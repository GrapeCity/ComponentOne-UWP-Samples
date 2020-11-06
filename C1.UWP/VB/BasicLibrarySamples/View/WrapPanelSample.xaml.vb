Imports BasicLibrarySamples
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class WrapPanelSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        Me.comboOrientation.SelectedIndex = 0
    End Sub

    Private Sub comboOrientation_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If comboOrientation.SelectedIndex = 0 Then
            panel.Orientation = Orientation.Horizontal
            scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto
        Else
            panel.Orientation = Orientation.Vertical
            scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
        End If
    End Sub
End Class