using C1.Xaml.FlexGrid;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace FlexGridSamples
{
    public partial class Editing : Page
    {
        public Editing()
        {
            InitializeComponent();

            // store sample description in Tag property
            Tag = Strings.EditingTag;

            // populate edit grid
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, PopulateEditGrid);
        }

        private void PopulateEditGrid()
        {
            // create the data
            var data = Customer.GetCustomerList(100);
            var view = new CollectionViewSource();
            view.Source = data;
            _flexEdit.ItemsSource = view.View;

            // hide read-only "Country" column 
            var col = _flexEdit.Columns["Country"];
            _flexEdit.Columns.Remove(col);

            // map countryID column so it shows country names instead of their IDs
            Dictionary<int, string> dct = new Dictionary<int, string>();
            foreach (var country in Customer.GetCountries())
            {
                dct[dct.Count] = country;
            }
            col = _flexEdit.Columns["CountryID"];
            col.ValueConverter = new ColumnValueConverter(dct);
            col.HorizontalAlignment = HorizontalAlignment.Left;
            col.Width = new GridLength(120);

            // provide auto-complete lists for first and last name columns
            col = _flexEdit.Columns["First"];
            col.ValueConverter = new ColumnValueConverter(Customer.GetFirstNames(), false);
            col = _flexEdit.Columns["Last"];
            col.ValueConverter = new ColumnValueConverter(Customer.GetLastNames(), false);

            // make read-only columns look disabled
            var readOnlyBrush = new SolidColorBrush(Color.FromArgb(0xe0, 0xe0, 0xe0, 0xe0));
            foreach (var c in _flexEdit.Columns)
            {
                if (c.PropertyInfo != null && !c.PropertyInfo.CanWrite)
                {
                    c.Background = readOnlyBrush;
                }
            }
        }
    }
}
