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
Partial Public NotInheritable Class GraphicsPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf GraphicsPage_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub GraphicsPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentGraphics(pdf)
        SetDocumentInfo(pdf, Strings.GraphicsDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentGraphics(pdf As C1PdfDocument)
        ' set up to draw
        Dim rc As New Rect(50, 70, 300, 300)
        Dim text As String = Strings.DocumentGraphicsText
        Dim font As New Font("Segoe UI Light", 16, PdfFontStyle.Italic)

        ' draw to pdf document
        Dim penWidth As Integer = 0
        Dim penRGB As Byte = 0
        pdf.FillPie(Colors.DarkRed, rc, 0, 20.0F)
        pdf.FillPie(Colors.Green, rc, 20.0F, 30.0F)
        pdf.FillPie(Colors.Teal, rc, 60.0F, 12.0F)
        pdf.FillPie(Colors.Orange, rc, -80.0F, -20.0F)
        Dim startAngle As Single = 0
        While startAngle < 360
            Dim penColor As Color = Color.FromArgb(&HFF, penRGB, penRGB, penRGB)
            penWidth += 1
            Dim pen As New Pen(penColor, penWidth)
            penRGB = CType((penRGB + 20), Byte)
            pdf.DrawArc(pen, rc, startAngle, 40.0F)
            startAngle += 40
        End While
        'pdf.DrawRectangle(Colors.Red, rc);
        rc = New Rect(10, 20, 300, 50)
        pdf.DrawString(text, font, Colors.Black, rc)

        ' show a Bezier curve
        Dim pts() As Point = {New Point(400, 100), New Point(420, 30), New Point(500, 140), New Point(530, 20)}

        ' draw Bezier 
        pdf.DrawBezier(New Pen(Colors.Green, 4), pts(0), pts(1), pts(2), pts(3))

        ' show Bezier control points
        pdf.DrawLines(Colors.Gray, pts)
        For Each pt As Point In pts
            pdf.FillRectangle(Colors.Orange, pt.X - 2, pt.Y - 2, 4, 4)
        Next

        ' title
        pdf.DrawString(Strings.Bezier, font, Colors.Black, New Rect(450, 180, 100, 100))

        ' figures
        Dim clr As Color = Color.FromArgb(255, 255, 255, 0)
        penWidth += 1
        Dim linePen As New Pen(clr, penWidth)
        linePen.DashStyle = DashStyle.DashDot
        pdf.DrawLine(linePen, 120, 700, 550, 300)
        pts = New Point() {New Point(200, 400), New Point(500, 300), New Point(500, 560), New Point(370, 660), New Point(250, 600), New Point(200, 400)}
        clr = Color.FromArgb(120, 0, 255, 0)
        pdf.FillPolygon(clr, pts)
        rc = New Rect(120, 350, 300, 300)
        clr = Color.FromArgb(150, 0, 0, 255)
        pdf.FillEllipse(clr, rc)
        rc = New Rect(100, 400, 250, 250)
        clr = Color.FromArgb(100, 255, 0, 0)
        pdf.FillRectangle(clr, rc)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class