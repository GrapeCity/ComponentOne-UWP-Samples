using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Printing;
using Windows.Graphics.Printing;

namespace FlexChartPrint
{
    public delegate UIElement PagePrinting(int pageNumber);
    public delegate void PagePrinted(int pageNumber, UIElement visual);

    public class PrintHelper
    {
        private PrintManager printMan;
        private PrintDocument printDoc;
        private IPrintDocumentSource printDocSource;
        private int _pageCount;

        #region Public members

        public PagePrinting PagePrinting;
        public PagePrinted PagePrinted;

        public void Register()
        {
            printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested += PrintTaskRequested;

            if (printDoc == null)
            {
                printDoc = new PrintDocument();
                printDocSource = printDoc.DocumentSource;
                printDoc.Paginate += Paginate;
                printDoc.GetPreviewPage += GetPreviewPage;
                printDoc.AddPages += AddPages;
            }
        }

        public void Unregister()
        {
            printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested -= PrintTaskRequested;
        }

        public async void Print(int pageCount = 1)
        {
            _pageCount = pageCount;

            try
            {
                await PrintManager.ShowPrintUIAsync();
            }
            catch (Exception e)
            {
                ShowErrorMessage("Printing error", e.Message);
            }
        }

        #endregion

        #region Implementation

        async private void ShowErrorMessage(string title, string content, string btnText = "OK")
        {
            var dlg = new ContentDialog()
            {
                Title = title,
                Content = content,
                PrimaryButtonText = btnText
            };
            await dlg.ShowAsync();
        }

        private UIElement OnPrinting(int pageNumber)
        {
            return PagePrinting(pageNumber);
        }

        private void OnPrinted(int pageNumber, UIElement visual)
        {
            PagePrinted(pageNumber, visual);
        }

        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            var printTask = args.Request.CreatePrintTask("Print", PrintTaskSourceRequrested);
            printTask.Completed += PrintTaskCompleted;
        }

        private void PrintTaskSourceRequrested(PrintTaskSourceRequestedArgs args)
        {
            args.SetSource(printDocSource);
        }

        private async void PrintTaskCompleted(PrintTask sender, PrintTaskCompletedEventArgs args)
        {
            if (args.Completion == PrintTaskCompletion.Failed)
            {
                await Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    ShowErrorMessage("Printing error", "Printing failed");
                });
            }
        }

        private void Paginate(object sender, PaginateEventArgs e)
        {
            printDoc.SetPreviewPageCount(_pageCount, PreviewPageCountType.Final);
        }

        private void GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            var el = OnPrinting(e.PageNumber);
            printDoc.SetPreviewPage(e.PageNumber, el);
            OnPrinted(e.PageNumber, el);
        }

        private void AddPages(object sender, AddPagesEventArgs e)
        {
            for (var i = 1; i < _pageCount + 1; i++)
            {
                var el = OnPrinting(i);
                printDoc.AddPage(el);
                OnPrinted(i, el);
            }

            printDoc.AddPagesComplete();
        }

        #endregion
    }
}
