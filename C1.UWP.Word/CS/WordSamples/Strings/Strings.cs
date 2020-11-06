using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace WordSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("WordSamplesLib/Resources");

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }

        public static string SessionStateErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateErrorMessage");
            }
        }

        public static string SessionStateKeyErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateKeyErrorMessage");
            }
        }

        public static string SuspensionManagerErrorMessage
        {
            get
            {
                return _loader.GetString("SuspensionManagerErrorMessage");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string WordSamplesBasicTextTitle
        {
            get
            {
                return _loader.GetString("WordSamplesBasicTextTitle");
            }
        }

        public static string WordSamplesBasicTextDescription
        {
            get
            {
                return _loader.GetString("WordSamplesBasicTextDescription");
            }
        }

        public static string WordSamplesBasicTextName
        {
            get
            {
                return _loader.GetString("WordSamplesBasicTextName");
            }
        }

        public static string WordSamplesImagesTitle
        {
            get
            {
                return _loader.GetString("WordSamplesImagesTitle");
            }
        }

        public static string WordSamplesImagesDescription
        {
            get
            {
                return _loader.GetString("WordSamplesImagesDescription");
            }
        }

        public static string WordSamplesImagesName
        {
            get
            {
                return _loader.GetString("WordSamplesImagesName");
            }
        }

        public static string WordSamplesGraphicsTitle
        {
            get
            {
                return _loader.GetString("WordSamplesGraphicsTitle");
            }
        }

        public static string WordSamplesGraphicsDescription
        {
            get
            {
                return _loader.GetString("WordSamplesGraphicsDescription");
            }
        }

        public static string WordSamplesGraphicsName
        {
            get
            {
                return _loader.GetString("WordSamplesGraphicsName");
            }
        }

        public static string WordSamplesQuotesTitle
        {
            get
            {
                return _loader.GetString("WordSamplesQuotesTitle");
            }
        }

        public static string WordSamplesQuotesDescription
        {
            get
            {
                return _loader.GetString("WordSamplesQuotesDescription");
            }
        }

        public static string WordSamplesQuotesName
        {
            get
            {
                return _loader.GetString("WordSamplesQuotesName");
            }
        }

        public static string WordSamplesTableOfContentsTitle
        {
            get
            {
                return _loader.GetString("WordSamplesTableOfContentsTitle");
            }
        }

        public static string WordSamplesTableOfContentsDescription
        {
            get
            {
                return _loader.GetString("WordSamplesTableOfContentsDescription");
            }
        }

        public static string WordSamplesTableOfContentsName
        {
            get
            {
                return _loader.GetString("WordSamplesTableOfContentsName");
            }
        }

        public static string WordSamplesTextFlowTitle
        {
            get
            {
                return _loader.GetString("WordSamplesTextFlowTitle");
            }
        }

        public static string WordSamplesTextFlowDescription
        {
            get
            {
                return _loader.GetString("WordSamplesTextFlowDescription");
            }
        }

        public static string WordSamplesTextFlowName
        {
            get
            {
                return _loader.GetString("WordSamplesTextFlowName");
            }
        }

        public static string WordSamplesPaperSizesTitle
        {
            get
            {
                return _loader.GetString("WordSamplesPaperSizesTitle");
            }
        }

        public static string WordSamplesPaperSizesDescription
        {
            get
            {
                return _loader.GetString("WordSamplesPaperSizesDescription");
            }
        }

        public static string WordSamplesPaperSizesName
        {
            get
            {
                return _loader.GetString("WordSamplesPaperSizesName");
            }
        }

        public static string WordSamplesExportUITitle
        {
            get
            {
                return _loader.GetString("WordSamplesExportUITitle");
            }
        }

        public static string WordSamplesExportUIDescription
        {
            get
            {
                return _loader.GetString("WordSamplesExportUIDescription");
            }
        }

        public static string WordSamplesExportUIName
        {
            get
            {
                return _loader.GetString("WordSamplesExportUIName");
            }
        }

        public static string GraphicsWarning
        {
            get
            {
                return _loader.GetString("GraphicsWarning");
            }
        }

        public static string DocumentBasicText
        {
            get
            {
                return _loader.GetString("DocumentBasicText");
            }
        }

        public static string DocumentBasicText2
        {
            get
            {
                return _loader.GetString("DocumentBasicText2");
            }
        }

        public static string DocumentBasicMergedCell
        {
            get
            {
                return _loader.GetString("DocumentBasicMergedCell");
            }
        }

        public static string GraphicsDocumentTitle
        {
            get
            {
                return _loader.GetString("GraphicsDocumentTitle");
            }
        }

        public static string DocumentGraphicsText
        {
            get
            {
                return _loader.GetString("DocumentGraphicsText");
            }
        }

        public static string Bezier
        {
            get
            {
                return _loader.GetString("Bezier");
            }
        }

        public static string ImagesDocumentTitle
        {
            get
            {
                return _loader.GetString("ImagesDocumentTitle");
            }
        }

        public static string PaperSizesDocumentTitle
        {
            get
            {
                return _loader.GetString("PaperSizesDocumentTitle");
            }
        }

        public static string PaperSizesFirstPage
        {
            get
            {
                return _loader.GetString("PaperSizesFirstPage");
            }
        }

        public static string PaperSizesWarning
        {
            get
            {
                return _loader.GetString("PaperSizesWarning");
            }
        }

        public static string StringFormatTwoArg
        {
            get
            {
                return _loader.GetString("StringFormatTwoArg");
            }
        }

        public static string QuotesDocumentTitle
        {
            get
            {
                return _loader.GetString("QuotesDocumentTitle");
            }
        }

        public static string QuotesAuthors
        {
            get
            {
                return _loader.GetString("QuotesAuthors");
            }
        }

        public static string RenderUIDocumentTitle
        {
            get
            {
                return _loader.GetString("RenderUIDocumentTitle");
            }
        }

        public static string TextFlowDocumentTitle
        {
            get
            {
                return _loader.GetString("TextFlowDocumentTitle");
            }
        }

        public static string MsWordFormats
        {
            get
            {
                return _loader.GetString("MsWordFormats");
            }
        }

        public static string TableOfContentsDocumentTitle
        {
            get
            {
                return _loader.GetString("TableOfContentsDocumentTitle");
            }
        }

        public static string BuildRandomTitleString1
        {
            get
            {
                return _loader.GetString("BuildRandomTitleString1");
            }
        }

        public static string BuildRandomTitleString2
        {
            get
            {
                return _loader.GetString("BuildRandomTitleString2");
            }
        }

        public static string BuildRandomTitleString3
        {
            get
            {
                return _loader.GetString("BuildRandomTitleString3");
            }
        }

        public static string BuildRandomSentenceString1
        {
            get
            {
                return _loader.GetString("BuildRandomSentenceString1");
            }
        }

        public static string BuildRandomSentenceString2
        {
            get
            {
                return _loader.GetString("BuildRandomSentenceString2");
            }
        }

        public static string BuildRandomSentenceString3
        {
            get
            {
                return _loader.GetString("BuildRandomSentenceString3");
            }
        }

        public static string BuildRandomSentenceString4
        {
            get
            {
                return _loader.GetString("BuildRandomSentenceString4");
            }
        }

        public static string DocumentAuthor
        {
            get
            {
                return _loader.GetString("DocumentAuthor");
            }
        }

        public static string DocumentSubject
        {
            get
            {
                return _loader.GetString("DocumentSubject");
            }
        }

        public static string Documentfooter
        {
            get
            {
                return _loader.GetString("Documentfooter");
            }
        }

        public static string SaveLocationTip
        {
            get
            {
                return _loader.GetString("SaveLocationTip");
            }
        }

        public static string MessageDialogTitle
        {
            get
            {
                return _loader.GetString("MessageDialogTitle");
            }
        }

        public static string PoundSign
        {
            get
            {
                return _loader.GetString("PoundSign");
            }
        }

        public static string FileTypeChoicesTip
        {
            get
            {
                return _loader.GetString("FileTypeChoicesTip");
            }
        }

        public static string AlternateFileTypeChoicesTip
        {
            get
            {
                return _loader.GetString("AlternateFileTypeChoicesTip");
            }
        }
        public static string ResourceNotFound
        {
            get
            {
                return _loader.GetString("ResourceNotFound");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string CheckBoxCB_Content
        {
            get
            {
                return _loader.GetString("CheckBoxCB_Content");
            }
        }

        public static string ComboBoxItem1_Content
        {
            get
            {
                return _loader.GetString("ComboBoxItem1_Content");
            }
        }

        public static string ComboBoxItem2_Content
        {
            get
            {
                return _loader.GetString("ComboBoxItem2_Content");
            }
        }

        public static string HyperlinkButton_Content
        {
            get
            {
                return _loader.GetString("HyperlinkButton_Content");
            }
        }

        public static string ListBoxItem1_Content
        {
            get
            {
                return _loader.GetString("ListBoxItem1_Content");
            }
        }

        public static string ListBoxItem2_Content
        {
            get
            {
                return _loader.GetString("ListBoxItem2_Content");
            }
        }

        public static string ListBoxItem3_Content
        {
            get
            {
                return _loader.GetString("ListBoxItem3_Content");
            }
        }

        public static string RadioButtonRB_Content
        {
            get
            {
                return _loader.GetString("RadioButtonRB_Content");
            }
        }

        public static string RenderBT_Content
        {
            get
            {
                return _loader.GetString("RenderBT_Content");
            }
        }

        public static string RichTextBlock_Text
        {
            get
            {
                return _loader.GetString("RichTextBlock_Text");
            }
        }

        public static string RunText1_Text
        {
            get
            {
                return _loader.GetString("RunText1_Text");
            }
        }

        public static string RunText2_Text
        {
            get
            {
                return _loader.GetString("RunText2_Text");
            }
        }

        public static string RunText3_Text
        {
            get
            {
                return _loader.GetString("RunText3_Text");
            }
        }

        public static string SaveWordBT_Content
        {
            get
            {
                return _loader.GetString("SaveWordBT_Content");
            }
        }

        public static string TextBlockTB1_Text
        {
            get
            {
                return _loader.GetString("TextBlockTB1_Text");
            }
        }

        public static string TextBlockTB2_Text
        {
            get
            {
                return _loader.GetString("TextBlockTB2_Text");
            }
        }

        public static string TextBoxTB_Text
        {
            get
            {
                return _loader.GetString("TextBoxTB_Text");
            }
        }

        public static string ToggleSwitch_Header
        {
            get
            {
                return _loader.GetString("ToggleSwitch_Header");
            }
        }

        public static string ImageFirstParagraph
        {
            get
            {
                return _loader.GetString("ImageFirstParagraph");
            }
        }
        public static string ImageSecondParagraph
        {
            get
            {
                return _loader.GetString("ImageSecondParagraph");
            }
        }
        public static string WordSamplesWordTitle
        {
            get
            {
                return _loader.GetString("WordSamplesWordTitle");
            }
        }
        public static string WordSamplesWordLink
        {
            get
            {
                return _loader.GetString("WordSamplesWordLink");
            }
        }
    }
}
