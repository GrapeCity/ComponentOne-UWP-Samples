Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports C1.Xaml
Imports BasicLibrarySamples
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class RadialMenu
    Inherits Page
    Public Sub New()
        UndoCommand = New DelegateCommand(Of Object)(AddressOf ExecuteUndoCommand, AddressOf GetCanExecuteUndoCommand)
        RedoCommand = New DelegateCommand(Of Object)(AddressOf ExecuteRedoCommand, AddressOf GetCanExecuteRedoCommand)
        ClearFormatCommand = New DelegateCommand(Of Object)(AddressOf ExecuteClearFormatCommand, AddressOf GetCanExecuteClearFormatCommand)
        Me.InitializeComponent()
    End Sub

    Private Sub contextMenu_ItemClick(sender As Object, e As SourcedEventArgs)
        Dim item As C1RadialMenuItem = TryCast(e.Source, C1RadialMenuItem)
        If TypeOf item Is C1RadialColorItem Then
            Me.text.Foreground = (CType(item, C1RadialColorItem)).Brush
            txt.Text = Strings.ContextMenuItemClickTB + " " + (CType(item, C1RadialColorItem)).Color.ToString()
        ElseIf TypeOf item Is C1RadialNumericItem Then
            txt.FontSize = (CType(item, C1RadialNumericItem)).Value
            txt.Text = Strings.ContextMenuItemClickTB + " " + (CType(item, C1RadialNumericItem)).Value.ToString()
        Else
            txt.Text = Strings.ContextMenuItemClickTB + " " + (If(item.Header, item.Name)).ToString()
        End If
    End Sub

    Private Sub contextMenu_ItemOpened(sender As Object, e As SourcedEventArgs)
        Dim item As C1RadialMenuItem = TryCast(e.Source, C1RadialMenuItem)
        txt.Text = Strings.RadialMenuItemOpenedTB + " " + (If(item.Header, item.Name)).ToString()
    End Sub

#Region "** Commands"
    ' define some commands and attach them to menu items in xaml
    Public Property UndoCommand() As DelegateCommand(Of Object)

    Private Sub ExecuteUndoCommand(parameter As Object)
        txt.Text = Strings.RadialMenuUnDo
        _canExecuteUndo = False
        _canExecuteRedo = True
        UndoCommand.RaiseCanExecuteChanged()
        RedoCommand.RaiseCanExecuteChanged()
    End Sub

    Private _canExecuteUndo As Boolean = False
    Private Function GetCanExecuteUndoCommand(parameter As Object) As Boolean
        Return _canExecuteUndo
    End Function

    Public Property RedoCommand() As DelegateCommand(Of Object)

    Private Sub ExecuteRedoCommand(parameter As Object)
        txt.Text = Strings.RadialMenuReDo
        _canExecuteUndo = True
        _canExecuteRedo = False
        UndoCommand.RaiseCanExecuteChanged()
        RedoCommand.RaiseCanExecuteChanged()
    End Sub

    Private _canExecuteRedo As Boolean = False
    Private Function GetCanExecuteRedoCommand(parameter As Object) As Boolean
        Return _canExecuteRedo
    End Function

    Public Property ClearFormatCommand() As DelegateCommand(Of Object)

    Private Sub ExecuteClearFormatCommand(parameter As Object)
        txt.Text = Strings.RadialMenuClear
        _canExecuteUndo = True
        _canExecuteRedo = False
        UndoCommand.RaiseCanExecuteChanged()
        RedoCommand.RaiseCanExecuteChanged()
    End Sub

    Private Function GetCanExecuteClearFormatCommand(parameter As Object) As Boolean
        Return True
    End Function
#End Region

    Private Sub contextMenu_Opened(sender As Object, e As EventArgs)
        ' expand menu immediately, as in this sample we don't have underlying editable controls
        contextMenu.Expand()
    End Sub

End Class