using C1.Xaml;
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

namespace BasicLibrarySamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClearStyleTabControl : Page
    {
        public ClearStyleTabControl()
        {
            this.InitializeComponent();
        }

        private void cmbTabStripPlacement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTabStripPlacement == null || c1TabControl1 == null) return;

            else if (cmbTabStripPlacement.SelectedIndex == 0)
            {
                c1TabControl1.TabStripPlacement = Dock.Left;
            }
            else if (cmbTabStripPlacement.SelectedIndex == 1)
            {
                c1TabControl1.TabStripPlacement = Dock.Right;

            }
            else if (cmbTabStripPlacement.SelectedIndex == 2)
            {
                c1TabControl1.TabStripPlacement = Dock.Top;
            }
            else if (cmbTabStripPlacement.SelectedIndex == 3)
            {
                c1TabControl1.TabStripPlacement = Dock.Bottom;
            }
        }

       

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
