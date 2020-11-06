using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FlexGridSamples
{
    public sealed partial class CustomColumns : Page
    {
        private ObservableCollection<Song> _songs;

        public CustomColumns()
        {
            this.InitializeComponent();
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, BindGrid);
            if (Util.IsWindowsPhoneDevice())
            {
                _flex.Loaded += _flex_Loaded;
            }
        }

        private void _flex_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonColumn.Width = new GridLength(160);
        }

        // load songs into the grid
        async void BindGrid()
        {
            // load songs
            _songs = new ObservableCollection<Song>( await MediaLibraryStorage.Load());

            // configure grid
            var fg = _flex;
            fg.CellFactory = new MusicCellFactory();
            fg.Columns["Duration"].ValueConverter = new FlexGridSamples.MediaLibrary.SongDurationConverter();
            fg.Columns["Size"].ValueConverter = new FlexGridSamples.MediaLibrary.SongSizeConverter();
            fg.ItemsSource = _songs;

            // done loading songs, hide progress indicator
            _progressBar.Visibility = Visibility.Collapsed;
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            var song = GetSong(sender);
            var index = _songs.IndexOf(song);
            
            if (index > 0)
            {
                _songs.RemoveAt(index);
                _songs.Insert(index - 1, song);

                _flex.SelectedIndex = index - 1;
                _flex.Invalidate();
            }
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            var song = GetSong(sender);
            var index = _songs.IndexOf(song);
            if (index < _songs.Count - 1)
            {
                _songs.RemoveAt(index);
                _songs.Insert(index + 1, song);

                _flex.SelectedIndex = index + 1;
                _flex.Invalidate();
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var song = GetSong(sender);
            _songs.Remove(song);
        }

        // get the song that is represented by a control on the grid
        Song GetSong(object control)
        {
            FrameworkElement e = control as FrameworkElement;
            return e.DataContext as Song;
        }
    }

}
