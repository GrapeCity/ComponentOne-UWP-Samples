using System;
using Windows.UI.Xaml.Controls;

namespace CalendarSamples
{
    /// <summary>
    /// The C1Calendar control allows to set custom DataTemplate to represent bolded days. Use C1Calendar.BoldedDaySlotTemplate property to alter appearance of all bolded days.
    /// </summary>
    public sealed partial class BoldedDayTemplate : Page
    {
        public BoldedDayTemplate()
        {
            this.InitializeComponent();

            // add some bolded days
            cal1.BoldedDates.Add(DateTime.Today.AddDays(2));
            cal1.BoldedDates.Add(DateTime.Today.AddDays(12));
            cal1.BoldedDates.Add(DateTime.Today.AddDays(22));
            cal1.BoldedDates.Add(DateTime.Today.AddDays(-2));
            cal1.BoldedDates.Add(DateTime.Today.AddDays(-12));
            cal1.BoldedDates.Add(DateTime.Today.AddDays(-22));
        }
    }
}
