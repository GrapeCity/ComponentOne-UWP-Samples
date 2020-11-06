using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using C1.Chart.Finance;
using C1.Xaml.Chart.Finance;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for Renko.xaml
    /// </summary>
    public partial class PointAndFigure : Page
    {
        DataService dataService = DataService.GetService();

        public PointAndFigure()
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

        public List<string> Scalings
        {
            get
            {
                return Enum.GetNames(typeof(PointAndFigureScaling)).ToList();
            }
        }

        public List<string> DataFields
        {
            get
            {
                return new List<string>() { "Close", "HighLow" };
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

        private void cbScaling_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (financialChart != null)
            {
                if (boxSize != null)
                    boxSize.IsEnabled = ((PointAndFigureOptions)financialChart.Options).Scaling == PointAndFigureScaling.Fixed;
                if (period != null)
                    period.IsEnabled = ((PointAndFigureOptions)financialChart.Options).Scaling == PointAndFigureScaling.Dynamic;
            }
        }
    }
}
