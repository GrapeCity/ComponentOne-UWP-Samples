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
using System.Collections.ObjectModel;
using C1.Xaml;

namespace BasicLibrarySamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BindingToC1CollectionView : Page
    {
        private readonly C1CollectionView _c1CollectionView;
        
        public BindingToC1CollectionView()
        {
            this.InitializeComponent();

            ObservableCollection<Customer> customers = Customer.GetCollection(50);
            _c1CollectionView = new C1CollectionView();
            _c1CollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Country"));
            _c1CollectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            _c1CollectionView.SourceCollection = customers.Distinct(new SourceComparer());

            listBox1.ItemsSource = _c1CollectionView;
            gridView1.ItemsSource = _c1CollectionView;

            //filterCheckBox.IsChecked = null;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrollViewer.HorizontalScrollBarVisibility = e.NewSize.Width > 540 ? ScrollBarVisibility.Disabled : ScrollBarVisibility.Visible;
        }

#if false
        private void filterCheckBox_Click_1(object sender, RoutedEventArgs e)
        {
            bool? isActive = filterCheckBox.IsChecked;
            if (!isActive.HasValue)
                _c1CollectionView.Filter = null;
            else if (isActive.Value)
                _c1CollectionView.Filter = IsActiveFilter;
            else
                _c1CollectionView.Filter = IsInactiveFilter;
        }

        bool IsActiveFilter(object customer)
        {
            return ((Customer)customer).Active;
        }

        bool IsInactiveFilter(object customer)
        {
            return !((Customer)customer).Active;
        }
#endif

    }

    /// <summary>
    /// A distinct compare for data source.
    /// </summary>
    public class SourceComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            if (x.Name.Equals(y.Name) && x.Country.Equals(y.Country))
                return true;
            else
                return false;
        }

        public int GetHashCode(Customer obj)
        {
            return 0;
        }
    }
}
