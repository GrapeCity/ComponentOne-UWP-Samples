using System;
using System.Collections.Generic;
using System.Text;
#if WPF
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
#elif WINDOWS_UWP
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
#endif

namespace DashboardModel
{
    public class UnitConverter : IValueConverter
    {
        public UnitConverter()
        {

        }
#if WPF
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, string language)
#endif
        {
            double convertValue = (double)value;
            convertValue /= 1000000;
            return convertValue;
        }

#if WPF
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#endif
        {
#if WPF
            return Convert(value, targetType, parameter, culture);
#elif WINDOWS_UWP
            return Convert(value, targetType, parameter, language);
#endif
        }
    }

    public class BarColorConverter : IValueConverter
    {
#if WPF
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, string language)
#endif
        {
            double precent = (double)value;
            return precent < 0.8 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Color.FromArgb(255, 0, 133, 199));
        }

#if WPF
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#endif
        {
#if WPF
            return Convert(value, targetType, parameter, culture);
#elif WINDOWS_UWP
            return Convert(value, targetType, parameter, language);
#endif
        }
    }

    public class GoodValueConverter : IValueConverter
    {
        public GoodValueConverter()
        {

        }

#if WPF
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, string language)
#endif
        {
            double goodValue = (double)value;
            goodValue *= 0.0000008;
            return goodValue;
        }

#if WPF
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#endif
        {
#if WPF
            return Convert(value, targetType, parameter, culture);
#elif WINDOWS_UWP
            return Convert(value, targetType, parameter, language);
#endif
        }
    }

    public class BadValueConverter : IValueConverter
    {
        public BadValueConverter()
        {

        }

#if WPF
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, string language)
#endif
        {
            double badValue = (double)value;
            badValue *= 0.0000005;
            return badValue;
        }

#if WPF
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#elif WINDOWS_UWP
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#endif
        {
#if WPF
            return Convert(value, targetType, parameter, culture);
#elif WINDOWS_UWP
            return Convert(value, targetType, parameter, language);
#endif
        }
    }
}
