using C1.Xaml.Chart;
using C1.Xaml.Chart.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Partial.CustomControls.IndicatorSeries
{
    public class ATRSeries : IndicatorSeriesBase
    {
        public ATRSeries(C1FlexChart chart, string plotAreaName) : base()
        {
            Chart = chart;
            Chart.BeginUpdate();


            Axis axisY = new Axis();
            axisY.TitleStyle = new ChartStyle();
            axisY.TitleStyle.FontWeight = FontWeights.Bold;
            axisY.Position = C1.Chart.Position.Right;
            axisY.PlotAreaName = plotAreaName;
            axisY.Title = "ATR";
            axisY.Labels = false;
            axisY.MajorTickMarks = axisY.MinorTickMarks = C1.Chart.TickMark.None;


            ATR series = new ATR();

            series.ChartType = C1.Chart.Finance.FinancialChartType.Line;
            series.Style = new ChartStyle();
            series.Style.Stroke = new SolidColorBrush(Color.FromArgb(255, 51, 103, 214));
            series.Style.Fill = new SolidColorBrush(Color.FromArgb(128, 66, 133, 244));
            series.Style.StrokeThickness = 1;
            series.BindingX = "Date";
            series.Binding = "High,Low,Close";


            series.AxisY = axisY;
            Chart.Series.Add(series);


            Utilities.Helper.BindingSettingsParams(chart, series, typeof(ATR), "Average True Range (ATR)",
                new Data.PropertyParam[]
                {
                    new Data.PropertyParam("Period", typeof(int)),
                    new Data.PropertyParam("Style.Stroke", typeof(Brush)),
                },
                () =>
                {
                    this.OnSettingParamsChanged();
                }
            );

            //binding series color to axis title.
            Binding binding = new Binding();
            binding.Path = new Windows.UI.Xaml.PropertyPath("Stroke");
            binding.Source = series.Style;
            BindingOperations.SetBinding(axisY.TitleStyle, ChartStyle.StrokeProperty, binding);


            Chart.EndUpdate();

            this.Series = new FinancialSeries[] { series };
        }
    }
}
