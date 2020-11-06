using C1.Xaml;
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

namespace BasicLibrarySamples
{
    public sealed partial class DropDownDemo : Page
    {
        public DropDownDemo()
        {
            this.InitializeComponent();
        }

        private void colorListBox_ItemTapped(object sender, C1TappedEventArgs e)
        {
            C1ListBoxItem item = sender as C1ListBoxItem;
            if (item != null)
            {
                Border b = item.Content as Border;
                if (b != null)
                {
                    dropDownBorder.Background = b.Background;
                }
            }
            c1DropDown1.IsDropDownOpen = false;
        }

    }
}
