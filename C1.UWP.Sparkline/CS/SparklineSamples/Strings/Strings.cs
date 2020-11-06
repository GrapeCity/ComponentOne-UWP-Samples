using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace SparklineSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("SparklineSamplesLib/Resources");

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

        public static string SparklineSamplesOverviewTitle
        {
            get
            {
                return _loader.GetString("SparklineSamplesOverviewTitle");
            }
        }

        public static string SparklineSamplesOverviewDescription
        {
            get
            {
                return _loader.GetString("SparklineSamplesOverviewDescription");
            }
        }

        public static string SparklineSamplesOverviewName
        {
            get
            {
                return _loader.GetString("SparklineSamplesOverviewName");
            }
        }

        public static string SparklineSamplesAppearanceTitle
        {
            get
            {
                return _loader.GetString("SparklineSamplesAppearanceTitle");
            }
        }

        public static string SparklineSamplesAppearanceDescription
        {
            get
            {
                return _loader.GetString("SparklineSamplesAppearanceDescription");
            }
        }

        public static string SparklineSamplesAppearanceName
        {
            get
            {
                return _loader.GetString("SparklineSamplesAppearanceName");
            }
        }

        public static string SparklineSamplesListBoxTitle
        {
            get
            {
                return _loader.GetString("SparklineSamplesListBoxTitle");
            }
        }

        public static string SparklineSamplesListBoxDescription
        {
            get
            {
                return _loader.GetString("SparklineSamplesListBoxDescription");
            }
        }

        public static string SparklineSamplesListBoxName
        {
            get
            {
                return _loader.GetString("SparklineSamplesListBoxName");
            }
        }

        public static string SparklineSamplesFlexGridIntegrationTitle
        {
            get
            {
                return _loader.GetString("SparklineSamplesFlexGridIntegrationTitle");
            }
        }

        public static string SparklineSamplesFlexGridIntegrationDescription
        {
            get
            {
                return _loader.GetString("SparklineSamplesFlexGridIntegrationDescription");
            }
        }

        public static string SparklineSamplesFlexGridIntegrationName
        {
            get
            {
                return _loader.GetString("SparklineSamplesFlexGridIntegrationName");
            }
        }


        public static string StatesColumnValue
        {
            get
            {
                return _loader.GetString("StatesColumnValue");
            }
        }

        public static string SkyBlueColor
        {
            get
            {
                return _loader.GetString("SkyBlueColor");
            }
        }

        public static string GoldColor
        {
            get
            {
                return _loader.GetString("GoldColor");
            }
        }

        public static string SandyBrownColor
        {
            get
            {
                return _loader.GetString("SandyBrownColor");
            }
        }

        public static string LightPinkColor
        {
            get
            {
                return _loader.GetString("LightPinkColor");
            }
        }

        public static string GrayColor
        {
            get
            {
                return _loader.GetString("GrayColor");
            }
        }

        public static string MediumOrchidColor
        {
            get
            {
                return _loader.GetString("MediumOrchidColor");
            }
        }

        public static string LightCoralColor
        {
            get
            {
                return _loader.GetString("LightCoralColor");
            }
        }

        public static string LightGreenColor
        {
            get
            {
                return _loader.GetString("LightGreenColor");
            }
        }

        public static string DarkKhakiColor
        {
            get
            {
                return _loader.GetString("DarkKhakiColor");
            }
        }

        public static string SparklineTypeTB_Text
        {
            get
            {
                return _loader.GetString("SparklineTypeTB_Text");
            }
        }

        public static string DisplayDateAxisTB_Text
        {
            get
            {
                return _loader.GetString("DisplayDateAxisTB_Text");
            }
        }

        public static string NewDataBT_Content
        {
            get
            {
                return _loader.GetString("NewDataBT_Content");
            }
        }

        public static string ShowMarksTB_Text
        {
            get
            {
                return _loader.GetString("ShowMarksTB_Text");
            }
        }

        public static string DisplayXAxisTB_Text
        {
            get
            {
                return _loader.GetString("DisplayXAxisTB_Text");
            }
        }

        public static string ShowFirstTB_Text
        {
            get
            {
                return _loader.GetString("ShowFirstTB_Text");
            }
        }

        public static string ShowLastTB_Text
        {
            get
            {
                return _loader.GetString("ShowLastTB_Text");
            }
        }

        public static string ShowHighTB_Text
        {
            get
            {
                return _loader.GetString("ShowHighTB_Text");
            }
        }

        public static string ShowLowTB_Text
        {
            get
            {
                return _loader.GetString("ShowLowTB_Text");
            }
        }

        public static string ShowNegativeTB_Text
        {
            get
            {
                return _loader.GetString("ShowNegativeTB_Text");
            }
        }

        public static string SeriesColorTB_Text
        {
            get
            {
                return _loader.GetString("SeriesColorTB_Text");
            }
        }

        public static string AxisColorTB_Text
        {
            get
            {
                return _loader.GetString("AxisColorTB_Text");
            }
        }

        public static string MarksColorTB_Text
        {
            get
            {
                return _loader.GetString("MarksColorTB_Text");
            }
        }

        public static string FirstMarkColorTB_Text
        {
            get
            {
                return _loader.GetString("FirstMarkColorTB_Text");
            }
        }

        public static string LastMarkColorTB_Text
        {
            get
            {
                return _loader.GetString("LastMarkColorTB_Text");
            }
        }

        public static string HighMarkColorTB_Text
        {
            get
            {
                return _loader.GetString("HighMarkColorTB_Text");
            }
        }

        public static string LowMarkColorTB_Text
        {
            get
            {
                return _loader.GetString("LowMarkColorTB_Text");
            }
        }

        public static string NegativeColorTB_Text
        {
            get
            {
                return _loader.GetString("NegativeColorTB_Text");
            }
        }

        public static string MarksCB_Content
        {
            get
            {
                return _loader.GetString("MarksCB_Content");
            }
        }

        public static string XAxisCB_Content
        {
            get
            {
                return _loader.GetString("XAxisCB_Content");
            }
        }

        public static string FirstCB_Content
        {
            get
            {
                return _loader.GetString("FirstCB_Content");
            }
        }

        public static string LastCB_Content
        {
            get
            {
                return _loader.GetString("LastCB_Content");
            }
        }

        public static string HighCB_Content
        {
            get
            {
                return _loader.GetString("HighCB_Content");
            }
        }

        public static string LowCB_Content
        {
            get
            {
                return _loader.GetString("LowCB_Content");
            }
        }

        public static string NegativeCB_Content
        {
            get
            {
                return _loader.GetString("NegativeCB_Content");
            }
        }

        public static string RegionTB_Text
        {
            get
            {
                return _loader.GetString("RegionTB_Text");
            }
        }

        public static string TotalSaleTB_Text
        {
            get
            {
                return _loader.GetString("TotalSaleTB_Text");
            }
        }

        public static string SalesTrendTB_Text
        {
            get
            {
                return _loader.GetString("SalesTrendTB_Text");
            }
        }

        public static string WinLossTB_Text
        {
            get
            {
                return _loader.GetString("WinLossTB_Text");
            }
        }

        public static string ProfitTrendTB_Text
        {
            get
            {
                return _loader.GetString("ProfitTrendTB_Text");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string LineType
        {
            get
            {
                return _loader.GetString("LineType");
            }
        }

        public static string ColumnType
        {
            get
            {
                return _loader.GetString("ColumnType");
            }
        }

        public static string WinlossType
        {
            get
            {
                return _loader.GetString("WinlossType");
            }
        }
    }
}
