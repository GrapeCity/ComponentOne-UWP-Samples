using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace StockChart
{

    class DataService
    {
        static Dictionary<string, string> _names = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        static Dictionary<string, QuoteData> _prices = new Dictionary<string, QuoteData>(StringComparer.OrdinalIgnoreCase);

        static DataService()
        {
        }

        private DataService()
        {

        }

        private static DataService _instance;
        public static DataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataService();
                }
                return _instance;
            }
        }

        public Dictionary<string, string> SymbolNames
        {
            get
            {
                // load company names (once)
                if (_names.Count == 0)
                {
                    foreach (var line in Data.DataPort.SymbolNames)
                    {
                        if (line != null)
                        {
                            var parts = line.Split('\t');
                            if (parts.Length >= 2)
                            {
                                var key = parts[0].Trim();
                                var value = parts[1].Trim();
                                if (key.Length > 0 && value.Length > 0)
                                {
                                    _names[key] = value;
                                }
                            }
                        }
                    }
                }
                return _names;
            }
        }

        public string GetSymbolName(string symbol)
        {
            string value = null;
            if (_names != null)
            {
                if (_names.TryGetValue(symbol, out value))
                {
                    return value + "(" + symbol.ToUpper() + ")";
                }
            }
            return value;
        }

        public QuoteData GetSymbolData(string symbol, Action<string> onWebError = null)
        {
            // try getting from cache
            QuoteData quoteCache;
            if (_prices.TryGetValue(symbol, out quoteCache))
            {
                return quoteCache;
            }
            QuoteData quoteData = new QuoteData();

            // not in cache, get now
            var t = DateTime.Today;
            var startDate = new DateTime(t.Year - 10, 1, 1);
            var fmt = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={0}&apikey=IF6RVQ6S90CZZ7VJ&datatype=csv&outputsize=full";
            var url = string.Format(fmt, symbol);


            // get content
            var sb = new StringBuilder();
            var request = System.Net.WebRequest.Create(url);


            var task = request.GetResponseAsync(); //where it's exiting

            try
            {
                using (var sr = new StreamReader(task.Result.GetResponseStream()))
                {
                    // skip headers
                    sr.ReadLine();

                    // read each line
                    for (var line = sr.ReadLine(); line != null; line = sr.ReadLine())
                    {
                        // append date (field 0) and adjusted close price (field 6)
                        var items = line.Split(',');
                        {
                            Quote q = new Quote(quoteData.ReferenceValue)
                            {

                                date = DateTime.Parse(items[0]),
                                open = Convert.ToDouble(items[1]),
                                high = Convert.ToDouble(items[2]),
                                low = Convert.ToDouble(items[3]),
                                close = Convert.ToDouble(items[4]),
                                volume = Convert.ToDouble(items[5]),
                            };
                            if(q.date < startDate) break;
                            quoteData.Add(q);
                        }
                    }
                }
            }
            catch (AggregateException ex)
            {
                if (onWebError != null)
                {
                    onWebError(ex.Message);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message); 
                }
            }
            catch (System.Net.WebException ex)
            {
                if (onWebError != null)
                {
                    onWebError(ex.Message);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            FillEvents(symbol, quoteData);

            quoteData.Reverse();
            _prices[symbol] = quoteData;

            return quoteData;
        }

        public async void GetSymbolDataAsync(string symbol, Action<QuoteData> onCallback, Action<string> onWebError = null)
        {
            await Windows.System.Threading.ThreadPool.RunAsync(
              (workItem) =>
              {
                  var data = GetSymbolData(symbol, onWebError);
                  if (onCallback != null)
                  {
                      onCallback(data);
                  }
              });
        }

        private void FillEvents(string symbol, IEnumerable<Quote> qs)
        {
            // not in cache, get now
            var fmt = "http://articlefeeds.nasdaq.com/nasdaq/symbols?symbol={0}";
            var url = string.Format(fmt, symbol);

            // get content
            var sb = new StringBuilder();

            try
            {
                var request = System.Net.WebRequest.Create(url);

                var task = request.GetResponseAsync(); //where it's exiting

                using (var stream = task.Result.GetResponseStream())
                {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.Load(stream);

                    var items = doc.GetElementsByTagName("item");
                    // read each line
                    foreach (System.Xml.XmlNode item in items)
                    {
                        var dt = DateTime.Parse(item["pubDate"].InnerText);
                        var text = item["title"].InnerText;

                        var quote = qs.FirstOrDefault(q => (q.date - dt).Days == 0);

                        if (quote != null)
                        {
                            if (quote.events != null)
                            {
                                if (quote.events.Length > 0)
                                {
                                    quote.events += Environment.NewLine;
                                }
                                quote.events += text;
                            }
                            else
                            {
                                quote.events = text;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public QuoteRange GetSymbolYRange(IEnumerable<Quote> quoteData, double s, double e, string porperty = null)
        {
            QuoteRange qr = null;
            DateTime ds = Utilities.FromOADate(s); //  DateTime.FromOADate(s);
            DateTime de = Utilities.FromOADate(e);
            IEnumerable<Quote> quoteCache = from p in quoteData where p.date >= ds && p.date <= de select p;

            if (quoteCache.Any())
            {
                qr = new QuoteRange();
                qr.PriceMin = quoteCache.Min((k) =>
                {
                    if (string.IsNullOrEmpty(porperty) || porperty.ToUpper() == "high,low,open,close".ToUpper())
                    {
                        return k.low;
                    }
                    else
                    {
                        return k.GetValue(porperty);
                    }
                });
                qr.PriceMax = quoteCache.Max((k) =>
                {
                    if (string.IsNullOrEmpty(porperty) || porperty.ToUpper() == "high,low,open,close".ToUpper())
                    {
                        return k.high;
                    }
                    else
                    {
                        return k.GetValue(porperty);
                    }
                });
                qr.VolumeMin = quoteCache.Min(k => k.volume);
                qr.VolumeMax = quoteCache.Max(k => k.volume);
            }
            return qr;
        }


    }
}
