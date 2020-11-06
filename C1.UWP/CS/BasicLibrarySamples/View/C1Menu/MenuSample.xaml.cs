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
    public sealed partial class MenuSample : Page
    {
        public MenuSample()
        {
            this.InitializeComponent();
        }

		public event EventHandler SelectedItemChanged;
		 
		private void C1MenuItem_Click(object sender, object e)
		{
			C1MenuItem menu = sender as C1MenuItem;
			if (SelectedItemChanged != null)
			{
				SelectedItemChanged(this, new EventArgs());
			}

		}

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //if ((bool)chkVertical.IsChecked)
            //{
            //    VisualStudioMenu.Orientation = Orientation.Vertical;
            //    C1DockPanel.SetDock(VisualStudioMenu, Dock.Left);
            //}
            //else
            //{
            //    VisualStudioMenu.Orientation = Orientation.Horizontal;
            //    C1DockPanel.SetDock(VisualStudioMenu, Dock.Top);
            //}
        }
    }
}
