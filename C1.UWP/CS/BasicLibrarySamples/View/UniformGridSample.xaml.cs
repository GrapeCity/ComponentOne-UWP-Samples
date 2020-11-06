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
using BasicLibrarySamples;

namespace BasicLibrarySamples
{
    public sealed partial class UniformGridSample : Page
    {
        public UniformGridSample()
        {
            this.InitializeComponent();

            panel.Children.Clear();
            for (int i = 0; i < 12; i++)
            {
                AddItem();
            }
        }

        string[] _colors = { "#FF008B9C", "#FF0094D6", "#FF497331", "#FF9DCFC3", "#FF005B84" };
        Random _rnd = new Random();
        private void AddItem()
        {
            panel.Children.Add(new ContentControl()
            {
                Content = (panel.Children.Count + 1).ToString(),
                Background = new SolidColorBrush(_rnd.PickOne<string>(_colors).ToColor()),
                Template = (ControlTemplate)Resources["PanelItemTemplate"]
            });
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }
    }
}
