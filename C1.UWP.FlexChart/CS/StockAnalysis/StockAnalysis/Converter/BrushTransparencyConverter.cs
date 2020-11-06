using System;
using System.Globalization;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Converter
{
    public class BrushTransparencyConverter : IValueConverter
    {       

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var brush = value as SolidColorBrush;
            if (brush == null)
            {
                return new SolidColorBrush(Windows.UI.Colors.Black);
            }
            var color = brush.Color;

            double tv = 1;

            if (double.TryParse(parameter.ToString(), out tv))
            {
                color.A = System.Convert.ToByte(color.A * tv);
            }

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
