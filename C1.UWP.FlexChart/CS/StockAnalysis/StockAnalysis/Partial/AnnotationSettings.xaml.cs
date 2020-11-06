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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StockAnalysis.Partial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AnnotationSettings : Page
    {
        public AnnotationSettings(string key)
        {
            this.Key = key;
            InitializeComponent();

        }

        public void ShowDialog(Page owner)
        {
            owner.Frame.Navigate(typeof(AnnotationSettings));
        }

        public string Key
        {
            get;
            private set;
        }
        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }

        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = e.NewSize.Height + 150;
        }
    }
}
