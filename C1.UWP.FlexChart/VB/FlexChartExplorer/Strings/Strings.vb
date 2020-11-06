Imports Windows.ApplicationModel.Resources

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FlexChartExplorerLib/Resources")

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

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property Charttype_Text() As String
        Get
            Return _loader.GetString("Charttype_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FlexChart_Footer() As String
        Get
            Return _loader.GetString("FlexChart_Footer")
        End Get
    End Property

    Public Shared ReadOnly Property FlexChart_Header() As String
        Get
            Return _loader.GetString("FlexChart_Header")
        End Get
    End Property

    Public Shared ReadOnly Property HitTest_Footer() As String
        Get
            Return _loader.GetString("HitTest_Footer")
        End Get
    End Property

    Public Shared ReadOnly Property HitTest_Header() As String
        Get
            Return _loader.GetString("HitTest_Header")
        End Get
    End Property

    Public Shared ReadOnly Property InnerRadius_Text() As String
        Get
            Return _loader.GetString("InnerRadius_Text")
        End Get
    End Property

    Public Shared ReadOnly Property InterpolateNulls_Content() As String
        Get
            Return _loader.GetString("InterpolateNulls_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Label_Text() As String
        Get
            Return _loader.GetString("Label_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LabelAngle_Text() As String
        Get
            Return _loader.GetString("LabelAngle_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LabelBorder_Content() As String
        Get
            Return _loader.GetString("LabelBorder_Content")
        End Get
    End Property

    Public Shared ReadOnly Property LabelPosition_Text() As String
        Get
            Return _loader.GetString("LabelPosition_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LabelsBorders_Text() As String
        Get
            Return _loader.GetString("LabelsBorders_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LegendToggle_Content() As String
        Get
            Return _loader.GetString("LegendToggle_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Offset_Text() As String
        Get
            Return _loader.GetString("Offset_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Palette_Text() As String
        Get
            Return _loader.GetString("Palette_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SelectedItemOffset_Text() As String
        Get
            Return _loader.GetString("SelectedItemOffset_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SelectedItemPosition_Text() As String
        Get
            Return _loader.GetString("SelectedItemPosition_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionMode_Text() As String
        Get
            Return _loader.GetString("SelectionMode_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Stacking_Text() As String
        Get
            Return _loader.GetString("Stacking_Text")
        End Get
    End Property

    Public Shared ReadOnly Property StartAngle_Text() As String
        Get
            Return _loader.GetString("StartAngle_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Zoom_Content() As String
        Get
            Return _loader.GetString("Zoom_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Rotate_Content() As String
        Get
            Return _loader.GetString("Rotate_Content")
        End Get
    End Property

    Public Shared ReadOnly Property StackedGroup_Content() As String
        Get
            Return _loader.GetString("StackedGroup_Content")
        End Get
    End Property

    Public Shared ReadOnly Property New_Content() As String
        Get
            Return _loader.GetString("New_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Save_Content() As String
        Get
            Return _loader.GetString("Save_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ShowCaption() As String
        Get
            Return _loader.GetString("ShowCaption")
        End Get
    End Property

    Public Shared ReadOnly Property OrderCaption() As String
        Get
            Return _loader.GetString("OrderCaption")
        End Get
    End Property

    Public Shared ReadOnly Property FitTypeCaption() As String
        Get
            Return _loader.GetString("FitTypeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property SettingsCaption() As String
        Get
            Return _loader.GetString("SettingsCaption")
        End Get
    End Property

    Public Shared ReadOnly Property ShowTotal() As String
        Get
            Return _loader.GetString("ShowTotal")
        End Get
    End Property

    Public Shared ReadOnly Property ShowConnectorLines() As String
        Get
            Return _loader.GetString("ShowConnectorLines")
        End Get
    End Property

    Public Shared ReadOnly Property ShowIntermediateTotal() As String
        Get
            Return _loader.GetString("ShowIntermediateTotal")
        End Get
    End Property

    Public Shared ReadOnly Property IsRelativeData() As String
        Get
            Return _loader.GetString("IsRelativeData")
        End Get
    End Property

    Public Shared ReadOnly Property QuartileCalculation_Text() As String
        Get
            Return _loader.GetString("QuartileCalculationText")
        End Get
    End Property

    Public Shared ReadOnly Property ShowMeanLine() As String
        Get
            Return _loader.GetString("ShowMeanLine")
        End Get
    End Property

    Public Shared ReadOnly Property ShowMeanMarks() As String
        Get
            Return _loader.GetString("ShowMeanMarks")
        End Get
    End Property

    Public Shared ReadOnly Property ShowOutliers() As String
        Get
            Return _loader.GetString("ShowOutliers")
        End Get
    End Property

    Public Shared ReadOnly Property ShowInnerPoints() As String
        Get
            Return _loader.GetString("ShowInnerPoints")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorAmount() As String
        Get
            Return _loader.GetString("ErrorAmount")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorBarDirection() As String
        Get
            Return _loader.GetString("ErrorBarDirection")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorBarEndStyle() As String
        Get
            Return _loader.GetString("ErrorBarEndStyle")
        End Get
    End Property

#Region "Samples info"

    Public Shared ReadOnly Property IntroductionName() As String
        Get
            Return _loader.GetString("IntroductionName")
        End Get
    End Property

    Public Shared ReadOnly Property IntroductionTitle() As String
        Get
            Return _loader.GetString("IntroductionTitle")
        End Get
    End Property

    Public Shared ReadOnly Property IntroductionDescription() As String
        Get
            Return _loader.GetString("IntroductionDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BindingName() As String
        Get
            Return _loader.GetString("BindingName")
        End Get
    End Property

    Public Shared ReadOnly Property BindingTitle() As String
        Get
            Return _loader.GetString("BindingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BindingDescription() As String
        Get
            Return _loader.GetString("BindingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SeriesBindingName() As String
        Get
            Return _loader.GetString("SeriesBindingName")
        End Get
    End Property

    Public Shared ReadOnly Property SeriesBindingTitle() As String
        Get
            Return _loader.GetString("SeriesBindingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SereisBindingDescription() As String
        Get
            Return _loader.GetString("SeriesBindingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property HeaderAndFooterName() As String
        Get
            Return _loader.GetString("HeaderAndFooterName")
        End Get
    End Property

    Public Shared ReadOnly Property HeaderAndFooterTitle() As String
        Get
            Return _loader.GetString("HeaderAndFooterTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HeaderAndFooterDescription() As String
        Get
            Return _loader.GetString("HeaderAndFooterDescription")
        End Get
    End Property

    Public Shared ReadOnly Property HitTestName() As String
        Get
            Return _loader.GetString("HitTestName")
        End Get
    End Property

    Public Shared ReadOnly Property HitTestTitle() As String
        Get
            Return _loader.GetString("HitTestTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HitTestDescription() As String
        Get
            Return _loader.GetString("HitTestDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AxesName() As String
        Get
            Return _loader.GetString("AxesName")
        End Get
    End Property

    Public Shared ReadOnly Property AxesTitle() As String
        Get
            Return _loader.GetString("AxesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AxesDescription() As String
        Get
            Return _loader.GetString("AxesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LabelsName() As String
        Get
            Return _loader.GetString("LabelsName")
        End Get
    End Property

    Public Shared ReadOnly Property LabelsTitle() As String
        Get
            Return _loader.GetString("LabelsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LabelsDescription() As String
        Get
            Return _loader.GetString("LabelsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionName() As String
        Get
            Return _loader.GetString("SelectionName")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionTitle() As String
        Get
            Return _loader.GetString("SelectionTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionDescription() As String
        Get
            Return _loader.GetString("SelectionDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ZoomName() As String
        Get
            Return _loader.GetString("ZoomName")
        End Get
    End Property

    Public Shared ReadOnly Property ZoomTitle() As String
        Get
            Return _loader.GetString("ZoomTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ZoomDescription() As String
        Get
            Return _loader.GetString("ZoomDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BubbleName() As String
        Get
            Return _loader.GetString("BubbleName")
        End Get
    End Property

    Public Shared ReadOnly Property BubbleTitle() As String
        Get
            Return _loader.GetString("BubbleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BubbleDescription() As String
        Get
            Return _loader.GetString("BubbleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialName() As String
        Get
            Return _loader.GetString("FinancialName")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialTitle() As String
        Get
            Return _loader.GetString("FinancialTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialDescription() As String
        Get
            Return _loader.GetString("FinancialDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ImageExportName() As String
        Get
            Return _loader.GetString("ImageExportName")
        End Get
    End Property

    Public Shared ReadOnly Property ImageExportTitle() As String
        Get
            Return _loader.GetString("ImageExportTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ImageExportDescription() As String
        Get
            Return _loader.GetString("ImageExportDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PieIntroductionName() As String
        Get
            Return _loader.GetString("PieIntroductionName")
        End Get
    End Property

    Public Shared ReadOnly Property PieIntroductionTitle() As String
        Get
            Return _loader.GetString("PieIntroductionTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PieIntroductionDescription() As String
        Get
            Return _loader.GetString("PieIntroductionDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PieSelectionName() As String
        Get
            Return _loader.GetString("PieSelectionName")
        End Get
    End Property

    Public Shared ReadOnly Property PieSelectionTitle() As String
        Get
            Return _loader.GetString("PieSelectionTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PieSelectionDescription() As String
        Get
            Return _loader.GetString("PieSelectionDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ZonesName() As String
        Get
            Return _loader.GetString("ZonesName")
        End Get
    End Property

    Public Shared ReadOnly Property ZonesTitle() As String
        Get
            Return _loader.GetString("ZonesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ZonesDescription() As String
        Get
            Return _loader.GetString("ZonesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TrendLineName() As String
        Get
            Return _loader.GetString("TrendLineName")
        End Get
    End Property

    Public Shared ReadOnly Property TrendLineTitle() As String
        Get
            Return _loader.GetString("TrendLineTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TrendLineDescription() As String
        Get
            Return _loader.GetString("TrendLineDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BoxWhiskerTitle() As String
        Get
            Return _loader.GetString("BoxWhiskerTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BoxWhiskerDescription() As String
        Get
            Return _loader.GetString("BoxWhiskerDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BoxWhiskerName() As String
        Get
            Return _loader.GetString("BoxWhiskerName")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorBarTitle() As String
        Get
            Return _loader.GetString("ErrorBarTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorBarName() As String
        Get
            Return _loader.GetString("ErrorBarName")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorBarDescription() As String
        Get
            Return _loader.GetString("ErrorBarDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WaterfallName() As String
        Get
            Return _loader.GetString("WaterfallName")
        End Get
    End Property

    Public Shared ReadOnly Property WaterfallTitle() As String
        Get
            Return _loader.GetString("WaterfallTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WaterfallDescription() As String
        Get
            Return _loader.GetString("WaterfallDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PlotAreasTitle() As String
        Get
            Return _loader.GetString("PlotAreasTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PlotAreasDescription() As String
        Get
            Return _loader.GetString("PlotAreasDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PlotAreasName() As String
        Get
            Return _loader.GetString("PlotAreasName")
        End Get
    End Property

    Public Shared ReadOnly Property AxisBindingTitle() As String
        Get
            Return _loader.GetString("AxisBindingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AxisBindingDescription() As String
        Get
            Return _loader.GetString("AxisBindingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AxisBindingName() As String
        Get
            Return _loader.GetString("AxisBindingName")
        End Get
    End Property

    Public Shared ReadOnly Property HistogramTitle() As String
        Get
            Return _loader.GetString("HistogramTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HistogramDescription() As String
        Get
            Return _loader.GetString("HistogramDescription")
        End Get
    End Property

    Public Shared ReadOnly Property HistogramName() As String
        Get
            Return _loader.GetString("HistogramName")
        End Get
    End Property

    Public Shared ReadOnly Property RangedHistogramTitle() As String
        Get
            Return _loader.GetString("RangedHistogramTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RangedHistogramDescription() As String
        Get
            Return _loader.GetString("RangedHistogramDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RangedHistogramName() As String
        Get
            Return _loader.GetString("RangedHistogramName")
        End Get
    End Property
#End Region

#Region "ChartType"

    Public Shared ReadOnly Property Bar() As String
        Get
            Return _loader.GetString("Bar")
        End Get
    End Property

    Public Shared ReadOnly Property Column() As String
        Get
            Return _loader.GetString("Column")
        End Get
    End Property

    Public Shared ReadOnly Property Line() As String
        Get
            Return _loader.GetString("Line")
        End Get
    End Property

    Public Shared ReadOnly Property Scatter() As String
        Get
            Return _loader.GetString("Scatter")
        End Get
    End Property

    Public Shared ReadOnly Property LineSymbols() As String
        Get
            Return _loader.GetString("LineSymbols")
        End Get
    End Property

    Public Shared ReadOnly Property Area() As String
        Get
            Return _loader.GetString("Area")
        End Get
    End Property

    Public Shared ReadOnly Property Spline() As String
        Get
            Return _loader.GetString("Spline")
        End Get
    End Property

    Public Shared ReadOnly Property SplineSymbols() As String
        Get
            Return _loader.GetString("SplineSymbols")
        End Get
    End Property

    Public Shared ReadOnly Property SplineArea() As String
        Get
            Return _loader.GetString("SplineArea")
        End Get
    End Property

    Public Shared ReadOnly Property StepType() As String
        Get
            Return _loader.GetString("Step")
        End Get
    End Property

    Public Shared ReadOnly Property StepSymbols() As String
        Get
            Return _loader.GetString("StepSymbols")
        End Get
    End Property

    Public Shared ReadOnly Property StepArea() As String
        Get
            Return _loader.GetString("StepArea")
        End Get
    End Property

    Public Shared ReadOnly Property Candlestick() As String
        Get
            Return _loader.GetString("Candlestick")
        End Get
    End Property

    Public Shared ReadOnly Property HighLowOpenClose() As String
        Get
            Return _loader.GetString("HighLowOpenClose")
        End Get
    End Property

    Public Shared ReadOnly Property LegendName() As String
        Get
            Return _loader.GetString("LegendName")
        End Get
    End Property

    Public Shared ReadOnly Property LegendTitle() As String
        Get
            Return _loader.GetString("LegendTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LegendDescription() As String
        Get
            Return _loader.GetString("LegendDescription")
        End Get
    End Property

#End Region

#Region "Legend"

    Public Shared ReadOnly Property LegendPosition_Text() As String
        Get
            Return _loader.GetString("LegendPosition_Text")
        End Get
    End Property
    Public Shared ReadOnly Property LegendOrientation_Text() As String
        Get
            Return _loader.GetString("LegendOrientation_Text")
        End Get
    End Property
    Public Shared ReadOnly Property LegendTextWrapping_Text() As String
        Get
            Return _loader.GetString("LegendTextWrapping_Text")
        End Get
    End Property
    Public Shared ReadOnly Property LegendMaxWidth_Text() As String
        Get
            Return _loader.GetString("LegendMaxWidth_Text")
        End Get
    End Property
#End Region



End Class