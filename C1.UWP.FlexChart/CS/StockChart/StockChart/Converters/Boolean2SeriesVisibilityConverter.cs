using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Data;

namespace StockChart.Converters
{
    public class Boolean2SeriesVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = System.Convert.ToBoolean(value);
            return b ? C1.Chart.SeriesVisibility.Visible : C1.Chart.SeriesVisibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            C1.Chart.SeriesVisibility v = (C1.Chart.SeriesVisibility)value;
            return v == C1.Chart.SeriesVisibility.Visible;
        }
    }
}
