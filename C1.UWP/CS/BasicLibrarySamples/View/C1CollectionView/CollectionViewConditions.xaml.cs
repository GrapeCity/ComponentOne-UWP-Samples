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
using System.Reflection;
using C1.Xaml;

namespace BasicLibrarySamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollectionViewConditions : Page
    {
        private readonly C1CollectionView _c1CollectionView;
        private string NoneItem = Strings.CollectionViewNoneItem;

        public CollectionViewConditions()
        {
            this.InitializeComponent();

            IList<string> fieldNames = new string[] { Strings.CollectionViewCustomerPropertyID, Strings.CollectionViewCustomerPropertyName, Strings.CollectionViewCustomerPropertyCountry, Strings.CollectionViewCustomerPropertyActive, Strings.CollectionViewCustomerPropertyCreated, Strings.CollectionViewCustomerPropertySales, Strings.CollectionViewCustomerPropertyGrowth };
          

            chooseSortFields.FieldNames = fieldNames;
            
            List<string> groupFields = new List<string>(fieldNames);
            groupFields.Sort();
            groupFields.Remove(Strings.CollectionViewCustomerPropertyActive);
            List<string> filterFields = new List<string>(groupFields);
            groupFields.Insert(0, NoneItem);
            groupComboBox.ItemsSource = groupFields;
            groupComboBox.SelectedItem = NoneItem;
            filterComboBox.ItemsSource = filterFields;
            filterComboBox.SelectedIndex = 0;


            ObservableCollection<Customer> customers = Customer.GetCollection(50);
            _c1CollectionView = new C1CollectionView();
            _c1CollectionView.SourceCollection = customers;

            listBox1.ItemsSource = _c1CollectionView;
            //gridView1.ItemsSource = _c1CollectionView;

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

        void UpdateSorting()
        {
            using (_c1CollectionView.DeferRefresh())
            {
                _c1CollectionView.SortDescriptions.Clear();
                foreach (string fieldName in chooseSortFields.SelectedFieldNames)
                {
                    _c1CollectionView.SortDescriptions.Add(new SortDescription(fieldName, ListSortDirection.Ascending));
                }
            }
        }

        void UpdateGrouping()
        {
            if (_c1CollectionView == null)
                return;
            using (_c1CollectionView.DeferRefresh())
            {
                _c1CollectionView.GroupDescriptions.Clear();
                if (groupComboBox.SelectedItem != NoneItem)
                {
                    //_c1CollectionView.GroupDescriptions.Add(new PropertyGroupDescription((string)groupComboBox.SelectedItem));
                    _c1CollectionView.GroupDescriptions.Add(new PropertyGroupDescription(GetGroupPropertyName(groupComboBox.SelectedIndex)));

                }
            }
        }

        string GetGroupPropertyName(int selectedIndex)
        {
            string selectedProperty = null;
            switch (selectedIndex)
            {
                case 1:
                    selectedProperty = "Country";
                    break;
                case 2:
                    selectedProperty = "Created";
                    break;
                case 3:
                    selectedProperty = "Growth";
                    break;
                case 4:
                    selectedProperty = "ID";
                    break;
                case 5:
                    selectedProperty = "Name";
                    break;
                case 6:
                    selectedProperty = "Sales";
                    break;
                default:
                    selectedProperty = "NoneItem";
                    break;
            }
            return selectedProperty;
        }

        void UpdateFiltering()
        {
            if (filterTextBox.Text.Length == 0)
                _c1CollectionView.Filter = null;
            else
            {
                if (_c1CollectionView.Filter == null)
                    _c1CollectionView.Filter = FilterFunction;
                else
                    _c1CollectionView.Refresh();
            }
        }

        bool FilterFunction(object customer)
        {
            Customer cust = customer as Customer;
            if (cust == null)
                return false;
            object propValue = null;

            String selectedItem = (string)filterComboBox.SelectedItem;

            if (selectedItem == Strings.CollectionViewCustomerPropertyID)
            {
                propValue = cust.ID;
            }
            else if (selectedItem == Strings.CollectionViewCustomerPropertyName)
            {
                propValue = cust.Name;
            }
            else if (selectedItem == Strings.CollectionViewCustomerPropertyCountry)
            {
                propValue = cust.Country;
            }
            else if (selectedItem == Strings.CollectionViewCustomerPropertyCreated)
            {
                propValue = cust.Created;
            }
            else if (selectedItem == Strings.CollectionViewCustomerPropertySales)
            {
                propValue = cust.Sales;
            }
            else if (selectedItem == Strings.CollectionViewCustomerPropertyGrowth)
            {
                propValue = cust.Growth;
            }
            else
            {
                return true;
            }
            if (propValue == null)
                return false;
            return propValue.ToString().StartsWith(filterTextBox.Text, StringComparison.CurrentCultureIgnoreCase);
        }

        private void chooseSortFields_SelectedFieldNamesChanged_1(object sender, EventArgs e)
        {
            UpdateSorting();
        }

        private void groupComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateGrouping();
        }

        private void filterTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            UpdateFiltering();
        }

        private void filterComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            filterTextBox.Text = "";
        }

    }
}
