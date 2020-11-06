using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using C1.Xaml;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using RichTextBoxSamples.Tools;
using System.Collections.Generic;
using docs = C1.Xaml.RichTextBox.Documents;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;

namespace RichTextBoxSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppBarDemo : Page
    {
        public AppBarDemo()
        {
            this.InitializeComponent();

            btnBold.RichTextBox = rtb;
            btnItalic.RichTextBox = rtb;
            btnUnderline.RichTextBox = rtb;
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                btnIncreaseFontSize.RichTextBox = rtb;
                btnDecreaseFontSize.RichTextBox = rtb;
                btnLeft.RichTextBox = rtb;
                btnCenter.RichTextBox = rtb;
                btnRight.RichTextBox = rtb;
                btnUndo.RichTextBox = rtb;
                btnRedo.RichTextBox = rtb;
            }            

            Assembly asm = typeof(DemoRichTextBox).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("RichTextBoxSamples.Resources.simple.htm");
            var html = new StreamReader(stream).ReadToEnd();
            rtb.Html = html;            
        }

        private async void rtb_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var md = new MessageDialog(Strings.NavigateMessage + e.Hyperlink.NavigateUri, Strings.Navigate);

            md.Commands.Add(new UICommand(Strings.Ok, (UICommandInvokedHandler) =>
            {
                Windows.System.Launcher.LaunchUriAsync(e.Hyperlink.NavigateUri);
            }));

            md.Commands.Add(new UICommand(Strings.Cancel, (UICommandInvokedHandler) =>
            {
                rtb.Select(e.Hyperlink.ContentStart.TextOffset, e.Hyperlink.ContentRange.Text.Length);
            }));

            await md.ShowAsync();
        }

        #region Lists
        void btnList_Click(object sender, RoutedEventArgs e)
        {
            using (new DocumentHistoryGroup(rtb.DocumentHistory))
            {
                var range = rtb.Selection;
                // check if selection is already a list
                var isChecked = range.EditRanges.All(r => docs.TextMarkerStyle.Disc.Equals(GetMarkerStyle(r)));
                range.TrimRuns();
                rtb.Selection = range;
                foreach (var r in range.EditRanges)
                {
                    if (isChecked)
                    {
                        // undo list
                        range.UndoList();
                    }
                    else
                    {
                        // make bullet list
                        range.MakeList(docs.TextMarkerStyle.Disc);
                    }
                }
            }
            rtb.Focus(FocusState.Programmatic);
        }

        /// <summary>
        /// Get the MarkerStyle of the selection.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        docs.TextMarkerStyle? GetMarkerStyle(C1TextRange range)
        {
            var lists = range.Lists.ToList();
            docs.TextMarkerStyle? marker = lists.Any() ? new docs.TextMarkerStyle?(lists.First().MarkerStyle) : null;
            foreach (var list in lists)
            {
                if (marker != list.MarkerStyle) return null;
            }
            return marker;
        }
        #endregion

        #region Font Colors

        private void btnFontColor_Click(object sender, RoutedEventArgs e)
        {
            FontColorTool fontColorPicker = new FontColorTool();
            fontColorPicker.RichTextBox = rtb;
            fontColorPicker.ColorMode = FontColorMode.Foreground;
            fontColorPicker.Popup.Placement = FlyoutPlacementMode.Top;
            fontColorPicker.Show(btnBold);
        }

        private void btnHighlight_Click(object sender, RoutedEventArgs e)
        {
            FontColorTool fontColorPicker = new FontColorTool();
            fontColorPicker.RichTextBox = rtb;
            fontColorPicker.ColorMode = FontColorMode.Background;
            fontColorPicker.Popup.Placement = FlyoutPlacementMode.Top;
            fontColorPicker.Show(btnBold);
        }

        #endregion

        #region Insert Objects

        private void btnInsertTable_Click(object sender, RoutedEventArgs e)
        {
            InsertTableTool tableTool = new InsertTableTool();
            tableTool.RichTextBox = rtb;
            tableTool.Popup.Placement = FlyoutPlacementMode.Top;
            tableTool.Show(sender as FrameworkElement);
        }

        private void btnInsertHyperlink_Click(object sender, RoutedEventArgs e)
        {
            InsertHyperlinkTool hyperlinkTool = new InsertHyperlinkTool();
            hyperlinkTool.RichTextBox = rtb;
            hyperlinkTool.Popup.Placement = FlyoutPlacementMode.Top;
            hyperlinkTool.Show(sender as FrameworkElement);
        }

        private void btnInsertPicture_Click(object sender, RoutedEventArgs e)
        {
            InsertImageTool imageTool = new InsertImageTool();
            imageTool.RichTextBox = rtb;
            imageTool.Popup.Placement = FlyoutPlacementMode.Top;
            imageTool.Show(sender as FrameworkElement);
        }

        private async void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var source = new BitmapImage();
                var newElement = new C1InlineUIContainer { Content = source, ContentTemplate = ImageAttach.ImageTemplate };
                ExceptionRoutedEventHandler failed = delegate
                {
                    newElement.Remove();
                };
                source.ImageFailed += failed;
                var stream = await file.OpenAsync(FileAccessMode.Read);
                source.SetSource(stream);

                using (var dataReader = new DataReader(stream))
                {
                    stream.Seek(0);
                    var bytes = new byte[stream.Size];
                    await dataReader.LoadAsync((uint)stream.Size);
                    dataReader.ReadBytes(bytes);
                    ImageAttach.SetStream(source, bytes);
                }
                using (new DocumentHistoryGroup(rtb.DocumentHistory))
                {
                    rtb.Selection.Delete();
                    rtb.Selection.Start.InsertInline(newElement);
                }
                rtb.Focus(FocusState.Programmatic);
            }
        }
        #endregion        
    }
}
