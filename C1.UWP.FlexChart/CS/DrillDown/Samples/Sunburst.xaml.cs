using C1.Xaml.Chart;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DrillDown
{
    public sealed partial class SunburstSample : Page
    {
        private DrillDownViewModel _vm;
        public SunburstSample()
        {
            this.InitializeComponent();
            _vm = new DrillDownViewModel();
            this.DataContext = _vm;
        }

    }
}
