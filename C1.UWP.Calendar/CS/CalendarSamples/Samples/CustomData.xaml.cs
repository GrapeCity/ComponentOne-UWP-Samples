using C1.Xaml.Calendar;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CalendarSamples
{
    /// <summary>
    /// Binds calendar to custom data and use custom BoldedDaySlotTemplate to show the list of events. 
    /// Use double tap to create new event, use Delete key to remove event.
    /// Note, the full sample with Appointment dialog is implemented as a separate application, see CalendarData sample. 
    /// </summary>
    public sealed partial class CustomData : Page
    {
        private AppointmentCollection _appointments = new AppointmentCollection();
        public CustomData()
        {
            this.InitializeComponent();

            // bind C1Calendar to the AppointmentCollection
            cal1.StartTimePath = "Start";
            cal1.EndTimePath = "End";
            cal1.DataSource = _appointments;
        }

        private void calendar_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            // add test appointment
            FrameworkElement source = e.OriginalSource as FrameworkElement;
            if (source != null && source.DataContext is DaySlot)
            {
                // create new in-place appointment
                Appointment app = new Appointment();
                app.Start = cal1.SelectedDate;
                app.Duration = TimeSpan.FromDays(1);
                app.Subject = Strings.AppointmentSubject + " " + app.Start.ToString();
                _appointments.Add(app);
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
