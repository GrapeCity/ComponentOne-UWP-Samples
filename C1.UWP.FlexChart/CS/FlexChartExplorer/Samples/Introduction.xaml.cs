using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using System.Linq;
using C1.Chart;
using C1.Xaml.Chart;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Introduction : Page
    {
        Dictionary<ChartType, string> _chartTypes;
        List<FruitDataItem> _fruits;
        List<string> _palettes;
        List<string> _stackings;

        public Introduction()
        {
            this.InitializeComponent();
        }

        public Dictionary<ChartType, string> ChartTypes
        {
            get
            {
                if (_chartTypes == null)
                {
                    _chartTypes = DataCreator.CreateSimpleChartTypes();
                }

                return _chartTypes;
            }
        }

        public List<string> Palettes
        {
            get
            {
                if (_palettes == null)
                {
                    _palettes = Enum.GetNames(typeof(Palette)).ToList();
                }

                return _palettes;
            }
        }

        public List<string> Stackings
        {
            get
            {
                if (_stackings == null)
                {
                    _stackings = Enum.GetNames(typeof(Stacking)).ToList();
                }

                return _stackings;
            }
        }

        public List<FruitDataItem> Data
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = DataCreator.CreateFruit();
                }

                return _fruits;
            }
        }

        public C1FlexChart FlexChart
        {
            get
            {
                return flexChart;
            }
        }

        private void cbStackedGroup_CheckChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (cbStackedGroup.IsChecked != null && cbStackedGroup.IsChecked.Value)
            {
                flexChart.Series[0].StackingGroup = 0;
                flexChart.Series[1].StackingGroup = 0;
                flexChart.Series[2].StackingGroup = 1;
            }
            else
            {
                foreach (var series in flexChart.Series)
                {
                    series.StackingGroup = -1;
                }
            }
        }

        private void chart_ParamChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((flexChart.ChartType == ChartType.Column || flexChart.ChartType == ChartType.Bar)
                &&
                flexChart.Stacking!= Stacking.None)
            {
                this.cbStackedGroup.Visibility = Visibility.Visible;
            }
            else
            {
                this.cbStackedGroup.Visibility = Visibility.Collapsed;
            }
        }
    }
    

}
