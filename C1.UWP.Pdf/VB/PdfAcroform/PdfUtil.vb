Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Collections.Generic
Imports System.Linq
Imports System.IO
Imports System
Imports C1.Xaml.Pdf

Public Class PdfUtil
    Shared _textBoxCount As Integer = 0
    Shared _checkBoxCount As Integer = 0
    Shared _radioButtonCount As Integer = 0
    Shared _comboBoxCount As Integer = 0
    Shared _listBoxCount As Integer = 0
    Shared _pushButtonCount As Integer = 0

    Public Shared Sub CreateDocument(pdf As C1PdfDocument)
        ' create pdf document
        pdf.Clear()
        pdf.Compression = CompressionLevel.NoCompression
        'pdf.FontType = PdfFontType.Standard;
        pdf.ConformanceLevel = PdfAConformanceLevel.PdfA2b
        pdf.DocumentInfo.Title = "PDF Acroform"

        ' calculate page rect (discounting margins)
        Dim rcPage As Rect = GetPageRect(pdf)
        Dim rc As Rect = rcPage

        ' add title
        Dim titleFont As New Font("Tahoma", 24, PdfFontStyle.Bold)
        rc = RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rc, False)

        ' render acroforms
        rc = rcPage
        Dim fieldFont As New Font("Arial", 14, PdfFontStyle.Regular)

        ' text box field
        rc = New Rect(rc.X, rc.Y + rc.Height / 10, rc.Width / 3, rc.Height / 30)
        Dim textBox1 As PdfTextBox = RenderTextBox(pdf, "TextBox Sample", fieldFont, rc)
        textBox1.BorderWidth = FieldBorderWidth.Thick
        textBox1.BorderStyle = FieldBorderStyle.Inset
        textBox1.BorderColor = Colors.Green
        'textBox1.BackColor = Colors.Yellow;

        ' first check box field
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderCheckBox(pdf, True, "CheckBox 1 Sample", fieldFont, rc)

        ' first radio button group
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderRadioButton(pdf, False, "RadioGroup1", "RadioButton 1 Sample Group 1", fieldFont, rc)
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderRadioButton(pdf, True, "RadioGroup1", "RadioButton 2 Sample Group 1", fieldFont, rc)
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderRadioButton(pdf, False, "RadioGroup1", "RadioButton 3 Sample Group 1", fieldFont, rc)

        ' second check box field
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderCheckBox(pdf, False, "CheckBox 2 Sample", fieldFont, rc)

        ' second radio button group
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderRadioButton(pdf, True, "RadioGroup2", "RadioButton 1 Sample Group 2", fieldFont, rc)
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        RenderRadioButton(pdf, False, "RadioGroup2", "RadioButton 2 Sample Group 2", fieldFont, rc)

        ' first combo box field
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, rc.Height)
        Dim comboBox1 As PdfComboBox = RenderComboBox(pdf, New String() {"First", "Second", "Third"}, 2, fieldFont, rc)

        ' first list box field
        Dim rclb As New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, 3 * rc.Height)
        RenderListBox(pdf, New String() {"First", "Second", "Third", "Fourth", "Fifth"}, 5, fieldFont, rclb)

        ' load first icon
        Dim icon As Image = Nothing
        'using (Stream stream = GetManifestResource("phoenix.png"))
        '{
        '    icon = Image.FromStream(stream);
        '}

        ' first push putton field
        rc = New Rect(rc.X, rc.Y + 6 * rc.Height, rc.Width, rc.Height)
        Dim button1 As PdfPushButton = RenderPushButton(pdf, "Submit", fieldFont, rc, icon, ButtonLayout.ImageLeftTextRight)
        button1.Actions.Released.Add(New PdfPushButton.Action(ButtonAction.CallMenu, "FullScreen"))
        button1.Actions.GotFocus.Add(New PdfPushButton.Action(ButtonAction.OpenFile, "..\..\Program.cs"))
        button1.Actions.LostFocus.Add(New PdfPushButton.Action(ButtonAction.GotoPage, "2"))
        button1.Actions.Released.Add(New PdfPushButton.Action(ButtonAction.OpenUrl, "https://developer.mescius.com/componentone"))

        '''/ load second icon
        'using (Stream stream = GetManifestResource("download.png"))
        '{
        '    icon = Image.FromStream(stream);
        '}

        ' second push putton field
        rc = New Rect(rc.X, rc.Y + 2 * rc.Height, rc.Width, 2 * rc.Height)
        Dim button2 As PdfPushButton = RenderPushButton(pdf, "Cancel", fieldFont, rc, icon, ButtonLayout.TextTopImageBottom)
        button2.Actions.Pressed.Add(New PdfPushButton.Action(ButtonAction.ClearFields))
        button2.Actions.Released.Add(New PdfPushButton.Action(ButtonAction.CallMenu, "Quit"))

        '''/ load second icon
        'using (Stream stream = GetManifestResource("top100.png"))
        '{
        '    icon = Image.FromStream(stream);
        '}

        ' push putton only icon field
        rc = New Rect(rc.X + 1.5F * rc.Width, rc.Y, rc.Width / 2, rc.Height)
        Dim button3 As PdfPushButton = RenderPushButton(pdf, "", fieldFont, rc, icon, ButtonLayout.ImageOnly)
        button3.Actions.MouseEnter.Add(New PdfPushButton.Action(ButtonAction.HideField, button1.Name))
        button3.Actions.MouseLeave.Add(New PdfPushButton.Action(ButtonAction.ShowField, button1.Name))
        button3.Actions.Released.Add(New PdfPushButton.Action(ButtonAction.CallMenu, "ShowGrid"))
        button3.BorderWidth = FieldBorderWidth.Medium
        button3.BorderStyle = FieldBorderStyle.Beveled
        button3.BorderColor = Colors.Gray

        ' next page
        pdf.NewPage()

        ' text for next page
        rc = rcPage
        RenderParagraph(pdf, "Second page as bookmark", titleFont, rcPage, rc, False)

        ' text box field
        'rc = rcPage;
        'rc = new Rect(rc.X, rc.Y + rc.Height / 10, rc.Width / 3, rc.Height / 30);
        'PdfTextBox textBox2 = RenderTextBox("TextSample 2", fieldFont, rc, Color.Yellow, "In 2 page");

        ' second pass to number pages
        AddFooters(pdf)
    End Sub


    ' get the current page rectangle (depends on paper size)
    ' and apply a 1" margin all around it.
    Public Shared Function GetPageRect(pdf As C1PdfDocument) As Rect
        Dim rcPage As Rect = pdf.PageRectangle
        rcPage = New Rect(rcPage.Left + 72, rcPage.Top + 72, rcPage.Width - 144, rcPage.Height - 144)
        'rcPage.Inflate(-72, -72);
        Return rcPage
    End Function

    ' add text box field for fields of the PDF document
    ' with common parameters and default names.
    ' 
    Shared Function RenderTextBox(pdf As C1PdfDocument, text As String, font As Font, rc As Rect, back As Color, toolTip As String) As PdfTextBox
        ' create
        Dim name As String = String.Format("ACFTB{0}", _textBoxCount + 1)
        Dim textBox As New PdfTextBox()

        ' default border
        'textBox.BorderWidth = 3f / 4;
        textBox.BorderStyle = FieldBorderStyle.Solid
        textBox.BorderColor = Colors.DarkGray

        ' parameters
        textBox.Font = font
        textBox.Name = name
        textBox.DefaultText = text
        textBox.Text = text
        textBox.ToolTip = If(String.IsNullOrEmpty(toolTip), String.Format("{0} ({1})", text, name), toolTip)
        If back <> Colors.Transparent Then
            textBox.BackColor = back
        End If

        ' add
        pdf.AddField(textBox, rc)
        _textBoxCount += 1

        ' done
        Return textBox
    End Function
    Public Shared Function RenderTextBox(pdf As C1PdfDocument, text As String, font As Font, rc As Rect, back As Color) As PdfTextBox
        Return RenderTextBox(pdf, text, font, rc, back, Nothing)
    End Function
    Shared Function RenderTextBox(pdf As C1PdfDocument, text As String, font As Font, rc As Rect) As PdfTextBox
        Return RenderTextBox(pdf, text, font, rc, Colors.Transparent, Nothing)
    End Function

    ' add check box field for fields of the PDF document
    ' with common parameters and default names.
    ' 
    Shared Function RenderCheckBox(pdf As C1PdfDocument, value As Boolean, text As String, font As Font, rc As Rect, back As Color,
        toolTip As String) As PdfCheckBox
        ' create
        Dim name As String = String.Format("ACFCB{0}", _checkBoxCount + 1)
        Dim checkBox As New PdfCheckBox()

        ' default border
        checkBox.BorderWidth = FieldBorderWidth.Thin
        checkBox.BorderStyle = FieldBorderStyle.Solid
        checkBox.BorderColor = Colors.DarkGray

        ' parameters
        checkBox.Name = name
        checkBox.DefaultValue = value
        checkBox.Value = value
        checkBox.ToolTip = If(String.IsNullOrEmpty(toolTip), String.Format("{0} ({1})", text, name), toolTip)
        If back <> Colors.Transparent Then
            checkBox.BackColor = back
        End If

        ' add
        Dim checkBoxSize As Object = font.Size
        Dim checkBoxTop As Object = rc.Top + (rc.Height - checkBoxSize) / 2
        pdf.AddField(checkBox, New Rect(rc.Left, checkBoxTop, checkBoxSize, checkBoxSize))
        _checkBoxCount += 1

        ' text for check box field
        Dim x As Object = rc.Left + checkBoxSize + 1.0F
        Dim y As Object = rc.Top + (rc.Height - checkBoxSize - 1.0F) / 2
        pdf.DrawString(text, New Font(font.Name, checkBoxSize, font.Style), Colors.Black, New Point(x, y))

        ' done
        Return checkBox
    End Function
    Public Shared Function RenderCheckBox(pdf As C1PdfDocument, value As Boolean, text As String, font As Font, rc As Rect, back As Color) As PdfCheckBox
        Return RenderCheckBox(pdf, value, text, font, rc, back,
            Nothing)
    End Function
    Public Shared Function RenderCheckBox(pdf As C1PdfDocument, value As Boolean, text As String, font As Font, rc As Rect) As PdfCheckBox
        Return RenderCheckBox(pdf, value, text, font, rc, Colors.Transparent,
            Nothing)
    End Function

    ' add radio button box field for fields of the PDF document
    ' with common parameters and default names.
    ' 
    Public Shared Function RenderRadioButton(pdf As C1PdfDocument, value As Boolean, group As String, text As String, font As Font, rc As Rect,
        back As Color, toolTip As String) As PdfRadioButton
        ' create
        Dim name As String = If(String.IsNullOrEmpty(group), "ACFRGR", group)
        Dim radioButton As New PdfRadioButton()

        ' parameters
        radioButton.Name = name
        radioButton.DefaultValue = value
        radioButton.Value = value
        radioButton.ToolTip = If(String.IsNullOrEmpty(toolTip), String.Format("{0} ({1})", text, name), toolTip)
        If back <> Colors.Transparent Then
            radioButton.BackColor = back
        End If

        ' add
        Dim radioSize As Object = font.Size
        Dim radioTop As Object = rc.Top + (rc.Height - radioSize) / 2
        pdf.AddField(radioButton, New Rect(rc.Left, radioTop, radioSize, radioSize))
        _radioButtonCount += 1

        ' text for radio button field
        Dim x As Object = rc.Left + radioSize + 1.0F
        Dim y As Object = rc.Top + (rc.Height - radioSize - 1.0F) / 2
        pdf.DrawString(text, New Font(font.Name, radioSize, font.Style), Colors.Black, New Point(x, y))

        ' done
        Return radioButton
    End Function
    Public Shared Function RenderRadioButton(pdf As C1PdfDocument, value As Boolean, group As String, text As String, font As Font, rc As Rect,
        back As Color) As PdfRadioButton
        Return RenderRadioButton(pdf, value, group, text, font, rc,
            back, Nothing)
    End Function
    Public Shared Function RenderRadioButton(pdf As C1PdfDocument, value As Boolean, group As String, text As String, font As Font, rc As Rect) As PdfRadioButton
        Return RenderRadioButton(pdf, value, group, text, font, rc,
            Colors.Transparent, Nothing)
    End Function

    ' add combo box field for fields of the PDF document
    ' with common parameters and default names.
    ' 
    Public Shared Function RenderComboBox(pdf As C1PdfDocument, list As String(), activeIndex As Integer, font As Font, rc As Rect, back As Color,
        toolTip As String) As PdfComboBox
        ' create
        Dim name As String = String.Format("ACFCLB{0}", _comboBoxCount + 1)
        Dim comboBox As New PdfComboBox()

        ' default border
        comboBox.BorderWidth = FieldBorderWidth.Thin
        comboBox.BorderStyle = FieldBorderStyle.Solid
        comboBox.BorderColor = Colors.DarkGray

        ' array
        For Each text As String In list
            comboBox.Items.Add(text)
        Next

        ' parameters
        comboBox.Font = font
        comboBox.Name = name
        comboBox.DefaultValue = activeIndex
        comboBox.Value = activeIndex
        comboBox.ToolTip = If(String.IsNullOrEmpty(toolTip), String.Format("{0} ({1})", String.Format("Count = {0}", comboBox.Items.Count), name), toolTip)
        If back <> Colors.Transparent Then
            comboBox.BackColor = back
        End If

        ' add
        pdf.AddField(comboBox, rc)
        _comboBoxCount += 1

        ' done
        Return comboBox
    End Function
    Public Shared Function RenderComboBox(pdf As C1PdfDocument, list As String(), activeIndex As Integer, font As Font, rc As Rect, back As Color) As PdfComboBox
        Return RenderComboBox(pdf, list, activeIndex, font, rc, back,
            Nothing)
    End Function
    Public Shared Function RenderComboBox(pdf As C1PdfDocument, list As String(), activeIndex As Integer, font As Font, rc As Rect) As PdfComboBox
        Return RenderComboBox(pdf, list, activeIndex, font, rc, Colors.Transparent,
            Nothing)
    End Function

    ' add list box field for fields of the PDF document
    ' with common parameters and default names.
    ' 
    Shared Function RenderListBox(pdf As C1PdfDocument, list As String(), activeIndex As Integer, font As Font, rc As Rect, back As Color,
        toolTip As String) As PdfListBox
        ' create
        Dim name As String = String.Format("ACFLB{0}", _listBoxCount + 1)
        Dim listBox As New PdfListBox()

        ' default border
        listBox.BorderWidth = FieldBorderWidth.Thin
        listBox.BorderStyle = FieldBorderStyle.Solid
        listBox.BorderColor = Colors.DarkGray

        ' array
        For Each text As String In list
            listBox.Items.Add(text)
        Next

        ' parameters
        listBox.Font = font
        listBox.Name = name
        listBox.DefaultValue = activeIndex
        listBox.Value = activeIndex
        listBox.ToolTip = If(String.IsNullOrEmpty(toolTip), String.Format("{0} ({1})", String.Format("Count = {0}", listBox.Items.Count), name), toolTip)
        If back <> Colors.Transparent Then
            listBox.BackColor = back
        End If

        ' add
        pdf.AddField(listBox, rc)
        _listBoxCount += 1

        ' done
        Return listBox
    End Function
    Public Shared Function RenderListBox(pdf As C1PdfDocument, list As String(), activeIndex As Integer, font As Font, rc As Rect, back As Color) As PdfListBox
        Return RenderListBox(pdf, list, activeIndex, font, rc, back,
            Nothing)
    End Function
    Public Shared Function RenderListBox(pdf As C1PdfDocument, list As String(), activeIndex As Integer, font As Font, rc As Rect) As PdfListBox
        Return RenderListBox(pdf, list, activeIndex, font, rc, Colors.Transparent,
            Nothing)
    End Function

    ' add push button box field for fields of the PDF document
    ' with common parameters and default names.
    ' 
    Public Shared Function RenderPushButton(pdf As C1PdfDocument, text As String, font As Font, rc As Rect, back As Color, fore As Color,
        toolTip As String, image As Image, layout As ButtonLayout) As PdfPushButton
        ' create
        Dim name As String = String.Format("ACFPB{0}", _pushButtonCount + 1)
        Dim pushButton As New PdfPushButton()

        ' parameters
        pushButton.Name = name
        pushButton.DefaultValue = text
        pushButton.Value = text
        pushButton.Font = font
        pushButton.ToolTip = If(String.IsNullOrEmpty(toolTip), String.Format("{0} ({1})", text, name), toolTip)
        If back <> Colors.Transparent Then
            pushButton.BackColor = back
        End If
        If fore <> Colors.Transparent Then
            pushButton.ForeColor = fore
        End If

        ' icon
        '    pushButton.Image = image;
        '    pushButton.Layout = layout;
        If image IsNot Nothing Then
        End If

        ' add
        pdf.AddField(pushButton, rc)
        _pushButtonCount += 1

        ' done
        Return pushButton
    End Function
    Public Shared Function RenderPushButton(pdf As C1PdfDocument, text As String, font As Font, rc As Rect, back As Color) As PdfPushButton
        Return RenderPushButton(pdf, text, font, rc, back, Colors.Transparent,
            Nothing, Nothing, ButtonLayout.TextOnly)
    End Function
    Public Shared Function RenderPushButton(pdf As C1PdfDocument, text As String, font As Font, rc As Rect) As PdfPushButton
        Return RenderPushButton(pdf, text, font, rc, Colors.Transparent, Colors.Transparent,
            Nothing, Nothing, ButtonLayout.TextOnly)
    End Function
    Public Shared Function RenderPushButton(pdf As C1PdfDocument, text As String, font As Font, rc As Rect, icon As Image, layout As ButtonLayout) As PdfPushButton
        Return RenderPushButton(pdf, text, font, rc, Colors.Transparent, Colors.Transparent,
            Nothing, icon, layout)
    End Function
    Public Shared Function RenderPushButton(pdf As C1PdfDocument, font As Font, rc As Rect, back As Color, image As Image) As PdfPushButton
        Return RenderPushButton(pdf, String.Empty, font, rc, back, Colors.Transparent,
            Nothing, image, ButtonLayout.ImageOnly)
    End Function

    ' measure a paragraph, skip a page if it won't fit, render it into a rectangle,
    ' and update the rectangle for the next paragraph.
    ' 
    ' optionally mark the paragraph as an outline entry and as a link target.
    '
    ' this routine will not break a paragraph across pages. for that, see the Text Flow sample.
    '
    Public Shared Function RenderParagraph(pdf As C1PdfDocument, text As String, font As Font, rcPage As Rect, rc As Rect, outline As Boolean,
        linkTarget As Boolean) As Rect
        ' if it won't fit this page, do a page break
        rc.Height = pdf.MeasureString(text, font, rc.Width).Height
        If rc.Bottom > rcPage.Bottom Then
            pdf.NewPage()
            rc.Y = rcPage.Top
        End If

        ' draw the string
        pdf.DrawString(text, font, Colors.Black, rc)

        ' show bounds (mainly to check word wrapping)
        'pdf.DrawRectangle(Pens.Sienna, rc);

        ' add headings to outline
        If outline Then
            pdf.DrawLine(New Pen(Colors.Black), rc.X, rc.Y, rc.Right, rc.Y)
            pdf.AddBookmark(text, 0, rc.Y)
        End If

        ' add link target
        If linkTarget Then
            pdf.AddTarget(text, rc)
        End If

        ' update rectangle for next time
        rc.Y += rc.Height
        'rc.Offset(0, rc.Height);
        Return rc
    End Function
    Public Shared Function RenderParagraph(pdf As C1PdfDocument, text As String, font As Font, rcPage As Rect, rc As Rect, outline As Boolean) As Rect
        Return RenderParagraph(pdf, text, font, rcPage, rc, outline,
            False)
    End Function
    Public Shared Function RenderParagraph(pdf As C1PdfDocument, text As String, font As Font, rcPage As Rect, rc As Rect) As Rect
        Return RenderParagraph(pdf, text, font, rcPage, rc, False,
            False)
    End Function

    '================================================================================
    ' add page footers to a document
    '
    ' this method is called by all samples in this project. it scans the document
    ' and adds a 'page n of m' footer to each page. the footers are rendered as 
    ' vertical text along the right edge of the document.
    '
    ' adding content to an existing page is easy: just set the CurrentPage property
    ' to point to an existing page and write into it as usual.
    '
    Public Shared Sub AddFooters(pdf As C1PdfDocument)
        Dim fontHorz As New Font("Tahoma", 7, PdfFontStyle.Bold)
        Dim fontVert As New Font("Viner Hand ITC", 14, PdfFontStyle.Bold)

        Dim sfRight As New StringFormat()
        sfRight.Alignment = HorizontalAlignment.Right

        Dim sfVert As New StringFormat()
        sfVert.FormatFlags = sfVert.FormatFlags Or StringFormatFlags.DirectionVertical
        sfVert.Alignment = HorizontalAlignment.Center

        Dim page As Integer = 0
        While page < pdf.Pages.Count
            ' select page we want (could change PageSize)
            pdf.CurrentPage = page

            ' build rectangles for rendering text
            Dim rcPage As Rect = GetPageRect(pdf)
            Dim rcFooter As Rect = rcPage
            rcFooter.Y = rcFooter.Bottom + 6
            rcFooter.Height = 12
            Dim rcVert As Rect = rcPage
            rcVert.X = rcPage.Right + 6

            ' add left-aligned footer
            Dim text As String = pdf.DocumentInfo.Title
            pdf.DrawString(text, fontHorz, Colors.Gray, rcFooter)

            ' add right-aligned footer
            text = String.Format("Page {0} of {1}", page + 1, pdf.Pages.Count)
            pdf.DrawString(text, fontHorz, Colors.Gray, rcFooter, sfRight)

            ' add vertical text
            text = pdf.DocumentInfo.Title + " (document created using the C1Pdf .UWP component)"
            pdf.DrawString(text, fontVert, Colors.LightGray, rcVert, sfVert)

            ' draw lines on bottom and right of the page
            Dim pen As New Pen(Colors.Gray, 1.0)
            pdf.DrawLine(pen, rcPage.Left, rcPage.Bottom, rcPage.Right, rcPage.Bottom)
            pdf.DrawLine(pen, rcPage.Right, rcPage.Top, rcPage.Right, rcPage.Bottom)
            page += 1
        End While
    End Sub

    '<System.Runtime.CompilerServices.Extension>
    Public Shared Function SaveToStream(pdf As C1PdfDocument) As MemoryStream
        Dim ms As New MemoryStream()
        pdf.Save(ms)
        ms.Seek(0, SeekOrigin.Begin)
        Return ms
    End Function
End Class
