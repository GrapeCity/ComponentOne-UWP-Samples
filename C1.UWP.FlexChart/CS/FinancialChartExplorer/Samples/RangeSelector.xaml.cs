using System;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for RangeSelector.xaml
    /// </summary>
    public partial class RangeSelector : Page
    {
        DataService dataService = DataService.GetService();

        public RangeSelector()
        {
            InitializeComponent();
        }

        public List<Quote> Data
        {
            get
            {
                return dataService.GetSymbolData("fb");
            }
        }

        void OnRangeSelectorValueChanged(object sender, EventArgs e)
        {
            candlestickChart.AxisX.Min = rangeSelector.LowerValue;
            candlestickChart.AxisX.Max = rangeSelector.UpperValue;
        }
    }
}
