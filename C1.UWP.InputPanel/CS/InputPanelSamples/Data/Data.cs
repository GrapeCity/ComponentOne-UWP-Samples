using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using System.Globalization;
using Windows.Storage;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
using C1.Xaml;
using C1.Xaml.InputPanel;
using System.Runtime.Serialization;
using System.Xml;

namespace InputPanelSamples
{
    public class Data
    {
        static List<Customer> _customer;
        static List<Employee> _employee;

        public static List<Customer> Load()
        {
            if (_customer == null)
            {
                _customer = GetCustomers<Customer>();
            }
            return _customer;
        }

        public static List<Employee> LoadEmployee()
        {
            if (_employee == null)
            {
                _employee = GetCustomers<Employee>();
            }
            return _employee;
        }

        public static List<T> GetCustomers<T>() where T : class
        {
            try
            {
                using (Stream stream = typeof(Data).GetTypeInfo().Assembly.GetManifestResourceStream("InputPanelSamples.Resources.customers.xml"))
                {
                    if (stream != null)
                    {
                        var xmls = new XmlSerializer(typeof(List<T>));
                        return (List<T>)xmls.Deserialize(stream);
                    }
                    return new List<T>();
                }
            }
            catch
            {
                throw new Exception(Strings.FileNotFoundException);
            }
        }

        private ObservableCollection<Employee> _employeeObservable;
        public ObservableCollection<Employee> EmployeeObservable
        {
            get
            {
                if (_employeeObservable == null)
                {
                    var list = new ObservableCollection<Employee>();
                    foreach (var employee in _employee)
                    {
                        list.Add(employee as Employee);
                    }
                    _employeeObservable = list;
                }
                return _employeeObservable;
            }
        }

        private ObservableCollection<Customer> _customerObservable;
        public ObservableCollection<Customer> CustomerObservable
        {
            get
            {
                if (_customerObservable == null)
                {
                    var list = new ObservableCollection<Customer>();
                    foreach (var customer in _customer)
                    {
                        list.Add(customer as Customer);
                    }
                    _customerObservable = list;
                }
                return _customerObservable;
            }
        }

        private ICollectionView _customerCollectionView;
        public ICollectionView CustomerCollectionView
        {
            get
            {
                if (_customerCollectionView == null)
                {
                    var list = new ObservableCollection<Customer>();
                    foreach (var customer in _customer)
                    {
                        list.Add(customer as Customer);
                    }
                    _customerCollectionView = new C1CollectionView(list);
                }
                return _customerCollectionView;
            }
        }
    }

    public enum Occupation
    {
        Doctor,
        Artist,
        Educator,
        Engineer,
        Executive,
        Other
    }

    public class Customer : INotifyPropertyChanged
    {
        // ** fields
        string _id;
        string _first, _last;
        string _country;
        DateTime? _birthDate;
        double _weight;
        int _age;
        private Occupation _occupation;
        private string _phone;
        bool _active;

        // ** ctors
        public Customer()
        {
        }

        // ** object model
        [Display(Name = "ID")]
        [Editable(false)]
        public string ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        [Display(Name = "Country")]
        public string Country
        {
            get { return _country; }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    NotifyPropertyChanged("Country");
                }
            }
        }

        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return First + " " + Last;
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string First
        {
            get
            {
                return _first;
            }
            set
            {
                if (value != _first)
                {
                    _first = value;

                    // call OnPropertyChanged with null parameter since setting this property
                    // modifies the value of "First" and also the value of "Name".
                    NotifyPropertyChanged("First");
                    NotifyPropertyChanged("Name");
                }
            }
        }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string Last
        {
            get
            {
                return _last;
            }
            set
            {
                if (value != _last)
                {
                    _last = value;

                    // call OnPropertyChanged with null parameter since setting this property
                    // modifies the value of "Last" and also the value of "Name".
                    NotifyPropertyChanged("Last");
                    NotifyPropertyChanged("Name");
                }
            }
        }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (value != _birthDate)
                {
                    _birthDate = value;
                    NotifyPropertyChanged("BirthDate");
                }
            }
        }

        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value != _age)
                {
                    _age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }

        [Display(Name = "Weight")]
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    NotifyPropertyChanged("Weight");
                }
            }
        }

        [Display(Name = "Occupation")]
        public Occupation Occupation
        {
            get
            {
                return _occupation;
            }
            set
            {
                if (value != _occupation)
                {
                    _occupation = value;
                    NotifyPropertyChanged("Occupation");
                }
            }
        }

        [Display(Name = "Phone Number")]
        [C1InputPanelMask("(000) 000-0000")]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    NotifyPropertyChanged("Phone");
                }
            }
        }

        [Display(Name = "Active")]
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (value != _active)
                {
                    _active = value;
                    NotifyPropertyChanged("Active");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    [XmlType("ArrayOfCustomer")]
    public class Employees
    {
        public List<Employee> employees { get; set; }
    }

    [XmlType("Customer")]
    public class Employee : INotifyPropertyChanged
    {
        // ** fields       
        string _id;
        DateTime? _birthDate;       
        int _age;
        private Occupation _occupation;
        private string _phone;
      
        // ** ctors
        public Employee()
        {
        }

        [Display(Name = "ID")]      
        public string ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (value != _birthDate)
                {
                    _birthDate = value;
                    NotifyPropertyChanged("BirthDate");
                }
            }
        }

        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value != _age)
                {
                    _age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }      

        [Display(Name = "Occupation")]
        public Occupation Occupation
        {
            get
            {
                return _occupation;
            }
            set
            {
                if (value != _occupation)
                {
                    _occupation = value;
                    NotifyPropertyChanged("Occupation");
                }
            }
        }

        [Display(Name = "Phone Number")]
        [C1InputPanelMask("(000) 000-0000")]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    NotifyPropertyChanged("Phone");
                }
            }
        }      

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
