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
    public sealed partial class SalesByCategory : UserControl
    {
        public SalesByCategory()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.pieDataLabel.Content = "{Percent}" + Strings.Percent;
            this.flexPie.BeginUpdate();
            this.flexPie.ItemsSource = (this.DataContext as DataModel.SampleDataSource).SalesByCategory;
            this.flexPie.EndUpdate();
        }
    }
}
