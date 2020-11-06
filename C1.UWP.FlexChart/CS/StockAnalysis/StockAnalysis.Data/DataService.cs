using StockAnalysis.Object;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Data
{
    public class QuoteEventArg : EventArgs
    {
        public QuoteEventArg(Quote quote)
        {
            Quote = quote;
        }

        public Object.Quote Quote
        {
            get;
            set;
        }
    }
    public class QuotesEventArg : EventArgs
    {
        public QuotesEventArg(IEnumerable<Object.Quote> quotes)
        {
            Quotes = quotes;
        }

        public IEnumerable<Object.Quote> Quotes
        {
            get;
            set;
        }
    }

    public class DataService
    {
        public static async void GetQuotesAsync(Dictionary<string, string> symbols, EventHandler<QuotesEventArg> callback)
        {
            Stack<Object.Quote> quotes = new Stack<Object.Quote>();
            foreach (var symbol in symbols)
            {
                var quote = await GetQuote(symbol);
                quotes.Push(quote);
            }
            var ordered = quotes.OrderBy(p => p != null ? p.Name : string.Empty);
            callback(quotes, new QuotesEventArg(ordered));
        }

        public static async Task<Object.Quote> GetQuote(KeyValuePair<string, string> symbol)
        {
            string url = string.Format("http://www.nasdaq.com/symbol/{0}/historical", symbol.Key);
            string reqStr = "1y|true|" + symbol.Key.ToUpper();

            return new Object.Quote()
            {
                Symbol = symbol.Key,
                Name = symbol.Value,
                //Data = Request(url, reqStr, Encoding.ASCII),
                Data = await Request(symbol.Key.ToLower(), Encoding.ASCII)
            };
        }
        internal async static Task<IEnumerable<Object.QuoteData>> Request(string symbolName, Encoding encoding)
        {
            Stack<Object.QuoteData> datas = new Stack<Object.QuoteData>();
            try
            {
                var filePath = new Uri("ms-appx:///Assets/Data/" + symbolName + ".csv");

                var storagefile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(filePath);

                try
                {
                    using (Stream stream = await storagefile.OpenStreamForReadAsync())
                    {
                        using (StreamReader sr = new StreamReader(stream, encoding))
                        {
                            // skip headers
                            sr.ReadLine();
                            sr.ReadLine();

                            for (var line = sr.ReadLine(); line != null; line = sr.ReadLine())
                            {
                                var data = ParseLine(line);
                                if (data != null)
                                {
                                    try
                                    {
                                        datas.Push(data);
                                    }
                                    catch (Exception ex)
                                    {
                                        System.Diagnostics.Debug.WriteLine(ex.Message);
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                    return datas;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return datas;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return datas;
            }




        }



        private static IEnumerable<QuoteData> Request(string url, string data, Encoding encoding)
        {
            int retryCounter = 3;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            var bs = encoding.GetBytes(data);

            QuoteData quoteCache = new QuoteData();
            RETRY:
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url.ToLower());
                request.Method = "POST";
                request.ContentType = "application/json";


                Stream stream = null;
                var t = Task.Run(() => stream = request.GetRequestStreamAsync().Result);
                t.Wait();

                stream.Write(bs, 0, bs.Length);
                stream.Flush();


                var t1 = Task.Run(() => response = (HttpWebResponse)request.GetResponseAsync().Result);
                t1.Wait();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                if (retryCounter > 0)
                {
                    request.Abort();
                    retryCounter--;
                    goto RETRY;
                }
            }

            if ((response == null || response.StatusCode != HttpStatusCode.OK) && retryCounter > 0)
            {
                request.Abort();
                retryCounter--;
                goto RETRY;
            }

            Stack<QuoteData> datas = new Stack<QuoteData>();
            try
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, encoding))
                    {
                        // skip headers
                        sr.ReadLine();
                        sr.ReadLine();

                        for (var line = sr.ReadLine(); line != null; line = sr.ReadLine())

                        {
                            datas.Push(ParseLine(line));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }

            return datas;
        }

        private static Object.QuoteData ParseLine(string line)
        {
            line = line.Replace("\"", string.Empty);

            var items = line.Split(',');
            Object.QuoteData data = new Object.QuoteData()
            {
                //"\"date\",\"close\",\"volume\",\"open\",\"high\",\"low\""
                Date = items[0].ToString(),
                Open = Convert.ToDouble(items[3]),
                High = Convert.ToDouble(items[4]),
                Low = Convert.ToDouble(items[5]),
                Close = Convert.ToDouble(items[1]),
                Volume = Convert.ToDouble(items[2]),
                LocalDate = Convert.ToDateTime(items[0])
            };

            return data;
        }

    }
}
