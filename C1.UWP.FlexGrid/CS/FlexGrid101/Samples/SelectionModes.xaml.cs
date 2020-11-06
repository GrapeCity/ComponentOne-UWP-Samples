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
    public partial class SelectionModes : Page
    {
        public SelectionModes()
        {
            InitializeComponent();

            foreach (var value in Enum.GetValues(typeof(C1.Xaml.FlexGrid.SelectionMode)))
            {
                selectionMode.Items.Add(value.ToString());
            }
            selectionMode.SelectedIndex = selectionMode.Items.IndexOf(C1.Xaml.FlexGrid.SelectionMode.CellRange.ToString());

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.MinColumnWidth = 85;
        }

        private void selectionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid.SelectionMode = (C1.Xaml.FlexGrid.SelectionMode)Enum.Parse(typeof(C1.Xaml.FlexGrid.SelectionMode), selectionMode.Items[selectionMode.SelectedIndex].ToString());
        }

        private void grid_SelectionChanging(object sender, C1.Xaml.FlexGrid.CellRangeEventArgs e)
        {
            // e.Cancel = true;
        }

        private void grid_SelectionChanged(object sender, C1.Xaml.FlexGrid.CellRangeEventArgs e)
        {
            if (e.CellRange != null && e.CellRange.Row != -1)
            {
                int rowsSelected = Math.Abs(e.CellRange.Row2 - e.CellRange.Row) + 1;
                int colsSelected = Math.Abs(e.CellRange.Column2 - e.CellRange.Column) + 1;

                lblSelection.Text = (rowsSelected * colsSelected).ToString() + " " + Strings.CellsSelectedText;
            }
        }
    }
}
