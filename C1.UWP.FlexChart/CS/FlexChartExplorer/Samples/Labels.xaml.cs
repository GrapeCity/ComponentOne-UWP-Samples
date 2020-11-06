using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml.Chart;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Labels : Page
    {
        Dictionary<ChartType, string> _chartTypes;
        List<FruitDataItem> _fruits;
        List<string> _labelPositions;

        public Labels()
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

        public List<string> LabelPositions
        {
            get
            {
                if (_labelPositions == null)
                {
                    _labelPositions = Enum.GetNames(typeof(LabelPosition)).ToList();
                }

                return _labelPositions;
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
