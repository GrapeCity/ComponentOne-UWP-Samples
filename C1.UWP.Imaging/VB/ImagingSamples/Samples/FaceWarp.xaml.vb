Imports Windows.UI.Xaml.Shapes
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.UI
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

Partial Public NotInheritable Class FaceWarp
    Inherits Page
    Const imageSize As Integer = 470 * 470

    Private _originalBitmap As New C1Bitmap()
    Private _bitmap As New C1Bitmap()
    Private _screen As New C1Bitmap()
    Private _position As Point
    Private _line As Line

    Public Sub New()
        InitializeComponent()

        LoadDefaultImage()
        image.Source = _screen.ImageSource

        Dim mouseHelper As New C1DragHelper(image, captureElementOnPointerPressed:=True, initialThreshold:=0)
        _line = New Line()
        AddHandler mouseHelper.DragStarted, AddressOf OnDragStarted
        AddHandler mouseHelper.DragDelta, AddressOf OnDragDelta
        AddHandler mouseHelper.DragCompleted, AddressOf OnDragCompleted
    End Sub

    Private Sub OnDragStarted(s As Object, e As C1DragStartedEventArgs)
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

    Private Sub OnDragDelta(s As Object, e As C1DragDeltaEventArgs)
        Dim pos As Point = e.GetPosition(image)
        _line.X2 = pos.X
        _line.Y2 = pos.Y
    End Sub

    Private Sub OnDragCompleted(s As Object, e As C1DragCompletedEventArgs)
        imageGrid.Children.Remove(_line)
        Dim start As Point = _position
        Dim [end] As Point = New Point(_position.X + e.CumulativeTranslation.X, _position.Y + e.CumulativeTranslation.Y)

        _bitmap = New C1Bitmap(_screen)
        Warp(_bitmap, _screen, start, [end])
    End Sub


    Sub Warp(src As C1Bitmap, dst As C1Bitmap, start As Point, [end] As Point)
        dst.BeginUpdate()
        dst.Copy(src, False)

        Dim dist As Double = Distance(start, [end])
        Dim affectedDist As Double = dist * 1.5
        Dim affectedDistSquared As Double = affectedDist * affectedDist
        Dim row As Integer = 0
        While row < dst.Height
            Dim col As Integer = 0
            While col < dst.Width
                Dim point As New Point(col, row)
                If DistanceSq(start, point) > affectedDistSquared Then
                    Continue While
                End If
                If DistanceSq([end], point) < 0.25 Then
                    dst.SetPixel(col, row, src.GetPixel(CType(start.X, Integer), CType(start.Y, Integer)))
                    Continue While
                End If
                Dim dir As New Point(point.X - [end].X, point.Y - [end].Y)
                Dim t As Double = IntersectRayCircle([end], dir, start, affectedDist)
                TryT(-[end].X / dir.X, t)
                TryT(-[end].Y / dir.Y, t)
                TryT((dst.Width - [end].X) / dir.X, t)
                TryT((dst.Height - [end].X) / dir.X, t)
                Dim anchor As New Point([end].X + (point.X - [end].X) * t, [end].Y + (point.Y - [end].Y))
                Dim x As Double = start.X + (anchor.X - start.X) / t
                Dim y As Double = start.Y + (anchor.Y - start.Y) / t
                dst.SetPixel(col, row, src.GetInterpolatedPixel(x, y))
                System.Threading.Interlocked.Increment(col)
            End While
            System.Threading.Interlocked.Increment(row)
        End While
        dst.EndUpdate()
    End Sub

    Shared Function Distance(a As Point, b As Point) As Double
        Return Math.Sqrt(DistanceSq(a, b))
    End Function

    Shared Function DistanceSq(a As Point, b As Point) As Double
        Dim dx As Double = a.X - b.X
        Dim dy As Double = a.Y - b.Y
        Return dx * dx + dy * dy
    End Function

    Shared Sub TryT(t2 As Double, ByRef t As Double)
        If t2 > 0 AndAlso t2 < t Then
            t = t2
        End If
    End Sub

    Shared Function IntersectRayCircle(rayOri As Point, rayDir As Point, center As Point, radius As Double) As Double
        Dim a As Double = rayDir.X
        Dim b As Double = rayOri.X
        Dim c As Double = center.X
        Dim d As Double = rayDir.Y
        Dim e As Double = rayOri.Y
        Dim f As Double = center.Y
        Dim g As Double = radius * radius

        Dim num1 As Double = Math.Sqrt(d * (2 * a * (b - c) * (e - f) - d * (b * b - 2 * b * c + c * c - g)) - a * a * (e * e - 2 * e * f + f * f - g))
        Dim num2 As Double = a * (c - b) + d * (f - e)
        Return (If(num1 + num2 > 0, num1 + num2, num1 - num2)) / (a * a + d * d)
    End Function

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
        picker.FileTypeFilter.Add(".bmp")
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
        _bitmap.SetStream(stream)
        If _bitmap.Width * _bitmap.Height > imageSize Then
            Dim scale As Double = Math.Sqrt(imageSize * 1.0 / (_bitmap.Width * _bitmap.Height))
            Dim resizedBitmap As New C1Bitmap(CType((_bitmap.Width * scale), Integer), CType((_bitmap.Height * scale), Integer))
            resizedBitmap.Copy(_bitmap, True)
            _bitmap = resizedBitmap
        End If
        _originalBitmap.Copy(_bitmap, False)
        _screen.Copy(_bitmap, False)

        imageGrid.Width = _screen.Width
        imageGrid.Height = _screen.Height
    End Sub

    Private Async Sub ExportImage(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add("png", New List(Of String)() From {
            ".png"
        })
        picker.DefaultFileExtension = ".png"

        Dim file As StorageFile = Await picker.PickSaveFileAsync()

        If file IsNot Nothing Then
            Dim saveStream As Stream = Await file.OpenStreamForWriteAsync()
            Dim readStream As Stream = _screen.GetStream(ImageFormat.Png, True)
            Dim data As Byte() = New Byte(readStream.Length) {}
            readStream.Read(data, 0, CType(readStream.Length, Integer))
            saveStream.Write(data, 0, data.Length)
            saveStream.Dispose()
        End If
    End Sub

    Private Sub Restart(sender As Object, e As RoutedEventArgs)
        _bitmap.Copy(_originalBitmap, False)
        _screen.Copy(_originalBitmap, False)
    End Sub
End Class