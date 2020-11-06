using C1.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BasicLibrarySamples
{
    public sealed partial class HierarchicalDropDown : Page
    {
        public HierarchicalDropDown()
        {
            this.InitializeComponent();
        }

        private void C1TreeView_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                UpdateSelection();
                e.Handled = true;
            }
        }

        private void UpdateSelection()
        {
            if (treeSelection.SelectedItem != null)
            {
                selection.Text = treeSelection.SelectedItem.Header.ToString();
            }
            else
            {
                selection.Text = Strings.HierarchicalDropDown_TB_Header.ToString();
            }
            soccerCountries.IsDropDownOpen = false;
        }

        private void C1TreeView_ItemClicked(object sender, SourcedEventArgs e)
        {
            UpdateSelection();
        }

        private void ContentControl_MouseLeftButtonDown(object sender, EventArgs e)
        {
            soccerCountries.IsDropDownOpen = true;
        }

    }
}
