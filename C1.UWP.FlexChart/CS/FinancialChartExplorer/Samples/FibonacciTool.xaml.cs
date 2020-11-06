using C1.Chart;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FinancialChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FibonacciTool : Page
    {
        DataService dataService = DataService.GetService();

        public FibonacciTool()
        {
            this.InitializeComponent();
            this.Loaded += FibonacciTool_Loaded;
        }

        public List<Quote> Data
        {
            get
            {
                return dataService.GetSymbolData("box", 87);
            }
        }

        public List<string> FibonacciTypes
        {
            get
            {
                return Strings.FibonacciTypes.Split(',').ToList();
            }
        }

        public List<string> Uptrends
        {
            get
            {
                return new List<string>() { bool.TrueString, bool.FalseString };
            }
        }

        public List<string> Positions
        {
            get
            {
                return Strings.Positions.Split(',').ToList();
            }
        }

        public List<string> VerticalPositions
        {
            get
            {
                return Strings.VerticalPositions.Split(',').ToList();
            }
        }

        public List<string> TimeZonesPositions
        {
            get
            {
                return Strings.TimeZonesPositions.Split(',').ToList();
            }
        }

        private void FibonacciTool_Loaded(object sender, RoutedEventArgs e)
        {
            cbFibonacciTypes.SelectedIndex = 2;
        }

        private void cbFibonacciTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = cbFibonacciTypes.SelectedIndex;
            if (selectedIndex == -1)
                return;

            rangeSelector.Visibility = Visibility.Collapsed;
            foreach (var ser in financialChart.Series)
            {
                if (ser == fs)
                    continue;

                ser.Visibility = SeriesVisibility.Hidden;
            }
            switch (selectedIndex)
            {
                case 0:
                    arc.Visibility = SeriesVisibility.Visible;
                    break;
                case 1:
                    fans.Visibility = SeriesVisibility.Visible;
                    break;
                case 2:
                    fibonacci.Visibility = SeriesVisibility.Visible;
                    if (cbRangeSelector.IsChecked.Value)
                        rangeSelector.Visibility = Visibility.Visible;
                    break;
                case 3:
                    timeZones.Visibility = SeriesVisibility.Visible;
                    break;
            }
        }

        private void C1RangeSelector_ValueChanged(object sender, EventArgs e)
        {
            if (fibonacci != null)
            {
                financialChart.BeginUpdate();
                fibonacci.MinX = rangeSelector.LowerValue;
                fibonacci.MaxX = rangeSelector.UpperValue;
                financialChart.EndUpdate();
            }
        }

        private void cbRangeSelector_Checked(object sender, RoutedEventArgs e)
        {
            if (rangeSelector != null)
                rangeSelector.Visibility = Visibility.Visible;
        }

        private void cbRangeSelector_Unchecked(object sender, RoutedEventArgs e)
        {
            if (rangeSelector != null)
                rangeSelector.Visibility = Visibility.Collapsed;
        }

        private void OnSplitterButtonClick(object sender, RoutedEventArgs e)
        {
            if (splitter != null)
            {
                splitter.IsPaneOpen = !splitter.IsPaneOpen;
            }
        }
    }
}
