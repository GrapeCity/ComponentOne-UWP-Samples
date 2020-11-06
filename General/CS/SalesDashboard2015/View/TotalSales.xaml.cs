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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SalesDashboard2015
{
    public sealed partial class TotalSales : UserControl
    {
        public TotalSales()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataModel.SampleDataSource dataSource = this.DataContext as DataModel.SampleDataSource;
            if (dataSource != null)
            {
                double totalSales = dataSource.TotalSales / 1000;
                gauge.Value = totalSales;
                runTotal.Text = totalSales.ToString();
            }
        }
    }
}
