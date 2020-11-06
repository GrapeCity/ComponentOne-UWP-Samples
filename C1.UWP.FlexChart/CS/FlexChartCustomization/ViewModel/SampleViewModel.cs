using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

namespace FlexChartCustomization
{
    public class SampleViewModel
    {
        List<DataItem> _data;
        List<DataItem> _cosData;

        public List<DataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<DataItem>();
                    _data.Add(new DataItem() { X = 1, Y = 50 });
                    _data.Add(new DataItem() { X = 2, Y = 30 });
                    _data.Add(new DataItem() { X = 3, Y = 40 });
                    _data.Add(new DataItem() { X = 4, Y = 60 });
                    _data.Add(new DataItem() { X = 5, Y = 90 });
                    _data.Add(new DataItem() { X = 6, Y = 80 });
                    _data.Add(new DataItem() { X = 7, Y = 56 });
                    _data.Add(new DataItem() { X = 8, Y = 56 });
                    _data.Add(new DataItem() { X = 9, Y = 50 });
                    _data.Add(new DataItem() { X = 10, Y = 70 });
                }

                return _data;
            }
        }

        public List<DataItem> CosData
        {
            get
            {
                if (_cosData == null)
                {
                    _cosData = new List<DataItem>();
                    for (int i = 0; i < 300; i++)
                    {
                        _cosData.Add(new DataItem { X = 0.16 * i, Y = Math.Cos(0.12 * i) });
                    }
                }

                return _cosData;
            }
        }

        static List<SmartPhoneVendor> vendors = null;

        private static BitmapImage loadImageSource(string resourceName)
        {

            //Uri uri = new Uri("ms-appx://FlexChartCustomizationLib2015/Assets/" + resourceName);
            Uri uri = new Uri("ms-appx:///FlexChartCustomizationLib/Assets/" + resourceName);
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = uri;
            return bitmap;
        }

        public static List<SmartPhoneVendor> SmartPhoneVendors
        {
            get
            {

                if (vendors == null)
                {
                    vendors = new List<SmartPhoneVendor>();

                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Apple",
                        Color = Color.FromArgb(255, 136, 189, 230),
                        Shipments = 215.2,
                        Country = "USA",
                        ImageSource = loadImageSource("apple.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Huawei",
                        Color = Color.FromArgb(255, 251, 178, 88),
                        Shipments = 139,
                        Country = "China",
                        ImageSource = loadImageSource("huawei.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Lenovo",
                        Color = Color.FromArgb(255, 144, 205, 151),
                        Shipments = 50.7,
                        Country = "China",
                        ImageSource = loadImageSource("lenovo.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "LG",
                        Color = Color.FromArgb(255, 246, 170, 201),
                        Shipments = 55.1,
                        Country = "Korea",
                        ImageSource = loadImageSource("lg.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Oppo",
                        Color = Color.FromArgb(255, 191, 165, 84),
                        Shipments = 92.5,
                        Country = "China",
                        ImageSource = loadImageSource("oppo.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Samsung",
                        Color = Color.FromArgb(255, 188, 153, 199),
                        Shipments = 310.3,
                        Country = "Korea",
                        ImageSource = loadImageSource("samsung.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Vivo",
                        Color = Color.FromArgb(255, 237, 221, 70),
                        Shipments = 71.7,
                        Country = "China",
                        ImageSource = loadImageSource("vivo.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "Xiaomi",
                        Color = Color.FromArgb(255, 240, 126, 110),
                        Shipments = 61,
                        Country = "China",
                        ImageSource = loadImageSource("xiaomi.png"),
                    });
                    vendors.Add(new SmartPhoneVendor()
                    {
                        Name = "ZTE",
                        Color = Color.FromArgb(255, 140, 140, 140),
                        Shipments = 61.9,
                        Country = "China",
                        ImageSource = loadImageSource("zte.png"),
                    });
                }
                return vendors;
            }
        }

        public static List<TemperatureRecord> USStatesTemperatureRecords
        {
            get
            {
                List<TemperatureRecord> records = new List<TemperatureRecord>();
                records.Add(new TemperatureRecord() { Place = "Alabama", High = 112 });
                records.Add(new TemperatureRecord() { Place = "Alaska", High = 100 });
                records.Add(new TemperatureRecord() { Place = "Arizona", High = 128 });
                records.Add(new TemperatureRecord() { Place = "Arkansas", High = 120 });
                records.Add(new TemperatureRecord() { Place = "California", High = 134 });
                records.Add(new TemperatureRecord() { Place = "Colorado", High = 114 });
                records.Add(new TemperatureRecord() { Place = "Connecticut", High = 106 });
                records.Add(new TemperatureRecord() { Place = "Delaware", High = 110 });
                records.Add(new TemperatureRecord() { Place = "District of Columbia", High = 106 });
                records.Add(new TemperatureRecord() { Place = "Florida", High = 109 });
                records.Add(new TemperatureRecord() { Place = "Georgia", High = 112 });
                records.Add(new TemperatureRecord() { Place = "Hawaii", High = 98 });
                records.Add(new TemperatureRecord() { Place = "Idaho", High = 118 });
                records.Add(new TemperatureRecord() { Place = "Illinois", High = 117 });
                records.Add(new TemperatureRecord() { Place = "Indiana", High = 116 });
                records.Add(new TemperatureRecord() { Place = "Iowa", High = 118 });
                records.Add(new TemperatureRecord() { Place = "Kansas", High = 121 });
                records.Add(new TemperatureRecord() { Place = "Kentucky", High = 114 });
                records.Add(new TemperatureRecord() { Place = "Louisiana", High = 114 });
                records.Add(new TemperatureRecord() { Place = "Maine", High = 105 });
                records.Add(new TemperatureRecord() { Place = "Maryland", High = 109 });
                records.Add(new TemperatureRecord() { Place = "Massachusetts", High = 107 });
                records.Add(new TemperatureRecord() { Place = "Michigan", High = 112 });
                records.Add(new TemperatureRecord() { Place = "Minnesota", High = 115 });
                records.Add(new TemperatureRecord() { Place = "Mississippi", High = 115 });
                records.Add(new TemperatureRecord() { Place = "Missouri", High = 118 });
                records.Add(new TemperatureRecord() { Place = "Montana", High = 117 });
                records.Add(new TemperatureRecord() { Place = "Nebraska", High = 118 });
                records.Add(new TemperatureRecord() { Place = "Nevada", High = 125 });
                records.Add(new TemperatureRecord() { Place = "New Hampshire", High = 106 });
                records.Add(new TemperatureRecord() { Place = "New Jersey", High = 110 });
                records.Add(new TemperatureRecord() { Place = "New Mexico", High = 122 });
                records.Add(new TemperatureRecord() { Place = "New York", High = 109 });
                records.Add(new TemperatureRecord() { Place = "North Carolina", High = 110 });
                records.Add(new TemperatureRecord() { Place = "North Dakota", High = 121 });
                records.Add(new TemperatureRecord() { Place = "Ohio", High = 113 });
                records.Add(new TemperatureRecord() { Place = "Oklahoma", High = 120 });
                records.Add(new TemperatureRecord() { Place = "Oregon", High = 117 });
                records.Add(new TemperatureRecord() { Place = "Pennsylvania", High = 111 });
                records.Add(new TemperatureRecord() { Place = "Rhode Island", High = 104 });
                records.Add(new TemperatureRecord() { Place = "South Carolina", High = 113 });
                records.Add(new TemperatureRecord() { Place = "South Dakota", High = 120 });
                records.Add(new TemperatureRecord() { Place = "Tennessee", High = 113 });
                records.Add(new TemperatureRecord() { Place = "Texas", High = 120 });
                records.Add(new TemperatureRecord() { Place = "Utah", High = 117 });
                records.Add(new TemperatureRecord() { Place = "Vermont", High = 105 });
                records.Add(new TemperatureRecord() { Place = "Virginia", High = 110 });
                records.Add(new TemperatureRecord() { Place = "Washington", High = 118 });
                records.Add(new TemperatureRecord() { Place = "West Virginia", High = 112 });
                records.Add(new TemperatureRecord() { Place = "Wisconsin", High = 114 });
                records.Add(new TemperatureRecord() { Place = "Wyoming", High = 115 });
                return records;
            }
        }
    }
}
