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
    public sealed partial class SalesByRegion : UserControl
    {
        public SalesByRegion()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.flexChart.BeginUpdate();
            this.flexChart.ToolTipContent = "{RegionName}\n{SaleValue}";
            this.flexChart.ItemsSource = (this.DataContext as DataModel.SampleDataSource).SalesByRegion;
            this.flexChart.EndUpdate();
        }
    }
}
