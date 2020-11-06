Imports C1.Chart
Imports C1.Chart.Finance
Imports MovingAverageType = C1.Chart.Finance.MovingAverageType

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class Overlays
    Inherits Page

    Private dataService As DataService = DataService.GetService()

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataService.GetSymbolData("box", 87)
        End Get
    End Property

    Public ReadOnly Property OverlayTypes As List(Of String)
        Get
            Return Strings.OverlaysTypes.Split(","c).ToList()
        End Get
    End Property

    Public ReadOnly Property Types As List(Of String)
        Get
            Return [Enum].GetNames(GetType(MovingAverageType)).ToList()
        End Get
    End Property

    Public ReadOnly Property IndicatorType() As List(Of String)
        Get
            Return Strings.IndicatorType.Split(","c).ToList()
        End Get
    End Property

    Sub OnOverlaysLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        cbOverlays.SelectedIndex = 0
        cbTypes.SelectedIndex = 0
    End Sub

    Private Sub ComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim selectedIndex As Integer = cbOverlays.SelectedIndex
        If selectedIndex = 0 Then
            bollinger.Visibility = SeriesVisibility.Visible
            envelopes.Visibility = SeriesVisibility.Hidden
            spBollingerOptions.Visibility = Visibility.Visible
            spEnvelopesOptions.Visibility = Visibility.Collapsed
        Else
            bollinger.Visibility = SeriesVisibility.Hidden
            envelopes.Visibility = SeriesVisibility.Visible
            spBollingerOptions.Visibility = Visibility.Collapsed
            spEnvelopesOptions.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub cbPeriod_ValueChanged(sender As Object, e As C1.Xaml.PropertyChangedEventArgs(Of Double))
        If bollinger IsNot Nothing Then
            Dim period As Integer = CType(e.NewValue, Integer)
            period = Math.Min(Math.Max(2, period), 86)
            bollinger.Period = period
        End If
    End Sub

    Private Sub cbMultiplier_ValueChanged(sender As Object, e As C1.Xaml.PropertyChangedEventArgs(Of Double))
        If bollinger IsNot Nothing Then
            Dim multiplier As Integer = CType(e.NewValue, Integer)
            multiplier = Math.Min(Math.Max(1, multiplier), 100)
            bollinger.Multiplier = multiplier
        End If
    End Sub

    Private Sub cbEnvelopesPeriod_ValueChanged(sender As Object, e As C1.Xaml.PropertyChangedEventArgs(Of Double))
        If envelopes IsNot Nothing Then
            Dim period As Integer = CType(e.NewValue, Integer)
            period = Math.Min(Math.Max(2, period), 86)
            envelopes.Period = period
        End If
    End Sub

    Private Sub cbSize_ValueChanged(sender As Object, e As C1.Xaml.PropertyChangedEventArgs(Of Double))
        If envelopes IsNot Nothing Then
            Dim s As Double = e.NewValue
            s = Math.Min(Math.Max(0, s), 1)
            envelopes.Size = s
        End If
    End Sub

    Private Sub cbTypes_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If envelopes IsNot Nothing Then
            Dim t As MovingAverageType = CType([Enum].Parse(GetType(MovingAverageType), cbTypes.SelectedValue.ToString()), MovingAverageType)
            envelopes.Type = t
        End If
    End Sub

    Private Sub OnSplitterButtonClick(sender As Object, e As RoutedEventArgs)
        splitter.IsPaneOpen = Not splitter.IsPaneOpen
    End Sub

    Private Sub overlayChart_PointerMoved(sender As Object, e As PointerRoutedEventArgs)
        Dim pt As Point = e.GetCurrentPoint(overlayChart).Position
        HandleTooltip(pt)
    End Sub

    Private Sub overlayChart_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        Dim pt As Point = e.GetCurrentPoint(overlayChart).Position
        HandleTooltip(pt)
    End Sub

    Sub HandleTooltip(pt As Point)
        Dim hitTest As HitTestInfo = overlayChart.HitTest(pt)
        Dim ser As ISeries = hitTest.Series
        If ser IsNot Nothing Then
            If ser Is bollinger Then
                overlayChart.ToolTipContent = "{seriesName}" + vbLf + "Date: {Date}" + vbLf + "Upper: {Upper:n2}" + vbLf + "Middle: {Middle:n2}" + vbLf + "Lower: {Lower:n2}"
            ElseIf ser Is envelopes Then
                overlayChart.ToolTipContent = "{seriesName}" + vbLf + "Date: {Date}" + vbLf + "Upper: {Upper:n2}" + vbLf + "Lower: {Lower:n2}"
            Else
                overlayChart.ToolTipContent = "{seriesName}" + vbLf + "Date: {Date}" + vbLf + "Y: {y:n2}" + vbLf + "Volume: {Volume:n0}"
            End If
        End If
    End Sub

End Class
