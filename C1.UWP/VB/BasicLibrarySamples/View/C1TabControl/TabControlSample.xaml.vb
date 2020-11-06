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
Partial Public NotInheritable Class TabControlSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
    End Sub

    Private Sub cmbTabItemClose_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cmbTabItemClose Is Nothing OrElse tabControl Is Nothing Then
            Return
        End If
        If cmbTabItemClose.SelectedIndex = 0 Then
            tabControl.TabItemClose = C1TabItemCloseOptions.None
        ElseIf cmbTabItemClose.SelectedIndex = 1 Then
            tabControl.TabItemClose = C1TabItemCloseOptions.InEachTab
        Else
            tabControl.TabItemClose = C1TabItemCloseOptions.GlobalClose
        End If
    End Sub


    Private Sub UpdatePlacementCombo(shape As C1TabItemShape)

    End Sub


End Class