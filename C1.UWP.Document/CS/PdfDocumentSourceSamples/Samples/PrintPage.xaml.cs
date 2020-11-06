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
    public sealed partial class PrintPage : Page
    {
        C1PdfDocumentSource _pdfDocSource = new C1PdfDocumentSource();
        StorageFile _pdfFile;

        public PrintPage()
        {
            this.InitializeComponent();

            this.Unloaded += Page_Unloaded;
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

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                try
                {
                    _pdfDocSource.UseSystemRendering = cbxUseSystemRendering.IsChecked.Value;
                    if (_pdfFile == null)
                    {
                        using (Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("PdfDocumentSourceSamples.Resources.DefaultDocument.pdf"))
                            await _pdfDocSource.LoadFromStreamAsync(stream.AsRandomAccessStream());
                    }
                    else
                        await _pdfDocSource.LoadFromFileAsync(_pdfFile);
                    break;
                }
                catch (PdfPasswordException)
                {
                    fileNameBlock.Text = _pdfFile.Name;
                    passwordBox.Password = string.Empty;
                    if (await passwordDialog.ShowAsync() != ContentDialogResult.Primary)
                        return;
                    _pdfDocSource.Credential = new System.Net.NetworkCredential(null, passwordBox.Password);
                }
                catch (Exception ex)
                {
                    MessageDialog md = new MessageDialog(string.Format(Strings.PdfErrorFormat, _pdfFile.Name, ex.Message), Strings.ErrorTitle);
                    await md.ShowAsync();
                    return;
                }
            }

            btnPrint.IsEnabled = false;
            try
            {
                await _pdfDocSource.ShowPrintUIAsync();
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToPrintFmt, ex.Message), Strings.ErrorTitle);
                await md.ShowAsync();
            }
            finally
            {
                btnPrint.IsEnabled = true;
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
    }
}
