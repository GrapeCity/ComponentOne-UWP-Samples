' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports System.Text
Imports C1.Xaml.Chart
Imports Windows.UI
Imports Windows.UI.Xaml.Documents
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = ChartViewModel.Instance

        AddHandler Me.Loaded, AddressOf pageLoaded

        AddHandler Me.lineMarker.Loaded, AddressOf linMarker_Loaded
    End Sub

    Private Sub pageLoaded(sender As System.Object, e As RoutedEventArgs)
        ChartViewModel.Instance.MainChart = financialChart1
        ChartViewModel.Instance.MainSeries = mainSeries
        ChartViewModel.Instance.MainMovingAverage = mainMovingAverage
        ChartViewModel.Instance.VolumeSeries = volumeSeries
        ChartViewModel.Instance.RangeSelector = rangeSelector
        ChartViewModel.Instance.AnnotationLayer = annotationLayer
        ChartViewModel.Instance.LineMarker = lineMarker

        Me.rangeSelector.UpperValue = Utilities.ToOADate(DateTime.Now)
        Me.rangeSelector.LowerValue = Utilities.ToOADate(DateTime.Parse(String.Format("01-01-{0}", DateTime.Now.Year)))

        Me.financialChart2.AxisX.Min = Utilities.ToOADate(New DateTime(2007, 12, 31))

    End Sub

    Private Sub linMarker_Loaded(sender As System.Object, e As RoutedEventArgs)
        If Me.lineMarker.Visibility = Visibility.Visible Then
            Dim whiteBrush As Brush = New SolidColorBrush(Windows.UI.Colors.White)
            Dim visuals As IEnumerable(Of DependencyObject) = GetLineVisual(Me.lineMarker)
            For Each item As DependencyObject In visuals
                Dim line = TryCast(item, Windows.UI.Xaml.Shapes.Line)
                line.Fill = whiteBrush
                line.Stroke = whiteBrush
            Next
        End If
        Me.lineMarker.Visibility = Visibility.Collapsed
    End Sub
    Private Shared Function GetLineVisual(obj As DependencyObject) As IEnumerable(Of DependencyObject)
        Dim objs As New List(Of DependencyObject)()
        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj) - 1
            Dim visual = VisualTreeHelper.GetChild(obj, i)

            If TypeOf visual Is Windows.UI.Xaml.Shapes.Line Then
                objs.Add(visual)
            Else
                objs.AddRange(GetLineVisual(visual))

            End If
        Next
        Return objs

    End Function


    Private Sub financialChart1_PointerMoved(sender As Object, e As PointerRoutedEventArgs)
        Dim pp As Windows.UI.Input.PointerPoint = e.GetCurrentPoint(financialChart1)

        Dim ht = financialChart1.HitTest(pp.Position)
        If ht IsNot Nothing Then
            Dim result = New StringBuilder()
            If ht.PointIndex >= 0 Then
                Dim currDate As DateTime = DateTime.MaxValue
                If ht.Series IsNot Nothing AndAlso ht.Item IsNot Nothing Then
                    Dim ddt = TryCast(ht.Item, Quote).GetRefValue("date")
                    currDate = Convert.ToDateTime(ddt)
                End If
                If TypeOf ht.Series Is C1.Xaml.Chart.Finance.MovingAverage Then
                    currDate = currDate.AddDays(0 - TryCast(ht.Series, C1.Xaml.Chart.Finance.MovingAverage).Period)
                End If

                If currDate = DateTime.MaxValue Then
                    Return
                End If

                Dim quotes As New Queue(Of QuoteInfo)()
                Dim binding As String = If(ChartViewModel.Instance.Binding = "high,low,open,close", "close", ChartViewModel.Instance.Binding)
                If ChartViewModel.Instance.DataSource IsNot Nothing Then
                    result.Append(String.Format("{0}: ", ChartViewModel.Instance.MainSymbol))
                    Dim quote = (From p In ChartViewModel.Instance.DataSource Where (p.[date] >= currDate) Select p).FirstOrDefault()

                    If quote IsNot Nothing Then
                        Dim dd As Double = quote.GetValue(binding)

                        quotes.Enqueue(New QuoteInfo() With {
                            .Code = ChartViewModel.Instance.MainSymbol,
                            .Color = Color.FromArgb(255, 255, 165, 0),
                            .Value = dd,
                            .Volume = Convert.ToInt32(quote.GetRefValue("volume")),
                            .[Date] = Convert.ToDateTime(quote.GetRefValue("date"))
                        })
                    End If
                End If

                If ChartViewModel.Instance.SymbolCollection IsNot Nothing AndAlso ChartViewModel.Instance.SymbolCollection.Any() Then
                    For Each series As Series In financialChart1.Series
                        If series.Visibility = C1.Chart.SeriesVisibility.Visible AndAlso Not (TypeOf series Is C1.Xaml.Chart.Finance.MovingAverage) AndAlso Not String.IsNullOrEmpty(series.SeriesName) Then
                            Dim currSeries = (From p In ChartViewModel.Instance.SymbolCollection Where p.Series.Equals(series) Select p).FirstOrDefault()

                            If currSeries IsNot Nothing Then

                                Dim quote = (From p In currSeries.DataSource Where (p.[date] >= currDate) Select p).FirstOrDefault()

                                If quote IsNot Nothing Then
                                    Dim dd As Double = quote.GetValue(binding)

                                    quotes.Enqueue(New QuoteInfo() With {
                                       .Code = currSeries.Code,
                                       .Color = currSeries.Color,
                                       .Value = dd,
                                       .Volume = Convert.ToInt32(quote.GetRefValue("volume")),
                                       .[Date] = Convert.ToDateTime(quote.GetRefValue("date"))
                                    })
                                End If
                            End If
                        End If
                    Next
                End If
                ChartViewModel.Instance.ComparisonQuoteInfo = quotes
            End If
        End If
    End Sub

    Private Sub rangeSelector_ValueChanged(sender As Object, e As EventArgs)
        ChartViewModel.Instance.LowerValue = rangeSelector.LowerValue
        financialChart1.AxisX.Min = rangeSelector.LowerValue
        ChartViewModel.Instance.UpperValue = rangeSelector.UpperValue
        financialChart1.AxisX.Max = rangeSelector.UpperValue
    End Sub

    Private Sub OnLineMarkerPositionChanged(sender As Object, e As C1.Xaml.Chart.Interaction.PositionChangedArgs)
        If financialChart1 IsNot Nothing Then
            Dim info = financialChart1.HitTest(New Point(e.Position.X, e.Position.Y))
            Dim value = lineMarker.Y
            ' financialChart1.AxisY.Min + (financialChart1.AxisY.Max - financialChart1.AxisY.Min) * (financialChart1.PlotRect.Top + financialChart1.PlotRect.Height - lineMarker.Y) / financialChart1.PlotRect.Height;
            'draw Y rectangle

            Dim format = String.Format((If(value >= 0, "+{0:P2}", "{0:P2}")), value)
            If value = 0 Then
                format = "{0:P2}"
            End If
            Dim text = String.Format(If(ChartViewModel.Instance.IsComparisonMode, format, "{0:.##}"), value)

            Dim border = New Border()
            border.Background = New SolidColorBrush(Color.FromArgb(255, 34, 34, 34))
            Dim tb = New TextBlock()
            tb.Padding = New Thickness(10)

            border.Child = tb

            tb.Inlines.Add(New Run() With {
               .Text = String.Format("{0:MMM dd, yyyy} " & vbCr & vbLf, info.X),
               .Foreground = New SolidColorBrush() With {
                   .Color = Color.FromArgb(255, 170, 170, 170)
                }
            })

            tb.Inlines.Add(New Run() With {
               .Text = text,
               .Foreground = New SolidColorBrush() With {
                    .Color = Color.FromArgb(255, 170, 170, 170)
                },
                .FontWeight = Windows.UI.Text.FontWeights.Bold
            })
            lineMarker.Content = border
        End If
    End Sub
End Class
