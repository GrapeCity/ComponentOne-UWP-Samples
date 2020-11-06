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
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox

Partial Public NotInheritable Class InsertTableTool
    Inherits UserControl
    Public Property Popup() As Flyout

    Public Property RichTextBox() As C1RichTextBox

    Public Sub New()
        Me.InitializeComponent()

        ' init flyout
        Popup = New Flyout()
        Popup.Content = Me
        Popup.Placement = FlyoutPlacementMode.Top
    End Sub

    Public Sub Show(placementTarget As FrameworkElement)
        Popup.ShowAt(placementTarget)
    End Sub

    Public Sub Close()
        Popup.Hide()
    End Sub

    Private Sub btnInsertTable_Click(sender As Object, e As RoutedEventArgs)
        Dim rows As Integer = CType(numRowsBox.Value, Integer)
        Dim cols As Integer = CType(numColsBox.Value, Integer)
        If RichTextBox IsNot Nothing AndAlso rows > 0 AndAlso cols > 0 Then
            RichTextBox.Selection.Start.InsertTable(rows, cols)
        End If
        Close()
    End Sub
End Class