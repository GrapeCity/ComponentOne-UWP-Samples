using System;
using Windows.UI.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for HeikinAshi.xaml
    /// </summary>
    public partial class HeikinAshi : Page
    {
        DataService dataService = DataService.GetService();

        public HeikinAshi()
        {
            InitializeComponent();
            this.Loaded += HeikinAshi_Loaded; ;
        }

        void HeikinAshi_Loaded(object sender, RoutedEventArgs e)
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
