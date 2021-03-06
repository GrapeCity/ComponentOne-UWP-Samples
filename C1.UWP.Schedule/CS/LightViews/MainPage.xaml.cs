﻿using C1.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LightViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            sched1.Settings.FirstVisibleTime = System.TimeSpan.FromHours(8);

            // add test appointments
            C1.C1Schedule.Appointment app = sched1.DataStorage.AppointmentStorage.Appointments.Add();
            app.Start = DateTime.Today.AddHours(14);
            app.Duration = TimeSpan.FromMinutes(60);
            app.Label = sched1.DataStorage.LabelStorage.Labels[3];
            app.Subject = "Test Appointment";

            app = sched1.DataStorage.AppointmentStorage.Appointments.Add();
            app.Start = DateTime.Today.AddDays(2);
            app.AllDayEvent = true;
            app.Label = sched1.DataStorage.LabelStorage.Labels[9];
            app.BusyStatus = sched1.DataStorage.StatusStorage.Statuses[C1.C1Schedule.StatusTypeEnum.Free];
            app.Subject = "Holiday";
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

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (sched1.ViewType == ViewType.Month)
            {
                sched1.ViewType = ViewType.Day;
                ViewButton.Label = "Month";
            }
            else
            {
                sched1.ViewType = ViewType.Month;
                ViewButton.Label = "1 Day";
            }
        }
    }
}
