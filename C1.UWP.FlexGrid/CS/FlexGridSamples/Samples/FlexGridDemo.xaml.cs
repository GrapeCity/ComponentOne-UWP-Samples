using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FlexGridSamples
{
    public sealed partial class FlexGridDemo : Page
    {
        C1.Xaml.C1CollectionView _view;

        public FlexGridDemo()
        {
            this.InitializeComponent();
            // create an observable list of customers
            var list = new System.Collections.ObjectModel.ObservableCollection<Customer>();
            for (int i = 0; i < 1000; i++)
                list.Add(new Customer());

            // create a C1CollectionView from the list 
            // (it supports sorting, filtering, and grouping)
            _view = new C1.Xaml.C1CollectionView(list);

            // sort and group customers by country
            _view.SortDescriptions.Add(new C1.Xaml.SortDescription("Country", C1.Xaml.ListSortDirection.Ascending));
            _view.GroupDescriptions.Add(new C1.Xaml.PropertyGroupDescription("Country"));

            // for MVVM scenarios, simply make the C1CollectionView an exposed property on the view model and bind to it
            c1FlexGrid1.ItemsSource = _view;

            //c1FlexGrid1.FrozenColumns = 2;
            c1FlexGrid1.Columns["Weight"].GroupAggregate = C1.Xaml.FlexGrid.Aggregate.Sum;
        }

        private void mergeCountry_Click(object sender, RoutedEventArgs e)
        {
            c1FlexGrid1.Columns["Country"].AllowMerging = (bool)mergeCountry.IsChecked;
        }
    }
}
