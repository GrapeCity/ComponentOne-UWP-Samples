using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BasicLibrarySamples
{
    public class Customer : BaseEditableObject
    {
        int _id;
        string _name, _country;
        DateTime _created;
        double _value, _sales, _assets, _growth;
        bool _active;

        static int _ctr;
        static Random _rnd = new Random();
        static string[] _countries = Strings.CollectionViewCustomerCountries.Split('|');
        static string[] _names = Strings.CollectionViewCustomerNames.Split('|');

        public static ObservableCollection<Customer> GetCollection(int count)
        {
            ObservableCollection<Customer> ret = new ObservableCollection<Customer>();
            for (int i = 0; i < count; i++)
                ret.Add(new Customer());
            return ret;
        }

        public Customer()
        {
            ID = _ctr++;
            Name = _names[_rnd.Next() % _names.Length];
            Country = _countries[_rnd.Next() % _countries.Length];
            Created = DateTime.Today.AddDays(_rnd.Next(-40, -30));
            for (int i = 0; i < 100; i++)
            {
                Assets += _rnd.NextDouble() * 100;
                Value += _rnd.NextDouble() * 1000;
                Sales += _rnd.NextDouble() * 100;
            }
            if (_rnd.NextDouble() < .05)
            {
                Value = -Value;
                Assets = -Assets;
            }
            if (_rnd.NextDouble() < .05)
            {
                Growth = -Growth;
            }
            Growth = _rnd.NextDouble();
            Active = _rnd.NextDouble() > .5;
        }

        [Display(Name = "ID")]
        public int ID
        {
            get { return _id; }
            set { SetValue(ref _id, value, "ID"); }
        }

        [Display(Name = "Name")]
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value, "Name"); }
        }

        [Display(Name = "Country")]
        public string Country
        {
            get { return _country; }
            set { SetValue(ref _country, value, "Country"); }
        }

        [Display(Name = "Created")]
        public DateTime Created
        {
            get { return _created; }
            set { SetValue(ref _created, value, "Created"); }
        }

        [Display(Name = "Sales")]
        public double Sales
        {
            get { return _sales; }
            set { SetValue(ref _sales, value, "Sales"); }
        }

        [Display(Name = "Growth")]
        public double Growth
        {
            get { return _growth; }
            set { SetValue(ref _growth, value, "Growth"); }
        }

        [Display(Name = "Assets")]
        public double Assets
        {
            get { return _assets; }
            set { SetValue(ref _assets, value, "Assets"); }
        }

        [Display(Name = "Value")]
        public double Value
        {
            get { return _value; }
            set { SetValue(ref _value, value, "Value"); }
        }

        [Display(Name = "Active")]
        public bool Active
        {
            get { return _active; }
            set { SetValue(ref _active, value, "Active"); }
        }
    }
}
