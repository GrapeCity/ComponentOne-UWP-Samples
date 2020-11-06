using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Windows.UI.Xaml.Data;

namespace FlexGridSamples
{
    public class Product : INotifyPropertyChanged, IEditableObject
    {
        static string[] _lines = Strings.Lines.Split('|');
        static string[] _colors = Strings.Colors.Split('|');
        static string[] _names = Strings.ProductName.Split('|');

        // object model
        [Display(Name = "Line")]
        public string Line
        {
            get
            {
                return (string)GetValue("Line");
            }
            set
            {
                SetValue("Line", value);
            }
        }

        [Display(Name = "Color")]
        public string Color
        {
            get
            {
                return (string)GetValue("Color");
            }
            set
            {
                SetValue("Color", value);
            }
        }

        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return (string)GetValue("Name");
            }
            set
            {
                SetValue("Name", value);
            }
        }

        [Display(Name = "Price")]
        public double Price
        {
            get
            {
                return (double)GetValue("Price");
            }
            set
            {
                SetValue("Price", value);
            }
        }

        [Display(Name = "Weight")]
        public double Weight
        {
            get
            {
                return (double)GetValue("Weight");
            }
            set
            {
                SetValue("Weight", value);
            }
        }

        [Display(Name = "Cost")]
        public double Cost
        {
            get
            {
                return (double)GetValue("Cost");
            }
            set
            {
                SetValue("Cost", value);
            }
        }

        [Display(Name = "Volume")]
        public double Volume
        {
            get
            {
                return (double)GetValue("Volume");
            }
            set
            {
                SetValue("Volume", value);
            }
        }

        [Display(Name = "Discontinued")]
        public bool Discontinued
        {
            get
            {
                return (bool)GetValue("Discontinued");
            }
            set
            {
                SetValue("Discontinued", value);
            }
        }

        [Display(Name = "Rating")]
        public int Rating
        {
            get
            {
                return (int)GetValue("Rating");
            }
            set
            {
                SetValue("Rating", value);
            }
        }

        // get/set values
        Dictionary<string, object> _values = new Dictionary<string, object>();
        object GetValue(string p)
        {
            object value;
            _values.TryGetValue(p, out value);
            return value;
        }
        void SetValue(string p, object value)
        {
            if (!object.Equals(value, GetValue(p)))
            {
                _values[p] = value;
                OnPropertyChanged(p);
            }
        }
        protected virtual void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        // factory
        public static ICollectionView GetProducts(int count)
        {
            var list = new ObservableCollection<Product>();
            var rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                var p = new Product();
                p.Line = _lines[rnd.Next() % _lines.Length];
                p.Color = _colors[rnd.Next() % _colors.Length];
                p.Name = _names[rnd.Next() % _names.Length];
                p.Price = rnd.Next(1, 1000);
                p.Weight = rnd.Next(1, 100);
                p.Cost = rnd.Next(1, 600);
                p.Volume = rnd.Next(500, 5000);
                p.Discontinued = rnd.NextDouble() < .1;
                p.Rating = rnd.Next(0, 5);
                list.Add(p);
            }
            return new CollectionViewSource() { Source = list }.View;
        }
        public static string[] GetLines()
        {
            return _lines;
        }
        public static string[] GetColors()
        {
            return _colors;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region IEditableObject Members

        static Dictionary<string, object> _clone;
        public void BeginEdit()
        {
            if (_clone == null)
            {
                _clone = new Dictionary<string, object>();
            }
            _clone.Clear();
            foreach (var key in _values.Keys)
            {
                _clone[key] = _values[key];
            }
        }
        public void CancelEdit()
        {
            _values.Clear();
            foreach (var key in _clone.Keys)
            {
                _values[key] = _clone[key];
            }
        }
        public void EndEdit()
        {
        }

        #endregion
    }
}
