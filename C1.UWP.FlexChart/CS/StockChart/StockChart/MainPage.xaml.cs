using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StockChart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel.ChartViewModel.Instance;

            this.Loaded += (o, e) =>
            {
                ViewModel.ChartViewModel.Instance.MainChart = financialChart1;
                ViewModel.ChartViewModel.Instance.MainSeries = mainSeries;
                ViewModel.ChartViewModel.Instance.MainMovingAverage = mainMovingAverage;
                ViewModel.ChartViewModel.Instance.VolumeSeries = volumeSeries;
                ViewModel.ChartViewModel.Instance.RangeSelector = rangeSelector;
                ViewModel.ChartViewModel.Instance.AnnotationLayer = annotationLayer;
                ViewModel.ChartViewModel.Instance.LineMarker = lineMarker;

                this.rangeSelector.UpperValue = Utilities.ToOADate(DateTime.Now);
                this.rangeSelector.LowerValue = Utilities.ToOADate(DateTime.Parse(string.Format("01-01-{0}", DateTime.Now.Year)));

                this.financialChart2.AxisX.Min = Utilities.ToOADate(new DateTime(2007, 12, 31));

            };

            this.lineMarker.Loaded += (o, e) =>
            {
                if (this.lineMarker.Visibility == Visibility.Visible)
                {
                    Brush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
                    IEnumerable<DependencyObject> visuals = GetLineVisual(this.lineMarker);
                    foreach (var item in visuals)
                    {
                        var line = item as Windows.UI.Xaml.Shapes.Line;
                        line.Fill = line.Stroke = whiteBrush;
                    }
                }
                this.lineMarker.Visibility = Visibility.Collapsed;
            };

        }

        static IEnumerable<DependencyObject> GetLineVisual(DependencyObject obj)
        {
            List<DependencyObject> objs = new List<DependencyObject>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var visual = VisualTreeHelper.GetChild(obj, i);

                if (visual is Windows.UI.Xaml.Shapes.Line)
                {
                    objs.Add(visual);
                }
                else
                {
                    objs.AddRange(GetLineVisual(visual));
                }

            }
            return objs;

        }




        private void OnLineMarkerPositionChanged(object sender, C1.Xaml.Chart.Interaction.PositionChangedArgs e)
        {
            if (financialChart1 != null)
            {
                var info = financialChart1.HitTest(new Point(e.Position.X, e.Position.Y));
                var value = lineMarker.Y; // financialChart1.AxisY.Min + (financialChart1.AxisY.Max - financialChart1.AxisY.Min) * (financialChart1.PlotRect.Top + financialChart1.PlotRect.Height - lineMarker.Y) / financialChart1.PlotRect.Height;

                //draw Y rectangle

                var format = string.Format((value >= 0 ? "+{0:P2}" : "{0:P2}"), value);
                if (value == 0)
                {
                    format = "{0:P2}";
                }
                var text = string.Format(ViewModel.ChartViewModel.Instance.IsComparisonMode ? format : "{0:.##}", value);

                var border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb(255, 34, 34, 34));
                var tb = new TextBlock();
                tb.Padding = new Thickness(10);

                border.Child = tb;

                tb.Inlines.Add(new Run()
                {
                    Text = string.Format("{0:MMM dd, yyyy} \r\n", info.X),
                    Foreground = new SolidColorBrush() { Color = Color.FromArgb(255, 170, 170, 170) },
                });

                tb.Inlines.Add(new Run()
                {
                    Text = text,
                    Foreground = new SolidColorBrush() { Color = Color.FromArgb(255, 170, 170, 170) },
                    FontWeight = Windows.UI.Text.FontWeights.Bold
                });
                lineMarker.Content = border;
            }
        }

        private void rangeSelector_ValueChanged(object sender, EventArgs e)
        {
            ViewModel.ChartViewModel.Instance.LowerValue = financialChart1.AxisX.Min = rangeSelector.LowerValue;
            ViewModel.ChartViewModel.Instance.UpperValue = financialChart1.AxisX.Max = rangeSelector.UpperValue;
        }

        private void financialChart1_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pp = e.GetCurrentPoint(financialChart1);

            var ht = financialChart1.HitTest(pp.Position);
            if (ht != null)
            {
                var result = new StringBuilder();
                if (ht.PointIndex >= 0)
                {
                    DateTime currDate = DateTime.MaxValue;
                    if (ht.Series != null && ht.Item != null)
                    {
                        currDate = Convert.ToDateTime(ht.Item.GetRefValue("date"));
                    }
                    if (ht.Series is C1.Xaml.Chart.Finance.MovingAverage)
                    {
                        currDate = currDate.AddDays(0 - (ht.Series as C1.Xaml.Chart.Finance.MovingAverage).Period);
                    }
                    if (currDate == DateTime.MaxValue)
                    {
                        return;
                    }

                    Queue<QuoteInfo> quotes = new Queue<QuoteInfo>();
                    string binding = ViewModel.ChartViewModel.Instance.Binding == "high,low,open,close" ? "close" : ViewModel.ChartViewModel.Instance.Binding;
                    if (ViewModel.ChartViewModel.Instance.DataSource != null)
                    {
                        result.Append(string.Format("{0}: ", ViewModel.ChartViewModel.Instance.MainSymbol));
                        var quote = (from p in ViewModel.ChartViewModel.Instance.DataSource where (p.date >= currDate) select p).FirstOrDefault();

                        if (quote != null)
                        {
                            double dd = quote.GetValue(binding);

                            quotes.Enqueue(new QuoteInfo()
                            {
                                Code = ViewModel.ChartViewModel.Instance.MainSymbol,
                                Color = Color.FromArgb(255, 255, 165, 0),
                                Value = dd,
                                Volume = Convert.ToInt32(quote.GetRefValue("volume")),
                                Date = Convert.ToDateTime(quote.GetRefValue("date"))
                            });
                        }
                    }

                    if (ViewModel.ChartViewModel.Instance.SymbolCollection != null && ViewModel.ChartViewModel.Instance.SymbolCollection.Any())
                    {
                        foreach (var series in financialChart1.Series)
                        {
                            if (series.Visibility == C1.Chart.SeriesVisibility.Visible && !(series is C1.Xaml.Chart.Finance.MovingAverage) && !string.IsNullOrEmpty(series.SeriesName))
                            {
                                var currSeries = (from p in ViewModel.ChartViewModel.Instance.SymbolCollection where p.Series == series select p).FirstOrDefault();

                                if (currSeries != null)
                                {

                                    var quote = (from p in currSeries.DataSource where (p.date >= currDate) select p).FirstOrDefault();

                                    if (quote != null)
                                    {
                                        double dd = quote.GetValue(binding);

                                        quotes.Enqueue(new QuoteInfo()
                                        {
                                            Code = currSeries.Code,
                                            Color = currSeries.Color,
                                            Value = dd,
                                            Volume = Convert.ToInt32(quote.GetRefValue("volume")),
                                            Date = Convert.ToDateTime(quote.GetRefValue("date"))
                                        });
                                    }
                                }
                            }
                        }
                    }
                    ViewModel.ChartViewModel.Instance.ComparisonQuoteInfo = quotes;
                }
            }
        }

    }
}
