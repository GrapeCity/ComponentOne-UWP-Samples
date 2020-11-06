using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class NewRow : Page
    {
        public NewRow()
        {
            this.InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.AllowAddNew = true;
            grid.CellFactory = new MyCellFactory();
            grid.MinColumnWidth = 85;

            foreach (Column c in grid.Columns)
            {
                if (c.ColumnName == "Country" || c.ColumnName == "Name" || c.ColumnName == "OrderAverage")
                {
                    //Hide these columns.
                    c.Visible = false;
                }
                else if (c.ColumnName == "Id")
                {
                    c.IsReadOnly = true;
                }
                else if (c.ColumnName == "CountryId")
                {
                    //Sets the DataMap to the country column so a picker is used to select the country.
                    Dictionary<int, string> dct = new Dictionary<int, string>();
                    foreach (var country in Customer.GetCountries())
                    {
                        dct[dct.Count] = country.Value;
                    }
                    c.ValueConverter = new ColumnValueConverter(dct);
                    c.Header = "Country";
                    c.HorizontalAlignment = HorizontalAlignment.Left;
                    c.Width = new GridLength(120);
                }
                else if (c.ColumnName == "OrderTotal" || c.ColumnName == "OrderAverage")
                {
                    //Sets currency format the these columns
                    c.Format = "C";
                }
            }
        }
    }
}
