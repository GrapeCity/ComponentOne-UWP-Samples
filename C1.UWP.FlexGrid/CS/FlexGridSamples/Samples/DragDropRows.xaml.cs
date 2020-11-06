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

namespace FlexGridSamples
{
    public sealed partial class DragDropRows : Page
    {
        public DragDropRows()
        {
            this.InitializeComponent();
            Loaded += DragDropRows_Loaded;
            _flex.AllowDragging = C1.Xaml.FlexGrid.AllowDragging.Both;
            _flex.AllowSorting = false;
        }

        private async void DragDropRows_Loaded(object sender, RoutedEventArgs e)
        {
            var data = await NorthwindStorage.Load();
            _flex.ItemsSource = data;
        }
    }
}
