Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("WordSamplesLib/Resources")

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
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

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesBasicTextTitle() As String
        Get
            Return _loader.GetString("WordSamplesBasicTextTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesBasicTextDescription() As String
        Get
            Return _loader.GetString("WordSamplesBasicTextDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesBasicTextName() As String
        Get
            Return _loader.GetString("WordSamplesBasicTextName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesImagesTitle() As String
        Get
            Return _loader.GetString("WordSamplesImagesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesImagesDescription() As String
        Get
            Return _loader.GetString("WordSamplesImagesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesImagesName() As String
        Get
            Return _loader.GetString("WordSamplesImagesName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesGraphicsTitle() As String
        Get
            Return _loader.GetString("WordSamplesGraphicsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesGraphicsDescription() As String
        Get
            Return _loader.GetString("WordSamplesGraphicsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesGraphicsName() As String
        Get
            Return _loader.GetString("WordSamplesGraphicsName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesQuotesTitle() As String
        Get
            Return _loader.GetString("WordSamplesQuotesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesQuotesDescription() As String
        Get
            Return _loader.GetString("WordSamplesQuotesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesQuotesName() As String
        Get
            Return _loader.GetString("WordSamplesQuotesName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesTableOfContentsTitle() As String
        Get
            Return _loader.GetString("WordSamplesTableOfContentsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesTableOfContentsDescription() As String
        Get
            Return _loader.GetString("WordSamplesTableOfContentsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesTableOfContentsName() As String
        Get
            Return _loader.GetString("WordSamplesTableOfContentsName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesTextFlowTitle() As String
        Get
            Return _loader.GetString("WordSamplesTextFlowTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesTextFlowDescription() As String
        Get
            Return _loader.GetString("WordSamplesTextFlowDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesTextFlowName() As String
        Get
            Return _loader.GetString("WordSamplesTextFlowName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesPaperSizesTitle() As String
        Get
            Return _loader.GetString("WordSamplesPaperSizesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesPaperSizesDescription() As String
        Get
            Return _loader.GetString("WordSamplesPaperSizesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesPaperSizesName() As String
        Get
            Return _loader.GetString("WordSamplesPaperSizesName")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesExportUITitle() As String
        Get
            Return _loader.GetString("WordSamplesExportUITitle")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesExportUIDescription() As String
        Get
            Return _loader.GetString("WordSamplesExportUIDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WordSamplesExportUIName() As String
        Get
            Return _loader.GetString("WordSamplesExportUIName")
        End Get
    End Property

    Public Shared ReadOnly Property GraphicsWarning() As String
        Get
            Return _loader.GetString("GraphicsWarning")
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

    Public Shared ReadOnly Property DocumentBasicMergedCell() As String
        Get
            Return _loader.GetString("DocumentBasicMergedCell")
        End Get
    End Property

    Public Shared ReadOnly Property GraphicsDocumentTitle() As String
        Get
            Return _loader.GetString("GraphicsDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentGraphicsText() As String
        Get
            Return _loader.GetString("DocumentGraphicsText")
        End Get
    End Property

    Public Shared ReadOnly Property Bezier() As String
        Get
            Return _loader.GetString("Bezier")
        End Get
    End Property

    Public Shared ReadOnly Property ImagesDocumentTitle() As String
        Get
            Return _loader.GetString("ImagesDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PaperSizesDocumentTitle() As String
        Get
            Return _loader.GetString("PaperSizesDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PaperSizesFirstPage() As String
        Get
            Return _loader.GetString("PaperSizesFirstPage")
        End Get
    End Property

    Public Shared ReadOnly Property PaperSizesWarning() As String
        Get
            Return _loader.GetString("PaperSizesWarning")
        End Get
    End Property

    Public Shared ReadOnly Property StringFormatTwoArg() As String
        Get
            Return _loader.GetString("StringFormatTwoArg")
        End Get
    End Property

    Public Shared ReadOnly Property QuotesDocumentTitle() As String
        Get
            Return _loader.GetString("QuotesDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property QuotesAuthors() As String
        Get
            Return _loader.GetString("QuotesAuthors")
        End Get
    End Property

    Public Shared ReadOnly Property RenderUIDocumentTitle() As String
        Get
            Return _loader.GetString("RenderUIDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TextFlowDocumentTitle() As String
        Get
            Return _loader.GetString("TextFlowDocumentTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MsWordFormats() As String
        Get
            Return _loader.GetString("MsWordFormats")
        End Get
    End Property

    Public Shared ReadOnly Property TableOfContentsDocumentTitle() As String
        Get
            Return _loader.GetString("TableOfContentsDocumentTitle")
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

    Public Shared ReadOnly Property DocumentAuthor() As String
        Get
            Return _loader.GetString("DocumentAuthor")
        End Get
    End Property

    Public Shared ReadOnly Property DocumentSubject() As String
        Get
            Return _loader.GetString("DocumentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property Documentfooter() As String
        Get
            Return _loader.GetString("Documentfooter")
        End Get
    End Property

    Public Shared ReadOnly Property SaveLocationTip() As String
        Get
            Return _loader.GetString("SaveLocationTip")
        End Get
    End Property

    Public Shared ReadOnly Property MessageDialogTitle() As String
        Get
            Return _loader.GetString("MessageDialogTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PoundSign() As String
        Get
            Return _loader.GetString("PoundSign")
        End Get
    End Property

    Public Shared ReadOnly Property FileTypeChoicesTip() As String
        Get
            Return _loader.GetString("FileTypeChoicesTip")
        End Get
    End Property

    Public Shared ReadOnly Property AlternateFileTypeChoicesTip() As String
        Get
            Return _loader.GetString("AlternateFileTypeChoicesTip")
        End Get
    End Property
    Public Shared ReadOnly Property ResourceNotFound() As String
        Get
            Return _loader.GetString("ResourceNotFound")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
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

    Public Shared ReadOnly Property HyperlinkButton_Content() As String
        Get
            Return _loader.GetString("HyperlinkButton_Content")
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

    Public Shared ReadOnly Property SaveWordBT_Content() As String
        Get
            Return _loader.GetString("SaveWordBT_Content")
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

    Public Shared ReadOnly Property ToggleSwitch_Header() As String
        Get
            Return _loader.GetString("ToggleSwitch_Header")
        End Get
    End Property

    Public Shared ReadOnly Property ImageFirstParagraph() As String
        Get
            Return _loader.GetString("ImageFirstParagraph")
        End Get
    End Property
    Public Shared ReadOnly Property ImageSecondParagraph() As String
        Get
            Return _loader.GetString("ImageSecondParagraph")
        End Get
    End Property
    Public Shared ReadOnly Property WordSamplesWordTitle() As String
        Get
            Return _loader.GetString("WordSamplesWordTitle")
        End Get
    End Property
    Public Shared ReadOnly Property WordSamplesWordLink() As String
        Get
            Return _loader.GetString("WordSamplesWordLink")
        End Get
    End Property
End Class