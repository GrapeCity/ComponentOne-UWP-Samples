using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

using FlexReportSamples.Data;

namespace FlexReportSamples
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetailPage : FlexReportSamples.Common.LayoutAwarePage
    {
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
            if (this.flipView.SelectedItem != null)
            {
                // keep frame content in sync with the selected item
                bool result = frame.Navigate(((SampleDataItem)this.flipView.SelectedItem).PageType);
            }
        }
    }
}
