using C1.Xaml.Chart;
using System.Linq;
using Windows.UI.Xaml.Controls;
using C1.Chart;

namespace FloatingBarChart
{
    /// <summary>
    /// Interaction logic for FloatingBar.xaml
    /// </summary>
    public partial class RangedArea : Page
    {
        Series seriesA, seriesB;
        float columnWidthPercentage = 0.6f;
        public RangedArea()
        {
            InitializeComponent();
            seriesA = new Series();
            seriesA.Binding = "ClassALow，ClassAHigh";
            seriesA.SeriesName = "Class A";

            seriesB = new Series();
            seriesB.Binding = "ClassBLow,ClassBHigh";
            seriesB.SeriesName = "Class B";

            flexChart.Series.Add(seriesA);
            flexChart.Series.Add(seriesB);
            flexChart.LabelRendering += FlexChart_LabelRendering;
            flexChart.AxisY.MajorUnit = 10;
            flexChart.ToolTip.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flexChart.DataLabel.Position = LabelPosition.Bottom;
            flexChart.DataLabel.Content = "{seriesName}";
            flexChart.ChartType = ChartType.Area;
            flexChart.Options.ClusterSize = new ElementSize() { SizeType = ElementSizeType.Percentage, Value = columnWidthPercentage * 100 };
        }

        private void FlexChart_LabelRendering(object sender, RenderDataLabelEventArgs e)
        {
            SubjectScoreRange range = (SubjectScoreRange)e.Item;
            e.Text = e.Text.Equals("Class A") ? range.ClassALow + " - " + range.ClassAHigh : range.ClassBLow + " - " + range.ClassBHigh;
        }
        
    }
}
