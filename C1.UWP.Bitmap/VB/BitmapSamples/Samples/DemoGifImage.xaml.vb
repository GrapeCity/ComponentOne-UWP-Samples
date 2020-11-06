
Imports System.Reflection
Imports Windows.Foundation.Metadata
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Imaging

Partial Public NotInheritable Class DemoGifImage
    Inherits Page
    Shared piIsAnimatedBitmap As PropertyInfo
    Shared miPlay As MethodInfo, miStop As MethodInfo

    Shared Sub New()
        If ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Media.Imaging.BitmapImage", "IsAnimatedBitmap") Then
            Dim bitmapImageType As Type = GetType(BitmapImage)
            piIsAnimatedBitmap = bitmapImageType.GetProperty("IsAnimatedBitmap")
            miPlay = bitmapImageType.GetMethod("Play")
            miStop = bitmapImageType.GetMethod("Stop")
        End If
    End Sub

    Public Sub New()
        InitializeComponent()

        AddHandler gifImage.ImageOpened, AddressOf GifImage_ImageOpened
        gifImage.UriSource = New Uri("ms-appx:///BitmapSamplesLib/Assets/C1FlexChartZoom.gif")
    End Sub

    Private Sub GifImage_ImageOpened(sender As Object, e As RoutedEventArgs)
        If piIsAnimatedBitmap IsNot Nothing AndAlso CBool(piIsAnimatedBitmap.GetValue(gifImage)) Then
            playbackButtons.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As RoutedEventArgs)
        If miPlay IsNot Nothing Then
            miPlay.Invoke(gifImage, New Object(-1) {})
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As RoutedEventArgs)
        If miStop IsNot Nothing Then
            miStop.Invoke(gifImage, New Object(-1) {})
        End If
    End Sub

    Private Sub ZoomInButton_Click(sender As Object, e As RoutedEventArgs)
        scrollViewer.ChangeView(Nothing, Nothing, scrollViewer.ZoomFactor / 0.7F)
    End Sub

    Private Sub ZoomOutButton_Click(sender As Object, e As RoutedEventArgs)
        scrollViewer.ChangeView(Nothing, Nothing, scrollViewer.ZoomFactor * 0.7F)
    End Sub
End Class
