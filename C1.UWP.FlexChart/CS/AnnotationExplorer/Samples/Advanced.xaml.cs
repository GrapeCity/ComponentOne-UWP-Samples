using C1.Chart.Annotation;
using C1.Xaml.Chart;
using C1.Xaml.Chart.Interaction;
using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Annotation = C1.Xaml.Chart.Annotation;

namespace AnnotationExplorer
{
    /// <summary>
    /// Interaction logic for Advanced.xaml
    /// </summary>
    public partial class Advanced : Page
    {
        AnnotationViewModel _model = new AnnotationViewModel();
        Annotation.Rectangle infoAnnotation;

        public Advanced()
        {
            InitializeComponent();
            this.DataContext = _model;
            this.Loaded += OnAdvancedLoaded;
        }

        public SolidColorBrush TextBrush
        {
            get
            {
                if (Util.IsWindowsDevice)
                {
                    return new SolidColorBrush(Colors.White);
                }
                else
                {
                    return new SolidColorBrush(Colors.Black);
                }
            }
        }

        private void OnAdvancedLoaded(object sender, RoutedEventArgs e)
        {
            SetupAttotations();
        }

        void SetupAttotations()
        {
            var financialData = _model.FinancialData;
            annotationLayer.Annotations.Clear();
            annotationLayer.Annotations.Add(new Annotation.Rectangle("", 10580, 1285)
            {
                Style = new ChartStyle()
                {
                    Fill = new SolidColorBrush(Colors.Green){ Opacity = 25.0 / 255 },
                    Stroke = new SolidColorBrush(Colors.Transparent),
                },
                Location = new Point((float)financialData[20].Date.ToOADate(), 100),
                Attachment = AnnotationAttachment.DataCoordinate,
                Position = AnnotationPosition.Right,
                
            });

            foreach (var data in financialData)
            {
                if (data.Volume >= 9)
                    annotationLayer.Annotations.Add(new Annotation.Square(Strings.DContent, 20)
                    {
                        Style = new ChartStyle()
                        {
                            Fill = new SolidColorBrush(Colors.Blue) { Opacity = 150.0 / 255 },
                            Stroke = new SolidColorBrush(Colors.Transparent),
                        },
                        ContentStyle = new ChartStyle()
                        {
                            FontSize = 10,
                            FontWeight = FontWeights.Bold,
                            FontFamily = new FontFamily("GenericSansSerif"),
                            Stroke = TextBrush
                        },
                        SeriesIndex = 1,
                        PointIndex = financialData.IndexOf(data),
                        Attachment = AnnotationAttachment.DataIndex,
                        TooltipText = Strings.DividendTooltip
                    });
                if (data.Date.Day % 10 == 0)
                    annotationLayer.Annotations.Add(new Annotation.Square(Strings.EContent, 20)
                    {
                        Style = new ChartStyle()
                        {
                            Fill = new SolidColorBrush(Colors.Aqua) { Opacity = 150.0 / 255 },
                        },
                        ContentStyle = new ChartStyle()
                        {
                            FontSize = 10,
                            FontWeight = FontWeights.Bold,
                            FontFamily = new FontFamily("GenericSansSerif")
                        },
                        SeriesIndex = 0,
                        PointIndex = financialData.IndexOf(data),
                        Attachment = AnnotationAttachment.DataIndex,
                        TooltipText = Strings.CloseTooltip
                    });
            }
            annotationLayer.Annotations.Add(new Annotation.Line(Strings.RWContent)
            {
                Style = new ChartStyle()
                {
                    Stroke = new SolidColorBrush(Colors.Aqua),
                },
                ContentStyle = new ChartStyle()
                {
                    FontSize = 12,
                    Stroke = TextBrush,
                    FontFamily = new FontFamily("GenericSansSerif")
                },
                Start = new Point((int)financialData[10].Date.ToOADate(), 20),
                End = new Point((int)financialData[40].Date.ToOADate(), 100),
                Attachment = AnnotationAttachment.DataCoordinate,
            });
            annotationLayer.Annotations.Add(new Annotation.Line("")
            {
                Style = new ChartStyle()
                {
                    Stroke = new SolidColorBrush(Colors.Aqua),
                },
                Start = new Point((int)financialData[20].Date.ToOADate(), 0),
                End = new Point((int)financialData[50].Date.ToOADate(), 80),
                Attachment = AnnotationAttachment.DataCoordinate,
            });
            annotationLayer.Annotations.Add(new Annotation.Image("ms-appx:///AnnotationExplorerLib/Assets/flag.png")
            {
                SeriesIndex = 0,
                PointIndex = 20,
                Attachment = AnnotationAttachment.DataIndex,
                Position = AnnotationPosition.Top
            });
            annotationLayer.Annotations.Add(new Annotation.Text(Strings.FacebookContent)
            {
                Style = new ChartStyle()
                {
                    Stroke = TextBrush,
                    FontFamily = new FontFamily("GenericSansSerif"),
                    FontSize = 12
                },
                SeriesIndex = 0,
                PointIndex = 20,
                Attachment = AnnotationAttachment.DataIndex,
                Position = AnnotationPosition.Left,
            });
            annotationLayer.Annotations.Add(new Annotation.Image("ms-appx:///AnnotationExplorerLib/Assets/flag.png")
            {
                SeriesIndex = 0,
                PointIndex = 70,
                Attachment = AnnotationAttachment.DataIndex,
                Position = AnnotationPosition.Top,
            });
            annotationLayer.Annotations.Add(new Annotation.Text(Strings.AlibabaContent)
            {
                Style = new ChartStyle()
                {
                    Stroke = TextBrush,
                    FontFamily = new FontFamily("GenericSansSerif"),
                    FontSize = 12
                },
                SeriesIndex = 0,
                PointIndex = 70,
                Attachment = AnnotationAttachment.DataIndex,
                Position = AnnotationPosition.Left,
            });
            annotationLayer.Annotations.Add(new Annotation.Image("ms-appx:///AnnotationExplorerLib/Assets/arrowDOWN.png")
            {
                SeriesIndex = 0,
                PointIndex = 30,
                Attachment = AnnotationAttachment.DataIndex,
                TooltipText = Strings.ArrowTooltip
            });
            annotationLayer.Annotations.Add(new Annotation.Image("ms-appx:///AnnotationExplorerLib/Assets/arrowUP.png")
            {
                SeriesIndex = 0,
                PointIndex = 50,
                Attachment = AnnotationAttachment.DataIndex,
                TooltipText = Strings.ArrowTooltip
            });
            if (Util.IsWindowsDevice)
            {
                infoAnnotation = new Annotation.Rectangle("", 120, 100)
                {
                    Style = new ChartStyle()
                    {
                        Fill = new SolidColorBrush(Colors.SandyBrown) { Opacity = 200.0 / 255 },
                        Stroke = new SolidColorBrush(Colors.Chocolate),
                    },
                    ContentStyle = new ChartStyle()
                    {
                        FontFamily = new FontFamily("GenericSansSerif"),
                        FontSize = 10,
                        FontWeight = FontWeights.Bold,
                        Stroke = new SolidColorBrush(Colors.Brown),
                    },
                    Location = new Point(100, 60),
                    Attachment = AnnotationAttachment.Absolute,
                };
            }
            else
            {
                infoAnnotation = new Annotation.Rectangle("", 120, 100)
                {
                    Style = new ChartStyle()
                    {
                        Fill = new SolidColorBrush(Colors.SandyBrown) { Opacity = 200.0 / 255 },
                        Stroke = new SolidColorBrush(Colors.Chocolate),
                    },
                    ContentStyle = new ChartStyle()
                    {
                        FontFamily = new FontFamily("GenericSansSerif"),
                        FontSize = 12,
                        FontWeight = FontWeights.Bold,
                        Stroke = new SolidColorBrush(Colors.Brown),
                    },
                    Location = new Point(130, 60),
                    Attachment = AnnotationAttachment.Absolute,
                };
            }
        }

        private void flexChart_Rendered(object sender, RenderEventArgs e)
        {
            if (flexChart.AxisX.Scrollbar == null)
            {
                flexChart.AxisX.Scrollbar = new C1AxisScrollbar() { Height = 20, FontSize = 6 };
            }
        }

        private void flexChart_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var pos = e.GetCurrentPoint(flexChart).Position;
            var dataList = _model.FinancialData;
            if (infoAnnotation!=null && flexChart.PlotRect.Contains(pos))
            {
                var ht = flexChart.HitTest(pos, false);
                var low = dataList[ht.PointIndex].Low;
                var hight = dataList[ht.PointIndex].Hight;
                var open = dataList[ht.PointIndex].Open;
                var close = dataList[ht.PointIndex].Close;
                var volume = dataList[ht.PointIndex].Volume;
                infoAnnotation.Content = string.Format(Strings.InfoTooltip, low, hight, open, close, volume);
                if (!annotationLayer.Annotations.Contains(infoAnnotation))
                {
                    annotationLayer.Annotations.Add(infoAnnotation);
                }
                flexChart.Invalidate();
            }
        }
    }
}
