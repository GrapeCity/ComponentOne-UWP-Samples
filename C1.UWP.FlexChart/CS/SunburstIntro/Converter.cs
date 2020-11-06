using C1.Chart;
using System;
using Windows.UI.Xaml.Data;

namespace SunburstIntro
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ( (parameter as string) == "PieLabelPosition")
                targetType = typeof(PieLabelPosition);
            else if ((parameter as string) == "PieLabelOverlapping")
                targetType = typeof(PieLabelOverlapping);
            return Enum.Parse(targetType, value.ToString());
        }
    }

    public class StringToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof(Position))
            {
                return (Position)Enum.Parse(typeof(Position), value.ToString());
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
