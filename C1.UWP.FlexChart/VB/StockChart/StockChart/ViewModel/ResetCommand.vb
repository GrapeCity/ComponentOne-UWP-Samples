Public Class ResetCommand
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
        If _viewModel.SymbolCollection IsNot Nothing AndAlso _viewModel.SymbolCollection.Any() Then
            Return True
        End If
        Return False
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim chart As C1.Xaml.Chart.C1FlexChart = _viewModel.MainChart

        For Each sysmbol As Symbol In _viewModel.SymbolCollection
            If chart.Series.Contains(sysmbol.Series) Then
                chart.Series.Remove(sysmbol.Series)
            End If
            If chart.Series.Contains(sysmbol.MovingAverage) Then
                chart.Series.Remove(sysmbol.MovingAverage)
            End If
        Next
        _viewModel.SymbolCollection.Clear()
    End Sub
End Class
