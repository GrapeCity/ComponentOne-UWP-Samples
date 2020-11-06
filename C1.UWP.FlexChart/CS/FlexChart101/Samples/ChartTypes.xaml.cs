using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml.Chart;

namespace FlexChart101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChartTypes : Page
    {
        Dictionary<ChartType, string> _chartTypes;
        List<FruitDataItem> _fruits;
        List<string> _palettes;
        List<string> _stackings;

        public ChartTypes()
        {
            this.InitializeComponent();
        }

        public Dictionary<ChartType, string> Types
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
    }
}
