Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.Foundation
Imports System

''' <summary>
''' Interaction logic for Basic.xaml
''' </summary>
Partial Public Class Basic
    Inherits Page
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub OnBasicLoaded(sender As Object, e As Windows.UI.Xaml.RoutedEventArgs) Handles Me.Loaded
        Dim pngImage As New BitmapImage(New Uri("ms-appx:///AnnotationExplorerLib/Assets/Image.png"))
        imageAnno.Source = pngImage
        AddPoints(polygonAnno.Points)
        flexChart.Invalidate()
    End Sub

    Sub AddPoints(pts As PointCollection)
        If Util.IsWindowsDevice Then
            pts.Add(New Point(100, 25))
            pts.Add(New Point(50, 70))
            pts.Add(New Point(75, 115))
            pts.Add(New Point(125, 115))
            pts.Add(New Point(150, 70))
        Else
            pts.Add(New Point(200, 25))
            pts.Add(New Point(150, 70))
            pts.Add(New Point(175, 115))
            pts.Add(New Point(225, 115))
            pts.Add(New Point(250, 70))
        End If
    End Sub
End Class