using C1.Chart;
using System;
using System.Collections.Generic;

namespace DataManipulation
{
    public class AggregateViewModel: ViewModelBase<AggregateFilter>
    {
        static Random r = new Random();
        public AggregateViewModel()
        {
            Filter.AggregateType = AggregateType.Sum;
            Queue<AggregateItem> sis = new Queue<AggregateItem>();

            for (int i = 0; i < 240; i++)
            {
                int month = ((i % 12) + 1);
                int q = (month / 3) + ((month % 3) == 0 ? 0 : 1);
                int year = (1997 + (i - 1) / 12);

                sis.Enqueue(new AggregateItem()
                {
                    Year = year,
                    M = month.ToString(),
                    Q = q,
                    Value = r.Next(500),
                });
            }
            this.Source = sis;
        }

        public override AggregateFilter Filter
        {
            get
            {
                return base.Filter;
            }
            set
            {
                base.Filter = value;
            }
        }

        #region Selection Data
        
        private string _aggregateProperty = null;
        public string AggregateProperty
        {
            get
            {
                return _aggregateProperty;
            }
            set
            {
                string key = value;
                if (string.IsNullOrEmpty(key))
                {
                    Filter.Bindings = null;
                }

                switch (key)
                {
                    case "Year":
                        Filter.Bindings = new string[] { "Year" };
                        break;
                    case "Quarter":
                        Filter.Bindings = new string[] { "Year", "Q" };
                        break;
                    default:
                        Filter.Bindings = null;
                        break;
                }
            }
        }

        private Dictionary<string, AggregateType> _aggregateTypes;
        public Dictionary<string, AggregateType> AggregateTypes
        {
            get
            {
                if (_aggregateTypes == null)
                {
                    _aggregateTypes = new Dictionary<string, AggregateType>();
                    foreach (var item in Enum.GetValues(typeof(AggregateType)))
                    {
                        _aggregateTypes.Add("Aggregate Type: " + ((AggregateType)item).ToString(), (AggregateType)item);
                    }
                }
                return _aggregateTypes;
            }
        }

        private Dictionary<string, string> _aggregateProperties;
        public Dictionary<string, string> AggregateProperties
        {
            get
            {
                if (_aggregateProperties == null)
                {
                    _aggregateProperties = new Dictionary<string, string>();
                    _aggregateProperties.Add("Aggregate Property: Null", "");
                    _aggregateProperties.Add("Aggregate Property: Quarter", "Quarter");
                    _aggregateProperties.Add("Aggregate Property: Year", "Year");

                }
                return _aggregateProperties;
            }
        }

        #endregion Selection Data

    }
}
