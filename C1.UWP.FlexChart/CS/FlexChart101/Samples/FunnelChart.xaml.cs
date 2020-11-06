using C1.Chart;
using C1.Xaml.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace FlexChart101
{
    /// <summary>
    /// Interaction logic for FunnelChart.xaml
    /// </summary>
    public partial class FunnelChart : Page
    {
        private List<DataItem> _data;

        public FunnelChart()
        {
            InitializeComponent();
        }

        public List<DataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataCreator.CreateFunnelData();
                }

                return _data;
            }
        }

        public List<string> FunnelTypes
        {
            get
            {
                return Enum.GetNames(typeof(FunnelChartType)).ToList();
            }
        }

        public C1FlexChart Funnel
        {
            get
            {
                return funnelChart;
            }
        }
    }
}
