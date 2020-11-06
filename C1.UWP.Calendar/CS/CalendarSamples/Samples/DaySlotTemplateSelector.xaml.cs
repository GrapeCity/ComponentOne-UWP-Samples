using C1.Xaml.Calendar;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CalendarSamples
{
    /// <summary>
    /// Shows customized holiday days, alters appearance of weekends and current day, uses custom data to show bolded days.
    /// </summary>
    public sealed partial class DaySlotTemplateSelector : Page
    {
        // dictionary of appointments to display in calendar
        private Dictionary<DateTime, string> _boldedDays = new Dictionary<DateTime, string>();
        private DayTemplateSelector _dayTemplateSelector = null;

        public DaySlotTemplateSelector()
        {
            this.InitializeComponent();

            calendar.DaySlotTemplateSelector = DayTemplateSelector;
            calendar.DayOfWeekSlotTemplateSelector = new DayOfWeekTemplateSelector();

            // add some bolded days
            _boldedDays.Add(DateTime.Today.AddDays(2), Strings.BoldedDay1);
            _boldedDays.Add(DateTime.Today.AddDays(15), Strings.BoldedDay2);
            _boldedDays.Add(DateTime.Today.AddDays(29), Strings.BoldedDay3);
            _boldedDays.Add(DateTime.Today.AddDays(48), Strings.BoldedMotherBirthday);
            _boldedDays.Add(DateTime.Today.AddDays(-5), Strings.BoldedDay4);
            _boldedDays.Add(DateTime.Today.AddDays(-17), Strings.BoldedDay5);
            _boldedDays.Add(DateTime.Today.AddDays(-30), Strings.BoldedDay6);

            // bind calendar to _boldedDays dictionary
            calendar.StartTimePath = "Key";
            calendar.DataSource = _boldedDays;
        }

        /// <summary>
        /// The DayTemplateSelector to alter individual days appearance.
        /// </summary>
        private DayTemplateSelector DayTemplateSelector
        {
            get
            {
                if (_dayTemplateSelector == null)
                {
                    //throw exception in CE, replace with following codes
                    //_dayTemplateSelector = Resources["DaySlotTemplateSelector"] as DayTemplateSelector;
                    _dayTemplateSelector = new DayTemplateSelector();
                    _dayTemplateSelector.Resources = this.Resources;

                    // fill-in some holidays
                    FillHolidays(ref _dayTemplateSelector.Holidays, DateTime.Today.Year);
                    FillHolidays(ref _dayTemplateSelector.Holidays, DateTime.Today.Year + 1);
               }
                return _dayTemplateSelector;
            }
        }
        private static void FillHolidays(ref Dictionary<DateTime, Holiday> holidays, int year)
        {
            AddHoliday(ref holidays, new DateTime(year, 1, 1), Strings.NewYearDay, Colors.Green, Colors.White);
            AddHoliday(ref holidays, new DateTime(year, 12, 25),Strings.ChristmasDay, Colors.Red, Colors.White);
            AddHoliday(ref holidays, new DateTime(year, 2, 14), Strings.ValentineDay, Colors.RosyBrown, Colors.DarkRed);
            AddHoliday(ref holidays, new DateTime(year, 4, 22), Strings.EarthDay, Colors.YellowGreen, Colors.Brown);
            AddHoliday(ref holidays, new DateTime(year, 6, 14), Strings.FlagDay, Colors.MidnightBlue, Colors.White);
            AddHoliday(ref holidays, new DateTime(year, 7, 4), Strings.IndependenceDay, Colors.MidnightBlue, Colors.White);
            AddHoliday(ref holidays, new DateTime(year, 10, 31), Strings.HalloweenDay, Colors.DarkOrange, Colors.Brown);
            AddHoliday(ref holidays, new DateTime(year, 11, 11), Strings.VeteransDay, Colors.MidnightBlue, Colors.White);
        }
        private static void AddHoliday(ref Dictionary<DateTime, Holiday> holidays,  DateTime date, string text, Color background, Color foreground)
        {
            holidays.Add(date, new Holiday() { Date = date, Text = text, Background = new SolidColorBrush(background), Foreground = new SolidColorBrush(foreground) });
        }
    }

    /// <summary>
    /// The structure to hold information about holiday day and it's appearance
    /// </summary>
    public struct Holiday
    {
        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The text to show in calendar
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// The brush to color day in calendar
        /// </summary>
        public Brush Background { get; set; }
        /// <summary>
        /// The foreground brush to color day in calendar
        /// </summary>
        public Brush Foreground { get; set; }
    }

    public class DayTemplateSelector : C1.Xaml.Calendar.DaySlotTemplateSelector
    {
        public Dictionary<DateTime, Holiday> Holidays = new Dictionary<DateTime, Holiday>();
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DaySlot slot = item as DaySlot;
            if (slot != null)
            {
                if (!slot.IsAdjacent && slot.DayOfWeek == DayOfWeek.Saturday)
                {
                    // set color for Saturday
                    ((Control)container).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 90, 255));
                }
                if (!slot.IsAdjacent && Holidays.ContainsKey(slot.Date))
                {
                    Holiday holiday = Holidays[slot.Date];
                    slot.Tag = holiday;
                    return Resources["Holiday"] as DataTemplate;
                }
                if (slot.Date == DateTime.Today)
                {
                    // use TodayBrush for border
                    ((Control)container).BorderBrush = ((Control)container).Background;
                    // clear background
                    ((Control)container).Background = new SolidColorBrush(Windows.UI.Colors.Transparent);
                    return (slot.IsBolded ? Resources["TodayBoldedDay"] : Resources["TodayUnboldedDay"]) as DataTemplate;
                }
            }

            // the base class will select custom DataTemplate, defined in the DaySlotTemplateSelector.Resources collection (see MainPage.xaml file)
            return base.SelectTemplateCore(item, container);
        }
    }

    public class DayOfWeekTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DayOfWeekSlot slot = item as DayOfWeekSlot;
            if (slot != null && slot.DayOfWeek == DayOfWeek.Saturday)
            {
                // set color for Saturday
                ((Control)container).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 90, 255));
            }
            // don't change DataTemplate at all
            return null;
        }

    }
}
