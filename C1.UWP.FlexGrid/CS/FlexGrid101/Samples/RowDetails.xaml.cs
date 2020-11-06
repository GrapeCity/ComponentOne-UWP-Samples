using C1.Xaml;
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
    public partial class RowDetails : Page
    {
        public RowDetails()
        {
            InitializeComponent();

            lblMode.Text = Strings.DetailsVisibiltyMode;

            showItemsPicker.Items.Add(DataGridRowDetailsVisibilityMode.Collapsed.ToString());
            showItemsPicker.Items.Add(DataGridRowDetailsVisibilityMode.Visible.ToString());
            showItemsPicker.Items.Add(DataGridRowDetailsVisibilityMode.VisibleWhenSelected.ToString());
            showItemsPicker.SelectionChanged += (s, e) =>
            {
                switch (showItemsPicker.SelectedIndex)
                {
                    case 0:
                        grid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
                        grid.Invalidate();
                        break;
                    case 1:
                        grid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Visible;
                        grid.Invalidate();
                        break;
                    case 2:
                        grid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
                        grid.Invalidate();
                        break;
                }
            };
            showItemsPicker.SelectedIndex = 1;

            var data = Customer.GetCustomerList(1000);
            var view = new C1CollectionView(data);
            grid.ItemsSource = view;
            grid.MinColumnWidth = 85;
        }
    }
}
