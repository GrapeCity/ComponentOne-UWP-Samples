using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Converter
{
    public class SolidColorBrushBrightnessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var brush = value as SolidColorBrush;
            var parm = System.Convert.ToDouble(parameter);

            if (brush == null)
            {
                return new SolidColorBrush(Colors.Black);
            }
            var hsb = Utilities.ColorEx.RgbToHsb(brush.Color);
            hsb.B = hsb.B * (1 + parm);

            var color = Utilities.ColorEx.HsbToRgb(hsb);
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
     
