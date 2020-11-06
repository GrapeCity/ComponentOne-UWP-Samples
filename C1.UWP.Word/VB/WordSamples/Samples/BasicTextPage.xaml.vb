Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml.Word.Objects
Imports C1.Xaml.Word
Imports C1.Util
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
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class BasicTextPage
    Inherits Page
    Private word As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf BasicText_Loaded

        word = New C1WordDocument(PaperKind.Letter)
        word.Clear()
    End Sub

    Sub BasicText_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentText(word)
        WordUtils.SetDocumentInfo(word, Strings.TableOfContentsDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(word.ToRtfText())
        progressRing.IsActive = False
    End Sub

    ''' <summary>
    ''' Shows how to position and align text
    ''' </summary>
    Shared Sub CreateDocumentText(word As C1WordDocument)
        ' use landscape for more impact
        word.Landscape = True

        ' show some text 
        Dim text As String = Strings.DocumentBasicText
        Dim font As New Font("Segoe UI Light", 14, RtfFontStyle.Regular)

        ' add paragraph
        word.AddParagraph(text, font, Colors.MidnightBlue, RtfHorizontalAlignment.Justify)
        Dim paragraph As RtfParagraph = CType(word.Current, RtfParagraph)
        paragraph.LeftBorderColor = Colors.Blue
        paragraph.LeftBorderStyle = RtfBorderStyle.Emboss
        paragraph.LeftBorderWidth = 1.0F
        paragraph.TopBorderColor = Colors.Blue
        paragraph.TopBorderStyle = RtfBorderStyle.Emboss
        paragraph.TopBorderWidth = 2.0F
        paragraph.RightBorderColor = Colors.Purple
        paragraph.RightBorderStyle = RtfBorderStyle.DotDash
        paragraph.RightBorderWidth = 5.0F

        ' next show some text 
        text = Strings.DocumentBasicText2
        word.AddParagraph(text, font, Colors.Black, RtfHorizontalAlignment.Justify)
        paragraph = CType(word.Current, RtfParagraph)
        paragraph.LeftBorderColor = Colors.DeepPink
        paragraph.LeftBorderStyle = RtfBorderStyle.DashDotStroked
        paragraph.LeftBorderWidth = 4.0F
        paragraph.RightBorderColor = Colors.Chocolate
        paragraph.RightBorderStyle = RtfBorderStyle.[Single]
        paragraph.RightBorderWidth = 2.0F
        paragraph.BottomBorderColor = Colors.DarkRed
        paragraph.BottomBorderStyle = RtfBorderStyle.Dashed
        paragraph.BottomBorderWidth = 3.0F

        ' RTF/Word formats
        Dim titleFont As New Font("Segoe UI Light", 48, RtfFontStyle.Bold)
        paragraph = word.GetParagraph(String.Empty, titleFont)
        Dim rs As New RtfString("R", titleFont)
        rs.ForeColor = Colors.Red
        paragraph.Add(rs)
        rs = New RtfString("T", titleFont)
        rs.ForeColor = Colors.DarkGreen
        paragraph.Add(rs)
        rs = New RtfString("F", titleFont)
        rs.ForeColor = Colors.BlueViolet
        paragraph.Add(rs)
        rs = New RtfString(" / ", titleFont)
        rs.ForeColor = Colors.Coral
        paragraph.Add(rs)
        titleFont = New Font("Segoe UI Light", 48, RtfFontStyle.Bold Or RtfFontStyle.Italic)
        rs = New RtfString("Word", titleFont)
        rs.ForeColor = Colors.DarkSeaGreen
        paragraph.Add(rs)
        word.Add(paragraph)
        Dim tableFont As New Font("Segoe UI Light", 16, RtfFontStyle.Regular)
        word.AddParagraph(String.Empty, tableFont, Colors.Black)

        ' add table
        Dim rows As Integer = 4
        Dim cols As Integer = 3
        Dim table As New RtfTable(rows, cols)
        word.Add(table)
        table.Rows(0).Cells(0).SetMerged(1, 2)
        Dim row As Integer = 0
        While row < rows
            If row = 0 Then
                table.Rows(row).Height = 50
            End If
            Dim col As Integer = 0
            While col < cols
                If row = 0 AndAlso col = 0 Then
                    ' table header
                    text = Strings.DocumentBasicMergedCell
                    table.Rows(row).Cells(col).Alignment = ContentAlignment.MiddleCenter
                    table.Rows(row).Cells(col).BackFilling = Colors.LightPink
                Else
                    ' table cell
                    text = String.Format("table cell {0}:{1}.", row, col)
                    table.Rows(row).Cells(col).BackFilling = Colors.LightYellow
                End If
                table.Rows(row).Cells(col).Content.Add(New RtfString(text))
                table.Rows(row).Cells(col).BottomBorderWidth = 2
                table.Rows(row).Cells(col).TopBorderWidth = 2
                table.Rows(row).Cells(col).LeftBorderWidth = 2
                table.Rows(row).Cells(col).RightBorderWidth = 2
                If col = cols - 1 Then
                    table.Rows(row).Cells(col).Alignment = ContentAlignment.BottomRight
                End If
                col += 1
            End While
            row += 1
        End While
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        WordUtils.Save(word)
    End Sub
End Class