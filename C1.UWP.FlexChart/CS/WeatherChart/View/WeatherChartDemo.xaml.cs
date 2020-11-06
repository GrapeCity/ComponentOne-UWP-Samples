using C1.Xaml.Chart;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace WeatherChart
{
    /// <summary>
    /// Interaction logic for WeatherChartDemo.xaml
    /// </summary>
    public partial class WeatherChartDemo : UserControl
    {
        public WeatherChartDemo()
        {
            InitializeComponent();
        }

        void OnChartRendered(object sender, RenderEventArgs e)
        {
            var flexChart = sender as C1FlexChart;
            if (flexChart == null)
                return;

            var rect = flexChart.PlotRect;
            e.Engine.SetFill(Colors.Transparent);
            e.Engine.SetStroke(new SolidColorBrush(Colors.DimGray));
            e.Engine.SetStrokeThickness(1d);
            e.Engine.DrawRect(rect.X, rect.Y, rect.Width, rect.Height);
        }

        void OnRangeSelectorValueChanged(object sender, System.EventArgs e)
        {
            chartPrecipitation.AxisX.Min = rangeSelector.LowerValue;
            chartPrecipitation.AxisX.Max = rangeSelector.UpperValue;
            chartPressure.AxisX.Min = rangeSelector.LowerValue;
            chartPressure.AxisX.Max = rangeSelector.UpperValue;
            chartTemperature.AxisX.Min = rangeSelector.LowerValue;
            chartTemperature.AxisX.Max = rangeSelector.UpperValue;
        }

        private void rangeSelector_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            rangeSelector.UpperValue = 42550;
        }
    }
}
