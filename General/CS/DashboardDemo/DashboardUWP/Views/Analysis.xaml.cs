using C1.Xaml;
using C1.Xaml.Maps;
using DashboardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ListCollectionView = C1.Xaml.C1CollectionView;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DashboardUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Analysis : Page, IUpdatablePage
    {
        ListCollectionView collectionView;
        C1VectorLayer vectorLayer;
        C1VectorLayer scaleLayer;

        public Analysis()
        {
            this.InitializeComponent();
        }

        public void UpdataPage()
        {
            FunelChart.ItemsSource = DataService.GetService().OpportunityItemList;
            C1MapHelper.UpdataMapMark(vectorLayer,scaleLayer, MainPage.IsWindowsPhoneDevice());
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ScaleMapPane.Visibility = ScaleMapPane.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            vectorLayer = new C1VectorLayer();
            Map.Source = new VirtualEarthRoadSource();
            Map.Layers.Add(vectorLayer);
            if(!MainPage.IsWindowsPhoneDevice())
            {
                scaleLayer = new C1VectorLayer();
                ScaleMap.Source = new VirtualEarthRoadSource();
                ScaleMap.Layers.Add(scaleLayer);
            }
            collectionView = DataService.GetService().ProductWiseSaleCollection;
            ProductList.ItemsSource = DataService.GetService().ProductList;
            RegionList.ItemsSource = DataService.GetService().RegionList;
            ProductList.SelectAll();
            RegionList.SelectAll();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            collectionView.Filter = null;
            collectionView.Filter = new Predicate<object>(FilterBySelectedProductsAndRegions);
            UpdateChartItemSource();
        }

        void UpdateChartItemSource()
        {
            var list = new List<RegionVsProductSale>();
            foreach(var region in DataService.GetService().RegionList)
            {
                IEnumerable<ProductsWiseSaleItem> items = from item in collectionView
                            where (item as ProductsWiseSaleItem).Region == region.Name
                            select item as ProductsWiseSaleItem;
                double sumSales = items.Sum(x => x.Sale);
                RegionVsProductSale salesItem = new RegionVsProductSale();
                salesItem.Name = region.ToString();
                salesItem.Sales = sumSales;
                list.Add(salesItem);
            }
            ProductWiseSales.ItemsSource = list;
        }

        bool FilterBySelectedProductsAndRegions(object productsWiseSaleItem)
        {
            foreach (Region region in RegionList.SelectedItems)
            {
                if (region.Name == (productsWiseSaleItem as ProductsWiseSaleItem).Region)
                {
                    foreach (Product product in ProductList.SelectedItems)
                    {
                        if (product.Name == (productsWiseSaleItem as ProductsWiseSaleItem).Product)
                            return true;
                    }
                }
            }
            return false;
        }
    }

    public class RegionVsProductSale
    {
        public string Name { get; set; }
        public double Sales { get; set; }
    }
}
