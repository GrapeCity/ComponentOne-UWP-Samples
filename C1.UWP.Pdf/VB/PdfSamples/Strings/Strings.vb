Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("PdfSamplesLib/Resources")

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Bezier() As String
        Get
            Return _loader.GetString("Bezier")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomSentenceString1() As String
        Get
            Return _loader.GetString("BuildRandomSentenceString1")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomSentenceString2() As String
        Get
            Return _loader.GetString("BuildRandomSentenceString2")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomSentenceString3() As String
        Get
            Return _loader.GetString("BuildRandomSentenceString3")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomSentenceString4() As String
        Get
            Return _loader.GetString("BuildRandomSentenceString4")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomTitleString1() As String
        Get
            Return _loader.GetString("BuildRandomTitleString1")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomTitleString2() As String
        Get
            Return _loader.GetString("BuildRandomTitleString2")
        End Get
    End Property

    Public Shared ReadOnly Property BuildRandomTitleString3() As String
        Get
            Return _loader.GetString("BuildRandomTitleString3")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxCB_Content() As String
        Get
            Return _loader.GetString("CheckBoxCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ComboBoxItem1_Content() As String
        Get
            Return _loader.GetString("ComboBoxItem1_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ComboBoxItem2_Content() As String
        Get
            Return _loader.GetString("ComboBoxItem2_Content")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentAuthor() As String
        Get
            Return _loader.GetString("DocumentAuthor")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentBasicText() As String
        Get
            Return _loader.GetString("DocumentBasicText")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentBasicText2() As String
        Get
            Return _loader.GetString("DocumentBasicText2")
        End Get
    End Property

    Public Shared ReadOnly Property Documentfooter() As String
        Get
            Return _loader.GetString("Documentfooter")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentGraphicsText() As String
        Get
            Return _loader.GetString("DocumentGraphicsText")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentSubject() As String
        Get
            Return _loader.GetString("DocumentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property FileTypeChoicesTip() As String
        Get
            Return _loader.GetString("FileTypeChoicesTip")
        End Get
    End Property

    Public Shared ReadOnly Property GraphicsDocumentTitle() As String
        Get
            Return _loader.GetString("GraphicsDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HyperlinkButton_Content() As String
        Get
            Return _loader.GetString("HyperlinkButton_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ImagesDocumentTitle() As String
        Get
            Return _loader.GetString("ImagesDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxItem1_Content() As String
        Get
            Return _loader.GetString("ListBoxItem1_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxItem2_Content() As String
        Get
            Return _loader.GetString("ListBoxItem2_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxItem3_Content() As String
        Get
            Return _loader.GetString("ListBoxItem3_Content")
        End Get
    End Property

    Public Shared ReadOnly Property MessageDialogTitle() As String
        Get
            Return _loader.GetString("MessageDialogTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PaperSizesDocumentTitle() As String
        Get
            Return _loader.GetString("PaperSizesDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesBasicTextDescription() As String
        Get
            Return _loader.GetString("PdfSamplesBasicTextDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesBasicTextName() As String
        Get
            Return _loader.GetString("PdfSamplesBasicTextName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesBasicTextTitle() As String
        Get
            Return _loader.GetString("PdfSamplesBasicTextTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesExportUIDescription() As String
        Get
            Return _loader.GetString("PdfSamplesExportUIDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesExportUIName() As String
        Get
            Return _loader.GetString("PdfSamplesExportUIName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesExportUITitle() As String
        Get
            Return _loader.GetString("PdfSamplesExportUITitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesGraphicsDescription() As String
        Get
            Return _loader.GetString("PdfSamplesGraphicsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesGraphicsName() As String
        Get
            Return _loader.GetString("PdfSamplesGraphicsName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesGraphicsTitle() As String
        Get
            Return _loader.GetString("PdfSamplesGraphicsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesImagesDescription() As String
        Get
            Return _loader.GetString("PdfSamplesImagesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesImagesName() As String
        Get
            Return _loader.GetString("PdfSamplesImagesName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesImagesTitle() As String
        Get
            Return _loader.GetString("PdfSamplesImagesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesPaperSizesDescription() As String
        Get
            Return _loader.GetString("PdfSamplesPaperSizesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesPaperSizesName() As String
        Get
            Return _loader.GetString("PdfSamplesPaperSizesName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesPaperSizesTitle() As String
        Get
            Return _loader.GetString("PdfSamplesPaperSizesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesQuotesDescription() As String
        Get
            Return _loader.GetString("PdfSamplesQuotesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesQuotesName() As String
        Get
            Return _loader.GetString("PdfSamplesQuotesName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesQuotesTitle() As String
        Get
            Return _loader.GetString("PdfSamplesQuotesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesTableOfContentsDescription() As String
        Get
            Return _loader.GetString("PdfSamplesTableOfContentsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesTableOfContentsName() As String
        Get
            Return _loader.GetString("PdfSamplesTableOfContentsName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesTableOfContentsTitle() As String
        Get
            Return _loader.GetString("PdfSamplesTableOfContentsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesTextFlowDescription() As String
        Get
            Return _loader.GetString("PdfSamplesTextFlowDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesTextFlowName() As String
        Get
            Return _loader.GetString("PdfSamplesTextFlowName")
        End Get
    End Property

    Public Shared ReadOnly Property PdfSamplesTextFlowTitle() As String
        Get
            Return _loader.GetString("PdfSamplesTextFlowTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PoundSign() As String
        Get
            Return _loader.GetString("PoundSign")
        End Get
    End Property

    Public Shared ReadOnly Property QuotesDocumentTitle() As String
        Get
            Return _loader.GetString("QuotesDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RadioButtonRB_Content() As String
        Get
            Return _loader.GetString("RadioButtonRB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property RenderBT_Content() As String
        Get
            Return _loader.GetString("RenderBT_Content")
        End Get
    End Property

    Public Shared ReadOnly Property RenderUIDocumentTitle() As String
        Get
            Return _loader.GetString("RenderUIDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ResourceNotFound() As String
        Get
            Return _loader.GetString("ResourceNotFound")
        End Get
    End Property

    Public Shared ReadOnly Property RichTextBlock_Text() As String
        Get
            Return _loader.GetString("RichTextBlock_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RunText1_Text() As String
        Get
            Return _loader.GetString("RunText1_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RunText2_Text() As String
        Get
            Return _loader.GetString("RunText2_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RunText3_Text() As String
        Get
            Return _loader.GetString("RunText3_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SaveLocationTip() As String
        Get
            Return _loader.GetString("SaveLocationTip")
        End Get
    End Property

    Public Shared ReadOnly Property SavePDFBT_Content() As String
        Get
            Return _loader.GetString("SavePDFBT_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property StringFormatTwoArg() As String
        Get
            Return _loader.GetString("StringFormatTwoArg")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property TableOfContentsDocumentTitle() As String
        Get
            Return _loader.GetString("TableOfContentsDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TextBlockTB1_Text() As String
        Get
            Return _loader.GetString("TextBlockTB1_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TextBlockTB2_Text() As String
        Get
            Return _loader.GetString("TextBlockTB2_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TextBoxTB_Text() As String
        Get
            Return _loader.GetString("TextBoxTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TextFlowDocumentTitle() As String
        Get
            Return _loader.GetString("TextFlowDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ToggleSwitch_Header() As String
        Get
            Return _loader.GetString("ToggleSwitch_Header")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property
End Class