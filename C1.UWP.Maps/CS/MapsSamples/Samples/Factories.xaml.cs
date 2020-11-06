using System;
using System.IO;
using Windows.UI.Xaml;
using System.Reflection;
using Windows.Foundation;
using System.Xml.Serialization;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using C1.Xaml.Maps;

namespace MapsSamples
{
    public sealed partial class Factories : Page
    {
        const double minStoreZoom = 10.5;
        DataBase dataBase;

        public Factories()
        {
            this.InitializeComponent();
            LoadDataBase();
            InitializeMapLayers();
        }

        void LoadDataBase()
        {
            using (Stream stream = typeof(Factories).GetTypeInfo().Assembly
              .GetManifestResourceStream("MapsSamples.Resources.database.xml"))
            {
                if (stream != null)
                {
                    var serializer = new XmlSerializer(typeof(DataBase));
                    dataBase = (DataBase)serializer.Deserialize(stream);
                }
                else
                {
                    dataBase = new DataBase();
                }
            }
        }

        void InitializeMapLayers()
        {
            maps.Layers.Add(new C1MapItemsLayer
                {
                    ItemsSource = dataBase.Factories,
                    ItemTemplate = (DataTemplate)Resources["factoryTemplate"]
                });

            maps.Layers.Add(new C1MapItemsLayer
                {
                    ItemsSource = dataBase.Offices,
                    ItemTemplate = (DataTemplate)Resources["officeTemplate"]
                });

            int storeSlices = (int)Math.Pow(2, minStoreZoom);
            maps.Layers.Add(new C1MapVirtualLayer
                {
                    Slices =
                    {
                        new MapSlice(1, 1, 0),
                        new MapSlice(storeSlices, storeSlices, minStoreZoom)
                    },
                    MapItemsSource = new LocalStroeSource(dataBase),
                    ItemTemplate = (DataTemplate)Resources["storeTemplate"]
                });
        }

        public class LocalStroeSource : IMapVirtualSource
        {
            DataBase _dataBase;

            public LocalStroeSource(DataBase localDataBase)
            {
                _dataBase = localDataBase;
            }


            public void Request(double minZoom, double maxZoom, Point lowerLeft, Point upperRight, Action<System.Collections.ICollection> callback)
            {
                if (minZoom < minStoreZoom)
                {
                    return;
                }

                var stores = new List<Store>();

                foreach (var store in _dataBase.Stores)
                {
                    if (store.Latitude > lowerLeft.Y
                        && store.Longitude > lowerLeft.X
                        && store.Latitude <= upperRight.Y
                        && store.Longitude <= upperRight.X)
                    {
                        stores.Add(store);
                    }
                }

                callback(stores);
            }
        }
    }

    public class Entity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Point Position { get { return new Point(Longitude, Latitude); } }
    }

    public class Office : Entity
    {
        public string Manager { get; set; }
        public int Stores { get; set; }
    }

    public class Factory : Entity
    {
        public double Capacity { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
    }
    public class ProductSale
    {
        public Product Product { get; set; }
        public int Sales { get; set; }
    }
    public class Store : Entity
    {
        public List<ProductSale> Sales { get; set; }
    }

    public class DataBase
    {
        public List<Factory> Factories { get; set; }
        public List<Office> Offices { get; set; }
        public List<Store> Stores { get; set; }
        public double OfficeStoreDistance { get; set; }

        public DataBase()
        {
            Factories = new List<Factory>();
            Offices = new List<Office>();
            Stores = new List<Store>();
            OfficeStoreDistance = 100000;
        }

    }
}
