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
using System.Collections.ObjectModel;

namespace SparklineSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegionSales : Page
    {
        public RegionSales()
        {
            this.InitializeComponent();

            Random rnd = new Random();
            string state = Strings.StatesColumnValue;
            string[] states = state.Split('|');
            this.Sales = new ObservableCollection<RegionSalesData>();
            for (int i = 0; i < states.Length; i++)
            {
                RegionSalesData rsd = new RegionSalesData();
                rsd.State = states[i];
                rsd.Data = new ObservableCollection<double>();
                for(int j = 0; j < 12; j++)
                {
                    double d = rnd.Next(-50, 50);
                    rsd.Data.Add(d);
                    rsd.NetSales += d;
                    rsd.TotalSales += Math.Abs(d);
                }
                this.Sales.Add(rsd);
            }

            this.DataContext = this;
        }

        public ObservableCollection<RegionSalesData> Sales { get; private set; }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 540)
            {
                region.Width = 60;
                totalSale.Width = 100;
                profitTrend.Width = 200;
                salesTrend.Width = 200;
                winLoss.Width = 200;
                RegionSalesListBox.ItemTemplate = (DataTemplate)Root.Resources["largeListBox"];
                ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else
            {
                region.Width = 25;
                totalSale.Width = 45;
                salesTrend.Width = 75;
                winLoss.Width = 75;
                profitTrend.Width = 75;
                RegionSalesListBox.ItemTemplate = (DataTemplate)Root.Resources["smallListBox"];
                ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }
    }

    public class RegionSalesData
    {
        public ObservableCollection<double> Data { get; set; }
        public string State { get; set; }
        public double TotalSales { get; set; }
        public string TotalSalesFormatted
        {
            get
            {
                return String.Format("{0:c2}", this.TotalSales);
            }
        }
        public double NetSales { get; set; }
    }
}
