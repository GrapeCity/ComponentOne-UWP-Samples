using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace StockAnalysis.Converter
{
    public class NewAnnotationType2VisibilityConverter : IValueConverter
    {     

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string param = parameter == null ? null : parameter.ToString();
            var type = (Data.NewAnnotationType)value;
            var visibility = type == Data.NewAnnotationType.None ? Visibility.Collapsed : Visibility.Visible;
            if (type == Data.NewAnnotationType.Text && param == "Shape")
            {
                visibility = Visibility.Collapsed;
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
