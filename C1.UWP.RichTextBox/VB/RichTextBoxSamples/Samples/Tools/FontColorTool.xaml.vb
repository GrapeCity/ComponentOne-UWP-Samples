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
Imports C1.Xaml.RichTextBox
Imports C1.Xaml

Partial Public NotInheritable Class FontColorTool
    Inherits UserControl
    Public Property Popup() As Flyout

    Public Property RichTextBox() As C1RichTextBox

    Public Property ColorMode() As FontColorMode

    Public Sub New()
        Me.InitializeComponent()

        ' init flyout
        Popup = New Flyout()
        Popup.Content = Me
        Popup.Placement = FlyoutPlacementMode.Bottom

        ColorMode = FontColorMode.Foreground
    End Sub

    Public Sub Show(placementTarget As FrameworkElement)
        Popup.ShowAt(placementTarget)
    End Sub

    Public Sub Close()
        Popup.Hide()
    End Sub

    Private Sub colorListBox_ItemTapped(sender As Object, e As C1TappedEventArgs)
        Dim item As C1ListBoxItem = TryCast(sender, C1ListBoxItem)
        Dim b As Border = TryCast(item.Content, Border)
        If ColorMode = FontColorMode.Background Then
            If Equals(b.Background, RichTextBox.Selection.InlineBackground) Then
                RichTextBox.Selection.InlineBackground = RichTextBox.Background
            Else
                RichTextBox.Selection.InlineBackground = b.Background
            End If
        Else
            If Equals(b.Background, RichTextBox.Selection.InlineBackground) Then
                RichTextBox.Selection.Foreground = RichTextBox.Foreground
            Else
                RichTextBox.Selection.Foreground = b.Background
            End If
        End If

        Close()
    End Sub

    Function Equals(source As Brush, dest As Brush) As Boolean
        Dim left As SolidColorBrush = TryCast(source, SolidColorBrush)
        Dim right As SolidColorBrush = TryCast(dest, SolidColorBrush)
        If left IsNot Nothing AndAlso right IsNot Nothing Then
            Return left.Color.Equals(right.Color)
        End If
        Return False
    End Function
End Class

Public Enum FontColorMode
    Background
    Foreground
End Enum