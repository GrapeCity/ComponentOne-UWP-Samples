using C1.Xaml.Chart.Interaction;
using System;
using Windows.UI.Xaml.Data;

namespace GestureChartSample
{
    class GestureModeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (GestureMode)Enum.Parse(typeof(GestureMode), value.ToString());
        }
    }
}
