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
Partial Public NotInheritable Class QuotesPage
    Inherits Page
    Private word As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf QuotesPage_Loaded

        word = New C1WordDocument(PaperKind.Letter)
        word.Clear()
    End Sub

    Sub QuotesPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentQuotes(word)
        WordUtils.SetDocumentInfo(word, Strings.QuotesDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(word.ToRtfText())
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentQuotes(word As C1WordDocument)
        ' calculate page rect (discounting margins)
        Dim rcPage As Rect = WordUtils.PageRectangle(word)
        Dim height As Double = rcPage.Top

        ' initialize fonts
        Dim hdrFont As New Font("Arial", 14, RtfFontStyle.Bold)
        Dim titleFont As New Font("Arial", 20, RtfFontStyle.Bold)
        Dim txtFont As New Font("Times New Roman", 10, RtfFontStyle.Italic)

        ' add title paragraph
        word.AddParagraph(Strings.QuotesAuthors, titleFont, Colors.DeepPink, RtfHorizontalAlignment.Center)
        word.AddParagraph(String.Empty)
        height += 2 * word.MeasureString(Strings.QuotesAuthors, titleFont, rcPage.Width).Height

        ' build document
        For Each s As String In GetQuotes()
            ' quote
            Dim authorQuote As String() = s.Split(vbTab.ToCharArray())
            Dim author As String = authorQuote(0)
            Dim text As String = authorQuote(1)

            ' if it won't fit this page, do a page break
            Dim h As Double = word.MeasureString(author, hdrFont, rcPage.Width).Height
            Dim sf As New StringFormat()
            sf.Alignment = HorizontalAlignment.Stretch
            h += word.MeasureString(text, txtFont, rcPage.Width, sf).Height
            h += 20
            If height + h > rcPage.Bottom Then
                word.PageBreak()
                height = rcPage.Top
            End If
            height += h

            ' render header (author)
            word.AddParagraph(author, hdrFont, Colors.Black, RtfHorizontalAlignment.Left)
            Dim paragraph As RtfParagraph = CType(word.Current, RtfParagraph)
            paragraph.TopBorderColor = Colors.Black
            paragraph.TopBorderStyle = RtfBorderStyle.[Single]
            paragraph.TopBorderWidth = 1.0F

            ' render body text (quote)
            word.AddParagraph(text, txtFont, Colors.DarkSlateGray, RtfHorizontalAlignment.Left)
            paragraph = CType(word.Current, RtfParagraph)
            paragraph.LeftIndent = 40.0F
            word.AddParagraph(String.Empty)
        Next
    End Sub

    Shared Function GetQuotes() As List(Of String)
        Dim list As New List(Of String)()

        Using sr As New StreamReader(GetType(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("WordSamples.quotes.txt"))
            Dim quotes As String = sr.ReadToEnd()
            For Each quote As String In quotes.Split("*"c)
                Dim pos As Integer = quote.IndexOf(vbCr & vbLf)
                If pos > -1 Then
                    Dim q As String = String.Format("{0}" & vbTab & "{1}", quote.Substring(0, pos), quote.Substring(pos + 2).Trim())
                    list.Add(q)
                End If
            Next
        End Using

        Return list
    End Function

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        WordUtils.Save(word)
    End Sub
End Class