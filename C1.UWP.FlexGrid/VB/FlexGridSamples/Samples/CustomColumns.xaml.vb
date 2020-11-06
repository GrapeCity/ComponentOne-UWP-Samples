Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.FlexGrid

Partial Public NotInheritable Class CustomColumns
    Inherits Page
    Private _songs As ObservableCollection(Of Song)

    Public Sub New()
        Me.InitializeComponent()
        Dim t As IAsyncAction = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, AddressOf BindGrid)
        If Util.IsWindowsPhoneDevice() Then
            AddHandler _flex.Loaded, AddressOf _flex_Loaded
        End If
    End Sub

    Private Sub _flex_Loaded(sender As Object, e As RoutedEventArgs)
        ButtonColumn.Width = New GridLength(160)
    End Sub

    ' load songs into the grid
    Async Sub BindGrid()
        ' load songs
        _songs = New ObservableCollection(Of Song)(Await MediaLibraryStorage.Load())

        ' configure grid
        Dim fg As C1FlexGrid = _flex
        fg.CellFactory = New MusicCellFactory()
        fg.Columns("Duration").ValueConverter = New FlexGridSamples.MediaLibrary.SongDurationConverter()
        fg.Columns("Size").ValueConverter = New FlexGridSamples.MediaLibrary.SongSizeConverter()
        fg.ItemsSource = _songs

        ' done loading songs, hide progress indicator
        _progressBar.Visibility = Visibility.Collapsed
    End Sub

    Private Sub btnMoveUp_Click(sender As Object, e As RoutedEventArgs)
        Dim song As Song = GetSong(sender)
        Dim index As Integer = _songs.IndexOf(song)

        If index > 0 Then
            _songs.RemoveAt(index)
            _songs.Insert(index - 1, song)

            _flex.SelectedIndex = index - 1
            _flex.Invalidate()
        End If
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As RoutedEventArgs)
        Dim song As Song = GetSong(sender)
        Dim index As Integer = _songs.IndexOf(song)
        If index < _songs.Count - 1 Then
            _songs.RemoveAt(index)
            _songs.Insert(index + 1, song)

            _flex.SelectedIndex = index + 1
            _flex.Invalidate()
        End If
    End Sub

    Private Sub btDelete_Click(sender As Object, e As RoutedEventArgs)
        Dim song As Song = GetSong(sender)
        _songs.Remove(song)
    End Sub

    ' get the song that is represented by a control on the grid
    Function GetSong(control As Object) As Song
        Dim e As FrameworkElement = TryCast(control, FrameworkElement)
        Return TryCast(e.DataContext, Song)
    End Function
End Class