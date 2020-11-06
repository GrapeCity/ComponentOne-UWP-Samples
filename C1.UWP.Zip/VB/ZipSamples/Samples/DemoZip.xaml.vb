Imports Windows.UI.Core
Imports System.Threading.Tasks
Imports Windows.UI.Popups
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports C1.C1Zip
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports Windows.Storage.Streams

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class DemoZip
    Inherits Page
    Private _zip As C1ZipFile
    Private _cvs As New CollectionViewSource()
    Private zipMemoryStream As MemoryStream = Nothing

    Public Sub New()
        Me.InitializeComponent()
        AddHandler _flex.SelectedItemChanged, AddressOf _flex_SelectedItemChanged
    End Sub

    Sub _flex_SelectedItemChanged(sender As Object, e As EventArgs)
        If _flex.SelectedItem IsNot Nothing Then
            _btnView.IsEnabled = True
            _btnRemove.IsEnabled = True
        Else
            _btnView.IsEnabled = False
            _btnRemove.IsEnabled = False
        End If
    End Sub

    ' refresh view when collection is modified
    Sub RefreshView()
        _flex.ItemsSource = Nothing
        If _zip Is Nothing Then
            Return
        End If
        _flex.ItemsSource = _zip.Entries
        If _zip.Entries.Count = 0 Then
            _btnCompress.IsEnabled = False
            _btnRemove.IsEnabled = False
            _btnView.IsEnabled = False
            _btnExtract.IsEnabled = False
            _zip = Nothing
        End If
    End Sub

    ' open an existing zip file
    Async Sub _btnOpen_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim picker As New Windows.Storage.Pickers.FileOpenPicker()

            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
            picker.FileTypeFilter.Add(".zip")
            Dim _zipfile As StorageFile = Await picker.PickSingleFileAsync()
            If _zipfile IsNot Nothing Then
                Clear()
                progressBar.Visibility = Visibility.Visible

                If _zip Is Nothing Then
                    _zip = New C1ZipFile(New MemoryStream(), True)
                End If
                Dim stream As IRandomAccessStream = Await _zipfile.OpenAsync(FileAccessMode.ReadWrite)
                _zip.Open(CType(stream.AsStream(), Stream))

                _btnExtract.IsEnabled = True
                RefreshView()
            End If
        Catch x As Exception
            System.Diagnostics.Debug.WriteLine(x.Message)
        End Try
        progressBar.Visibility = Visibility.Collapsed
    End Sub

    ' remove selected entries from zip
    Sub _btnRemove_Click(sender As Object, e As RoutedEventArgs)
        For Each entry As C1ZipEntry In _flex.SelectedItems
            _zip.Entries.Remove(entry.FileName)
        Next
        RefreshView()
    End Sub

    ' show a preview of the selected entry
    Sub _btnView_Click(sender As Object, e As RoutedEventArgs)
        Dim entry As C1ZipEntry = TryCast(_flex.SelectedItem, C1ZipEntry)
        If entry IsNot Nothing Then
            Using stream As Stream = entry.OpenReader()
                Dim sr As New StreamReader(CType(stream, Stream))
                _tbContent.Text = sr.ReadToEnd()
            End Using
            _preview.Visibility = Visibility.Visible
            _mainpage.Visibility = Visibility.Collapsed
        End If
    End Sub

    ' close the preview pane by hiding it
    Sub _btnClosePreview_Click_1(sender As Object, e As RoutedEventArgs)
        _preview.Visibility = Visibility.Collapsed
        _mainpage.Visibility = Visibility.Visible
    End Sub

    ' add files by folder
    Private Async Sub _btnPickFolder_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim folderPicker As New FolderPicker()
            folderPicker.FileTypeFilter.Add(Strings.Star)

            Dim pickedFolder As StorageFolder = Await folderPicker.PickSingleFolderAsync()
            If pickedFolder IsNot Nothing Then
                If _btnExtract.IsEnabled Then
                    Clear()
                End If
                progressBar.Visibility = Visibility.Visible

                If zipMemoryStream Is Nothing Then
                    zipMemoryStream = New MemoryStream()
                End If
                If _zip Is Nothing Then
                    _zip = New C1ZipFile(zipMemoryStream, True)
                End If
                Await _zip.Entries.AddFolderAsync(pickedFolder)

                _btnCompress.IsEnabled = True

            End If
        Catch
        End Try
        RefreshView()
        progressBar.Visibility = Visibility.Collapsed
    End Sub

    ' add files
    Private Async Sub _btnPickFiles_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim picker As New FileOpenPicker()
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            picker.FileTypeFilter.Add(Strings.Star)

            Dim files As IReadOnlyList(Of StorageFile) = Await picker.PickMultipleFilesAsync()

            If files IsNot Nothing Then
                If files.Count = 0 Then
                    Return
                End If
                If _btnExtract.IsEnabled Then
                    Clear()
                End If
                progressBar.Visibility = Visibility.Visible
                If zipMemoryStream Is Nothing Then
                    zipMemoryStream = New MemoryStream()
                End If
                If _zip Is Nothing Then
                    _zip = New C1ZipFile(zipMemoryStream, True)
                End If
                For Each f As StorageFile In files
                    Await _zip.Entries.AddAsync(f)
                Next
                _btnCompress.IsEnabled = True
            End If
        Catch
        End Try
        RefreshView()
        progressBar.Visibility = Visibility.Collapsed
    End Sub

    Private Async Sub _btnCompress_Click(sender As Object, e As RoutedEventArgs)
        Try
            If zipMemoryStream IsNot Nothing Then
                Dim fileSavePicker As New FileSavePicker()
                fileSavePicker.FileTypeChoices.Add(Strings.ZipFile, New List(Of String)() From {".zip"})
                fileSavePicker.DefaultFileExtension = ".zip"
                fileSavePicker.SuggestedFileName = Strings.NewFolder
                fileSavePicker.CommitButtonText = Strings.Save
                fileSavePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder

                Dim pickedSaveFile As StorageFile = Await fileSavePicker.PickSaveFileAsync()
                Await FileIO.WriteBytesAsync(pickedSaveFile, zipMemoryStream.ToArray())
                Dim md As New MessageDialog(Strings.CompressMessage + pickedSaveFile.Path)
                Dim result As IUICommand = Await md.ShowAsync()
            End If
        Catch
        End Try
        RefreshView()
    End Sub

    Private Async Sub _btnExtract_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim folderPicker As New FolderPicker()
            folderPicker.FileTypeFilter.Add(Strings.Star)

            Dim pickedFolder As StorageFolder = Await folderPicker.PickSingleFolderAsync()
            progressBar.Visibility = Visibility.Visible
            For Each entry As C1ZipEntry In _zip.Entries
                Dim name As String = entry.FileName
                Await entry.Extract(pickedFolder, name)
            Next
            Dim md As New MessageDialog(Strings.ExtractMessage + pickedFolder.Path)
            Dim result As IUICommand = Await md.ShowAsync()
        Catch
        End Try
        RefreshView()
        progressBar.Visibility = Visibility.Collapsed
    End Sub

    Private Sub _btnClear_Click(sender As Object, e As RoutedEventArgs)
        Clear()
    End Sub

    Private Sub Clear()
        _flex.ItemsSource = Nothing

        If zipMemoryStream IsNot Nothing Then
            zipMemoryStream.Flush()
            zipMemoryStream.Dispose()
        End If
        zipMemoryStream = Nothing
        _btnCompress.IsEnabled = False
        _btnExtract.IsEnabled = False
        If _zip IsNot Nothing Then
            _zip.Close()
            _zip = Nothing
        End If
    End Sub
End Class