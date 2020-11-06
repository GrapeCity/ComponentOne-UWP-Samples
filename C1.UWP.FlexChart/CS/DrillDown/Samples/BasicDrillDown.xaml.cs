using C1.Xaml.Chart;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace DrillDown
{
    public partial class BasicDrillDownSample : Page
    {
        private DrillDownViewModel _vm;
        private bool isDrillDownEnabled = true;
        public BasicDrillDownSample()
        {
            InitializeComponent();
            _vm = new DrillDownViewModel();
            this.DataContext = _vm;
            _vm.Manager.BeforeDrill += Manager_BeforeDrill;
            _vm.Manager.AfterDrill += Manager_AfterDrill;
            _vm.Manager.Refresh();

            this.Loaded += (o, e) =>
            {
                cbAggregate.SelectedIndex = 0;
                cbChartTypes.SelectedIndex = 0;
            };           
        }

        private void Manager_AfterDrill(object sender, DrillDownEventArgs e)
        {
            if (flexChart.Visibility == Windows.UI.Xaml.Visibility.Visible)
            {
                switch (e.DrillDownPath)
                {
                    case "Country":
                    case "City":
                    default:
                        flexChart.ChartType = C1.Chart.ChartType.Column;
                        break;
                    case "Year":
                        flexChart.ChartType = C1.Chart.ChartType.LineSymbols;
                        break;
                }
            }
            flexChart.Footer = pieChart.Footer = string.Format("{0}-wise sales", e.DrillDownPath);
        }

        private void Manager_BeforeDrill(object sender, DrillDownEventArgs e)
        {
            e.Cancel = !isDrillDownEnabled;
        }

        private void Chart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var flexChart = sender as FlexChartBase;
            var hitInfo = flexChart.HitTest(e.GetPosition(flexChart));
            if (hitInfo != null && hitInfo.Distance < 2)
            {
                _vm.Manager.DrillDown(hitInfo.PointIndex);                
            }
        }

        private void OnCheckChanged(object sender, RoutedEventArgs e)
        {
            isDrillDownEnabled = (bool)chkEnableDrillDown.IsChecked;
        }
    }
}
