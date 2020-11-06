using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace RichTextBoxSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("RichTextBoxSamplesLib/Resources");

        public static string UnValidUrlMessage
        {
            get
            {
                return _loader.GetString("UnValidUrlMessage");
            }
        }

        public static string Error
        {
            get
            {
                return _loader.GetString("Error");
            }
        }

        public static string Navigate
        {
            get
            {
                return _loader.GetString("Navigate");
            }
        }

        public static string NavigateMessage
        {
            get
            {
                return _loader.GetString("NavigateMessage");
            }
        }

        public static string Ok
        {
            get
            {
                return _loader.GetString("Ok");
            }
        }

        public static string Cancel
        {
            get
            {
                return _loader.GetString("Cancel");
            }
        }

        public static string AlignLeft
        {
            get
            {
                return _loader.GetString("AlignLeft");
            }
        }

        public static string AlignCenter
        {
            get
            {
                return _loader.GetString("AlignCenter");
            }
        }

        public static string AlignRight
        {
            get
            {
                return _loader.GetString("AlignRight");
            }
        }

        public static string Justify
        {
            get
            {
                return _loader.GetString("Justify");
            }
        }

        public static string BulletedList
        {
            get
            {
                return _loader.GetString("BulletedList");
            }
        }

        public static string NumberedList
        {
            get
            {
                return _loader.GetString("NumberedList");
            }
        }

        public static string Undo
        {
            get
            {
                return _loader.GetString("Undo");
            }
        }

        public static string Redo
        {
            get
            {
                return _loader.GetString("Redo");
            }
        }

        public static string ClearFormat
        {
            get
            {
                return _loader.GetString("ClearFormat");
            }
        }

        public static string Superscript
        {
            get
            {
                return _loader.GetString("Superscript");
            }
        }

        public static string Subscript
        {
            get
            {
                return _loader.GetString("Subscript");
            }
        }

        public static string Strikethrough
        {
            get
            {
                return _loader.GetString("Strikethrough");
            }
        }

        public static string IncreaseFont
        {
            get
            {
                return _loader.GetString("IncreaseFont");
            }
        }

        public static string DecreaseFont
        {
            get
            {
                return _loader.GetString("DecreaseFont");
            }
        }

        public static string Denmark
        {
            get
            {
                return _loader.GetString("Denmark");
            }
        }

        public static string Switzerland
        {
            get
            {
                return _loader.GetString("Switzerland");
            }
        }

        public static string Germany
        {
            get
            {
                return _loader.GetString("Germany");
            }
        }

        public static string Greece
        {
            get
            {
                return _loader.GetString("Greece");
            }
        }

        public static string Canada
        {
            get
            {
                return _loader.GetString("Canada");
            }
        }

        public static string UK
        {
            get
            {
                return _loader.GetString("UK");
            }
        }

        public static string US
        {
            get
            {
                return _loader.GetString("US");
            }
        }

        public static string Argentina
        {
            get
            {
                return _loader.GetString("Argentina");
            }
        }

        public static string Spain
        {
            get
            {
                return _loader.GetString("Spain");
            }
        }

        public static string Mexico
        {
            get
            {
                return _loader.GetString("Mexico");
            }
        }

        public static string CanadaFrench
        {
            get
            {
                return _loader.GetString("CanadaFrench");
            }
        }

        public static string France
        {
            get
            {
                return _loader.GetString("France");
            }
        }

        public static string Italy
        {
            get
            {
                return _loader.GetString("Italy");
            }
        }

        public static string Bokmal
        {
            get
            {
                return _loader.GetString("Bokmal");
            }
        }

        public static string Netherlands
        {
            get
            {
                return _loader.GetString("Netherlands");
            }
        }

        public static string Brazil
        {
            get
            {
                return _loader.GetString("Brazil");
            }
        }

        public static string Portugal
        {
            get
            {
                return _loader.GetString("Portugal");
            }
        }

        public static string Russia
        {
            get
            {
                return _loader.GetString("Russia");
            }
        }

        public static string Sweden
        {
            get
            {
                return _loader.GetString("Sweden");
            }
        }

        public static string PdfFile
        {
            get
            {
                return _loader.GetString("PdfFile");
            }
        }

        public static string RtbSample
        {
            get
            {
                return _loader.GetString("RtbSample");
            }
        }

        public static string SaveMessage
        {
            get
            {
                return _loader.GetString("SaveMessage");
            }
        }

        public static string PrintException
        {
            get
            {
                return _loader.GetString("PrintException");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }

        public static string SessionStateKeyErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateKeyErrorMessage");
            }
        }

        public static string SessionStateErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateErrorMessage");
            }
        }

        public static string SuspensionManagerErrorMessage
        {
            get
            {
                return _loader.GetString("SuspensionManagerErrorMessage");
            }
        }

        public static string DemoTitle
        {
            get
            {
                return _loader.GetString("DemoTitle");
            }
        }

        public static string DemoDescription
        {
            get
            {
                return _loader.GetString("DemoDescription");
            }
        }

        public static string DemoName
        {
            get
            {
                return _loader.GetString("DemoName");
            }
        }

        public static string AppBarTitle
        {
            get
            {
                return _loader.GetString("AppBarTitle");
            }
        }

        public static string AppBarDescription
        {
            get
            {
                return _loader.GetString("AppBarDescription");
            }
        }

        public static string AppBarName
        {
            get
            {
                return _loader.GetString("AppBarName");
            }
        }

        public static string FormattingTitle
        {
            get
            {
                return _loader.GetString("FormattingTitle");
            }
        }

        public static string FormattingDescription
        {
            get
            {
                return _loader.GetString("FormattingDescription");
            }
        }

        public static string FormattingName
        {
            get
            {
                return _loader.GetString("FormattingName");
            }
        }

        public static string RtfFilterTitle
        {
            get
            {
                return _loader.GetString("RtfFilterTitle");
            }
        }

        public static string RtfFilterDescription
        {
            get
            {
                return _loader.GetString("RtfFilterDescription");
            }
        }

        public static string RtfFilterName
        {
            get
            {
                return _loader.GetString("RtfFilterName");
            }
        }

        public static string SyntaxTitle
        {
            get
            {
                return _loader.GetString("SyntaxTitle");
            }
        }

        public static string SyntaxDescription
        {
            get
            {
                return _loader.GetString("SyntaxDescription");
            }
        }

        public static string SyntaxName
        {
            get
            {
                return _loader.GetString("SyntaxName");
            }
        }

        public static string SearchTitle
        {
            get
            {
                return _loader.GetString("SearchTitle");
            }
        }

        public static string SearchDescription
        {
            get
            {
                return _loader.GetString("SearchDescription");
            }
        }

        public static string SearchName
        {
            get
            {
                return _loader.GetString("SearchName");
            }
        }

        public static string PrintTitle
        {
            get
            {
                return _loader.GetString("PrintTitle");
            }
        }

        public static string PrintDescription
        {
            get
            {
                return _loader.GetString("PrintDescription");
            }
        }

        public static string PrintName
        {
            get
            {
                return _loader.GetString("PrintName");
            }
        }

        public static string SpellCheckTitle
        {
            get
            {
                return _loader.GetString("SpellCheckTitle");
            }
        }

        public static string SpellCheckDescription
        {
            get
            {
                return _loader.GetString("SpellCheckDescription");
            }
        }

        public static string SpellCheckName
        {
            get
            {
                return _loader.GetString("SpellCheckName");
            }
        }

        public static string MultiLanguageTitle
        {
            get
            {
                return _loader.GetString("MultiLanguageTitle");
            }
        }

        public static string MultiLanguageDescription
        {
            get
            {
                return _loader.GetString("MultiLanguageDescription");
            }
        }

        public static string MultiLanguageName
        {
            get
            {
                return _loader.GetString("MultiLanguageName");
            }
        }

        public static string RtfSample
        {
            get
            {
                return _loader.GetString("RtfSample");
            }
        }

        public static string SpellCheck
        {
            get
            {
                return _loader.GetString("SpellCheck");
            }
        }

        public static string Find
        {
            get
            {
                return _loader.GetString("FindSample");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string ChoosePic_Content
        {
            get
            {
                return _loader.GetString("ChoosePic_Content");
            }
        }

        public static string ColNum_Text
        {
            get
            {
                return _loader.GetString("ColNum_Text");
            }
        }

        public static string ComboBoxItemDraft_Content
        {
            get
            {
                return _loader.GetString("ComboBoxItemDraft_Content");
            }
        }

        public static string ComboBoxItemPrint_Content
        {
            get
            {
                return _loader.GetString("ComboBoxItemPrint_Content");
            }
        }

        public static string DownloadingText_Text
        {
            get
            {
                return _loader.GetString("DownloadingText_Text");
            }
        }

        public static string FindText_Text
        {
            get
            {
                return _loader.GetString("FindText_Text");
            }
        }

        public static string HtmlTab_Header
        {
            get
            {
                return _loader.GetString("HtmlTab_Header");
            }
        }

        public static string InsertHyperlink_Content
        {
            get
            {
                return _loader.GetString("InsertHyperlink_Content");
            }
        }

        public static string InsertPic_Content
        {
            get
            {
                return _loader.GetString("InsertPic_Content");
            }
        }

        public static string InsertTable_Content
        {
            get
            {
                return _loader.GetString("InsertTable_Content");
            }
        }

        public static string LanguageText_Text
        {
            get
            {
                return _loader.GetString("LanguageText_Text");
            }
        }

        public static string Next_Content
        {
            get
            {
                return _loader.GetString("Next_Content");
            }
        }

        public static string Previous_Content
        {
            get
            {
                return _loader.GetString("Previous_Content");
            }
        }

        public static string Print_Content
        {
            get
            {
                return _loader.GetString("Print_Content");
            }
        }

        public static string Replace_Content
        {
            get
            {
                return _loader.GetString("Replace_Content");
            }
        }

        public static string ReplaceAll_Content
        {
            get
            {
                return _loader.GetString("ReplaceAll_Content");
            }
        }

        public static string ReplaceText_Text
        {
            get
            {
                return _loader.GetString("ReplaceText_Text");
            }
        }

        public static string RichTextBoxTab_Header
        {
            get
            {
                return _loader.GetString("RichTextBoxTab_Header");
            }
        }

        public static string RowNum_Text
        {
            get
            {
                return _loader.GetString("RowNum_Text");
            }
        }

        public static string RtfTab_Header
        {
            get
            {
                return _loader.GetString("RtfTab_Header");
            }
        }

        public static string Save_Content
        {
            get
            {
                return _loader.GetString("Save_Content");
            }
        }

        public static string Text_Text
        {
            get
            {
                return _loader.GetString("Text_Text");
            }
        }

        public static string Url_Text
        {
            get
            {
                return _loader.GetString("Url_Text");
            }
        }

        public static string ViewModeText_Text
        {
            get
            {
                return _loader.GetString("ViewModeText_Text");
            }
        }

        public static string FontColor
        {
            get
            {
                return _loader.GetString("FontColor");
            }
        }

        public static string Highlight
        {
            get
            {
                return _loader.GetString("Highlight");
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Font Size.
        /// </summary>
        public static string LineNumber
        {
            get
            {
                return _loader.GetString("Line_Number");
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LineNumberMode None.
        /// </summary>
        public static string LineNumberMode_None
        {
            get
            {
                return _loader.GetString("LineNumberMode_None");
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to LineNumberMode Continuous.
        /// </summary>
        public static string LineNumberMode_Continuous
        {
            get
            {
                return _loader.GetString("LineNumberMode_Continuous");
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to LineNumberMode RestartEachPage.
        /// </summary>
        public static string LineNumberMode_RestartEachPage
        {
            get
            {
                return _loader.GetString("LineNumberMode_RestartEachPage");
            }
        }

    }
}
