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
    public class DaySlotTemplateSelector : C1.Xaml.Calendar.DaySlotTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DaySlot slot = item as DaySlot;
            if (slot != null && !slot.IsAdjacent && slot.DayOfWeek == DayOfWeek.Saturday)
            {
                // set color for Saturday
                ((Control)container).Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 191, 255));
            }
            // the base class will select custom DataTemplate, defined in the DaySlotTemplateSelector.Resources collection (see MainPage.xaml file)
            return base.SelectTemplateCore(item, container);
        }
    }
}
