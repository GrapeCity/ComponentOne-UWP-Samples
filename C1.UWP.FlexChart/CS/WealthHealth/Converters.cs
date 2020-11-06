using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace WealthHealth
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var val = double.Parse(value.ToString());
            return (int)Math.Floor(val);
        }
    }
}
