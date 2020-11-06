Imports Windows.ApplicationModel.Resources

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FlexReportSamplesLib/Resources")

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

    Public Shared ReadOnly Property ExportSamplePageName() As String
        Get
            Return _loader.GetString("ExportSamplePageName")
        End Get
    End Property

    Public Shared ReadOnly Property ExportSamplePageTitle() As String
        Get
            Return _loader.GetString("ExportSamplePageTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ExportSamplePageDescription() As String
        Get
            Return _loader.GetString("ExportSamplePageDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PrintSamplePageName() As String
        Get
            Return _loader.GetString("PrintSamplePageName")
        End Get
    End Property

    Public Shared ReadOnly Property PrintSamplePageTitle() As String
        Get
            Return _loader.GetString("PrintSamplePageTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PrintSamplePageDescription() As String
        Get
            Return _loader.GetString("PrintSamplePageDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PreviewErrorFmt() As String
        Get
            Return _loader.GetString("PreviewErrorFmt")
        End Get
    End Property

    Public Shared ReadOnly Property ViewerPaneSamplePageName() As String
        Get
            Return _loader.GetString("ViewerPaneSamplePageName")
        End Get
    End Property

    Public Shared ReadOnly Property ViewerPaneSamplePageTitle() As String
        Get
            Return _loader.GetString("ViewerPaneSamplePageTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ViewerPaneSamplePageDescription() As String
        Get
            Return _loader.GetString("ViewerPaneSamplePageDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ViewerSamplePageName() As String
        Get
            Return _loader.GetString("ViewerSamplePageName")
        End Get
    End Property

    Public Shared ReadOnly Property ViewerSamplePageTitle() As String
        Get
            Return _loader.GetString("ViewerSamplePageTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ViewerSamplePageDescription() As String
        Get
            Return _loader.GetString("ViewerSamplePageDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ZipFiles() As String
        Get
            Return _loader.GetString("ZipFiles")
        End Get
    End Property

    Public Shared ReadOnly Property ExportToFolderFmt() As String
        Get
            Return _loader.GetString("ExportToFolderFmt")
        End Get
    End Property

    Public Shared ReadOnly Property ExportToFileFmt() As String
        Get
            Return _loader.GetString("ExportToFileFmt")
        End Get
    End Property

    Public Shared ReadOnly Property ExportComplete() As String
        Get
            Return _loader.GetString("Export complete")
        End Get
    End Property

    Public Shared ReadOnly Property FailedToExportFmt() As String
        Get
            Return _loader.GetString("FailedToExportFmt")
        End Get
    End Property

    Public Shared ReadOnly Property FailedToLoadFmt() As String
        Get
            Return _loader.GetString("FailedToLoadFmt")
        End Get
    End Property

    Public Shared ReadOnly Property FailedToPrintFmt() As String
        Get
            Return _loader.GetString("FailedToPrintFmt")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property btnExport_Content() As String
        Get
            Return _loader.GetString("btnExport_Content")
        End Get
    End Property

    Public Shared ReadOnly Property btnExportTo_Content() As String
        Get
            Return _loader.GetString("btnExportTo_Content")
        End Get
    End Property

    Public Shared ReadOnly Property C1FlexReport_Text() As String
        Get
            Return _loader.GetString("C1FlexReport_Text")
        End Get
    End Property

    Public Shared ReadOnly Property cbOpenDocument_Content() As String
        Get
            Return _loader.GetString("cbOpenDocument_Content")
        End Get
    End Property

    Public Shared ReadOnly Property cbUseFlexCommonTasks_Content() As String
        Get
            Return _loader.GetString("cbUseFlexCommonTasks_Content")
        End Get
    End Property

    Public Shared ReadOnly Property cbUseZipForMultipleFiles_Content() As String
        Get
            Return _loader.GetString("cbUseZipForMultipleFiles_Content")
        End Get
    End Property

    Public Shared ReadOnly Property lblExportFilter_Text() As String
        Get
            Return _loader.GetString("lblExportFilter_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblReport_Text() As String
        Get
            Return _loader.GetString("lblReport_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblReportFile_Text() As String
        Get
            Return _loader.GetString("lblReportFile_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblZoom_Text() As String
        Get
            Return _loader.GetString("lblZoom_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblPrint_Text() As String
        Get
            Return _loader.GetString("lblPrint_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblActualSize_Text() As String
        Get
            Return _loader.GetString("lblActualSize_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblPageWidth_Text() As String
        Get
            Return _loader.GetString("lblPageWidth_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblWholePage_Text() As String
        Get
            Return _loader.GetString("lblWholePage_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblOnePage_Text() As String
        Get
            Return _loader.GetString("lblOnePage_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblFacingPages_Text() As String
        Get
            Return _loader.GetString("lblFacingPages_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblTwoPages_Text() As String
        Get
            Return _loader.GetString("lblTwoPages_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblFourPages_Text() As String
        Get
            Return _loader.GetString("lblFourPages_Text")
        End Get
    End Property

    Public Shared ReadOnly Property lblPrintLayout_Text() As String
        Get
            Return _loader.GetString("lblPrintLayout_Text")
        End Get
    End Property

    Public Shared ReadOnly Property btnPrint_Content() As String
        Get
            Return _loader.GetString("btnPrint_Content")
        End Get
    End Property
End Class
