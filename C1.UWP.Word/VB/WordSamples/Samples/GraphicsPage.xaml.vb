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
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class GraphicsPage
    Inherits Page
    Private word As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf GraphicsPage_Loaded

        word = New C1WordDocument(PaperKind.Letter)
        word.Clear()
    End Sub

    Sub GraphicsPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentGraphics(word)
        WordUtils.SetDocumentInfo(word, Strings.GraphicsDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(word.ToRtfText())
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentGraphics(word As C1WordDocument)
        ' set up to draw
        word.Landscape = True
        Dim rc As New Rect(0, 100, 300, 300)
        Dim text As String = Strings.DocumentGraphicsText
        Dim font As New Font("Segoe UI Light", 16, RtfFontStyle.Italic)

        ' add warning paragraph
        word.AddParagraph(Strings.GraphicsWarning, font, Colors.DarkGray, RtfHorizontalAlignment.Left)
        Dim paragraph As RtfParagraph = CType(word.Current, RtfParagraph)
        paragraph.BottomBorderColor = Colors.Red
        paragraph.BottomBorderStyle = RtfBorderStyle.Dotted
        paragraph.BottomBorderWidth = 1.0F
        word.AddParagraph(String.Empty)

        ' draw to word document
        Dim penWidth As Integer = 0
        Dim penRGB As Byte = 0
        word.FillPie(Colors.DarkRed, rc, 0, 20.0F)
        word.FillPie(Colors.Green, rc, 20.0F, 30.0F)
        word.FillPie(Colors.Teal, rc, 60.0F, 12.0F)
        word.FillPie(Colors.Orange, rc, -80.0F, -20.0F)
        Dim startAngle As Single = 0
        While startAngle < 360
            Dim penColor As Color = Color.FromArgb(&HFF, penRGB, penRGB, penRGB)
            penWidth += 1
            Dim pen As New Pen(penColor, penWidth)
            penRGB = CType((penRGB + 20), Byte)
            word.DrawArc(pen, rc, startAngle, 40.0F)
            startAngle += 40
        End While
        word.DrawRectangle(Colors.Red, rc)
        word.DrawString(text, font, Colors.Black, rc)

        ' show a Bezier curve
        Dim pts() As Point = {New Point(400, 100), New Point(420, 30), New Point(500, 140), New Point(530, 20)}

        ' draw Bezier 
        word.DrawBeziers(New Pen(Colors.Green, 4), pts)

        ' show Bezier control points
        word.DrawPolyline(Colors.Gray, pts)
        For Each pt As Point In pts
            word.FillRectangle(Colors.Orange, pt.X - 2, pt.Y - 2, 4, 4)
        Next

        ' title
        word.DrawString(Strings.Bezier, font, Colors.Black, New Rect(500, 150, 100, 100))
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        WordUtils.Save(word)
    End Sub
End Class