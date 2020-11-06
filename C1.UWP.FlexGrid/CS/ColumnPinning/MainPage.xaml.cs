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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ColumnPinning
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            // Setting AllowFreezing to None will prevent the availability of dragging frozen columns/rows.
            grid.AllowFreezing = C1.Xaml.FlexGrid.AllowFreezing.None;
            // Disable the Sorting option to prevent sorting icon disrupting the pinning icon.
            grid.AllowSorting = false;
            grid.Columns["Country"].AllowMerging = true;
            grid.MinColumnWidth = 85;
            this.Loaded += GridColumnPinning_Loaded;
            grid.Columns.CollectionChanged += Columns_CollectionChanged;
        }

        // Event handler.
        private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            (grid.CellFactory as ColumnPinningCellFactory).OnGridColumnCollectionChanged(grid);
        }

        // Override the CellFactory of the control with custom-defined CellFactory.
        private void GridColumnPinning_Loaded(object sender, RoutedEventArgs e)
        {
            grid.CellFactory = new ColumnPinningCellFactory();            
        }
    }
}
