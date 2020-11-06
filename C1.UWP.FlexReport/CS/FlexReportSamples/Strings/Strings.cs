using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace FlexReportSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("FlexReportSamplesLib/Resources");

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

        public static string PreviewErrorFmt
        {
            get { return _loader.GetString("PreviewErrorFmt"); }
        }

        public static string ViewerPaneSamplePageName
        {
            get { return _loader.GetString("ViewerPaneSamplePageName"); }
        }

        public static string ViewerPaneSamplePageTitle
        {
            get { return _loader.GetString("ViewerPaneSamplePageTitle"); }
        }

        public static string ViewerPaneSamplePageDescription
        {
            get { return _loader.GetString("ViewerPaneSamplePageDescription"); }
        }

        public static string ViewerSamplePageName
        {
            get { return _loader.GetString("ViewerSamplePageName"); }
        }

        public static string ViewerSamplePageTitle
        {
            get { return _loader.GetString("ViewerSamplePageTitle"); }
        }

        public static string ViewerSamplePageDescription
        {
            get { return _loader.GetString("ViewerSamplePageDescription"); }
        }

        public static string ZipFiles
        {
            get { return _loader.GetString("ZipFiles"); }
        }

        public static string ExportToFolderFmt
        {
            get { return _loader.GetString("ExportToFolderFmt"); }
        }

        public static string ExportToFileFmt
        {
            get { return _loader.GetString("ExportToFileFmt"); }
        }

        public static string ExportComplete
        {
            get { return _loader.GetString("Export complete"); }
        }

        public static string FailedToExportFmt
        {
            get { return _loader.GetString("FailedToExportFmt"); }
        }

        public static string FailedToLoadFmt
        {
            get { return _loader.GetString("FailedToLoadFmt"); }
        }

        public static string FailedToPrintFmt
        {
            get { return _loader.GetString("FailedToPrintFmt"); }
        }

        public static string AppName_Text
        {
            get { return _loader.GetString("AppName_Text"); }
        }

        public static string btnExport_Content
        {
            get { return _loader.GetString("btnExport_Content"); }
        }

        public static string btnExportTo_Content
        {
            get { return _loader.GetString("btnExportTo_Content"); }
        }

        public static string C1FlexReport_Text
        {
            get { return _loader.GetString("C1FlexReport_Text"); }
        }

        public static string cbOpenDocument_Content
        {
            get { return _loader.GetString("cbOpenDocument_Content"); }
        }

        public static string cbUseFlexCommonTasks_Content
        {
            get { return _loader.GetString("cbUseFlexCommonTasks_Content"); }
        }

        public static string cbUseZipForMultipleFiles_Content
        {
            get { return _loader.GetString("cbUseZipForMultipleFiles_Content"); }
        }

        public static string lblExportFilter_Text
        {
            get { return _loader.GetString("lblExportFilter_Text"); }
        }

        public static string lblReport_Text
        {
            get { return _loader.GetString("lblReport_Text"); }
        }

        public static string lblReportFile_Text
        {
            get { return _loader.GetString("lblReportFile_Text"); }
        }

        public static string lblZoom_Text
        {
            get { return _loader.GetString("lblZoom_Text"); }
        }

        public static string lblPrint_Text
        {
            get { return _loader.GetString("lblPrint_Text"); }
        }

        public static string lblActualSize_Text
        {
            get { return _loader.GetString("lblActualSize_Text"); }
        }

        public static string lblPageWidth_Text
        {
            get { return _loader.GetString("lblPageWidth_Text"); }
        }

        public static string lblWholePage_Text
        {
            get { return _loader.GetString("lblWholePage_Text"); }
        }

        public static string lblOnePage_Text
        {
            get { return _loader.GetString("lblOnePage_Text"); }
        }

        public static string lblFacingPages_Text
        {
            get { return _loader.GetString("lblFacingPages_Text"); }
        }

        public static string lblTwoPages_Text
        {
            get { return _loader.GetString("lblTwoPages_Text"); }
        }

        public static string lblFourPages_Text
        {
            get { return _loader.GetString("lblFourPages_Text"); }
        }

        public static string lblPrintLayout_Text
        {
            get { return _loader.GetString("lblPrintLayout_Text"); }
        }

        public static string btnPrint_Content
        {
            get { return _loader.GetString("btnPrint_Content"); }
        }
    }
}
