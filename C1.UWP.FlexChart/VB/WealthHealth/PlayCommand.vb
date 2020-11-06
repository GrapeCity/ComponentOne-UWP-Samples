Imports System.Windows.Input
Imports System

Public Class PlayCommand
    Implements ICommand
    Private _execute As Action

    Public Sub New(execute As Action)
        _execute = execute
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        _execute()
    End Sub
End Class