using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ControlExplorer.Common
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b;
            bool.TryParse(value.ToString(), out b);
            return b ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility v = (Visibility)Enum.Parse(typeof(Visibility), value.ToString());
            return v == Visibility.Collapsed ? false : true;
        }
    }

    public class UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Uri)
            {
                return ((Uri)value).ToString();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
            {
                try
                {
                    return new Uri(value as string);
                }
                catch
                {
                }
            }
            return value;
        }
    }
}
