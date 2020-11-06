using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Windows.ApplicationModel;

namespace FlexChartEditableAnnotations
{
    public static class Localizer
    {
        static string currentCultureConfiguration = string.Empty;
        static Localizer()
        {
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "en-US": currentCultureConfiguration = "/Localization/SampleConfiguration_EN.xml"; break;
                case "ch-CH": currentCultureConfiguration = "/Localization/SampleConfiguration_CH.xml"; break;
                case "jp-JP": currentCultureConfiguration = "/Localization/SampleConfiguration_JP.xml"; break;
                default: currentCultureConfiguration = "/Localization/SampleConfiguration_EN.xml"; break;
            }
        }

        public static string GetItem(string id, string attribute)
        {
            try
            {
                string result = String.Empty;

                string XMLFilePath = Package.Current.InstalledLocation.Path + currentCultureConfiguration;
                XDocument loadedData = XDocument.Load(XMLFilePath);

                var textElements = loadedData.Descendants("text");
                foreach (XElement xe in textElements)
                {
                    if (xe.Attribute("id").Value == id && xe.Element(attribute).Value != null)
                    {
                        result = xe.Element(attribute).Value;
                        break;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Error getting localized text: {0}", ex.Message);
            }
        }
        public static string MakeRtf(this string source)
        {
            var result = (@"{\rtf1\ansi\deff0{\colortbl \red100\green100\blue100;\red255\green0\blue0;}" + source + " }")
                .Replace("[b]", "\\b ")
                .Replace("[/b]", "\\b0 ")
                .Replace("[color]", "\\cf1 ")
                .Replace("[/color]", "\\cf0 ")
                .Replace("\r\n", "\\line ");
            return result;
        }
    }
}
