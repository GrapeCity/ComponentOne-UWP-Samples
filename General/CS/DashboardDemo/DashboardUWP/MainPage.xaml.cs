using DashboardModel;
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
using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DashboardUWP
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

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IsWindowsPhoneDevice())
                Menu.OpenPaneLength = Window.Current.Bounds.Width;
            DataService.GetService().InitializeDataService();
            Menu.SelectedIndex = 0;
            ContentFrame.Navigate(typeof(RangeSelectorPage), typeof(Dashboard));
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuImageItem item = e.ClickedItem as HamburgerMenuImageItem;
            switch (Menu.Items.IndexOf(item))
            {
                case 0:
                    ContentFrame.Navigate(typeof(RangeSelectorPage), typeof(Dashboard));
                    break;
                case 1:
                    ContentFrame.Navigate(typeof(RangeSelectorPage), typeof(Analysis));
                    break;
                case 2:
                    ContentFrame.Navigate(typeof(Reporting));
                    break;
                case 3:
                    ContentFrame.Navigate(typeof(RangeSelectorPage), typeof(Tasks));
                    break;
                case 4:
                    ContentFrame.Navigate(typeof(Products));
                    break;
            }
            if(IsWindowsPhoneDevice())
                Menu.IsPaneOpen =false;
        }

        internal static bool IsWindowsPhoneDevice()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                return true;
            }
            return false;
        }
    }
}
