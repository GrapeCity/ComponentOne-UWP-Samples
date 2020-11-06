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

Partial Public NotInheritable Class ContextMenu
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        If Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            listviewerTxt.Text = Strings.ContextMenuPhoneTB
            listviewerTxt.FontSize = 10
        End If
    End Sub

    Private Sub contextMenu_ItemClick(sender As Object, e As C1.Xaml.SourcedEventArgs)
        txt.Text = Strings.ContextMenuItemClickTB + " " + (CType(e.Source, C1.Xaml.C1MenuItem)).Header.ToString()

    End Sub
End Class