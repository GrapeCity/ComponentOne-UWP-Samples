﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Data;

namespace StockChart.Converters
{
    class MultipleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double v = System.Convert.ToDouble(value);
            int times = System.Convert.ToInt32(parameter);
            if (times < 1)
            {
                times = 1;
            }
            return v * times;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            double v = System.Convert.ToDouble(value);
            int times = System.Convert.ToInt32(parameter);
            if (times < 1)
            {
                times = 1;
            }
            return v / times;
        }
    }
}
