using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Navigation;

using C1.Chart;
using C1.Xaml.Chart;

using AnimationDemo.Data;

namespace AnimationDemo.View
{
    public sealed partial class FlexChartAnimation : Page
    {
        DataSource dataSource;

        public FlexChartAnimation()
        {
            this.InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            dataSource.NewData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            dataSource.UpdateData();
        }

        private void AddSer_Click(object sender, RoutedEventArgs e)
        {
            dataSource.AddSeries();
        }

        private void DelSer_Click(object sender, RoutedEventArgs e)
        {
            dataSource.RemoveSeries();
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            dataSource.AddPoint();
        }

        private void DelPoint_Click(object sender, RoutedEventArgs e)
        {
            dataSource.RemovePoint();
        }

        private void chart_Loaded(object sender, RoutedEventArgs e)
        {
            cbChartType.ItemsSource = new ChartType[] { ChartType.Column, ChartType.Bar, ChartType.Line, ChartType.LineSymbols, ChartType.Scatter, ChartType.Area };
            cbStacking.ItemsSource = new Stacking[] { Stacking.None, Stacking.Stacked, Stacking.Stacked100pc };
            cbRenderMode.ItemsSource = new RenderMode[] { RenderMode.Default, RenderMode.Direct2D };
            cbAnimation.ItemsSource = new AnimationSettings[]
                    { AnimationSettings.None, AnimationSettings.Load, AnimationSettings.Update,
                        AnimationSettings.AxesLoad, AnimationSettings.AxesUpdate, AnimationSettings.Axes,
                        AnimationSettings.All };
            cbAnimation.SelectedValue = AnimationSettings.All;

            dataSource = new DataSource(chart);
            dataSource.NewData();
        }

        private void cbAnimation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pnlLoad.Visibility = (chart.AnimationSettings & (AnimationSettings.Load | AnimationSettings.AxesLoad)) != 0 ? Visibility.Visible : Visibility.Collapsed;
            pnlUpdate.Visibility = (chart.AnimationSettings & (AnimationSettings.Update | AnimationSettings.AxesUpdate)) != 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public List<C1.Chart.AnimationDirection> Directions
        {
            get
            {
                return new List<C1.Chart.AnimationDirection>() { C1.Chart.AnimationDirection.X, C1.Chart.AnimationDirection.Y, C1.Chart.AnimationDirection.XY };
            }
        }

        public List<AnimationType> Types
        {
            get
            {
                return new List<AnimationType>() { AnimationType.All, AnimationType.Series, AnimationType.Points };
            }
        }

        public List<AnimationSettings> Settings
        {
            get
            {
                return new List<AnimationSettings>() { AnimationSettings.None, AnimationSettings.Load, AnimationSettings.Update, AnimationSettings.AxesLoad, AnimationSettings.AxesUpdate, AnimationSettings.Axes, AnimationSettings.All };
            }
        }

        List<Easing> easings;

        public List<Easing> Easings
        {
            get
            {
                if (easings == null)
                {
                    var ar = Enum.GetValues(typeof(Easing));
                    easings = new List<Easing>();
                    foreach (var o in ar)
                        easings.Add((Easing)o);
                }
                return easings;
            }
        }
    }

    class DataSource
    {
        C1FlexChart chart;
        int npts = 10;
        int nser = 3;
        static Random rnd = new Random();

        public DataSource(C1FlexChart chart)
        {
            this.chart = chart;
        }

        public void NewData()
        {
            var max = (1 + (int)(rnd.NextDouble() * 5)) * 100;

            chart.Series.Clear();

            for (var i = 0; i < nser; i++)
                chart.Series.Add(new Series()
                {
                    Binding = "Y",
                    BindingX = "X",
                    ItemsSource = DataHelper.Create( npts, max),
                    SeriesName = i.ToString()
                });
        }

        public void UpdateData()
        {
            var max = (1 + (int)(rnd.NextDouble() * 5)) * 100;
            var nser = chart.Series.Count;

            for (var i = 0; i < nser; i++)
                chart.Series[i].ItemsSource = DataHelper.Create( npts, max);
        }

        public void AddSeries()
        {
            var max = (1 + (int)(rnd.NextDouble() * 5)) * 100;

            chart.Series.Add(new Series()
            {
                Binding = "Y",
                BindingX = "X",
                ItemsSource = DataHelper.Create( npts, max),
                SeriesName = chart.Series.Count.ToString()
            });
        }

        public void RemoveSeries()
        {
            var cnt = chart.Series.Count;
            if (cnt > 0)
                chart.Series.RemoveAt(cnt - 1);
        }

        public void AddPoint()
        {
            var max = (1 + (int)(rnd.NextDouble() * 5)) * 100;

            foreach (var s in chart.Series)
            {
                var col = (ObservableCollection<Point>)s.ItemsSource;
                col.Add(new Point(col.Count, rnd.NextDouble() * max));
            }
        }

        public void RemovePoint()
        {
            foreach (var s in chart.Series)
            {
                var col = (ObservableCollection<Point>)s.ItemsSource;
                if (col.Count > 0)
                    col.RemoveAt(col.Count - 1);
            }
        }
    }
}
