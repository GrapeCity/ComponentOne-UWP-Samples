using C1.Xaml;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlexRadarIntro
{
    /// <summary>
    /// Interaction logic for PolarChart.xaml
    /// </summary>
    public partial class PolarChart : Page
    {
        public PolarChart()
        {
            InitializeComponent();
            this.Loaded += PolarChart_Loaded;
        }

        private void PolarChart_Loaded(object sender, RoutedEventArgs e)
        {
            polarChart.ChartType = C1.Chart.RadarChartType.LineSymbols;
            polarChart.ItemsSource = CreateData(10, 2);
        }

        List<Point> CreateData(double k, double a)
        {
            var pts = new List<Point>();
            int n = 360;
            for (var i = 0; i < n; i++)
            {
                var angle = Math.PI * i / 180;
                pts.Add(new Point() { X = i, Y = (float)(Math.Cos(k * angle) + a) });
            }
            return pts;
        }

        void OnNumericBoxValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (numericUpDown2 != null && numericUpDown2 != null && polarChart != null)
            {
                polarChart.ItemsSource = CreateData(numericUpDownStartAngle.Value, numericUpDown2.Value);
            }
        }
    }
}
