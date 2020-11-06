using C1.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexGrid101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Grouping : Page
    {
        ObservableCollection<Customer> _collectionView;
        public Grouping()
        {
            this.InitializeComponent();

            UpdateVideos();
        }

        private void UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _collectionView = new ObservableCollection<Customer>(data);
            var listCollectionView = new C1CollectionView(_collectionView);
            listCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Country"));
            grid.ItemsSource = listCollectionView;
            grid.MinColumnWidth = 85;
        }
    }
}
