using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.System;
using System.Reflection;

using C1.Xaml.Document;
using C1.Xaml.Document.Export;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PdfDocumentSourceSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExportPage : Page
    {
        C1PdfDocumentSource _pdfDocSource = new C1PdfDocumentSource();
        StorageFile _pdfFile;

        public ExportPage()
        {
            this.InitializeComponent();

            this.Unloaded += Page_Unloaded;

            cbxUseSystemRendering_Click(null, null);
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _pdfDocSource.ClearContent();
        }

        void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                passwordBox.PasswordRevealMode = PasswordRevealMode.Visible;
            }
            else
            {
                passwordBox.PasswordRevealMode = PasswordRevealMode.Hidden;
            }
        }

        private async Task ShowPreview(ExportFilter ef)
        {
            try
            {
                if (ef.StorageFolder == null)
                {
                    await Launcher.LaunchFileAsync(ef.PreviewFile);
                }
                else
                {
                    await Launcher.LaunchFolderAsync(ef.StorageFolder);
                }
            }
            catch
            {
            }
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string fileName = null;
            while (true)
            {
                try
                {
                    _pdfDocSource.UseSystemRendering = cbxUseSystemRendering.IsChecked.Value;
                    if (_pdfFile == null)
                    {
                        using (Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("PdfDocumentSourceSamples.Resources.DefaultDocument.pdf"))
                            await _pdfDocSource.LoadFromStreamAsync(stream.AsRandomAccessStream());
                        fileName = "DefaultDocument.pdf";
                    }
                    else
                    {
                        await _pdfDocSource.LoadFromFileAsync(_pdfFile);
                        fileName = Path.GetFileName(_pdfFile.Name);
                    }
                    break;
                }
                catch (PdfPasswordException)
                {
                    fileNameBlock.Text = fileName;
                    passwordBox.Password = string.Empty;
                    if (await passwordDialog.ShowAsync() != ContentDialogResult.Primary)
                        return;
                    _pdfDocSource.Credential = new System.Net.NetworkCredential(null, passwordBox.Password);
                }
                catch (Exception ex)
                {
                    MessageDialog md = new MessageDialog(string.Format(Strings.PdfErrorFormat, fileName, ex.Message), Strings.ErrorTitle);
                    await md.ShowAsync();
                    return;
                }
            }

            // prepare ExportFilter object
            ExportProvider ep = _pdfDocSource.SupportedExportProviders[cbExportProvider.SelectedIndex];
            ExportFilter ef = ep.NewExporter() as ExportFilter;
            ef.UseZipForMultipleFiles = cbxUseSystemRendering.IsChecked.Value;

            //
            if ((ef is BmpFilter || ef is JpegFilter || ef is PngFilter || ef is GifFilter))
            {
                // these export filters produce more than one file during export
                // ask for directory in this case
                if (cbxUseZipForMultipleFiles.IsChecked == true)
                {
                    // ask for zip file
                    FileSavePicker fsp = new FileSavePicker();
                    fsp.DefaultFileExtension = ".zip";
                    fsp.FileTypeChoices.Add(Strings.ZipFiles, new string[] { ".zip" });
                    fsp.SuggestedFileName = Path.GetFileNameWithoutExtension(fileName) + ".zip";
                    ef.StorageFile = await fsp.PickSaveFileAsync();
                    if (ef.StorageFile == null)
                        return;
                }
                else
                {
                    FolderPicker fp = new FolderPicker();
                    fp.FileTypeFilter.Add("." + ep.DefaultExtension);
                    fp.FileTypeFilter.Add(".zip");
                    ef.StorageFolder = await fp.PickSingleFolderAsync();
                    if (ef.StorageFolder == null)
                        // user cancels an export
                        return;
                }
            }
            else
            {
                // ask for file
                FileSavePicker fsp = new FileSavePicker();
                fsp.DefaultFileExtension = "." + ep.DefaultExtension;
                fsp.FileTypeChoices.Add(ep.FormatName + " (." + ep.DefaultExtension + ")", new string[] { "." + ep.DefaultExtension });
                fsp.FileTypeChoices.Add(Strings.ZipFiles, new string[] { ".zip" });
                fsp.SuggestedFileName = Path.GetFileNameWithoutExtension(fileName) + "." + ep.DefaultExtension;
                ef.StorageFile = await fsp.PickSaveFileAsync();
                if (ef.StorageFile == null)
                    return;
            }

            btnExport.IsEnabled = false;
            try
            {
                await _pdfDocSource.ExportAsync(ef);
                await ShowPreview(ef);
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToExportFmt, ex.Message), Strings.ErrorTitle);
                await md.ShowAsync();
            }
            finally
            {
                btnExport.IsEnabled = true;
            }
        }

        private async void btnFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fsp = new FileOpenPicker();
            fsp.FileTypeFilter.Add(".pdf");
            var file = await fsp.PickSingleFileAsync();
            if (file != null)
            {
                _pdfFile = file;
                tbFile.Text = _pdfFile.Name;
            }
        }

        private void cbxUseSystemRendering_Click(object sender, RoutedEventArgs e)
        {
            _pdfDocSource.UseSystemRendering = cbxUseSystemRendering.IsChecked.Value;
            cbExportProvider.Items.Clear();
            var supportedExportProviders = _pdfDocSource.SupportedExportProviders;
            foreach (var sep in supportedExportProviders)
                cbExportProvider.Items.Add(sep.FormatName);
            cbExportProvider.SelectedIndex = 0;
        }
    }
}
