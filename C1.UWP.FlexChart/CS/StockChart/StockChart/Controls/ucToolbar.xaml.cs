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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace StockChart
{
    public sealed partial class ucToolbar : UserControl
    {
        public ucToolbar()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel.ChartViewModel.Instance;

            this.Loaded += (o, e) =>
            {
                this.cmbChartType.SelectedIndex = 0;
                this.cmbMovingAverageType.SelectedIndex = 0;
            };
        }

        private void cmbExport_DropDownClosed(object sender, object e)
        {
            if (ViewModel.ChartViewModel.Instance.ExportCommand != null && cmbExport.SelectedValue != null)
            {
                ViewModel.ChartViewModel.Instance.ExportCommand.Execute(((KeyValuePair<string, string>)(cmbExport.SelectedValue)).Value);
            }
            cmbExport.SelectedIndex = -1;
        }
    }
}
