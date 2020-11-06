Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports C1.Xaml.Chart
Imports C1.Xaml
Imports C1.Chart
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Interaction logic for CurrencyComparisonDemo.xaml
''' </summary>
Partial Public Class CurrencyComparisonDemo
    Inherits Page
    Private _visibilityState As Dictionary(Of String, Boolean)
    Private y2Main As Axis, y2Range As Axis
    Private _measureMode As MeasureMode = MeasureMode.Both
    Private _dtExchangeRate As List(Of Data)
    Private _dtPercentageChange As List(Of Data)
    Private _sourceTable As List(Of Data)
    Private _endPlotDate As DateTime
    Private _startPlotDate As DateTime
    Private _timeFrame As TimeFrame = TimeFrame.SixMonths
    Private _baseCurrency As String
    Private _rangeChartRendered As Boolean = False
    Private isChangeFromLegend As Boolean
    Private _viewModel As New CurrencyComparisonModel()

    Public Sub New()
        InitializeComponent()
        Me.DataContext = _viewModel
    End Sub

    Sub Init()
        _baseCurrency = "USD"
        _sourceTable = HelperExtensions.ImportData()
        _endPlotDate = _sourceTable(0).[Date]
        _sourceTable = _sourceTable.FilterTableByDate(_endPlotDate.AddYears(-10))
        _dtExchangeRate = _sourceTable.ConvertToBase(_baseCurrency)
        _dtPercentageChange = _dtExchangeRate.ConvertToPercentage()
        _startPlotDate = _dtExchangeRate(_dtExchangeRate.Count - 1).[Date]

        If _visibilityState Is Nothing Then
            _visibilityState = New Dictionary(Of String, Boolean)()
        End If
    End Sub

    Sub SetUpMainChart()
        y2Main = New Axis()
        y2Main.Position = Position.Right
        y2Main.Format = "P0"

        Dim i As Integer = 0
        While i < _viewModel.Currencies.Count
            Dim currency As Currency = _viewModel.Currencies(i)
            currency.ExchangeRateSeries = New ChartSeries() With {
                .Binding = currency.Symbol,
                .SeriesName = currency.Symbol,
                .Style = New ChartStyle()
            }
            currency.PercentageChangeSeries = New ChartSeries() With {
                .Binding = currency.Symbol,
                .SeriesName = currency.Symbol,
                .IsPercentage = True,
                .AxisY = y2Main,
                .Style = New ChartStyle()
            }
            currency.ExchangeRateSeries.Style.Stroke = New SolidColorBrush() With {
                .Color = _viewModel.ChartColors(i Mod _viewModel.ChartColors.Count)
            }
            currency.PercentageChangeSeries.Style.Stroke = New SolidColorBrush() With {
                .Color = _viewModel.ChartColors(i Mod _viewModel.ChartColors.Count)
            }
            currency.PercentageChangeSeries.Style.StrokeDashArray = New DoubleCollection() From {
                5.0F,
                2.0F
            }

            'Set Initial Visibilities
            If currency.Symbol = "JPY" Then
                currency.ExchangeRateSeries.Visibility = SeriesVisibility.Visible
                currency.PercentageChangeSeries.Visibility = SeriesVisibility.Plot

                _visibilityState.Add(currency.Symbol, True)
            Else
                currency.ExchangeRateSeries.Visibility = SeriesVisibility.Legend
                currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden
                _visibilityState.Add(currency.Symbol, False)
            End If
            mainChart.Series.Add(currency.ExchangeRateSeries)
            mainChart.Series.Add(currency.PercentageChangeSeries)
            i += 1
        End While
        AddHandler mainChart.SeriesVisibilityChanged, AddressOf HandleMainChartSeriesVisibilityChanged
    End Sub

    Sub SetUpRangeChart()
        y2Range = New Axis() With {
            .AxisLine = False,
            .Title = String.Empty,
            .Labels = False,
            .MajorTickMarks = TickMark.None,
            .MinorTickMarks = TickMark.None
        }

        For Each currency As Currency In _viewModel.Currencies
            Dim s As New ChartSeries() With {
                .Binding = currency.Symbol,
                .SeriesName = currency.Symbol,
                .Visibility = currency.ExchangeRateSeries.Visibility,
                .Style = New ChartStyle(),
                .ItemsSource = _dtExchangeRate
            }
            Dim p As New ChartSeries() With {
                .Binding = currency.Symbol,
                .SeriesName = currency.Symbol,
                .IsPercentage = True,
                .AxisY = y2Range,
                .Visibility = currency.PercentageChangeSeries.Visibility,
                .Style = New ChartStyle(),
                .ItemsSource = _dtPercentageChange
            }
            s.Style.Stroke = currency.ExchangeRateSeries.Style.Stroke
            p.Style.Stroke = currency.PercentageChangeSeries.Style.Stroke
            p.Style.StrokeDashArray = currency.PercentageChangeSeries.Style.StrokeDashArray

            rangeChart.Series.Add(s)
            rangeChart.Series.Add(p)
        Next
    End Sub

    Sub UpdateGridLines()
        mainChart.AxisY.MajorGrid = _measureMode <> MeasureMode.PercentageChange
        y2Main.MajorGrid = _measureMode = MeasureMode.PercentageChange
    End Sub

    Sub UpdateChartView()
        Select Case _measureMode
            Case MeasureMode.Both
                Dim max As Double = 0
                For Each currency As Currency In _viewModel.Currencies
                    If Utils.IsVisible(currency.PercentageChangeSeries) Then
                        Dim seriesMax As Double = currency.PercentageChangeSeries.GetValues(0).Max()
                        max = Math.Max(max, seriesMax)
                    End If
                Next
                y2Main.Max = If(max > 1, max + 0.5, max + 0.2)
                y2Range.Max = If(max > 1, max + 0.5, max + 0.2)
                Exit Select
            Case MeasureMode.PercentageChange
                y2Main.Max = Double.NaN
                y2Range.Max = Double.NaN
                Exit Select
            Case MeasureMode.ExchangeRate
                y2Main.Max = 0
                y2Range.Max = 0
                Exit Select
        End Select
        UpdateGridLines()
    End Sub

    Sub UpdateChart(tf As TimeFrame)
        If _dtExchangeRate Is Nothing Then
            Return
        End If

        mainChart.BeginUpdate()
        rangeChart.BeginUpdate()
        _dtPercentageChange = _dtExchangeRate.ConvertToPercentage()
        For Each currency As Currency In _viewModel.Currencies
            currency.ExchangeRateSeries.ItemsSource = _dtExchangeRate
            currency.PercentageChangeSeries.ItemsSource = _dtPercentageChange
            rangeChart.Series.First(Function(s) Not (CType(s, ChartSeries)).IsPercentage AndAlso s.SeriesName.Equals(currency.Symbol)).ItemsSource = _dtExchangeRate
            rangeChart.Series.First(Function(s) (CType(s, ChartSeries)).IsPercentage AndAlso s.SeriesName.Equals(currency.Symbol)).ItemsSource = _dtPercentageChange
        Next
        rangeChart.EndUpdate()
        mainChart.EndUpdate()
        Select Case tf
            Case TimeFrame.FiveDays
                mainChart.AxisX.Min = _endPlotDate.AddBusinessDays(-5).ToOADate()
                mainChart.AxisX.Format = "MMM dd yyyy"
                Exit Select
            Case TimeFrame.TenDays
                mainChart.AxisX.Min = _endPlotDate.AddBusinessDays(-10).ToOADate()
                mainChart.AxisX.Format = "MMM dd yyyy"
                Exit Select
            Case TimeFrame.OneMonth
                mainChart.AxisX.Format = "MMM dd yyyy"
                mainChart.AxisX.Min = _endPlotDate.AddMonths(-1).ToOADate()
                Exit Select
            Case TimeFrame.SixMonths
                mainChart.AxisX.Format = "MMM dd yyyy"
                mainChart.AxisX.Min = _endPlotDate.AddMonths(-6).ToOADate()
                Exit Select
            Case TimeFrame.OneYear
                mainChart.AxisX.Format = "MMM yy"
                mainChart.AxisX.Min = _endPlotDate.AddYears(-1).ToOADate()
                Exit Select
            Case TimeFrame.FiveYears
                mainChart.AxisX.Format = "yyyy"
                mainChart.AxisX.Min = _endPlotDate.AddYears(-5).ToOADate()
                Exit Select
            Case TimeFrame.TenYears
                mainChart.AxisX.Format = "yyyy"
                mainChart.AxisX.Min = _startPlotDate.ToOADate()
                Exit Select
        End Select
        mainChart.AxisX.Max = _endPlotDate.ToOADate()
        rangeSelector.UpdateLayout()
    End Sub

    Sub UpdateVisibilityState(currency As Currency)
        _visibilityState(currency.Symbol) = Utils.IsVisible(currency.ExchangeRateSeries) OrElse Utils.IsVisible(currency.PercentageChangeSeries)
    End Sub

    Sub UpdateToFromDates()
        Dim from As String = HelperExtensions.FromOADate(mainChart.AxisX.GetMin()).ToShortDateString()
        Dim [to] As String = HelperExtensions.FromOADate(mainChart.AxisX.GetMax()).ToShortDateString()
        tbPeriod.Text = String.Format("Period:{0} to {1}", from, [to])
    End Sub

#Region "Event handler"

    Sub HandleLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Init()
        SetUpMainChart()
        SetUpRangeChart()
        cbCurrencies.SelectedIndex = 0
        cbMeasureModes.SelectedIndex = 2
    End Sub

    Sub HandleMainChartSeriesVisibilityChanged(sender As Object, e As SeriesEventArgs)
        Dim series As ChartSeries = TryCast(e.Series, ChartSeries)
        Dim currency As Currency = _viewModel.Currencies.First(Function(c) c.Symbol.Equals(series.SeriesName))
        If isChangeFromLegend Then
            If Not series.IsPercentage Then
                If _measureMode = MeasureMode.Both Then
                    If Utils.IsVisible(currency.ExchangeRateSeries) Then
                        currency.PercentageChangeSeries.Visibility = SeriesVisibility.Plot
                    Else
                        currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden
                    End If
                End If
            End If
            UpdateVisibilityState(currency)
        End If
        Dim rangeSeries As Series = rangeChart.Series.First(Function(s) s.SeriesName.Equals(series.SeriesName) AndAlso (CType(s, ChartSeries)).IsPercentage = series.IsPercentage)
        rangeSeries.Visibility = series.Visibility
    End Sub

    Sub HandleCurrenciesSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cbCurrencies.SelectedValue Is Nothing Then
            Return
        End If

        isChangeFromLegend = False
        Dim oldBaseCurrency As Object = _baseCurrency
        _baseCurrency = cbCurrencies.SelectedValue.ToString()
        _dtExchangeRate = _sourceTable.ConvertToBase(_baseCurrency)
        UpdateChart(_timeFrame)
        Dim newBaseCurrencySeries As Currency = _viewModel.Currencies.First(Function(c) c.Symbol.Equals(_baseCurrency))
        Dim oldBaseCurrencySeries As Currency = _viewModel.Currencies.First(Function(c) c.Symbol.Equals(oldBaseCurrency))
        UpdateVisibilityState(newBaseCurrencySeries)
        Select Case _measureMode
            Case MeasureMode.ExchangeRate
                newBaseCurrencySeries.ExchangeRateSeries.Visibility = SeriesVisibility.Legend
                oldBaseCurrencySeries.ExchangeRateSeries.Visibility = If(_visibilityState(_baseCurrency), SeriesVisibility.Visible, SeriesVisibility.Legend)
                Exit Select
            Case MeasureMode.PercentageChange
                newBaseCurrencySeries.PercentageChangeSeries.Visibility = SeriesVisibility.Legend
                oldBaseCurrencySeries.PercentageChangeSeries.Visibility = If(_visibilityState(_baseCurrency), SeriesVisibility.Visible, SeriesVisibility.Legend)
                Exit Select
            Case MeasureMode.Both
                newBaseCurrencySeries.ExchangeRateSeries.Visibility = SeriesVisibility.Legend
                newBaseCurrencySeries.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden
                oldBaseCurrencySeries.ExchangeRateSeries.Visibility = If(_visibilityState(_baseCurrency), SeriesVisibility.Visible, SeriesVisibility.Legend)
                oldBaseCurrencySeries.PercentageChangeSeries.Visibility = If(_visibilityState(_baseCurrency), SeriesVisibility.Plot, SeriesVisibility.Hidden)
                Exit Select
        End Select
        UpdateChartView()
        isChangeFromLegend = True
        UpdateToFromDates()
    End Sub

    Sub HandleMeasureModesSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        isChangeFromLegend = False
        If _viewModel.Currencies IsNot Nothing Then
            _measureMode = CType(cbMeasureModes.SelectedValue, MeasureMode)
            For Each currency As Currency In _viewModel.Currencies
                Select Case _measureMode
                    Case MeasureMode.ExchangeRate
                        If Utils.IsVisible(currency.PercentageChangeSeries) Then
                            currency.ExchangeRateSeries.Visibility = SeriesVisibility.Visible
                        Else
                            currency.ExchangeRateSeries.Visibility = SeriesVisibility.Legend
                        End If
                        currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden
                        Exit Select

                    Case MeasureMode.PercentageChange
                        If Utils.IsVisible(currency.ExchangeRateSeries) Then
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Visible
                        Else
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Legend
                        End If
                        currency.ExchangeRateSeries.Visibility = SeriesVisibility.Hidden
                        Exit Select

                    Case MeasureMode.Both
                        If Utils.IsVisible(currency.ExchangeRateSeries) OrElse Utils.IsVisible(currency.PercentageChangeSeries) Then
                            currency.ExchangeRateSeries.Visibility = SeriesVisibility.Visible
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Plot
                        Else
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden
                            currency.ExchangeRateSeries.Visibility = SeriesVisibility.Legend
                        End If
                        Exit Select
                End Select
            Next
            UpdateChartView()
        End If
        isChangeFromLegend = True
    End Sub

    Sub HandleRangeSelectorValueChanged(sender As Object, e As EventArgs)
        If _rangeChartRendered Then
            mainChart.AxisX.Min = rangeSelector.LowerValue
            mainChart.AxisX.Max = rangeSelector.UpperValue
            mainChart.AxisX.Format = String.Empty
            RemoveHandler rangeChart.Rendered, AddressOf HandleRangeChartRendered
            UpdateToFromDates()
        End If
    End Sub

    Sub HandleRangeChartRendered(sender As Object, e As RenderEventArgs)
        Dim max As Double = rangeChart.AxisX.GetMax()
        Dim min As Double = rangeChart.AxisX.GetMin()
        If Not Double.IsNaN(min) AndAlso Not Double.IsNaN(max) Then
            RemoveHandler rangeSelector.ValueChanged, AddressOf HandleRangeSelectorValueChanged
            rangeSelector.LowerValue = mainChart.AxisX.GetMin()
            AddHandler rangeSelector.ValueChanged, AddressOf HandleRangeSelectorValueChanged
            _rangeChartRendered = True
        End If
    End Sub

    Sub HandleMainChartMouseMove(sender As Object, e As PointerRoutedEventArgs)
        Dim hitTestInfo As HitTestInfo = mainChart.HitTest(e.GetCurrentPoint(mainChart).Position)
        If hitTestInfo IsNot Nothing AndAlso hitTestInfo.Series IsNot Nothing Then
            Dim series As ChartSeries = CType(hitTestInfo.Series, ChartSeries)
            If series.IsPercentage Then
                mainChart.ToolTipContent = "Currency: {seriesName}" & vbLf & "Date: {x:MM-dd-yyyy}" & vbLf & "Value: {value:p4}"
            Else
                mainChart.ToolTipContent = "Currency: {seriesName}" & vbLf & "Date: {x:MM-dd-yyyy}" & vbLf & "Value: {value}"
            End If
        End If
    End Sub

    Sub HandleRadioButtonChecked(sender As Object, e As RoutedEventArgs)
        Dim btnSelectedTimeFrame As RadioButton = TryCast(sender, RadioButton)
        If btnSelectedTimeFrame.Tag Is Nothing Then
            Return
        End If

        _timeFrame = _viewModel.DictTimeFrame(btnSelectedTimeFrame.Tag.ToString())
        UpdateChart(_timeFrame)
        If rangeSelector IsNot Nothing Then
            RemoveHandler rangeSelector.ValueChanged, AddressOf HandleRangeSelectorValueChanged
            rangeSelector.UpperValue = _endPlotDate.ToOADate()
            rangeSelector.LowerValue = mainChart.AxisX.GetMin()
            AddHandler rangeSelector.ValueChanged, AddressOf HandleRangeSelectorValueChanged
        End If
        UpdateToFromDates()
        UpdateChartView()
    End Sub

#End Region
End Class