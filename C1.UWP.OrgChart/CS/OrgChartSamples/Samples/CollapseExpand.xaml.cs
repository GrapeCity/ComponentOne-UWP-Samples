using C1.Xaml.OrgChart;
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
    public sealed partial class CollapseExpand : Page
    {
        public CollapseExpand()
        {
            this.InitializeComponent();
            CreateData();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        // toggle OrgChart orientation when user clicks the checkbox on the main page
        void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            _orgChart.Orientation = ((CheckBox)sender).IsChecked.Value
                ? Orientation.Horizontal
                : Orientation.Vertical;
            _orgChart.IsCollapsed = false;
        }

        // rebuild the chart using new random data
        void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            CreateData();
            SetToggleButtonState(_orgChart, _orgChart.IsCollapsed);
        }

        // collapse the chart to level 2, if Phone to level 1 
        void Button_Collapse_Click(object sender, RoutedEventArgs e)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                ToggleCollapseExpand(_orgChart, 0, 1);
            }
            else
            {
                ToggleCollapseExpand(_orgChart, 0, 2);
            }
               
        }


        // collapse the chart to a given level
        void ToggleCollapseExpand(C1OrgChart node, int level, int maxLevel)
        {
            //ToggleButton button = null;
            if (level >= maxLevel)
            {
                node.IsCollapsed = true;
                // Get ToggleButton and set its IsCheced property to true.
                SetToggleButtonState(node, true);
            }
            else
            {
                node.IsCollapsed = false;
                SetToggleButtonState(node, false);
                foreach (var subNode in node.ChildNodes)
                {
                    ToggleCollapseExpand(subNode, level + 1, maxLevel);
                }
            }
        }

        // create some random data and assign it to the chart
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
                _tbTotal.Text = string.Format(Strings.TotalItem, p.TotalCount);
            }
            _orgChart.Header = p;
        }


        /// <summary>
        /// Get ToggleButton from orgChart and set its IsChecked property to isChecked;
        /// </summary>
        private void SetToggleButtonState(DependencyObject chart, bool isChecked)
        {
            ToggleButton button = null;
            int count = VisualTreeHelper.GetChildrenCount(chart);
            for (int index = 0; index < count; index++)
            {
                var child = VisualTreeHelper.GetChild(chart, index);
                if (child is ToggleButton)
                {
                    button = (ToggleButton)child;
                    button.IsChecked = isChecked;
                }
                else
                {
                    SetToggleButtonState(child, isChecked);
                }
            }
        }

        private void CheckedChanged(object sender)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            FrameworkElement parent = VisualTreeHelper.GetParent(toggleButton) as FrameworkElement;
            while (parent != null && !(parent is C1OrgChart))
            {
                parent = VisualTreeHelper.GetParent(parent) as FrameworkElement;
            }
            if (parent != null)
            {
                C1OrgChart orgChart = parent as C1OrgChart;
                if (toggleButton.IsChecked != null)
                {
                    orgChart.IsCollapsed = toggleButton.IsChecked.Value;
                }
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            CheckedChanged(sender);
        }

    }
}
