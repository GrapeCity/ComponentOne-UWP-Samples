using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ControlExplorer.Common;

namespace ControlExplorer
{
    public class FeatureDescription : BindableBase, ISearchable
    {
        private string _name;
        private string _description;
        private bool _isExpanded;
        private bool _isNew;
        private Uri _packageUri;
        private string _assemblyName;
        private Page _sample;

        // constructor
        public FeatureDescription(ControlDescription control, XElement f)
        {
            Control = control;
            Description = (f.Element("Description") != null) ? f.Element("Description").Value : string.Empty;
            Name = (f.Attribute("name") != null) ? f.Attribute("name").Value : string.Empty;
            IconName = (f.Attribute("iconName") != null) ? f.Attribute("iconName").Value : string.Empty;
            AssemblyName = (f.Attribute("assemblyName") != null) ? PlatformUtils.AdjustPlatformName(f.Attribute("assemblyName").Value, false) : string.Empty;
            PackageUri = (f.Attribute("packageUri") != null) ? new Uri(PlatformUtils.AdjustPlatformName(f.Attribute("packageUri").Value, true), UriKind.RelativeOrAbsolute) : null;
            DemoControlTypeName = (f.Attribute("type") != null) ? f.Attribute("type").Value : string.Empty;
            Source = (f.Attribute("source") != null) ? f.Attribute("source").Value : string.Empty;
            Event = (f.Element("Event") != null ? f.Element("Event").Value : "");
            Link = new Uri((control.Name + "/" + Name).Trim().Replace("?", "").Replace("'", "").Replace("(", "").Replace(")", ""), UriKind.Relative);
            SupportThemes = (f.Attribute("supportThemes") != null ? bool.Parse(f.Attribute("supportThemes").Value) : true);
            IsExpanded = (f.Attribute("isExpanded") != null) ? bool.Parse(f.Attribute("isExpanded").Value) : false;
            IsNew = (f.Attribute("isNew") != null) ? bool.Parse(f.Attribute("isNew").Value) : false;
            if (f.Element("SubFeatures") != null)
            {
                SubFeatures = (from sf in f.Element("SubFeatures").Elements("SubFeature") select new FeatureDescription(control, sf)).ToList();
                foreach (FeatureDescription sub in SubFeatures)
                {
                    sub.OwnerFeature = this;
                }
            }
            else
            {
                SubFeatures = new List<FeatureDescription>();
            }
            if (f.Element("Properties") != null)
            {
                var properties = from pair in f.Element("Properties").Elements("Property")
                                 select new PropertyAttribute
                                 {
                                     MemberName = pair.Attribute("name").Value,
                                     DisplayName = (pair.Attribute("caption") != null ? pair.Attribute("caption").Value : pair.Attribute("name").Value),
                                     DefaultValue = (pair.Attribute("value") != null ? pair.Attribute("value").Value : null),
                                     Browsable = (pair.Attribute("display") != null ? bool.Parse(pair.Attribute("display").Value) : true),
                                     MinimumValue = (pair.Attribute("minimumValue") != null ? double.Parse(pair.Attribute("minimumValue").Value, CultureInfo.InvariantCulture) : double.NaN),
                                     MaximumValue = (pair.Attribute("maximumValue") != null ? double.Parse(pair.Attribute("maximumValue").Value, CultureInfo.InvariantCulture) : double.NaN),
                                     Tag = (pair.Attribute("nullable") != null ? bool.Parse(pair.Attribute("nullable").Value) : false),
                                 };
                Properties = new List<PropertyAttribute>(properties);
            }
        }

        public FeatureDescription(string p1, string p2, string p3, string p4, string p5, string ITEM_CONTENT, ControlDescription group1)
        {
            Name = p1;
            Description = p3;
        }

        public int ID { get; set; }

        // general information
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string IconName
        {
            get; set;
        }

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_description))
                {
                    if (OwnerFeature != null)
                    {
                        return OwnerFeature.Description;
                    }
                    if (Control != null)
                    {
                        return Control.Description;
                    }
                }
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public Uri Link { get; set; }

        public string Source { get; set; }
        public FrameworkElement Sample
        {
            get
            {
                // create sample every time. In other case sample is not shown after navigating from it and returning back
                //     if (_sample == null)
                {
                    #region create sample
                    switch (DemoControlTypeName)
                    {
                        #region barcode
                        case "BarCodeSamples.DemoBarCode":
                            _sample = new BarCodeSamples.DemoBarCode();
                            break;
                        case "BarCodeSamples.NewBarcodes":
                            _sample = new BarCodeSamples.NewBarcodes();
                            break;
                        #endregion

                        #region book
                        case "ExtendedSamples.C1BookDemo":
                            _sample = new ExtendedSamples.C1BookDemo();
                            break;
                        case "ExtendedSamples.C1BookPageSpan":
                            _sample = new ExtendedSamples.C1BookPageSpan();
                            break;
                        #endregion

                        #region colorPicker
                        case "ExtendedSamples.C1ColorPickerDemo":
                            _sample = new ExtendedSamples.C1ColorPickerDemo();
                            break;
                        #endregion

                        #region calendar
                        case "CalendarSample.DefaultView":
                            _sample = new CalendarSamples.DefaultView();
                            break;
                        case "CalendarSample.BoldedDayTemplate":
                            _sample = new CalendarSamples.BoldedDayTemplate();
                            break;
                        case "CalendarSample.DaySlotTemplateSelector":
                            _sample = new CalendarSamples.DaySlotTemplateSelector();
                            break;
                        case "CalendarSample.CustomData":
                            _sample = new CalendarSamples.CustomData();
                            break;
                        #endregion

                        #region scheduler
                        case "ScheduleSamples.Samples.DefaultView":
                            _sample = new ScheduleSamples.DefaultView();
                            break;
                        case "ScheduleSamples.Samples.BusinessObjectsBinding":
                            _sample = new ScheduleSamples.BusinessObjectsBinding();
                            break;
                        #endregion

                        #region tile
                        case "TileSamples.Samples.C1TileListBoxSample":
                            _sample = new TileSamples.C1TileListBoxSample();
                            break;
                        case "TileSamples.Samples.GridViewSample":
                            _sample = new TileSamples.GridViewSample();
                            break;
                        case "TileSamples.Samples.ListBoxSample":
                            _sample = new TileSamples.ListBoxSample();
                            break;
                        case "TileSamples.Samples.ContentSourceSample":
                            _sample = new TileSamples.ContentSourceSample();
                            break;
                        #endregion

                        #region gauges
                        case "GaugeSamples.RadialGauge":
                            _sample = new GaugeSamples.RadialGauge();
                            break;
                        case "GaugeSamples.SpeedometerGauge":
                            _sample = new GaugeSamples.SpeedometerGauge();
                            break;
                        case "GaugeSamples.VolumeGauge":
                            _sample = new GaugeSamples.VolumeGauge();
                            break;
                        case "GaugeSamples.LinearGauge":
                            _sample = new GaugeSamples.LinearGauge();
                            break;
                        case "GaugeSamples.RulerGauge":
                            _sample = new GaugeSamples.RulerGauge();
                            break;
                        case "GaugeSamples.Rule":
                            _sample = new GaugeSamples.Rule();
                            break;
                        case "GaugeSamples.Clock":
                            _sample = new GaugeSamples.Clock();
                            break;
                        case "GaugeSamples.Automobile":
                            _sample = new GaugeSamples.Automobile();
                            break;
                        case "GaugeSamples.Thermometer":
                            _sample = new GaugeSamples.Thermometer();
                            break;
                        case "GaugeSamples.Knob":
                            _sample = new GaugeSamples.Knob();
                            break;
                        case "GaugeSamples.RegionKnob":
                            _sample = new GaugeSamples.RegionKnob();
                            break;
                        #endregion
                       
                        #region dropdown
                        case "BasicLibrarySamples.View.DropDownDemo":
                            _sample = new BasicLibrarySamples.DropDownDemo();
                            break;
                        case "BasicLibrarySamples.View.AutoCompleteDropDown":
                            _sample = new BasicLibrarySamples.AutoCompleteDropDown();
                            break;
                        case "BasicLibrarySamples.View.HierarchicalDropDown":
                            _sample = new BasicLibrarySamples.HierarchicalDropDown();
                            break;
                        #endregion

                        #region input editors
                        case "C1.Xaml.DateTimeEditors.C1DatePicker":
                            _sample = new Page()
                            {
                                Content = new C1.Xaml.DateTimeEditors.C1DatePicker()
                                {
                                    VerticalAlignment = VerticalAlignment.Top,
                                    HorizontalAlignment = HorizontalAlignment.Left,
                                    Width = 200,
                                    AllowNull = true,
                                    Margin = new Thickness(20, 50, 0, 0),
                                }
                            };
                            break;
                        case "C1.Xaml.DateTimeEditors.C1TimeEditor":
                            _sample = new Page()
                            {
                                Content = new C1.Xaml.DateTimeEditors.C1TimeEditor()
                                {
                                    VerticalAlignment = VerticalAlignment.Top,
                                    HorizontalAlignment = HorizontalAlignment.Left,
                                    AllowNull = true,
                                    Value = null,
                                    MinWidth = 250,
                                    Margin = new Thickness(20, 50, 0, 0),
                                }
                            };
                            break;
                        case "C1.Xaml.DateTimeEditors.C1DateTimePicker":
                            _sample = new Page()
                            {
                                Content = new C1.Xaml.DateTimeEditors.C1DateTimePicker()
                                {
                                    VerticalAlignment = VerticalAlignment.Top,
                                    HorizontalAlignment = HorizontalAlignment.Left,
                                    MinDatePickerWidth = 138,
                                    Padding = new Thickness(3),
                                    CustomTimeFormat = "HH:mm:ss",
                                    AllowNull = true,
                                    Margin = new Thickness(0, 50, 0, 0),
                                }
                            };
                            break;
                        case "C1.Xaml.C1DateSelector":
                            _sample = new Page()
                            {
                                Content = new C1.Xaml.C1DateSelector()
                                {
                                    // don't set horizontal alignment and width, as control will adjust itself according to available space
                                    VerticalAlignment = VerticalAlignment.Top,
                                    Margin = new Thickness(20, 50, 0, 0),
                                    MaxWidth = 450
                                }
                            };
                            break;
                        case "C1.Xaml.C1TimeSelector":
                            _sample = new Page()
                            {
                                Content = new C1.Xaml.C1TimeSelector()
                                {
                                    // don't set horizontal alignment and width, as control will adjust itself according to available space
                                    VerticalAlignment = VerticalAlignment.Top,
                                    Margin = new Thickness(20, 50, 0, 0),
                                    MaxWidth = 450
                                }
                            };
                            break;
                        case "C1.Xaml.C1DateTimeSelector":
                            _sample = new Page()
                            {
                                Content = new C1.Xaml.C1DateTimeSelector()
                                {
                                    // don't set horizontal alignment and width, as control will adjust itself according to available space
                                    VerticalAlignment = VerticalAlignment.Top,
                                    Margin = new Thickness(20, 50, 0, 0),
                                }
                            };
                            break;
                        case "NumericBoxSamples.MainPage":
                            _sample = new BasicLibrarySamples.NumericBoxSample()
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center
                            };
                            break;
                        case "MaskedTextBoxSamples.MainPage":
                            _sample = new BasicLibrarySamples.MaskedTextBoxSample()
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center
                            };
                            break;
                        case "RangeSlider":
                            _sample = new BasicLibrarySamples.RangeSlider();
                            break;
                        case "InputSamples.MultiSelect":
                            _sample = new InputSamples.MultiSelect();
                            break;
                        case "InputSamples.CheckList":
                            _sample = new InputSamples.CheckList();
                            break;
                        case "InputSamples.TagEditor":
                            _sample = new InputSamples.TagEditor();
                            break;
                        #endregion

                        #region inputpanel
                        case "InputPanelSamples.BindToInputPanel":
                            _sample = new InputPanelSamples.BindToInputPanel();
                            break;
                        case "InputPanelSamples.CustomTemplate":
                            _sample = new InputPanelSamples.CustomTemplate();
                            break;
                        case "InputPanelSamples.IntegrationC1FlexGrid":
                            _sample = new InputPanelSamples.IntegrationC1FlexGrid();
                            break;
                        #endregion

                        #region expressioneditor
                        case "ExpressionEditorSamples.ColumnCalculation":
                            _sample = new ExpressionEditorSamples.ColumnCalculation();
                            break;
                        case "ExpressionEditorSamples.SupportFilter":
                            _sample = new ExpressionEditorSamples.SupportFilter();
                            break;
                        case "ExpressionEditorSamples.SupportGrouping":
                            _sample = new ExpressionEditorSamples.SupportGrouping();
                            break;
                        #endregion

                        #region layout
                        case "WrapPanelSample":
                            _sample = new BasicLibrarySamples.WrapPanelSample();
                            break;
                        case "DockPanelSample":
                            _sample = new BasicLibrarySamples.DockPanelSample();
                            break;
                        case "UniformGridSample":
                            _sample = new BasicLibrarySamples.UniformGridSample();
                            break;
                        case "RadialPanelSample":
                            _sample = new BasicLibrarySamples.RadialPanelSample();
                            break;
                        case "GridSplitterSample":
                            _sample = new BasicLibrarySamples.GridSplitterSample();
                            break;
                        #endregion

                        #region listbox
                        //case "TileListBoxSample":
                        //    _sample = new BasicLibrarySamples.TileListBoxSample();
                        //    break;
                        case "ListBoxSample":
                            _sample = new BasicLibrarySamples.ListBoxSample();
                            break;
                        #endregion

                        #region flexreport
                        case "FlexReportSamples.ViewerPage":
                            _sample = new FlexReportSamples.ViewerPage();
                            break;
                        case "FlexReportSamples.ViewerPanePage":
                            _sample = new FlexReportSamples.ViewerPanePage();
                            break;
                        case "FlexReportSamples.ExportPage":
                            _sample = new FlexReportSamples.ExportPage();
                            ((FlexReportSamples.ExportPage)_sample).FilePickerVisible = false;
                            break;
                        case "FlexReportSamples.PrintPage":
                            _sample = new FlexReportSamples.PrintPage();
                            break;
                        #endregion

                        #region pdfdocumentsource
                        case "PdfDocumentSourceSamples.PdfViewPage":
                            _sample = new PdfDocumentSourceSamples.PdfViewPage();
                            break;
                        case "PdfDocumentSourceSamples.ExportPage":
                            _sample = new PdfDocumentSourceSamples.ExportPage();
                            break;
                        case "PdfDocumentSourceSamples.PrintPage":
                            _sample = new PdfDocumentSourceSamples.PrintPage();
                            break;
                        #endregion

                        #region financial chart
                        case "FinancialChartExplorer.HeikinAshi":
                            _sample = new FinancialChartExplorer.HeikinAshi();
                            break;
                        case "FinancialChartExplorer.LineBreak":
                            _sample = new FinancialChartExplorer.LineBreak();
                            break;
                        case "FinancialChartExplorer.Renko":
                            _sample = new FinancialChartExplorer.Renko();
                            break;
                        case "FinancialChartExplorer.Kagi":
                            _sample = new FinancialChartExplorer.Kagi();
                            break;
                        case "FinancialChartExplorer.ColumnVolume":
                            _sample = new FinancialChartExplorer.ColumnVolume();
                            break;
                        case "FinancialChartExplorer.EquiVolume":
                            _sample = new FinancialChartExplorer.EquiVolume();
                            break;
                        case "FinancialChartExplorer.CandleVolume":
                            _sample = new FinancialChartExplorer.CandleVolume();
                            break;
                        case "FinancialChartExplorer.ArmsCandleVolume":
                            _sample = new FinancialChartExplorer.ArmsCandleVolume();
                            break;
                        case "FinancialChartExplorer.RangeSelector":
                            _sample = new FinancialChartExplorer.RangeSelector();
                            break;
                        case "FinancialChartExplorer.TrendLines":
                            _sample = new FinancialChartExplorer.TrendLines();
                            break;
                        case "FinancialChartExplorer.MovingAverages":
                            _sample = new FinancialChartExplorer.MovingAverages();
                            break;
                        case "FinancialChartExplorer.Indicators":
                            _sample = new FinancialChartExplorer.Indicators();
                            break;
                        case "FinancialChartExplorer.Markers":
                            _sample = new FinancialChartExplorer.Markers();
                            break;
                        case "FinancialChartExplorer.Overlays":
                            _sample = new FinancialChartExplorer.Overlays();
                            break;
                        case "FinancialChartExplorer.EventAnnotations":
                            _sample = new FinancialChartExplorer.EventAnnotations();
                            break;
                        case "FinancialChartExplorer.FibonacciTool":
                            _sample = new FinancialChartExplorer.FibonacciTool();
                            break;
                        #endregion

                        #region flexchart
                        case "FlexChartExplorer.Introduction":
                            _sample = new FlexChartExplorer.Introduction();
                            break;
                        case "FlexChartExplorer.Binding":
                            _sample = new FlexChartExplorer.Binding();
                            break;
                        case "FlexChartExplorer.SeriesBinding":
                            _sample = new FlexChartExplorer.SeriesBinding();
                            break;
                        case "FlexChartExplorer.HeaderAndFooter":
                            _sample = new FlexChartExplorer.HeaderAndFooter();
                            break;
                        case "FlexChartExplorer.Selection":
                            _sample = new FlexChartExplorer.Selection();
                            break;
                        case "FlexChartExplorer.Labels":
                            _sample = new FlexChartExplorer.Labels();
                            break;
                        case "FlexChartExplorer.HitTest":
                            _sample = new FlexChartExplorer.HitTest();
                            break;
                        case "FlexChartExplorer.Zoom":
                            _sample = new FlexChartExplorer.Zoom();
                            break;
                        case "FlexChartExplorer.Bubble":
                            _sample = new FlexChartExplorer.Bubble();
                            break;
                        case "FlexChartExplorer.Financial":
                            _sample = new FlexChartExplorer.Financial();
                            break;
                        case "FlexChartExplorer.Axes":
                            _sample = new FlexChartExplorer.Axes();
                            break;
                        case "FlexChartExplorer.PlotAreas":
                            _sample = new FlexChartExplorer.PlotAreas();
                            break;
                        case "FlexChartExplorer.AxisBinding":
                            _sample = new FlexChartExplorer.AxisBinding();
                            break;
                        case "FlexChartExplorer.ImageExport":
                            _sample = new FlexChartExplorer.ImageExport();
                            break;
                        case "FlexChartExplorer.Zones":
                            _sample = new FlexChartExplorer.Zones();
                            break;
                        case "FlexChartExplorer.TrendLine":
                            _sample = new FlexChartExplorer.TrendLine();
                            break;
                        case "FlexChartExplorer.Waterfall":
                            _sample = new FlexChartExplorer.Waterfall();
                            break;
                        case "FlexChartExplorer.BoxWhisker":
                            _sample = new FlexChartExplorer.BoxWhisker();
                            break;
                        case "FlexChartExplorer.ErrorBar":
                            _sample = new FlexChartExplorer.ErrorBar();
                            break;
                        case "FlexChartExplorer.PieIntroduction":
                            _sample = new FlexChartExplorer.PieIntroduction();
                            break;
                        case "FlexChartExplorer.PieSelection":
                            _sample = new FlexChartExplorer.PieSelection();
                            break;
                        case "FlexChartExplorer.MultiPie":
                            _sample = new FlexChartExplorer.MultiPie();
                            break;
                        case "SunburstIntro.GettingStarted":
                            _sample = new SunburstIntro.GettingStarted();
                            break;
                        case "SunburstIntro.BasicFeatures":
                            _sample = new SunburstIntro.BasicFeatures();
                            break;
                        case "SunburstIntro.LegendTitles":
                            _sample = new SunburstIntro.LegendTitles();
                            break;
                        case "SunburstIntro.Selection":
                            _sample = new SunburstIntro.Selection();
                            break;
                        case "FlexRadarIntro.RadarChart":
                            _sample = new FlexRadarIntro.RadarChart();
                            break;
                        case "FlexRadarIntro.PolarChart":
                            _sample = new FlexRadarIntro.PolarChart();
                            break;
                        case "FlexChartExplorer.TreeMap":
                            _sample = new FlexChartExplorer.TreeMap();
                            break;

                        case "AnimationDemo.View.FlexPieAnimation":
                            _sample = new AnimationDemo.View.FlexPieAnimation();
                            break;
                        case "AnimationDemo.View.FlexChartAnimation":
                            _sample = new AnimationDemo.View.FlexChartAnimation();
                            break;
                        case "AnimationDemo.View.CustomAnimation":
                            _sample = new AnimationDemo.View.CustomAnimation();
                            break;

                        #endregion

                        #region flexgrid
                        case "FlexGridSamples.MediaLibrary":
                            _sample = new FlexGridSamples.MediaLibrary();
                            break;
                        case "FlexGridSamples.Financial":
                            _sample = new FlexGridSamples.Financial();
                            break;
                        case "FlexGridSamples.FlexGridDemo":
                            _sample = new FlexGridSamples.FlexGridDemo();
                            break;
                        case "FlexGridSamples.CollectionView":
                            _sample = new FlexGridSamples.CollectionView();
                            break;
                        case "FlexGridSamples.FullTextFilter":
                            _sample = new FlexGridSamples.FullTextFilter();
                            break;
                        case "FlexGridSamples.Unbound":
                            _sample = new FlexGridSamples.Unbound();
                            break;
                        //case "FlexGridSamples.YouTube":
                        //    _sample = new FlexGridSamples.YouTube();
                        //    break;
                        case "FlexGridSamples.Editing":
                            _sample = new FlexGridSamples.Editing();
                            break;
                        case "FlexGridSamples.ExcelStyleMerge":
                            _sample = new FlexGridSamples.ExcelStyleMerge();
                            break;
                        case "FlexGridSamples.Printing":
                            _sample = new FlexGridSamples.Printing();
                            break;
                        #endregion

                        #region pdf
                        case "PdfSamples.BasicTextPage":
                            _sample = new PdfSamples.BasicTextPage();
                            break;
                        case "PdfSamples.ImagesPage":
                            _sample = new PdfSamples.ImagesPage();
                            break;
                        case "PdfSamples.QuotesPage":
                            _sample = new PdfSamples.QuotesPage();
                            break;
                        case "PdfSamples.GraphicsPage":
                            _sample = new PdfSamples.GraphicsPage();
                            break;
                        case "PdfSamples.TOCPage":
                            _sample = new PdfSamples.TOCPage();
                            break;
                        case "PdfSamples.TextFlowPage":
                            _sample = new PdfSamples.TextFlowPage();
                            break;
                        case "PdfSamples.PaperSizesPage":
                            _sample = new PdfSamples.PaperSizesPage();
                            break;
                        case "PdfSamples.RenderUIPage":
                            _sample = new PdfSamples.RenderUIPage();
                            break;
                        #endregion

                        #region pdfviewer
                        case "PdfViewerSamples.PdfViewerDemoPage":
                            _sample = new PdfViewerSamples.PdfViewerDemoPage();
                            break;
                        case "PdfViewerSamples.LargeFile":
                            _sample = new PdfViewerSamples.LargeFile();
                            break;
                        case "PdfViewerSamples.Printing":
                            _sample = new PdfViewerSamples.Printing();
                            break;
                        #endregion

                        #region treeview
                        case "TreeViewSample":
                            _sample = new BasicLibrarySamples.TreeViewSample();
                            break;
                        case "TreeViewSamples.Edit":
                            _sample = new BasicLibrarySamples.Edit();
                            break;
                        case "TreeViewSamples.CheckBox":
                            _sample = new BasicLibrarySamples.CheckBox();
                            break;
                        case "TreeViewSamples.DragDrop":
                            _sample = new BasicLibrarySamples.DragDrop();
                            break;
                        case "TreeViewSamples.HierarchicalTemplate":
                            _sample = new BasicLibrarySamples.HierarchicalTemplate();
                            break;
                        #endregion

                        #region tabcontrol
                        case "EntranceTab":
                            _sample = new BasicLibrarySamples.EntranceTab();
                            break;
                        case "TabControlSample":
                            _sample = new BasicLibrarySamples.TabControlSample();
                            break;
                        case "ClearStyleTabControl":
                            _sample = new BasicLibrarySamples.ClearStyleTabControl();
                            break;
                        #endregion

                        #region collectionview
                        case "BasicLibrarySamples.View.CollectionViewConditions":
                            _sample = new BasicLibrarySamples.CollectionViewConditions();
                            break;
                        case "BasicLibrarySamples.View.BindingToC1CollectionView":
                            _sample = new BasicLibrarySamples.BindingToC1CollectionView();
                            break;
                        #endregion

                        #region menu
                        case "MenuSample":
                            _sample = new BasicLibrarySamples.MenuSample();
                            break;
                        case "VerticalMenu":
                            _sample = new BasicLibrarySamples.VerticalMenu();
                            break;
                        case "ContextMenu":
                            _sample = new BasicLibrarySamples.ContextMenu();
                            break;
                        case "RadialMenu":
                            _sample = new BasicLibrarySamples.RadialMenu();
                            break;
                        #endregion

                        #region richtextbox
                        case "RichTextBoxSamples.DemoRichTextBox":
                            _sample = new RichTextBoxSamples.DemoRichTextBox();
                            break;
                        case "RichTextBoxSamples.SyntaxHighlight":
                            _sample = new RichTextBoxSamples.SyntaxHighlight();
                            break;
                        case "RichTextBoxSamples.RichTextBoxFormatting":
                            _sample = new RichTextBoxSamples.RichTextBoxFormatting();
                            break;
                        case "RichTextBoxSamples.AsYouTypeSpellCheck":
                            _sample = new RichTextBoxSamples.AsYouTypeSpellCheck();
                            break;
                        case "RichTextBoxSamples.Printing":
                            _sample = new RichTextBoxSamples.Printing();
                            break;
                        case "RichTextBoxSamples.AppBarDemo":
                            _sample = new RichTextBoxSamples.AppBarDemo();
                            break;
                        case "RichTextBoxSamples.DemoRtfFilter":
                            _sample = new RichTextBoxSamples.DemoRtfFilter();
                            break;
                        case "RichTextBoxSamples.MultiLanguageSpellCheck":
                            _sample = new RichTextBoxSamples.MultiLanguageSpellCheck();
                            break;
                        #endregion

                        #region image
                        case "ImageSamples.DemoGifImage":
                            _sample = new ImagingSamples.DemoGifImage();
                            break;
                        case "ImageSamples.Crop":
                            _sample = new ImagingSamples.Crop();
                            break;
                        case "ImageSamples.FaceWarp":
                            _sample = new ImagingSamples.FaceWarp();
                            break;
                        #endregion

                        #region bitmap
                        case "BitmapSamples.Crop":
                            _sample = new BitmapSamples.Crop();
                            break;
                        case "BitmapSamples.FaceWarp":
                            _sample = new BitmapSamples.FaceWarp();
                            break;
                        #endregion

                        #region maps
                        case "MapsSamples.DemoMaps":
                            _sample = new MapsSamples.DemoMaps();
                            break;
                        case "MapsSamples.CustomTileSource":
                            _sample = new MapsSamples.CustomTileSource();
                            break;
                        case "MapsSamples.Cities":
                            _sample = new MapsSamples.Cities();
                            break;
                        case "MapsSamples.EarthQuake":
                            _sample = new MapsSamples.EarthQuake();
                            break;
                        case "MapsSamples.Flicker":
                            _sample = new MapsSamples.Flicker();
                            break;
                        case "MapsSamples.Grid":
                            _sample = new MapsSamples.Grid();
                            break;
                        case "MapsSamples.MapChart":
                            _sample = new MapsSamples.MapChart();
                            break;
                        case "MapsSamples.Marks":
                            _sample = new MapsSamples.Marks();
                            break;
                        #endregion

                        #region orgchart
                        case "OrgChartSamples.TemplateSample":
                            _sample = new OrgChartSamples.TemplateSample();
                            break;
                        case "OrgChartSamples.HierarchicalSample":
                            _sample = new OrgChartSamples.HierarchicalSample();
                            break;
                        case "OrgChartSamples.MainSample":
                            _sample = new OrgChartSamples.MainSample();
                            break;
                        case "OrgChartSamples.CollapseExpand":
                            _sample = new OrgChartSamples.CollapseExpand();
                            break;
                        #endregion

                        #region sparkline
                        case "SparklineSamplesLib.MainSample":
                            _sample = new SparklineSamples.MainSample();
                            break;
                        case "SparklineSamplesLib.AppearanceSample":
                            _sample = new SparklineSamples.AppearanceSample();
                            break;
                        case "SparklineSamplesLib.RegionSales":
                            _sample = new SparklineSamples.RegionSales();
                            break;
                        case "SparklineSamplesLib.FlexGridIntegration":
                            _sample = new SparklineSamples.FlexGridIntegration();
                            break;
                        #endregion

                        #region tileview
                        case "TileViewVirtualization.MainPage":
                            _sample = new TileViewSamples.BlankPage();
                            break;
                        case "TileDashboard.MainPage":
                            _sample = new TileViewSamples.MainPage1();
                            break;
                        case "TileDashboard.MainPage2":
                            _sample = new TileViewSamples.MainPage2();
                            break;
                        #endregion

                        #region word
                        case "WordSamples.TextFlowPage":
                            _sample = new WordSamples.TextFlowPage();
                            break;
                        #endregion

                        #region excel
                        case "ExcelSamples.DemoPage":
                            _sample = new ExcelSamples.DemoPage();
                            break;
                        #endregion

                        #region zip
                        case "ZipSamples.DemoZip":
                            _sample = new ZipSamples.DemoZip();
                            break;
                        #endregion
                        default:
                            break;
                    }

                    #endregion
                }
                return _sample;
            }
        }

        public FeatureType Type
        {
            get
            {
                //if (Controls.Count > 0)
                //{
                //    return FeatureType.RelatedSamples;
                //}
                //else
                {
                    return FeatureType.Default;
                }
            }
        }

        public bool SupportThemes { get; private set; }
        public Visibility ThemeVisibility 
        {
            get
            {
                return SupportThemes ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool LocalhostOnly { get; set; }

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                SetProperty(ref _isExpanded, value, "IsExpanded");
            }
        }

        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            set
            {
                SetProperty(ref _isNew, value, "IsNew");
            }
        }

        // visual behavior
        public bool ShowAnimation { get; set; }

        // demo
        public string DemoControlTypeName { get; set; }
        public ControlDescription Control { get; set; }

        public string SolutionPath;
        public string XamlPath;

        public string FullDemoControlTypeName
        {
            get
            {
                if (string.IsNullOrEmpty(DemoControlTypeName))
                {
                    return PlatformUtils.StripPlatformSuffix(Control.AssemblyName, false) + ".C1" + Control.Name; ;
                }
                else
                {
                    return DemoControlTypeName;
                }
            }
        }

        #region assembly

        public Uri PackageUri
        {
            get
            {
                if (_packageUri != null)
                {
                    return _packageUri;
                }
                if (string.IsNullOrEmpty(DemoControlTypeName))
                {
                    return new Uri(Control.AssemblyName + ".zip", UriKind.RelativeOrAbsolute);
                }
                else
                {
                    return new Uri(AssemblyName + ".xap", UriKind.RelativeOrAbsolute);
                }
            }
            set
            {
                _packageUri = value;
            }
        }

        public string AssemblyName
        {
            get
            {
                return "";
            }
            set
            {
                _assemblyName = value;
            }
        }

        #endregion

        // default type properties
        public List<PropertyAttribute> Properties { get; set; }

        public Visibility PropertiesVisibility
        {
            get
            {
                return Properties != null && Properties.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public string Event { get; set; }

        public IEnumerable<FeatureDescription> SubFeatures { get; set; }
        public FeatureDescription OwnerFeature { get; set; }

        #region ISearchable Members

        public bool Contains(string word)
        {
            word = word.ToLower();
            bool inSubFeature = false;
            foreach (var sf in SubFeatures)
            {
                inSubFeature |= sf.Contains(word);
            }

            return inSubFeature || Name.ToLower().Contains(word); 
        }

        public bool ContainsAny(string[] searchKeys)
        {
            return searchKeys.Any(key => Contains(key));
        }

        #endregion
    }

    public enum FeatureType
    {
        Default,
        Custom,
        RelatedSamples
    }
}
