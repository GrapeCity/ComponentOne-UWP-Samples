using C1.Xaml.Chart;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace DrillDown
{
    public sealed partial class TreemapSample : Page
    {
        private DrillDownViewModel _vm;
        public TreemapSample()
        {
            this.InitializeComponent();
            _vm = new DrillDownViewModel();
            this.DataContext = _vm;
        }
        
    }


}
