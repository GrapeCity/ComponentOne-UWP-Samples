using C1.BarCode;
using System;
using Windows.UI.Xaml.Data;

namespace BarCodeSamples
{
    public class StringToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (CodeType)Enum.Parse(typeof(CodeType), value.ToString());
        }
    }
}
