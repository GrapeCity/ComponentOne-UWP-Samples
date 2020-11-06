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

namespace StockAnalysis.Partial.Layouts
{
    public sealed partial class Main : UserControl
    {
        public Main()
        {           
            this.InitializeComponent();
        }
        public ViewModel.ViewModel Model
        {
            get
            {
                return ViewModel.ViewModel.Instance;
            }
        }

        private void navList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = sender as CustomControls.NavList;           
            VisualStateManager.GoToState(sender as CustomControls.NavList, "textSwitcher", true);
        }
    }
}
