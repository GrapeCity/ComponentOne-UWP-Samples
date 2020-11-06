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
    public sealed partial class Editing : Page
    {
        CellRange selectedRange;
        public Editing()
        {
            this.InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }

        private async void Grid_DoubleClickAsync(object sender, RoutedEventArgs e)
        {
            if (this.selectedRange != null)
            {
                Customer c = grid.Rows[this.selectedRange.Row].DataItem as Customer;
                if (c != null)
                    await new EditCustomerForm(c).ShowAsync();
            }
        }

        private void Grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }

        private void Grid_SelectionChanged(object sender, CellRangeEventArgs e)
        {
            this.selectedRange = e.CellRange;
        }
    }
}
