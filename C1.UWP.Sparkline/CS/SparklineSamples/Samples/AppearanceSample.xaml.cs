using C1.Xaml.Sparkline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SparklineSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppearanceSample : Page
    {
        public AppearanceSample()
        {
            this.InitializeComponent();
            this.Loaded += AppearanceSample_Loaded;
        }

        private void AppearanceSample_Loaded(object sender, RoutedEventArgs e)
        {
            sparklineType.SelectedIndex = 0;
            SeriesColor.SelectedIndex = 1;
            MarksColor.SelectedIndex = 2;
            HightMarkColor.SelectedIndex = 1;
            LowMarkColor.SelectedIndex = 2;
            FirstMarkColor.SelectedIndex = 7;
            LastMarkColor.SelectedIndex = 1;
            NegativeColor.SelectedIndex = 1;
            XAxisColor.SelectedIndex = 3;
        }
    }
}
