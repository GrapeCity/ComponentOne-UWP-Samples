using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StockAnalysis.Partial.UserControls
{
    public sealed partial class Settings : UserControl
    {        
        public Settings()
        {
            this.InitializeComponent();
        }
        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }

        private async void TryShowDisableMessage(string msg)
        {
            if (ViewModel.ViewModel.Instance.ChartType == C1.Chart.Finance.FinancialChartType.Kagi ||
                ViewModel.ViewModel.Instance.ChartType == C1.Chart.Finance.FinancialChartType.Renko ||
                ViewModel.ViewModel.Instance.ChartType == C1.Chart.Finance.FinancialChartType.PointAndFigure)
            {
                indicatorsDropdown.IsDropDownOpen = false;
                overlaysDropdown.IsDropDownOpen = false;
                var dialog = new MessageDialog(msg);
                await dialog.ShowAsync();
            }
        }

        private void indicatorsDropdown_DropDownOpened(object sender, object e)
        {
            TryShowDisableMessage(String.Message.DisableIndicatorMessage);
        }

        private void overlaysDropdown_DropDownOpened(object sender, object e)
        {
            TryShowDisableMessage(String.Message.DisableOverlayMessage);
        }
    }
}
