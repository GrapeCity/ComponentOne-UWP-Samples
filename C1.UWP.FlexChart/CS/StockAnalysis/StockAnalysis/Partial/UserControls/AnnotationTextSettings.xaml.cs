using StockAnalysis.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Automation.Peers;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StockAnalysis.Partial.UserControls
{
    public sealed partial class AnnotationTextSettings : UserControl
    {
        public AnnotationTextSettings()
        {
            this.InitializeComponent();
        }

        Dictionary<string, double> DictionaryEntries = new Dictionary<string, double>()
        {
            {"8pt", 8 },
            { "9pt", 9 },
            { "10pt", 10 },
            {"12pt", 12 },
            {"14pt", 14 },
            {"18pt", 18 },
            {"24pt", 24 },
            {"32pt", 32 },
            {"48pt", 48 },
            {"64pt", 64 }
        };

        ArrayList SystemFontFamilies = new ArrayList()
        {
            "Arial",
            "Calibri",
            "Consolas",
            "Segoe UI",
            "Segoe UI Historic",
            "Selawik",
            "Verdana",
            "Cambria",
            "Courier New",
            "Georgia",
            "Times New Roman",
            "Segoe UI Emoji",
            "Segoe UI Symbol",
            "Ebrima",
            "Gadugi",
            "Javanese Text Regular Fallback font for Javanese script",
            "Leelawadee UI",
            "Malgun Gothic",
            "Microsoft Himalaya",
            "Microsoft JhengHei UI",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft Tai Le",
            "Microsoft YaHei UI",
            "Microsoft Yi Baiti",
            "Mongolian Baiti",
            "MV Boli",
            "Myanmar Text",
            "Nirmala UI",
            "SimSun",
            "Yu Gothic",
            "Yu Gothic UI"
        };
    }
}
