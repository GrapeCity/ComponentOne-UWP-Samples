using C1.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace FlexChartExplorer
{
    public sealed partial class NumericAxisGrouping : Page
    {
        Dictionary<AxisGroupSeparator, string> _groupSeparator;

        public NumericAxisGrouping()
        {
            this.InitializeComponent();
            flexChart.AxisY.GroupProvider = new MyGroupProvider();
        }

        public Dictionary<AxisGroupSeparator, string> GroupSeparator
        {
            get
            {
                if (_groupSeparator == null)
                {
                    _groupSeparator = new Dictionary<AxisGroupSeparator, string>();
                    _groupSeparator.Add(AxisGroupSeparator.None, "None");
                    _groupSeparator.Add(AxisGroupSeparator.Horizontal, "Horizontal");
                    _groupSeparator.Add(AxisGroupSeparator.Vertical, "Vertical");
                    _groupSeparator.Add(AxisGroupSeparator.Grid, "Grid");
                }

                return _groupSeparator;
            }
        }

        public List<TemperatureRecord> Data
        {
            get { return TemperatureRecord.Records(); }
        }

        class MyGroupProvider : IAxisGroupProvider
        {
            public int GetLevels(IRange range)
            {
                return 1;
            }

            public bool? GetExpandButton(int level)
            {
                return null;
            }

            public void OnButtonClick(int level) {}

            public IList<IRange> GetRanges(IRange range, int level)
            {
                var ranges = new List<IRange>();
                if (level == 1)
                {
                    ranges.Add(new DoubleRange("Low", 0, 10));
                    ranges.Add(new DoubleRange("Medium", 10, 25));
                    ranges.Add(new DoubleRange("High", 25, 40));
                }
                return ranges;
            }
        }

        public class TemperatureRecord
        {
            public string Month { get; set; }
            public double Temperature { get; set; }
            public TemperatureRecord(string month, double temperature)
            {
                Month = month;
                Temperature = temperature;
            }
            public static List<TemperatureRecord> Records()
            {
                var records = new List<TemperatureRecord>();
                records.Add(new TemperatureRecord("Jan", 1));
                records.Add(new TemperatureRecord("Feb", 5));
                records.Add(new TemperatureRecord("Mar", 2.4));
                records.Add(new TemperatureRecord("Apr", 8));
                records.Add(new TemperatureRecord("May", 30));
                records.Add(new TemperatureRecord("Jun", 17.5));
                records.Add(new TemperatureRecord("Jul", 32.8));
                records.Add(new TemperatureRecord("Aug", 20));
                records.Add(new TemperatureRecord("Sep", 16));
                records.Add(new TemperatureRecord("Oct", 10));
                records.Add(new TemperatureRecord("Nov", 4.6));
                records.Add(new TemperatureRecord("Dec", 5));
                return records;
            }
        }

    }
}
