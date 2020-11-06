using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace StockAnalysis.Converter
{
    public class Name2LogoConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {     
            return App.Current.Resources[value] as Windows.UI.Xaml.Controls.ControlTemplate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
