using DataManipulation.Business.FunctionSeries;
using System;
using Windows.UI.Xaml.Controls;

namespace DataManipulation
{
    /// <summary>
    /// Interaction logic for YFunctionSeriesView.xaml
    /// </summary>
    public partial class YFunctionSeriesView : Page
    {
        YFunctionSeries series;
        public YFunctionSeriesView()
        {
            InitializeComponent();

            this.Loaded += (o, e) =>
             {
                 series = new YFunctionSeries();
                 series.SampleCount = 300;
                 series.Min = -10;
                 series.Max = 10;
                 series.SeriesName = "Y-Function Series";
                 series.Function = Calculate;
                 this.flexChart1.Series.Clear();
                 this.flexChart1.Series.Add(series);
             };
        }

        private double Calculate(double v)
        {
            return Math.Sin(4 * v) * Math.Cos(3 * v);
        }
    }
}
