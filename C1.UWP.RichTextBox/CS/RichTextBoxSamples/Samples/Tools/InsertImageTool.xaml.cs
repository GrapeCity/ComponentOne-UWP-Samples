using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Streams;

namespace RichTextBoxSamples.Tools
{
    public sealed partial class InsertImageTool : UserControl
    {
        public Flyout Popup
        {
            get;
            set;
        }

        public C1RichTextBox RichTextBox
        {
            get;
            set;
        }

        public InsertImageTool()
        {
            this.InitializeComponent();

            // init flyout
            Popup = new Flyout();
            Popup.Content = this;
            Popup.Placement = FlyoutPlacementMode.Bottom;
        }

        public void Show(FrameworkElement placementTarget)
        {
            Popup.ShowAt(placementTarget);
        }

        public void Close()
        {
            Popup.Hide();
        }

        private async void btnChoosePhoto_Click(object sender, RoutedEventArgs e)
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
                var imageContainer = new C1InlineUIContainer { Content = source, ContentTemplate = ImageAttach.ImageTemplate };
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
                ImageAttach.SetFormat(source, "image/" + file.FileType.Substring(1));
                using (new DocumentHistoryGroup(RichTextBox.DocumentHistory))
                {
                    RichTextBox.Selection.Delete();
                    RichTextBox.Selection.Start.InsertInline(imageContainer);
                }
            }
            else
            {
            }

            Close();
            RichTextBox.Focus(FocusState.Programmatic);
        }

        private void btnFromWeb_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
                return;

            Uri uri = null;
            try
            {
                uri = new Uri(txtUrl.Text, UriKind.Absolute);
            }
            catch (FormatException)
            {
                try
                {
                    uri = new Uri("http://" + txtUrl.Text, UriKind.Absolute);
                }
                catch (FormatException)
                {
                    MessageDialog dialog = new MessageDialog(Strings.UnValidUrlMessage, Strings.Error);
                    dialog.ShowAsync();
                    return;
                }
            }

            using (new DocumentHistoryGroup(RichTextBox.DocumentHistory))
            {
                RichTextBox.Selection.Delete();
                BitmapImage source = new BitmapImage(uri);
                C1InlineUIContainer imageContainer = new C1InlineUIContainer();
                imageContainer.Content = source;
                imageContainer.ContentTemplate = ImageAttach.ImageTemplate;
                RichTextBox.Selection.Start.InsertInline(imageContainer);
            }

            Close();
            RichTextBox.Focus(FocusState.Programmatic);
        }
    }
}
