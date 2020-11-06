using C1.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DataManipulation
{
    public class Boolean2StackingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = System.Convert.ToBoolean(value);
            if (b)
            {
                return Stacking.Stacked;
            }
            return Stacking.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Stacking s = (Stacking)value;
            if (s == Stacking.Stacked)
            {
                return true;
            }
            return false;
        }
    }
}
