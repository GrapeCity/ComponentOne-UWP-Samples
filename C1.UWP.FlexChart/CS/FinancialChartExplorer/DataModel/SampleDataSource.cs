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

namespace FinancialChartExplorer.Data
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
            _allItems.Add(new SampleDataItem("HeikinAshi",
                Strings.HeikinAshiTitle,
                Strings.HeikinAshiDescription,
                "",
                typeof(HeikinAshi),
                Strings.HeikinAshiName));
            _allItems.Add(new SampleDataItem("LineBreak",
                Strings.LineBreakTitle,
                Strings.LineBreakDescription,
                "",
                typeof(LineBreak),
                Strings.LineBreakName));
            _allItems.Add(new SampleDataItem("Renko",
                Strings.RenkoTitle,
                Strings.RenkoDescription,
                "",
                typeof(Renko),
                Strings.RenkoName));
            _allItems.Add(new SampleDataItem("Kagi",
                Strings.KagiTitle,
                Strings.KagiDescription,
                "",
                typeof(Kagi),
                Strings.KagiName));
            _allItems.Add(new SampleDataItem("ColumnVolume",
                Strings.ColumnVolumeTitle,
                Strings.ColumnVolumeDescription,
                "",
                typeof(ColumnVolume),
                Strings.ColumnVolumeName));
            _allItems.Add(new SampleDataItem("EquiVolume",
                Strings.EquiVolumeTitle,
                Strings.EquiVolumeDescription,
                "",
                typeof(EquiVolume),
                Strings.EquiVolumeName));
            _allItems.Add(new SampleDataItem("CandleVolume",
                Strings.CandleVolumeTitle,
                Strings.CandleVolumeDescription,
                "",
                typeof(CandleVolume),
                Strings.CandleVolumeName));
            _allItems.Add(new SampleDataItem("ArmsCandleVolume",
                Strings.ArmsCandleVolumeTitle,
                Strings.ArmsCandleVolumeDescription,
                "",
                typeof(ArmsCandleVolume),
                Strings.ArmsCandleVolumeName));
            _allItems.Add(new SampleDataItem("Markers",
                Strings.MarkersTitle,
                Strings.MarkersDescription,
                "",
                typeof(Markers),
                Strings.MarkersName));
            _allItems.Add(new SampleDataItem("RangeSelector",
                Strings.RangeSelectorTitle,
                Strings.RangeSelectorDescription,
                "",
                typeof(RangeSelector),
                Strings.RangeSelectorName));
            _allItems.Add(new SampleDataItem("TrendLines",
                Strings.TrendLinesTitle,
                Strings.TrendLinesDescription,
                "",
                typeof(TrendLines),
                Strings.TrendLinesName));
            _allItems.Add(new SampleDataItem("MovingAverages",
                Strings.MovingAveragesTitle,
                Strings.MovingAveragesDescription,
                "",
                typeof(MovingAverages),
                Strings.MovingAveragesName));
            _allItems.Add(new SampleDataItem("Overlays",
                Strings.OverlaysTitle,
                Strings.OverlaysDescription,
                "",
                typeof(Overlays),
                Strings.OverlaysName));
            _allItems.Add(new SampleDataItem("Indicators",
                Strings.IndicatorsTitle,
                Strings.IndicatorsDescription,
                "",
                typeof(Indicators),
                Strings.IndicatorsName));
            _allItems.Add(new SampleDataItem("EventAnnotations",
                Strings.EventAnnotationsTitle,
                Strings.EventAnnotationsDescription,
                "",
                typeof(EventAnnotations),
                Strings.EventAnnotationsName));
            _allItems.Add(new SampleDataItem("FibonacciTool",
                Strings.FibonacciToolTitle,
                Strings.FibonacciToolDescription,
                "",
                typeof(FibonacciTool),
                Strings.FibonacciToolName));
            _allItems.Add(new SampleDataItem("PointAndFigure",
                Strings.PointAndFigureTitle,
                Strings.PointAndFigureDescription,
                "",
                typeof(PointAndFigure),
                Strings.PointAndFigureName));
        }
    }
}
