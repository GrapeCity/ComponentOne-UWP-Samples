Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.Foundation.Collections
Imports System.Reflection
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.FlexGrid
Imports C1.Xaml

''' <summary>
''' Interaction logic for MediaLibrary.xaml
''' </summary>
Partial Public Class MediaLibrary
    Inherits Page
    Private _songs As List(Of Song)

    Public Sub New()
        InitializeComponent()
        Dispatcher.RunAsync(CoreDispatcherPriority.Normal, AddressOf BindITunesGrid)
        AddHandler _flexMedia.SizeChanged, AddressOf OnGridSizeChanged

        If Util.IsWindowsPhoneDevice() Then
            AddHandler _flexMedia.Loaded, AddressOf _flexMedia_Loaded
        End If
    End Sub
    Private Sub _flexMedia_Loaded(sender As Object, e As RoutedEventArgs)
        NameColumn.Width = New GridLength(240)
    End Sub

    ' load songs into the grid
    Async Sub BindITunesGrid()
        ' load songs
        _songs = Await MediaLibraryStorage.Load()

        ' build view
        Dim view As New C1.Xaml.C1CollectionView(_songs)
        view.GroupDescriptions.Add(New C1.Xaml.PropertyGroupDescription("Artist"))
        view.GroupDescriptions.Add(New C1.Xaml.PropertyGroupDescription("Album"))

        ' configure grid
        Dim fg As C1FlexGrid = _flexMedia
        fg.CellFactory = New MusicCellFactory()
        fg.MergeManager = Nothing
        ' << review this, should not merge cells with content
        fg.Columns("Duration").ValueConverter = New SongDurationConverter()
        fg.Columns("Size").ValueConverter = New SongSizeConverter()
        fg.ItemsSource = view

        ' configure search box
        _srchMedia.View = view
        For Each name As String In "Artist|Album|Name".Split("|"c)
            _srchMedia.FilterProperties.Add(GetType(Song).GetRuntimeProperty(name))
        Next

        ' show media library summary
        UpdateSongStatus()
        AddHandler view.VectorChanged, AddressOf OnVectorChanged

        ' done loading songs, hide progress indicator
        _progressBar.Visibility = Visibility.Collapsed
    End Sub

    Sub OnVectorChanged(sender As Object, e As IVectorChangedEventArgs)
        UpdateSongStatus()
    End Sub

    ' update song status
    Sub UpdateSongStatus()
        Dim view As IC1CollectionView = TryCast(_flexMedia.ItemsSource, IC1CollectionView)
        Dim songs As IEnumerable(Of Song) = view.OfType(Of Song)()
        _txtSongs.Text = String.Format(Strings.SongInfo, (From s In songs Select s.Artist).Distinct().Count(), (From s In songs Select s.Album).Distinct().Count(), songs.Count(), CType((From s In songs Select s.Size / 1024.0 / 1024.0).Sum(), Double), CType((From s In songs Select s.Duration / 1000.0 / 3600.0 / 24.0).Sum(), Double))
    End Sub

    ' turn ownerdraw on and off
    Sub _chkOwnerDraw_Click(sender As Object, e As RoutedEventArgs)
        _flexMedia.CellFactory = If(_chkOwnerDraw.IsChecked.Value, New MusicCellFactory(), Nothing)
    End Sub

    'Set the zoom so that it fits grid width.
    Private Sub OnGridSizeChanged(sender As Object, e As SizeChangedEventArgs)
        _flexMedia.ChangeView(Nothing, Nothing, CType(_flexMedia.ActualWidth, Single) / (_flexMedia.Columns.Sum(Function(c) CType(c.ActualWidth, Single)) + 1), True)
        _flexMedia.ZoomMode = ZoomMode.Disabled
    End Sub

    ' converter for artist/album groups
    Public Class GroupHeaderConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.Convert
            ' return group name only (no counts)
            Dim group As ICollectionViewGroup = TryCast(value, ICollectionViewGroup)
            If group IsNot Nothing AndAlso targetType.Equals(GetType(String)) Then
                Return group.Group.ToString()
            End If

            ' default
            Return value
        End Function
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class

    ' converter for song durations (stored in milliseconds)
    Public Class SongDurationConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.Convert
            Dim ts As TimeSpan = TimeSpan.FromMilliseconds(CType(value, Long))
            Return If(ts.Hours = 0, String.Format(Strings.MMSS, ts.Minutes, ts.Seconds), String.Format(Strings.HHMMSS, ts.Hours, ts.Minutes, ts.Seconds))
        End Function
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class

    ' converter for song sizes (return x.xx MB)
    Public Class SongSizeConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.Convert
            Return String.Format(Strings.Size, CType(value, Long) / 1024.0 / 1024.0)
        End Function
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Class