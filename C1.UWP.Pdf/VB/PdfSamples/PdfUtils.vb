Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.UI
Imports Windows.System
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Pdf

''' <summary>
''' Utility class on top of C1.Xaml.Pdf.
''' </summary>
Public Class PdfUtils
    ''' <summary>
    ''' Create C1Pdf document.
    ''' </summary>
    ''' <returns>The C1Pdf document.</returns>
    Friend Shared Function CreatePdfDocument() As C1PdfDocument
        Dim pdf As New C1PdfDocument(PaperKind.Letter)
        'pdf.ConformanceLevel = PdfAConformanceLevel.PdfA2b;
        'pdf.Clear();
        Return pdf
    End Function
End Class

Module C1PdfDocumentExtension

    <Extension()>
    Public Function RenderParagraph(ByVal pdf As C1PdfDocument, text As String, font As Font, rcPage As Rect, rc As Rect, outline As Boolean,
            linkTarget As Boolean) As Rect
        ' if it won't fit this page, do a page break
        rc.Height = pdf.MeasureString(text, font, rc.Width).Height
        If rc.Bottom > rcPage.Bottom Then
            pdf.NewPage()
            rc.Y = rcPage.Top
        End If

        ' draw the string
        pdf.DrawString(text, font, Colors.Black, rc)

        ' show bounds (to check word wrapping)
        'var p = Pen.GetPen(Colors.Orange);
        'pdf.DrawRectangle(p, rc);

        ' add headings to outline
        If outline Then
            pdf.DrawLine(Colors.Black, rc.X, rc.Y, rc.Right, rc.Y)
            pdf.AddBookmark(text, 0, rc.Y)
        End If

        ' add link target
        If linkTarget Then
            pdf.AddTarget(text, rc)
        End If

        ' update rectangle for next time
        rc = Offset(rc, 0, rc.Height)
        Return rc
    End Function

    <Extension()>
    Public Function RenderParagraph(ByVal doc As C1PdfDocument, text As String, font As Font, rcPage As Rect, rc As Rect, outline As Boolean) As Rect
        Return RenderParagraph(doc, text, font, rcPage, rc, outline,
                False)
    End Function

    <Extension()>
    Public Function RenderParagraph(ByVal doc As C1PdfDocument, text As String, font As Font, rcPage As Rect, rc As Rect) As Rect
        Return RenderParagraph(doc, text, font, rcPage, rc, False,
                False)
    End Function

    <Extension()>
    Public Function PageRectangle(ByVal pdf As C1PdfDocument) As Rect
        Return PageRectangle(pdf, New Thickness(72))
    End Function

    <Extension()>
    Public Function PageRectangle(ByVal pdf As C1PdfDocument, pageMargins As Thickness) As Rect
        Dim rc As Rect = pdf.PageRectangle
        Dim left As Double = Math.Min(rc.Width, rc.Left + pageMargins.Left)
        Dim top As Double = Math.Min(rc.Height, rc.Top + pageMargins.Top)
        Dim width As Double = Math.Max(0, rc.Width - (pageMargins.Left + pageMargins.Right))
        Dim height As Double = Math.Max(0, rc.Height - (pageMargins.Top + pageMargins.Bottom))
        Return New Rect(left, top, width, height)
    End Function

    <Extension()>
    Public Sub SetDocumentInfo(ByVal pdf As C1PdfDocument, title As String)
        ' set document info
        Dim di As PdfDocumentInfo = pdf.DocumentInfo
        di.Author = Strings.DocumentAuthor
        di.Subject = Strings.DocumentSubject
        di.Title = title

        ' render footers
        ' this reopens each page and adds content to them (now we know the page count).
        Dim font As New Font("Arial", 8, PdfFontStyle.Bold)
        Dim fmt As New StringFormat()
        fmt.Alignment = HorizontalAlignment.Right
        fmt.LineAlignment = VerticalAlignment.Bottom
        Dim page As Integer = 0
        While page < pdf.Pages.Count
            pdf.CurrentPage = page
            Dim text As String = String.Format(Strings.Documentfooter, di.Title, page + 1, pdf.Pages.Count)
            pdf.DrawString(text, font, Colors.DarkGray, Inflate(pdf.PageRectangle, -72, -36), fmt)
            page += 1
        End While
    End Sub

    <Extension()>
    Public Async Sub Save(ByVal pdf As C1PdfDocument)
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add(Strings.FileTypeChoicesTip, New List(Of String)() From {
                ".pdf"
            })
        picker.DefaultFileExtension = ".pdf"
        picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Await pdf.SaveAsync(file)

            Dim dlg As New MessageDialog(Strings.SaveLocationTip + " " + file.Path, "PdfSamples")
            dlg.Commands.Add(New UICommand("Open", New UICommandInvokedHandler(Async Function(args)
                                                                                   ' to open the created file (using file extension)
                                                                                   Dim success As Boolean = Await Launcher.LaunchFileAsync(file)
                                                                                   Return New UICommand()
                                                                               End Function)))
            dlg.Commands.Add(New UICommand("Cancel"))
            dlg.CancelCommandIndex = 2
            Await dlg.ShowAsync()
        End If
    End Sub

    <Extension()>
    Public Function SaveToStream(ByVal pdf As C1PdfDocument) As MemoryStream
        Dim ms As New MemoryStream()
        pdf.Save(ms)
        ms.Seek(0, SeekOrigin.Begin)
        Return ms
    End Function

    <Extension()>
    Public Function Inflate(ByVal rc As Rect, dx As Double, dy As Double) As Rect
        rc.X -= dx
        rc.Y -= dy
        rc.Width += 2 * dx
        rc.Height += 2 * dy
        Return rc
    End Function

    <Extension()>
    Public Function Offset(ByVal rc As Rect, dx As Double, dy As Double) As Rect
        rc.X += dx
        rc.Y += dy
        Return rc
    End Function
End Module