using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for ArmsCandleVolume.xaml
    /// </summary>
    public partial class ArmsCandleVolume : Page
    {
        DataService dataService = DataService.GetService();

        public ArmsCandleVolume()
        {
            InitializeComponent();
            this.Loaded += ArmsCandleVolume_Loaded;
        }

        void ArmsCandleVolume_Loaded(object sender, RoutedEventArgs e)
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
