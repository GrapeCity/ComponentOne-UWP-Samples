Imports Windows.ApplicationModel.Resources

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FlexChart101Lib/Resources")

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

    Public Shared ReadOnly Property TxtCharttype() As String
        Get
            Return _loader.GetString("txtCharttype")
        End Get
    End Property

    Public Shared ReadOnly Property TxtSelectionMode() As String
        Get
            Return _loader.GetString("txtSelectionMode")
        End Get
    End Property

    Public Shared ReadOnly Property TxtStacking() As String
        Get
            Return _loader.GetString("txtStacking")
        End Get
    End Property

    Public Shared ReadOnly Property TxtAppName() As String
        Get
            Return _loader.GetString("txtAppName")
        End Get
    End Property

    Public Shared ReadOnly Property TxtHeader() As String
        Get
            Return _loader.GetString("txtHeader")
        End Get
    End Property

    Public Shared ReadOnly Property TxtFooter() As String
        Get
            Return _loader.GetString("txtFooter")
        End Get
    End Property

    Public Shared ReadOnly Property TxtAxisX() As String
        Get
            Return _loader.GetString("txtAxisX")
        End Get
    End Property

    Public Shared ReadOnly Property TxtAxisY() As String
        Get
            Return _loader.GetString("txtAxisY")
        End Get
    End Property

    Public Shared ReadOnly Property TxtLegend() As String
        Get
            Return _loader.GetString("txtLegend")
        End Get
    End Property

    Public Shared ReadOnly Property TxtGroupLegend() As String
        Get
            Return _loader.GetString("txtGroupLegend")
        End Get
    End Property

    Public Shared ReadOnly Property TxtPalette() As String
        Get
            Return _loader.GetString("txtPalette")
        End Get
    End Property

    Public Shared ReadOnly Property CbMarch() As String
        Get
            Return _loader.GetString("cbMarch")
        End Get
    End Property

    Public Shared ReadOnly Property CbApril() As String
        Get
            Return _loader.GetString("cbApril")
        End Get
    End Property

    Public Shared ReadOnly Property CbMay() As String
        Get
            Return _loader.GetString("cbMay")
        End Get
    End Property

    Public Shared ReadOnly Property CbRotate() As String
        Get
            Return _loader.GetString("cbRotate")
        End Get
    End Property

    Public Shared ReadOnly Property BtnSlow() As String
        Get
            Return _loader.GetString("btnSlow")
        End Get
    End Property

    Public Shared ReadOnly Property BtnMedium() As String
        Get
            Return _loader.GetString("btnMedium")
        End Get
    End Property

    Public Shared ReadOnly Property BtnFast() As String
        Get
            Return _loader.GetString("btnFast")
        End Get
    End Property

    Public Shared ReadOnly Property BtnStart() As String
        Get
            Return _loader.GetString("btnStart")
        End Get
    End Property

    Public Shared ReadOnly Property BtnStop() As String
        Get
            Return _loader.GetString("btnStop")
        End Get
    End Property

    Public Shared ReadOnly Property BtnOk() As String
        Get
            Return _loader.GetString("btnOk")
        End Get
    End Property

    Public Shared ReadOnly Property Header() As String
        Get
            Return _loader.GetString("Header")
        End Get
    End Property

    Public Shared ReadOnly Property Footer() As String
        Get
            Return _loader.GetString("Footer")
        End Get
    End Property

    Public Shared ReadOnly Property NeckWidth() As String
        Get
            Return _loader.GetString("NeckWidth")
        End Get
    End Property

    Public Shared ReadOnly Property NeckHeight() As String
        Get
            Return _loader.GetString("NeckHeight")
        End Get
    End Property

    Public Shared ReadOnly Property FunnelType() As String
        Get
            Return _loader.GetString("FunnelType")
        End Get
    End Property

#Region "Samples info"

    Public Shared ReadOnly Property GettingStartedName() As String
        Get
            Return _loader.GetString("GettingStartedName")
        End Get
    End Property

    Public Shared ReadOnly Property GettingStartedTitle() As String
        Get
            Return _loader.GetString("GettingStartedTitle")
        End Get
    End Property

    Public Shared ReadOnly Property GettingStartedDescription() As String
        Get
            Return _loader.GetString("GettingStartedDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ChartTypesName() As String
        Get
            Return _loader.GetString("ChartTypesName")
        End Get
    End Property

    Public Shared ReadOnly Property ChartTypesTitle() As String
        Get
            Return _loader.GetString("ChartTypesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ChartTypesDescription() As String
        Get
            Return _loader.GetString("ChartTypesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CustomizingAxesName() As String
        Get
            Return _loader.GetString("CustomizingAxesName")
        End Get
    End Property

    Public Shared ReadOnly Property CustomizingAxesTitle() As String
        Get
            Return _loader.GetString("CustomizingAxesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CustomizingAxesDescription() As String
        Get
            Return _loader.GetString("CustomizingAxesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DynamicName() As String
        Get
            Return _loader.GetString("DynamicName")
        End Get
    End Property

    Public Shared ReadOnly Property DynamicTitle() As String
        Get
            Return _loader.GetString("DynamicTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DynamicDescription() As String
        Get
            Return _loader.GetString("DynamicDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LegendAndTitlesName() As String
        Get
            Return _loader.GetString("LegendAndTitlesName")
        End Get
    End Property

    Public Shared ReadOnly Property LegendAndTitlesTitle() As String
        Get
            Return _loader.GetString("LegendAndTitlesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LegendAndTitlesDescription() As String
        Get
            Return _loader.GetString("LegendAndTitlesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MixedChartTypesName() As String
        Get
            Return _loader.GetString("MixedTypesName")
        End Get
    End Property

    Public Shared ReadOnly Property MixedChartTypesTitle() As String
        Get
            Return _loader.GetString("MixedTypesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MixedChartTypesDescription() As String
        Get
            Return _loader.GetString("MixedTypesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionModesName() As String
        Get
            Return _loader.GetString("SelectionModesName")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionModesTitle() As String
        Get
            Return _loader.GetString("SelectionModesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionModesDescription() As String
        Get
            Return _loader.GetString("SelectionModesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property StylingSeriesName() As String
        Get
            Return _loader.GetString("StylingSeriesName")
        End Get
    End Property

    Public Shared ReadOnly Property StylingSeriesTitle() As String
        Get
            Return _loader.GetString("StylingSeriesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property StylingSeriesDescription() As String
        Get
            Return _loader.GetString("StylingSeriesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ToggleName() As String
        Get
            Return _loader.GetString("ToggleName")
        End Get
    End Property

    Public Shared ReadOnly Property ToggleTitle() As String
        Get
            Return _loader.GetString("ToggleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ToggleDescription() As String
        Get
            Return _loader.GetString("ToggleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TooltipsName() As String
        Get
            Return _loader.GetString("TooltipsName")
        End Get
    End Property

    Public Shared ReadOnly Property TooltipsTitle() As String
        Get
            Return _loader.GetString("TooltipsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TooltipsDescription() As String
        Get
            Return _loader.GetString("TooltipsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FunnelChartName() As String
        Get
            Return _loader.GetString("FunnelChartName")
        End Get
    End Property

    Public Shared ReadOnly Property FunnelChartTitle() As String
        Get
            Return _loader.GetString("FunnelChartTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FunnelChartDescription() As String
        Get
            Return _loader.GetString("FunnelChartDescription")
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

#End Region
End Class