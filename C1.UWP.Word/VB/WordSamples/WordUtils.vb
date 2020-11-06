Imports C1.Xaml.Word.Objects
Imports C1.Xaml.Word
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.UI
Imports Windows.Storage.Streams
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Foundation
Imports Windows.System
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Module WordUtils

    <Extension()>
    Public Function RenderParagraph(ByVal doc As C1WordDocument, text As String, font As Font, rcPage As Rect, rc As Rect, outline As Boolean, linkTarget As Boolean) As Rect
        ' if it won't fit this page, do a page break
        rc.Height = doc.MeasureString(text, font, rc.Width).Height
        If rc.Bottom > rcPage.Bottom Then
            doc.PageBreak()
            rc.Y = rcPage.Top
        End If

        ' draw the string
        doc.DrawString(text, font, Colors.Black, rc)

        ' add headings to outline
        If outline Then
            doc.DrawLine(Colors.Black, rc.X, rc.Y, rc.Right, rc.Y)
        End If

        If linkTarget Then
        End If

        ' update rectangle for next time
        rc = Offset(rc, 0, rc.Height)
        Return rc
    End Function

    <Extension()>
    Public Function RenderParagraph(ByVal doc As C1WordDocument, text As String, font As Font, rcPage As Rect, rc As Rect, outline As Boolean) As Rect
        Return RenderParagraph(doc, text, font, rcPage, rc, outline, False)
    End Function

    <Extension()>
    Public Function RenderParagraph(ByVal doc As C1WordDocument, text As String, font As Font, rcPage As Rect, rc As Rect) As Rect
        Return RenderParagraph(doc, text, font, rcPage, rc, False, False)
    End Function

    Dim _pageCurrent As Integer = 1

    <Extension()>
    Public Function CurrentPage(ByVal doc As C1WordDocument) As Integer
        Return _pageCurrent
    End Function
    <Extension()>
    Public Function CurrentPage(ByVal doc As C1WordDocument, page As Integer) As Integer
        _pageCount = Math.Max(_pageCount, page)
        _pageCurrent = page
        Return _pageCurrent
    End Function
    Dim _pageCount As Integer = 1
    <Extension()>
    Public Function PageCount(ByVal doc As C1WordDocument) As Integer
        Return _pageCount
    End Function

    <Extension()>
    Public Function PageRectangle(ByVal doc As C1WordDocument) As Rect
        Return PageRectangle(doc, New Thickness(doc.LeftMargin, doc.TopMargin, doc.RightMargin, doc.BottomMargin))
    End Function
    <Extension()>
    Public Function PageRectangle(ByVal doc As C1WordDocument, pageMargins As Thickness) As Rect
        Dim sz As Size = doc.PageSize
        Dim left As Double = Math.Min(sz.Width, pageMargins.Left)
        Dim top As Double = Math.Min(sz.Height, pageMargins.Top)
        Dim width As Double = Math.Max(0, sz.Width - (pageMargins.Left + pageMargins.Right))
        Dim height As Double = Math.Max(0, sz.Height - (pageMargins.Top + pageMargins.Bottom))
        Return New Rect(left, top, width, height)
    End Function

    <Extension()>
    Public Sub SetDocumentInfo(ByVal doc As C1WordDocument, title As String, Optional graphicFooter As Boolean = False)
        ' set document info
        Dim di As IC1WordInfo = doc.Info
        di.Author = Strings.DocumentAuthor
        di.Subject = Strings.DocumentSubject
        di.Title = title

        ' footer font
        Dim font As New Font("Arial", 8, RtfFontStyle.Bold)
        Dim fmt As New StringFormat()
        fmt.Alignment = HorizontalAlignment.Right
        fmt.LineAlignment = VerticalAlignment.Bottom

        ' render footers
        If graphicFooter Then
            ' this reopens each page and adds content to them (now we know the page count).
            Dim page As Integer = 0
            While page < doc.PageCount()
                doc.CurrentPage(page)
                Dim text As String = String.Format(Strings.Documentfooter, di.Title, page + 1, doc.PageCount())
                doc.DrawString(text, font, Colors.DarkGray, WordUtils.Inflate(doc.PageRectangle(), -72, -36), fmt)
                page += 1
            End While
        Else
            ' standard footer
            Dim text As String = String.Format(Strings.Documentfooter, di.Title, "|", "|")
            Dim paragraph As New RtfParagraph(doc.CurrentSection.Footer)
            paragraph.Alignment = RtfHorizontalAlignment.Right
            Dim count As Integer = 0
            For Each part As String In text.Split("|"c)
                If Not String.IsNullOrEmpty(part) Then
                    paragraph.Add(New RtfString(part))
                End If
                Select Case count
                    Case 0
                        paragraph.Add(New RtfPageField())
                        Exit Select
                    Case 1
                        paragraph.Add(New RtfNumPagesField())
                        Exit Select
                End Select
                count += 1
            Next
            doc.CurrentSection.Footer.Add(paragraph)
        End If
    End Sub

    <Extension()>
    Public Async Sub Save(ByVal doc As C1WordDocument)
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add(Strings.FileTypeChoicesTip, New List(Of String)() From {".docx"})
        picker.FileTypeChoices.Add(Strings.AlternateFileTypeChoicesTip, New List(Of String)() From {".rtf"})
        picker.DefaultFileExtension = ".docx"
        picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Await doc.SaveAsync(file, If(file.Name.ToLower().EndsWith(".rtf"), FileFormat.Rtf, FileFormat.OpenXml))
            Dim dlg As New MessageDialog(Strings.SaveLocationTip + " " + file.Path, "WordSamples")
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
    Public Async Function SaveToStream(ByVal doc As C1WordDocument) As Task(Of MemoryStream)
        Dim ms As New MemoryStream()
        Using imas As New InMemoryRandomAccessStream()
            Await doc.SaveAsync(imas.AsStream(), FileFormat.OpenXml)
        End Using
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