using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScheduleSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaveLocalData : Page
    {
        //IRandomAccessStream stream;
        public SaveLocalData()
        {
            this.InitializeComponent();
            this.Unloaded += SaveLocalData_Unloaded;
            try
            {
                // set toast notifier for C1Schedule to show toast notifications instead of embedded reminder dialog
                sched1.ToastNotifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
                // note, notifications might not be shown if end-user disabled them for some reason
                // also, toast notifications are disabled when application is running in simulator
            }
            catch
            {
                // if application manifest doesn't allow toast notifications, then above code will fail
            }
        }

        private async void SaveLocalData_Unloaded(object sender, RoutedEventArgs e)
        {
            // Export XML to app local folder
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(Strings.ExportFileName, Windows.Storage.CreationCollisionOption.OpenIfExists);
            
            IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            await sched1.DataStorage.ExportAsync(stream.AsStreamForWrite(), C1.C1Schedule.FileFormatEnum.XML);

            await stream.FlushAsync();
            stream.Dispose();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Import XML from app local folder
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                var file = await folder.GetFileAsync(Strings.ImportFileName);

                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                await sched1.DataStorage.ImportAsync(stream.AsStreamForRead(), C1.C1Schedule.FileFormatEnum.XML);
                stream.Dispose();
            }
            catch { }
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sched1.NewAppointmentDialog();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (sched1.ViewType == C1.Xaml.Schedule.ViewType.Month)
            {
                sched1.ViewType = C1.Xaml.Schedule.ViewType.Day;
                ViewButton.Label = Strings.MonthView;
            }
            else
            {
                sched1.ViewType = C1.Xaml.Schedule.ViewType.Month;
                ViewButton.Label = Strings.DayView;
            }
        }

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            sched1.SelectedDateTime = DateTime.Now;
        }
    }
}
