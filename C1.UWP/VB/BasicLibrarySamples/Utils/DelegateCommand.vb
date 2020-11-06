Imports System.Windows.Input
Imports System

Public Class DelegateCommand(Of T)
    Implements ICommand
    Private Shared ReadOnly EmptyExecute As Action(Of T) = Nothing
    Private Shared ReadOnly EmptyCanExecute As Func(Of T, Boolean) = Function(T) True


    Private _execute As Action(Of T)
    Private _canExecute As Func(Of T, Boolean)

    Public Sub New(executeMethod As Action(Of T))
        Me.New(executeMethod, Nothing)
    End Sub

    Public Sub New(execute As Action(Of T), canExecute As Func(Of T, Boolean))
        _execute = execute
        _canExecute = canExecute
    End Sub

    Public Sub Execute(parameter As T)
        _execute(parameter)
    End Sub


    Public Function CanExecute(parameter As T) As Boolean
        Return _canExecute(parameter)
    End Function


    Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return Me.CanExecute(CType(parameter, T))
    End Function


    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub RaiseCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
    End Sub


    Sub Execute(parameter As Object) Implements ICommand.Execute
        Me.Execute(CType(parameter, T))
    End Sub
End Class
