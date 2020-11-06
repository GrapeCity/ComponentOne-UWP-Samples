using C1.Xaml.Chart;
using C1.Xaml.Chart.Finance;
using System.Collections.Generic;

namespace StockAnalysis.Partial.CustomControls.IndicatorSeries
{
    public interface IIndicator
    {
        event System.EventHandler SettingParamsChanged;
        C1FlexChart Chart
        {
            get;
        }


        IEnumerable<Series> Series
        {
            get;
        }

        Axis AxisY
        {
            get;
        }

        string PlotAreaName
        {
            get;
            set;
        }

        void RemoveAllSeriesFromChart();


        IEnumerable<Object.QuoteRange> GetYRange(double low, double high);
    }
}