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
using Windows.UI.Xaml.Navigation;

using C1.Chart;
using C1.Xaml.Chart;

namespace AnimationDemo.View
{
    public sealed partial class CustomAnimation : Page
    {
        int npts = 100;

        public CustomAnimation()
        {
            this.InitializeComponent();
        }

        private void AddSer_Click(object sender, RoutedEventArgs e)
        {
            AddsSeries();
        }

        private void DelSer_Click(object sender, RoutedEventArgs e)
        {
            if (chart.Series.Count > 0)
                chart.Series.RemoveAt(chart.Series.Count - 1);
        }

        private void chart_Loaded(object sender, RoutedEventArgs e)
        {
            chart.AnimationLoad.Direction = C1.Chart.AnimationDirection.XY;
            chart.AnimationLoad.Easing = Easing.Linear;

            AddsSeries();
        }

        void AddsSeries()
        {
            var pts = new Point[npts];

            var rnd = new Random();
            for (var i = 0; i < npts; i++)
                pts[i] = new Point(2 * (rnd.NextDouble() - 0.5f), 2 * (rnd.NextDouble() - 0.5f));

            var ser = new Series() { BindingX = "X", Binding = "Y", ItemsSource = pts, SymbolSize = 4 };
            chart.Series.Add(ser);
        }

        private void AnimationTransform(object sender, AnimationTransformEventArgs e)
        {
            var center = ((Point[])e.Series.DataSource)[0];
            e.Start = e.AxisType == AxisType.X ? center.X : center.Y;
        }

        private void chart_Unloaded(object sender, RoutedEventArgs e)
        {
            chart.Series.Clear();
        }

    }
}
