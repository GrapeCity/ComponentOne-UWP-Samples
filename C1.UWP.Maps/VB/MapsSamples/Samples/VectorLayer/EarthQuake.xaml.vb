Imports Windows.UI.Xaml.Shapes
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
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

Partial Public NotInheritable Class EarthQuake
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Sub EarthQuake_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Me.maps.Layers.Count = 0 Then
            Dim layer As New C1VectorLayer() With {
                .ItemStyle = CType(Me.Resources("style"), Style)
            }
            Utils.LoadKMLFromResources(layer, "MapsSamples.2.5_day_depth.kml", True, Nothing)
            Me.maps.Layers.Add(layer)
        Else
            Dim layer As C1VectorLayer = TryCast(maps.Layers(0), C1VectorLayer)
            Utils.LoadKMLFromResources(layer, "MapsSamples.2.5_day_depth.kml", True, Nothing)
        End If
    End Sub

    Sub EarthQuake_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        ' Release memory
        Dim vl As C1VectorLayer = TryCast(maps.Layers(0), C1VectorLayer)
        maps.Layers.Clear()
    End Sub
End Class