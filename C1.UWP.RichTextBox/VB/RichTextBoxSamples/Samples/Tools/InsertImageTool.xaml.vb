Imports Windows.Storage.Streams
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox

Partial Public NotInheritable Class InsertImageTool
    Inherits UserControl
    Public Property Popup() As Flyout

    Public Property RichTextBox() As C1RichTextBox

    Public Sub New()
        Me.InitializeComponent()

        ' init flyout
        Popup = New Flyout()
        Popup.Content = Me
        Popup.Placement = FlyoutPlacementMode.Bottom
    End Sub

    Public Sub Show(placementTarget As FrameworkElement)
        Popup.ShowAt(placementTarget)
    End Sub

    Public Sub Close()
        Popup.Hide()
    End Sub

    Private Async Sub btnChoosePhoto_Click(sender As Object, e As RoutedEventArgs)
        Dim openPicker As New FileOpenPicker()
        openPicker.ViewMode = PickerViewMode.Thumbnail
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
        openPicker.FileTypeFilter.Add(".jpg")
        openPicker.FileTypeFilter.Add(".jpeg")
        openPicker.FileTypeFilter.Add(".png")
        Dim file As StorageFile = Await openPicker.PickSingleFileAsync()
        If file IsNot Nothing Then
            Dim source As New BitmapImage()
            Dim imageContainer As New C1InlineUIContainer() With {
                .Content = source,
                .ContentTemplate = ImageAttach.ImageTemplate
            }
            Dim stream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.Read)
            source.SetSource(stream)
            Using dataReader As New DataReader(stream)
                stream.Seek(0)
                Dim bytes As Byte() = New Byte(stream.Size) {}
                Await dataReader.LoadAsync(CType(stream.Size, UInteger))
                dataReader.ReadBytes(bytes)
                ImageAttach.SetStream(source, bytes)
            End Using
            ImageAttach.SetFormat(source, "image/" + file.FileType.Substring(1))
            Using New DocumentHistoryGroup(RichTextBox.DocumentHistory)
                RichTextBox.Selection.Delete()
                RichTextBox.Selection.Start.InsertInline(imageContainer)
            End Using
        Else
        End If

        Close()
        RichTextBox.Focus(FocusState.Programmatic)
    End Sub

    Private Sub btnFromWeb_Click(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrEmpty(txtUrl.Text) Then
            Return
        End If

        Dim uri As Uri = Nothing
        Try
            uri = New Uri(txtUrl.Text, UriKind.Absolute)
        Catch exp As FormatException
            Try
                uri = New Uri("http://" + txtUrl.Text, UriKind.Absolute)
            Catch exp1 As FormatException
                Dim dialog As New MessageDialog(Strings.UnValidUrlMessage, Strings.[Error])
                dialog.ShowAsync()
                Return
            End Try
        End Try

        Using New DocumentHistoryGroup(RichTextBox.DocumentHistory)
            RichTextBox.Selection.Delete()
            Dim source As New BitmapImage(uri)
            Dim imageContainer As New C1InlineUIContainer()
            imageContainer.Content = source
            imageContainer.ContentTemplate = ImageAttach.ImageTemplate
            RichTextBox.Selection.Start.InsertInline(imageContainer)
        End Using

        Close()
        RichTextBox.Focus(FocusState.Programmatic)
    End Sub
End Class