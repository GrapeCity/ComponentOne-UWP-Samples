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
    public sealed partial class MainSample : Page
    {
        private SampleData sampleData = new SampleData();
        public MainSample()
        {
            this.InitializeComponent();
            sparklineType.ItemsSource = Enum.GetValues(typeof(SparklineType));
            sparklineType.SelectedItem = sparkline.SparklineType;
            sparkline.Data = sampleData.DefaultData;

        }

        private void sparklineType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sparkline.SparklineType = (SparklineType)sparklineType.SelectedItem;
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked.Value)
            {
                sparkline.DateAxisData = sampleData.DefaultDateAxisData;
            }
            else
            {
                if (sparkline.DateAxisData != null)
                    sparkline.DateAxisData = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cnt = 12;
            double[] vals = new double[cnt];
            Random rnd = new Random();
            for (int i=0; i< cnt; i++)
            {
                vals[i] = rnd.Next(-50, 50);
            }
            sparkline.Data = vals;
        }
    }
}
