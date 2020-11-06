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
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

#Const WITHOUT_GRAPHICS = True

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class TOCPage
    Inherits Page
    Private _doc As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf TOCPage_Loaded

        _doc = New C1WordDocument(PaperKind.Letter)
        _doc.Clear()
    End Sub

    Sub TOCPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentTOC(_doc)
        WordUtils.SetDocumentInfo(_doc, Strings.TableOfContentsDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(_doc.ToRtfText())
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentTOC(doc As C1WordDocument)
        ' calculate page rect (discounting margins)
        Dim rcPage As Rect = WordUtils.PageRectangle(doc)
        Dim height As Double = rcPage.Top

        ' initialize fonts
        Dim titleFont As New Font("Tahoma", 20, RtfFontStyle.Bold)
        Dim headerFont As New Font("Arial", 14, RtfFontStyle.Bold)
        Dim bodyFont As New Font("Times New Roman", 11)

        ' add title
        doc.AddParagraph(Strings.TableOfContentsDocumentTitle, titleFont, Colors.DeepPink, RtfHorizontalAlignment.Center)
        doc.AddParagraph(String.Empty)

        ' create context of the document
        Dim pageIndex As Integer = 2
        Dim data As New List(Of List(Of String))()
        Dim i As Integer = 0
        While i < 30
            ' iniialization data
            Dim list As New List(Of String)()
            data.Add(list)

            ' create it header (as a link target and outline entry)
            Dim header As String = String.Format("{0}. {1}", i + 1, BuildRandomTitle())
            Dim h As Double = 2 * doc.MeasureString(header, headerFont, rcPage.Width).Height

            ' create some text
            Dim j As Integer = 0
            While j < 3 + _rnd.[Next](20)
                ' some paragraph
                Dim text As String = BuildRandomParagraph()
                Dim sf As New StringFormat()
                sf.Alignment = HorizontalAlignment.Stretch
                h += doc.MeasureString(text, bodyFont, rcPage.Width, sf).Height
                h += 6

                ' test next page
                If height + h > rcPage.Bottom Then
                    pageIndex += 1
                    height = rcPage.Top
                End If
                height += h
                h = 0

                ' page index for header
                If j = 0 Then
                    list.Add(pageIndex.ToString())
                    list.Add(header.ToString())
                End If

                ' page index for paragraph
                list.Add(pageIndex.ToString())
                list.Add(text.ToString())
                j += 1
            End While

            ' last line
            height += 20
            i += 1
        End While

        ' render Table of Contents
        Dim table As New RtfTable(data.Count, 2)
        doc.Add(table)
        Dim row As Integer = 0
        While row < data.Count
            ' get bookmark info
            Dim list As List(Of String) = data(row)
            Dim page As String = list(0)
            Dim header As String = list(1)

            ' add cells
            table.Rows(row).Cells(0).Content.Add(New RtfString(header))
            'var hlink = new RtfHyperlink(string.Format("hdr{0}", 1 + row));
            'hlink.Content.Add(new RtfString(page));
            'table.Rows[row].Cells[1].Content.Add(hlink);
            table.Rows(row).Cells(1).Content.Add(New RtfString(page))

            ' set attributes
            table.Rows(row).Cells(0).Alignment = ContentAlignment.BottomLeft
            table.Rows(row).Cells(1).Alignment = ContentAlignment.BottomRight
            table.Rows(row).BottomBorderWidth = 1
            table.Rows(row).BottomBorderStyle = RtfBorderStyle.Dotted
            row += 1
        End While

        ' next page
        doc.PageBreak()
        pageIndex = 1

        ' render contents

        For Each list As List(Of String) In data
            i = 0
            While i < list.Count
                Dim page As Integer = Integer.Parse(list(i))
                If page <> pageIndex Then
                    doc.PageBreak()
                    pageIndex = page
                End If
                Dim text As String = list(i + 1)
                If i = 0 Then
                    ' header
                    'doc.AddBookmark(string.Format("hdr{0}", 1 + data.IndexOf(list)));
                    doc.AddParagraph(text, headerFont, Colors.DarkGray, RtfHorizontalAlignment.Center)
                    Dim paragraph As RtfParagraph = CType(doc.Current, RtfParagraph)
                    paragraph.TopBorderColor = Colors.DarkGray
                    paragraph.TopBorderStyle = RtfBorderStyle.[Single]
                    paragraph.TopBorderWidth = 1.0F
                    doc.AddParagraph(String.Empty, bodyFont, Colors.Black)
                Else
                    ' context
                    doc.AddParagraph(text, bodyFont, Colors.Black, RtfHorizontalAlignment.Justify)
                End If
                i += 2
            End While
            doc.AddParagraph(String.Empty, bodyFont, Colors.Black)
        Next
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
        WordUtils.Save(_doc)
    End Sub
End Class