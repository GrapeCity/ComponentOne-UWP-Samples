Namespace Common
	Public Class DelegateCommand
		Implements ICommand
		Private _action As Action
		Private _canExecute As Boolean = False

        Public Sub New(action As Action, canExecute As Boolean)
            Me._action = action
            Me._canExecute = canExecute
        End Sub

        Private Event ICommand_CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Private Function ICommand_CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return _canExecute
        End Function

        Private Sub ICommand_Execute(parameter As Object) Implements ICommand.Execute
            _action()
        End Sub
    End Class
End Namespace