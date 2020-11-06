using System;
using Windows.UI.Xaml.Data;

namespace StockAnalysis.Converter
{
    public class Boolean2BooleanNullableConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? bis = System.Convert.ToBoolean(value);
            return bis;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
