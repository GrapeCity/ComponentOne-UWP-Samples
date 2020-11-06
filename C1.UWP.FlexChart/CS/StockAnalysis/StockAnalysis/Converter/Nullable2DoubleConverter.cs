using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace StockAnalysis.Converter
{
    public class Nullable2DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value as Nullable<double>) == null ? 0 : (value as Nullable<double>).Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
