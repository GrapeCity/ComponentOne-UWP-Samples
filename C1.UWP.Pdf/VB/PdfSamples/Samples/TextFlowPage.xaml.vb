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
Partial Public NotInheritable Class TextFlowPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf TextFlowPage_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub TextFlowPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentTextFlow(pdf)
        SetDocumentInfo(pdf, Strings.TextFlowDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentTextFlow(pdf As C1PdfDocument)
        ' load long string from resource file
        Dim text As String = Strings.ResourceNotFound

        Using sr As New StreamReader(GetType(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("PdfSamples.flow.txt"))
            text = sr.ReadToEnd()
        End Using
        text = text.Replace(vbTab, "   ")
        text = String.Format("{0}" & vbCr & vbLf & vbCr & vbLf & "---oOoOoOo---" & vbCr & vbLf & vbCr & vbLf & "{0}", text)

        ' create pdf document
        pdf.DocumentInfo.Title = Strings.TextFlowDocumentTitle

        ' add title
        Dim titleFont As New Font("Tahoma", 24, PdfFontStyle.Bold)
        Dim bodyFont As New Font("Tahoma", 9)
        Dim rcPage As Rect = PageRectangle(pdf)
        Dim rc As Rect = RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, False)
        rc.Y += titleFont.Size + 6
        rc.Height = rcPage.Height - rc.Y

        ' create two columns for the text
        Dim rcLeft As Rect = rc
        rcLeft.Width = rcPage.Width / 2 - 12
        rcLeft.Height = 300
        rcLeft.Y = (rcPage.Y + rcPage.Height - rcLeft.Height) / 2
        Dim rcRight As Rect = rcLeft
        rcRight.X = rcPage.Right - rcRight.Width

        ' start with left column
        rc = rcLeft

        ' render string spanning columns and pages
        While True
            ' render as much as will fit into the rectangle
            rc = Inflate(rc, -3, -3)
            Dim nextChar As Integer = pdf.DrawString(text, bodyFont, Colors.Black, rc)
            rc = Inflate(rc, +3, +3)
            pdf.DrawRectangle(Colors.LightGray, rc)

            ' break when done
            If nextChar >= text.Length Then
                Exit While
            End If

            ' get rid of the part that was rendered
            text = text.Substring(nextChar)

            ' switch to right-side rectangle
            If rc.Left = rcLeft.Left Then
                rc = rcRight
            Else
                ' switch to left-side rectangle on the next page
                pdf.NewPage()
                rc = rcLeft
            End If
        End While
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class