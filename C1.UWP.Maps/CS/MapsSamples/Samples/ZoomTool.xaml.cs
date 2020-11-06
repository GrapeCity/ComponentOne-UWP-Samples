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
    public sealed partial class ZoomTool : UserControl
    {
        public ZoomTool()
        {
            this.InitializeComponent();
            Loaded += ZoomTool_Loaded;            
        }

        private void ZoomTool_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Orientation == Windows.UI.Xaml.Controls.Orientation.Horizontal)
            {
                this.VerticalZoomTool.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                this.HorizontalZoomTool.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }

            this.HIncrementButton.Tapped += HIncrementButton_Tapped;
            this.VIncrementButton.Tapped += VIncrementButton_Tapped;
            this.HDecrementButton.Tapped += HDecrementButton_Tapped;
            this.VDecrementButton.Tapped += VDecrementButton_Tapped;
        }

        void VDecrementButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.VSlider.Value--;
        }

        void HDecrementButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.HSlider.Value--;
        }

        void VIncrementButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.VSlider.Value++;
        }

        void HIncrementButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.HSlider.Value++;
        }

        public Orientation Orientation
        {
            get;
            set;
        }

        public static readonly DependencyProperty MapsProperty =
            DependencyProperty.Register(
                "Maps", typeof(C1Maps), typeof(ZoomTool), new PropertyMetadata(null, OnMapsPropertyChanged));
        public C1Maps Maps
        {
            get
            {
                return (C1Maps)this.GetValue(MapsProperty);
            }
            set
            {
                this.SetValue(MapsProperty, value);
            }
        }

        private static void OnMapsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
                (d as ZoomTool).OnMapsChanged();
        }

        private void OnMapsChanged()
        {
            var binding = new Binding();
            binding.Path = new PropertyPath("TargetZoom");
            binding.Source = Maps;
            binding.Mode = BindingMode.TwoWay;

            if (this.Orientation == Windows.UI.Xaml.Controls.Orientation.Horizontal)
            {
                this.HSlider.SetBinding(Slider.ValueProperty, binding);
            }
            else
            {
                this.VSlider.SetBinding(Slider.ValueProperty, binding);
            }
        }
    }
}
