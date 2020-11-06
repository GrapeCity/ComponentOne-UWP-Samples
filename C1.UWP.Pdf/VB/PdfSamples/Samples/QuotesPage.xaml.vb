Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Pdf

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class QuotesPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf QuotesPage_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub QuotesPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentQuotes(pdf)
        SetDocumentInfo(pdf, Strings.QuotesDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentQuotes(pdf As C1PdfDocument)
        ' calculate page rect (discounting margins)
        Dim rcPage As Rect = PageRectangle(pdf)
        Dim rc As Rect = rcPage

        ' initialize output parameters
        Dim hdrFont As New Font("Arial", 14, PdfFontStyle.Bold)
        Dim titleFont As New Font("Arial", 24, PdfFontStyle.Bold)
        Dim txtFont As New Font("Times New Roman", 10, PdfFontStyle.Italic)

        ' add title
        rc = RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rc)

        ' build document
        For Each s As String In GetQuotes()
            Dim authorQuote As String() = s.Split(vbTab.ToCharArray())

            ' render header (author)
            Dim author As String = authorQuote(0)
            rc.Y += 20
            rc = RenderParagraph(pdf, author, hdrFont, rcPage, rc, True)

            ' render body text (quote)
            Dim text As String = authorQuote(1)
            rc.X = rcPage.X + 36
            ' << indent body text by 1/2 inch
            rc.Width = rcPage.Width - 40
            rc = RenderParagraph(pdf, text, txtFont, rcPage, rc)
            rc.X = rcPage.X
            ' << restore indent
            rc.Width = rcPage.Width
            ' << add 12pt spacing after each quote
            rc.Y += 12
        Next
    End Sub

    Shared Function GetQuotes() As List(Of String)
        Dim list As New List(Of String)()

        Using sr As New StreamReader(GetType(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("PdfSamples.quotes.txt"))
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
        Save(pdf)
    End Sub
End Class