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

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class ClearStyleTabControl
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub cmbTabStripPlacement_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cmbTabStripPlacement Is Nothing OrElse c1TabControl1 Is Nothing Then
            Return

        ElseIf cmbTabStripPlacement.SelectedIndex = 0 Then
            c1TabControl1.TabStripPlacement = Dock.Left
        ElseIf cmbTabStripPlacement.SelectedIndex = 1 Then

            c1TabControl1.TabStripPlacement = Dock.Right
        ElseIf cmbTabStripPlacement.SelectedIndex = 2 Then
            c1TabControl1.TabStripPlacement = Dock.Top
        ElseIf cmbTabStripPlacement.SelectedIndex = 3 Then
            c1TabControl1.TabStripPlacement = Dock.Bottom
        End If
    End Sub



    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
    End Sub

End Class