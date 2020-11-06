using System;
using System.Linq;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using FlexChart101.Data;
using System.Reflection;
using System.IO;
using C1.C1Zip;
using FlexChart101.Common;

namespace FlexChart101
{
    /// <summary>
    /// A page that displays a collection of items.
    /// </summary>
    public sealed partial class MainPage : Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
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
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleItems = SampleDataSource.GetItems((String)navigationParameter);
            try
            {
                Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
                using (Stream stream = asm.GetManifestResourceStream("FlexChart101.Resources.SamplesCodes.zip"))
                {
                    using (C1ZipFile zip = new C1ZipFile(stream))
                    {
                        bool isMobileDevice = LayoutAwarePage.IsWindowsPhoneDevice();
                        sampleItems.ToList<SampleDataItem>().ForEach(sampleItem =>
                        {
                            var ets = zip.Entries.Where(entry => entry.FileName.Equals(sampleItem.SourceCodes.XamlFileName)
                            || entry.FileName.Equals(sampleItem.SourceCodes.CodeFileName)
                            || (entry.FileName.Contains("DeviceFamily-Mobile/")) && entry.FileName.Contains(sampleItem.SourceCodes.XamlFileName));
                            ets.ToList<C1ZipEntry>().ForEach(entry =>
                            {
                                if (entry.FileName.Contains("xaml.cs"))
                                    sampleItem.SourceCodes.Code = GetContent(entry);
                                else if (ets.Count() == 2 || (isMobileDevice && entry.FileName.Contains("DeviceFamily-Mobile/") 
                                    || !isMobileDevice && !entry.FileName.Contains("DeviceFamily-Mobile/")))
                                    sampleItem.SourceCodes.Xaml = GetContent(entry);
                            });
                        });
                    }
                }
            }
            catch
            {

            }
            this.DefaultViewModel["AllItems"] = sampleItems;
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }

        string GetContent(C1ZipEntry entry)
        {
            using (Stream entryStream = entry.OpenReader())
            {
                using (StreamReader streamReader = new StreamReader(entryStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
