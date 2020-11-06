using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace InputSamples
{
    public class Entity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Point Position { get { return new Point(Longitude, Latitude); } }
    }

    public class Office : Entity
    {
        public string Manager { get; set; }
        public int Stores { get; set; }

        public string ToolTip
        {
            get
            {
                string tooltip = Name + "\r\n" + Strings.ToolTipManager + Manager;
                return tooltip;
            }
        }
    }

    public class Factory : Entity
    {
        public double Capacity { get; set; }
    }

    public class DistributionData
    {
        public List<Factory> Factories { get; set; }
        public List<Office> Offices { get; set; }
    }

    public enum AccountType
    {
        Cash,
        CreditCard,
        BankAccount,
        OnlinePayment
    }

    public enum IncomeType
    {
        Salary,
        Stock,
        Investment,
        Lottery,
        Others
    }

    public enum ExpenseType
    {
        Tax,
        Traffic,
        Shopping,
        Entertainment,
        Education,
        Health,
        Others
    }

    public class FinnanceItem
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public double Cost { get; set; }
        public int AccountId { get; set; }
        public int TypeId { get; set; }
        public AccountType AccountType { get { return (AccountType)AccountId; } }
    }

    public class Income : FinnanceItem
    {
        public IncomeType Type { get { return (IncomeType)TypeId; } }
    }

    public class Expense : FinnanceItem
    {
        public ExpenseType Type { get { return (ExpenseType)TypeId; } }
    }

    public class FinnanceData
    {
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
    }

    public class Mail
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class AddressBook
    {
        public List<Mail> Mails { get; set; }
    }
}

