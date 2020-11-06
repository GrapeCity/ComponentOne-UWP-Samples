using C1.Xaml.Chart;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using C1.Chart;
using Windows.UI;

namespace FloatingBarChart
{
    /// <summary>
    /// Interaction logic for Gantt.xaml
    /// </summary>
    public partial class Gantt : Page
    {
        Series customSeries;
        public Gantt()
        {
            InitializeComponent();
            customSeries = new GanntSeriesWithPointLegendItems();
            customSeries.SeriesName = "Phases";
            customSeries.Binding = "Start,End";
            customSeries.SymbolRendering += CustomSeries_SymbolRendering;
            flexChart.LabelRendering += FlexChart_LabelRendering;
            flexChart.AxisX.MajorUnit = 1;
            flexChart.AxisX.MajorGrid = true;
            flexChart.AxisX.Format = "Week 0";
            flexChart.Series.Add(customSeries);
            flexChart.ToolTip.Content = "{x}";
            flexChart.DataLabel.Position = LabelPosition.Left;
            flexChart.DataLabel.Content = "Value";
        }

        private void FlexChart_LabelRendering(object sender, RenderDataLabelEventArgs e)
        {
            var range = (Phase)e.Item;
            int duration = range.End - range.Start;
            e.Text = duration > 1 ? duration + " weeks" : "1 week";
        }

        private void CustomSeries_SymbolRendering(object sender, RenderSymbolEventArgs e)
        {
            var color = SampleViewModel.ReleasePhases[e.Index].Color;
            e.Engine.SetFill(new SolidColorBrush(color));
            e.Engine.SetStroke(new SolidColorBrush(Color.FromArgb(200, color.R, color.G, color.B)));
        }

        public class GanntSeriesWithPointLegendItems : Series, ISeries
        {
            /// <summary>
            /// Gets the name of legend.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            string ISeries.GetLegendItemName(int index) { return SampleViewModel.ReleasePhases[SampleViewModel.ReleasePhases.Count - 1 - index].Name; }

            /// <summary>
            /// Gets the style of legend.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            _Style ISeries.GetLegendItemStyle(int index)
            {
                return new _Style { Fill = new SolidColorBrush(SampleViewModel.ReleasePhases[SampleViewModel.ReleasePhases.Count - 1 - index].Color) };
            }

            /// <summary>
            /// Get the number of series items in the legend.
            /// </summary>
            int ISeries.GetLegendItemLength() { return SampleViewModel.ReleasePhases.Count; }
        }
    }
}
