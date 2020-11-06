using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Graphics.Printing;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Printing;
using C1.Xaml.RichTextBox;
using Windows.Storage.Pickers;
using Windows.Storage;
using C1.Xaml.Pdf;
using C1.Xaml.RichTextBox.PdfFilter;

namespace RichTextBoxSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
        /// A list of UIElements used to store the rtb pages. 
        /// </summary>
        internal List<UIElement> pages = null;

        public Printing()
        {
            this.InitializeComponent();

            Assembly asm = typeof(Printing).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("RichTextBoxSamples.Resources.dickens.htm");
            var html = new StreamReader(stream).ReadToEnd();
            rtb.Html = html;

            pages = new List<UIElement>();
            this.Loaded += Printing_Loaded;
            this.Unloaded += Printing_Unloaded;
            cmbViewMode.SelectedIndex = 1;
        }

        #region event handlers
        void Printing_Unloaded(object sender, RoutedEventArgs e)
        {
            UnregisterForPrinting();
        }

        void Printing_Loaded(object sender, RoutedEventArgs e)
        {
            // init printing 
            RegisterForPrinting();
        }

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add(Strings.PdfFile , new List<string>() { ".pdf" });
            savePicker.DefaultFileExtension = ".pdf";
            StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                var pdf = new C1PdfDocument(PaperKind.Custom);
                pdf.ConformanceLevel = PdfAConformanceLevel.PdfA2b;
                var layout = rtb.ViewManager.PresenterInfo as C1PageLayout;
                PdfFilter.PrintDocument(rtb.Document, pdf, layout.Padding);
                await pdf.SaveAsync(file);
                MessageDialog dlg = new MessageDialog(Strings.SaveMessage + file.Path, Strings.RtbSample);
                await dlg.ShowAsync();
            }
        }

        private void cmbViewMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbViewMode.SelectedIndex == 0)
            {
                rtb.ViewMode = TextViewMode.Draft;
            }
            else
            {
                rtb.ViewMode = TextViewMode.Print;
            }
        }

        #endregion

        #region implemention
        /// <summary>
        /// This is the event handler for PrintManager.PrintTaskRequested.
        /// </summary>
        /// <param name="sender">PrintManager</param>
        /// <param name="e">PrintTaskRequestedEventArgs </param>
        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
        {
            PrintTask printTask = null;
            printTask = e.Request.CreatePrintTask("Printing C1RichTextBox", sourceRequested =>
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

                // set print options like paper size and orientation
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    var layout = rtb.ViewManager.PresenterInfo as C1PageLayout;
                    if(layout != null && layout.Width > layout.Height)
                    {
                        printTask.Options.Orientation = PrintOrientation.Landscape;
                    }
                });

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
            if(pages.Count > 0)
                pages.Clear();
            var mgr = new C1RichTextViewManager { Document = rtb.Document };
            var layout = rtb.ViewManager.PresenterInfo as C1PageLayout;
            var contentSize = new Size(layout.Width - layout.Padding.Left - layout.Padding.Right, layout.Height - layout.Padding.Top - layout.Padding.Bottom);

            // print the pages outside the visual tree
            var elements = mgr.OfflinePaint(contentSize).ToList();
            foreach (var el in elements)
            {
                var page = (Grid)printTemplate.LoadContent();
                var canvas = el as Canvas;
                if(canvas != null)
                    canvas.Margin = layout.Padding;
                page.Children.Clear();
                page.Children.Add(canvas);
                pages.Add(page);
            }
            PrintDocument printDoc = (PrintDocument)sender;
            // Report the number of preview pages
            printDoc.SetPreviewPageCount(pages.Count, PreviewPageCountType.Intermediate);
        }

        /// <summary>
        /// This is the event handler for PrintDocument.GetPrintPreviewPage. It provides a specific print preview page,
        /// in the form of an UIElement, to an instance of PrintDocument. PrintDocument subsequently converts the UIElement
        /// into a page that the Windows print system can deal with.
        /// </summary>
        /// <param name="sender">PrintDocument</param>
        /// <param name="e">Arguments containing the preview requested page</param>
        private void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            PrintDocument printDoc = (PrintDocument)sender;
            printDoc.SetPreviewPage(e.PageNumber, pages[e.PageNumber - 1]);
        }

        /// <summary>
        /// This is the event handler for PrintDocument.AddPages. It provides all pages to be printed, in the form of
        /// UIElements, to an instance of PrintDocument. PrintDocument subsequently converts the UIElements
        /// into a pages that the Windows print system can deal with.
        /// </summary>
        /// <param name="sender">PrintDocument</param>
        /// <param name="e">Add page event arguments containing a print task options reference</param>
        private void AddPrintPages(object sender, AddPagesEventArgs e)
        {
            // Loop over all of the pages and add each one to be printed
            foreach (FrameworkElement page in pages)
            {
                printDocument.AddPage(page);
            }
            PrintDocument printDoc = (PrintDocument)sender;
            // Indicate that all of the print pages have been provided
            printDoc.AddPagesComplete();
        }
        #endregion
    }
}
