using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace InputSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("InputSamplesLib/Resources");

        public static string Account_BankAccount
        {
            get
            {
                return _loader.GetString("Account_BankAccount");
            }
        }

        public static string Account_Cash
        {
            get
            {
                return _loader.GetString("Account_Cash");
            }
        }

        public static string Account_CreditCard
        {
            get
            {
                return _loader.GetString("Account_CreditCard");
            }
        }

        public static string Account_OnlinePayment
        {
            get
            {
                return _loader.GetString("Account_OnlinePayment");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string ButtonDontSend
        {
            get
            {
                return _loader.GetString("ButtonDontSend");
            }
        }

        public static string ButtonOK
        {
            get
            {
                return _loader.GetString("ButtonOK");
            }
        }

        public static string ButtonSandAnyway
        {
            get
            {
                return _loader.GetString("ButtonSandAnyway");
            }
        }

        public static string CheckListDescription
        {
            get
            {
                return _loader.GetString("CheckListDescription");
            }
        }

        public static string CheckListName
        {
            get
            {
                return _loader.GetString("CheckListName");
            }
        }

        public static string CheckListTitle
        {
            get
            {
                return _loader.GetString("CheckListTitle");
            }
        }

        public static string EmptyToError
        {
            get
            {
                return _loader.GetString("EmptyToError");
            }
        }

        public static string ErrorTitle
        {
            get
            {
                return _loader.GetString("ErrorTitle");
            }
        }

        public static string ExpenseType_Education
        {
            get
            {
                return _loader.GetString("ExpenseType_Education");
            }
        }

        public static string ExpenseType_Entertainment
        {
            get
            {
                return _loader.GetString("ExpenseType_Entertainment");
            }
        }

        public static string ExpenseType_Health
        {
            get
            {
                return _loader.GetString("ExpenseType_Health");
            }
        }

        public static string ExpenseType_Others
        {
            get
            {
                return _loader.GetString("ExpenseType_Others");
            }
        }

        public static string ExpenseType_Shopping
        {
            get
            {
                return _loader.GetString("ExpenseType_Shopping");
            }
        }

        public static string ExpenseType_Tax
        {
            get
            {
                return _loader.GetString("ExpenseType_Tax");
            }
        }

        public static string ExpenseType_Traffic
        {
            get
            {
                return _loader.GetString("ExpenseType_Traffic");
            }
        }

        public static string IncomeType_InvestmentReturn
        {
            get
            {
                return _loader.GetString("IncomeType_InvestmentReturn");
            }
        }

        public static string IncomeType_Lottery
        {
            get
            {
                return _loader.GetString("IncomeType_Lottery");
            }
        }

        public static string IncomeType_Others
        {
            get
            {
                return _loader.GetString("IncomeType_Others");
            }
        }

        public static string IncomeType_Salary
        {
            get
            {
                return _loader.GetString("IncomeType_Salary");
            }
        }

        public static string IncomeType_Stock
        {
            get
            {
                return _loader.GetString("IncomeType_Stock");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }
        
        public static string MultiSelectDescription
        {
            get
            {
                return _loader.GetString("MultiSelectDescription");
            }
        }

        public static string MultiSelectName
        {
            get
            {
                return _loader.GetString("MultiSelectName");
            }
        }

        public static string MultiSelectTitle
        {
            get
            {
                return _loader.GetString("MultiSelectTitle");
            }
        }

        public static string NoSubjectError
        {
            get
            {
                return _loader.GetString("NoSubjectError");
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

        public static string TagEditorDescription
        {
            get
            {
                return _loader.GetString("TagEditorDescription");
            }
        }

        public static string TagEditorName
        {
            get
            {
                return _loader.GetString("TagEditorName");
            }
        }

        public static string TagEditorTitle
        {
            get
            {
                return _loader.GetString("TagEditorTitle");
            }
        }

        public static string ToastAnd
        {
            get
            {
                return _loader.GetString("ToastAnd");
            }
        }

        public static string ToastJoinSeprator
        {
            get
            {
                return _loader.GetString("ToastJoinSeprator");
            }
        }

        public static string ToastNamesFormat
        {
            get
            {
                return _loader.GetString("ToastNamesFormat");
            }
        }

        public static string ToastPeopleEnd
        {
            get
            {
                return _loader.GetString("ToastPeopleEnd");
            }
        }

        public static string ToastPeriod
        {
            get
            {
                return _loader.GetString("ToastPeriod");
            }
        }

        public static string ToastSubjectFormat
        {
            get
            {
                return _loader.GetString("ToastSubjectFormat");
            }
        }

        public static string ToastTitle
        {
            get
            {
                return _loader.GetString("ToastTitle");
            }
        }

        public static string ToolTipManager
        {
            get
            {
                return _loader.GetString("ToolTipManager");
            }
        }

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }
    }
}
