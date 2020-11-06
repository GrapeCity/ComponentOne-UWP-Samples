using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Converter
{
    public class SolidColorBrush2ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush brush = value as SolidColorBrush;
            return brush == null ? Colors.Transparent : brush.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Color color = (Color)value;
            return new SolidColorBrush(color);
        }
    }
}
