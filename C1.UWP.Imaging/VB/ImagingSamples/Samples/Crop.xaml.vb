Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Imaging
Imports C1.Xaml

Partial Public NotInheritable Class Crop
    Inherits Page
    Private bitmap As New C1Bitmap()
    Private selection As Rect

    Public Sub New()
        InitializeComponent()

        LoadDefaultImage()
        Image.Source = bitmap.ImageSource

        Dim mouseHelper As New C1DragHelper(imageGrid)
        AddHandler mouseHelper.DragStarted, AddressOf OnDragStarted
        AddHandler mouseHelper.DragDelta, AddressOf OnDragDelta
    End Sub

    Private _startPosition As Point
    Sub OnDragStarted(sender As Object, e As C1DragStartedEventArgs)
        _startPosition = e.Origin
    End Sub

    Sub OnDragDelta(sender As Object, e As C1DragDeltaEventArgs)
        Dim transform As GeneralTransform = Window.Current.Content.TransformToVisual(image)
        Dim start As Point = transform.TransformPoint(_startPosition)
        Dim [end] As Point = transform.TransformPoint(e.GetPosition(Nothing))
        start.X = Math.Min(CType(Math.Max(start.X, 0), Double), bitmap.Width)
        [end].X = Math.Min(CType(Math.Max([end].X, 0), Double), bitmap.Width)
        start.Y = Math.Min(CType(Math.Max(start.Y, 0), Double), bitmap.Height)
        [end].Y = Math.Min(CType(Math.Max([end].Y, 0), Double), bitmap.Height)

        selection = New Rect(New Point(Math.Round(Convert.ToDouble(Math.Min(start.X, [end].X))), Math.Round(Convert.ToDouble(Math.Min(start.Y, [end].Y)))), New Size(Convert.ToDouble(Math.Round(Math.Abs(start.X - [end].X))), Convert.ToDouble(Math.Round(Math.Abs(start.Y - [end].Y)))))

        UpdateMask()
    End Sub

    Sub UpdateMask()
        topMask.Height = selection.Top
        bottomMask.Height = bitmap.Height - selection.Bottom
        leftMask.Width = selection.Left
        rightMask.Width = bitmap.Width - selection.Right
    End Sub

    Sub LoadDefaultImage()
        Dim asm As Assembly = GetType(Crop).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("ImagingSamples.Lenna.jpg")
        LoadImageStream(stream)
    End Sub

    Private Async Sub LoadImage(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileOpenPicker()

        picker.FileTypeFilter.Add(".png")
        picker.FileTypeFilter.Add(".jpg")
        picker.FileTypeFilter.Add(".gif")
        picker.FileTypeFilter.Add(".jpeg")

        Dim file As StorageFile = Await picker.PickSingleFileAsync()

        If file IsNot Nothing Then
            Using fileStream As Stream = Await file.OpenStreamForReadAsync()
                Try
                    LoadImageStream(fileStream)
                Catch ex As Exception
                    LoadDefaultImage()
                    Dim md As New MessageDialog(Strings.ImageFormatNotSupportedException + ex.Message, "")
                    md.ShowAsync()
                End Try
            End Using
        End If
    End Sub

    Sub LoadImageStream(stream As Stream)
        bitmap.SetStream(stream)

        imageGrid.Width = bitmap.Width
        imageGrid.Height = bitmap.Height

        selection = New Rect(0, 0, bitmap.Width, bitmap.Height)
        UpdateMask()
    End Sub

    Private Async Sub ExportImage(sender As Object, e As RoutedEventArgs)
        If selection.Width = 0 OrElse selection.Height = 0 Then
            Dim md As New MessageDialog(Strings.EmptySelectionMessage)
            md.ShowAsync()
            Return
        End If
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add("png", New List(Of String)() From {
            ".png"
        })
        picker.DefaultFileExtension = ".png"

        Dim file As StorageFile = Await picker.PickSaveFileAsync()

        If file IsNot Nothing Then
            Dim saveStream As Stream = Await file.OpenStreamForWriteAsync()
            Dim crop As New C1Bitmap(CType(selection.Width, Integer), CType(selection.Height, Integer))
            crop.BeginUpdate()
            Dim x As Integer = 0
            While x < selection.Width
                Dim y As Integer = 0
                While y < selection.Height
                    crop.SetPixel(x, y, bitmap.GetPixel(x + CType(selection.X, Integer), y + CType(selection.Y, Integer)))
                    System.Threading.Interlocked.Increment(y)
                End While
                System.Threading.Interlocked.Increment(x)
            End While
            crop.EndUpdate()
            Dim readStream As Stream = crop.GetStream(ImageFormat.Png, True)
            Dim data As Byte() = New Byte(readStream.Length) {}
            readStream.Read(data, 0, CType(readStream.Length, Integer))
            saveStream.Write(data, 0, data.Length)
            saveStream.Dispose()
        End If
    End Sub
End Class