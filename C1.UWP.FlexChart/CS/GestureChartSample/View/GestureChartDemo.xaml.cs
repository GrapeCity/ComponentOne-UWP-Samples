using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GestureChartSample
{
    public sealed partial class GestureChartDemo : UserControl
    {
        public GestureChartDemo()
        {
            this.InitializeComponent();
        }

        private void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            gestureChart.AxisX.Min = double.NaN;
            gestureChart.AxisX.Max = double.NaN;
            gestureChart.AxisY.Min = double.NaN;
            gestureChart.AxisY.Max = double.NaN;
        }
    }
}
