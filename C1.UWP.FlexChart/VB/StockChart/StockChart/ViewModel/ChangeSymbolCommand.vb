Public Class ChangeSymbolCommand
    Implements ICommand
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Sub RaiseCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, New EventArgs())
    End Sub

    Private _viewModel As ChartViewModel
    Public Sub New(viewModel As ChartViewModel)
        _viewModel = viewModel
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        If _viewModel.ChangeSymbolCommandParamter IsNot Nothing Then
            Dim text = _viewModel.ChangeSymbolCommandParamter
            If Not String.IsNullOrEmpty(text) Then
                Dim code = text.Split(New Char() {" "c}).FirstOrDefault()
                If _viewModel.SymbolNames.Keys.Contains(code) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim code = parameter.ToString().Split(New Char() {" "}).FirstOrDefault()
        If Not String.IsNullOrEmpty(code) Then
            _viewModel.MainSymbol = code

            _viewModel.ChangeSymbolCommandParamter = String.Empty
        End If


    End Sub
End Class