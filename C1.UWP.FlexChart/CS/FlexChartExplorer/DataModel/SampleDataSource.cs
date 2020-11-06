using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace FlexChartExplorer.Data
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> that defines common properties.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String uniqueId, String title, String description, String imagePath, String name)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._description = description;
            this._imagePath = imagePath;
            this.Name = name;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        public string Name { get; set; }

        public DataTemplate Icon
        {
            get
            {
                try
                {
                    return (DataTemplate)App.Current.Resources["IconC1" + UniqueId.Replace(" ", "")];
                }
                catch
                {
                    return (DataTemplate)App.Current.Resources["IconC1Gray"];
                }
            }
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(SampleDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        public SampleDataItem(String uniqueId, String title, String description, String imagePath, Type pageType, string name)
            : base(uniqueId, title, description, imagePath, name)
        {
            _pageType = pageType;
        }

        private Type _pageType;
        public Type PageType
        {
            get { return this._pageType; }
            set { this.SetProperty(ref this._pageType, value); }
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();

        private ObservableCollection<SampleDataItem> _allItems = new ObservableCollection<SampleDataItem>();
        public ObservableCollection<SampleDataItem> AllItems
        {
            get { return this._allItems; }
        }

        public static IEnumerable<SampleDataItem> GetItems(string uniqueId)
        {
            if (!uniqueId.Equals("AllItems")) throw new ArgumentException(Strings.UniqueIdItemsArgumentException);

            return _sampleDataSource.AllItems;
        }

        public static SampleDataItem GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.AllItems.Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public SampleDataSource()
        {
            _allItems.Add(new SampleDataItem("Introduction",
                Strings.IntroductionTitle,
                Strings.IntroductionDescription,
                "",
                typeof(Introduction),
                Strings.IntroductionName));
            _allItems.Add(new SampleDataItem("Binding",
                Strings.BindingTitle,
                Strings.BindingDescription,
                "",
                typeof(Binding),
                Strings.BindingName));
            _allItems.Add(new SampleDataItem("SeriesBinding",
                Strings.SeriesBindingTitle,
                Strings.SereisBindingDescription,
                "",
                typeof(SeriesBinding),
                Strings.SeriesBindingName));
            _allItems.Add(new SampleDataItem("HeaderAndFooter",
                Strings.HeaderAndFooterTitle,
                Strings.HeaderAndFooterDescription,
                "",
                typeof(HeaderAndFooter),
                Strings.HeaderAndFooterName));
            _allItems.Add(new SampleDataItem("Selection",
                Strings.SelectionTitle,
                Strings.SelectionDescription,
                "",
                typeof(Selection),
                Strings.SelectionName));
            _allItems.Add(new SampleDataItem("Labels",
                Strings.LabelsTitle,
                Strings.LabelsDescription,
                "",
                typeof(Labels),
                Strings.LabelsName));
            _allItems.Add(new SampleDataItem("AutoLabels",
                Strings.AutoLabelsTitle,
                Strings.AutoLabelsDescription,
                "",
                typeof(AutoLabels),
                Strings.AutoLabelsName));
            _allItems.Add(new SampleDataItem("HitTest",
                Strings.HitTestTitle,
                Strings.HitTestDescription,
                "",
                typeof(HitTest),
                Strings.HitTestName));
            _allItems.Add(new SampleDataItem("Zoom",
               Strings.ZoomTitle,
               Strings.ZoomDescription,
               "",
               typeof(Zoom),
               Strings.ZoomName));
            _allItems.Add(new SampleDataItem("Bubble",
                Strings.BubbleTitle,
                Strings.BubbleDescription,
                "",
                typeof(Bubble),
                Strings.BubbleName));
            _allItems.Add(new SampleDataItem("Financial",
                Strings.FinancialTitle,
                Strings.FinancialDescription,
                "",
                typeof(Financial),
                Strings.FinancialName));
            _allItems.Add(new SampleDataItem("Axes",
                Strings.AxesTitle,
                Strings.AxesDescription,
                "",
                typeof(Axes),
                Strings.AxesName));
            _allItems.Add(new SampleDataItem("AxisLabels",
                Strings.AxisLabelsTitle,
                Strings.AxisLabelsDescription,
                "",
                typeof(AxisLabels),
                Strings.AxisLabelsName));
            _allItems.Add(new SampleDataItem("AxisGrouping",
    Strings.AxisGroupingTitle,
    Strings.AxisGroupingDescription,
    "",
    typeof(AxisGrouping),
    Strings.AxisGroupingName));
            _allItems.Add(new SampleDataItem("NumericAxisGrouping",
    Strings.NumericAxisGroupingTitle,
    Strings.NumericAxisGroupingDescription,
    "",
    typeof(NumericAxisGrouping),
    Strings.NumericAxisGroupingName));
            _allItems.Add(new SampleDataItem("DateTimeAxisGrouping",
Strings.DateTimeAxisGroupingTitle,
Strings.DateTimeAxisGroupingDescription,
"",
typeof(DateTimeAxisGrouping),
Strings.DateTimeAxisGroupingName));
            _allItems.Add(new SampleDataItem("PlotAreas",
                Strings.PlotAreasTitle,
                Strings.PlotAreasDescription,
                "",
                typeof(PlotAreas),
                Strings.PlotAreasName));
            _allItems.Add(new SampleDataItem("AxisBinding",
               Strings.AxisBindingTitle,
               Strings.AxisBindingDescription,
               "",
               typeof(AxisBinding),
               Strings.AxisBindingName));
            _allItems.Add(new SampleDataItem("ImageExport",
                Strings.ImageExportTitle,
                Strings.ImageExportDescription,
                "",
                typeof(ImageExport),
                Strings.ImageExportName));
            _allItems.Add(new SampleDataItem("Zones",
                Strings.ZonesTitle,
                Strings.ZonesDescription,
                "",
                typeof(Zones),
                Strings.ZonesName));
            _allItems.Add(new SampleDataItem("TrendLine",
                Strings.TrendLineTitle,
                Strings.TrendLineDescription,
                "",
                typeof(TrendLine),
                Strings.TrendLineName));
            _allItems.Add(new SampleDataItem("Waterfall",
                Strings.WaterfallTitle,
                Strings.WaterfallDescription,
                "",
                typeof(Waterfall),
                Strings.WaterfallName));
            _allItems.Add(new SampleDataItem("PieIntroduction",
                Strings.PieIntroductionTitle,
                Strings.PieIntroductionDescription,
                "",
                typeof(PieIntroduction),
                Strings.PieIntroductionName));
            _allItems.Add(new SampleDataItem("PieSelection",
                Strings.PieSelectionTitle,
                Strings.PieSelectionDescription,
                "",
                typeof(PieSelection),
                Strings.PieSelectionName));
            _allItems.Add(new SampleDataItem("MultiPie",
                Strings.MultiPieTitle,
                Strings.MultiPieDescription,
                "",
                typeof(MultiPie),
                Strings.MultiPieName));
            _allItems.Add(new SampleDataItem("BoxWhisker",
                Strings.BoxWhiskerTitle,
                Strings.BoxWhiskerDescription,
                "",
                typeof(BoxWhisker),
                Strings.BoxWhiskerName));
            _allItems.Add(new SampleDataItem("ErrorBar",
                Strings.ErrorBarTitle,
                Strings.ErrorBarDescription,
                "",
                typeof(ErrorBar),
                Strings.ErrorBarName));
            _allItems.Add(new SampleDataItem("Legend",
                Strings.LegendTitle,
                Strings.LegendDescription,
                "",
                typeof(Legend),
                Strings.LegendName));
            _allItems.Add(new SampleDataItem("TreeMap",
                Strings.TreeMapTitle,
                Strings.TreeMapDescription,
                "",
                typeof(TreeMap),
                Strings.TreeMapName));

            _allItems.Add(new SampleDataItem("TreeMapNodeColor",
    Strings.TreeMapNodeColorTitle,
    Strings.TreeMapNodeColorDescription,
    "",
    typeof(TreeMapNodeColor),
    Strings.TreeMapNodeColorName));

            _allItems.Add(new SampleDataItem("Histogram",
                Strings.HistogramTitle,
                Strings.HistogramDescription,
                "",
                typeof(Histogram),
                Strings.HistogramName));
            _allItems.Add(new SampleDataItem("RangedHistogram",
                Strings.RangedHistogramTitle,
                Strings.RangedHistogramDescription,
                "",
                typeof(RangedHistogram),
                Strings.RangedHistogramName));
            _allItems.Add(new SampleDataItem("Pareto",
                Strings.ParetoTitle,
                Strings.ParetoDescription,
                "",
                typeof(Pareto),
                Strings.ParetoName));
        }
    }
}
