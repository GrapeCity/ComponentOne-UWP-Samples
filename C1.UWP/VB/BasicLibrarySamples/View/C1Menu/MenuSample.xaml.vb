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
Imports C1.Xaml

Partial Public NotInheritable Class MenuSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public Event SelectedItemChanged As EventHandler

    Private Sub C1MenuItem_Click(sender As Object, e As Object)
        Dim menu As C1MenuItem = TryCast(sender, C1MenuItem)
        RaiseEvent SelectedItemChanged(Me, New EventArgs())
    End Sub

    Private Sub CheckBox_Checked(sender As Object, e As RoutedEventArgs)

    End Sub
End Class