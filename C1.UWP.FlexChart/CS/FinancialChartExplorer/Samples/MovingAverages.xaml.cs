using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using C1.Chart;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for MovingAverages.xaml
    /// </summary>
    public partial class MovingAverages : Page
    {
        DataService dataSerivice = DataService.GetService();

        public MovingAverages()
        {
            InitializeComponent();
        }

        public List<Quote> Data
        {
            get
            {
                return dataSerivice.GetSymbolData("box");
            }
        }

        public List<string> MovingAverageType
        {
            get
            {
                return Enum.GetNames(typeof(MovingAverageType)).ToList();
            }
        }
    }
}
