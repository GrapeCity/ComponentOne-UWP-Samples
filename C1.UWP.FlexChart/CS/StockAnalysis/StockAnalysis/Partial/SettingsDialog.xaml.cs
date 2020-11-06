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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StockAnalysis.Partial
{
    public sealed partial class SettingsDialog : ContentDialog
    {
        public string Key
        {
            get;
            private set;
        }
        public SettingsDialog()
        {
            this.InitializeComponent();
        }
        public SettingsDialog(string key)
        {
            this.Key = key;
            InitializeComponent();
        }   

        private IEnumerable<object> itemSource;
        public IEnumerable<object> ItemSource
        {
            get
            {
                if (itemSource == null)
                {
                    IEnumerable<Data.SettingParam> settings;
                    if (ViewModel.ViewModel.Instance.Settings.TryGetValue(Key, out settings))
                    {
                        itemSource = settings;
                    }
                }
                return itemSource;

            }
        }
        
        private void SettingList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = e.NewSize.Height + 140;
        }

        private void FlatButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
