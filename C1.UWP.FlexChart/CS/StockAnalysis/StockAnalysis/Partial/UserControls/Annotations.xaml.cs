using StockAnalysis.Command;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StockAnalysis.Partial.UserControls
{
    public sealed partial class Annotations : UserControl
    {
        public Annotations()
        {
            this.InitializeComponent();
            listbox.SelectedIndex = 0;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var src = e.AddedItems[0] as Data.ListDataItem;
                if (src != null)
                {
                    ViewModel.ViewModel.Instance.NewAnnotationType = (Data.NewAnnotationType)src.Tag;
                }

                CloseDropdownCommand closeCMD = new CloseDropdownCommand();
                closeCMD.Execute(this);
            }
        }
    }
}
