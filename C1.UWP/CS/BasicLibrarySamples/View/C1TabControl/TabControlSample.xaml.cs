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
    public sealed partial class TabControlSample : Page
    {
        public TabControlSample()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void cmbTabItemClose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTabItemClose == null || tabControl == null) return;
            if (cmbTabItemClose.SelectedIndex == 0)
                tabControl.TabItemClose = C1TabItemCloseOptions.None;
            else if (cmbTabItemClose.SelectedIndex == 1)
                tabControl.TabItemClose = C1TabItemCloseOptions.InEachTab;
            else
                tabControl.TabItemClose = C1TabItemCloseOptions.GlobalClose;
        }


        private void UpdatePlacementCombo(C1TabItemShape shape)
        {

        }


    }
}
