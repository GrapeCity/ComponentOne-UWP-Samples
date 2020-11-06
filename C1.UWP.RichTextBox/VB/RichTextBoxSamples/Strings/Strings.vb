Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("RichTextBoxSamplesLib/Resources")

    Public Shared ReadOnly Property UnValidUrlMessage() As String
        Get
            Return _loader.GetString("UnValidUrlMessage")
        End Get
    End Property

    Public Shared ReadOnly Property [Error]() As String
        Get
            Return _loader.GetString("Error")
        End Get
    End Property

    Public Shared ReadOnly Property Navigate() As String
        Get
            Return _loader.GetString("Navigate")
        End Get
    End Property

    Public Shared ReadOnly Property NavigateMessage() As String
        Get
            Return _loader.GetString("NavigateMessage")
        End Get
    End Property

    Public Shared ReadOnly Property Ok() As String
        Get
            Return _loader.GetString("Ok")
        End Get
    End Property

    Public Shared ReadOnly Property Cancel() As String
        Get
            Return _loader.GetString("Cancel")
        End Get
    End Property

    Public Shared ReadOnly Property AlignLeft() As String
        Get
            Return _loader.GetString("AlignLeft")
        End Get
    End Property

    Public Shared ReadOnly Property AlignCenter() As String
        Get
            Return _loader.GetString("AlignCenter")
        End Get
    End Property

    Public Shared ReadOnly Property AlignRight() As String
        Get
            Return _loader.GetString("AlignRight")
        End Get
    End Property

    Public Shared ReadOnly Property Justify() As String
        Get
            Return _loader.GetString("Justify")
        End Get
    End Property

    Public Shared ReadOnly Property BulletedList() As String
        Get
            Return _loader.GetString("BulletedList")
        End Get
    End Property

    Public Shared ReadOnly Property NumberedList() As String
        Get
            Return _loader.GetString("NumberedList")
        End Get
    End Property

    Public Shared ReadOnly Property Undo() As String
        Get
            Return _loader.GetString("Undo")
        End Get
    End Property

    Public Shared ReadOnly Property Redo() As String
        Get
            Return _loader.GetString("Redo")
        End Get
    End Property

    Public Shared ReadOnly Property ClearFormat() As String
        Get
            Return _loader.GetString("ClearFormat")
        End Get
    End Property

    Public Shared ReadOnly Property Superscript() As String
        Get
            Return _loader.GetString("Superscript")
        End Get
    End Property

    Public Shared ReadOnly Property Subscript() As String
        Get
            Return _loader.GetString("Subscript")
        End Get
    End Property

    Public Shared ReadOnly Property Strikethrough() As String
        Get
            Return _loader.GetString("Strikethrough")
        End Get
    End Property

    Public Shared ReadOnly Property IncreaseFont() As String
        Get
            Return _loader.GetString("IncreaseFont")
        End Get
    End Property

    Public Shared ReadOnly Property DecreaseFont() As String
        Get
            Return _loader.GetString("DecreaseFont")
        End Get
    End Property

    Public Shared ReadOnly Property Denmark() As String
        Get
            Return _loader.GetString("Denmark")
        End Get
    End Property

    Public Shared ReadOnly Property Switzerland() As String
        Get
            Return _loader.GetString("Switzerland")
        End Get
    End Property

    Public Shared ReadOnly Property Germany() As String
        Get
            Return _loader.GetString("Germany")
        End Get
    End Property

    Public Shared ReadOnly Property Greece() As String
        Get
            Return _loader.GetString("Greece")
        End Get
    End Property

    Public Shared ReadOnly Property Canada() As String
        Get
            Return _loader.GetString("Canada")
        End Get
    End Property

    Public Shared ReadOnly Property UK() As String
        Get
            Return _loader.GetString("UK")
        End Get
    End Property

    Public Shared ReadOnly Property US() As String
        Get
            Return _loader.GetString("US")
        End Get
    End Property

    Public Shared ReadOnly Property Argentina() As String
        Get
            Return _loader.GetString("Argentina")
        End Get
    End Property

    Public Shared ReadOnly Property Spain() As String
        Get
            Return _loader.GetString("Spain")
        End Get
    End Property

    Public Shared ReadOnly Property Mexico() As String
        Get
            Return _loader.GetString("Mexico")
        End Get
    End Property

    Public Shared ReadOnly Property CanadaFrench() As String
        Get
            Return _loader.GetString("CanadaFrench")
        End Get
    End Property

    Public Shared ReadOnly Property France() As String
        Get
            Return _loader.GetString("France")
        End Get
    End Property

    Public Shared ReadOnly Property Italy() As String
        Get
            Return _loader.GetString("Italy")
        End Get
    End Property

    Public Shared ReadOnly Property Bokmal() As String
        Get
            Return _loader.GetString("Bokmal")
        End Get
    End Property

    Public Shared ReadOnly Property Netherlands() As String
        Get
            Return _loader.GetString("Netherlands")
        End Get
    End Property

    Public Shared ReadOnly Property Brazil() As String
        Get
            Return _loader.GetString("Brazil")
        End Get
    End Property

    Public Shared ReadOnly Property Portugal() As String
        Get
            Return _loader.GetString("Portugal")
        End Get
    End Property

    Public Shared ReadOnly Property Russia() As String
        Get
            Return _loader.GetString("Russia")
        End Get
    End Property

    Public Shared ReadOnly Property Sweden() As String
        Get
            Return _loader.GetString("Sweden")
        End Get
    End Property

    Public Shared ReadOnly Property PdfFile() As String
        Get
            Return _loader.GetString("PdfFile")
        End Get
    End Property

    Public Shared ReadOnly Property RtbSample() As String
        Get
            Return _loader.GetString("RtbSample")
        End Get
    End Property

    Public Shared ReadOnly Property SaveMessage() As String
        Get
            Return _loader.GetString("SaveMessage")
        End Get
    End Property

    Public Shared ReadOnly Property PrintException() As String
        Get
            Return _loader.GetString("PrintException")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property DemoTitle() As String
        Get
            Return _loader.GetString("DemoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DemoDescription() As String
        Get
            Return _loader.GetString("DemoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DemoName() As String
        Get
            Return _loader.GetString("DemoName")
        End Get
    End Property

    Public Shared ReadOnly Property AppBarTitle() As String
        Get
            Return _loader.GetString("AppBarTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AppBarDescription() As String
        Get
            Return _loader.GetString("AppBarDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AppBarName() As String
        Get
            Return _loader.GetString("AppBarName")
        End Get
    End Property

    Public Shared ReadOnly Property FormattingTitle() As String
        Get
            Return _loader.GetString("FormattingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FormattingDescription() As String
        Get
            Return _loader.GetString("FormattingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FormattingName() As String
        Get
            Return _loader.GetString("FormattingName")
        End Get
    End Property

    Public Shared ReadOnly Property RtfFilterTitle() As String
        Get
            Return _loader.GetString("RtfFilterTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RtfFilterDescription() As String
        Get
            Return _loader.GetString("RtfFilterDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RtfFilterName() As String
        Get
            Return _loader.GetString("RtfFilterName")
        End Get
    End Property

    Public Shared ReadOnly Property SyntaxTitle() As String
        Get
            Return _loader.GetString("SyntaxTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SyntaxDescription() As String
        Get
            Return _loader.GetString("SyntaxDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SyntaxName() As String
        Get
            Return _loader.GetString("SyntaxName")
        End Get
    End Property

    Public Shared ReadOnly Property SearchTitle() As String
        Get
            Return _loader.GetString("SearchTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SearchDescription() As String
        Get
            Return _loader.GetString("SearchDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SearchName() As String
        Get
            Return _loader.GetString("SearchName")
        End Get
    End Property

    Public Shared ReadOnly Property PrintTitle() As String
        Get
            Return _loader.GetString("PrintTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PrintDescription() As String
        Get
            Return _loader.GetString("PrintDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PrintName() As String
        Get
            Return _loader.GetString("PrintName")
        End Get
    End Property

    Public Shared ReadOnly Property SpellCheckTitle() As String
        Get
            Return _loader.GetString("SpellCheckTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SpellCheckDescription() As String
        Get
            Return _loader.GetString("SpellCheckDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SpellCheckName() As String
        Get
            Return _loader.GetString("SpellCheckName")
        End Get
    End Property

    Public Shared ReadOnly Property MultiLanguageTitle() As String
        Get
            Return _loader.GetString("MultiLanguageTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MultiLanguageDescription() As String
        Get
            Return _loader.GetString("MultiLanguageDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MultiLanguageName() As String
        Get
            Return _loader.GetString("MultiLanguageName")
        End Get
    End Property

    Public Shared ReadOnly Property RtfSample() As String
        Get
            Return _loader.GetString("RtfSample")
        End Get
    End Property

    Public Shared ReadOnly Property SpellCheck() As String
        Get
            Return _loader.GetString("SpellCheck")
        End Get
    End Property

    Public Shared ReadOnly Property Find() As String
        Get
            Return _loader.GetString("FindSample")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ChoosePic_Content() As String
        Get
            Return _loader.GetString("ChoosePic_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ColNum_Text() As String
        Get
            Return _loader.GetString("ColNum_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ComboBoxItemDraft_Content() As String
        Get
            Return _loader.GetString("ComboBoxItemDraft_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ComboBoxItemPrint_Content() As String
        Get
            Return _loader.GetString("ComboBoxItemPrint_Content")
        End Get
    End Property

    Public Shared ReadOnly Property DownloadingText_Text() As String
        Get
            Return _loader.GetString("DownloadingText_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FindText_Text() As String
        Get
            Return _loader.GetString("FindText_Text")
        End Get
    End Property

    Public Shared ReadOnly Property HtmlTab_Header() As String
        Get
            Return _loader.GetString("HtmlTab_Header")
        End Get
    End Property

    Public Shared ReadOnly Property InsertHyperlink_Content() As String
        Get
            Return _loader.GetString("InsertHyperlink_Content")
        End Get
    End Property

    Public Shared ReadOnly Property InsertPic_Content() As String
        Get
            Return _loader.GetString("InsertPic_Content")
        End Get
    End Property

    Public Shared ReadOnly Property InsertTable_Content() As String
        Get
            Return _loader.GetString("InsertTable_Content")
        End Get
    End Property

    Public Shared ReadOnly Property LanguageText_Text() As String
        Get
            Return _loader.GetString("LanguageText_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Next_Content() As String
        Get
            Return _loader.GetString("Next_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Previous_Content() As String
        Get
            Return _loader.GetString("Previous_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Print_Content() As String
        Get
            Return _loader.GetString("Print_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Replace_Content() As String
        Get
            Return _loader.GetString("Replace_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ReplaceAll_Content() As String
        Get
            Return _loader.GetString("ReplaceAll_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ReplaceText_Text() As String
        Get
            Return _loader.GetString("ReplaceText_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RichTextBoxTab_Header() As String
        Get
            Return _loader.GetString("RichTextBoxTab_Header")
        End Get
    End Property

    Public Shared ReadOnly Property RowNum_Text() As String
        Get
            Return _loader.GetString("RowNum_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RtfTab_Header() As String
        Get
            Return _loader.GetString("RtfTab_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Save_Content() As String
        Get
            Return _loader.GetString("Save_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Text_Text() As String
        Get
            Return _loader.GetString("Text_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Url_Text() As String
        Get
            Return _loader.GetString("Url_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ViewModeText_Text() As String
        Get
            Return _loader.GetString("ViewModeText_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FontColor() As String
        Get
            Return _loader.GetString("FontColor")
        End Get
    End Property

    Public Shared ReadOnly Property Highlight() As String
        Get
            Return _loader.GetString("Highlight")
        End Get
    End Property
End Class