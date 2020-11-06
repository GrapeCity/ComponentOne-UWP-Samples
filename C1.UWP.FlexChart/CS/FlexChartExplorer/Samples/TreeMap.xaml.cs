using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using System.Linq;
using C1.Chart;
using C1.Xaml.Chart;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TreeMap : Page
    {
        object[] _data;
        List<string> _chartTypes;
        List<string> _palettes;
        List<int> _maxDepths;

        public TreeMap()
        {
            this.InitializeComponent();
        }

        public object[] Data
        {
            get
            {
                if (_data == null)
                    _data = DataCreator.CreateHierarchicalData();
                return _data;
            }
        }

        public List<string> ChartTypes
        {
            get
            {
                if (_chartTypes == null)
                    _chartTypes = Enum.GetNames(typeof(TreeMapType)).ToList();
                return _chartTypes;
            }
        }

        public List<string> Palettes
        {
            get
            {
                if (_palettes == null)
                    _palettes = Enum.GetNames(typeof(C1.Chart.Palette)).ToList();
                return _palettes;
            }
        }

        public List<int> MaxDepths
        {
            get
            {
                if (_maxDepths == null)
                    _maxDepths = new List<int>() { 1, 2, 3, 4 };
                return _maxDepths;
            }
        }

        private void cbLabels_Checked(object sender, RoutedEventArgs e)
        {
            if(treeMap!=null)
                treeMap.DataLabel.Content = cbLabels.IsChecked == true ? "{type}" : "";
        }

    }

}
