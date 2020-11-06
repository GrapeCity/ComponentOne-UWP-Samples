using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace StockAnalysis.Converter
{
    public class NewAnnotationType2SettingButtonVisibilityConverter : IValueConverter
    {      
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Data.NewAnnotationType type = (Data.NewAnnotationType)value;
            return type == Data.NewAnnotationType.None ? Windows.UI.Xaml.Visibility.Collapsed : Windows.UI.Xaml.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
