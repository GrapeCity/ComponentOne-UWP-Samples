Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Threading.Tasks

Imports Windows.Foundation
Imports Windows.Graphics.Imaging
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.UI.Popups
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Input

Imports C1.Xaml
Imports C1.Xaml.Bitmap
Imports C1.Util.DX

Public NotInheritable Class Transform
    Inherits Page

    Private _bitmap As C1Bitmap
    Private _softwareBitmap As SoftwareBitmap
    Private _sbs As SoftwareBitmapSource
    Private _savedCopy As C1Bitmap

    Private _startPosition As Point
    Private _dragHelper As C1DragHelper
    Private _selection As Rect
    Private _initialized As Boolean

    Public Sub New()
        InitializeComponent()

        AddHandler Me.Loaded, AddressOf Page_Loaded
        AddHandler Me.Unloaded, AddressOf Page_Unloaded
    End Sub

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        _bitmap = New C1Bitmap()

        Await LoadDefaultImage()

        _dragHelper = New C1DragHelper(imageGrid)
        AddHandler _dragHelper.DragStarted, AddressOf OnDragStarted
        AddHandler _dragHelper.DragDelta, AddressOf OnDragDelta

        AddHandler imageGrid.Tapped, AddressOf ImageGrid_Tapped

        _initialized = True
    End Sub

    Private Sub Page_Unloaded(sender As Object, e As RoutedEventArgs)
        If _initialized Then
            _initialized = False
            _dragHelper.FinalizeHelper()

            CleanImageSource()
            ClearSavedCopy()
            _bitmap.Dispose()
        End If
    End Sub

    Private Async Function LoadDefaultImage() As Task
        Dim asm As Assembly = GetType(Crop).GetTypeInfo().Assembly
        Using stream As Stream = asm.GetManifestResourceStream("BitmapSamples.HousePlan.jpg")
            _bitmap.Load(stream, New FormatConverter(PixelFormat.Format32bppPBGRA))
        End Using

        ClearSavedCopy()
        _savedCopy = _bitmap.Transform()

        Await UpdateImageSource()
    End Function

    Private Async Sub LoadImage_Clicked(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileOpenPicker()

        picker.FileTypeFilter.Add(".ico")
        picker.FileTypeFilter.Add(".bmp")
        picker.FileTypeFilter.Add(".gif")
        picker.FileTypeFilter.Add(".png")
        picker.FileTypeFilter.Add(".jpg")
        picker.FileTypeFilter.Add(".jpeg")
        picker.FileTypeFilter.Add(".jxr")
        picker.FileTypeFilter.Add(".tif")
        picker.FileTypeFilter.Add(".tiff")

        Dim file As StorageFile = Await picker.PickSingleFileAsync()

        If file IsNot Nothing Then
            Dim errMsg As String = String.Empty
            Try
                Await _bitmap.LoadAsync(file, New FormatConverter(PixelFormat.Format32bppPBGRA))

                ClearSavedCopy()
                _savedCopy = _bitmap.Transform()

                Await UpdateImageSource()
                Return
            Catch ex As Exception
                errMsg = ex.Message
            End Try
            Await LoadDefaultImage()
            Dim md As New MessageDialog(Strings.ImageFormatNotSupportedException + errMsg, "")
            Await md.ShowAsync()
        End If
    End Sub

    Private Async Function UpdateImageSource() As Task
        CleanImageSource()
        _softwareBitmap = _bitmap.ToSoftwareBitmap()
        _sbs = New SoftwareBitmapSource()
        Await _sbs.SetBitmapAsync(_softwareBitmap)
        image.Source = _sbs

        imageGrid.Width = _bitmap.PixelWidth
        imageGrid.Height = _bitmap.PixelHeight

        InitSelection()
    End Function

    Private Sub CleanImageSource()
        If _sbs IsNot Nothing Then
            image.Source = Nothing
            _sbs.Dispose()
            _softwareBitmap.Dispose()
            _sbs = Nothing
        End If
    End Sub

    Private Async Sub ExportImage_Clicked(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add("png", New List(Of String)() From {
            ".png"
        })
        picker.DefaultFileExtension = ".png"

        Dim file As StorageFile = Await picker.PickSaveFileAsync()

        If file IsNot Nothing Then
            Await _bitmap.SaveAsPngAsync(file, Nothing)
            InitSelection()
        End If
    End Sub

    Private Async Sub Restart_Clicked(sender As Object, e As RoutedEventArgs)
        If _savedCopy IsNot Nothing Then
            _bitmap.Dispose()
            _bitmap = _savedCopy.Transform()
            Await UpdateImageSource()
        End If
    End Sub

    Private Sub ClearSavedCopy()
        If _savedCopy IsNot Nothing Then
            _savedCopy.Dispose()
            _savedCopy = Nothing
        End If
    End Sub

    Private Async Function ApplyTransform(t As BaseTransform) As Task
        Dim newBitmap As C1Bitmap = _bitmap.Transform(t)
        _bitmap.Dispose()
        _bitmap = newBitmap
        Await UpdateImageSource()
    End Function

    Private Async Sub CropToSelection_Clicked(sender As Object, e As RoutedEventArgs)
        Dim cropRect As RectL = (New RectD(_selection)).Round()
        Await ApplyTransform(New Clipper(New ImageRect(cropRect)))
    End Sub

    Private Async Sub RotateCW_Clicked(sender As Object, e As RoutedEventArgs)
        Await ApplyTransform(New FlipRotator(TransformOptions.Rotate90))
    End Sub

    Private Async Sub RotateCCW_Clicked(sender As Object, e As RoutedEventArgs)
        Await ApplyTransform(New FlipRotator(TransformOptions.Rotate270))
    End Sub

    Private Async Sub FlipH_Clicked(sender As Object, e As RoutedEventArgs)
        Await ApplyTransform(New FlipRotator(TransformOptions.FlipHorizontal))
    End Sub

    Private Async Sub FlipV_Clicked(sender As Object, e As RoutedEventArgs)
        Await ApplyTransform(New FlipRotator(TransformOptions.FlipVertical))
    End Sub

    Private Async Sub ScaleIn_Clicked(sender As Object, e As RoutedEventArgs)
        Dim px As Int32 = CInt(_bitmap.PixelWidth * 1.6F + 0.5F)
        Dim py As Int32 = CInt(_bitmap.PixelHeight * 1.6F + 0.5F)
        Await ApplyTransform(New Scaler(px, py, InterpolationMode.HighQualityCubic))
    End Sub

    Private Async Sub ScaleOut_Clicked(sender As Object, e As RoutedEventArgs)
        Dim px As Int32 = CInt(_bitmap.PixelWidth * 0.625F + 0.5F)
        Dim py As Int32 = CInt(_bitmap.PixelHeight * 0.625F + 0.5F)
        If px > 0 AndAlso py > 0 Then
            Await ApplyTransform(New Scaler(px, py, InterpolationMode.HighQualityCubic))
        End If
    End Sub

    Private Sub OnDragStarted(sender As Object, e As C1DragStartedEventArgs)
        _startPosition = e.Origin
    End Sub

    Private Sub OnDragDelta(sender As Object, e As C1DragDeltaEventArgs)
        Dim transform As GeneralTransform = Window.Current.Content.TransformToVisual(image)
        Dim start As Point = transform.TransformPoint(_startPosition)
        Dim [end] As Point = transform.TransformPoint(e.GetPosition(Nothing))
        start.X = Math.Min(CDbl(Math.Max(start.X, 0)), _bitmap.PixelWidth)
        [end].X = Math.Min(CDbl(Math.Max([end].X, 0)), _bitmap.PixelWidth)
        start.Y = Math.Min(CDbl(Math.Max(start.Y, 0)), _bitmap.PixelHeight)
        [end].Y = Math.Min(CDbl(Math.Max([end].Y, 0)), _bitmap.PixelHeight)

        _selection = New Rect(New Point(Math.Round(Convert.ToDouble(Math.Min(start.X, [end].X))), Math.Round(Convert.ToDouble(Math.Min(start.Y, [end].Y)))), New Size(Convert.ToDouble(Math.Round(Math.Abs(start.X - [end].X))), Convert.ToDouble(Math.Round(Math.Abs(start.Y - [end].Y)))))

        UpdateMask()
    End Sub

    Private Sub ImageGrid_Tapped(sender As Object, e As TappedRoutedEventArgs)
        InitSelection()
    End Sub

    Private Sub InitSelection()
        _selection = New Rect(0, 0, _bitmap.PixelWidth, _bitmap.PixelHeight)
        UpdateMask()
    End Sub

    Private Sub UpdateMask()
        topMask.Height = _selection.Top
        bottomMask.Height = _bitmap.PixelHeight - _selection.Bottom
        leftMask.Width = _selection.Left
        rightMask.Width = _bitmap.PixelWidth - _selection.Right
    End Sub

End Class
