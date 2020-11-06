using C1.Xaml.Calendar;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;

namespace CalendarData
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarDataDemo : Page
    {
        private AppointmentCollection _appointments = new AppointmentCollection();
        // If it is true, the sample will work with device's Appointments provider.
        // If it is false, the sample will bind collection of custom Appointment objects. 
        private static bool UseAppointmentManager = true;
        // async task for opening device calendar application
        private Windows.Foundation.IAsyncOperation<string> _calTask = null;

        public CalendarDataDemo()
        {
            this.InitializeComponent();

            if (!UseAppointmentManager)
            {
                // bind C1Calendar to the AppointmentCollection
                calendar.StartTimePath = "Start";
                calendar.EndTimePath = "End";
                calendar.DataSource = _appointments;
            }
           
        }

        private void Appointment_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // handle appointment removing
            if (e.Key == Windows.System.VirtualKey.Delete)
            {
                ListBox el = sender as ListBox;
                if (el != null && el.SelectedItems.Count > 0)
                {
                    foreach (Appointment app in el.SelectedItems)
                    {
                        _appointments.Remove(app);
                    }
                }
            }
        }

        private void AlterAppearance_Click(object sender, RoutedEventArgs e)
        {
            // show Sundays in Red and Saturdays in Blue
            DaySlotTemplateSelector datesSelector = this.Resources["DaySlotTemplateSelector"] as DaySlotTemplateSelector;
            calendar.DaySlotTemplateSelector = datesSelector;
            // use bolded days dictionary defined in the DaySlotTemplateSelector class instance 
            calendar.DayOfWeekSlotTemplateSelector = new DayOfWeekTemplateSelector();
            calendar.WeekendBrush = new SolidColorBrush(Colors.Red);
            calendar.TodayBrush = new SolidColorBrush(Colors.Green);
            Refresh(calendar.DisplayDate);
        }

        private void cal1_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh(calendar.DisplayDate);
        }

        private void Refresh(DateTime displayDate)
        {
            // update bolded dates for the visible month (and for adjacent days)
            GetBoldedDates(displayDate.AddMonths(-1), displayDate.AddMonths(2));
        }

        private void cal1_DisplayDateChanging(object sender, DateChangedEventArgs e)
        {
            Refresh(e.NewValue);
        }

        private async void calendar_DoubleTapped(object sender, RoutedEventArgs e)
        {
            if (_calTask != null)
            {
                // if there is already opened task, cancel it first
                _calTask.Cancel();
                _calTask.Close();
                _calTask = null;
            }
            // show the list of appointments for the bolded day
            FrameworkElement fel = e.OriginalSource as FrameworkElement;
            if (fel != null)
            {
                DaySlot slot = fel.DataContext as DaySlot;
                if (slot != null)
                {
                    DateTime date = slot.Date;
                    string message = date.ToString();
                    if (slot.DataSource == null || slot.DataSource.Count == 0)
                    {
                        if (UseAppointmentManager)
                        {
                            // create new appointment and fill initial properties
                            Windows.ApplicationModel.Appointments.Appointment app = new Windows.ApplicationModel.Appointments.Appointment();
                            app.StartTime = date;
                            app.AllDay = true;
                            app.Subject = Strings.DeviceAppointmentSubject;
                            // Show the Appointments provider Add Appointment UI, to enable the user to add an appointment. 
                            // The returned id can be used later to edit or remove existent appointment.
                            _calTask = AppointmentManager.ShowEditNewAppointmentAsync(app);
                            string id = await _calTask;
                            Refresh(calendar.DisplayDate);
                            _calTask = null;
                            return;
                        }
                        else
                        {
                            if (!Device.IsWindowsPhoneDevice())
                            {
                                DataTemplate boldedDaySlotTemplate = this.Resources["BoldedDaySlotTemplate"] as DataTemplate;
                                calendar.BoldedDaySlotTemplate = boldedDaySlotTemplate;
                                Appointment app = new Appointment();
                                app.Start = calendar.SelectedDate;
                                app.Duration = TimeSpan.FromDays(1);
                                app.Subject = Strings.AppointmentSubject + " " + app.Start.ToString();
                                _appointments.Add(app);
                                calendar.DataSource = _appointments;
                                return;
                            }
                            else
                            {
                                message += "\r\n" + Strings.Message;
                            }
                        }
                    }
                    else
                    {
                        if (!UseAppointmentManager)
                        {
                            foreach (Appointment app in slot.DataSource)
                            {
                                message += "\r\n" + app.Subject;
                            }
                        }
                        else
                        {
                            foreach (Windows.ApplicationModel.Appointments.Appointment app in slot.DataSource)
                            {
                                message += "\r\n" + app.Subject;
                            }
                        }
                        var dialog = new MessageDialog(message);
                        dialog.ShowAsync();
                           
                    }
                }
            }
        }

        private async Task GetBoldedDates(DateTime start, DateTime end)
        {
            DateList boldedDates = calendar.BoldedDates;
            if (!UseAppointmentManager)
            {
                // generate test appointment
                List<object> list = new List<object>();
                Appointment app = new Appointment();
                app.Start = start.AddDays(12);
                app.End = app.Start.AddHours(1);
                app.Subject = Strings.EmulatorAppointmentSubject;
                list.Add(app);
                // bind calendar to data
                calendar.DataSource = list;
                // don't set StartTimePath and EndTimePath as they are the same as default values
            }
            else
            {
                // get appointments from the device calendar
                var store = await AppointmentManager.RequestStoreAsync(AppointmentStoreAccessType.AllCalendarsReadOnly);
                var appointments = await store.FindAppointmentsAsync(new DateTimeOffset(start), end - start);

                // bind calendar to the search results
                calendar.DataSource = appointments;
                // don't set StartTimePath and EndTimePath as they are the same as default values
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog(Strings.DialogMessage);
            dialog.ShowAsync();
        }

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            calendar.Today();
        }

    }
    

}
