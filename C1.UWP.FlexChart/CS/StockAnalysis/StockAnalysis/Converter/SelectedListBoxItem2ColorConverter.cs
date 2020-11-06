using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace StockAnalysis.Converter
{
    public class SelectedListBoxItem2ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool iSelected = (bool)value;
            return iSelected ? App.Current.Resources["Blue500"] : App.Current.Resources["Grey700"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
