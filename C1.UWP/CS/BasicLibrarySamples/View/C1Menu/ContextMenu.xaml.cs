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
    public sealed partial class ContextMenu : Page
    {
        public ContextMenu()
        {
            this.InitializeComponent();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                _txt.Text = Strings.ContextMenuPhoneTB;
                _txt.FontSize = 10;
            }
        }

        private void contextMenu_ItemClick(object sender, C1.Xaml.SourcedEventArgs e)
        {
            txt.Text = Strings.ContextMenuItemClickTB + " " + ((C1.Xaml.C1MenuItem)e.Source).Header.ToString();

        }
    }
}
