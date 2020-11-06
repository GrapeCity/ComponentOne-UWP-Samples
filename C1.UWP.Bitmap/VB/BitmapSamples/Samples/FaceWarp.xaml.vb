
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection

Imports Windows.ApplicationModel
Imports Windows.Foundation
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.UI
Imports Windows.UI.Popups
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Shapes

Imports C1.Xaml
Imports C1.Xaml.Bitmap

Imports D2D = C1.Util.DX.Direct2D
Imports D3D = C1.Util.DX.Direct3D11
Imports DXGI = C1.Util.DX.DXGI
Imports WIC = C1.Util.DX.WIC
Imports C1.Util.DX

Partial Public NotInheritable Class FaceWarp
    Inherits Page

    Private _bitmap As C1Bitmap
    Private _savedCopy As C1Bitmap
    Private _dragHelper As C1DragHelper
    Private _app As Application
    Private _position As Point
    Private _line As Line
    Private _warpStart As Point2F
    Private _warpEnd As Point2F
    Private _initialized As Boolean

    Private _imageSource As SurfaceImageSource
    Private _sisNative As DXGI.ISurfaceImageSourceNative

    Private _d2dFactory As D2D.Factory2
    Private _wicFactory As WIC.ImagingFactory2

    Private _dxgiDevice As DXGI.Device
    Private _d2dContext As D2D.DeviceContext1

    Private _blur As D2D.Effects.GaussianBlur
    Private _warp As WarpEffect

    Public Sub New()
        InitializeComponent()

        AddHandler Loaded, AddressOf Page_Loaded
        AddHandler Unloaded, AddressOf Page_Unloaded
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        CreateDeviceIndependentResources()
        _bitmap = New C1Bitmap(_wicFactory)

        CreateDeviceResources()

        LoadDefaultImage()
        _dragHelper = New C1DragHelper(image, captureElementOnPointerPressed:=True, initialThreshold:=0)
        AddHandler _dragHelper.DragStarted, AddressOf OnDragStarted
        AddHandler _dragHelper.DragDelta, AddressOf OnDragDelta
        AddHandler _dragHelper.DragCompleted, AddressOf OnDragCompleted

        _app = Application.Current
        If _app IsNot Nothing Then
            AddHandler _app.Suspending, AddressOf App_Suspending
        End If
        _initialized = True
    End Sub

    Private Sub Page_Unloaded(sender As Object, e As RoutedEventArgs)
        If _initialized Then
            If _app IsNot Nothing Then
                RemoveHandler _app.Suspending, AddressOf App_Suspending
            End If
            _initialized = False

            _dragHelper.FinalizeHelper()

            DiscardDeviceResources()

            ClearSavedCopy()
            _bitmap.Dispose()

            DiscardDeviceIndependentResources()
        End If
    End Sub

    Private Sub App_Suspending(sender As Object, e As SuspendingEventArgs)
        TrimDxgiDevice()
    End Sub

    Private Sub OnDragStarted(sender As Object, e As C1DragStartedEventArgs)
        _position = e.GetPosition(image)
        _line = New Line() With {
                .X1 = _position.X,
                .Y1 = _position.Y,
                .X2 = _position.X,
                .Y2 = _position.Y,
                .Stroke = New SolidColorBrush(Colors.Blue),
                .StrokeThickness = 7,
                .StrokeEndLineCap = PenLineCap.Triangle,
                .StrokeStartLineCap = PenLineCap.Round
        }
        imageGrid.Children.Add(_line)
    End Sub

    Private Sub OnDragDelta(sender As Object, e As C1DragDeltaEventArgs)
        Dim pos As Point = e.GetPosition(image)
        _line.X2 = pos.X
        _line.Y2 = pos.Y
    End Sub

    Private Sub OnDragCompleted(sender As Object, e As C1DragCompletedEventArgs)
        imageGrid.Children.Remove(_line)
        Dim start As Point = New Point(_position.X + e.CumulativeTranslation.X, _position.Y + e.CumulativeTranslation.Y)
        Dim [end] As Point = _position

        Dim w As Double = image.ActualWidth
        Dim h As Double = image.ActualHeight
        _warpStart = New Point2F(CSng(start.X / w), CSng(start.Y / h))
        _warpEnd = New Point2F(CSng([end].X / w), CSng([end].Y / h))

        UpdateImageSource(True)
    End Sub

    Private Sub LoadDefaultImage()
        Dim asm As Assembly = GetType(Crop).GetTypeInfo().Assembly
        Using stream As Stream = asm.GetManifestResourceStream("BitmapSamples.Sheep.jpg")
            _bitmap.Load(stream, New FormatConverter(PixelFormat.Format32bppPBGRA))
        End Using

        ClearSavedCopy()
        _savedCopy = _bitmap.Transform()

        CreateImageSource()
    End Sub

    Private Async Sub LoadImage(sender As Object, e As RoutedEventArgs)
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

                CreateImageSource()
                Return
            Catch ex As Exception
                errMsg = ex.Message
            End Try
            LoadDefaultImage()
            Dim md As New MessageDialog(Strings.ImageFormatNotSupportedException + errMsg, "")
            Await md.ShowAsync()
        End If
    End Sub

    Private Async Sub ExportImage(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add("png", New List(Of String)() From {
            ".png"
        })
        picker.DefaultFileExtension = ".png"

        Dim file As StorageFile = Await picker.PickSaveFileAsync()

        If file IsNot Nothing Then
            Await _bitmap.SaveAsPngAsync(file, Nothing)
        End If
    End Sub

    Private Sub Restart(sender As Object, e As RoutedEventArgs)
        _bitmap.ImportAsFragment(_savedCopy, 0, 0)
        UpdateImageSource(False)
    End Sub

    Private Sub ClearSavedCopy()
        If _savedCopy IsNot Nothing Then
            _savedCopy.Dispose()
            _savedCopy = Nothing
        End If
    End Sub

    Private Sub CreateDeviceIndependentResources()
        _d2dFactory = D2D.Factory2.Create(D2D.FactoryType.SingleThreaded)
        _wicFactory = WIC.ImagingFactory2.Create()
    End Sub

    Private Sub DiscardDeviceIndependentResources()
        DXUtil.Dispose(_d2dFactory)
        DXUtil.Dispose(_wicFactory)
    End Sub

    Private Sub CreateDeviceResources()
        Dim actualLevel As D3D.FeatureLevel
        Dim d3dContext As D3D.DeviceContext = Nothing
        Dim d3dDevice As New D3D.Device(IntPtr.Zero)
        Dim result As HResult = HResult.Ok

        For i As Integer = 0 To 1
            ' use WARP if hardware is not available
            Dim dt As D3D.DriverType = If(i = 0, D3D.DriverType.Hardware, D3D.DriverType.Warp)
            result = D3D.D3D11.CreateDevice(Nothing, dt, IntPtr.Zero, D3D.DeviceCreationFlags.BgraSupport Or D3D.DeviceCreationFlags.SingleThreaded, Nothing, 0,
                D3D.D3D11.SdkVersion, d3dDevice, actualLevel, d3dContext)
            If result.Code <> -2005270524 Then
                ' DXGI_ERROR_UNSUPPORTED
                Exit For
            End If
        Next
        result.CheckError()
        d3dContext.Dispose()

        _dxgiDevice = d3dDevice.QueryInterface(Of DXGI.Device)()
        d3dDevice.Dispose()

        Dim d2dDevice As D2D.Device1 = D2D.Device1.Create(_d2dFactory, _dxgiDevice)
        _d2dContext = d2dDevice.CreateDeviceContext1(D2D.DeviceContextOptions.None)
        _d2dContext.SetUnitMode(D2D.UnitMode.Pixels)
        d2dDevice.Dispose()

        Dim sourceEffect As D2D.Effect = D2D.Effect.RegisterAndCreateCustom(Of WarpEffect)(_d2dFactory, _d2dContext)
        _warp = DirectCast(sourceEffect.CustomEffect, WarpEffect)
        _warp.Effect = sourceEffect

        _blur = D2D.Effects.GaussianBlur.Create(_d2dContext)
        _blur.StandardDeviation = 2.0F
    End Sub

    Friend Sub DiscardDeviceResources()
        ClearImageSource()

        DXUtil.Dispose(_blur)
        DXUtil.Dispose(_warp)

        DXUtil.Dispose(_dxgiDevice)
        DXUtil.Dispose(_d2dContext)
    End Sub

    Private Sub TrimDxgiDevice()
        If _dxgiDevice IsNot Nothing Then
            Using dxgiDevice As DXGI.Device3 = _dxgiDevice.QueryInterface(Of DXGI.Device3)()
                dxgiDevice.Trim()
            End Using
        End If
    End Sub

    Private Sub CreateImageSource()
        ClearImageSource()

        _imageSource = New SurfaceImageSource(_bitmap.PixelWidth, _bitmap.PixelHeight, False)

        _sisNative = ComObject.QueryInterface(Of DXGI.ISurfaceImageSourceNative)(_imageSource)
        _sisNative.SetDevice(_dxgiDevice)

        UpdateImageSource(False)

        image.Source = _imageSource
    End Sub

    Private Sub ClearImageSource()
        If _sisNative IsNot Nothing Then
            image.Source = Nothing
            _sisNative.Dispose()
            _sisNative = Nothing
            _imageSource = Nothing
        End If
    End Sub

    Private Sub UpdateImageSource(applyWarpEffect As Boolean)
        Dim surfaceOffset As Point2L = Point2L.Empty
        Dim dxgiSurface As DXGI.Surface = Nothing

        Dim w As Integer = _bitmap.PixelWidth
        Dim h As Integer = _bitmap.PixelHeight
        Dim hr As HResult = _sisNative.BeginDraw(New RectL(w, h), surfaceOffset, dxgiSurface)
        If hr = DXGI.ResultCode.DeviceRemoved OrElse hr = DXGI.ResultCode.DeviceReset Then
            DiscardDeviceResources()
            CreateDeviceResources()
            _sisNative.SetDevice(_dxgiDevice)
            Return
        End If
        hr.CheckError()

        Dim rt As D2D.DeviceContext1 = _d2dContext

        Dim bpTarget As New D2D.BitmapProperties1(New D2D.PixelFormat(DXGI.Format.B8G8R8A8_UNorm, D2D.AlphaMode.Premultiplied), CSng(_bitmap.DpiX), CSng(_bitmap.DpiY), D2D.BitmapOptions.Target Or D2D.BitmapOptions.CannotDraw)

        Dim targetBmp As D2D.Bitmap1 = D2D.Bitmap1.Create(rt, dxgiSurface, bpTarget)
        dxgiSurface.Dispose()

        rt.SetTarget(targetBmp)

        rt.BeginDraw()
        rt.Clear(Nothing)

        Dim buffer As D2D.Bitmap1 = _bitmap.ToD2DBitmap1(rt, D2D.BitmapOptions.None)
        If Not applyWarpEffect Then
            rt.DrawBitmap(buffer, New RectF(surfaceOffset.X, surfaceOffset.Y, w, h))
        Else
            _warp.SetNormPositions(_warpStart, _warpEnd)
            _warp.Effect.SetInput(0, buffer)

            '_blur.SetInputEffect(0, _warp.Effect);
            'rt.DrawImage(_blur, new Point2F(surfaceOffset.X, surfaceOffset.Y));
            rt.DrawImage(_warp.Effect, New Point2F(surfaceOffset.X, surfaceOffset.Y))
        End If
        buffer.Dispose()

        rt.EndDraw()
        rt.SetTarget(Nothing)

        If applyWarpEffect Then
            Dim srcRect As New RectL(surfaceOffset.X, surfaceOffset.Y, w, h)
            _bitmap.ImportAsFragment(targetBmp, rt, srcRect, 0, 0)
        End If
        targetBmp.Dispose()

        _sisNative.EndDraw()
    End Sub
End Class
