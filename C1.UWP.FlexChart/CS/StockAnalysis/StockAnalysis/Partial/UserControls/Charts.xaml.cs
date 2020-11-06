using C1.Chart.Finance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Charts : UserControl
    {
        public Charts()
        {
            this.InitializeComponent();
            EventHandler<C1.Xaml.Chart.RenderEventArgs> handlerInitRange = null;
            handlerInitRange = (o, e) =>
            {
                if (
                !ViewModel.ViewModel.Instance.IsLoaded &&
                ViewModel.ViewModel.Instance.CurrectQuote != null &&
                ViewModel.ViewModel.Instance.CurrectQuote.Data != null &&
                (
                (ViewModel.ViewModel.Instance.LowerValue == 0 || ViewModel.ViewModel.Instance.LowerValue == null)
                && ViewModel.ViewModel.Instance.UpperValue == 0 || ViewModel.ViewModel.Instance.UpperValue == null)                
                )
                {
                    ViewModel.ViewModel.Instance.UpperValue = ViewModel.ViewModel.Instance.CurrectQuote.Data.Count() - 1;
                    ViewModel.ViewModel.Instance.LowerValue = ViewModel.ViewModel.Instance.UpperValue - 60;

                    ViewModel.ViewModel.Instance.IsLoaded = true;
                    this.rangeChart.Rendered -= handlerInitRange;
                }
            };
            this.rangeChart.Rendered += handlerInitRange;

            ViewModel.ViewModel.Instance.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "ChartType")
                {
                    if (ViewModel.ViewModel.Instance.ChartType == FinancialChartType.Kagi ||
                        ViewModel.ViewModel.Instance.ChartType == FinancialChartType.Renko ||
                        ViewModel.ViewModel.Instance.ChartType == FinancialChartType.PointAndFigure)
                    {
                        this.krChart.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.krChart.Visibility = Visibility.Collapsed;
                    }
                }

            };
        }
        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }
    }
}
