using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;

namespace PdfViewerSamples
{
    public sealed partial class Printing : Page
    {
        /// <summary>
        /// PrintDocument is used to prepare the pages for printing. 
        /// Prepare the pages to print in the handlers for the Paginate, GetPreviewPage, and AddPages events.
        /// </summary>
        private PrintDocument printDocument = null;

        /// <summary>
        /// Marker interface for document source
        /// </summary>
        private IPrintDocumentSource printDocumentSource = null;

        /// <summary>
        /// A list of UIElements used to store the pdf pages.  This gives easy access
        /// to any desired page without having to call c1PdfViewer.GetPages multiple times
        /// </summary>
        internal List<FrameworkElement> pages = null;

        public Printing()
        {
            this.InitializeComponent();
            pages = new List<FrameworkElement>();
            this.Unloaded += Printing_Unloaded;
            this.Loaded += Printing_Loaded;
          
        }

        private void Printing_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly asm = typeof(PdfViewerDemoPage).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("PdfViewerSamples.Resources.PdfViewer.pdf");
            c1PdfViewer1.LoadDocument(stream);
            // init printing 
            RegisterForPrinting();
        }

        private void Printing_Unloaded(object sender, RoutedEventArgs e)
        {
            UnregisterForPrinting();
            c1PdfViewer1.CloseDocument();
        }

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync();
        }

        /// <summary>
        /// This is the event handler for PrintManager.PrintTaskRequested.
        /// </summary>
        /// <param name="sender">PrintManager</param>
        /// <param name="e">PrintTaskRequestedEventArgs </param>
        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
        {
            PrintTask printTask = null;
            printTask = e.Request.CreatePrintTask("SamplePDF", sourceRequested =>
            {
                // Print Task event handler is invoked when the print job is completed.
                printTask.Completed += async (s, args) =>
                {
                    // Notify the user when the print operation fails.
                    if (args.Completion == PrintTaskCompletion.Failed)
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            MessageDialog dialog = new MessageDialog(Strings.PrintException);
                            dialog.ShowAsync();
                        });
                    }
                };

                sourceRequested.SetSource(printDocumentSource);
            });

        }

        /// <summary>
        /// This method registers the app for printing with Windows and sets up the necessary event handlers for the print process.
        /// </summary>
        private void RegisterForPrinting()
        {
            // Create the PrintDocument.
            printDocument = new PrintDocument();

            // Save the DocumentSource.
            printDocumentSource = printDocument.DocumentSource;

            // Add an event handler which sets up print preview.
            printDocument.Paginate += Paginate;

            // Add an event handler which provides a specified preview page.
            printDocument.GetPreviewPage += GetPrintPreviewPage;

            // Add an event handler which provides all final print pages.
            printDocument.AddPages += AddPrintPages;

            // Create a PrintManager and add a handler for printing initialization.
            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested += PrintTaskRequested;
        }

        /// <summary>
        /// This method unregisters the app for printing with Windows.
        /// </summary>
        private void UnregisterForPrinting()
        {
            if (printDocument == null)
                return;

            printDocument.Paginate -= Paginate;
            printDocument.GetPreviewPage -= GetPrintPreviewPage;
            printDocument.AddPages -= AddPrintPages;

            // Remove the handler for printing initialization.
            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested -= PrintTaskRequested;

        }

        /// <summary>
        /// This is the event handler for PrintDocument.Paginate. 
        /// It fires when the PrintManager requests print preview
        /// </summary>
        /// <param name="sender">PrintDocument</param>
        /// <param name="e">Paginate Event Arguments</param>
        private void Paginate(object sender, PaginateEventArgs e)
        {
            option = e.PrintTaskOptions;
            PrintDocument printDoc = (PrintDocument)sender;

            // Report the number of preview pages
            printDoc.SetPreviewPageCount(c1PdfViewer1.PageCount, PreviewPageCountType.Intermediate);
        }

        private PrintTaskOptions option = null;
        /// <summary>
        /// This is the event handler for PrintDocument.GetPrintPreviewPage. It provides a specific print preview page,
        /// in the form of an UIElement, to an instance of PrintDocument. PrintDocument subsequently converts the UIElement
        /// into a page that the Windows print system can deal with.
        /// </summary>
        /// <param name="sender">PrintDocument</param>
        /// <param name="e">Arguments containing the preview requested page</param>
        private async void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            PrintDocument printDoc = (PrintDocument)sender;
            Size paperSize = option.GetPageDescription((uint)e.PageNumber).PageSize;
            double rate = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            paperSize = new Size(paperSize.Width / rate, paperSize.Height / rate);
            printDoc.SetPreviewPage(e.PageNumber, await c1PdfViewer1.GetPage(e.PageNumber, paperSize));
        }

        /// <summary>
        /// This is the event handler for PrintDocument.AddPages. It provides all pages to be printed, in the form of
        /// UIElements, to an instance of PrintDocument. PrintDocument subsequently converts the UIElements
        /// into a pages that the Windows print system can deal with.
        /// </summary>
        /// <param name="sender">PrintDocument</param>
        /// <param name="e">Add page event arguments containing a print task options reference</param>
        private async void AddPrintPages(object sender, AddPagesEventArgs e)
        {
            // Loop over all of the pages and add each one to be printed
                pages.Clear();
                foreach (FrameworkElement page in c1PdfViewer1.GetPages())
                {
                    pages.Add(page);
                }
            
            foreach (FrameworkElement page in pages)
            {
                printDocument.AddPage(page);
            }

            PrintDocument printDoc = (PrintDocument)sender;

            // Indicate that all of the print pages have been provided
            printDoc.AddPagesComplete();
        }

        private async void btnLoad_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".pdf");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                Stream stream = await file.OpenStreamForReadAsync();
                c1PdfViewer1.LoadDocument(stream);
            }

        }
    }
}
