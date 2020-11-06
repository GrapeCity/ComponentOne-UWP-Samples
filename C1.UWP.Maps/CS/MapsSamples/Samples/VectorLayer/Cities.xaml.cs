using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Reflection;

namespace MapsSamples
{
    public sealed partial class Cities : Page
    {

        C1VectorLayer vl;
        public Cities()
        {
            InitializeComponent();

            this.Loaded += Cities_Loaded;
            this.Unloaded += Cities_Unloaded;
        }

        void Cities_Unloaded(object sender, RoutedEventArgs e)
        {
            this.maps.Zoom = 2;
            this.maps.Center = new Point();

            //Release memory
            if (vl != null)
            {
                foreach (var child in vl.Children)
                {
                    var place = child as C1VectorPlacemark;
                    if (place != null)
                    {
                        place.Loaded -= C1VectorPlacemark_Loaded;
                    }
                }
            }

            vl = null;
            this.maps.Layers.Clear();
        }

        void Cities_Loaded(object sender, RoutedEventArgs e)
        {
            Color fc = Color.FromArgb(0xff, 0xC0, 0x50, 0x4d);
            //maps.Foreground = new SolidColorBrush(fc);

            vl = new C1VectorLayer();

            Stream stream = typeof(Cities).GetTypeInfo().Assembly.GetManifestResourceStream("MapsSamples.Resources.Cities100K.txt");
            if (stream != null)
            {
                List<City> cities = City.Read(stream);
                vl.ItemTemplate = (DataTemplate)Resources["templCity"];
                IEnumerable<City> source = from city in cities orderby city.Population descending select city;
                vl.ItemsSource = source.Take(500);
            }
            stream.Dispose();
            stream = null;

            maps.Layers.Add(vl);
        }

        private void C1VectorPlacemark_Loaded(object sender, RoutedEventArgs e)
        {
            C1VectorPlacemark pl = (C1VectorPlacemark)sender;
            City city = (City)pl.DataContext;
            ToolTipService.SetToolTip(pl, city.Name + ":\n" + city.Population.ToString());
        }
    }
}
