using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml.Chart;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Axes : Page
    {
        List<DataItem> _data;
        Random rnd = new Random();
        int npts = 12;

        public Axes()
        {
            this.InitializeComponent();
        }

        public List<DataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<DataItem>();
                    var dt = DateTime.Today;
                    for (var i = 0; i < npts; i++)
                    {
                        _data.Add(new DataItem()
                        {
                            Time = dt.AddMonths(i),
                            Precipitation = rnd.Next(30, 100),
                            Temperature = rnd.Next(7, 20)
                        });
                    }
                }

                return _data;
            }
        }

        public List<double> LabelAngles
        {
            get
            {
                return new List<double>() { -90, -45, 0, 45, 90 };
            }
        }

        public class DataItem
        {
            public DateTime Time { get; set; }
            public int Precipitation { get; set; }
            public int Temperature { get; set; }
        }
    }
}
