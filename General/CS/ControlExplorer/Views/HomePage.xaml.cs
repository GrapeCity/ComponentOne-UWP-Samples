using C1.Xaml;
using ControlExplorer.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Phone.UI.Input;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace ControlExplorer
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        NavigationHelper navigationHelper = null;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
        }

        public HomePage()
        {
            this.InitializeComponent();
            navigationHelper = new NavigationHelper(frame);
        }

        public Frame AppFrame
        {
            get
            {
                return frame;
            }
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = new List<ControlDescription>();
                var groups = this.DefaultViewModel["Groups"] as List<GroupDescription>;
                if (groups != null)
                {
                    foreach (var group in groups)
                    {
                        foreach (var c in group.Controls)
                        {
                            if (c.Contains(sender.Text))
                            {
                                suggestions.Add(c);
                            }
                        }
                    }

                    if (suggestions.Count > 0)
                    {
                        controlsSearchBox.ItemsSource = suggestions.OrderByDescending(c => c.Name.StartsWith(sender.Text, StringComparison.CurrentCultureIgnoreCase)).ThenBy(c => c.Name);
                    }
                }
            }
        }

        private void controlsSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null && args.ChosenSuggestion is ControlDescription)
            {
                var control = args.ChosenSuggestion as ControlDescription;
                frame.Navigate(typeof(SamplesPage),
                    new NavigationParameter(control, navigationHelper));
            }
            controlsSearchBox.Text = string.Empty;
        }

        private void splitViewToggle_Click(object sender, RoutedEventArgs e)
        {
            splitter.IsPaneOpen = !splitter.IsPaneOpen;
        }

        private void tree_ItemClick(object sender, SourcedEventArgs e)
        {
            var treeViewItem = e.Source as C1TreeViewItem;
            if (treeViewItem != null)
            {
                var item = treeViewItem.Header as FeatureDescription;
                if (item != null)
                {
                    if (item.SubFeatures != null && item.SubFeatures.Count() > 0)
                        return;

                    splitter.IsPaneOpen = false;
                    frame.Navigate(typeof(SamplesPage),
                        new NavigationParameter(item, navigationHelper));
                }
            }
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            while (navigationHelper.CanGoBack)
            {
                navigationHelper.GoBack();
            }
            this.splitter.IsPaneOpen = false;
        }
    }
}
