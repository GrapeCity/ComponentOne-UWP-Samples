using DashboardModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DashboardUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Page, IUpdatablePage
    {
        public Dashboard()
        {
            this.InitializeComponent();
        }

        public void UpdataPage()
        {
            TopSaleProducts.ItemsSource = DataService.GetService().GetTopSaleProductList(3);
            TopSaleCustomer.ItemsSource = DataService.GetService().GetTopSaleCustomerList(7);
            TopSaleCustomer.CellFactory = new CellFormatFactory();
            RegionSales.ItemsSource = DataService.GetService().RegionSalesVsGoal;
            CategortySales.ItemsSource = DataService.GetService().CategorySalesVsGoal;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CurrentProfitVSPriorProfit.ItemsSource = DataService.GetService().BudgetItemList;
            SalesAndProfits.ItemsSource = DataService.GetService().BudgetItemList;
        }
    }
}
