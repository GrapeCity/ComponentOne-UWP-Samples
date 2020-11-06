using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace MapsSamples
{
    public sealed partial class EarthQuake : Page
    {
        public EarthQuake()
        {
            this.InitializeComponent();

            this.Unloaded += EarthQuake_Unloaded;
            this.Loaded += EarthQuake_Loaded;
        }

        void EarthQuake_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.maps.Layers.Count == 0)
            {
                var layer = new C1VectorLayer()
                {
                    ItemStyle = (Style)this.Resources["style"],
                };
                Utils.LoadKMLFromResources(layer, "MapsSamples.Resources.2.5_day_depth.kml", true, null);
                this.maps.Layers.Add(layer);
            }
            else
            {
                var layer = maps.Layers[0] as C1VectorLayer;
                Utils.LoadKMLFromResources(layer, "MapsSamples.Resources.2.5_day_depth.kml", true, null);
            }
        }

        void EarthQuake_Unloaded(object sender, RoutedEventArgs e)
        {
            // Release memory
            var vl = maps.Layers[0] as C1VectorLayer;
            maps.Layers.Clear();
        }
    }
}
