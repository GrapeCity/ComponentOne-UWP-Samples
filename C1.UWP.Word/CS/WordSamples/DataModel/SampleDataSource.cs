﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WordSamples;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace WordSamples.Data
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> that defines common properties.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : WordSamples.Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String uniqueId, String title, String description, String imagePath, String name)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._description = description;
            this._imagePath = imagePath;
            this.Name = name;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        public string Name { get; set; }

        public DataTemplate Icon
        {
            get
            {
                try
                {
                    return (DataTemplate)App.Current.Resources["IconC1" + UniqueId.Replace(" ", "")];
                }
                catch
                {
                    return (DataTemplate)App.Current.Resources["IconC1Gray"];
                }
            }
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(SampleDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }


        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        public SampleDataItem(String uniqueId, String title, String description, String imagePath, Type pageType, String name)
            : base(uniqueId, title, description, imagePath, name)
        {
            _pageType = pageType;
        }

        private Type _pageType;
        public Type PageType
        {
            get { return this._pageType; }
            set { this.SetProperty(ref this._pageType, value); }
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();

        private ObservableCollection<SampleDataItem> _allItems = new ObservableCollection<SampleDataItem>();
        public ObservableCollection<SampleDataItem> AllItems
        {
            get { return this._allItems; }
        }

        public static IEnumerable<SampleDataItem> GetItems(string uniqueId)
        {
            if (!uniqueId.Equals("AllItems")) throw new ArgumentException(Strings.UniqueIdItemsArgumentException);

            return _sampleDataSource.AllItems;
        }

        public static SampleDataItem GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.AllItems.Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public SampleDataSource()
        {
            _allItems.Add(new SampleDataItem("Basic Text",
                 Strings.WordSamplesBasicTextTitle,
                 Strings.WordSamplesBasicTextDescription,
                 "Assets/BasicText.png",
                 typeof(WordSamples.BasicTextPage),
                 Strings.WordSamplesBasicTextName));
            _allItems.Add(new SampleDataItem("Images",
                  Strings.WordSamplesImagesTitle,
                  Strings.WordSamplesImagesDescription,
                  "Assets/MediumGray.png",
                  typeof(WordSamples.ImagesPage),
                  Strings.WordSamplesImagesName));
            _allItems.Add(new SampleDataItem("Graphics",
                   Strings.WordSamplesGraphicsTitle,
                   Strings.WordSamplesGraphicsDescription,
                   "Assets/Graphics.png",
                   typeof(WordSamples.GraphicsPage),
                   Strings.WordSamplesGraphicsName));
            _allItems.Add(new SampleDataItem("Quotes",
                   Strings.WordSamplesQuotesTitle,
                   Strings.WordSamplesQuotesDescription,
                   "Assets/Quotes.png",
                   typeof(WordSamples.QuotesPage),
                   Strings.WordSamplesQuotesName));
            _allItems.Add(new SampleDataItem("Table of Contents",
                   Strings.WordSamplesTableOfContentsTitle,
                   Strings.WordSamplesTableOfContentsDescription,
                   "Assets/TOC.png",
                   typeof(WordSamples.TOCPage),
                   Strings.WordSamplesTableOfContentsName));
            _allItems.Add(new SampleDataItem("Text Flow",
                   Strings.WordSamplesTextFlowTitle,
                   Strings.WordSamplesTextFlowDescription,
                   "Assets/TextFlow.png",
                   typeof(WordSamples.TextFlowPage),
                   Strings.WordSamplesTextFlowName));
            _allItems.Add(new SampleDataItem("Paper Sizes",
                   Strings.WordSamplesPaperSizesTitle,
                   Strings.WordSamplesPaperSizesDescription,
                   "Assets/PaperSizes.png",
                   typeof(WordSamples.PaperSizesPage),
                   Strings.WordSamplesPaperSizesName));
            _allItems.Add(new SampleDataItem("Export UI",
                  Strings.WordSamplesExportUITitle,
                  Strings.WordSamplesExportUIDescription,
                  "Assets/MediumGray.png",
                  typeof(WordSamples.RenderUIPage),
                  Strings.WordSamplesExportUIName));
            _allItems.Add(new SampleDataItem("Export RichTextBox",
                  Strings.WordSamplesExportRichTextTitle,
                  Strings.WordSamplesExportRichTextDescription,
                  "Assets/BasicText.png",
                  typeof(WordSamples.ExportRichText),
                  Strings.WordSamplesExportRichTextName));

        }
    }
}
