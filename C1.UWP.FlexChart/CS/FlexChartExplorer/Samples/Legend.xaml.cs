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
    public sealed partial class Legend : Page
    {
        List<FruitsDataItem> _fruits;
        List<string> _legendPostion;
        List<string> _legendOrientation;
        List<string> _legendTextWrapping;
        List<LegendMaxWidthItem> _legendMaxWidth;

        public Legend()
        {
            this.InitializeComponent();

            this.Loaded += (o, e) =>
            {
                this.cbMaxWidth.SelectedIndex = 0;
            };
        }

        public List<FruitsDataItem> Data
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = DataCreator.CreateFruits();
                }

                return _fruits;
            }
        }

        public List<string> LegendPosition
        {
            get
            {

                if (_legendPostion == null)
                {
                    _legendPostion = Enum.GetNames(typeof(Position)).ToList();

                }
                return _legendPostion;
            }
        }

        public List<string> LegendOrientation
        {
            get
            {
                if (_legendOrientation == null)
                {
                    _legendOrientation = Enum.GetNames(typeof(C1.Chart.Orientation)).ToList();
                }

                return _legendOrientation;
            }
        }

        public List<string> LegendTextWrapping
        {
            get
            {
                if (_legendTextWrapping == null)
                {
                    _legendTextWrapping = Enum.GetNames(typeof(C1.Chart.TextWrapping)).ToList();
                }

                return _legendTextWrapping;
            }
        }

        public List<LegendMaxWidthItem> LegendMaxWidth
        {
            get
            {
                if (_legendMaxWidth == null)
                {
                    _legendMaxWidth = new List<LegendMaxWidthItem>();
                    _legendMaxWidth.Add(new LegendMaxWidthItem() { Name = "Narrow", Value = 80 });
                    _legendMaxWidth.Add(new LegendMaxWidthItem() { Name = "Middle", Value = 180 });
                    _legendMaxWidth.Add(new LegendMaxWidthItem() { Name = "Wide", Value = 360 });
                }

                return _legendMaxWidth;
            }
        }

        private void cbCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCheckBox.IsChecked.HasValue && flexChart != null)
            {
                foreach (ISeries ser in flexChart.Series)
                {
                    int start = ser.Name.IndexOf("The quick ") + "The quick ".Length;
                    int end = ser.Name.IndexOf(" jumps over");
                    string groupName = ser.Name.Substring(start, end - start);

                    ser.LegendGroup = cbCheckBox.IsChecked == false ? null : groupName;
                }
            }
        }
    }

    public class LegendMaxWidthItem
    {
        public string Name
        {
            get;
            set;
        }
        public int Value
        {
            get;
            set;
        }
    }


    public class MaxWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var item = value as LegendMaxWidthItem;

            return item == null ? 0 : item.Value;
        }
    }
}
