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
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Pdf

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class TOCPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf TOCPage_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub TOCPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentTOC(pdf)
        SetDocumentInfo(pdf, Strings.TableOfContentsDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentTOC(pdf As C1PdfDocument)
        ' create pdf document
        pdf.DocumentInfo.Title = Strings.TableOfContentsDocumentTitle

        ' add title
        Dim titleFont As New Font("Tahoma", 24, PdfFontStyle.Bold)
        Dim rcPage As Rect = PageRectangle(pdf)
        Dim rc As Rect = RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, False)
        rc.Y += 12

        ' create nonsense document
        Dim bkmk As New List(Of String())()
        Dim headerFont As New Font("Arial", 14, PdfFontStyle.Bold)
        Dim bodyFont As New Font("Times New Roman", 11)
        Dim i As Integer = 0
        While i < 30
            ' create ith header (as a link target and outline entry)
            Dim header As String = String.Format("{0}. {1}", i + 1, BuildRandomTitle())
            rc = RenderParagraph(pdf, header, headerFont, rcPage, rc, True,
                    True)

            ' save bookmark to build TOC later
            Dim pageNumber As Integer = pdf.CurrentPage + 1
            bkmk.Add(New String() {pageNumber.ToString(), header})

            ' create some text
            rc.X += 36
            rc.Width -= 36
            Dim j As Integer = 0
            While j < 3 + _rnd.[Next](20)
                Dim text As String = BuildRandomParagraph()
                rc = RenderParagraph(pdf, text, bodyFont, rcPage, rc)
                rc.Y += 6
                j += 1
            End While
            rc.X -= 36
            rc.Width += 36
            rc.Y += 20
            i += 1
        End While

        ' start Table of Contents
        pdf.NewPage()
        ' start TOC on a new page
        Dim tocPage As Integer = pdf.CurrentPage
        ' save page index (to move TOC later)
        rc = RenderParagraph(pdf, Strings.TableOfContentsDocumentTitle, titleFont, rcPage, rcPage, True)
        rc.Y += 12
        rc.X += 30
        rc.Width -= 40

        ' render Table of Contents
        Dim dottedPen As New Pen(Colors.Gray, 1.5F)
        dottedPen.DashStyle = DashStyle.Dot
        Dim sfRight As New StringFormat()
        sfRight.Alignment = HorizontalAlignment.Right
        rc.Height = bodyFont.Size * 1.2
        For Each entry As String() In bkmk
            ' get bookmark info
            Dim page As String = entry(0)
            Dim header As String = entry(1)

            ' render header name and page number
            pdf.DrawString(header, bodyFont, Colors.Black, rc)
            pdf.DrawString(page, bodyFont, Colors.Black, rc, sfRight)

#If True Then
            ' connect the two with some dots (looks better than a dotted line)
            Dim dots As String = ". "
            Dim wid As Double = pdf.MeasureString(dots, bodyFont).Width
            Dim x1 As Double = rc.X + pdf.MeasureString(header, bodyFont).Width + 8
            Dim x2 As Double = rc.Right - pdf.MeasureString(page, bodyFont).Width - 8
            Dim x As Double = rc.X
            rc.X = x1
            While rc.X < x2
                pdf.DrawString(dots, bodyFont, Colors.Gray, rc)
                rc.X += wid
            End While
            rc.X = x
#Else
            ' connect with a dotted line (another option)
            Dim x1 As Object = rc.X + pdf.MeasureString(header, bodyFont).Width + 5
            Dim x2 As Object = rc.Right - pdf.MeasureString(page, bodyFont).Width - 5
            Dim y As Object = rc.Top + bodyFont.Size
            pdf.DrawLine(dottedPen, x1, y, x2, y)
#End If
            ' add local hyperlink to entry
            pdf.AddLink(Strings.PoundSign + header, rc)

            ' move on to next entry
            rc = Offset(rc, 0, rc.Height)
            If rc.Bottom > rcPage.Bottom Then
                pdf.NewPage()
                rc.Y = rcPage.Y
            End If
        Next

        ' move table of contents to start of document
        Dim lastPage As PdfPage = pdf.Pages.Last()
        pdf.Pages.RemoveAt(pdf.Pages.Count - 1)
        pdf.Pages.Insert(0, lastPage)
    End Sub

    Shared Function BuildRandomTitle() As String
        Dim a1 As String() = Strings.BuildRandomTitleString1.Split("|"c)
        Dim a2 As String() = Strings.BuildRandomTitleString2.Split("|"c)
        Dim a3 As String() = Strings.BuildRandomTitleString3.Split("|"c)
        Return String.Format("{0} {1} {2}", a1(_rnd.[Next](a1.Length - 1)), a2(_rnd.[Next](a2.Length - 1)), a3(_rnd.[Next](a3.Length - 1)))
    End Function

    Shared Function BuildRandomParagraph() As String
        Dim sb As New StringBuilder()
        Dim i As Integer = 0
        While i < 5 + _rnd.[Next](10)
            sb.AppendFormat(BuildRandomSentence())
            i += 1
        End While
        Return sb.ToString()
    End Function
    Shared Function BuildRandomSentence() As String
        Dim a1 As String() = Strings.BuildRandomSentenceString1.Split("|"c)
        Dim a2 As String() = Strings.BuildRandomSentenceString2.Split("|"c)
        Dim a3 As String() = Strings.BuildRandomSentenceString3.Split("|"c)
        Dim a4 As String() = Strings.BuildRandomSentenceString4.Split("|"c)
        Return String.Format("{0} {1} {2} {3}. ", a1(_rnd.[Next](a1.Length - 1)), a2(_rnd.[Next](a2.Length - 1)), a3(_rnd.[Next](a3.Length - 1)), a4(_rnd.[Next](a4.Length - 1)))
    End Function
    Shared _rnd As New Random()

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class