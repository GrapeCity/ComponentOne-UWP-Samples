Imports BasicLibrarySamples
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
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class UniformGridSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()

        panel.Children.Clear()
        Dim i As Integer = 0
        While i < 12
            AddItem()
            i += 1
        End While
    End Sub

    Private _colors As String() = {"#FF008B9C", "#FF0094D6", "#FF497331", "#FF9DCFC3", "#FF005B84"}
    Private _rnd As New Random()
    Private Sub AddItem()
        Dim colorKey As String = _rnd.PickOne(_colors)
        Dim backgroundColor As Color = colorKey.ToColor()
        panel.Children.Add(New ContentControl() With {
            .Content = (panel.Children.Count + 1).ToString(),
            .Background = New SolidColorBrush(backgroundColor),
            .Template = CType(Resources("PanelItemTemplate"), ControlTemplate)
        })
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As RoutedEventArgs)
        AddItem()
    End Sub
End Class