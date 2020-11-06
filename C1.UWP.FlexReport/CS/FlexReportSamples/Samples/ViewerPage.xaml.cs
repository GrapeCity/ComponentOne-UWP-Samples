using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Windows.Storage;
using Windows.UI.Popups;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using C1.Xaml.FlexReport;
using C1.Xaml.Document;

namespace FlexReportSamples
{
    public sealed partial class ViewerPage : Page
    {
        C1FlexReport _report;
        C1PdfDocumentSource _pdfDocSource;
        Assembly _asm;

        string[] _pdfs = new string[]
        {
            "C1XapOptimizer.pdf",
            "ComparisonOfFormats.pdf",
            "TEST_ECG.pdf",
            "Simple Charts.pdf"
        };

        public ViewerPage()
        {
            this.InitializeComponent();
            this.Unloaded += ViewerPage_Unloaded;
            this.Loaded += ViewerPage_Loaded;

            _report = new C1FlexReport();
        }

        void ViewerPage_Unloaded(object sender, RoutedEventArgs e)
        {
            cbReport.SelectionChanged -= CbReport_SelectionChanged;

            flexViewer.DocumentSource = null;
            if (_pdfDocSource != null)
            {
                _pdfDocSource.Dispose();
                _pdfDocSource = null;
            }
            _report.Dispose();
            _report = null;
        }

        async void ViewerPage_Loaded(object sender, RoutedEventArgs e)
        {
            _asm = typeof(ViewerPage).GetTypeInfo().Assembly;
            await ExportPage.CopyC1NWind();

            string[] reports = null;

            // get list of reports from resource using stream
            using (Stream stream = _asm.GetManifestResourceStream("FlexReportSamples.Resources.FlexCommonTasks_UWP.flxr"))
                reports = C1FlexReport.GetReportList(stream);

            cbReport.Items.Clear();
            cbReport.SelectionChanged += CbReport_SelectionChanged;

            if (reports != null && reports.Length > 0)
            {
                foreach (string s in reports)
                    cbReport.Items.Add(s);
            }

            foreach (string s in _pdfs)
                cbReport.Items.Add(s);

            cbReport.SelectedIndex = 0;
        }

        async void CbReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string itemName = cbReport.SelectedItem as string;
            if (!string.IsNullOrEmpty(itemName))
            {
                flexViewer.DocumentSource = null;
                if (!_pdfs.Contains(itemName))
                    await LoadReport(itemName);
                else
                    await LoadPdf(itemName);
            }
        }

        async Task LoadReport(string reportName)
        {
            // load report
            try
            {
                using (Stream stream = _asm.GetManifestResourceStream("FlexReportSamples.Resources.FlexCommonTasks_UWP.flxr"))
                    _report.Load(stream, reportName);
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToLoadFmt, reportName, ex.Message), "Error");
                await md.ShowAsync();
                return;
            }
            flexViewer.DocumentSource = _report;
        }

        async Task LoadPdf(string pdfName)
        {
            if (_pdfDocSource == null)
            {
                _pdfDocSource = new C1PdfDocumentSource();
            }
            // load pdf
            try
            {
                // load from resource stream
                _pdfDocSource.UseSystemRendering = false;
                var memStream = new MemoryStream();
                using (Stream stream = _asm.GetManifestResourceStream("FlexReportSamples.Resources." + pdfName))
                {
                    await stream.CopyToAsync(memStream);
                    memStream.Position = 0;
                }
                await _pdfDocSource.LoadFromStreamAsync(memStream.AsRandomAccessStream());
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToLoadFmt, pdfName, ex.Message), "Error");
                await md.ShowAsync();
                return;
            }
            flexViewer.DocumentSource = _pdfDocSource;
        }
    }
}
