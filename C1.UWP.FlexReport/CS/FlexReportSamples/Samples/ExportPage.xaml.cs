using System;
using System.IO;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Reflection;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using System.Threading.Tasks;
using Windows.System;

using C1.Xaml.Document.Export;
using C1.Xaml.FlexReport;

namespace FlexReportSamples
{
    public sealed partial class ExportPage : Page
    {
        private const string c_Builtin = "Built-in FlexReportCommonTasks_UWP.flxr";
        private const string c_Browse = "Browse...";

        private C1FlexReport _report;
        private ReportItem _previousItem;

        public ExportPage()
        {
            this.InitializeComponent();

            _report = new C1FlexReport();

            //
            _previousItem = (ReportItem)tbReportFile.Items[0];
            tbReportFile.Items.Add(new ReportItem() { Caption = c_Builtin });
            tbReportFile.Items.Add(new ReportItem() { Caption = c_Browse });
            tbReportFile.SelectedIndex = 0;

            // build list of supported export filters
            foreach (var e in _report.SupportedExportProviders)
            {
                cbExportFilter.Items.Add(e.FormatName);
            }
            cbExportFilter.SelectedIndex = 0;
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

            // avoid duplicate entries:
            foreach (ReportItem tri in tbReportFile.Items)
            {
                if (tri.SameAs(ri))
                {
                    tbReportFile.SelectedItem = tri;
                    UpdateReportsList();
                    return true;
                }
            }

            // as of Aug 2016, tbReportFile.Items.Insert(0, ri) crashes with error 0xC000027B
            tbReportFile.Items.Add(ri);
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
                btnExport.IsEnabled = !_report.IsBusy;
            }
            else
                btnExport.IsEnabled = false;
        }

        private async Task DoExport(bool pickDestination)
        {
            if (_report.IsBusy)
                return;

            string selectedReport = cbReport.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedReport))
                return;
            if (cbExportFilter.SelectedIndex < 0 || cbExportFilter.SelectedIndex >= _report.SupportedExportProviders.Length)
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
                    await _report.LoadAsync(ri.File, selectedReport);
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToLoadFmt, selectedReport, ex.Message), "Error");
                await md.ShowAsync();
                return;
            }

            // prepare ExportFilter object
            ExportProvider ep = _report.SupportedExportProviders[cbExportFilter.SelectedIndex];
            ExportFilter ef = ep.NewExporter() as ExportFilter;
            ef.UseZipForMultipleFiles = cbUseZipForMultipleFiles.IsChecked.Value;

            //
            if ((ef is BmpFilter || ef is JpegFilter || ef is PngFilter || ef is GifFilter))
            {
                // these export filters produce more than one file during export
                // ask for directory in this case
                string defFileName = selectedReport + "." + ep.DefaultExtension + ".zip";
                if (cbUseZipForMultipleFiles.IsChecked == true)
                {
                    if (pickDestination)
                    {
                    // ask for zip file
                    FileSavePicker fsp = new FileSavePicker();
                    fsp.DefaultFileExtension = ".zip";
                    fsp.FileTypeChoices.Add(Strings.ZipFiles, new string[] { ".zip" });
                        fsp.SuggestedFileName = defFileName;
                    ef.StorageFile = await fsp.PickSaveFileAsync();
                    if (ef.StorageFile == null)
                        return;
                }
                else
                {
                        // use file in temp folder
                        ef.StorageFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(defFileName, CreationCollisionOption.ReplaceExisting);
                    }
                }
                else
                {
                    if (pickDestination)
                    {
                    FolderPicker fp = new FolderPicker();
                    fp.FileTypeFilter.Add("." + ep.DefaultExtension);
                    fp.FileTypeFilter.Add(".zip");
                    ef.StorageFolder = await fp.PickSingleFolderAsync();
                    if (ef.StorageFolder == null)
                        // user cancels an export
                        return;
                    }
                    else
                    {
                        ef.StorageFolder = await ApplicationData.Current.TemporaryFolder.CreateFolderAsync(selectedReport, CreationCollisionOption.OpenIfExists);
                    }
                }
            }
            else
            {
                string defFileName = selectedReport + "." + ep.DefaultExtension;
                if (pickDestination)
                {
                // ask for file
                FileSavePicker fsp = new FileSavePicker();
                fsp.DefaultFileExtension = "." + ep.DefaultExtension;
                fsp.FileTypeChoices.Add(ep.FormatName + " (." + ep.DefaultExtension + ")", new string[] { "." + ep.DefaultExtension });
                fsp.FileTypeChoices.Add(Strings.ZipFiles, new string[] { ".zip" });
                    fsp.SuggestedFileName = defFileName;
                ef.StorageFile = await fsp.PickSaveFileAsync();
                if (ef.StorageFile == null)
                    return;
            }
                else
                {
                    // use file in temp folder
                    ef.StorageFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(defFileName, CreationCollisionOption.ReplaceExisting);
                }
            }

            try
            {
                await _report.RenderToFilterAsync(ef);
                //_report.RenderToFilter(ef);
                await ShowPreview(ef);
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToExportFmt, selectedReport, ex.Message), "Error");
                await md.ShowAsync();
                return;
            }
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            btnExportTo.IsEnabled = false;
            btnExport.IsEnabled = false;
            try
            {
                await DoExport(false);
            }
            finally
            {
                btnExportTo.IsEnabled = cbReport.SelectedItem != null;
                btnExport.IsEnabled = cbReport.SelectedItem != null;
            }
        }

        private async void btnExportTo_Click(object sender, RoutedEventArgs e)
        {
            btnExportTo.IsEnabled = false;
            btnExport.IsEnabled = false;
            try
            {
                await DoExport(true);
            }
            finally
            {
                btnExportTo.IsEnabled = cbReport.SelectedItem != null;
                btnExport.IsEnabled = cbReport.SelectedItem != null;
            }
        }

        private string GetExportResultDesc(ExportFilter ef)
        {
            if (ef.StorageFolder != null)
            {
                StringBuilder files = new StringBuilder();
                foreach (var file in ef.OutputFiles)
                    files.AppendLine(Path.GetFileName(file));
                return string.Format(Strings.ExportToFolderFmt, ef.StorageFolder.Path, ef.OutputFiles.Count, files.ToString());
            }
            else
            {
                return string.Format(Strings.ExportToFileFmt, ef.PreviewFile.Path) + "\r\n";
            }
        }

        private async Task ShowPreview(ExportFilter ef)
        {
            if (!cbOpenDocument.IsChecked.Value)
            {
                MessageDialog md = new MessageDialog(GetExportResultDesc(ef), Strings.ExportComplete);
                await md.ShowAsync();
                return;
            }

            try
            {
                if (ef.StorageFolder == null)
                {
                    if (!await Launcher.LaunchFileAsync(ef.PreviewFile))
                        throw new Exception("Launcher.LaunchFileAsync() returns false.");
                }
                else
                {
                    if (!await Launcher.LaunchFolderAsync(ef.StorageFolder))
                        throw new Exception("Launcher.LaunchFolderAsync() returns false.");
        }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(GetExportResultDesc(ef) + string.Format(Strings.PreviewErrorFmt, ex.Message), Strings.ExportComplete);
                await md.ShowAsync();
            }
        }

        public static async Task CopyC1NWind()
        {
            var f = await ApplicationData.Current.LocalFolder.TryGetItemAsync("C1NWind.db") as StorageFile;
            Assembly asm = typeof(ExportPage).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("FlexReportSamples.Resources.C1NWind.db"))
            {
                if (f == null || (long)(await f.GetBasicPropertiesAsync()).Size != stream.Length)
                {
                    if (f == null)
                        f = await ApplicationData.Current.LocalFolder.CreateFileAsync("C1NWind.db", CreationCollisionOption.ReplaceExisting);
                    using (Stream dst = await f.OpenStreamForWriteAsync())
                    {
                        await stream.CopyToAsync(dst);
                        await dst.FlushAsync();
                    }
                }
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //
            await CopyC1NWind();

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

            public bool SameAs(ReportItem other)
            {
                if (this.Caption != other.Caption)
                    return false;
                if (this.File == null)
                    return other.File == null;
                return this.File.Path == other.File.Path;
            }
        }
    }
}
