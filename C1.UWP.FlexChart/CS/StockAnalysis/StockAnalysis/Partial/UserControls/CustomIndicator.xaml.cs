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
    public sealed partial class CustomIndicator : UserControl
    {
        public CustomIndicator()
        {
            this.InitializeComponent();
        }
        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }

        private void SettableCheckBox_Checked(object sender, RoutedEventArgs e)
        {            
            var check = sender as CustomControls.SettableCheckBox;               

            Type type = Type.GetType("StockAnalysis.Partial.CustomControls.CustomIndicator." + check.Tag);

            if (type != null && Model.IndicatorCharts.Count < 3 && !Model.IndicatorCharts.Contains(type))
            {
                Model.IndicatorCharts.Add(type);
            }
            else
            {
                var dialog = new MessageDialog(String.Message.MaximumIndicatorMessage);
                var task = System.Threading.Tasks.Task.Run(() => dialog.ShowAsync());               
                check.IsChecked = false;
            }
        }

        private void SettableCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var check = sender as CustomControls.SettableCheckBox;
            if (check != null)
            {
                Type type = Type.GetType("StockAnalysis.Partial.CustomControls.CustomIndicator." + check.Tag);
                if (Model.IndicatorCharts.Contains(type))
                    Model.IndicatorCharts.Remove(type);
            }
        }
    }
}

