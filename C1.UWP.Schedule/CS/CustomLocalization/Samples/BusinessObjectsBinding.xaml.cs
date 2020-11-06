using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScheduleSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusinessObjectsBinding : Page
    {
        public BusinessObjectsBinding()
        {
            this.Unloaded += BusinessObjectsBinding_Unloaded;
            this.InitializeComponent();
            sched1.Settings.FirstVisibleTime = System.TimeSpan.FromHours(8);

            AppointmentCollection apps = Resources["_ds"] as AppointmentCollection;
            if (apps != null)
            {
                // add demo appointment
                Appointment app = new Appointment();
                app.Subject = Strings.AppointmentSubject;
                app.Start = DateTime.Today;
                app.Duration = TimeSpan.FromMinutes(60);
                apps.Add(app);
            }

        }
        void BusinessObjectsBinding_Unloaded(object sender, RoutedEventArgs e)
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

    [DataContract(Name = "Appointment", Namespace = "http://www.componentone.com")]
    public class Appointment : INotifyPropertyChanged
    {
        public Appointment()
        {
            Id = Guid.NewGuid();
        }
        [DataMember]
        public Guid Id { get; private set; }

        private string _subject = "";
        [DataMember]
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    OnPropertyChanged("Subject");
                }
            }
        }

        private string _location = "";
        [DataMember]
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged("Location");
                }
            }
        }

        private DateTime _start;
        [DataMember]
        public DateTime Start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    OnPropertyChanged("Start");
                }
            }
        }

        [DataMember]
        public DateTime End
        {
            get { return _start.Add(_duration); }
            set
            {
                if (value >= _start)
                {
                    Duration = (value.Subtract(_start));
                    OnPropertyChanged("End");
                }
            }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }

        private string _description = "";
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private string _properties = "";
        [DataMember]
        public string Properties
        {
            get { return _properties; }
            set
            {
                if (_properties != value)
                {
                    _properties = value;
                    OnPropertyChanged("Properties");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // inherit from ObservableCollection to allow auto refresh in calendar
    public class AppointmentCollection : ObservableCollection<Appointment>
    {
        public AppointmentCollection()
        {
        }
    }

}
