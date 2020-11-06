using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarData
{
    // inherit from ObservableCollection to allow auto refresh in calendar
    public class AppointmentCollection : ObservableCollection<Appointment>
    {
        public AppointmentCollection()
        {
        }
    }
}
