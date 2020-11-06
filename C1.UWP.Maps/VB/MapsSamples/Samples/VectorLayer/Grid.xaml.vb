Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps

Partial Public NotInheritable Class Grid
    Inherits Page
    Private vl As C1VectorLayer
    Public Sub New()
        InitializeComponent()
    End Sub

    Sub Grid_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        Me.maps.Zoom = 2
        Me.maps.Center = New Point()
        Me.maps.Layers.Clear()
    End Sub

    Sub Grid_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim fc As Color = Colors.LightGray
        ' Color.FromArgb(0xff, 0xC0, 0x50, 0x4d);
        Dim bk As Color = Color.FromArgb(&HFF, &H44, &H44, &H44)
        Dim bb As Color = Colors.Black
        maps.Foreground = New SolidColorBrush(fc)
        maps.Background = New SolidColorBrush(bk)
        maps.BorderBrush = New SolidColorBrush(bb)

        vl = New C1VectorLayer()

        Dim stroke As New SolidColorBrush(Colors.LightGray)

        Dim lon As Integer = -180
        While lon <= 180
            Dim dc As New DoubleCollection()
            dc.Add(1)
            dc.Add(2)

            Dim pl As New C1VectorPolyline() With {
                .Stroke = stroke
            }
            Dim pc As New PointCollection()
            pc.Add(New Point(lon, -85))
            pc.Add(New Point(lon, +85))
            pl.Points = pc
            vl.Children.Insert(0, pl)

            Dim lbl As String = Math.Abs(lon).ToString() + Strings.Degree
            If lon > 0 Then
                lbl += Strings.East
            ElseIf lon < 0 Then
                lbl += Strings.West
            End If

            Dim pm As New C1VectorPlacemark() With {
                .GeoPoint = New Point(lon, 0),
                .Label = lbl,
                .LabelPosition = LabelPosition.Top
            }
            vl.Children.Add(pm)
            lon += 30
        End While

        Dim lat As Integer = -80
        While lat <= 80
            Dim dc As New DoubleCollection()
            dc.Add(1)
            dc.Add(2)

            Dim pl As New C1VectorPolyline() With {
                .Stroke = stroke
            }
            Dim pc As New PointCollection()
            pc.Add(New Point(-180, lat))
            pc.Add(New Point(180, lat))
            pl.Points = pc
            vl.Children.Insert(0, pl)

            Dim lbl As String = Math.Abs(lat).ToString() + Strings.Degree
            If lat > 0 Then
                lbl += Strings.North
            ElseIf lat < 0 Then
                lbl += Strings.South
            End If

            Dim pm As New C1VectorPlacemark() With {
                .GeoPoint = New Point(0, lat),
                .Label = lbl,
                .LabelPosition = LabelPosition.Right
            }
            vl.Children.Add(pm)
            lat += 20
        End While

        maps.Layers.Add(vl)
    End Sub
End Class