using C1.Xaml;
using C1.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InputSamples
{
    public class DataProvider
    {
        private C1CollectionView incomeCollection;
        private C1CollectionView expenseCollection;

        private DistributionData distributionData;
        private FinnanceData finnanceData;
        private AddressBook addressBook;

        static DataProvider provider;

        public List<string> FilterFamilyMembers { get; private set; }
        public List<AccountType> FilterAccountTypes { get; private set; }
        public List<IncomeType> FilterIncomeTypes { get; private set; }
        public List<ExpenseType> FilterExpenseTypes { get; private set; }

        public DistributionData DistributionData { get { return distributionData; } }

        public C1CollectionView Incomes { get { return incomeCollection; } }
        public C1CollectionView Expenses { get { return expenseCollection; } }

        public Dictionary<string, AccountType> AccountTypes
        {
            get
            {
                Dictionary<string, AccountType> dictionary = new Dictionary<string, AccountType>();
                dictionary[Strings.Account_Cash] = AccountType.Cash;
                dictionary[Strings.Account_CreditCard] = AccountType.CreditCard;
                dictionary[Strings.Account_BankAccount] = AccountType.BankAccount;
                dictionary[Strings.Account_OnlinePayment] = AccountType.OnlinePayment;
                return dictionary;
            }
        }
        public Dictionary<string, IncomeType> IncomeTypes
        {
            get
            {
                Dictionary<string, IncomeType> dictionary = new Dictionary<string, IncomeType>();
                dictionary[Strings.IncomeType_Salary] = IncomeType.Salary;
                dictionary[Strings.IncomeType_Stock] = IncomeType.Stock;
                dictionary[Strings.IncomeType_InvestmentReturn] = IncomeType.Investment;
                dictionary[Strings.IncomeType_Lottery] = IncomeType.Lottery;
                dictionary[Strings.IncomeType_Others] = IncomeType.Others;
                return dictionary;
            }
        }
        public Dictionary<string, ExpenseType> ExpenseTypes
        {
            get
            {
                Dictionary<string, ExpenseType> dictionary = new Dictionary<string, ExpenseType>();
                dictionary[Strings.ExpenseType_Tax] = ExpenseType.Tax;
                dictionary[Strings.ExpenseType_Traffic] = ExpenseType.Traffic;
                dictionary[Strings.ExpenseType_Shopping] = ExpenseType.Shopping;
                dictionary[Strings.ExpenseType_Entertainment] = ExpenseType.Entertainment;
                dictionary[Strings.ExpenseType_Education] = ExpenseType.Education;
                dictionary[Strings.ExpenseType_Health] = ExpenseType.Health;
                dictionary[Strings.ExpenseType_Others] = ExpenseType.Others;
                return dictionary;
            }
        }

        public List<string> FamilyMembers
        {
            get
            {
                List<string> list = new List<string>();
                list.Add("Richard");
                list.Add("Violet");
                list.Add("Olivia");
                list.Add("Lucas");
                return list;
            }
        }

        public List<Mail> MailList { get { return addressBook.Mails; } }

        static DataProvider() { }

        public static DataProvider GetProvider()
        {
            if (provider == null)
            {
                provider = new DataProvider();
                provider.InstallData();
            }
            return provider;
        }

        public void InstallData()
        {
            Assembly assembly = Assembly.Load(new AssemblyName("InputSamplesLib"));
            var mapDataStream = assembly.GetManifestResourceStream("InputSamples.Resources.MapData.xml");
            distributionData = (DistributionData)new XmlSerializer(typeof(DistributionData)).Deserialize(mapDataStream);
            var finnanceDataStream = assembly.GetManifestResourceStream("InputSamples.Resources.FinanceData.xml");
            finnanceData = (FinnanceData)new XmlSerializer(typeof(FinnanceData)).Deserialize(finnanceDataStream);
            ObservableCollection<Income> incomesCollcetion = new ObservableCollection<Income>(finnanceData.Incomes);
            var mailDataStream = assembly.GetManifestResourceStream("InputSamples.Resources.MailData.xml");
            addressBook = (AddressBook)new XmlSerializer(typeof(AddressBook)).Deserialize(mailDataStream);
            incomeCollection = new C1CollectionView(finnanceData.Incomes);
            incomeCollection.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
            incomeCollection.GroupDescriptions.Add(new PropertyGroupDescription("AccountType"));
            incomeCollection.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
            expenseCollection = new C1CollectionView(finnanceData.Expenses);
            expenseCollection.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
            expenseCollection.GroupDescriptions.Add(new PropertyGroupDescription("AccountType"));
            expenseCollection.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
            FilterFamilyMembers = new List<string>();
            FilterAccountTypes = new List<AccountType>();
            FilterIncomeTypes = new List<IncomeType>();
            FilterExpenseTypes = new List<ExpenseType>();
            incomeCollection.Filter = new Predicate<object>(FilterCompatibleIncomeItems);
            expenseCollection.Filter = new Predicate<object>(FilterCompatibleExpenseItems);
        }

        private bool FilterCompatibleIncomeItems(object incomeItem)
        {
            var current = incomeItem as Income;
            if (current == null)
                return false;
            bool result = FilterFamilyMembers.Contains(current.Name) && FilterAccountTypes.Contains(current.AccountType) && FilterIncomeTypes.Contains(current.Type);
            return result;
        }
        private bool FilterCompatibleExpenseItems(object expenseItem)
        {
            var current = expenseItem as Expense;
            if (current == null)
                return false;
            bool result = FilterFamilyMembers.Contains(current.Name) && FilterAccountTypes.Contains(current.AccountType) && FilterExpenseTypes.Contains(current.Type);
            return result;
        }

        public void UpdateData<T>(List<T> addItems, List<T> removeItems, List<T> source, DataFilterType filterType)
        {
            foreach (T item in addItems)
            {
                if (!source.Contains(item))
                    source.Add(item);
            }
            foreach (T item in removeItems)
            {
                if (source.Contains(item))
                    source.Remove(item);
            }
            if (filterType != DataFilterType.Income)
            {
                expenseCollection.Filter = null;
                expenseCollection.Filter = new Predicate<object>(FilterCompatibleExpenseItems);
            }
            if (filterType != DataFilterType.Expense)
            {
                incomeCollection.Filter = null;
                incomeCollection.Filter = new Predicate<object>(FilterCompatibleIncomeItems);
            }
        }
    }

    public enum DataFilterType
    {
        Name,
        Account,
        Income,
        Expense
    }
}
