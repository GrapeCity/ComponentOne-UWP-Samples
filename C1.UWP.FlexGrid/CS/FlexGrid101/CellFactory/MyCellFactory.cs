using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace FlexGrid101
{
    public class MyCellFactory : CellFactory
    {
        public override void CreateCellContentEditor(C1FlexGrid grid, Border bdr, CellRange rng)
        {
            if (grid.Columns[rng.Column].ColumnName == "LastOrderDate" && !grid.Columns[rng.Column].Format.Contains("t"))
            {
                C1.Xaml.C1DateSelector date = new C1.Xaml.C1DateSelector();
                Binding binding = new Binding();
                binding.Path =  new Windows.UI.Xaml.PropertyPath("LastOrderDate");
                binding.Mode = BindingMode.TwoWay;
                date.SetBinding(C1.Xaml.C1DateSelector.SelectedDateProperty, binding);
                bdr.Child = date;                
            }
            else
            {
                base.CreateCellContentEditor(grid, bdr, rng);
            }

        }
    }

    public class ConditionalFormatCellFactory : CellFactory
    {
        public override void CreateCellContentEditor(C1FlexGrid grid, Border bdr, CellRange rng)
        {
            if (grid.Columns[rng.Column].ColumnName == "LastOrderDate" && !grid.Columns[rng.Column].Format.Contains("t"))
            {
                DatePicker date = new DatePicker();
                Binding binding = new Binding();
                binding.Path = new Windows.UI.Xaml.PropertyPath("LastOrderDate");
                binding.Mode = BindingMode.TwoWay;
                date.SetBinding(DatePicker.DateProperty, binding);
                bdr.Child = date;
            }
            else
            {
                base.CreateCellContentEditor(grid, bdr, rng);
            }
        }

        public override void CreateCellContent(C1FlexGrid grid, Border bdr, CellRange rng)
        {
            base.CreateCellContent(grid, bdr, rng);

            var orderTotalColumn = grid.Columns["OrderTotal"];
            var orderCountColumn = grid.Columns["OrderCount"];
            if (rng.Column == orderTotalColumn.Index)
            {
                TextBlock tb = bdr.Child as TextBlock;
                if (tb != null)
                {
                    var cellValue = grid[rng.Row, rng.Column] as double?;
                    if (cellValue.HasValue)
                    {
                        tb.Foreground = cellValue < 5000.0 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
                    }
                }
            }
            if (rng.Column == orderCountColumn.Index)
            {
                TextBlock tb = bdr.Child as TextBlock;
                if (tb != null)
                {
                    var cellValue = grid[rng.Row, rng.Column] as int?;
                    if (cellValue.HasValue)
                    {
                        tb.Foreground = new SolidColorBrush(Colors.Black);
                        bdr.Background = cellValue < 50.0 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
                    }
                }
            }

        }
    }
}
