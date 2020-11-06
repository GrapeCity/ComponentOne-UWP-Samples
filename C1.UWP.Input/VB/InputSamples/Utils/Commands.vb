Imports Windows.UI.Xaml.Controls
Imports System.Windows.Input
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class PaneToggleSwitchCommand
		Implements ICommand
        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim view As SplitView = CType(parameter, SplitView)
        If view IsNot Nothing Then
            view.IsPaneOpen = Not view.IsPaneOpen
        End If
    End Sub
End Class