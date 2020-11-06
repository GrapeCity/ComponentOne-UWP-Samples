using Windows.ApplicationModel.Resources;

namespace CurrencyComparison
{
    public class Strings
    {
        public static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

        public static string BaseCurrency
        {
            get
            {
                return _loader.GetString("BaseCurrency");
            }
        }

        public static string Currencies
        {
            get
            {
                return _loader.GetString("Currencies");
            }
        }

        public static string Both
        {
            get
            {
                return _loader.GetString("Both");
            }
        }

        public static string ExchangeRate
        {
            get
            {
                return _loader.GetString("ExchangeRate");
            }
        }

        public static string PercentageChange
        {
            get
            {
                return _loader.GetString("PercentageChange");
            }
        }

        public static string Y1Title
        {
            get
            {
                return _loader.GetString("Y1Title");
            }
        }

        public static string Y2Title
        {
            get
            {
                return _loader.GetString("Y2Title");
            }
        }

        public static string Measure
        {
            get
            {
                return _loader.GetString("Measure");
            }
        }

        public static string FiveD
        {
            get
            {
                return _loader.GetString("FiveD");
            }
        }

        public static string TenD
        {
            get
            {
                return _loader.GetString("TenD");
            }
        }

        public static string OneM
        {
            get
            {
                return _loader.GetString("OneM");
            }
        }

        public static string SixM
        {
            get
            {
                return _loader.GetString("SixM");
            }
        }

        public static string OneY
        {
            get
            {
                return _loader.GetString("OneY");
            }
        }

        public static string FiveY
        {
            get
            {
                return _loader.GetString("FiveY");
            }
        }

        public static string TenY
        {
            get
            {
                return _loader.GetString("TenY");
            }
        }
    }
}
