using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlotAreas : Page
    {
        PlotAreasSampleDataItem[] _data;

        public PlotAreas()
        {
            this.InitializeComponent();
        }


        public PlotAreasSampleDataItem[] Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataCreator.CreateForPlotAreas();
                }

                return _data;
            }
        }
    }
}
