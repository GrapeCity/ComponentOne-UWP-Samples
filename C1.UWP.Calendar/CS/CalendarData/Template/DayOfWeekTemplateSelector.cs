using C1.Xaml.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CalendarData
{
    public class DayOfWeekTemplateSelector : C1.Xaml.C1DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DayOfWeekSlot slot = item as DayOfWeekSlot;
            if (slot != null && slot.DayOfWeek == DayOfWeek.Saturday)
            {
                // set color for Saturday
                ((Control)container).Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 191, 255));
            }
            // don't change DataTemplate at all
            return null;
        }
    }
}
