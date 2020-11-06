using System;
using System.Collections.Specialized;
using Windows.UI.Xaml.Data;

namespace FlexGridSamples
{
    // converter used to group countries by their first initial
    class CountryInitialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return ((string)value)[0].ToString().ToUpper();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
