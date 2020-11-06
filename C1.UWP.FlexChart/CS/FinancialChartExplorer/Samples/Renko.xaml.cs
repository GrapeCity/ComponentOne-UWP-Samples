using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using C1.Chart.Finance;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for Renko.xaml
    /// </summary>
    public partial class Renko : Page
    {
        DataService dataService = DataService.GetService();

        public Renko()
        {
            InitializeComponent();
            this.Loaded += Renko_Loaded;
        }

        public List<Company> Companies
        {
            get
            {
                return dataService.GetCompanies();
            }
        }

        public List<string> RangeMode
        {
            get
            {
                return Enum.GetNames(typeof(RangeMode)).ToList();
            }
        }

        public List<string> DataFields
        {
            get
            {
                return Enum.GetNames(typeof(DataFields)).ToList();
            }
        }

        void Renko_Loaded(object sender, RoutedEventArgs e)
        {
            cbSymbol.SelectedIndex = 0;
        }

        void OnSymbolSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (financialChart != null)
            {
                Company c = cbSymbol.SelectedValue as Company;
                var data = dataService.GetSymbolData(c.Symbol);
                financialChart.BeginUpdate();
                financialChart.ItemsSource = data;
                financialChart.EndUpdate();
            }
        }
    }
}
