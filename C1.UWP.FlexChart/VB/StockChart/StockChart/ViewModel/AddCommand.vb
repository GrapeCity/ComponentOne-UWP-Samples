Imports C1.Chart
Imports C1.Xaml.Chart

Public Class AddCommand
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
        If _viewModel.AddCommandParamter IsNot Nothing Then
            Dim text = _viewModel.AddCommandParamter
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
        Dim chart As C1FlexChart = _viewModel.MainChart

        Dim code = parameter.ToString().Split(New Char() {" "c}).FirstOrDefault()
        If chart Is Nothing OrElse String.IsNullOrEmpty(code) Then
            Return
        End If

        If code.ToUpper() = _viewModel.MainSymbol.ToUpper() Then
            Return
        End If
        _viewModel.AddCommandParamter = String.Empty

        Dim theSymbol As IEnumerable(Of Symbol) = From p In _viewModel.SymbolCollection Where p.Code.ToUpper() = code.ToUpper() Select p
        If theSymbol IsNot Nothing AndAlso theSymbol.Any() Then
            Return
        End If

        CreateSysmbol(code,
                       Async Sub(s)
                           AddHandler s.PropertyChanged, AddressOf symbol_PropertyChanged

                           Await chart.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                                    Sub()
                                                        theSymbol = From p In _viewModel.SymbolCollection Where p.Code.ToUpper() = s.Code.ToUpper() Select p
                                                        If theSymbol IsNot Nothing AndAlso theSymbol.Any() Then
                                                            Return
                                                        End If

                                                        _viewModel.Binding = "percentage"
                                                        InitSymbol(s, _viewModel.Binding)
                                                        _viewModel.SymbolCollection.Add(s)
                                                        chart.Series.Add(s.Series)
                                                        chart.Series.Add(s.MovingAverage)
                                                        s.Series.Dispose()
                                                        s.MovingAverage.Dispose()

                                                        If _viewModel.SymbolCollection.Count > 4 Then
                                                            Dim symbol = _viewModel.SymbolCollection.FirstOrDefault()
                                                            _viewModel.SymbolCollection.Remove(symbol)
                                                        End If
                                                    End Sub)
                       End Sub)
    End Sub

    Private Sub symbol_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        If e.PropertyName = "Visibility" Then
            _viewModel.UpdateYRange()
        End If
    End Sub

    Private Async Sub CreateSysmbol(code As String, callback As Action(Of Symbol))
        Dim s As Symbol = Nothing
        Await Windows.System.Threading.ThreadPool.RunAsync(Sub(workItem)
                                                               Try
                                                                   Dim symbolData = DataService.Instance.GetSymbolData(code)
                                                                   If symbolData.Any() Then
                                                                       s = New Symbol(code) With {
                                                                                 .DataSource = symbolData
                                                                             }
                                                                       callback(s)
                                                                   Else
                                                                       Throw New System.Net.WebException()
                                                                   End If
                                                               Catch we As System.Net.WebException
                                                                   System.Diagnostics.Debug.WriteLine(we.Message)
                                                               End Try

                                                           End Sub)
    End Sub

    Shared IndexMemory As Integer = 0
    Private Sub InitSymbol(s As Symbol, [property] As String)
        s.Color = ChartViewModel._Colors(IndexMemory Mod ChartViewModel._Colors.Length)
        IndexMemory += 1
        Dim hsb As HsbColor = ColorEx.RgbToHsb(s.Color)

        s.MovingAverage = New C1.Xaml.Chart.Finance.MovingAverage() With {
            .Binding = [property],
            .Type = MovingAverageType.Simple,
            .Period = 10
        }

        s.MovingAverage.Visibility = If(_viewModel.IsShowMovingAverage, SeriesVisibility.Visible, SeriesVisibility.Hidden)
        s.MovingAverage.Style = New ChartStyle()
        s.MovingAverage.Style.Fill = InlineAssignHelper(s.MovingAverage.Style.Stroke, New SolidColorBrush(ColorEx.HsbToRgb(New HsbColor() With {
           .A = hsb.A,
           .H = hsb.H,
           .s = Math.Max(hsb.B / 2, 0),
           .B = Math.Min(hsb.B * 2, 1)
        })))
        s.MovingAverage.ItemsSource = s.DataSource

        s.Series = New Series() With {
           .Binding = [property],
           .SeriesName = s.Code.ToUpper()
        }
        s.Series.ChartType = ChartType.Line
        s.Series.Style = New ChartStyle()
        s.Series.Style.StrokeThickness = 2
        s.Series.Style.Fill = New SolidColorBrush(Windows.UI.Color.FromArgb(64, s.Color.R, s.Color.G, s.Color.B))
        s.Series.Style.Stroke = New SolidColorBrush(s.Color)
        s.Series.ItemsSource = s.DataSource
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class