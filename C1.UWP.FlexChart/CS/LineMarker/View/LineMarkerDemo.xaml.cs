﻿using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using C1.Chart;
using C1.Xaml.Chart.Interaction;
using Windows.Foundation;

namespace LineMarkerSample
{
    /// <summary>
    /// Interaction logic for LineMarkerDemo.xaml
    /// </summary>
    public partial class LineMarkerDemo : UserControl
    {
        public LineMarkerDemo()
        {
            InitializeComponent();
        }

        Color FromArgb(int clr)
        {
            var bytes = BitConverter.GetBytes(clr);
            return Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
        }

        private void OnLineMarkerPositionChanged(object sender, PositionChangedArgs e)
        {
            if (flexChart != null)
            {
                var info = flexChart.HitTest(new Point(e.Position.X, double.NaN));
                int pointIndex = info.PointIndex;
                var tb = new TextBlock();
                if (info.X == null)
                    return;

                tb.Inlines.Add(new Run()
                {
                    Text = string.Format("{0:dd-MM}", info.X)
                });
                for (int index = 0; index < flexChart.Series.Count; index++)
                {
                    var series = flexChart.Series[index];
                    var value = series.GetValues(0)[pointIndex];
                    var fill = (int)((IChart)flexChart).GetColor(index);
                    string content = string.Format("{0}{1} = {2}", "\n", series.SeriesName, string.Format("{0:f2}", value));
                    tb.Inlines.Add(new Run()
                    {
                        Text = content,
                        Foreground = new SolidColorBrush() { Color = FromArgb(fill) }
                    });
                }
                tb.IsHitTestVisible = false;
                lineMarker.Content = tb;
            }
        }
    }
}
