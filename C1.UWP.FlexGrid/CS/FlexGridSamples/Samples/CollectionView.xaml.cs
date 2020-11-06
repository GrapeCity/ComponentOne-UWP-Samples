using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using C1.Xaml.FlexGrid;
using C1.Xaml;
using System.Collections;

namespace FlexGridSamples
{
    public sealed partial class CollectionView : Page
    {
        C1CollectionView _c1CollectionView;

        public CollectionView()
        {
            this.InitializeComponent();
            c1FlexGrid1.GroupHeaderConverter = new MyGroupConverter();
            List<FilterFiled> filterFields = new List<FilterFiled>();
            filterFields.Add(new FilterFiled { Name = Strings.FiledLine, Filed = "Line" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledColor, Filed = "Color" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledPrice, Filed = "Price" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledWeight, Filed = "Weight" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledCost, Filed = "Cost" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledVolume, Filed = "Volume" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledDiscontinued, Filed = "Discontinued" });
            filterFields.Add(new FilterFiled { Name = Strings.FiledRating, Filed = "Rating" });
            filterComboBox.ItemsSource = filterFields;
            filterComboBox.DisplayMemberPath = "Name";
            filterComboBox.SelectedIndex = 0;

            //you can use a custome C1CollectionViewConverter to define sort/group in xaml page
            //or define C1CollectionViewer as following.
            //_c1CollectionView = new C1CollectionView();
            //_c1CollectionView.SourceCollection = Product.GetProducts(100);
            //_c1CollectionView.GroupDescriptions.Add(new C1.Xaml.PropertyGroupDescription("Color"));

            c1FlexGrid1.DataContext = new ViewModel();
            c1FlexGrid1.Loaded += C1FlexGrid1_Loaded;

        }

        private void C1FlexGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            _c1CollectionView = c1FlexGrid1.CollectionView as C1CollectionView;
        }

        void UpdateFiltering()
        {
            if (filterTextBox.Text.Length == 0)
            {
                _c1CollectionView.Filter = null;
            }
            else
            {
                if (_c1CollectionView.Filter == null)
                {
                    _c1CollectionView.Filter = FilterFunction;
                }
                else
                {
                    _c1CollectionView.Refresh();
                }
            }
        }

        bool FilterFunction(object product)
        {
            // get customer to test
            Product c = product as Product;
            if (c == null)
            {
                return false;
            }

            // get value of the property we're filtering on
            var ff = filterComboBox.SelectedItem as FilterFiled;
            var pi = typeof(Product).GetRuntimeProperty(ff.Filed);
            object propValue = pi.GetValue(c, null);
            if (propValue == null)
            {
                return false;
            }

            // check if the property contains the filter string
            var text = propValue.ToString();
            return text.IndexOf(filterTextBox.Text, StringComparison.CurrentCultureIgnoreCase) > -1;
        }
        void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFiltering();
        }
        void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterTextBox.Text = string.Empty;
        }

        private void groupCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            if (_c1CollectionView != null && cb != null)
            {
                string name = cb.Name;
                string propertyName = name;
                if (name.Contains("Color"))
                {
                    propertyName = "Color";
                }
                else if (name.Contains("Line"))
                {
                    propertyName = "Line";
                }
                else if (name.Contains("Rating"))
                {
                    propertyName = "Rating";
                }
                using (_c1CollectionView.DeferRefresh())
                {
                    var group = _c1CollectionView.GroupDescriptions.FirstOrDefault(p => (p as PropertyGroupDescription).PropertyName == propertyName);
                    if (group == null)
                    {
                        _c1CollectionView.GroupDescriptions.Add(new PropertyGroupDescription(propertyName));
                    }
                }
            }
        }

        private void groupCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            if (_c1CollectionView != null && cb != null)
            {
                string name = cb.Name;
                string propertyName = name;
                if (name.Contains("Color"))
                {
                    propertyName = "Color";
                }
                else if (name.Contains("Line"))
                {
                    propertyName = "Line";
                }
                else if (name.Contains("Rating"))
                {
                    propertyName = "Rating";
                }
                using (_c1CollectionView.DeferRefresh())
                {
                    _c1CollectionView.GroupDescriptions.Remove(_c1CollectionView.GroupDescriptions.FirstOrDefault(p => (p as PropertyGroupDescription).PropertyName == propertyName));

                }
            }
        }
    }

    class MyGroupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var gr = parameter as GroupRow;
            var group = gr.Group;
            var cv = gr.Grid.CollectionView as IC1CollectionView;
            var desc = cv != null && gr.Level < cv.GroupDescriptions.Count
                   ? cv.GroupDescriptions[gr.Level] as PropertyGroupDescription
                   : null;
            string name = desc.PropertyName;
            if (name == "Line" || name == "Color" || name == "Rating")
            {
                name = gr.Grid.Columns[name].Header;
            }

            //string headerName = gr.Grid.Columns[name].Header;
            int itemCount = group.GroupItems.Count;
            if (itemCount > 1)
            {
                return string.Format(Strings.ItemsCount, name, itemCount);
            }
            return string.Format(Strings.ItemCount, name, itemCount);
        }

        // shouldn't need to convert back to anything
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
            //throw new NotImplementedException();
        }
    }

    public class C1CollectionViewConverter : IValueConverter
    {

        private ObservableCollection<SortDescription> sortDescriptions = new ObservableCollection<SortDescription>();

        public ObservableCollection<SortDescription> SortDescriptions
        {
            get { return sortDescriptions; }
            set { sortDescriptions = value; }
        }


        private ObservableCollection<PropertyGroupDescription> groupDescriptions = new ObservableCollection<PropertyGroupDescription>();

        public ObservableCollection<PropertyGroupDescription> GroupDescriptions
        {
            get { return groupDescriptions; }
            set { groupDescriptions = value; }
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is IEnumerable)
            {
                var collectionView = new C1CollectionView();

                collectionView.SourceCollection = (System.Collections.IEnumerable)value;
                foreach (var group in this.GroupDescriptions)
                {
                    collectionView.GroupDescriptions.Add(group);
                }
                foreach (var sort in this.SortDescriptions)
                {
                    collectionView.SortDescriptions.Add(sort);
                }

                return collectionView;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewModel
    {
        public ICollectionView Products { get; set; }

        public ViewModel()
        {
            Products = Product.GetProducts(100);
        }
    }

    public class FilterFiled
    {
        public string Name { get; set; }
        public string Filed { get; set; }
    }
}
