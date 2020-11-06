using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BasicLibrarySamples;

namespace BasicLibrarySamples
{
    public sealed partial class WrapPanelSample : Page
    {
        public WrapPanelSample()
        {
            this.InitializeComponent();
            this.comboOrientation.SelectedIndex = 0;
        }
        
        private void comboOrientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboOrientation.SelectedIndex == 0)
            {
                panel.Orientation = Orientation.Horizontal;
                scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
            else
            {
                panel.Orientation = Orientation.Vertical;
                scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }
    }
}
