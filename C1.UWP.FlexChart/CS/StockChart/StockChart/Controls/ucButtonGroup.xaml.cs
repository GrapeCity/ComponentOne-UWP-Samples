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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace StockChart
{
    public sealed partial class ucButtonGroup : UserControl
    {
        public ucButtonGroup()
        {
            this.InitializeComponent();
        }


        #region DependencyProperty
        public int SelectedIndex
        {
            get { return (int)this.GetValue(SelectedIndexProperty); }
            set { this.SetValue(SelectedIndexProperty, value); }
        }

        public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register(
            "SelectedIndex", typeof(int), typeof(ucButtonGroup), new PropertyMetadata(0
                , new PropertyChangedCallback((o, e) =>
                {
                    ucButtonGroup groups = o as ucButtonGroup;
                    if (groups != null)
                    {
                        groups.SelectIndex();
                    }
                })
                )

            );

        #endregion

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            int index = -1;
            foreach (var item in this.grid.Children)
            {
                index++;
                if (item == sender)
                {
                    this.SelectedIndex = index;
                }
            }
        }

        async void SelectIndex()
        {
            if (this.grid.Children.Count > SelectedIndex && SelectedIndex >= 0)
            {
                if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        var rb = (this.grid.Children[SelectedIndex] as RadioButton);
                        if (rb != null)
                        {
                            rb.IsChecked = true;
                        }
                    });
                }
                
            }
        }
    }
}
