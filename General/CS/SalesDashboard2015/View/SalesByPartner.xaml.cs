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
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using C1.Xaml.Chart;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SalesDashboard2015
{
    public sealed partial class SalesByPartner : UserControl
    {
        List<string> DataList;

        public SalesByPartner()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataList = new List<string>();
            this.flexChart.BeginUpdate();
            this.flexChart.ItemsSource = (this.DataContext as DataModel.SampleDataSource).SalesByPartner;
            this.flexChart.EndUpdate();
            foreach(DataModel.PartnersData data in (this.DataContext as DataModel.SampleDataSource).SalesByPartner)
            {
                string sale = Strings.SignDollar + data.TotalSale;
                this.DataList.Add(sale);
            }
        }

        private void flexChart_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ChangeMyDataLabel(e);
        }

        private void flexChart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChangeMyDataLabel(e);
        }

        private void ChangeMyDataLabel(RoutedEventArgs e)
        {
            if (this.flexChart.SelectedIndex < 0)
            {
                this.MyDataLabel.Visibility = Visibility.Collapsed;
                this.MyDataLabel.Text = "";
            }
            else
            {
                this.MyDataLabel.Visibility = Visibility.Visible;
                this.MyDataLabel.Text = this.DataList[this.flexChart.SelectedIndex];
                object selectedItem = e.OriginalSource;
                double left = RenderCanvas.GetLeft(selectedItem as UIElement);
                double top = RenderCanvas.GetTop(selectedItem as UIElement);
                double width = (selectedItem as FrameworkElement).Width;
                Canvas.SetLeft(this.MyDataLabel, left + width + 5);
                Canvas.SetTop(this.MyDataLabel, top);
            }
        }
    }
}
