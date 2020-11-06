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
    public sealed partial class SalesByType : UserControl
    {
        public SalesByType()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataModel.SampleDataSource dataSource = this.DataContext as DataModel.SampleDataSource;
            if (dataSource != null)
            {
                gaugeConsole.Value = dataSource.TotalSalesConsole / 1000;
                gaugeDesktop.Value = dataSource.TotalSalesDesktop / 1000;
                gaugePhone.Value = dataSource.TotalSalesPhone / 1000;
                gaugeTablet.Value = dataSource.TotalSalesTablet / 1000;
                gaugeTV.Value = dataSource.TotalSalesTV / 1000;
            }
        }
    }
}
