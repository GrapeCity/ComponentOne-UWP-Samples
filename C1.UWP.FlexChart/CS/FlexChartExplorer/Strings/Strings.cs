using Windows.ApplicationModel.Resources;

namespace FlexChartExplorer
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("FlexChartExplorerLib/Resources");

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

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string Charttype_Text
        {
            get
            {
                return _loader.GetString("Charttype_Text");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string FlexChart_Footer
        {
            get
            {
                return _loader.GetString("FlexChart_Footer");
            }
        }

        public static string FlexChart_Header
        {
            get
            {
                return _loader.GetString("FlexChart_Header");
            }
        }

        public static string HitTest_Footer
        {
            get
            {
                return _loader.GetString("HitTest_Footer");
            }
        }

        public static string HitTest_Header
        {
            get
            {
                return _loader.GetString("HitTest_Header");
            }
        }

        public static string InnerRadius_Text
        {
            get
            {
                return _loader.GetString("InnerRadius_Text");
            }
        }

        public static string InterpolateNulls_Content
        {
            get
            {
                return _loader.GetString("InterpolateNulls_Content");
            }
        }

        public static string Label_Text
        {
            get
            {
                return _loader.GetString("Label_Text");
            }
        }

        public static string LabelAngle_Text
        {
            get
            {
                return _loader.GetString("LabelAngle_Text");
            }
        }

        public static string LabelBorder_Content
        {
            get
            {
                return _loader.GetString("LabelBorder_Content");
            }
        }

        public static string LabelPosition_Text
        {
            get
            {
                return _loader.GetString("LabelPosition_Text");
            }
        }

        public static string LabelsBorders_Text
        {
            get
            {
                return _loader.GetString("LabelsBorders_Text");
            }
        }

        public static string LegendToggle_Content
        {
            get
            {
                return _loader.GetString("LegendToggle_Content");
            }
        }

        public static string Offset_Text
        {
            get
            {
                return _loader.GetString("Offset_Text");
            }
        }

        public static string Palette_Text
        {
            get
            {
                return _loader.GetString("Palette_Text");
            }
        }

        public static string SelectedItemOffset_Text
        {
            get
            {
                return _loader.GetString("SelectedItemOffset_Text");
            }
        }

        public static string SelectedItemPosition_Text
        {
            get
            {
                return _loader.GetString("SelectedItemPosition_Text");
            }
        }

        public static string SelectionMode_Text
        {
            get
            {
                return _loader.GetString("SelectionMode_Text");
            }
        }

        public static string Stacking_Text
        {
            get
            {
                return _loader.GetString("Stacking_Text");
            }
        }

        public static string StartAngle_Text
        {
            get
            {
                return _loader.GetString("StartAngle_Text");
            }
        }

        public static string Zoom_Content
        {
            get
            {
                return _loader.GetString("Zoom_Content");
            }
        }

        public static string Rotate_Content
        {
            get
            {
                return _loader.GetString("Rotate_Content");
            }
        }

        public static string StackedGroup_Content
        {
            get
            {
                return _loader.GetString("StackedGroup_Content");
            }
        }

        public static string New_Content
        {
            get
            {
                return _loader.GetString("New_Content");
            }
        }

        public static string Save_Content
        {
            get
            {
                return _loader.GetString("Save_Content");
            }
        }

        public static string ShowCaption
        {
            get
            {
                return _loader.GetString("ShowCaption");
            }
        }

        public static string OrderCaption
        {
            get
            {
                return _loader.GetString("OrderCaption");
            }
        }

        public static string FitTypeCaption
        {
            get
            {
                return _loader.GetString("FitTypeCaption");
            }
        }

        public static string SettingsCaption
        {
            get
            {
                return _loader.GetString("SettingsCaption");
            }
        }

        public static string ShowTotal
        {
            get
            {
                return _loader.GetString("ShowTotal");
            }
        }

        public static string ShowConnectorLines
        {
            get
            {
                return _loader.GetString("ShowConnectorLines");
            }
        }

        public static string ShowIntermediateTotal
        {
            get
            {
                return _loader.GetString("ShowIntermediateTotal");
            }
        }

        public static string IsRelativeData
        {
            get
            {
                return _loader.GetString("IsRelativeData");
            }
        }

        #region Samples info

        public static string IntroductionName
        {
            get
            {
                return _loader.GetString("IntroductionName");
            }
        }

        public static string IntroductionTitle
        {
            get
            {
                return _loader.GetString("IntroductionTitle");
            }
        }

        public static string IntroductionDescription
        {
            get
            {
                return _loader.GetString("IntroductionDescription");
            }
        }

        public static string AxisGroupingName
        {
            get
            {
                return _loader.GetString("AxisGroupingName");
            }
        }

        public static string AxisGroupingTitle
        {
            get
            {
                return _loader.GetString("AxisGroupingTitle");
            }
        }

        public static string AxisGroupingDescription
        {
            get
            {
                return _loader.GetString("AxisGroupingDescription");
            }
        }

        public static string NumericAxisGroupingName
        {
            get
            {
                return _loader.GetString("NumericAxisGroupingName");
            }
        }

        public static string NumericAxisGroupingTitle
        {
            get
            {
                return _loader.GetString("NumericAxisGroupingTitle");
            }
        }

        public static string NumericAxisGroupingDescription
        {
            get
            {
                return _loader.GetString("NumericAxisGroupingDescription");
            }
        }

        public static string DateTimeAxisGroupingName
        {
            get
            {
                return _loader.GetString("DateTimeAxisGroupingName");
            }
        }

        public static string DateTimeAxisGroupingTitle
        {
            get
            {
                return _loader.GetString("DateTimeAxisGroupingTitle");
            }
        }

        public static string DateTimeAxisGroupingDescription
        {
            get
            {
                return _loader.GetString("DateTimeAxisGroupingDescription");
            }
        }


        public static string BindingName
        {
            get
            {
                return _loader.GetString("BindingName");
            }
        }

        public static string BindingTitle
        {
            get
            {
                return _loader.GetString("BindingTitle");
            }
        }

        public static string BindingDescription
        {
            get
            {
                return _loader.GetString("BindingDescription");
            }
        }

        public static string SeriesBindingName
        {
            get
            {
                return _loader.GetString("SeriesBindingName");
            }
        }

        public static string SeriesBindingTitle
        {
            get
            {
                return _loader.GetString("SeriesBindingTitle");
            }
        }

        public static string SereisBindingDescription
        {
            get
            {
                return _loader.GetString("SeriesBindingDescription");
            }
        }

        public static string HeaderAndFooterName
        {
            get
            {
                return _loader.GetString("HeaderAndFooterName");
            }
        }

        public static string HeaderAndFooterTitle
        {
            get
            {
                return _loader.GetString("HeaderAndFooterTitle");
            }
        }

        public static string HeaderAndFooterDescription
        {
            get
            {
                return _loader.GetString("HeaderAndFooterDescription");
            }
        }

        public static string HitTestName
        {
            get
            {
                return _loader.GetString("HitTestName");
            }
        }

        public static string HitTestTitle
        {
            get
            {
                return _loader.GetString("HitTestTitle");
            }
        }

        public static string HitTestDescription
        {
            get
            {
                return _loader.GetString("HitTestDescription");
            }
        }

        public static string AxesName
        {
            get
            {
                return _loader.GetString("AxesName");
            }
        }

        public static string AxesTitle
        {
            get
            {
                return _loader.GetString("AxesTitle");
            }
        }

        public static string AxesDescription
        {
            get
            {
                return _loader.GetString("AxesDescription");
            }
        }

        public static string AxisLabelsName
        {
            get
            {
                return _loader.GetString("AxisLabelsName");
            }
        }

        public static string AxisLabelsTitle
        {
            get
            {
                return _loader.GetString("AxisLabelsTitle");
            }
        }

        public static string AxisLabelsDescription
        {
            get
            {
                return _loader.GetString("AxisLabelsDescription");
            }
        }

        public static string OverlappingLabels_Caption
        {
            get
            {
                return _loader.GetString("OverlappingLabels_Caption");
            }
        }

        public static string StaggeredLines_Caption
        {
            get
            {
                return _loader.GetString("StaggeredLines_Caption");
            }
        }

        public static string LabelsName
        {
            get
            {
                return _loader.GetString("LabelsName");
            }
        }

        public static string LabelsTitle
        {
            get
            {
                return _loader.GetString("LabelsTitle");
            }
        }

        public static string LabelsDescription
        {
            get
            {
                return _loader.GetString("LabelsDescription");
            }
        }

        public static string AutoLabelsName
        {
            get
            {
                return _loader.GetString("AutoLabelsName");
            }
        }

        public static string AutoLabelsTitle
        {
            get
            {
                return _loader.GetString("AutoLabelsTitle");
            }
        }

        public static string AutoLabelsDescription
        {
            get
            {
                return _loader.GetString("AutoLabelsDescription");
            }
        }

        public static string SelectionName
        {
            get
            {
                return _loader.GetString("SelectionName");
            }
        }

        public static string SelectionTitle
        {
            get
            {
                return _loader.GetString("SelectionTitle");
            }
        }

        public static string SelectionDescription
        {
            get
            {
                return _loader.GetString("SelectionDescription");
            }
        }

        public static string ZoomName
        {
            get
            {
                return _loader.GetString("ZoomName");
            }
        }

        public static string ZoomTitle
        {
            get
            {
                return _loader.GetString("ZoomTitle");
            }
        }

        public static string ZoomDescription
        {
            get
            {
                return _loader.GetString("ZoomDescription");
            }
        }

        public static string BubbleName
        {
            get
            {
                return _loader.GetString("BubbleName");
            }
        }

        public static string BubbleTitle
        {
            get
            {
                return _loader.GetString("BubbleTitle");
            }
        }

        public static string BubbleDescription
        {
            get
            {
                return _loader.GetString("BubbleDescription");
            }
        }

        public static string FinancialName
        {
            get
            {
                return _loader.GetString("FinancialName");
            }
        }

        public static string FinancialTitle
        {
            get
            {
                return _loader.GetString("FinancialTitle");
            }
        }

        public static string FinancialDescription
        {
            get
            {
                return _loader.GetString("FinancialDescription");
            }
        }

        public static string ImageExportName
        {
            get
            {
                return _loader.GetString("ImageExportName");
            }
        }

        public static string ImageExportTitle
        {
            get
            {
                return _loader.GetString("ImageExportTitle");
            }
        }

        public static string ImageExportDescription
        {
            get
            {
                return _loader.GetString("ImageExportDescription");
            }
        }

        public static string PieIntroductionName
        {
            get
            {
                return _loader.GetString("PieIntroductionName");
            }
        }

        public static string PieIntroductionTitle
        {
            get
            {
                return _loader.GetString("PieIntroductionTitle");
            }
        }

        public static string PieIntroductionDescription
        {
            get
            {
                return _loader.GetString("PieIntroductionDescription");
            }
        }

        public static string PieSelectionName
        {
            get
            {
                return _loader.GetString("PieSelectionName");
            }
        }

        public static string PieSelectionTitle
        {
            get
            {
                return _loader.GetString("PieSelectionTitle");
            }
        }

        public static string PieSelectionDescription
        {
            get
            {
                return _loader.GetString("PieSelectionDescription");
            }
        }

        public static string MultiPieName
        {
            get
            {
                return _loader.GetString("MultiPieName");
            }
        }

        public static string MultiPieTitle
        {
            get
            {
                return _loader.GetString("MultiPieTitle");
            }
        }

        public static string MultiPieDescription
        {
            get
            {
                return _loader.GetString("MultiPieDescription");
            }
        }

        public static string Show_Text
        {
            get
            {
                return _loader.GetString("Show_Text");
            }
        }

        public static string ZonesName
        {
            get
            {
                return _loader.GetString("ZonesName");
            }
        }

        public static string ZonesTitle
        {
            get
            {
                return _loader.GetString("ZonesTitle");
            }
        }

        public static string ZonesDescription
        {
            get
            {
                return _loader.GetString("ZonesDescription");
            }
        }

        public static string TrendLineName
        {
            get
            {
                return _loader.GetString("TrendLineName");
            }
        }

        public static string TrendLineTitle
        {
            get
            {
                return _loader.GetString("TrendLineTitle");
            }
        }

        public static string TrendLineDescription
        {
            get
            {
                return _loader.GetString("TrendLineDescription");
            }
        }

        public static string WaterfallName
        {
            get
            {
                return _loader.GetString("WaterfallName");
            }
        }

        public static string WaterfallTitle
        {
            get
            {
                return _loader.GetString("WaterfallTitle");
            }
        }

        public static string WaterfallDescription
        {
            get
            {
                return _loader.GetString("WaterfallDescription");
            }
        }

        public static string AxisBindingTitle
        {
            get
            {
                return _loader.GetString("AxisBindingTitle");
            }
        }

        public static string AxisBindingDescription
        {
            get
            {
                return _loader.GetString("AxisBindingDescription");
            }
        }

        public static string AxisBindingName
        {
            get
            {
                return _loader.GetString("AxisBindingName");
            }
        }

        public static string DataShape_Text
        {
            get
            {
                return _loader.GetString("DataShape_Text");
            }
        }

        public static string OverlappedLabels_Text
        {
            get
            {
                return _loader.GetString("OverlappedLabels_Text");
            }
        }

        #endregion

        #region ChartType

        public static string Bar
        {
            get
            {
                return _loader.GetString("Bar");
            }
        }

        public static string Column
        {
            get
            {
                return _loader.GetString("Column");
            }
        }

        public static string Line
        {
            get
            {
                return _loader.GetString("Line");
            }
        }

        public static string Scatter
        {
            get
            {
                return _loader.GetString("Scatter");
            }
        }

        public static string LineSymbols
        {
            get
            {
                return _loader.GetString("LineSymbols");
            }
        }

        public static string Area
        {
            get
            {
                return _loader.GetString("Area");
            }
        }

        public static string Spline
        {
            get
            {
                return _loader.GetString("Spline");
            }
        }

        public static string SplineSymbols
        {
            get
            {
                return _loader.GetString("SplineSymbols");
            }
        }

        public static string SplineArea
        {
            get
            {
                return _loader.GetString("SplineArea");
            }
        }

        public static string Step
        {
            get
            {
                return _loader.GetString("Step");
            }
        }

        public static string StepSymbols
        {
            get
            {
                return _loader.GetString("StepSymbols");
            }
        }

        public static string StepArea
        {
            get
            {
                return _loader.GetString("StepArea");
            }
        }

        public static string Candlestick
        {
            get
            {
                return _loader.GetString("Candlestick");
            }
        }

        public static string HighLowOpenClose
        {
            get
            {
                return _loader.GetString("HighLowOpenClose");
            }
        }

        public static string InclusiveMedian
        {
            get
            {
                return _loader.GetString("InclusiveMedian");
            }
        }
        public static string ExclusiveMedian
        {
            get
            {
                return _loader.GetString("ExclusiveMedian");
            }
        }

        public static string BoxWhiskerTitle
        {
            get
            {
                return _loader.GetString("BoxWhiskerTitle");
            }
        }
        public static string BoxWhiskerDescription
        {
            get
            {
                return _loader.GetString("BoxWhiskerDescription");
            }
        }
        public static string BoxWhiskerName
        {
            get
            {
                return _loader.GetString("BoxWhiskerName");
            }
        }

        public static string QuartileCalculation_Text
        {
            get
            {
                return _loader.GetString("QuartileCalculationText");
            }
        }

        public static string ShowMeanLine
        {
            get
            {
                return _loader.GetString("ShowMeanLine");
            }
        }

        public static string ShowMeanMarks
        {
            get
            {
                return _loader.GetString("ShowMeanMarks");
            }
        }

        public static string ShowOutliers
        {
            get
            {
                return _loader.GetString("ShowOutliers");
            }
        }

        public static string ShowInnerPoints
        {
            get
            {
                return _loader.GetString("ShowInnerPoints");
            }
        }

        public static string ErrorAmount
        {
            get
            {
                return _loader.GetString("ErrorAmount");
            }
        }
      
        public static string ErrorBarDirection
        {
            get
            {
                return _loader.GetString("ErrorBarDirection");
            }
        }

        public static string ErrorBarEndStyle
        {
            get
            {
                return _loader.GetString("ErrorBarEndStyle");
            }
        }

        public static string ErrorBarTitle
        {
            get
            {
                return _loader.GetString("ErrorBarTitle");
            }
        }

        public static string ErrorBarName
        {
            get
            {
                return _loader.GetString("ErrorBarName");
            }
        }

        public static string ErrorBarDescription
        {
            get
            {
                return _loader.GetString("ErrorBarDescription");
            }
        }

        public static string PlotAreasTitle
        {
            get
            {
                return _loader.GetString("PlotAreasTitle");
            }
        }

        public static string PlotAreasDescription
        {
            get
            {
                return _loader.GetString("PlotAreasDescription");
            }

         }
        public static string PlotAreasName
        {
            get
            {
                return _loader.GetString("PlotAreasName");
            }
        }

        public static string LegendPosition_Text
        {
            get
            {
                return _loader.GetString("LegendPosition_Text");
            }
        }

        public static string LegendOrientation_Text
        {
            get
            {
                return _loader.GetString("LegendOrientation_Text");
            }
        }

        public static string LegendTextWrapping_Text
        {
            get
            {
                return _loader.GetString("LegendTextWrapping_Text");
            }
        }

        public static string LegendMaxWidth_Text
        {
            get
            {
                return _loader.GetString("LegendMaxWidth_Text");
            }
        }

        public static string LegendName
        {
            get
            {
                return _loader.GetString("LegendName");
            }
        }

        public static string LegendTitle
        {
            get
            {
                return _loader.GetString("LegendTitle");
            }
        }
        public static string LegendDescription
        {
            get
            {
                return _loader.GetString("LegendDescription");
            }
        }

        public static string TreeMapName
        {
            get
            {
                return _loader.GetString("TreeMapName");
            }
        }

        public static string TreeMapTitle
        {
            get
            {
                return _loader.GetString("TreeMapTitle");
            }
        }
        public static string TreeMapDescription
        {
            get
            {
                return _loader.GetString("TreeMapDescription");
            }
        }

        public static string TreeMapNodeColorName
        {
            get
            {
                return _loader.GetString("TreeMapNodeColorName");
            }
        }

        public static string TreeMapNodeColorTitle
        {
            get
            {
                return _loader.GetString("TreeMapNodeColorTitle");
            }
        }
        public static string TreeMapNodeColorDescription
        {
            get
            {
                return _loader.GetString("TreeMapNodeColorDescription");
            }
        }


        public static string HistogramName
        {
            get
            {
                return _loader.GetString("HistogramName");
            }
        }

        public static string HistogramTitle
        {
            get
            {
                return _loader.GetString("HistogramTitle");
            }
        }
        public static string HistogramDescription
        {
            get
            {
                return _loader.GetString("HistogramDescription");
            }
        }

        public static string RangedHistogramName
        {
            get
            {
                return _loader.GetString("RangedHistogramName");
            }
        }

        public static string RangedHistogramTitle
        {
            get
            {
                return _loader.GetString("RangedHistogramTitle");
            }
        }
        public static string RangedHistogramDescription
        {
            get
            {
                return _loader.GetString("RangedHistogramDescription");
            }
        }

        public static string FrequencyPolygonName
        {
            get
            {
                return _loader.GetString("FrequencyPolygonName");
            }
        }

        public static string FrequencyPolygonTitle
        {
            get
            {
                return _loader.GetString("FrequencyPolygonTitle");
            }
        }
        public static string FrequencyPolygonDescription
        {
            get
            {
                return _loader.GetString("FrequencyPolygonDescription");
            }
        }

        public static string MaxDepth_Text
        {
            get
            {
                return _loader.GetString("MaxDepth_Text");
            }
        }

        public static string Labels_Text
        {
            get
            {
                return _loader.GetString("Labels_Text");
            }
        }

        public static string ParetoName
        {
            get
            {
                return _loader.GetString("ParetoName");
            }
        }

        public static string ParetoTitle
        {
            get
            {
                return _loader.GetString("ParetoTitle");
            }
        }
        public static string ParetoDescription
        {
            get
            {
                return _loader.GetString("ParetoDescription");
            }
        }

        #endregion
    }
}
