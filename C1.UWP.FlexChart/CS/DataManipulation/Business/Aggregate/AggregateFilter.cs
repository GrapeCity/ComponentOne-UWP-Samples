using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation
{
    public class AggregateFilter : FilterBase
    {
        public class Pair
        {
            public string Key { get; set; }
            public double Value { get; set; }

            public Pair(string key, double value)
            {
                Key = key; Value = value;
            }
        }

        public override void Analyse()
        {
            IEnumerable<object> src = this.Source as IEnumerable<object>;

            if (src == null)
            {
                return;
            }
            if (!src.Any())
            {
                return;
            }

            IEnumerable<Pair> data;

            if (Bindings == null || Bindings.Length == 0)
            {
                data = from p in src
                       select new Pair(GetValueKey(p, new string[] { "Year", "M" }), GetValue(p, "Value"));
            }
            else
            {
                var groupedData = src.GroupBy(k => GetValueKey(k, Bindings));
                data = from p in groupedData select new Pair(GetValueKey(p.First(), Bindings).ToString(), (from k in p select GetValue(k, "Value")).Aggregate(AggregateType));
            }

            this.DataSource = data.ToArray();

            this.OnPropertyChanged("DataSource");
        }
        static string GetValueKey(object obj, string[] keys)
        {
            string r = string.Empty;
            foreach (var key in keys)
            {
                switch (key)
                {
                    case "Q":
                        r += " Q" + GetValue(obj, key);
                        break;
                    case "M":
                        DateTime dt = new DateTime(1900, Convert.ToInt32(GetValue(obj, key)), 1);
                        r += " " + dt.ToString("MMM");
                        break;
                    default:
                        r += GetValue(obj, key);
                        break;
                }
            }
            return r;
        }
    }

}
