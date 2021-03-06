﻿using C1.Xaml.Chart;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using C1.Chart;
using Windows.UI;

namespace FlexChartCustomization
{
    /// <summary>
    /// Interaction logic for LegendRanges.xaml
    /// </summary>
    public partial class LegendRanges : Page
    {
        public LegendRanges()
        {
            InitializeComponent();

            var recordsSeries = new SeriesWithPointLegendItems();
            recordsSeries.SymbolRendering += RecordsSeries_SymbolRendering;
            flexChart.Series.Add(recordsSeries);
        }
        private void RecordsSeries_SymbolRendering(object sender, RenderSymbolEventArgs e)
        {
            int idx = (((TemperatureRecord)e.Item).High - 95) / 5;
            e.Engine.SetFill(new SolidColorBrush(GetTempartureRangeColor(idx)));
            e.Engine.SetStroke(new SolidColorBrush(GetTempartureRangeColor(idx)));
        }

        private static readonly Color[] GradientRedColors =
        {
                Color.FromArgb(255, 254, 224, 232),
                Color.FromArgb(255, 252, 173, 193),
                Color.FromArgb(255, 251, 121, 154),
                Color.FromArgb(255, 249, 70, 115),
                Color.FromArgb(255, 247, 19, 77),
                Color.FromArgb(255, 205, 7, 57),
                Color.FromArgb(255, 154, 5, 43),
                Color.FromArgb(255, 103, 3, 29)
        };
        private static Color GetTempartureRangeColor(int index)
        {
            return GradientRedColors[index];
        }

        public class SeriesWithPointLegendItems : Series, ISeries
        {
            /// <summary>
            /// Gets the name of legend.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            string ISeries.GetLegendItemName(int index)
            {
                int low = 95 + 5 * index;
                return low + " to " + (low + 5);
            }

            /// <summary>
            /// Gets the style of legend.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            _Style ISeries.GetLegendItemStyle(int index)
            {
                return new _Style { Fill = new SolidColorBrush(GetTempartureRangeColor(index)) };
            }

            /// <summary>
            /// Get the number of series items in the legend.
            /// </summary>
            int ISeries.GetLegendItemLength() { return 8; }
        }
    }
}
