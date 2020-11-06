Public Class RelayCommand
    Implements ICommand
    Private _execute As Action(Of String)

    Public Sub New(execute As Action(Of String))
        _execute = execute
    End Sub

    Private Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean
        Return True
    End Function

    Public Sub Execute(parameter As Object)
        _execute(TryCast(parameter, String))
    End Sub

    Private Function ICommand_CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Private Sub ICommand_Execute(parameter As Object) Implements ICommand.Execute
        _execute(CType(parameter, String))
    End Sub
End Class