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

namespace OrgChartSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TemplateSample : Page
    {
        public TemplateSample()
        {
            this.InitializeComponent();
            CreateData();
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            // create new data
            CreateData();
        }

        void CreateData()
        {
            Person p;
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                p = Person.CreatePerson(3);
            }
            else
            {
                p = Person.CreatePerson(5);
            }
            c1OrgChart1.Header = p;
        }

        private void comboOrientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (c1OrgChart1 == null) return;
            if (comboOrientation != null)
            {
                if (comboOrientation.SelectedIndex == 0)
                {
                    c1OrgChart1.Orientation = Orientation.Horizontal;
                }
                else
                {
                    c1OrgChart1.Orientation = Orientation.Vertical;
                }
            }
        }
    }
}
