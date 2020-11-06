﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;

namespace FlexGridSamples
{
    /// <summary>
    /// Based on this: http://en.wikipedia.org/wiki/Market_data
    /// </summary>
    public class FinancialData : INotifyPropertyChanged
    {
        const int HISTORY_SIZE = 5;
        List<decimal> _askHistory = new List<decimal>();
        List<decimal> _bidHistory = new List<decimal>();
        List<decimal> _saleHistory = new List<decimal>();

        [Display(Name = "Symbol")]
        public string Symbol
        {
            get { return (string)GetProp("Symbol"); }
            set { SetProp("Symbol", value); }
        }

        [Display(Name = "Name")]
        public string Name
        {
            get { return (string)GetProp("Name"); }
            set { SetProp("Name", value); }
        }

        [Display(Name = "Bid")]
        public decimal Bid
        {
            get { return (decimal)GetProp("Bid"); }
            set
            {
                AddHistory(_bidHistory, value);
                SetProp("Bid", value);
            }
        }

        [Display(Name = "Ask")]
        public decimal Ask
        {
            get { return (decimal)GetProp("Ask"); }
            set
            {
                AddHistory(_askHistory, value);
                SetProp("Ask", value);
            }
        }

        [Display(Name = "LastSale")]
        public decimal LastSale
        {
            get { return (decimal)GetProp("LastSale"); }
            set
            {
                AddHistory(_saleHistory, value);
                SetProp("LastSale", value);
            }
        }

        [Display(Name = "BidSize")]
        public int BidSize
        {
            get { return (int)GetProp("BidSize"); }
            set { SetProp("BidSize", value); }
        }

        [Display(Name = "AskSize")]
        public int AskSize
        {
            get { return (int)GetProp("AskSize"); }
            set { SetProp("AskSize", value); }
        }

        [Display(Name = "LastSize")]
        public int LastSize
        {
            get { return (int)GetProp("LastSize"); }
            set { SetProp("LastSize", value); }
        }

        [Display(Name = "Volume")]
        public int Volume
        {
            get { return (int)GetProp("Volume"); }
            set { SetProp("Volume", value); }
        }

        [Display(Name = "QuoteTime")]
        public DateTime QuoteTime
        {
            get { return (DateTime)GetProp("QuoteTime"); }
            set { SetProp("QuoteTime", value); }
        }

        [Display(Name = "TradeTime")]
        public DateTime TradeTime
        {
            get { return (DateTime)GetProp("TradeTime"); }
            set { SetProp("TradeTime", value); }
        }
        public List<decimal> GetHistory(string propName)
        {
            switch (propName)
            {
                case "Ask":
                    return _askHistory;
                case "Bid":
                    return _bidHistory;
                case "LastSale":
                    return _saleHistory;
            }
            return null;
        }
        void AddHistory(List<decimal> list, decimal value)
        {
            while (list.Count >= HISTORY_SIZE)
            {
                list.RemoveAt(0);
            }
            while (list.Count < HISTORY_SIZE)
            {
                list.Add(value);
            }
        }

        Dictionary<string, object> _propBag = new Dictionary<string, object>();
        object GetProp(string propName)
        {
            object value = null;
            _propBag.TryGetValue(propName, out value);
            return value;
        }
        void SetProp(string propName, object value)
        {
            if (!_propBag.ContainsKey(propName) || GetProp(propName) != value)
            {
                _propBag[propName] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        // get a default list of financial items
        public async static Task<FinancialDataList> GetFinancialData()
        {
            var list = new FinancialDataList();
            var rnd = new Random(0);

            Uri resourceUri;
            if (typeof(FinancialData).GetTypeInfo().Module.Name.EndsWith("exe"))
            {
                resourceUri = new Uri("ms-appx:///Resources/StockSymbols.txt");
            }
            else
            {
                resourceUri = new Uri("ms-appx:///FlexGridSamplesLib/Resources/StockSymbols.txt");
            }
            var file = await StorageFile.GetFileFromApplicationUriAsync(resourceUri);
            var fileStream = await file.OpenAsync(FileAccessMode.Read);

            using (var sr = new StreamReader(fileStream.AsStream()))
            {
                while (!sr.EndOfStream)
                {
                    var sn = sr.ReadLine().Split('\t');
                    if (sn.Length > 1 && sn[0].Trim().Length > 0)
                    {
                        var data = new FinancialData();
                        data.Symbol = sn[0];
                        data.Name = sn[1];
                        data.Bid = rnd.Next(1, 1000);
                        data.Ask = data.Bid + (decimal)rnd.NextDouble();
                        data.LastSale = data.Bid;
                        data.BidSize = rnd.Next(10, 500);
                        data.AskSize = rnd.Next(10, 500);
                        data.LastSize = rnd.Next(10, 500);
                        data.Volume = rnd.Next(10000, 20000);
                        data.QuoteTime = DateTime.Now;
                        data.TradeTime = DateTime.Now;
                        list.Add(data);
                    }
                }
            }
            list.AutoUpdate = true;
            return list;
        }
    }

    public class FinancialDataList : List<FinancialData>
    {
        // fields
        C1.Util.Timer _timer;
        Random _rnd = new Random(0);

        // fields
        int _updateInterval = 100;
        bool _autoUpdate = false; 

        // object model
        public int UpdateInterval
        {
            get { return _updateInterval; }
            set
            {
                if (_updateInterval != value)
                {
                    _updateInterval = value;
                    UpdateTimer();
                }
            }
        }
        public int BatchSize { get; set; }
        public bool AutoUpdate
        {
            get { return _autoUpdate; }
            set
            {
                if (_autoUpdate != value)
                {
                    _autoUpdate = value;
                    UpdateTimer();
                }
            }
        }

        // ctor
        public FinancialDataList()
        {
            BatchSize = 100;
        }

        void UpdateTimer()
        {
            if (AutoUpdate)
            {
                if (_timer == null)
                {
                    _timer = new C1.Util.Timer();
                    _timer.Tick += _timer_Tick;
                }
                _timer.Interval = TimeSpan.FromMilliseconds(UpdateInterval);
                _timer.IsEnabled = true;
            }
            else if ( _timer != null)
            {
                _timer.IsEnabled = false;
                _timer.Tick -= _timer_Tick;
                _timer = null;
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (this.Count > 0)
            {
                for (int i = 0; i < BatchSize; i++)
                {
                    int index = _rnd.Next() % this.Count;
                    var data = this[index];
                    for (bool ok = false; !ok; )
                    {
                        try
                        {
                            data.Bid = data.Bid * (decimal)(1 + (_rnd.NextDouble() * .11 - .05));
                            data.Ask = data.Ask * (decimal)(1 + (_rnd.NextDouble() * .11 - .05));
                            ok = true;
                        }
                        catch { }
                    }
                    data.BidSize = _rnd.Next(10, 1000);
                    data.AskSize = _rnd.Next(10, 1000);
                    var sale = (data.Ask + data.Bid) / 2;
                    data.LastSale = sale;
                    data.LastSize = (data.AskSize + data.BidSize) / 2;
                    data.QuoteTime = DateTime.Now;
                    data.TradeTime = DateTime.Now.AddSeconds(-_rnd.Next(0, 60));
                }
            }
        }
    }
}
