Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.System
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml

Partial Public NotInheritable Class HierarchicalDropDown
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub C1TreeView_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        If e.Key = VirtualKey.Enter Then
            UpdateSelection()
            e.Handled = True
        End If
    End Sub

    Private Sub UpdateSelection()
        If treeSelection.SelectedItem IsNot Nothing Then
            selection.Text = treeSelection.SelectedItem.Header.ToString()
        Else
            selection.Text = Strings.HierarchicalDropDown_TB_Header.ToString()
        End If
        soccerCountries.IsDropDownOpen = False
    End Sub

    Private Sub C1TreeView_ItemClicked(sender As Object, e As SourcedEventArgs)
        UpdateSelection()
    End Sub

    Private Sub ContentControl_MouseLeftButtonDown(sender As Object, e As EventArgs)
        soccerCountries.IsDropDownOpen = True
    End Sub

End Class