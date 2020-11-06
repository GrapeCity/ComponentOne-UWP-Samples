using C1.Xaml;
using ControlExplorer.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ControlExplorer
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SamplesPage : Page
    {
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public SamplesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter as NavigationParameter;
            if (parameter != null)
            {
                var feature = parameter.Feature;
                if (feature != null)
                {
                    this.DefaultViewModel["Feature"] = feature;
                }
                else
                {
                    var control = parameter.Control;
                    var features = control.Features;
                    this.DefaultViewModel["Control"] = control;
                    this.DefaultViewModel["Features"] = features;
                    feature = features.FirstOrDefault(c => c.IsExpanded || c.IsNew) ?? features.First();
                    if (feature.SubFeatures != null && feature.SubFeatures.Count() > 0)
                    {
                        this.DefaultViewModel["Feature"] = feature.SubFeatures.FirstOrDefault(c => c.IsNew) ?? feature.SubFeatures.First();
                    }
                    else
                    {
                        this.DefaultViewModel["Feature"] = feature;
                    }
                }
                this.DefaultViewModel["Navigation"] = parameter.Navigation;
                this.DefaultViewModel["Groups"] = MainViewModel.Instance.Groups;
            }
        }

        private void tree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0)
                return;
            var feature = (e.AddedItems[0] as C1TreeViewItem).DataContext as FeatureDescription;
            try
            {
                if (feature.SubFeatures.Count() == 0)
                {
                    DefaultViewModel["Feature"] = feature;
                }
                else
                {
                    feature.IsExpanded = !feature.IsExpanded;
                }
            }
            catch { }
        }

        private void tree_ItemPrepared(object sender, ItemPreparedEventArgs e)
        {
            var treeViewItem = e.Element as C1TreeViewItem;
            var item = e.Item as FeatureDescription;
            if (treeViewItem != null && item != null)
            {
                var selectedFeature = DefaultViewModel["Feature"] as FeatureDescription;
                if (selectedFeature != null)
                {
                    if (item == selectedFeature.OwnerFeature)
                        item.IsExpanded = true;
                    else if (item == selectedFeature)
                        treeViewItem.IsSelected = true;
                }
                treeViewItem.SetBinding(C1TreeViewItem.IsExpandedProperty, new Binding()
                {
                    Path = new PropertyPath("IsExpanded"),
                    Mode = BindingMode.TwoWay,
                    Source = item
                });
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as HyperlinkButton;
            if (button != null)
            {
                var control = button.DataContext as ControlDescription;
                if (control != null)
                {
                    var navigation = this.DefaultViewModel["Navigation"] as NavigationHelper;
                    navigation.Frame.Navigate(typeof(SamplesPage),
                        new NavigationParameter(control, navigation));
                }
            }
        }

        private void Root_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (DropDown != null)
            {
                DropDown.ShowAt(Root);
            }
        }

        private void Root_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (DropDown != null)
            {
                DropDown.ShowAt(Root);
            }
        }
    }
}
