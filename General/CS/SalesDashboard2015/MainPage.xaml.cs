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
using Windows.Graphics.Display;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SalesDashboard2015
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayProperties.OrientationChanged += DisplayProperties_OrientationChanged;
        }

        private void DisplayProperties_OrientationChanged(object sender)
        {
            if (!IsWindowsPhoneDevice())
            {
                OrientationChanged();
            }
        }

        private void OrientationChanged()
        {
            if (DisplayProperties.CurrentOrientation == DisplayOrientations.Portrait ||
                DisplayProperties.CurrentOrientation == DisplayOrientations.PortraitFlipped)
            {
                //FristFrame
                FristFrame.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                FristFrame.ColumnDefinitions.RemoveAt(0);
                Grid.SetRow(salesByType, 2);
                salesByType.Margin = new Thickness(0, 20, 0, 0);

                //LastFrame
                LastFrame.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                LastFrame.ColumnDefinitions.RemoveAt(0);
                Grid.SetRow(salesByCategory, 2);
                salesByCategory.Margin = new Thickness(0, 20, 0, 0);

            }
            else
            {
                //FristFrame
                FristFrame.ColumnDefinitions.Add(new ColumnDefinition());
                FristFrame.RowDefinitions.RemoveAt(0);
                Grid.SetRow(salesByType, 0);
                Grid.SetColumn(salesByType, 1);
                Grid.SetRowSpan(salesByType, 2);
                salesByType.Margin = new Thickness(20, 0, 0, 0);

                //LastFrame
                LastFrame.ColumnDefinitions.Add(new ColumnDefinition());
                LastFrame.RowDefinitions.RemoveAt(0);
                Grid.SetRow(salesByCategory, 0);
                Grid.SetColumn(salesByCategory, 1);
                Grid.SetRowSpan(salesByCategory, 2);
                salesByCategory.Margin = new Thickness(20, 0, 0, 0);
            }
        }

        private bool IsWindowsPhoneDevice()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                return true;
            }

            return false;
        }
    }
}
