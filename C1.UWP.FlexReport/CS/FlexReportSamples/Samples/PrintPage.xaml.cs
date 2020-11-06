using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

using C1.Xaml.FlexReport;

namespace FlexReportSamples
{
    public sealed partial class PrintPage : Page
    {
        private const string c_Builtin = "Built-in FlexReportCommonTasks_UWP.flxr";
        private const string c_Browse = "Browse...";

        private C1FlexReport _report;
        private ReportItem _previousItem;

        public PrintPage()
        {
            this.InitializeComponent();

            _report = new C1FlexReport();

            //
            _previousItem = (ReportItem)tbReportFile.Items[0];
            tbReportFile.Items.Add(new ReportItem() { Caption = c_Builtin });
            tbReportFile.Items.Add(new ReportItem() { Caption = c_Browse });
            tbReportFile.SelectedIndex = 0;
        }

        public bool FilePickerVisible
        {
            get { return gReportFile.Visibility == Visibility.Visible; }
            set
            {
                gReportFile.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                lblReportFile.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private async Task<bool> SelectFile()
        {
            FileOpenPicker fsp = new FileOpenPicker();
            fsp.FileTypeFilter.Add(".flxr");
            var file = await fsp.PickSingleFileAsync();
            if (file == null)
                return false;

            ReportItem ri = new ReportItem() { Caption = file.DisplayName, File = file };
            tbReportFile.Items.Insert(tbReportFile.Items.Count - 1, ri);
            tbReportFile.SelectedItem = ri;
            UpdateReportsList();
            return true;
        }

        private async void UpdateReportsList()
        {
            string[] reports = null;
            ReportItem ri = tbReportFile.SelectedItem as ReportItem;
            if (ri.File == null && ri.Caption == c_Builtin)
            {
                // get list of reports from resource using stream
                Assembly asm = typeof(ExportPage).GetTypeInfo().Assembly;
                using (Stream stream = asm.GetManifestResourceStream("FlexReportSamples.Resources.FlexCommonTasks_UWP.flxr"))
                    reports = C1FlexReport.GetReportList(stream);
            }
            else
            {
                // get list of reports from a file
                if (ri.File != null)
                {
                    try
                    {
                        reports = await C1FlexReport.GetReportListAsync(ri.File);
                    }
                    catch
                    {
                    }
                }
            }

            // 
            cbReport.Items.Clear();
            if (reports != null && reports.Length > 0)
            {
                foreach (string s in reports)
                    cbReport.Items.Add(s);
                cbReport.SelectedIndex = 0;
                btnPrint.IsEnabled = !_report.IsBusy;
            }
            else
                btnPrint.IsEnabled = false;
        }

        private async Task DoPrint()
        {
            if (_report.IsBusy)
                return;

            string selectedReport = cbReport.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedReport))
                return;
            ReportItem ri = tbReportFile.SelectedItem as ReportItem;
            if (ri == null || (ri.File == null && ri.Caption == c_Browse))
                return;

            // load report
            try
            {
                if (ri.File == null && ri.Caption == c_Builtin)
                {
                    // load from resource stream
                    Assembly asm = typeof(ExportPage).GetTypeInfo().Assembly;
                    using (Stream stream = asm.GetManifestResourceStream("FlexReportSamples.Resources.FlexCommonTasks_UWP.flxr"))
                        _report.Load(stream, selectedReport);
                }
                else
                {
                    // load from selected file
                    await _report.LoadAsync(ri.File, selectedReport);
                }

                // render a report
                await _report.RenderAsync();

                // show print UI
                await _report.ShowPrintUIAsync();
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToPrintFmt, selectedReport, ex.Message), "Error");
                await md.ShowAsync();
                return;
            }
        }

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            btnPrint.IsEnabled = false;
            try
            {
                await DoPrint();
            }
            finally
            {
                btnPrint.IsEnabled = cbReport.SelectedItem != null;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //
            await ExportPage.CopyC1NWind();

            //
            UpdateReportsList();
        }

        private async void btnReportFile_Click(object sender, RoutedEventArgs e)
        {
            await SelectFile();
        }

        private async void tbReportFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReportItem ri = tbReportFile.SelectedItem as ReportItem;
            if (ri == null)
                return;

            if (ri.File == null && ri.Caption == c_Browse)
            {
                if (!await SelectFile())
                {
                    tbReportFile.SelectedItem = _previousItem;
                }
            }
            else
            {
                UpdateReportsList();
            }
            _previousItem = (ReportItem)tbReportFile.SelectedItem;
        }

        private class ReportItem
        {
            public string Caption { get; set; }

            public StorageFile File { get; set; }

            public override string ToString()
            {
                return Caption;
            }
        }
    }
}
