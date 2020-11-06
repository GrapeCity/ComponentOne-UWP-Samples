using C1.Chart.Finance;
using C1.Xaml.Chart;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StockAnalysis.Partial.UserControls
{
    public sealed partial class KRChart : UserControl
    {
        public KRChart()
        {
            this.InitializeComponent();
           
            InitAnnotition(financialChart);

            this.financialChart.RightTapped += (o, e) =>
            {
                _flyoutBasePossition = e.GetPosition(financialChart);
            };


            ViewModel.ViewModel.Instance.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "ChartType")
                {
                    if (ViewModel.ViewModel.Instance.ChartType == FinancialChartType.Kagi ||
                               ViewModel.ViewModel.Instance.ChartType == FinancialChartType.Renko ||
                               ViewModel.ViewModel.Instance.ChartType == FinancialChartType.PointAndFigure)
                    {
                        this.financialChart.ChartType = ViewModel.ViewModel.Instance.ChartType;

                        if (this.financialChart.ChartType == FinancialChartType.PointAndFigure)
                        {
                            financialSeries.Style = new ChartStyle();
                            financialSeries.AltStyle = new ChartStyle();
                            financialSeries.Style.Stroke = new SolidColorBrush(Colors.Black);
                            financialSeries.AltStyle.Stroke = new SolidColorBrush(Colors.Red);

                        }
                        else
                        {
                            financialSeries.Style.Stroke = new SolidColorBrush(Color.FromArgb(255, 51, 103, 214));
                            financialSeries.Style.Fill = new SolidColorBrush(Color.FromArgb(128, 66, 133, 244));
                        }


                        IEnumerable<Data.SettingParam> settings;
                        if (settingsCache.TryGetValue(financialChart.ChartType, out settings))
                        {
                            var reversalSetting = (from p in settings where p.Key == "Reversal" select p).FirstOrDefault();
                            if (reversalSetting != null)
                            {
                                var value = System.Convert.ToInt32(reversalSetting.Value);
                                this.financialChart.Options.ReversalAmount = value > 1 ? value : 1;
                            }
                        }
                    }

                }
                else if (e.PropertyName == "ChartTypeCategory")
                {
                    if (AL != null)
                    {
                        AL.Annotations.Clear();
                    }
                }
                else if (e.PropertyName == "CurrectQuote")
                {
                    if (AL != null)
                    {
                        AL.Annotations.Clear();
                    }
                }
            };
            InitAndBindingData(FinancialChartType.Kagi);
            InitAndBindingData(FinancialChartType.Renko);
            InitAndBindingPointAndFigureData(FinancialChartType.PointAndFigure);
        }

        private Point _flyoutBasePossition;
                
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AL.ShowContentEditor(_flyoutBasePossition);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            AL.Annotations.Remove(AL.SelectedAnnotation);
        }
        Dictionary<FinancialChartType, IEnumerable<Data.SettingParam>> settingsCache = new Dictionary<FinancialChartType, IEnumerable<Data.SettingParam>>();

        private void InitAndBindingData(FinancialChartType type)
        {
            IEnumerable<Data.SettingParam> settings;
            if (ViewModel.ViewModel.Instance.Settings.TryGetValue(Enum.GetName(typeof(FinancialChartType), type), out settings))
            {
                var reversalSetting = (from p in settings where p.Key == "ReversalAmount" select p).FirstOrDefault();
                if (reversalSetting != null)
                {
                    var value = System.Convert.ToDouble(reversalSetting.Value);
                    this.financialChart.Options.ReversalAmount = value > 1 ? value : 1;
                    this.financialChart.Options.BoxSize = value > 1 ? value : 1;
                    reversalSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = System.Convert.ToDouble(reversalSetting.Value);
                            if (value > 0)
                            {
                                this.financialChart.Options.ReversalAmount = value;
                                this.financialChart.Options.BoxSize = value;
                            }
                        }
                    };
                }
                var rangeModeSetting = (from p in settings where p.Key == "RangeMode" select p).FirstOrDefault();
                if (rangeModeSetting != null)
                {
                    var value = (RangeMode)rangeModeSetting.Value;
                    this.financialChart.Options.RangeMode = value;
                    rangeModeSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = (RangeMode)rangeModeSetting.Value;
                            this.financialChart.Options.RangeMode = value;

                            if (value == RangeMode.Percentage)
                            {
                                this.financialChart.Options.ReversalAmount = 0.05;

                                reversalSetting.Type = typeof(double);
                                reversalSetting.Value = 0.05;
                                reversalSetting.Minimum = 0;
                            }
                            else
                            {
                                this.financialChart.Options.ReversalAmount = 2;

                                reversalSetting.Type = typeof(uint);
                                reversalSetting.Value = 2;
                                reversalSetting.Minimum = 1;
                            }
                        }
                    };
                }
                var dataFieldsSetting = (from p in settings where p.Key == "DataFields" select p).FirstOrDefault();
                if (dataFieldsSetting != null)
                {
                    var value = (DataFields)dataFieldsSetting.Value;
                    this.financialChart.Options.DataFields = value;
                    dataFieldsSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = (DataFields)dataFieldsSetting.Value;
                            this.financialChart.Options.DataFields = value;
                        }
                    };
                }
                settingsCache.Add(type, settings);
            }
        }

        private void InitAndBindingPointAndFigureData(FinancialChartType type)
        {
            IEnumerable<Data.SettingParam> settings;
            if (ViewModel.ViewModel.Instance.Settings.TryGetValue(Enum.GetName(typeof(FinancialChartType), type), out settings))
            {
                var reversalSetting = (from p in settings where p.Key == "ReversalAmount" select p).FirstOrDefault();
                if (reversalSetting != null)
                {
                    var value = System.Convert.ToDouble(reversalSetting.Value);
                    this.financialChart.Options.ReversalAmount = value > 1 ? value : 1;
                    reversalSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = System.Convert.ToDouble(reversalSetting.Value);
                            if (value > 0)
                            {
                                this.financialChart.Options.ReversalAmount = value;
                            }
                        }
                    };
                }
                var dataFieldsSetting = (from p in settings where p.Key == "DataFields" select p).FirstOrDefault();
                if (dataFieldsSetting != null)
                {
                    var value = (DataFields)dataFieldsSetting.Value;
                    this.financialChart.Options.DataFields = value;
                    dataFieldsSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = (DataFields)dataFieldsSetting.Value;
                            this.financialChart.Options.DataFields = value;
                        }
                    };
                }

                var scalingSetting = (from p in settings where p.Key == "Scaling" select p).FirstOrDefault();
                if (scalingSetting != null)
                {
                    var value = (C1.Chart.Finance.PointAndFigureScaling)scalingSetting.Value;
                    (this.financialChart.Options as C1.Xaml.Chart.Finance.PointAndFigureOptions).Scaling = value;
                    scalingSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = (C1.Chart.Finance.PointAndFigureScaling)scalingSetting.Value;
                            (this.financialChart.Options as C1.Xaml.Chart.Finance.PointAndFigureOptions).Scaling = value;
                        }
                    };
                }
                var boxSizeSetting = (from p in settings where p.Key == "BoxSize" select p).FirstOrDefault();
                if (boxSizeSetting != null)
                {
                    var value = System.Convert.ToDouble(boxSizeSetting.Value);
                    this.financialChart.Options.BoxSize = value > 1 ? value : 1;
                    boxSizeSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = System.Convert.ToDouble(boxSizeSetting.Value);
                            if (value > 0)
                            {
                                this.financialChart.Options.BoxSize = value;
                            }
                        }
                    };
                }
                var periodSetting = (from p in settings where p.Key == "Period" select p).FirstOrDefault();
                if (periodSetting != null)
                {
                    var value = System.Convert.ToInt32(periodSetting.Value);
                    (this.financialChart.Options as C1.Xaml.Chart.Finance.PointAndFigureOptions).Period = value;
                    periodSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = System.Convert.ToInt32(periodSetting.Value);
                            if (value > 0)
                            {
                                (this.financialChart.Options as C1.Xaml.Chart.Finance.PointAndFigureOptions).Period = value;
                            }
                        }
                    };
                }


                var squareGridSetting = (from p in settings where p.Key == "SquareGrid" select p).FirstOrDefault();
                if (squareGridSetting != null)
                {
                    var value = System.Convert.ToBoolean(squareGridSetting.Value);
                    (this.financialChart.Options as C1.Xaml.Chart.Finance.PointAndFigureOptions).SquareGrid = value;
                    squareGridSetting.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == "Value" && financialChart.ChartType == type)
                        {
                            value = System.Convert.ToBoolean(squareGridSetting.Value);
                            (this.financialChart.Options as C1.Xaml.Chart.Finance.PointAndFigureOptions).SquareGrid = value;
                        }
                    };
                }


                settingsCache.Add(type, settings);
            }
        }


        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }


        EditableAnnotitions.EditableAnnotationLayer _al;

        public EditableAnnotitions.EditableAnnotationLayer AL
        {
            get
            {
                if (_al == null)
                {
                    _al = new EditableAnnotitions.EditableAnnotationLayer(financialChart);
                }
                return _al;
            }
        }

        private void InitAnnotition(C1.Xaml.Chart.C1FlexChart chart)
        {
            #region Annotations Setup

            AL.PolygonAddFunc = (pt) =>
            {
                return new C1.Xaml.Chart.Annotation.Polygon("Polygon")
                {
                    Points =
                    {
                        pt,pt,pt
                    }
                };
            };

            chart.Layers.Add(AL);

            AL.PolygonReSizeFunc = (poly, rectangle) =>
            {
                var top = new Point((float)(rectangle.Left + rectangle.Width / 2), rectangle.Y);
                var left = new Point(rectangle.Left, rectangle.Bottom);
                var right = new Point(rectangle.Right, rectangle.Bottom);
                poly.Points[0] = EditableAnnotitions.Helpers.CoordsToAnnoPoint(chart, poly, top);
                poly.Points[1] = EditableAnnotitions.Helpers.CoordsToAnnoPoint(chart, poly, left);
                poly.Points[2] = EditableAnnotitions.Helpers.CoordsToAnnoPoint(chart, poly, right);
            };

            AL.ContentEditor = new EditableAnnotitions.AnnotationEditor();
            #endregion

            AL.Attachment = C1.Chart.Annotation.AnnotationAttachment.DataCoordinate;

            ViewModel.ViewModel.Instance.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "NewAnnotationType")
                {
                    if (ViewModel.ViewModel.Instance.NewAnnotationType == Data.NewAnnotationType.None)
                    {
                        AL.AllowAdd = false;
                    }
                    else
                    {
                        AL.AllowAdd = true;
                        switch (ViewModel.ViewModel.Instance.NewAnnotationType)
                        {
                            case Data.NewAnnotationType.Circle:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Circle);
                                break;
                            case Data.NewAnnotationType.Ellipse:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Ellipse);
                                break;
                            case Data.NewAnnotationType.Line:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Line);
                                break;
                            case Data.NewAnnotationType.Polygon:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Polygon);
                                break;
                            case Data.NewAnnotationType.Rectangle:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Rectangle);
                                break;
                            case Data.NewAnnotationType.Square:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Square);
                                break;
                            case Data.NewAnnotationType.Text:
                                AL.NewAnnotationType = typeof(C1.Xaml.Chart.Annotation.Text);
                                break;
                            case Data.NewAnnotationType.None:
                            default:
                                AL.AllowAdd = false;
                                break;
                        }
                    }
                }
            };
        }
    }
}
