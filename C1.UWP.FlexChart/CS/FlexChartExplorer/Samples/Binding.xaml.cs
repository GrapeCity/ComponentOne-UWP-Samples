using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml.Chart;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlexChartExplorer
{
    public sealed partial class Binding : Page
    {
        int npts = 50;
        Random rnd = new Random();
        Dictionary<ChartType, string> _chartTypes;
        List<DataItem> _data;

        public Binding()
        {
            this.InitializeComponent();
        }

        public Dictionary<ChartType, string> ChartTypes
        {
            get
            {
                if (_chartTypes == null)
                {
                    _chartTypes = new Dictionary<ChartType, string>();
                    _chartTypes.Add(ChartType.Line, Strings.Line);
                    _chartTypes.Add(ChartType.LineSymbols, Strings.LineSymbols);
                    _chartTypes.Add(ChartType.Area, Strings.Area);
                }

                return _chartTypes;
            }
        }

        public List<DataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<DataItem>();
                    var dateStep = 0;
                    for (var i = 0; i < npts; i++)
                    {
                        var date = DateTime.Today.AddDays(dateStep += 9);
                        _data.Add(new DataItem()
                        {
                            Downloads = date.Month == 4 || date.Month == 8 ? (int?)null : rnd.Next(10, 20),
                            Sales = date.Month == 4 || date.Month == 8 ? (int?)null : rnd.Next(0, 10),
                            Date = date
                        });
                    }
                }

                return _data;
            }
        }

        public C1FlexChart FlexChart
        {
            get
            {
                return flexChart;
            }
        }
    }

    public class DataItem
    {
        public int? Downloads { get; set; }
        public int? Sales { get; set; }
        public DateTime Date { get; set; }
    }
}
