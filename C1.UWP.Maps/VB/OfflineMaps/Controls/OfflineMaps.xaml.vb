Imports C1.Xaml.Maps
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.UI
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation

Partial Public NotInheritable Class OfflineMapsN
    Inherits UserControl

    Private vl As C1VectorLayer
    Private currentPosition As Point

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf OnMapsLoaded
        currentPosition = New Point(-76.9057, 40.2726)
        vl = New C1VectorLayer()
        Me.maps.Layers.Add(vl)
    End Sub

    Private Sub OnMapsLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.maps.Center = currentPosition
        Me.maps.Source = New OfflineMapsSource()
        AddMark(currentPosition)
    End Sub

    Private Sub AddMark(ByVal position As Point)
        Dim clr As Color = Colors.DarkRed
        Dim mark As C1VectorPlacemark = New C1VectorPlacemark() With {
            .GeoPoint = position,
            .LabelPosition = LabelPosition.Top,
            .Geometry = Utils.CreateBaloon(),
            .Fill = New SolidColorBrush(clr)
        }
        vl.Children.Add(mark)
        vl.LabelVisibility = LabelVisibility.Visible
    End Sub
End Class

Public Class OfflineMapsSource
        Inherits C1MultiScaleTileSource

        Private Const uriFormat As String = "ms-appx:/Resources/Tiles/{Z}/{X}/{Y}.png"

        Public Sub New()
            MyBase.New(&H8000000, &H8000000, &H100, &H100, 0)
        End Sub

        Protected Overrides Sub GetTileLayers(ByVal tileLevel As Integer, ByVal tilePositionX As Integer, ByVal tilePositionY As Integer, ByVal source As IList(Of Object))
        If tileLevel > 8 Then
            Dim zoom As Integer = tileLevel - 8
            Dim uri As String = uriFormat
            uri = uri.Replace("{X}", tilePositionX.ToString())
            uri = uri.Replace("{Y}", tilePositionY.ToString())
            uri = uri.Replace("{Z}", zoom.ToString())
            source.Add(New Uri(uri))
        End If
    End Sub
    End Class
