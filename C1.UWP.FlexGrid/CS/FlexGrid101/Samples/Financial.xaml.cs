using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public partial class Financial : Page
    {
        FinancialDataList _financialData;
        bool _loaded = false;

        public Financial()
        {
            InitializeComponent();
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, PopulateFinancialGrid);
            _flexFinancial.Loaded += _flexFinancial_Loaded;
            _flexFinancial.Unloaded += _flexFinancial_Unloaded;
        }

        private void _flexFinancial_Unloaded(object sender, RoutedEventArgs e)
        {
            _loaded = false;
            _flexFinancial.ScrollPositionChanging -= _flexFinancial_ScrollPositionChanging;
            _flexFinancial.ScrollPositionChanged -= _flexFinancial_ScrollPositionChanged;
            if (_financialData != null)
            {
                _financialData.AutoUpdate = false;
            }
        }

        private void _flexFinancial_Loaded(object sender, RoutedEventArgs e)
        {
            if (Util.IsWindowsPhoneDevice())
            {
                SymbolColumn.Width = new GridLength(50);
                NameColumn.Visible = false;
            }
            if (_financialData != null)
            {
                _financialData.AutoUpdate = _chkAutoUpdate.IsChecked.Value;
            }
            _flexFinancial.ScrollPositionChanging += _flexFinancial_ScrollPositionChanging;
            _flexFinancial.ScrollPositionChanged += _flexFinancial_ScrollPositionChanged;
            _loaded = true;
        }

        async void PopulateFinancialGrid()
        {
            // populate the grid
            _financialData = await FinancialData.GetFinancialData();
            var view = new C1.Xaml.C1CollectionView(_financialData);
            if (!_loaded)
            {
                _financialData.AutoUpdate = false;
            }
            _flexFinancial.ItemsSource = view;
            view.VectorChanged += View_VectorChanged;

            // configure search box
            _srchCompanies.View = view;
            var props = _srchCompanies.FilterProperties;
            props.Add(typeof(FinancialData).GetRuntimeProperty("Name"));
            props.Add(typeof(FinancialData).GetRuntimeProperty("Symbol"));

            // show company info
            UpdateCompanyStatus();
            UpdateCellFactory();
        }

        void _flexFinancial_ScrollPositionChanged(object sender, EventArgs e)
        {
            _financialData.AutoUpdate = _chkAutoUpdate.IsChecked.Value;
        }

        void _flexFinancial_ScrollPositionChanging(object sender, EventArgs e)
        {
            // suspend data updates during scrolling
            _financialData.AutoUpdate = false;
        }

        void View_VectorChanged(Windows.Foundation.Collections.IObservableVector<object> sender, Windows.Foundation.Collections.IVectorChangedEventArgs @event)
        {
            UpdateCompanyStatus();
        }

        // update song status
        void UpdateCompanyStatus()
        {
            var view = _flexFinancial.ItemsSource as ICollectionView;
            var companies = view.OfType<FinancialData>();
            _txtCompanies.Text = string.Format(Strings.CompaniesInfo,
                (from c in companies select c.Symbol).Distinct().Count());
        }

        // control update frequency
        void _chkAutoUpdate_Click(object sender, RoutedEventArgs e)
        {
            _financialData.AutoUpdate = ((CheckBox)sender).IsChecked.Value;
        }
        void _cmbUpdateInterval_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_financialData != null)
            {
                var cmb = sender as ComboBox;
                var index = cmb.SelectedIndex;
                int ms = 10000;
                switch (index)
                {
                    case 1:
                        ms = 1000;
                        break;
                    case 2:
                        ms = 500;
                        break;
                }
                _financialData.UpdateInterval = ms;
            }
        }
        void _cmbBatchSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_financialData != null)
            {
                var cmb = sender as ComboBox;
                var val = ((ComboBoxItem)cmb.SelectedItem).Content as string;
                _financialData.BatchSize = int.Parse(val);
            }
        }
        void _chkOwnerDrawFinancial_Click(object sender, RoutedEventArgs e)
        {
            UpdateCellFactory();
        }

        private void UpdateCellFactory()
        {
            _flexFinancial.CellFactory = _chkOwnerDrawFinancial.IsChecked.Value
                ? new FinancialCellFactory()
                : null;
        }

        private void _cmbHeadersVisibility_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cmbHeadersVisibility != null && _flexFinancial != null)
                _flexFinancial.HeadersVisibility = (HeadersVisibility)Enum.Parse(typeof(HeadersVisibility), ((ComboBoxItem)_cmbHeadersVisibility.SelectedItem).Content as string);
        }

        private void _flexFinancial_CellContentChanging(C1FlexGrid sender, CellContentChangingEventArgs args)
        {
            if (args.Phase == 0)
            {
                args.RegisterUpdateCallback(_flexFinancial_CellContentChanging);
            }
            else if (args.Phase == 1)
            {
                var factory = _flexFinancial.CellFactory as FinancialCellFactory;
                if (factory != null)
                    factory.ShowLiveData(_flexFinancial, args.Range, args.Cell);
            }
        }
    }
}
