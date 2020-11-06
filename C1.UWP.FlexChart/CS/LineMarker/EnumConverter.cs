using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using C1.Xaml.Chart.Interaction;

namespace LineMarkerSample
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Type type = value.GetType();
            if (type == typeof(LineMarkerAlignment))
            {
                var model = parameter as LineMarkerViewModel;
                var alignments = model.LineMarkerAlignments;
                var alignment = (LineMarkerAlignment)Enum.Parse(typeof(LineMarkerAlignment), value.ToString());
                return alignments.Values.ToList().IndexOf(alignment);
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof(bool))
                return bool.Parse(value.ToString());
            else
            {
                if (targetType == typeof(LineMarkerAlignment))
                {
                    var model = parameter as LineMarkerViewModel;
                    var alignments = model.LineMarkerAlignments;
                    return alignments.Values.ElementAt(int.Parse(value.ToString()));
                }
                else
                {
                    return Enum.Parse(targetType, value.ToString());
                }
            }
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var val = (LineMarkerInteraction)Enum.Parse(typeof(LineMarkerInteraction), value.ToString());
            return val == LineMarkerInteraction.Drag ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
