using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace FlexGridSamples
{
    /// <summary>
    /// Interaction logic for MediaLibrary.xaml
    /// </summary>
    public partial class MediaLibrary : Page
    {
        private List<Song> _songs;

        public MediaLibrary()
        {
            InitializeComponent();
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, BindITunesGrid);
            _flexMedia.SizeChanged += OnGridSizeChanged;
            if (Util.IsWindowsPhoneDevice())
            {
                _flexMedia.Loaded += _flexMedia_Loaded;
            }
        }
        private void _flexMedia_Loaded(object sender, RoutedEventArgs e)
        {
            NameColumn.Width = new GridLength(240);
        }

        // load songs into the grid
        async void BindITunesGrid()
        {
            // load songs
            _songs = await MediaLibraryStorage.Load();

            // build view
            var view = new C1.Xaml.C1CollectionView(_songs);
            view.GroupDescriptions.Add(new C1.Xaml.PropertyGroupDescription("Artist"));
            view.GroupDescriptions.Add(new C1.Xaml.PropertyGroupDescription("Album"));

            // configure grid
            var fg = _flexMedia;
            fg.CellFactory = new MusicCellFactory();
            fg.MergeManager = null; // << review this, should not merge cells with content
            fg.Columns["Duration"].ValueConverter = new SongDurationConverter();
            fg.Columns["Size"].ValueConverter = new SongSizeConverter();
            fg.ItemsSource = view;

            // configure search box
            _srchMedia.View = view;
            foreach (string name in "Artist|Album|Name".Split('|'))
            {
                _srchMedia.FilterProperties.Add(typeof(Song).GetRuntimeProperty(name));
            }

            // show media library summary
            UpdateSongStatus();
            view.VectorChanged += (s, e) => { UpdateSongStatus(); };

            // done loading songs, hide progress indicator
            _progressBar.Visibility = Visibility.Collapsed;
        }

        // update song status
        void UpdateSongStatus()
        {
            var view = _flexMedia.ItemsSource as C1.Xaml.IC1CollectionView;
            var songs = view.OfType<Song>();
            _txtSongs.Text = string.Format(Strings.SongInfo,
                (from s in songs select s.Artist).Distinct().Count(),
                (from s in songs select s.Album).Distinct().Count(),
                songs.Count(),
                (double)(from s in songs select s.Size / 1024.0 / 1024.0).Sum(),
                (double)(from s in songs select s.Duration / 1000.0 / 3600.0 / 24.0).Sum());
        }

        // turn ownerdraw on and off
        void _chkOwnerDraw_Click(object sender, RoutedEventArgs e)
        {
            _flexMedia.CellFactory = _chkOwnerDraw.IsChecked.Value
                ? new MusicCellFactory()
                : null;
        }

        //Set the zoom so that it fits grid width.
        private void OnGridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _flexMedia.ChangeView(null, null, (float)_flexMedia.ActualWidth / (_flexMedia.Columns.Sum(c => (float)c.ActualWidth) + 1), true);
            _flexMedia.ZoomMode = ZoomMode.Disabled;
        }

        // converter for artist/album groups
        public class GroupHeaderConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string culture)
            {
                // return group name only (no counts)
                var group = value as ICollectionViewGroup;
                if (group != null && targetType == typeof(string))
                {
                    return group.Group.ToString();
                }

                // default
                return value;
            }
            public object ConvertBack(object value, Type targetType, object parameter, string culture)
            {
                throw new NotImplementedException();
            }
        }

        // converter for song durations (stored in milliseconds)
        public class SongDurationConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string culture)
            {
                var ts = TimeSpan.FromMilliseconds((long)value);
                return ts.Hours == 0
                    ? string.Format(Strings.MMSS, ts.Minutes, ts.Seconds)
                    : string.Format(Strings.HHMMSS, ts.Hours, ts.Minutes, ts.Seconds);
            }
            public object ConvertBack(object value, Type targetType, object parameter, string culture)
            {
                throw new NotImplementedException();
            }
        }

        // converter for song sizes (return x.xx MB)
        public class SongSizeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string culture)
            {
                return string.Format(Strings.Size, (long)value / 1024.0 / 1024.0);
            }
            public object ConvertBack(object value, Type targetType, object parameter, string culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
