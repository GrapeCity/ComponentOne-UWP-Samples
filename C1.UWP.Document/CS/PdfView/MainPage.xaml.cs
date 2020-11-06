using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Windows.Foundation;
using Windows.Foundation.Collections;

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

using C1.Xaml.Document;
using C1.Xaml.FlexViewer;

namespace PdfView
{
    public sealed partial class MainPage : Page
    {
        const string c_CheckedGlyph = "\xE0A2";
        const string c_UncheckedGlyph = "\xE003";

        C1PdfDocumentSource _pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        ToolMenuItem _closeToolItem;
        ToolMenuItem _useSystemRenderingToolItem;

        public MainPage()
        {
            this.InitializeComponent();

            this.Unloaded += MainPage_Unloaded;
            this.Loaded += MainPage_Loaded;

            flexViewer.PrepareToolMenu += FlexViewer_PrepareToolMenu;
            flexViewer.NavigateToCustomTool += FlexViewer_NavigateToCustomTool;

            _pdfDocSource.DefaultPrintOptions.PageScaling = PageScaling.FitToPrintableArea;
        }

        internal void App_Suspending()
        {
            flexViewer.Pane.HandleSuspending();
        }

        void FlexViewer_PrepareToolMenu(object sender, EventArgs e)
        {
            var items = ((C1FlexViewer)sender).ToolMenuItems;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                switch (items[i].Tool)
                {
                    case FlexViewerTool.PageSettings:
                    case FlexViewerTool.Parameters:
                        items.RemoveAt(i);
                        break;
                }
            }
            items.Insert(0, new ToolMenuItem("\xE155", FlexViewerTool.CustomTool1, Strings.OpenToolLabel));
            _useSystemRenderingToolItem = new ToolMenuItem(_pdfDocSource.UseSystemRendering ? c_CheckedGlyph : c_UncheckedGlyph, FlexViewerTool.CustomTool3, Strings.UseSystemRenderingToolLabel);
            items.Add(_useSystemRenderingToolItem);
            _closeToolItem = new ToolMenuItem("\xE10A", FlexViewerTool.CustomTool2, Strings.CloseToolLabel);
            items.Add(_closeToolItem);
        }

        async void FlexViewer_NavigateToCustomTool(object sender, CustomToolEventArgs e)
        {
            if (e.Tool == FlexViewerTool.CustomTool1)
            {
                await OpenPdf();
            }
            else if (e.Tool == FlexViewerTool.CustomTool2)
            {
                _pdfDocSource.ClearContent();
            }
            else if (e.Tool == FlexViewerTool.CustomTool3)
            {
                await ChangeUseSystemRendering();
            }
        }

        void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _pdfDocSource.ClearContent();
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var f = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/DefaultDocument.pdf"));
            await LoadPdf(f);
            flexViewer.DocumentSource = _pdfDocSource;
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

        async Task ChangeUseSystemRendering()
        {
            _closeToolItem.IsEnabled = false;
            _useSystemRenderingToolItem.IsEnabled = false;
            try
            {
                _pdfDocSource.UseSystemRendering = !_pdfDocSource.UseSystemRendering;
                _useSystemRenderingToolItem.Glyph = _pdfDocSource.UseSystemRendering ? c_CheckedGlyph : c_UncheckedGlyph;
                await _pdfDocSource.GenerateAsync();
            }
            finally
            {
                _closeToolItem.IsEnabled = true;
                _useSystemRenderingToolItem.IsEnabled = true;
            }
        }

        async Task LoadPdf(StorageFile file)
        {
            _closeToolItem.IsEnabled = false;
            _useSystemRenderingToolItem.IsEnabled = false;

            try
            {
                while (true)
                {
                    try
                    {
                        await _pdfDocSource.LoadFromFileAsync(file);
                        break;
                    }
                    catch (PdfPasswordException)
                    {
                        fileNameBlock.Text = file.Name;
                        passwordBox.Password = string.Empty;
                        if (await passwordDialog.ShowAsync() != ContentDialogResult.Primary)
                            break;
                        _pdfDocSource.Credential = new System.Net.NetworkCredential(null, passwordBox.Password);
                    }
                    catch (Exception ex)
                    {
                        MessageDialog md = new MessageDialog(string.Format(Strings.PdfErrorFormat, file.Name, ex.Message), Strings.ErrorTitle);
                        await md.ShowAsync();
                        break;
                    }
                }
            }
            finally
            {
                _closeToolItem.IsEnabled = true;
                _useSystemRenderingToolItem.IsEnabled = true;
            }
        }

        async Task OpenPdf()
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            fop.ViewMode = PickerViewMode.List;
            fop.FileTypeFilter.Clear();
            fop.FileTypeFilter.Add(".pdf");
            StorageFile file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                await LoadPdf(file);
            }
        }
    }
}
