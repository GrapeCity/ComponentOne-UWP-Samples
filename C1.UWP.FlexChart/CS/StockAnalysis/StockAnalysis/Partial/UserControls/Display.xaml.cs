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
    public sealed partial class Display : UserControl
    {
        public Display()
        {
            this.InitializeComponent();
        }
        public FinancialChartType ChartType
        {
            get { return (FinancialChartType)this.GetValue(ChartTypeProperty); }
            set { this.SetValue(ChartTypeProperty, value); }
        }
        public static DependencyProperty ChartTypeProperty = DependencyProperty.Register(
            "ChartType",
            typeof(FinancialChartType),
            typeof(Display),
            new PropertyMetadata(FinancialChartType.Candlestick)
        );

        private void SettableRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var btn = sender as CustomControls.SettableRadioButton;
            if (btn.Tag != null)
                this.ChartType = (FinancialChartType)btn.Tag;

            if (this.ChartType != FinancialChartType.Renko &&
                this.ChartType != FinancialChartType.Kagi &&
                this.ChartType != FinancialChartType.PointAndFigure)
            {
                Command.CloseDropdownCommand cmd = new Command.CloseDropdownCommand();
                cmd.Execute(this);
            }
            else
            {
                btn.IsShowSetting = true;
            }           
        }

        private void SettableRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            var btn = sender as CustomControls.SettableRadioButton;
            if (this.ChartType == FinancialChartType.Renko ||
                this.ChartType == FinancialChartType.Kagi ||
                this.ChartType == FinancialChartType.PointAndFigure)
            {
                btn.IsShowSetting = false;
            }
        }
    }
}
