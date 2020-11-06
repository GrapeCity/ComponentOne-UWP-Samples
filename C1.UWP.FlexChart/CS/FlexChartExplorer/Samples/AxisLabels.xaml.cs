using C1.Chart;
using C1.Xaml;
using C1.Xaml.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlexChartExplorer
{
    public sealed partial class AxisLabels : Page
    {
        List<string> _overlappingLabels;

        public AxisLabels()
        {
            this.InitializeComponent();
        }

        public List<object> Data
        {
            get{ return GDPData.GetData();}
        }

        public List<string> OverlappingLabels
        {
            get
            {
                if (_overlappingLabels == null)
                    _overlappingLabels = Enum.GetNames(typeof(OverlappingLabels)).ToList();
                return _overlappingLabels;
            }
        }
    }

    class GDPData
    {
        static string csv_data = @"United States,18624450
European Union,16408364
China,11232108
Japan,4936543
Germany,3479232
United Kingdom,2629188
France,2466472
India,2263792
Italy,1850735
Brazil,1798622
Canada,1529760
South Korea,1411042
Russia,1283162
Australia,1261645
Spain,1232597
Mexico,1046925
Indonesia,932448
Turkey,863390
Netherlands,777548
Switzerland,669038
Saudi Arabia,646438";

        static List<object> _data;

        static List<object> ParseData()
        {
            var list = new List<object>();
            var data = csv_data;
            var ss = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ss.Length; i++)
            {
                var vals = ss[i].Split(',');
                list.Add(new { Country = vals[0], GDP = double.Parse(vals[1]) });
            }

            return list;
        }

        public static List<object> GetData()
        {
            if (_data == null)
                _data = ParseData();

            return _data;
        }
    }
}
