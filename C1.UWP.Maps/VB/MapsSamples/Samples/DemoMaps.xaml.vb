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

Partial Public NotInheritable Class DemoMaps
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        comboSources.ItemsSource = [Enum].GetValues(GetType(Sources))
        comboSources.SelectedItem = Sources.VirtualEarthHybrid
    End Sub

    Sub DemoMaps_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Me.maps.TargetCenter = New Point(-79.9247, 40.4587)
    End Sub

    Sub DemoMaps_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        Me.maps.Zoom = 1.1
        Me.maps.Center = New Point()
        comboSources.SelectedIndex = 0
    End Sub

    Public Enum Sources
        VirtualEarthAerial
        VirtualEarthRoad
        VirtualEarthHybrid
    End Enum

    Private sourcesMap As New Dictionary(Of Sources, MultiScaleTileSource)() From {
        {Sources.VirtualEarthAerial, New VirtualEarthAerialSource()},
        {Sources.VirtualEarthRoad, New VirtualEarthRoadSource()},
        {Sources.VirtualEarthHybrid, New VirtualEarthHybridSource()}
    }

    Private _source As Sources
    Public Property Source() As Sources
        Get
            Return _source
        End Get
        Set
            _source = Value
            If Maps IsNot Nothing Then
                Maps.Source = sourcesMap(_source)
            End If
        End Set
    End Property

    Private Sub comboSources_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Source = CType(comboSources.SelectedItem, Sources)
    End Sub

    Private Sub item_Tapped(sender As Object, e As TappedRoutedEventArgs)
        Dim layer As C1MapItemsLayer = TryCast(Maps.Layers(0), C1MapItemsLayer)
        Dim item As FrameworkElement = TryCast(layer.Items(0), FrameworkElement)
        FlyoutBase.GetAttachedFlyout(item).ShowAt(item)
    End Sub
End Class