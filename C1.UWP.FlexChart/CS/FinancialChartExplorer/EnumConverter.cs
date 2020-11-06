using System;
using Windows.UI.Xaml.Data;
using C1.Chart;
using C1.Chart.Finance;
using MovingAverageType = C1.Chart.MovingAverageType;
using C1.Xaml.Chart.Interaction;
using Windows.UI.Xaml;

namespace FinancialChartExplorer
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof(FitType))
            {
                return (FitType)Enum.Parse(typeof(FitType), value.ToString());
            }
            else if (targetType == typeof(MovingAverageType))
            {
                return (MovingAverageType)Enum.Parse(typeof(MovingAverageType), value.ToString());
            }
            else if (targetType == typeof(RangeMode))
            {
                return (RangeMode)Enum.Parse(typeof(RangeMode), value.ToString());
            }
            else if (targetType == typeof(DataFields))
            {
                return (DataFields)Enum.Parse(typeof(DataFields), value.ToString());
            }
            else if (targetType == typeof(LabelPosition))
            {
                return (LabelPosition)Enum.Parse(typeof(LabelPosition), value.ToString());
            }
            else if (targetType == typeof(LineMarkerAlignment))
            {
                return (LineMarkerAlignment)Enum.Parse(typeof(LineMarkerAlignment), value.ToString());
            }
            else if (targetType == typeof(LineMarkerInteraction))
            {
                return (LineMarkerInteraction)Enum.Parse(typeof(LineMarkerInteraction), value.ToString());
            }
            else if (targetType == typeof(LineMarkerLines))
            {
                return (LineMarkerLines)Enum.Parse(typeof(LineMarkerLines), value.ToString());
            }
            else if (targetType == typeof(PointAndFigureScaling))
            {
                return (PointAndFigureScaling)Enum.Parse(typeof(PointAndFigureScaling), value.ToString());
            }
            else if (targetType == typeof(bool))
            {
                return bool.Parse(value.ToString());
            }

            return value;
        }
    }

    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int index = int.Parse(value.ToString());
            int para = int.Parse(parameter.ToString());
            return index == para ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ReversedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = bool.Parse(value.ToString());
            return !val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
