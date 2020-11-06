using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Printing;
using Windows.Graphics.Printing;

using System.Reflection;

using System.Runtime.Serialization;
using System.Xml.Serialization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
using C1.Chart;
using C1.Xaml.Chart;

namespace FlexChartPrint
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        PrintHelper printHelper = new PrintHelper();
        UIElement[] charts = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            // init charts
            if (charts == null)
            {
                SetupLineChart();
                SetupColumnChart();
                SetupPieChart();
                charts = new UIElement[] { lineChart, columnChart, pieChart };
            }
        }

        private void btnPrintSingle_Click(object sender, RoutedEventArgs e)
        {
            SetupSinglePagePrinting();
            printHelper.Print(1);
        }

        private void btnPrintMulti_Click(object sender, RoutedEventArgs e)
        {
            SetupMultiPagePrinting();
            printHelper.Print(charts.Length);
        }

        private void btnPrintMultiLine_Click(object sender, RoutedEventArgs e)
        {
            SetupMultiLinePrinting();
            printHelper.Print(10);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            printHelper.Register();// register view for printing
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            printHelper.Unregister();
            base.OnNavigatedFrom(e);
        }

        #region Setup print handlers

        private void SetupSinglePagePrinting()
        {
            printHelper.PagePrinting = (pageNumber) => {
                Content = null;
                pnlOptions.Visibility = Visibility.Collapsed;// hide buttons
                return root; // print root grid element
            };

            printHelper.PagePrinted = (pageNumber, visual) => {
                // restore visual tree
                Content = root;
                pnlOptions.Visibility = Visibility.Visible;
            };
        }

        private void SetupMultiPagePrinting()
        {
            printHelper.PagePrinting = (pageNumber) => {
                Content = null;
                pnlOptions.Visibility = Visibility.Collapsed;// hide buttons
                var chart = charts[pageNumber - 1];
                root.Children.Remove(chart); // detach from visual tree
                return chart;
            };

            printHelper.PagePrinted = (pageNumber, visual) => {
                // restore visual tree
                root.Children.Add(visual);
                Content = root;
                pnlOptions.Visibility = Visibility.Visible;
            };
        }

        private void SetupMultiLinePrinting()
        {
            double actualMin = ((IAxis)lineChart.AxisX).GetMin();
            double actualMax = ((IAxis)lineChart.AxisX).GetMax();
            double range = actualMax - actualMin;

            printHelper.PagePrinting = (pageNumber) => {
                Content = null;
                pnlOptions.Visibility = Visibility.Collapsed;// hide buttons
                root.Children.Remove(lineChart);// detach from visual tree

                // set x-range
                lineChart.AxisX.Min = actualMin + (pageNumber - 1) * range / 10;
                lineChart.AxisX.Max = actualMin + pageNumber * range / 10;

                return lineChart;
            };

            printHelper.PagePrinted = (pageNumber, visual) => {
                // restore x-range
                lineChart.AxisX.Min = double.NaN;
                lineChart.AxisX.Max = double.NaN;

                // restore visual tree
                root.Children.Add(visual);
                Content = root;
                pnlOptions.Visibility = Visibility.Visible;
            };
        }

        #endregion


        #region Sample charts

        private void SetupPieChart()
        {
            pieChart.BeginUpdate();
            var len = 10;
            var data = new object[len];
            for (var i = 0; i < 4; i++)
                data[i] = new { Name = "Q " + (i+1).ToString(), Value = i+1 };

            pieChart.Binding = "Value";
            pieChart.BindingName = "Name";
            pieChart.ItemsSource = data;
            pieChart.EndUpdate();
        }

        private void SetupColumnChart()
        {
            columnChart.BeginUpdate();

            var len = 10;
            for (var j = 0; j < 2; j++)
            {
                var pts = new Point[len];
                for (int i = 0; i < pts.Length; i++)
                    pts[i] = new Point(i, 2.0 + Math.Sin(i - 0.5*j));
                var ser = new Series() { ItemsSource = pts, SeriesName = "S " + (j+1).ToString() };
                ser.BindingX = "X";
                ser.Binding = "Y";
                columnChart.Series.Add(ser);
            }

            columnChart.EndUpdate();
        }

        private void SetupLineChart()
        {
            var rnd = new Random();
            var pts1 = new Point[1001];
            for (int i = 0; i < pts1.Length; i++)
            {
                var r = rnd.NextDouble();
                pts1[i] = new Point(i, 10 * r *Math.Sin(0.1*i)*Math.Sin(0.6*rnd.NextDouble() * i));
            }

            var pts2 = new Point[1001];
            for (int i = 0; i < pts2.Length; i++)
            {
                var r = rnd.NextDouble();
                pts2[i] = new Point(i, 10 * r * Math.Sin(0.1 * i) * Math.Sin(0.6 * rnd.NextDouble() * i));
            }

            lineChart.BeginUpdate();
            
            var ser1 = new Series() { ItemsSource = pts1 };
            ser1.BindingX = "X";
            ser1.Binding = "Y";
            ser1.SeriesName = "s1";
            lineChart.Series.Add(ser1);

            var ser2 = new Series() { ItemsSource = pts2 };
            ser2.BindingX = "X";
            ser2.Binding = "Y";
            ser2.SeriesName = "s2";
            lineChart.Series.Add(ser2);

            lineChart.ChartType = ChartType.Line;
            lineChart.LegendPosition = Position.Bottom;
            lineChart.EndUpdate();
        }

        #endregion
    }

}
