using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using C1.Chart;
using System.Collections.Generic;
using System.Linq;

namespace FlexChartExplorer
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string str = value.ToString();
            switch (parameter.ToString())
            {
                case "Palette":
                    return (Palette)Enum.Parse(typeof(Palette), str);
                case "Stacking":
                    return (Stacking)Enum.Parse(typeof(Stacking), str);
                case "PieLabelPosition":
                    return (PieLabelPosition)Enum.Parse(typeof(PieLabelPosition), str);
                case "LabelPosition":
                    return (LabelPosition)Enum.Parse(typeof(LabelPosition), str);
                case "ChartSelectionMode":
                    return (ChartSelectionMode)Enum.Parse(typeof(ChartSelectionMode), str);
                case "Position":
                    return (Position)Enum.Parse(typeof(Position), str);
                case "FitType":
                    return (FitType)Enum.Parse(typeof(FitType), str);
                case "QuartileCalculation":
                    return (QuartileCalculation)Enum.Parse(typeof(QuartileCalculation), str);
                case "ErrorAmount":
                    return (ErrorAmount)Enum.Parse(typeof(ErrorAmount), str);
                case "Direction":
                    return (ErrorBarDirection)Enum.Parse(typeof(ErrorBarDirection), str);
                case "EndStyle":
                    return (ErrorBarEndStyle)Enum.Parse(typeof(ErrorBarEndStyle), str);
                case "Orientation":
                    return (Orientation)Enum.Parse(typeof(Orientation), str);
                case "TextWrapping":
                    return (C1.Chart.TextWrapping)Enum.Parse(typeof(C1.Chart.TextWrapping), str);
                case "TreeMapType":
                    return (TreeMapType)Enum.Parse(typeof(TreeMapType), str);
                case "HistogramBinning":
                    return (HistogramBinning)Enum.Parse(typeof(HistogramBinning), str);
                case "LabelOverlapping":
                    return (LabelOverlapping)Enum.Parse(typeof(LabelOverlapping), str);
                case "DataShape":
                    return (DataShape)Enum.Parse(typeof(DataShape), str);
                case "OverlappingLabels":
                    return (OverlappingLabels)Enum.Parse(typeof(OverlappingLabels), str);
                case "GroupSeperator":
                    return (AxisGroupSeparator)Enum.Parse(typeof(AxisGroupSeparator), str);               
            }
            return null;
        }
    }

    public class ChartTypeConverter : DependencyObject, IValueConverter
    {
        public Dictionary<ChartType, string> ChartTypes
        {
            get { return (Dictionary<ChartType, string>)GetValue(ChartTypesProperty); }
            set { SetValue(ChartTypesProperty, value); }
        }

        public static readonly DependencyProperty ChartTypesProperty =
            DependencyProperty.Register("ChartTypes", typeof(Dictionary<ChartType, string>), typeof(ChartTypeConverter), 
            new PropertyMetadata(null));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var key = (ChartType)value;
            int index = 0;
            foreach (var chartType in ChartTypes)
            {
                if (chartType.Key.Equals(key))
                    return index;
                index++;
            }

            return index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int index = (int)value;
            return ChartTypes.ElementAt(index).Key;
        }
    }

    public class GroupSeparatorConverter : DependencyObject, IValueConverter
    {
        public Dictionary<AxisGroupSeparator, string> GroupSeparator
        {
            get { return (Dictionary<AxisGroupSeparator, string>)GetValue(GroupSeparatorProperty); }
            set { SetValue(GroupSeparatorProperty, value); }
        }

        public static readonly DependencyProperty GroupSeparatorProperty =
            DependencyProperty.Register("GroupSeparator", typeof(Dictionary<AxisGroupSeparator, string>), typeof(GroupSeparatorConverter),
            new PropertyMetadata(null));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var key = (AxisGroupSeparator)value;
            int index = 0;
            foreach (var type in GroupSeparator)
            {
                if (type.Key.Equals(key))
                    return index;
                index++;
            }

            return index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int index = (int)value;
            return GroupSeparator.ElementAt(index).Key;
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return Visibility.Collapsed;

            var position = (PieLabelPosition)Enum.Parse(typeof(PieLabelPosition), value.ToString());
            return position == PieLabelPosition.None ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var fitType = (FitType)Enum.Parse(typeof(FitType), value.ToString());
            return fitType == FitType.Fourier || fitType == FitType.Polynom ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isChecked = (bool)value;
            return isChecked ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
