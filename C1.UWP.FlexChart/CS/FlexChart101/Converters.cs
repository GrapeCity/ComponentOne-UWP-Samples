using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using System.Collections.Generic;
using C1.Chart;

namespace FlexChart101
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
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
                case "FunnelChartType":
                    return (FunnelChartType)Enum.Parse(typeof(FunnelChartType), str);
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

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var visibility = (SeriesVisibility)Enum.Parse(typeof(SeriesVisibility), value.ToString());
            return visibility == SeriesVisibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? SeriesVisibility.Visible : SeriesVisibility.Legend;
        }
    }

    public class FormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return double.Parse(value.ToString());
        }
    }
}
