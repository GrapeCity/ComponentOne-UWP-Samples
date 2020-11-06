using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace ExpressionEditorSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("ExpressionEditorSamplesLib/Resources");

       
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

        public static string Typexlsx
        {
            get
            {
                return _loader.GetString("Typexlsx");
            }
        }

        public static string Typecsv
        {
            get
            {
                return _loader.GetString("Typecsv");
            }
        }

        public static string DefaultFileName
        {
            get
            {
                return _loader.GetString("DefaultFileName");
            }
        }

        public static string SaveLocationTip
        {
            get
            {
                return _loader.GetString("SaveLocationTip");
            }
        }

        public static string SaveAndOpenException
        {
            get
            {
                return _loader.GetString("SaveAndOpenException");
            }
        }

        public static string SheetName
        {
            get
            {
                return _loader.GetString("SheetName");
            }
        }

        public static string DataCreatedTip
        {
            get
            {
                return _loader.GetString("DataCreatedTip");
            }
        }

        public static string OpenTip
        {
            get
            {
                return _loader.GetString("OpenTip");
            }
        }

        public static string ExpressionEditorSamplesTitle
        {
            get
            {
                return _loader.GetString("ExpressionEditorSamplesTitle");
            }
        }

        public static string ExpressionEditorSamplesDescription
        {
            get
            {
                return _loader.GetString("ExpressionEditorSamplesDescription");
            }
        }

        public static string ExpressionEditorSamplesName
        {
            get
            {
                return _loader.GetString("ExpressionEditorSamplesName");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string C1Excel_Text
        {
            get
            {
                return _loader.GetString("C1Excel_Text");
            }
        }

        public static string ContentTB_Text
        {
            get
            {
                return _loader.GetString("ContentTB_Text");
            }
        }

        public static string CreateButton_Content
        {
            get
            {
                return _loader.GetString("CreateButton_Content");
            }
        }

        public static string OpenButton_Content
        {
            get
            {
                return _loader.GetString("OpenButton_Content");
            }
        }

        public static string SaveButton_Content
        {
            get
            {
                return _loader.GetString("SaveButton_Content");
            }
        }

        public static string IntegrationGridColumnCalculationTitle
        {
            get
            {
                return _loader.GetString("IntegrationGridColumnCalculationTitle");
            }
        }

        public static string IntegrationGridColumnCalculationDescription
        {
            get
            {
                return _loader.GetString("IntegrationGridColumnCalculationDescription");
            }
        }

        public static string IntegrationGridColumnCalculationName
        {
            get
            {
                return _loader.GetString("IntegrationGridColumnCalculationName");
            }
        }

        public static string IntegrationGridSupportGroupingTitle
        {
            get
            {
                return _loader.GetString("IntegrationGridSupportGroupingTitle");
            }
        }

        public static string IntegrationGridSupportGroupingDescription
        {
            get
            {
                return _loader.GetString("IntegrationGridSupportGroupingDescription");
            }
        }

        public static string IntegrationGridSupportGroupingName
        {
            get
            {
                return _loader.GetString("IntegrationGridSupportGroupingName");
            }
        }

        public static string IntegrationGridSupportFilterTitle
        {
            get
            {
                return _loader.GetString("IntegrationGridSupportFilterTitle");
            }
        }

        public static string IntegrationGridSupportFilterDescription
        {
            get
            {
                return _loader.GetString("IntegrationGridSupportFilterDescription");
            }
        }

        public static string IntegrationGridSupportFilterName
        {
            get
            {
                return _loader.GetString("IntegrationGridSupportFilterName");
            }
        }

        public static string FlexChartSamplesTitle
        {
            get
            {
                return _loader.GetString("FlexChartSamplesTitle");
            }
        }

        public static string FlexChartSamplesDescription
        {
            get
            {
                return _loader.GetString("FlexChartSamplesDescription");
            }
        }

        public static string FlexChartSamplesName
        {
            get
            {
                return _loader.GetString("FlexChartSamplesName");
            }
        }
    }
}
