using System;
using Windows.UI.Xaml.Controls;

namespace CalendarSamples
{
    /// <summary>
    /// Shows the C1Calendar control with default appearance options and some bolded dates.
    /// </summary>
    public sealed partial class DefaultView : Page
    {
        public DefaultView()
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
