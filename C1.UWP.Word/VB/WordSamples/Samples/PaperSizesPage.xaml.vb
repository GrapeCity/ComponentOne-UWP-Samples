Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml.Word.Objects
Imports C1.Xaml.Word
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
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
Partial Public NotInheritable Class PaperSizesPage
    Inherits Page
    Private word As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf PaperSizesPage_Loaded

        word = New C1WordDocument(PaperKind.Letter)
        word.Clear()
    End Sub

    Sub PaperSizesPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentPaperSizes(word)
        WordUtils.SetDocumentInfo(word, Strings.PaperSizesDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(word.ToRtfText())
        progressRing.IsActive = False
    End Sub


    Shared Sub CreateDocumentPaperSizes(word As C1WordDocument)
        ' landscape for first page
        Dim landscape As Boolean = True
        word.Landscape = landscape

        ' add title
        Dim titleFont As New Font("Tahoma", 24, RtfFontStyle.Bold)
        Dim rc As Rect = WordUtils.PageRectangle(word)
        word.AddParagraph(Strings.PaperSizesFirstPage, titleFont)
        Dim paragraph As RtfParagraph = CType(word.Current, RtfParagraph)
        paragraph.BottomBorderColor = Colors.Purple
        paragraph.BottomBorderStyle = RtfBorderStyle.Dotted
        paragraph.BottomBorderWidth = 3.0F

        ' view warning
        Dim warningFont As New Font("Arial", 14)
        word.AddParagraph(Strings.PaperSizesWarning, warningFont, Colors.Blue)

        ' create constant font and StringFormat objects
        Dim font As New Font("Tahoma", 18)
        Dim sf As New StringFormat()
        sf.Alignment = HorizontalAlignment.Center
        sf.LineAlignment = VerticalAlignment.Center
        word.AddParagraph(String.Empty, font, Colors.Black)

        ' create one page with each paper size
        For Each pk As PaperKind In [Enum].GetValues(GetType(PaperKind))
            ' skip custom page size
            If pk = PaperKind.[Custom] Then
                Continue For
            End If

            ' add new page for every page after the first one
            word.PageBreak()

            ' set paper kind and orientation
            Dim section As New RtfSection(pk)
            word.Add(section)
            landscape = Not landscape
            word.Landscape = landscape

            ' add some content on the page
            Dim text As String = String.Format(Strings.StringFormatTwoArg, pk, word.Landscape)
            word.AddParagraph(text)
            paragraph = CType(word.Current, RtfParagraph)
            paragraph.SetRectBorder(RtfBorderStyle.DashSmall, Colors.Aqua, 2.0F)
            word.AddParagraph(String.Empty)
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        WordUtils.Save(word)
    End Sub
End Class