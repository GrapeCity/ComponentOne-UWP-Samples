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
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

#Const WITHOUT_GRAPHICS = True

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class TextFlowPage
    Inherits Page
    Private _doc As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf TextFlowPage_Loaded

        _doc = New C1WordDocument(PaperKind.Letter)
        _doc.Clear()
    End Sub

    Sub TextFlowPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        CreateDocumentTextFlow(_doc)
        WordUtils.SetDocumentInfo(_doc, Strings.TextFlowDocumentTitle)
        c1RichTextBox1.Document = New RtfFilter().ConvertToDocument(_doc.ToRtfText())
        progressRing.IsActive = False
    End Sub

    Shared Sub CreateDocumentTextFlow(word As C1WordDocument)
        ' load long string from resource file
        Dim text As String = Strings.ResourceNotFound

        Using sr As New StreamReader(GetType(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("WordSamples.flow.txt"))
            text = sr.ReadToEnd()
        End Using

        ' content rectangle
        Dim rcPage As Rect = WordUtils.PageRectangle(word)

        ' create two columns for the text
        Dim columnWidth As Single = CType((rcPage.Width - 30), Single) / 2
        word.MainSection.Columns.Clear()
        word.MainSection.Columns.Add(New RtfColumn(columnWidth))
        word.MainSection.Columns.Add(New RtfColumn(columnWidth))

        ' add title
        Dim titleFont As New Font("Tahoma", 14, RtfFontStyle.Bold)
        Dim bodyFont As New Font("Tahoma", 11)
        word.AddParagraph(Strings.MsWordFormats, titleFont, Colors.DarkOliveGreen, RtfHorizontalAlignment.Center)
        word.AddParagraph(String.Empty)

        ' first paragraph about C1Word object model
        Dim paragraph As RtfParagraph = word.GetParagraph(String.Empty, bodyFont)
        Dim hyperlink As New RtfHyperlink(Strings.WordSamplesWordLink, Colors.Blue, RtfUnderlineStyle.[Single])
        hyperlink.Add(New RtfString(Strings.WordSamplesWordTitle))
        paragraph.Add(hyperlink)
        word.Add(paragraph)
        word.AddParagraph(String.Empty)

        ' render string spanning columns and pages
        For Each part As String In text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
            word.AddParagraph(part, bodyFont, Colors.Black, RtfHorizontalAlignment.Justify)
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        WordUtils.Save(_doc)
    End Sub

    Private Async Sub c1RichTextBox1_RequestNavigate(sender As Object, e As RequestNavigateEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(e.Hyperlink.NavigateUri)
    End Sub
End Class