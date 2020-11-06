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
using Windows.UI.Xaml.Navigation;

namespace MapsSamples
{
    public sealed partial class DemoMaps : Page
    {
        public DemoMaps()
        {
            this.InitializeComponent();
            this.Unloaded += DemoMaps_Unloaded;
            this.Loaded += DemoMaps_Loaded;
            comboSources.ItemsSource = Enum.GetValues(typeof(Sources));
            comboSources.SelectedItem = Sources.VirtualEarthHybrid;
            
        }

        void DemoMaps_Loaded(object sender, RoutedEventArgs e)
        {
            this.maps.TargetCenter = new Point(-79.9247, 40.4587);
        }

        void DemoMaps_Unloaded(object sender, RoutedEventArgs e)
        {
            this.maps.Zoom = 1.1;
            this.maps.Center = new Point();
            comboSources.SelectedIndex = 0;
        }

        public enum Sources
        {
            VirtualEarthAerial,
            VirtualEarthRoad,
            VirtualEarthHybrid,
        };

        Dictionary<Sources, MultiScaleTileSource> sourcesMap = new Dictionary<Sources, MultiScaleTileSource> 
		{ 
			{Sources.VirtualEarthAerial, new VirtualEarthAerialSource() },
			{Sources.VirtualEarthRoad, new VirtualEarthRoadSource() },
			{Sources.VirtualEarthHybrid, new VirtualEarthHybridSource() },
		};

        Sources _source;
        public Sources Source
        {
            get { return _source; }
            set
            {
                _source = value;
                if (maps != null)
                {
                    maps.Source = sourcesMap[_source];
                }
            }
        }

        private void comboSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Source = (Sources)comboSources.SelectedItem;
        }

        private void item_Tapped(object sender, TappedRoutedEventArgs e)
        {
            C1MapItemsLayer layer = maps.Layers[0] as C1MapItemsLayer;
            FrameworkElement item = layer.Items[0] as FrameworkElement;
            FlyoutBase.GetAttachedFlyout(item).ShowAt(item);
        }
    }
}
