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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace OfflineMaps
{
    public sealed partial class MapTool : UserControl
    {
        public MapTool()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public static readonly DependencyProperty MapsProperty =
            DependencyProperty.Register(
                "Maps", typeof(C1Maps), typeof(MapTool), null);
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
    }
}
