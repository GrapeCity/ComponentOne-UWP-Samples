using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Specialized;
using C1.Xaml.Chart;


using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace SalesDashboard2015.DataModel
{
    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public class SampleDataSource : SalesDashboard2015.Common.BindableBase
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();
        private DateTime startDate = new DateTime(2009, 1, 1);
        private int numPoints = 730;
        private string[] types = new string[] { "Console", "Desktop", "Phone", "Tablet", "TV" };
        private string[] categories = new string[] { Strings.Desktop, Strings.Mobile, Strings.Other };
        private string[] partners = new string[] { Strings.Partner1, Strings.Partner2, Strings.Partner3, Strings.Partner4, Strings.Partner5, Strings.Partner6 };
        private string[] quarters = new string[] { Strings.Q1, Strings.Q2, Strings.Q3, Strings.Q4 };
        private List<Region> regions = new List<Region>();

        private ObservableCollection<SampleDataItem> _allSales = new ObservableCollection<SampleDataItem>();
        public ObservableCollection<SampleDataItem> AllSales
        {
            get { return this._allSales; }
        }

        #region Total Sales
        public double TotalSales
        {
            get
            {
                double runningTotal = 0;
                foreach (SampleDataItem item in _allSales)
                {
                    runningTotal += item.SaleAmount;
                }
                return runningTotal;
            }
        }
        #endregion

        #region Sales by Type
        private double _totalSalesConsole;
        public double TotalSalesConsole
        {
            get
            {
                return _totalSalesConsole;
            }
        }

        private double _totalSalesDesktop;
        public double TotalSalesDesktop
        {
            get
            {
                return _totalSalesDesktop;
            }
        }

        private double _totalSalesPhone;
        public double TotalSalesPhone
        {
            get
            {
                return _totalSalesPhone;
            }
        }

        private double _totalSalesTablet;
        public double TotalSalesTablet
        {
            get
            {
                return _totalSalesTablet;
            }
        }

        private double _totalSalesTV;
        public double TotalSalesTV
        {
            get
            {
                return _totalSalesTV;
            }
        }
        #endregion

        #region Sales by Partner

        public List<PartnersData> SalesByPartner
        {
            get
            {
                // group all sales by partner
                IEnumerable<IGrouping<string, SampleDataItem>> query = from sale in _allSales
                                                                       group sale by sale.Partner;
                List<PartnersData> partnersDatas = new List<PartnersData>();
                int index = 0;
                foreach (var group in query)
                {
                    PartnersData data = new PartnersData();
                    double runningTotal = 0;
                    foreach (SampleDataItem item in group)
                    {
                        runningTotal += item.SaleAmount;
                    }
                    data.TotalSale = runningTotal;
                    data.PartnersName = partners[index];
                    index++;
                    partnersDatas.Add(data);
                }
                return partnersDatas;
            }
        }

        #endregion

        #region Sales by Category
        public List<CategoryData> SalesByCategory
        {
            get
            {
                // group all sales by category
                IEnumerable<IGrouping<string, SampleDataItem>> query = from sale in _allSales
                                                                       group sale by sale.Category;
                List<CategoryData> dataList = new List<CategoryData>();
                int index = 0;
                double totalCategoryNumber = 0;
                double totalSaleNumber = 0;
                foreach (var group in query)
                {
                    CategoryData data = new CategoryData();
                    foreach (SampleDataItem item in group)
                        totalCategoryNumber += item.SaleAmount;
                    data.CategoryName = categories[index];
                    data.TotalSale = totalCategoryNumber;
                    dataList.Add(data);
                    totalSaleNumber += totalCategoryNumber;
                    totalCategoryNumber = 0;
                    index++;
                }
                foreach(CategoryData data in dataList)
                {
                    double curNumber = data.TotalSale;
                    data.Percent = curNumber / totalSaleNumber * 100;
                    data.Percent = double.Parse(Convert.ToDouble(data.Percent).ToString("0.00"));
                }
                return dataList;
            }
        }
        #endregion

        //#region Sales by Region
        public List<RegionData> SalesByRegion
        {
            get
            {
                // group all sales by category
                IEnumerable<IGrouping<Region, SampleDataItem>> query = from sale in _allSales
                                                                       group sale by sale.Region;
                List<RegionData> regionDatas = new List<RegionData>();
                foreach (var region in query)
                {
                    RegionData data = new RegionData();
                    SampleDataItem firstItem = region.First<SampleDataItem>();
                    data.Longitude = firstItem.Region.Longitude;
                    data.Latitude = firstItem.Region.Latitude;
                    data.RegionName = firstItem.Region.Name;
                    double runningTotal = 0;
                    // calculate total for group
                    foreach (SampleDataItem item in region)
                        runningTotal += item.SaleAmount;
                    data.SaleValue = runningTotal;
                    regionDatas.Add(data);
                }
                return regionDatas;
            }
        }

        //#endregion

        #region Sales by Quarter

        public List<QuarterData> SalesByQuarter
        {
            get
            {
                // group all sales by year
                IEnumerable<IGrouping<int, SampleDataItem>> yearGroup = from sale in _allSales
                                                                        group sale by sale.SaleDate.Year;
                List<QuarterData> quarterDatas = new List<QuarterData>();
                foreach(var year in yearGroup)
                {
                    IEnumerable<IGrouping<int, SampleDataItem>> monthGroup = from sale in year
                                                                             group sale by sale.SaleDate.Month;
                    SampleDataItem firstItem = year.First<SampleDataItem>();
                    double saleNumber = 0;
                    int counter = 1;
                    foreach (var month in monthGroup)
                    {
                        foreach (SampleDataItem item in month)
                        {
                            saleNumber += item.SaleAmount;
                        }
                        if (counter.Equals(3)||counter.Equals(6)||counter.Equals(9)||counter.Equals(12))
                        {
                            if (quarterDatas.Count < (counter / 3))
                            {
                                QuarterData data = new QuarterData();
                                if (firstItem.SaleDate.Year.Equals(2009))
                                    data.Year2009 = saleNumber;
                                else
                                    data.Year2010 = saleNumber;
                                data.Quarter = quarters[counter / 3 - 1];
                                quarterDatas.Add(data);
                            }
                            else
                            {
                                if (firstItem.SaleDate.Year.Equals(2009))
                                    quarterDatas[counter / 3 - 1].Year2009 = saleNumber;
                                else
                                    quarterDatas[counter / 3 - 1].Year2010 = saleNumber;
                            }
                            saleNumber = 0;
                        }
                        counter += 1;
                    }
                }
                return quarterDatas;
            }
        }

        #endregion

        public SampleDataSource()
        {
            InitializeRegions();

            Random rnd = new Random();
            for (int i = 0; i < numPoints; i++)
            {
                _allSales.Add(new SampleDataItem(Guid.NewGuid().ToString(),
                    types[rnd.Next(types.Length)],
                    categories[rnd.Next(categories.Length)],
                    partners[rnd.Next(partners.Length)],
                    regions[rnd.Next(regions.Count)],
                    startDate.AddDays(i),
                    rnd.Next(0, i)));
            }

            CalculateTotalSales();
        }

        private void InitializeRegions()
        {
            regions.Add(new Region() { Name = Strings.Spain, Latitude = 40.6986, Longitude = -3.2949 });
            regions.Add(new Region() { Name = Strings.USA, Latitude = 40.4230, Longitude = -98.7372 });
            regions.Add(new Region() { Name = Strings.Brazil, Latitude = -15.6778, Longitude = -47.4384 });
            regions.Add(new Region() { Name = Strings.Uruguay, Latitude = -33.0000, Longitude = -56.0000 });
            regions.Add(new Region() { Name = Strings.Russia, Latitude = 54.8270, Longitude = 55.0423 });
            regions.Add(new Region() { Name = Strings.China, Latitude = 32.9043, Longitude = 110.4677 });
            regions.Add(new Region() { Name = Strings.Japan, Latitude = 35.4112, Longitude = 135.8337 });

        }

        private void CalculateTotalSales()
        {

            _totalSalesConsole = 0;
            _totalSalesDesktop = 0;
            _totalSalesPhone = 0;
            _totalSalesTablet = 0;
            _totalSalesTV = 0;
            foreach (SampleDataItem item in _allSales)
            {
                if (item.Type.Equals("TV"))
                    _totalSalesTV += item.SaleAmount;
                else if (item.Type.Equals("Desktop"))
                    _totalSalesDesktop += item.SaleAmount;
                else if (item.Type.Equals("Console"))
                    _totalSalesConsole += item.SaleAmount;
                else if (item.Type.Equals("Tablet"))
                    _totalSalesTablet += item.SaleAmount;
                else if (item.Type.Equals("Phone"))
                    _totalSalesPhone += item.SaleAmount;
            }
        }
    }

    /// <summary>
    /// Quarter item data model
    /// </summary>
    public class QuarterData
    {
        public string Quarter { get; set; }
        public double Year2010 { get; set; }
        public double Year2009 { get; set; }  
    }

    /// <summary>
    /// Partners item data model
    /// </summary>
    public class PartnersData
    {
        public string PartnersName { get; set; }
        public double TotalSale { get; set; }
    }

    /// <summary>
    /// Region item data model
    /// </summary>
    public class RegionData
    {
        public string RegionName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double SaleValue { get; set; }
    }

    public class CategoryData
    {
        public string CategoryName { get; set; }
        public double TotalSale { get; set; }
        public double Percent { get; set; }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SalesDashboard2015.Common.BindableBase
    {
        public SampleDataItem() { }

        public SampleDataItem(String uniqueId, String type, String category, String partner, Region region, DateTime saleDate, double saleAmount)
        {
            this._uniqueId = uniqueId;
            this._type = type;
            this._category = category;
            this._partner = partner;
            this._region = region;
            this._saleAmount = saleAmount;
            this._saleDate = saleDate;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _type = string.Empty;
        public string Type
        {
            get { return this._type; }
            set { this.SetProperty(ref this._type, value); }
        }

        private string _category = string.Empty;
        public string Category
        {
            get { return this._category; }
            set { this.SetProperty(ref this._category, value); }
        }

        private string _partner = string.Empty;
        public string Partner
        {
            get { return this._partner; }
            set { this.SetProperty(ref this._partner, value); }
        }

        private Region _region = null;
        public Region Region
        {
            get { return this._region; }
            set { this.SetProperty(ref this._region, value); }
        }

        private DateTime _saleDate;
        public DateTime SaleDate
        {
            get { return this._saleDate; }
            set { this.SetProperty(ref this._saleDate, value); }
        }

        private double _saleAmount;
        public double SaleAmount
        {
            get { return this._saleAmount; }
            set { this.SetProperty(ref this._saleAmount, value); }
        }
    }

    public class Region
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
