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
Imports C1.Xaml.Pdf

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class PaperSizesPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf PaperSizesPage_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub PaperSizesPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentPaperSizes(pdf)
        SetDocumentInfo(pdf, Strings.PaperSizesDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub


    Shared Sub CreateDocumentPaperSizes(pdf As C1PdfDocument)
        ' add title
        Dim titleFont As New Font("Tahoma", 24, PdfFontStyle.Bold)
        Dim rc As Rect = PageRectangle(pdf)
        RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rc, rc, False)

        ' create constant font and StringFormat objects
        Dim font As New Font("Tahoma", 18)
        Dim sf As New StringFormat()
        sf.Alignment = HorizontalAlignment.Center
        sf.LineAlignment = VerticalAlignment.Center

        ' create one page with each paper size
        Dim firstPage As Boolean = True
        For Each pk As PaperKind In [Enum].GetValues(GetType(PaperKind))
            ' Silverlight doesn't have Enum.GetValues
            'PaperKind pk = fi;

            ' skip custom size
            If pk = PaperKind.[Custom] Then
                Continue For
            End If

            ' add new page for every page after the first one
            If Not firstPage Then
                pdf.NewPage()
            End If
            firstPage = False

            ' set paper kind and orientation
            pdf.PaperKind = pk
            pdf.Landscape = Not pdf.Landscape

            ' draw some content on the page
            rc = PageRectangle(pdf)
            rc = Inflate(rc, -6, -6)
            Dim text As String = String.Format(Strings.StringFormatTwoArg, pdf.PaperKind, pdf.Landscape)
            pdf.DrawString(text, font, Colors.Black, rc, sf)
            pdf.DrawRectangle(Colors.Black, rc)
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class