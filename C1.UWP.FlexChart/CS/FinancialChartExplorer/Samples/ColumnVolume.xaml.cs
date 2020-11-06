using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using C1.Xaml.Chart.Finance;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for ColumnVolume.xaml
    /// </summary>
    public partial class ColumnVolume : Page
    {
        DataService dataService = DataService.GetService();

        public ColumnVolume()
        {
            InitializeComponent();
            this.Loaded += ColumnVolume_Loaded;
        }

        void ColumnVolume_Loaded(object sender, RoutedEventArgs e)
        {
            financialChart.Series.Clear();
            financialChart.Series.Add(new FinancialSeries());
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

        public List<Company> Companies
        {
            get
            {
                return dataService.GetCompanies();
            }
        }
    }
}
