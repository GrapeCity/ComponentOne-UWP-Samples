using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using C1.C1Zip;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Popups;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ZipSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoZip : Page
    {
        C1ZipFile _zip;
        CollectionViewSource _cvs = new CollectionViewSource();
        MemoryStream zipMemoryStream = null;

        public DemoZip()
        {
            this.InitializeComponent();
            _flex.SelectedItemChanged += _flex_SelectedItemChanged;
        }

        void _flex_SelectedItemChanged(object sender, EventArgs e)
        {
            if (_flex.SelectedItem != null)
            {
                _btnView.IsEnabled = true;
                _btnRemove.IsEnabled = true;
            }
            else
            {
                _btnView.IsEnabled = false;
                _btnRemove.IsEnabled = false;
            }
        }

        // refresh view when collection is modified
        void RefreshView()
        {
            _flex.ItemsSource = null;
            if (_zip == null)
            {
                return;
            }
            _flex.ItemsSource = _zip.Entries;
            if (_zip.Entries.Count == 0)
            {
                _btnCompress.IsEnabled = false;
                _btnRemove.IsEnabled = false;
                _btnView.IsEnabled = false;
                _btnExtract.IsEnabled = false;
                _zip=null;
            }
        }

        // open an existing zip file
        async void _btnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();

                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add(".zip");
                StorageFile _zipfile = await picker.PickSingleFileAsync();
                if (_zipfile != null)
                {
                    Clear();
                    progressBar.Visibility = Visibility.Visible;

                    if (_zip == null)
                    {
                        _zip = new C1ZipFile(new System.IO.MemoryStream(), true);
                    }
                    var stream = await _zipfile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                    _zip.Open(stream.AsStream());

                    _btnExtract.IsEnabled = true;
                    RefreshView();
                }
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine(x.Message);
            }
            progressBar.Visibility = Visibility.Collapsed;
        }

        // remove selected entries from zip
        void _btnRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (C1ZipEntry entry in _flex.SelectedItems)
            {
                _zip.Entries.Remove(entry.FileName);
            }
            RefreshView();
        }

        // show a preview of the selected entry
        void _btnView_Click(object sender, RoutedEventArgs e)
        {
            var entry = _flex.SelectedItem as C1ZipEntry;
            if (entry != null)
            {
                using (var stream = entry.OpenReader())
                {
                    var sr = new System.IO.StreamReader(stream);
                    _tbContent.Text = sr.ReadToEnd();
                }
                _preview.Visibility = Visibility.Visible;
                _mainpage.Visibility = Visibility.Collapsed;
            }
        }

        // close the preview pane by hiding it
        void _btnClosePreview_Click_1(object sender, RoutedEventArgs e)
        {
            _preview.Visibility = Visibility.Collapsed;
            _mainpage.Visibility = Visibility.Visible;
        }

        // add files by folder
        private async void _btnPickFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FolderPicker folderPicker = new FolderPicker();
                folderPicker.FileTypeFilter.Add(Strings.Star);

                StorageFolder pickedFolder = await folderPicker.PickSingleFolderAsync();
                if (pickedFolder != null)
                {
                    if (_btnExtract.IsEnabled)
                    {
                        Clear();
                    }
                    progressBar.Visibility = Visibility.Visible;

                    if (zipMemoryStream == null)
                    {
                        zipMemoryStream = new MemoryStream();
                    }
                    if (_zip == null)
                    {
                        _zip = new C1ZipFile(zipMemoryStream, true);
                    }
                    await _zip.Entries.AddFolderAsync(pickedFolder);

                    _btnCompress.IsEnabled = true;
                }

            }
            catch
            {
            }
            RefreshView();
            progressBar.Visibility = Visibility.Collapsed;
        }

        // add files
        private async void _btnPickFiles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add(Strings.Star);

                var files = await picker.PickMultipleFilesAsync();

                if (files != null)
                {
                    if (files.Count == 0)
                    {
                        return;
                    }
                    if (_btnExtract.IsEnabled)
                    {
                        Clear();
                    }
                    progressBar.Visibility = Visibility.Visible;
                    if (zipMemoryStream == null)
                    {
                        zipMemoryStream = new MemoryStream();
                    }
                    if (_zip == null)
                    {
                        _zip = new C1ZipFile(zipMemoryStream, true);
                    }
                    foreach (var f in files)
                    {
                        await _zip.Entries.AddAsync(f);
                    }
                    _btnCompress.IsEnabled = true;
                }
            }
            catch
            {
            }
            RefreshView();
            progressBar.Visibility = Visibility.Collapsed;
        }

        private async void _btnCompress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (zipMemoryStream != null)
                {
                    FileSavePicker fileSavePicker = new FileSavePicker();
                    fileSavePicker.FileTypeChoices.Add(Strings.ZipFile, new List<string> { ".zip" });
                    fileSavePicker.DefaultFileExtension = ".zip";
                    fileSavePicker.SuggestedFileName = Strings.NewFolder;
                    fileSavePicker.CommitButtonText = Strings.Save;
                    fileSavePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

                    StorageFile pickedSaveFile = await fileSavePicker.PickSaveFileAsync();
                    await FileIO.WriteBytesAsync(pickedSaveFile, zipMemoryStream.ToArray());
                    MessageDialog md = new MessageDialog(Strings.CompressMessage + pickedSaveFile.Path);
                    md.ShowAsync();
                }
            }
            catch
            {
            }
            RefreshView();
        }

        private async void _btnExtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FolderPicker folderPicker = new FolderPicker();
                folderPicker.FileTypeFilter.Add(Strings.Star);

                StorageFolder pickedFolder = await folderPicker.PickSingleFolderAsync();
                progressBar.Visibility = Visibility.Visible;
                foreach (var entry in _zip.Entries)
                {
                    var name = entry.FileName;
                    await entry.Extract(pickedFolder, name);
                }
                MessageDialog md = new MessageDialog(Strings.ExtractMessage + pickedFolder.Path);
                md.ShowAsync();
            }
            catch
            {
            }
            RefreshView();
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void _btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            _flex.ItemsSource = null;

            if (zipMemoryStream != null)
            {
                zipMemoryStream.Flush();
                zipMemoryStream.Dispose();
            }
            zipMemoryStream = null;
            _btnCompress.IsEnabled = false;
            _btnExtract.IsEnabled = false;
            if (_zip != null)
            {
                _zip.Close();
                _zip = null;
            }
        }
    }
}
