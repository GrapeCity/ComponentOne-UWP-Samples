using C1.BarCode;
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

namespace BarCodeSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoBarCode : Page
    {
        List<Category> Categories = new List<Category>();
        public DemoBarCode()
        {
            this.InitializeComponent();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                this.Loaded += Generator_Loaded;
            }
        }

        void Generator_Loaded(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Editor), Format.Text);
        }

        private void categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView.SelectedItem != null)
            {
                var selectedItem = (Category)gridView.SelectedItem;
                var format = selectedItem.Format;
                var frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(Editor), format);
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as AppBarButton;
            if (button != null)
            {
                var tag = button.Tag as string;
                var format = (Format)Enum.Parse(typeof(Format), tag);
                frame.Navigate(typeof(Editor), format);
            }
        }
    }
}
