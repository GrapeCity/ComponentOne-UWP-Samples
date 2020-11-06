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
Imports C1.Xaml.Pdf

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class BasicTextPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf BasicText_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub BasicText_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentText(pdf)

        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    ''' <summary>
    ''' Shows how to position and align text
    ''' </summary>
    Shared Sub CreateDocumentText(pdf As C1PdfDocument)
        ' use landscape for more impact
        pdf.Landscape = True

        ' measure and show some text 
        Dim text As String = Strings.DocumentBasicText
        Dim font As New Font("Segoe UI Light", 12, PdfFontStyle.Italic)

        ' create StringFormat used to set text alignment and line spacing
        Dim fmt As New StringFormat()
        fmt.LineSpacing = -1.5
        ' 1.5 char height
        fmt.Alignment = HorizontalAlignment.Center

        ' measure it
        Dim sz As Size = pdf.MeasureString(text, font, 72 * 3, fmt)
        Dim rc As New Rect(pdf.PageRectangle.Width / 2, 72, sz.Width, sz.Height)
        rc = Offset(rc, 110, 0)

        ' draw a rounded frame
        rc = rc.Inflate(0, 0)
        pdf.FillRectangle(Colors.Teal, rc, New Size(0, 0))
        'pdf.DrawRectangle(new Pen(Colors.DarkGray, 5), rc, new Size(0, 0));
        rc = rc.Inflate(-10, -10)

        ' draw the text
        pdf.DrawString(text, font, Colors.White, rc, fmt)

        ' point in center for rotate the text
        rc = pdf.PageRectangle
        Dim pt As Point = New Point(rc.X + rc.Width / 2, rc.Y + rc.Height / 2)

        ' rotate the string in small increments
        Dim [step] As Integer = 6
        text = Strings.DocumentBasicText2
        Dim i As Integer = 0
        While i <= 360
            pdf.RotateAngle = i
            Dim s As String = String.Format(text, i)
            font = New Font("Courier New", 8 + i / 30.0, PdfFontStyle.Bold)
            Dim b As Byte = CType((255 * (1 - i / 360.0)), Byte)
            pdf.DrawString(s, font, Color.FromArgb(&HFF, b, b, b), pt)
            i += [step]
        End While
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class