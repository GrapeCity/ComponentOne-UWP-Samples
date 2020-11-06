using C1.Chart;
using C1.Chart.Annotation;
using C1.Xaml.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Rectangle = C1.Xaml.Chart.Annotation.Rectangle;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for EventAnnotations.xaml
    /// </summary>
    public partial class EventAnnotations : Page
    {
        DataService dataService = DataService.GetService();
        private List<Quote> _data;

        public EventAnnotations()
        {
            InitializeComponent();
            this.Loaded += EventAnnotations_Loaded;
        }

        private void EventAnnotations_Loaded(object sender, RoutedEventArgs e)
        {
            var annotations = dataService.GetData<Annotation>("box-annotations");
            foreach (var anno in annotations)
            {
                var rectangle = new Rectangle()
                {
                    Content = "E",
                    Width = 20,
                    Height = 20,
                    Attachment = AnnotationAttachment.DataIndex,
                    PointIndex = anno.DataIndex,
                    TooltipText = anno.Description == null ? "[b]" + anno.Title + "[/b]" : ("[b]" + anno.Title + "[/b]" + "\n" + anno.Description)
                };
                var fillColor = (Color)XamlBindingHelper.ConvertValue(typeof(Color), "#88bde6");
                rectangle.Style = new ChartStyle()
                {
                    Fill = new SolidColorBrush(fillColor)
                };
                annotationLayer.Annotations.Add(rectangle);
            }
        }

        public List<Quote> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = dataService.GetSymbolData("box", 87);
                }

                return _data;
            }
        }

        private void rangeChanged(object sender, EventArgs e)
        {
            var yRange = dataService.FindRenderedYRange(Data, selector.LowerValue, selector.UpperValue);
            financialChart.BeginUpdate();
            financialChart.AxisX.Min = selector.LowerValue;
            financialChart.AxisX.Max = selector.UpperValue;
            financialChart.AxisY.Min = yRange.Min;
            financialChart.AxisY.Max = yRange.Max;
            financialChart.EndUpdate();
        }

        private void selectorChart_Rendered(object sender, RenderEventArgs e)
        {
            if (selector != null)
            {
                var axis = selectorChart.AxisX as IAxis;
                var min = axis.GetMin();
                var max = axis.GetMax();
                var range = dataService.FindApproxRange(min, max, dataService.IsWindowsPhoneDevice() ? 0.25 : 0.45);
                selector.LowerValue = range.Min;
                selector.UpperValue = range.Max;
            }
        }
    }
}
