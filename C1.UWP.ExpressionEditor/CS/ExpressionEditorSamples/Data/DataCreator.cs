using System.Collections.Generic;

namespace ExpressionEditorSamples
{
    class DataCreator
    {
        static List<DataItem> _datas;

        public static List<DataItem> CreateData()
        {
            if (_datas == null)
            {
                _datas = new List<DataItem>();
                _datas.Add(new DataItem("UK", 5, 4));
                _datas.Add(new DataItem("USA", 7, 3));
                _datas.Add(new DataItem("Germany", 8, 5));
                _datas.Add(new DataItem("Japan", 12, 8));
            }
            return _datas;
        }
    }

    public class DataItem
    {
        public DataItem()
        {
        }

        public DataItem(string country, int sales, int expenses)
        {
            Country = country;
            Sales = sales;
            Expenses = expenses;
        }

        public string Country { get; set; }
        public int Sales { get; set; }
        public int Expenses { get; set; }
    }
}
