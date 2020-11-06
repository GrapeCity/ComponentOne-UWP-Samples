using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using FlexChart101.Data;
using Windows.UI.Xaml;
using System.Reflection;
using Windows.UI.Xaml.Markup;
using System.IO;
using C1.C1Zip;

namespace FlexChart101
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetailPage : Common.LayoutAwarePage
    {
        Dictionary<SampleDataItem, double> storedHeights = new Dictionary<SampleDataItem, double>();

        public ItemDetailPage()
        {
            this.InitializeComponent();
            this.flipView.ItemsSource = SampleDataSource.GetItems("AllItems");
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Allow saved page state to override the initial item to display
            if (pageState != null && pageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = pageState["SelectedItem"];
            }
            var item = SampleDataSource.GetItem((String)navigationParameter);
            this.flipView.SelectedItem = item;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            var selectedItem = (SampleDataItem)this.flipView.SelectedItem;
            pageState["SelectedItem"] = selectedItem.UniqueId;
        }

        void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = this.flipView.SelectedItem as SampleDataItem;
            if (selectedItem != null)
            {
                if (storedHeights.ContainsKey(selectedItem))
                {
                    row1.Height = new GridLength(storedHeights[selectedItem]);
                }
                else
                {
                    AdjustRowHeight(selectedItem);
                }
                bool result = frame.Navigate((selectedItem).PageType);
            }
        }

        private void FlipView_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            var selectedItem = this.flipView.SelectedItem as SampleDataItem;
            if (selectedItem != null)
            {
                AdjustRowHeight(selectedItem);
            }
        }

        void AdjustRowHeight(SampleDataItem selectedItem)
        {
            var container = this.flipView.ContainerFromIndex(this.flipView.SelectedIndex) as FlipViewItem;
            if (container != null)
            {
                var panel = container.ContentTemplateRoot as StackPanel;
                if (panel != null)
                {
                    var desiredHeight = panel.DesiredSize.Height;
                    row1.Height = new GridLength(desiredHeight);
                    storedHeights[selectedItem] = desiredHeight;
                }
            }
            else
            {
                var dataTemplate = flipView.ItemTemplate;
                var panel = dataTemplate.LoadContent() as StackPanel;
                if (panel != null)
                {
                    panel.DataContext = selectedItem;
                    panel.Measure(new Windows.Foundation.Size(this.ActualWidth, double.PositiveInfinity));
                    row1.Height = new GridLength(panel.DesiredSize.Height);
                    storedHeights[selectedItem] = panel.DesiredSize.Height;
                }
            }
        }
    }
}
