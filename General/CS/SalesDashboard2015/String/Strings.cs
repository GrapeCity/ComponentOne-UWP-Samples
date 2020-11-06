using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace SalesDashboard2015
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView();

        public static string InitializedPageError
        {
            get { return _loader.GetString("InitializedPageError"); }
        }

        public static string SignDollar
        {
            get { return _loader.GetString("SignDollar"); }
        }

        public static string Percent
        {
            get { return _loader.GetString("Percent"); }
        }

        public static string Desktop
        {
            get { return _loader.GetString("Desktop"); }
        }

        public static string Mobile
        {
            get { return _loader.GetString("Mobile"); }
        }

        public static string Other
        {
            get { return _loader.GetString("Other"); }
        }

        public static string Q1
        {
            get { return _loader.GetString("Q1"); }
        }

        public static string Q2
        {
            get { return _loader.GetString("Q2"); }
        }

        public static string Q3
        {
            get { return _loader.GetString("Q3"); }
        }

        public static string Q4
        {
            get { return _loader.GetString("Q4"); }
        }

        public static string Partner1
        {
            get { return _loader.GetString("Partner1"); }
        }

        public static string Partner2
        {
            get { return _loader.GetString("Partner2"); }
        }

        public static string Partner3
        {
            get { return _loader.GetString("Partner3"); }
        }

        public static string Partner4
        {
            get { return _loader.GetString("Partner4"); }
        }

        public static string Partner5
        {
            get { return _loader.GetString("Partner5"); }
        }

        public static string Partner6
        {
            get { return _loader.GetString("Partner6"); }
        }

        public static string USA
        {
            get
            {
                return _loader.GetString("USA");
            }
        }

        public static string Russia
        {
            get
            {
                return _loader.GetString("Russia");
            }
        }

        public static string China
        {
            get
            {
                return _loader.GetString("China");
            }
        }

        public static string Spain
        {
            get
            {
                return _loader.GetString("Spain");
            }
        }

        public static string Japan
        {
            get
            {
                return _loader.GetString("Japan");
            }
        }

        public static string Brazil
        {
            get
            {
                return _loader.GetString("Brazil");
            }
        }

        public static string Uruguay
        {
            get
            {
                return _loader.GetString("Uruguay");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string Category_Text
        {
            get
            {
                return _loader.GetString("Category_Text");
            }
        }

        public static string Partner_Text
        {
            get
            {
                return _loader.GetString("Partner_Text");
            }
        }

        public static string PhoneCategory_Header
        {
            get
            {
                return _loader.GetString("PhoneCategory_Header");
            }
        }

        public static string PhonePartner_Header
        {
            get
            {
                return _loader.GetString("PhonePartner_Header");
            }
        }

        public static string PhoneQuarterly_Header
        {
            get
            {
                return _loader.GetString("PhoneQuarterly_Header");
            }
        }

        public static string PhoneRegion_Header
        {
            get
            {
                return _loader.GetString("PhoneRegion_Header");
            }
        }

        public static string PhoneTotal_Header
        {
            get
            {
                return _loader.GetString("PhoneTotal_Header");
            }
        }

        public static string PhoneType_Header
        {
            get
            {
                return _loader.GetString("PhoneType_Header");
            }
        }

        public static string Quarterly_Text
        {
            get
            {
                return _loader.GetString("Quarterly_Text");
            }
        }

        public static string Region_Text
        {
            get
            {
                return _loader.GetString("Region_Text");
            }
        }

        public static string RunTotalOne_Text
        {
            get
            {
                return _loader.GetString("RunTotalOne_Text");
            }
        }

        public static string RunTotalThree_Text
        {
            get
            {
                return _loader.GetString("RunTotalThree_Text");
            }
        }

        public static string RunTotalTwo_Text
        {
            get
            {
                return _loader.GetString("RunTotalTwo_Text");
            }
        }

        public static string TitleFive_Text
        {
            get
            {
                return _loader.GetString("TitleFive_Text");
            }
        }

        public static string TitleFour_Text
        {
            get
            {
                return _loader.GetString("TitleFour_Text");
            }
        }

        public static string TitleOne_Text
        {
            get
            {
                return _loader.GetString("TitleOne_Text");
            }
        }

        public static string TitleThree_Text
        {
            get
            {
                return _loader.GetString("TitleThree_Text");
            }
        }

        public static string TitleTwo_Text
        {
            get
            {
                return _loader.GetString("TitleTwo_Text");
            }
        }

        public static string Total_Text
        {
            get
            {
                return _loader.GetString("Total_Text");
            }
        }

        public static string Type_Text
        {
            get
            {
                return _loader.GetString("Type_Text");
            }
        }
    }
}
