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
Imports C1.Xaml

Partial Public NotInheritable Class DropDownDemo
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub colorListBox_ItemTapped(sender As Object, e As C1TappedEventArgs)
        Dim item As C1ListBoxItem = TryCast(sender, C1ListBoxItem)
        If item IsNot Nothing Then
            Dim b As Border = TryCast(item.Content, Border)
            If b IsNot Nothing Then
                dropDownBorder.Background = b.Background
            End If
        End If
        c1DropDown1.IsDropDownOpen = False
    End Sub

End Class