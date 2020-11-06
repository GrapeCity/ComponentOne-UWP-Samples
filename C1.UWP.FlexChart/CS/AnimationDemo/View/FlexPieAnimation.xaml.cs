using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

using C1.Chart;
using C1.Xaml.Chart;

using AnimationDemo.Data;

namespace AnimationDemo.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlexPieAnimation : Page
    {
        public FlexPieAnimation()
        {
            this.InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            chart.BeginUpdate();

            var data = chart.ItemsSource as ObservableCollection<DataItem>;
            if (data != null)
            {
                var npts = data.Count;

                for (var i = 0; i < npts; i++)
                    data[i].Value = rnd.Next(1, 10);
            }

            chart.EndUpdate();
        }

        Random rnd = new Random();

        void NewData(int npts = 6)
        {
            var data = new ObservableCollection<DataItem>();

            for (var i = 0; i < npts; i++)
                data.Add(new DataItem { Value = rnd.Next(1, 10), Name = "Item " + i.ToString() });

            chart.BeginUpdate();
            chart.Binding = "Value";
            chart.BindingName = "Name";

            chart.ItemsSource = data;
            chart.EndUpdate();
        }

        private void chart_Loaded(object sender, RoutedEventArgs e)
        {
            chart.DataLabel.Content = "{Value}";

            cbAnimation.ItemsSource = new AnimationSettings[]
                    { AnimationSettings.None, AnimationSettings.Load, AnimationSettings.Update, AnimationSettings.All };
            cbAnimation.SelectedValue = AnimationSettings.All;

            NewData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var data = chart.ItemsSource as ObservableCollection<DataItem>;
            if (data != null)
                data.Add(new DataItem { Value = rnd.Next(1, 10), Name = "Item " + data.Count.ToString() });
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var data = chart.ItemsSource as ObservableCollection<DataItem>;
            if (data != null && data.Count > 0)
                data.RemoveAt(data.Count - 1);
        }

        private void cbLabels_Checked(object sender, RoutedEventArgs e)
        {
            chart.DataLabel.Position = cbLabels.IsChecked == true ? PieLabelPosition.Center : PieLabelPosition.None;
        }

        private void cbAnimation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pnlLoad.Visibility = (chart.AnimationSettings & AnimationSettings.Load) != 0 ? Visibility.Visible : Visibility.Collapsed;
            pnlUpdate.Visibility = (chart.AnimationSettings & AnimationSettings.Update) != 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public List<AnimationType> Types
        {
            get
            {
                return new List<AnimationType>() { AnimationType.All, AnimationType.Points };
            }
        }

        public List<AnimationSettings> Settings
        {
            get
            {
                return new List<AnimationSettings>() { AnimationSettings.None, AnimationSettings.Load, AnimationSettings.Update, AnimationSettings.All };
            }
        }

        public List<SliceAttribute> Attributes
        {
            get
            {
                return new List<SliceAttribute>() { SliceAttribute.Radius, SliceAttribute.Angle, SliceAttribute.Sweep };
            }
        }

        List<Easing> easings;

        public List<Easing> Easings
        {
            get
            {
                if (easings == null)
                {
                    var ar = Enum.GetValues(typeof(Easing));
                    easings = new List<Easing>();
                    foreach (var o in ar)
                        easings.Add((Easing)o);
                }
                return easings;
            }
        }
    }
}
