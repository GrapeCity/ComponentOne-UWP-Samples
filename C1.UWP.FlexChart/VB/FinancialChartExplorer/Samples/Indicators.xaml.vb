Imports C1.Xaml.Chart.Finance
Imports C1.Xaml.Chart
Imports C1.Xaml
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Collections.Generic

''' <summary>
''' Interaction logic for Indicators.xaml
''' </summary>
Partial Public Class Indicators
    Inherits Page
    Private dataService As DataService = dataService.GetService()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataService.GetSymbolData("box", 87)
        End Get
    End Property

    Public ReadOnly Property IndicatorType() As List(Of String)
        Get
            Return Strings.IndicatorType.Split(","c).ToList()
        End Get
    End Property

    Sub OnIndicatorsLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        cbIndicatorType.SelectedIndex = 0
        Me.cbPeriod.Value = atr.Period
    End Sub

    Sub OnIndicatorTypeSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If indicatorChart Is Nothing Then
            Return
        End If

        Dim selectedIndex As Integer = cbIndicatorType.SelectedIndex

        If selectedIndex = 0 OrElse selectedIndex = 1 OrElse selectedIndex = 2 OrElse selectedIndex = 3 Then
            If spNormalOptions IsNot Nothing Then
                spNormalOptions.Visibility = Visibility.Visible
            End If
            If spMacdOptions IsNot Nothing Then
                spMacdOptions.Visibility = Visibility.Collapsed
            End If
            If spStochasticOptions IsNot Nothing Then
                spStochasticOptions.Visibility = Visibility.Collapsed
            End If
        ElseIf selectedIndex = 4 Then
            If spNormalOptions IsNot Nothing Then
                spNormalOptions.Visibility = Visibility.Collapsed
            End If
            If spStochasticOptions IsNot Nothing Then
                spStochasticOptions.Visibility = Visibility.Collapsed
            End If
            If spMacdOptions IsNot Nothing Then
                spMacdOptions.Visibility = Visibility.Visible
            End If
        ElseIf selectedIndex = 5 Then
            If spNormalOptions IsNot Nothing Then
                spNormalOptions.Visibility = Visibility.Collapsed
            End If
            If spMacdOptions IsNot Nothing Then
                spMacdOptions.Visibility = Visibility.Collapsed
            End If
            If spStochasticOptions IsNot Nothing Then
                spStochasticOptions.Visibility = Visibility.Visible
            End If
        End If

        indicatorChart.BeginUpdate()
        For Each ser As ISeries In indicatorChart.Series
            ser.Visibility = SeriesVisibility.Hidden
        Next
        If selectedIndex = 0 Then
            atr.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 1 Then
            rsi.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 2 Then
            cci.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 3 Then
            wi.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 4 Then
            macd.Visibility = SeriesVisibility.Visible
            histogram.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 5 Then
            stochastic.Visibility = SeriesVisibility.Visible
        End If
        indicatorChart.EndUpdate()
    End Sub

    Sub OnCbPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        wi.Period = CType(e.NewValue, Integer)
        cci.Period = wi.Period
        rsi.Period = cci.Period
        atr.Period = rsi.Period
    End Sub

    Sub OnFinancialChartRendered(sender As Object, e As RenderEventArgs)
        If indicatorChart IsNot Nothing Then
            indicatorChart.AxisX.Min = (CType(financialChart.AxisX, IAxis)).GetMin()
            indicatorChart.AxisX.Max = (CType(financialChart.AxisX, IAxis)).GetMax()
        End If
    End Sub

    Private Sub OnStochasticSmoothingPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If stochastic IsNot Nothing Then
            stochastic.SmoothingPeriod = CorrectValue(e.NewValue, 1)
        End If
    End Sub

    Private Sub OnDPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If stochastic IsNot Nothing Then
            stochastic.DPeriod = CorrectValue(e.NewValue)
        End If
    End Sub

    Private Sub OnKPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If stochastic IsNot Nothing Then
            stochastic.KPeriod = CorrectValue(e.NewValue)
        End If
    End Sub

    Private Sub OnSmoothingPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If macd IsNot Nothing Then
            macd.SmoothingPeriod = CorrectValue(e.NewValue)
        End If
        If histogram IsNot Nothing Then
            histogram.SmoothingPeriod = CorrectValue(e.NewValue)
        End If
    End Sub

    Private Sub OnSlowPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If macd IsNot Nothing Then
            macd.SlowPeriod = CorrectValue(e.NewValue)
        End If
        If histogram IsNot Nothing Then
            histogram.SlowPeriod = CorrectValue(e.NewValue)
        End If
    End Sub

    Private Sub OnFastPeriodValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If macd IsNot Nothing Then
            macd.FastPeriod = CorrectValue(e.NewValue)
        End If
        If histogram IsNot Nothing Then
            histogram.FastPeriod = CorrectValue(e.NewValue)
        End If
    End Sub

    Function CorrectValue(newValue As Double, Optional minimum As Integer = 2) As Integer
        Return Math.Max(Math.Min(86, CType(newValue, Integer)), minimum)
    End Function

    Private Sub OnSplitterButtonClick(sender As Object, e As RoutedEventArgs)
        splitter.IsPaneOpen = Not splitter.IsPaneOpen
    End Sub

    Private Sub indicatorChart_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        Dim pt As Point = e.GetCurrentPoint(indicatorChart).Position
        HandleTooltip(pt)
    End Sub

    Private Sub indicatorChart_PointerMoved(sender As Object, e As PointerRoutedEventArgs)
        Dim pt As Point = e.GetCurrentPoint(indicatorChart).Position
        HandleTooltip(pt)
    End Sub

    Sub HandleTooltip(pt As Point)
        Dim hitTest As HitTestInfo = indicatorChart.HitTest(pt)
        Dim ser As ISeries
        If hitTest IsNot Nothing Then
            ser = hitTest.Series
            If ser IsNot Nothing Then
                If ser Is macd Then
                    indicatorChart.ToolTipContent = "Date: {Date}" + vbLf + "MACD: {Macd:n2}" + vbLf + "DSignal: {Signal:n2}"
                ElseIf ser Is stochastic Then
                    indicatorChart.ToolTipContent = "Date: {Date}" + vbLf + "%K: {K:n2}" + vbLf + “%D: {D:n2}"
                Else
                    indicatorChart.ToolTipContent = "{seriesName}” + vbLf + "Date: {Date}" + vbLf + "Y: {y:n2}" + vbLf + "Volume: {Volume:n0}"
                End If
            End If
        End If
    End Sub

End Class