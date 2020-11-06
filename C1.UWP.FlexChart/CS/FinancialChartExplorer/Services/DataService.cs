using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace FinancialChartExplorer
{
    public class DataService
    {
        List<Company> _companies = new List<Company>();
        Dictionary<string, List<Quote>> _cache = new Dictionary<string, List<Quote>>();

        private DataService()
        {
            _companies.Add(new Company() { Symbol = "box", Name = "Box Inc" });
            _companies.Add(new Company() { Symbol = "fb", Name = "Facebook" });
        }

        public List<Company> GetCompanies()
        {
            return _companies;
        }

        public List<T> GetData<T>(string symbol)
        {
            string path = string.Format("FinancialChartExplorer.Resources.{0}.json", symbol);
            var asm = this.GetType().GetTypeInfo().Assembly;
            var stream = asm.GetManifestResourceStream(path);
            var ser = new DataContractJsonSerializer(typeof(T[]));
            var data = (T[])ser.ReadObject(stream);

            return data.ToList();
        }

        public List<Quote> GetSymbolData(string symbol, int count = 20)
        {
            if (!_cache.Keys.Contains(symbol))
            {
                var dataList = GetData<Quote>(symbol);
                _cache.Add(symbol, dataList);
            }
            if (IsWindowsPhoneDevice())
            {
                var dataList = _cache[symbol] as List<Quote>;
                return dataList.Take(count).ToList();
            }
            return _cache[symbol];
        }

        public bool IsWindowsPhoneDevice()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                return true;
            }
            return false;
        }

        public Range FindRenderedYRange(List<Quote> data, double xmin, double xmax)
        {
            Quote item;
            double ymin = double.NaN;
            double ymax = double.NaN;

            for (int i = 0; i < data.Count; i++)
            {
                item = data[i];
                if (xmin > i || i > xmax)
                {
                    continue;
                }
                if (double.IsNaN(ymax) || item.High > ymax)
                {
                    ymax = item.High;
                }
                if (double.IsNaN(ymin) || item.Low < ymin)
                {
                    ymin = item.Low;
                }
            }

            return new Range() { Min = ymin, Max = ymax };
        }

        public Range FindApproxRange(double min, double max, double percent)
        {
            var range = new Range();
            range.Max = max;
            range.Min = (max - min) * (1 - percent) + min;
            return range;
        }

        static DataService _ds;
        public static DataService GetService()
        {
            if (_ds == null)
                _ds = new DataService();
            return _ds;
        }
    }

    [DataContract]
    public class Quote
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "high")]
        public double High { get; set; }

        [DataMember(Name = "low")]
        public double Low { get; set; }

        [DataMember(Name = "open")]
        public double Open { get; set; }

        [DataMember(Name = "close")]
        public double Close { get; set; }

        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        public System.DateTime date
        {
            get { return System.DateTime.ParseExact(Date.ToString(), "MM/dd/yy", System.Globalization.CultureInfo.InvariantCulture); }
        }
    }

    [DataContract]
    public class Annotation
    {
        [DataMember(Name = "title")]
        public string Title
        {
            get; set;
        }

        [DataMember(Name = "description")]
        public string Description
        {
            get; set;
        }

        [DataMember(Name = "publicationDate")]
        public string PublicationDate
        {
            get; set;
        }

        [DataMember(Name = "dataIndex")]
        public int DataIndex
        {
            get; set;
        }
    }

    public class Range
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public class Company
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
