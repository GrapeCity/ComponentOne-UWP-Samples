using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using C1.Chart.Finance;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for Kagi.xaml
    /// </summary>
    public partial class Kagi : Page
    {
        DataService dataService = DataService.GetService();

        public Kagi()
        {
            InitializeComponent();
            this.Loaded += Kagi_Loaded;
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

        void Kagi_Loaded(object sender, RoutedEventArgs e)
        {
            cbSymbol.SelectedIndex = 0;
            cbRangeMode.SelectedIndex = 0;
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

        private void OnRangeModeChanged(object sender, SelectionChangedEventArgs e)
        {
            var rmode = cbRangeMode.SelectedValue as string;
            financialChart.BeginUpdate();
            if (rmode == "Fixed")
            {
                cbReversalAmount.Minimum = 1;
                cbReversalAmount.Maximum = 14;
                cbReversalAmount.Increment = 1;
                cbReversalAmount.Format = "0";
                financialChart.Options.RangeMode = C1.Chart.Finance.RangeMode.Fixed;
            }
            else if (rmode == "ATR")
            {
                cbReversalAmount.Minimum = 2;
                cbReversalAmount.Maximum = 14;
                cbReversalAmount.Increment = 1;
                cbReversalAmount.Format = "0";
                if (financialChart.Options.ReversalAmount < 2)
                    financialChart.Options.ReversalAmount = 2;
                financialChart.Options.RangeMode = C1.Chart.Finance.RangeMode.ATR;
            }
            else
            {
                cbReversalAmount.Minimum = 0;
                cbReversalAmount.Maximum = 1;
                cbReversalAmount.Format = "0.00";
                cbReversalAmount.Increment = 0.05;
                if (cbReversalAmount.Value >= 1)
                    cbReversalAmount.Value = 0.05;
                financialChart.Options.RangeMode = C1.Chart.Finance.RangeMode.Percentage;
            }
            financialChart.EndUpdate();
        }
    }
}
