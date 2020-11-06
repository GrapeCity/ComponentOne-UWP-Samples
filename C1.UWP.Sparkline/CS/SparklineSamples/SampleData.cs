using C1.Xaml.Sparkline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace SparklineSamples
{
    class SampleData
    {
        Dictionary<string, Color> _defaultColors;
        Dictionary<string, SparklineType> _types;

        public List<double> DefaultData
        {
            get 
            {
                List<double> data = new List<double>() { 1.0, -2.0, -1.0, 6.0, 4.0, -4.0, 3.0, 8.0};
                return data;
            }
        }

        public List<DateTime> DefaultDateAxisData
        {
            get
            {
                List<DateTime> dates = new List<DateTime>();
                dates.Add(new DateTime(2011, 1, 5));
                dates.Add(new DateTime(2011, 1, 1));
                dates.Add(new DateTime(2011, 2, 11));
                dates.Add(new DateTime(2011, 3, 1));
                dates.Add(new DateTime(2011, 2, 1));
                dates.Add(new DateTime(2011, 2, 3));
                dates.Add(new DateTime(2011, 3, 6));
                dates.Add(new DateTime(2011, 2, 19));
                return dates;
            }
        }

        public Dictionary<string, Color> DefaultColors
        {
            get
            {
                if (_defaultColors == null)
                {
                    _defaultColors = new Dictionary<string, Color>();
                    _defaultColors.Add(Strings.SkyBlueColor, Color.FromArgb(0xFF, 0x88, 0xBD, 0xE6));
                    _defaultColors.Add(Strings.SandyBrownColor, Color.FromArgb(0xFF, 0xFB, 0xB2, 0x58));
                    _defaultColors.Add(Strings.LightGreenColor, Color.FromArgb(0xFF, 0x90, 0xCD, 0x97));
                    _defaultColors.Add(Strings.LightPinkColor, Color.FromArgb(0xFF, 0xF6, 0xAA, 0xC9));
                    _defaultColors.Add(Strings.DarkKhakiColor, Color.FromArgb(0xFF, 0xBF, 0xA5, 0x54));
                    _defaultColors.Add(Strings.MediumOrchidColor, Color.FromArgb(0xFF, 0xBC, 0x99, 0xC7));
                    _defaultColors.Add(Strings.GoldColor, Color.FromArgb(0xFF, 0xED, 0xDD, 0x46));
                    _defaultColors.Add(Strings.LightCoralColor, Color.FromArgb(0xFF, 0xF0, 0x7E, 0x6E));
                    _defaultColors.Add(Strings.GrayColor, Color.FromArgb(0xFF, 0x8C, 0x8C, 0x8C));
                }

                return _defaultColors;
            }
        }

        public Dictionary<string, SparklineType> SparklineTypes
        {
            get
            {
                if (_types == null)
                {
                    _types = new Dictionary<string, SparklineType>();
                    _types.Add(Strings.LineType, SparklineType.Line);
                    _types.Add(Strings.ColumnType, SparklineType.Column);
                    _types.Add(Strings.WinlossType, SparklineType.Winloss);
                }

                return _types;
            }
        }
    }
}
