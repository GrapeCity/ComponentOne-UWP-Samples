Imports C1.Xaml.Maps
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation

Partial Public NotInheritable Class ZoomTool
    Inherits UserControl

    Public Sub New()
        Me.InitializeComponent()

        If Me.Orientation = Windows.UI.Xaml.Controls.Orientation.Horizontal Then
            Me.VerticalZoomTool.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        Else
            Me.HorizontalZoomTool.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        End If

        AddHandler Me.HIncrementButton.Tapped, AddressOf HIncrementButton_Tapped
        AddHandler Me.VIncrementButton.Tapped, AddressOf VIncrementButton_Tapped
        AddHandler Me.HDecrementButton.Tapped, AddressOf HDecrementButton_Tapped
        AddHandler Me.VDecrementButton.Tapped, AddressOf VDecrementButton_Tapped
    End Sub

    Private Sub VDecrementButton_Tapped(ByVal sender As Object, ByVal e As TappedRoutedEventArgs)
        Me.VSlider.Value -= 1
    End Sub

    Private Sub HDecrementButton_Tapped(ByVal sender As Object, ByVal e As TappedRoutedEventArgs)
        Me.HSlider.Value -= 1
    End Sub

    Private Sub VIncrementButton_Tapped(ByVal sender As Object, ByVal e As TappedRoutedEventArgs)
        Me.VSlider.Value += 1
    End Sub

    Private Sub HIncrementButton_Tapped(ByVal sender As Object, ByVal e As TappedRoutedEventArgs)
        Me.HSlider.Value += 1
    End Sub

    Public Property Orientation As Orientation
    Public Shared ReadOnly MapsProperty As DependencyProperty = DependencyProperty.Register("Maps", GetType(C1Maps), GetType(ZoomTool), New PropertyMetadata(Nothing, AddressOf OnMapsPropertyChanged))

    Public Property Maps As C1Maps
        Get
            Return CType(Me.GetValue(MapsProperty), C1Maps)
        End Get
        Set(ByVal value As C1Maps)
            Me.SetValue(MapsProperty, value)
        End Set
    End Property

    Private Shared Sub OnMapsPropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        TryCast(d, ZoomTool).OnMapsChanged()
    End Sub

    Private Sub OnMapsChanged()
        Dim binding As Binding = New Binding()
        binding.Path = New PropertyPath("TargetZoom")
        binding.Source = Maps
        binding.Mode = BindingMode.TwoWay

        If Me.Orientation = Windows.UI.Xaml.Controls.Orientation.Horizontal Then
            Me.HSlider.SetBinding(Slider.ValueProperty, binding)
        Else
            Me.VSlider.SetBinding(Slider.ValueProperty, binding)
        End If
    End Sub
End Class
