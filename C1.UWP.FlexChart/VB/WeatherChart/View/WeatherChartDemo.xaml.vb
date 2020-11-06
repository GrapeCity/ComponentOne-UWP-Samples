Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI
Imports C1.Xaml.Chart

''' <summary>
''' Interaction logic for WeatherChartDemo.xaml
''' </summary>
Partial Public Class WeatherChartDemo
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Sub OnChartRendered(sender As Object, e As RenderEventArgs)
        Dim flexChart As C1FlexChart = TryCast(sender, C1FlexChart)
        If flexChart Is Nothing Then
            Return
        End If

        Dim rect As Rect = flexChart.PlotRect
        e.Engine.SetFill(Colors.Transparent)
        e.Engine.SetStroke(New SolidColorBrush(Colors.DimGray))
        e.Engine.SetStrokeThickness(1.0)
        e.Engine.DrawRect(rect.X, rect.Y, rect.Width, rect.Height)
    End Sub

    Sub OnRangeSelectorValueChanged(sender As Object, e As System.EventArgs)
        chartPrecipitation.AxisX.Min = rangeSelector.LowerValue
        chartPrecipitation.AxisX.Max = rangeSelector.UpperValue
        chartPressure.AxisX.Min = rangeSelector.LowerValue
        chartPressure.AxisX.Max = rangeSelector.UpperValue
        chartTemperature.AxisX.Min = rangeSelector.LowerValue
        chartTemperature.AxisX.Max = rangeSelector.UpperValue
    End Sub
End Class