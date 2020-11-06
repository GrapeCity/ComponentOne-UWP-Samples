Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps

Partial Public NotInheritable Class CustomTileSource
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        Me.OSMSource.Source = New OpenStreetMapsSource()
    End Sub

    Sub CustomTileSource_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        Me.OSMSource.Zoom = 1
        Me.OSMSource.Center = New Point()
    End Sub

    Public Class OpenStreetMapsSource
        Inherits C1MultiScaleTileSource
        Private ReadOnly tilePathPrefixes As String() = {"a", "b", "c"}
        Private ReadOnly rand As New Random()
        Private Const uriFormat As String = "http://{S}.tile.openstreetmap.org/{Z}/{X}/{Y}.png"

        Public Sub New()
            MyBase.New(&H8000000, &H8000000, &H100, &H100, 0)
        End Sub

        Protected Overrides Sub GetTileLayers(tileLevel As Integer, tilePositionX As Integer, tilePositionY As Integer, sources As IList(Of Object))
            If tileLevel > 8 Then
                Dim zoom As Integer = tileLevel - 8
                Dim prefix As String = tilePathPrefixes(rand.[Next](3))
                Dim url As String = uriFormat

                url = url.Replace("{S}", prefix)
                url = url.Replace("{Z}", zoom.ToString())
                url = url.Replace("{X}", tilePositionX.ToString())
                url = url.Replace("{Y}", tilePositionY.ToString())
                sources.Add(New Uri(url))
            End If
        End Sub
    End Class

    Private Sub btnZoomIn_Click(sender As Object, e As RoutedEventArgs)
        Me.OSMSource.TargetZoom += 1.0
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As RoutedEventArgs)
        Me.OSMSource.TargetZoom -= 1.0
    End Sub

End Class