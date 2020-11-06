using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PdfViewerSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PdfViewerDemoPage : Page
    {
        public PdfViewerDemoPage()
        {
            this.InitializeComponent();
            Loaded += PdfViewerDemoPage_Loaded;
            Unloaded += PdfViewerDemoPage_Unloaded;
        }

        private void PdfViewerDemoPage_Unloaded(object sender, RoutedEventArgs e)
        {
            pdfViewer.CloseDocument();
        }

        private void PdfViewerDemoPage_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly asm = typeof(PdfViewerDemoPage).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("PdfViewerSamples.Resources.GCDataSheet_2016.pdf");
            pdfViewer.LoadDocument(stream);
            cmbOrientation.SelectedIndex = 1;
        }

        private async void btnLoad_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".pdf");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                Stream stream = await file.OpenStreamForReadAsync();
                pdfViewer.LoadDocument(stream);
            }

        }

        private void cmbOrientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOrientation.SelectedIndex == 0)
            {
                pdfViewer.Orientation = Windows.UI.Xaml.Controls.Orientation.Horizontal;
            }
            else
            {
                pdfViewer.Orientation = Windows.UI.Xaml.Controls.Orientation.Vertical;
            }
        }

    }
}
