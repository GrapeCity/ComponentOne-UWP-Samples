using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using C1.Xaml.Schedule;
using System;

namespace ScheduleSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DefaultView : Page
    {
        public DefaultView()
        {
            this.Unloaded += DefaultView_Unloaded;
            this.InitializeComponent();
            sched1.Settings.FirstVisibleTime = System.TimeSpan.FromHours(8);

            // add test appointments
            C1.C1Schedule.Appointment app = sched1.DataStorage.AppointmentStorage.Appointments.Add();
            app.Start = DateTime.Today.AddHours(14);
            app.Duration = TimeSpan.FromMinutes(60);
            app.Label = sched1.DataStorage.LabelStorage.Labels[3];
            app.Subject = Strings.AppointmentSubject;

            app = sched1.DataStorage.AppointmentStorage.Appointments.Add();
            app.Start = DateTime.Today.AddDays(2);
            app.AllDayEvent = true;
            app.Label = sched1.DataStorage.LabelStorage.Labels[9];
            app.BusyStatus = sched1.DataStorage.StatusStorage.Statuses[C1.C1Schedule.StatusTypeEnum.Free];
            app.Subject = Strings.HolidaySubject;
        }

        void DefaultView_Unloaded(object sender, RoutedEventArgs e)
        {
            // dispose C1Scheduler control to avoid memory leaks
            sched1.Dispose();
        }
        private void DayClick(object sender, RoutedEventArgs e)
        {
            sched1.ChangeStyle(sched1.OneDayStyle);
        }
        private void WorkWeekClick(object sender, RoutedEventArgs e)
        {
            sched1.ChangeStyle(sched1.WorkingWeekStyle);
        }
        private void WeekClick(object sender, RoutedEventArgs e)
        {
            sched1.ChangeStyle(sched1.WeekStyle);
        }

        private void MonthClick(object sender, RoutedEventArgs e)
        {
            sched1.ChangeStyle(sched1.MonthStyle);
        }

        private async void Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                C1Scheduler.ExportCommand.Execute(sched1.SelectedAppointment != null ? sched1.SelectedAppointment : null, sched1);
            }
            catch (UnauthorizedAccessException)
            {
                // might happen in emulators
            }
        }
        private async void Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                C1Scheduler.ImportCommand.Execute(null, sched1);
            }
            catch (UnauthorizedAccessException)
            {
                // might happen in emulators
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sched1.NewAppointmentDialog();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (sched1.ViewType == ViewType.Month)
            {
                sched1.ViewType = ViewType.Day;
                ViewButton.Label = Strings.MonthView;
            }
            else
            {
                sched1.ViewType = ViewType.Month;
                ViewButton.Label = Strings.DayView;
            }
        }

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            sched1.SelectedDateTime = DateTime.Now;
        }
    }
}
