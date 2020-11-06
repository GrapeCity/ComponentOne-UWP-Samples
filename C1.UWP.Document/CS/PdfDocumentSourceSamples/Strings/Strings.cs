using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace PdfDocumentSourceSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("PdfDocumentSourceSamplesLib/Resources");

        public static string UniqueIdItemsArgumentException
        {
            get { return _loader.GetString("UniqueIdItemsArgumentException"); }
        }

        public static string SessionStateErrorMessage
        {
            get { return _loader.GetString("SessionStateErrorMessage"); }
        }

        public static string SessionStateKeyErrorMessage
        {
            get { return _loader.GetString("SessionStateKeyErrorMessage"); }
        }

        public static string SuspensionManagerErrorMessage
        {
            get { return _loader.GetString("SuspensionManagerErrorMessage"); }
        }

        public static string InitializationException
        {
            get { return _loader.GetString("InitializationException"); }
        }

        public static string PdfViewSamplePageName
        {
            get { return _loader.GetString("PdfViewSamplePageName"); }
        }

        public static string PdfViewSamplePageTitle
        {
            get { return _loader.GetString("PdfViewSamplePageTitle"); }
        }

        public static string PdfViewSamplePageDescription
        {
            get { return _loader.GetString("PdfViewSamplePageDescription"); }
        }

        public static string ExportSamplePageName
        {
            get { return _loader.GetString("ExportSamplePageName"); }
        }

        public static string ExportSamplePageTitle
        {
            get { return _loader.GetString("ExportSamplePageTitle"); }
        }

        public static string ExportSamplePageDescription
        {
            get { return _loader.GetString("ExportSamplePageDescription"); }
        }

        public static string AppName_Text
        {
            get { return _loader.GetString("AppName_Text"); }
        }

        public static string OpenToolLabel
        {
            get { return _loader.GetString("OpenToolLabel"); }
        }

        public static string CloseToolLabel
        {
            get { return _loader.GetString("CloseToolLabel"); }
        }

        public static string UseSystemRenderingToolLabel
        {
            get { return _loader.GetString("UseSystemRendering"); }
        }

        public static string PasswordTitleLabel
        {
            get { return _loader.GetString("PasswordTitleLabel"); }
        }

        public static string PasswordOpenLabel
        {
            get { return _loader.GetString("PasswordOpenLabel"); }
        }

        public static string PasswordCancelLabel
        {
            get { return _loader.GetString("PasswordCancelLabel"); }
        }

        public static string ShowPasswordCheck
        {
            get { return _loader.GetString("ShowPasswordCheck"); }
        }

        public static string ErrorTitle
        {
            get { return _loader.GetString("ErrorTitle"); }
        }

        public static string PdfErrorFormat
        {
            get { return _loader.GetString("PdfErrorFormat"); }
        }

        public static string ZipFiles
        {
            get { return _loader.GetString("ZipFiles"); }
        }

        public static string FileNotSpecified
        {
            get { return _loader.GetString("FileNotSpecified"); }
        }

        public static string lblFile_Text
        {
            get { return _loader.GetString("lblFile_Text"); }
        }

        public static string cbxUseSystemRendering_Text
        {
            get { return _loader.GetString("cbxUseSystemRendering_Text"); }
        }

        public static string lblExportProvider_Text
        {
            get { return _loader.GetString("lblExportProvider_Text"); }
        }

        public static string cbxUseZipForMultipleFiles_Text
        {
            get { return _loader.GetString("cbxUseZipForMultipleFiles_Text"); }
        }

        public static string btnExport_Text
        {
            get { return _loader.GetString("btnExport_Text"); }
        }

        public static string btnPrint_Text
        {
            get { return _loader.GetString("btnPrint_Text"); }
        }

        public static string FailedToExportFmt
        {
            get { return _loader.GetString("FailedToExportFmt"); }
        }

        public static string FailedToPrintFmt
        {
            get { return _loader.GetString("FailedToPrintFmt"); }
        }

        public static string PrintSamplePageName
        {
            get { return _loader.GetString("PrintSamplePageName"); }
        }

        public static string PrintSamplePageTitle
        {
            get { return _loader.GetString("PrintSamplePageTitle"); }
        }

        public static string PrintSamplePageDescription
        {
            get { return _loader.GetString("PrintSamplePageDescription"); }
        }
    }
}
