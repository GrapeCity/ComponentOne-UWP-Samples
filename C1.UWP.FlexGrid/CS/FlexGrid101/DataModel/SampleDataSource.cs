using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace FlexGrid101.Data
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> that defines common properties.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : FlexGrid101.Common.BindableBase
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
            _allItems.Add(new SampleDataItem("GettingStarted",
                Strings.GettingStartedTitle,
                Strings.GettingStartedDescription,
                "Assets/flexgrid.png",
                typeof(GettingStarted),
                Strings.GettingStartedDescription));
            _allItems.Add(new SampleDataItem("ColumnDefinitions",
                Strings.ColumnDefinitionTitle,
                Strings.ColumnDefinitionDescription,
                "Assets/flexgrid_columns.png",
                typeof(ColumnDefinitions),
                Strings.ColumnDefinitionDescription));
            _allItems.Add(new SampleDataItem("SelectionModes",
                Strings.SelectionModesTitle,
                Strings.SelectionModesDescription,
                "Assets/flexgrid_selection.png",
                typeof(SelectionModes),
                Strings.SelectionModesDescription));
            _allItems.Add(new SampleDataItem("EditConfirmation",
                Strings.EditConfirmationTitle,
                Strings.EditConfirmationDescription,
                "Assets/flexgrid_editConfirmation.png",
                typeof(EditConfirmation),
                Strings.EditConfirmationDescription));
            _allItems.Add(new SampleDataItem("Editing",
                Strings.EditingTitle,
                Strings.EditingDescription,
                "Assets/input_form.png",
                typeof(Editing),
                Strings.EditingDescription));
            _allItems.Add(new SampleDataItem("ConditionalFormatting",
                Strings.ConditionalFormattingTitle,
                Strings.ConditionalFormattingDescription,
                "Assets/flexgrid_conditionalFormatting.png",
                typeof(ConditionalFormatting),
                Strings.ConditionalFormattingDescription));
            _allItems.Add(new SampleDataItem("CustomCells",
                Strings.CustomCellsTitle,
                Strings.CustomCellsDescription,
                "Assets/flexgrid_custom.png",
                typeof(CustomCells),
                Strings.CustomCellsDescription));
            _allItems.Add(new SampleDataItem("Grouping",
                Strings.GroupingTitle,
                Strings.GroupingDescription,
                "Assets/flexgrid_grouping.png",
                typeof(Grouping),
                Strings.GroupingDescription));
            _allItems.Add(new SampleDataItem("RowDetails",
                Strings.RowDetailsTitle,
                Strings.RowDetailsDescription,
                "Assets/flexgrid_rowdetails.png",
                typeof(RowDetails),
                Strings.RowDetailsDescription));
            _allItems.Add(new SampleDataItem("CollectionView",
                Strings.CollectionViewTitle,
                Strings.CollectionViewDescription,
                "Assets/flexgrid_filter.png",
                typeof(CollectionView),
                Strings.CollectionViewDescription));
            _allItems.Add(new SampleDataItem("FullTextFilter",
                Strings.FullTextFilterTitle,
                Strings.FullTextFilterDescription,
                "Assets/flexgrid_fullTextFilter.png",
                typeof(FullTextFilter),
                Strings.FullTextFilterDescription));
            _allItems.Add(new SampleDataItem("ColumnLayout",
                Strings.ColumnLayoutTitle,
                Strings.ColumnLayoutDescription,
                "Assets/flexgrid_columns.png",
                typeof(ColumnLayout),
                Strings.ColumnLayoutDescription));
            _allItems.Add(new SampleDataItem("StarSizing",
                Strings.StarSizingTitle,
                Strings.StarSizingDescription,
                "Assets/flexgrid_starSizing.png",
                typeof(StarSizing),
                Strings.StarSizingDescription));
            _allItems.Add(new SampleDataItem("CellFreezing",
                Strings.CellFreezingTitle,
                Strings.CellFreezingDescription,
                "Assets/flexgrid_freezing.png",
                typeof(CellFreezing),
                Strings.CellFreezingDescription));
            _allItems.Add(new SampleDataItem("CustomMerging",
                Strings.CustomMergingTitle,
                Strings.CustomMergingDescription,
                "Assets/flexgrid_merging.png",
                typeof(CustomMerging),
                Strings.CustomMergingDescription));
            _allItems.Add(new SampleDataItem("Unbound",
                Strings.UnboundTitle,
                Strings.UnboundDescription,
                "Assets/flexgrid_headers.png",
                typeof(Unbound),
                Strings.UnboundDescription));
            _allItems.Add(new SampleDataItem("CustomAppearance",
                Strings.CustomAppearanceTitle,
                Strings.CustomAppearanceDescription,
                "Assets/flexgrid_customAppearance.png",
                typeof(CustomAppearance),
                Strings.CustomAppearanceDescription));
            _allItems.Add(new SampleDataItem("NewRow",
                Strings.NewRowTitle,
                Strings.NewRowDescription,
                "Assets/flexgrid_newRow.png",
                typeof(NewRow),
                Strings.NewRowDescription));
            _allItems.Add(new SampleDataItem("Financial",
                Strings.FinancialTitle,
                Strings.FinancialDescription,
                "Assets/flexgrid_financial.png",
                typeof(Financial),
                Strings.FinancialTitle));
            _allItems.Add(new SampleDataItem("CustomSortIcon",
                Strings.CustomSortTitle,
                Strings.CustomSortDescription,
                "Assets/flexgrid_customSort.png",
                typeof(CustomSortIcon),
                Strings.CustomSortDescription));
        }
    }
}
