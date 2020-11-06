using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace PdfSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("PdfSamplesLib/Resources");

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string Bezier
        {
            get
            {
                return _loader.GetString("Bezier");
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

        public static string DocumentAuthor
        {
            get
            {
                return _loader.GetString("DocumentAuthor");
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

        public static string Documentfooter
        {
            get
            {
                return _loader.GetString("Documentfooter");
            }
        }

        public static string DocumentGraphicsText
        {
            get
            {
                return _loader.GetString("DocumentGraphicsText");
            }
        }

        public static string DocumentSubject
        {
            get
            {
                return _loader.GetString("DocumentSubject");
            }
        }

        public static string FileTypeChoicesTip
        {
            get
            {
                return _loader.GetString("FileTypeChoicesTip");
            }
        }

        public static string GraphicsDocumentTitle
        {
            get
            {
                return _loader.GetString("GraphicsDocumentTitle");
            }
        }

        public static string HyperlinkButton_Content
        {
            get
            {
                return _loader.GetString("HyperlinkButton_Content");
            }
        }

        public static string ImagesDocumentTitle
        {
            get
            {
                return _loader.GetString("ImagesDocumentTitle");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
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

        public static string MessageDialogTitle
        {
            get
            {
                return _loader.GetString("MessageDialogTitle");
            }
        }

        public static string PaperSizesDocumentTitle
        {
            get
            {
                return _loader.GetString("PaperSizesDocumentTitle");
            }
        }

        public static string PdfSamplesBasicTextDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesBasicTextDescription");
            }
        }

        public static string PdfSamplesBasicTextName
        {
            get
            {
                return _loader.GetString("PdfSamplesBasicTextName");
            }
        }

        public static string PdfSamplesBasicTextTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesBasicTextTitle");
            }
        }

        public static string PdfSamplesExportUIDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesExportUIDescription");
            }
        }

        public static string PdfSamplesExportUIName
        {
            get
            {
                return _loader.GetString("PdfSamplesExportUIName");
            }
        }

        public static string PdfSamplesExportUITitle
        {
            get
            {
                return _loader.GetString("PdfSamplesExportUITitle");
            }
        }

        public static string PdfSamplesGraphicsDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesGraphicsDescription");
            }
        }

        public static string PdfSamplesGraphicsName
        {
            get
            {
                return _loader.GetString("PdfSamplesGraphicsName");
            }
        }

        public static string PdfSamplesGraphicsTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesGraphicsTitle");
            }
        }

        public static string PdfSamplesImagesDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesImagesDescription");
            }
        }

        public static string PdfSamplesImagesName
        {
            get
            {
                return _loader.GetString("PdfSamplesImagesName");
            }
        }

        public static string PdfSamplesImagesTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesImagesTitle");
            }
        }

        public static string PdfSamplesPaperSizesDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesPaperSizesDescription");
            }
        }

        public static string PdfSamplesPaperSizesName
        {
            get
            {
                return _loader.GetString("PdfSamplesPaperSizesName");
            }
        }

        public static string PdfSamplesPaperSizesTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesPaperSizesTitle");
            }
        }

        public static string PdfSamplesQuotesDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesQuotesDescription");
            }
        }

        public static string PdfSamplesQuotesName
        {
            get
            {
                return _loader.GetString("PdfSamplesQuotesName");
            }
        }

        public static string PdfSamplesQuotesTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesQuotesTitle");
            }
        }

        public static string PdfSamplesTableOfContentsDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesTableOfContentsDescription");
            }
        }

        public static string PdfSamplesTableOfContentsName
        {
            get
            {
                return _loader.GetString("PdfSamplesTableOfContentsName");
            }
        }

        public static string PdfSamplesTableOfContentsTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesTableOfContentsTitle");
            }
        }

        public static string PdfSamplesTextFlowDescription
        {
            get
            {
                return _loader.GetString("PdfSamplesTextFlowDescription");
            }
        }

        public static string PdfSamplesTextFlowName
        {
            get
            {
                return _loader.GetString("PdfSamplesTextFlowName");
            }
        }

        public static string PdfSamplesTextFlowTitle
        {
            get
            {
                return _loader.GetString("PdfSamplesTextFlowTitle");
            }
        }

        public static string PoundSign
        {
            get
            {
                return _loader.GetString("PoundSign");
            }
        }

        public static string QuotesDocumentTitle
        {
            get
            {
                return _loader.GetString("QuotesDocumentTitle");
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

        public static string RenderUIDocumentTitle
        {
            get
            {
                return _loader.GetString("RenderUIDocumentTitle");
            }
        }

        public static string ResourceNotFound
        {
            get
            {
                return _loader.GetString("ResourceNotFound");
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

        public static string SaveLocationTip
        {
            get
            {
                return _loader.GetString("SaveLocationTip");
            }
        }

        public static string SavePDFBT_Content
        {
            get
            {
                return _loader.GetString("SavePDFBT_Content");
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

        public static string StringFormatTwoArg
        {
            get
            {
                return _loader.GetString("StringFormatTwoArg");
            }
        }

        public static string SuspensionManagerErrorMessage
        {
            get
            {
                return _loader.GetString("SuspensionManagerErrorMessage");
            }
        }

        public static string TableOfContentsDocumentTitle
        {
            get
            {
                return _loader.GetString("TableOfContentsDocumentTitle");
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

        public static string TextFlowDocumentTitle
        {
            get
            {
                return _loader.GetString("TextFlowDocumentTitle");
            }
        }

        public static string ToggleSwitch_Header
        {
            get
            {
                return _loader.GetString("ToggleSwitch_Header");
            }
        }

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }
    }
}
