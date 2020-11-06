using System;
using System.Linq;
using Windows.UI.Xaml;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml.Chart;

namespace FlexChart101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LegendAndTitles : Page
    {
        List<GroupDataItem> _data;
        List<string> _positions;

        public LegendAndTitles()
        {
            this.InitializeComponent();
        }

        public List<GroupDataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataCreator.CreateGroupData();
                }

                return _data;
            }
        }

        public List<string> Legends
        {
            get
            {
                if (_positions == null)
                {
                    _positions = Enum.GetNames(typeof(Position)).ToList<string>();
                }

                return _positions;
            }
        }

        public C1FlexChart FlexChart
        {
            get
            {
                return this.flexChart;
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (sender is AppBarButton)
                settings.Visibility = Visibility.Visible;
            else
                settings.Visibility = Visibility.Collapsed;
        }

        private void cbGroup_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGroup.IsChecked.HasValue && flexChart != null)
            {
                foreach (ISeries ser in flexChart.Series)
                {
                    ser.LegendGroup = (cbGroup.IsChecked == false) ? null :
                                      ((ser.Name.IndexOf("Sales") > -1) ? "Sales" : "Expenses");
                }
            }
        }
    }
}
