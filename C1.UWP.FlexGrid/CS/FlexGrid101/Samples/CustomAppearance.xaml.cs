using C1.Xaml.FlexGrid;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexGrid101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomAppearance : Page
    {
        public CustomAppearance()
        {
            this.InitializeComponent();

            PopulateEditGrid();
        }

        private void PopulateEditGrid()
        {
            // create the data
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.MinColumnWidth = 85;

            // hide read-only "Country" column 
            var col = grid.Columns["Country"];
            col.Visible = false;

            // map countryID column so it shows country names instead of their IDs
            Dictionary<int, string> dct = new Dictionary<int, string>();
            foreach (var country in Customer.GetCountries())
            {
                dct[country.Key] = country.Value;
            }
            col = grid.Columns["CountryID"];
            col.ValueConverter = new ColumnValueConverter(dct);
            col.HorizontalAlignment = HorizontalAlignment.Left;
            col.Width = new GridLength(120);

            // provide auto-complete lists for first and last name columns
            col = grid.Columns["FirstName"];
            col.ValueConverter = new ColumnValueConverter(Customer.GetFirstNames(), false);
            col = grid.Columns["LastName"];
            col.ValueConverter = new ColumnValueConverter(Customer.GetLastNames(), false);

            // make read-only columns look disabled
            var readOnlyBrush = new SolidColorBrush(Color.FromArgb(0xe0, 0xe0, 0xe0, 0xe0));
            foreach (var c in grid.Columns)
            {
                if (c.PropertyInfo != null && !c.PropertyInfo.CanWrite)
                {
                    c.Background = readOnlyBrush;
                }
            }

            grid.Columns.Move(grid.Columns["Name"].Index, 1);
        }
    }
}
