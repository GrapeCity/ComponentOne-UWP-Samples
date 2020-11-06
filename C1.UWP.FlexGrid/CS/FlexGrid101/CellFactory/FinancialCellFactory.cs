using C1.Xaml.FlexGrid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace FlexGrid101
{
    public class FinancialCellFactory : CellFactory
    {
        static Thickness _thicknessEmpty = new Thickness(0);

        // bind cell to ticker
        public override void CreateCellContent(C1FlexGrid grid, Border bdr, CellRange range)
        {
            // create visual element for this cell
            var dataItem = grid.Rows[range.Row].DataItem;
            var name = grid.Columns[range.Column].PropertyInfo.Name;
            if (dataItem is FinancialData &&
               (name.Equals("LastSale") || name.Equals("Bid") || name.Equals("Ask")))
            {
                // create stock ticker cell
                StockTicker ticker = new StockTicker();
                bdr.Child = ticker;
                bdr.Padding = _thicknessEmpty;
            }
            else
            {
                // use default implementation
                base.CreateCellContent(grid, bdr, range);
            }
        }

        public override void DisposeCell(C1FlexGrid grid, CellType cellType, FrameworkElement cell)
        {
            base.DisposeCell(grid, cellType, cell);
        }

        public void ShowLiveData(C1FlexGrid grid, CellRange range, FrameworkElement cell)
        {
            //Sets the binding in the cell content so that is updated at runtime.
            var stockTicker = (cell as Border).Child as StockTicker;
            if (stockTicker != null)
            {
                var c = grid.Columns[range.Column];
                var r = grid.Rows[range.Row];
                var pi = c.PropertyInfo;

                // to show sparklines
                stockTicker.Tag = r.DataItem;
                stockTicker.BindingSource = pi.Name;

                var binding = new Binding { Path = new PropertyPath(pi.Name) };
                binding.Converter = new MyConverter();
                binding.Source = r.DataItem;
                binding.Mode = BindingMode.OneWay;
                stockTicker.SetBinding(StockTicker.ValueProperty, binding);
            }
        }
    }

    public class MyConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return System.Convert.ToDouble(value);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
