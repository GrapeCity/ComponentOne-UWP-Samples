using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for CandleVolume.xaml
    /// </summary>
    public partial class CandleVolume : Page
    {
        DataService dataService = DataService.GetService();

        public CandleVolume()
        {
            InitializeComponent();
            this.Loaded += CandleVolume_Loaded;
        }

        void CandleVolume_Loaded(object sender, RoutedEventArgs e)
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

        public List<Company> Companies
        {
            get
            {
                return dataService.GetCompanies();
            }
        }
    }
}
