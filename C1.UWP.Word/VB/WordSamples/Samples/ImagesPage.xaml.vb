Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml.Word.Objects
Imports C1.Xaml.Word
Imports Windows.UI.Core
Imports Windows.Graphics.Imaging
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Storage.Streams
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class ImagesPage
    Inherits Page
    Private word As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf ImagesPage_Loaded

        word = New C1WordDocument(PaperKind.Letter)
        word.Clear()
    End Sub

    Async Sub ImagesPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        Await CreateDocumentImages(word)
        WordUtils.SetDocumentInfo(word, Strings.TableOfContentsDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(word.ToRtfText())
        progressRing.IsActive = False
    End Sub

    Async Function CreateDocumentImages(word As C1WordDocument) As Task
        ' add first image paragraph
        Dim font As New Font("Segoe UI Light", 16, RtfFontStyle.Italic)
        word.AddParagraph(Strings.ImageFirstParagraph, font, Colors.DarkGray, RtfHorizontalAlignment.Left)
        Dim paragraph As RtfParagraph = CType(word.Current, RtfParagraph)
        paragraph.BottomBorderColor = Colors.Gray
        paragraph.BottomBorderStyle = RtfBorderStyle.[Single]
        paragraph.BottomBorderWidth = 1.0F
        word.AddParagraph(String.Empty)

        ' calculate page rect (discounting margins)
        Dim rcPage As Rect = WordUtils.PageRectangle(word)
        Dim ras As New InMemoryRandomAccessStream()

        ' load image into writeable bitmap
        Dim wb As New WriteableBitmap(880, 660)
        Dim file As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(New Uri("ms-appx:///WordSamplesLib/Assets/pic.jpg"))
        wb.SetSource(Await file.OpenReadAsync())

        ' add image without scaling by center
        word.AddPicture(wb, RtfHorizontalAlignment.Center)
        word.LineBreak()
        word.AddParagraph(String.Empty)

        ' add first image paragraph
        font = New Font("Segoe UI Light", 12, RtfFontStyle.Regular)
        word.AddParagraph(Strings.ImageSecondParagraph, font, Colors.DeepSkyBlue, RtfHorizontalAlignment.Left)
        paragraph = CType(word.Current, RtfParagraph)
        paragraph.BottomBorderColor = Colors.BlueViolet
        paragraph.BottomBorderStyle = RtfBorderStyle.Dotted
        paragraph.BottomBorderWidth = 2.0F
        word.AddParagraph(String.Empty)

        ' add image with scaling by right
        word.AddPicture(wb, RtfHorizontalAlignment.Right)
        Dim picture As RtfPicture = CType(word.Current, RtfPicture)
        picture.Height = 33
        picture.Width = 44
    End Function

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        WordUtils.Save(word)
    End Sub
End Class