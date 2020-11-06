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
using Windows.UI.Xaml.Controls;
using BasicLibrarySamples;
using Windows.UI.Xaml;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace BasicLibrarySamples.Data
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> and <see cref="SampleDataGroup"/> that
    /// defines properties common to both.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : BasicLibrarySamples.Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String uniqueId, String title, String description, String imagePath, string name)
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
                object res;
                if (App.Current.Resources.TryGetValue("IconC1" + _uniqueId.Replace(" ", ""), out res))
                    return (DataTemplate)res;
                else
                {
                    res = App.Current.Resources["IconC1Gray"];
                    return (DataTemplate)res;
            }
                return App.Current.Resources.TryGetValue("IconC1" + _uniqueId.Replace(" ", ""), out res) ? (DataTemplate)res :
                    (DataTemplate)App.Current.Resources["IconC1Gray"];

                //return (DataTemplate)App.Current.Resources["IconC1" + Name.Replace(" ", "")] ?? (DataTemplate)App.Current.Resources["IconC1Gray"];
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

            _allItems.Add(new SampleDataItem("MaskedTextBox",
                    Strings.MaskedTextBoxTitle,
                    Strings.MaskedTextBoxDescription,
                    "Assets/LightGray.png",
                    typeof(MaskedTextBoxSample),
                    Strings.MaskedTextBoxName));
            _allItems.Add(new SampleDataItem("NumericBox",
                    Strings.NumericBoxTitle,
                    Strings.NumericBoxDescription,
                    "Assets/DarkGray.png",
                    typeof(NumericBoxSample),
                    Strings.NumericBoxName));
            _allItems.Add(new SampleDataItem("DropDown",
                    Strings.DropDownTitle,
                    Strings.DropDownDescription,
                    "Assets/LightGray.png",
                    typeof(DropDownDemo),
                    Strings.DropDownName));
            _allItems.Add(new SampleDataItem("Hierarchical Tree",
                    Strings.HierarchicalDropDownTitle,
                    Strings.HierarchicalDropDownDescription,
                    "Assets/LightGray.png",
                    typeof(HierarchicalDropDown),
                    Strings.HierarchicalDropDownName));
            _allItems.Add(new SampleDataItem("AutoComplete",
                    Strings.AutoCompleteDropDownTitle,
                    Strings.AutoCompleteDropDownDescription,
                    "Assets/LightGray.png",
                    typeof(AutoCompleteDropDown),
                    Strings.AutoCompleteDropDownName));
            _allItems.Add(new SampleDataItem("DockPanel",
                    Strings.DockPanelSampleTitle,
                    Strings.DockPanelSampleDescription,
                    "Assets/LightGray.png",
                    typeof(DockPanelSample),
                    Strings.DockPanelSampleName));
            _allItems.Add(new SampleDataItem("UniformGrid",
                    Strings.UniformGridSampleTitle,
                    Strings.UniformGridSampleDescription,
                    "Assets/LightGray.png",
                    typeof(UniformGridSample),
                    Strings.UniformGridSampleName));
            _allItems.Add(new SampleDataItem("WrapPanel",
                    Strings.WrapPanelSampleTitle,
                    Strings.WrapPanelSampleDescription,
                    "Assets/DarkGray.png",
                    typeof(WrapPanelSample),
                    Strings.WrapPanelSampleName));
            _allItems.Add(new SampleDataItem("RadialPanel",
                   Strings.RadialPanelSampleTitle,
                   Strings.RadialPanelSampleDescription,
                   "Assets/LightGray.png",
                   typeof(RadialPanelSample),
                   Strings.RadialPanelSampleName));
            _allItems.Add(new SampleDataItem("TabControl",
                   Strings.EntranceTabTitle,
                   Strings.EntranceTabDescription,
                   "Assets/LightGray.png",
                   typeof(EntranceTab),
                   Strings.EntranceTabName));
            _allItems.Add(new SampleDataItem("Tab Placement",
                   Strings.ClearStyleTabControlTitle,
                   Strings.ClearStyleTabControlDescription,
                   "Assets/LightGray.png",
                   typeof(ClearStyleTabControl),
                   Strings.ClearStyleTabControlName));
            _allItems.Add(new SampleDataItem("Close and Pin",
                   Strings.TabControlSampleTitle,
                   Strings.TabControlSampleDescription,
                   "Assets/LightGray.png",
                   typeof(TabControlSample),
                   Strings.TabControlSampleName));
            _allItems.Add(new SampleDataItem("Conditions",
                    Strings.CollectionViewConditionsTitle,
                    Strings.CollectionViewConditionseDescription,
                    "Assets/LightGray.png",
                    typeof(CollectionViewConditions),
                    Strings.CollectionViewConditionsName));
            _allItems.Add(new SampleDataItem("Grouping",
                    Strings.BindingToC1CollectionViewTitle,
                    Strings.BindingToC1CollectionViewDescription,
                    "Assets/LightGray.png",
                    typeof(BindingToC1CollectionView),
                    Strings.BindingToC1CollectionViewName));
            _allItems.Add(new SampleDataItem("ListBox",
                    Strings.ListBoxSampleTitle,
                    Strings.ListBoxSampleDescription,
                    "Assets/LightGray.png",
                    typeof(ListBoxSample),
                    Strings.ListBoxSampleName));
            //_allItems.Add(new SampleDataItem("TileListBox",
            //        "TileListBox",
            //        "The C1TileListBox control is a high performance list box that can arrange its items in both rows and columns to create tile displays. Both ComponentOne ListBox controls support incremental loading so you can infinitely load more items on demand as the user scrolls to the end of the list.",
            //        "Assets/DarkGray.png",
            //        typeof(TileListBoxSample)));
            _allItems.Add(new SampleDataItem("TreeView",
                     Strings.TreeViewSampleTitle,
                     Strings.TreeViewSampleDescription,
                     "Assets/LightGray.png",
                     typeof(TreeViewSample),
                    Strings.TreeViewSampleName));
            _allItems.Add(new SampleDataItem("CheckBoxTreeView",
                    Strings.CheckBoxTreeViewTitle,
                    Strings.CheckBoxTreeViewDescription,
                    "Assets/LightGray.png",
                    typeof(CheckBox),
                    Strings.CheckBoxTreeViewName));
            _allItems.Add(new SampleDataItem("DragDropTreeView",
                    Strings.DragDropTreeViewTitle,
                    Strings.DragDropTreeViewDescription,
                    "Assets/LightGray.png",
                    typeof(DragDrop),
                    Strings.DragDropTreeViewName));
            _allItems.Add(new SampleDataItem("HierarchicalTreeView",
                   Strings.HierarchicalTreeViewTitle,
                   Strings.HierarchicalTreeViewDescription,
                   "Assets/LightGray.png",
                   typeof(HierarchicalTemplate),
                   Strings.HierarchicalTreeViewName));
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                _allItems.Add(new SampleDataItem("EditTreeView",
                    Strings.EditTreeViewTitle,
                    Strings.EditTreeViewDescription,
                    "Assets/LightGray.png",
                    typeof(Edit),
                    Strings.EditTreeViewName));
            }
            _allItems.Add(new SampleDataItem("Menu",
                    Strings.MenuSampleTitle,
                    Strings.MenuSampleDescription,
                    "Assets/LightGray.png",
                    typeof(MenuSample),
                    Strings.MenuSampleName));
            _allItems.Add(new SampleDataItem("ContextMenu",
                    Strings.ContextMenuTitle,
                    Strings.ContextMenuDescription,
                    "Assets/LightGray.png",
                    typeof(ContextMenu),
                    Strings.ContextMenuName));
            _allItems.Add(new SampleDataItem("RadialMenu",
                    Strings.RadialMenuTitle,
                    Strings.RadialMenuDescription,
                    "Assets/LightGray.png",
                    typeof(RadialMenu),
                    Strings.RadialMenuName));
            _allItems.Add(new SampleDataItem("Progress Indicator",
                    Strings.ProgressIndicatorDemoTitle,
                    Strings.ProgressIndicatorDemoDescription,
                    "Assets/DarkGray.png",
                    typeof(ProgressIndicatorDemo),
                    Strings.ProgressIndicatorDemoName));
            _allItems.Add(new SampleDataItem("Input Handling",
                    Strings.InputHandlingTitle,
                    Strings.InputHandlingeDescription,
                    "Assets/DarkGray.png",
                    typeof(InputHandling),
                    Strings.InputHandlingName));
            _allItems.Add(new SampleDataItem("RangeSlider",
                    Strings.RangeSliderTitle,
                    Strings.RangeSliderDescription,
                    "Assets/DarkGray.png",
                    typeof(RangeSlider),
                    Strings.RangeSliderName));
            _allItems.Add(new SampleDataItem("GridSplitter",
                    Strings.GridSplitterSampleTitle,
                    Strings.GridSplitterSampleDescription,
                    "Assets/LightGray.png",
                    typeof(GridSplitterSample),
                    Strings.GridSplitterSampleName));

            var orderby = from e in _allItems orderby e.Title select e;
            _allItems = new ObservableCollection<SampleDataItem>(orderby);

        }
    }
}
