using C1.Xaml.FlexGrid;
using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexGrid101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomMerging : Page
    {
        public CustomMerging()
        {
            this.InitializeComponent();

            grid.SelectionChanged += Grid_SelectionChanged;
            grid.MinColumnWidth = 85;
            grid.MergeManager = new MyMergeManager();

            PopulateGrid();
        }

        private void PopulateGrid()
        {
            grid.Columns.Add(new Column { Header = Strings.Monday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            grid.Columns.Add(new Column { Header = Strings.Tuesday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            grid.Columns.Add(new Column { Header = Strings.Wednesday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            grid.Columns.Add(new Column { Header = Strings.Thursday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            grid.Columns.Add(new Column { Header = Strings.Friday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            grid.Columns.Add(new Column { Header = Strings.Saturday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            grid.Columns.Add(new Column { Header = Strings.Sunday, Width = new GridLength(1, GridUnitType.Star), MinWidth = 120, AllowMerging = true, HeaderHorizontalAlignment = HorizontalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });

            grid.Rows.Add(new Row());
            grid.Rows.Add(new Row());
            grid.Rows.Add(new Row());
            grid.Rows.Add(new Row());
            grid.Rows.Add(new Row());
            grid.Rows.Add(new Row());
            grid.Rows.Add(new Row());

            grid.ColumnHeaders.Rows.Insert(0, new Row() { AllowMerging = true });
            grid.ColumnHeaders[0, 0] = Strings.Weekday;
            grid.ColumnHeaders[0, 1] = Strings.Weekday;
            grid.ColumnHeaders[0, 2] = Strings.Weekday;
            grid.ColumnHeaders[0, 3] = Strings.Weekday;
            grid.ColumnHeaders[0, 4] = Strings.Weekday;
            grid.ColumnHeaders[0, 5] = Strings.Weekend;
            grid.ColumnHeaders[0, 6] = Strings.Weekend;

            grid.ColumnHeaders[1, 0] = Strings.Monday;
            grid.ColumnHeaders[1, 1] = Strings.Tuesday;
            grid.ColumnHeaders[1, 2] = Strings.Wednesday;
            grid.ColumnHeaders[1, 3] = Strings.Thursday;
            grid.ColumnHeaders[1, 4] = Strings.Friday;
            grid.ColumnHeaders[1, 5] = Strings.Saturday;
            grid.ColumnHeaders[1, 6] = Strings.Sunday;

            grid.RowHeaders.Columns[0].Width = GridLength.Auto;
            grid.RowHeaders[0, 0] = "12:00";
            grid.RowHeaders[1, 0] = "13:00";
            grid.RowHeaders[2, 0] = "14:00";
            grid.RowHeaders[3, 0] = "15:00";
            grid.RowHeaders[4, 0] = "16:00";
            grid.RowHeaders[5, 0] = "17:00";
            grid.RowHeaders[6, 0] = "18:00";

            grid[0, 0] = "Walker";
            grid[0, 1] = "Morning Show";
            grid[0, 2] = "Morning Show";
            grid[0, 3] = "Sports";
            grid[0, 4] = "Weather";
            grid[0, 5] = "N/A";
            grid[0, 6] = "N/A";
            grid[1, 5] = "N/A";
            grid[1, 6] = "N/A";
            grid[2, 5] = "N/A";
            grid[2, 6] = "N/A";
            grid[3, 5] = "N/A";
            grid[3, 6] = "N/A";
            grid[4, 5] = "N/A";
            grid[4, 6] = "N/A";
            grid[1, 0] = "Today Show";
            grid[1, 1] = "Today Show";
            grid[2, 0] = "Today Show";
            grid[2, 1] = "Today Show";
            grid[1, 2] = "Sesame Street";
            grid[1, 3] = "Football";
            grid[2, 3] = "Football";
            grid[1, 4] = "Market Watch";
            grid[2, 2] = "Kids Zone";
            grid[2, 4] = "Soap Opera";
            grid[3, 0] = "News";
            grid[3, 1] = "News";
            grid[3, 2] = "News";
            grid[3, 3] = "News";
            grid[3, 4] = "News";
            grid[4, 0] = "News";
            grid[4, 1] = "News";
            grid[4, 2] = "News";
            grid[4, 3] = "News";
            grid[4, 4] = "News";
            grid[5, 0] = "Wheel of Fortune";
            grid[5, 1] = "Wheel of Fortune";
            grid[5, 2] = "Wheel of Fortune";
            grid[5, 3] = "Jeopardy";
            grid[5, 4] = "Jeopardy";
            grid[5, 5] = "Movie";
            grid[6, 5] = "Movie";
            grid[5, 6] = "Golf";
            grid[6, 6] = "Golf";
            grid[6, 0] = "Night Show";
            grid[6, 1] = "Night Show";
            grid[6, 2] = "Sports";
            grid[6, 3] = "Big Brother";
            grid[6, 4] = "Big Brother";
        }

        private void Grid_SelectionChanged(object sender, CellRangeEventArgs e)
        {

            string selectedText = grid[e.CellRange.Row, e.CellRange.Column].ToString();
            labelShowName.Text = selectedText;
            labelShowTimes.Text = "";
            for (int c = 0; c < grid.Columns.Count; c++)
            {
                string dayName = grid.ColumnHeaders[1, c].ToString();
                string startTime = "";
                for (int r = 0; r < grid.Rows.Count; r++)
                {
                    string cellValue = grid[r, c].ToString();

                    if (cellValue.Equals(selectedText))
                    {
                        if (startTime == "")
                        {
                            startTime = grid.RowHeaders[r, 0].ToString();
                            labelShowTimes.Text = labelShowTimes.Text + dayName + " " + startTime + "-";
                        }
                    }
                    else if (startTime != "" && labelShowTimes.Text.ToString().EndsWith("-"))
                    {
                        string endTime = grid.RowHeaders[r, 0].ToString();
                        labelShowTimes.Text = labelShowTimes.Text + endTime + "\n";
                    }

                    // handle last row exception
                    if (r == grid.Rows.Count - 1 && startTime != "" && labelShowTimes.Text.ToString().EndsWith("-"))
                    {
                        labelShowTimes.Text = labelShowTimes.Text + "19:00\n";
                    }
                }
            }
        }
    }

    public class MyMergeManager : IMergeManager
    {
        public CellRange GetMergedRange(C1FlexGrid grid, CellType cellType, CellRange rg)
        {
            if (cellType == CellType.Cell)
            {
                // expand left/right
                for (int i = rg.Column; i < grid.Columns.Count - 1; i++)
                {
                    if (GetDataDisplay(grid, rg.Row, i) != GetDataDisplay(grid, rg.Row, i + 1)) break;
                    rg.Column2 = i + 1;
                }
                for (int i = rg.Column; i > 0; i--)
                {
                    if (GetDataDisplay(grid, rg.Row, i) != GetDataDisplay(grid, rg.Row, i - 1)) break;
                    rg.Column = i - 1;
                }

                // expand up/down
                for (int i = rg.Row; i < grid.Rows.Count - 1; i++)
                {
                    if (GetDataDisplay(grid, i, rg.Column) != GetDataDisplay(grid, i + 1, rg.Column)) break;
                    rg.Row2 = i + 1;
                }
                for (int i = rg.Row; i > 0; i--)
                {
                    if (GetDataDisplay(grid, i, rg.Column) != GetDataDisplay(grid, i - 1, rg.Column)) break;
                    rg.Row = i - 1;
                }
            }

            if (cellType == CellType.ColumnHeader)
            {
                for (int i = rg.Column; i < grid.Columns.Count - 1; i++)
                {
                    if (GetColumnHeaderDataDisplay(grid, rg.Row, i) != GetColumnHeaderDataDisplay(grid, rg.Row, i + 1)) break;
                    rg.Column2 = i + 1;
                }
                for (int i = rg.Column; i > 0; i--)
                {
                    if (GetColumnHeaderDataDisplay(grid, rg.Row, i) != GetColumnHeaderDataDisplay(grid, rg.Row, i - 1)) break;
                    rg.Column = i - 1;
                }
            }

            // done
            return rg;
        }
        string GetDataDisplay(C1FlexGrid grid, int r, int c)
        {
            return grid[r, c].ToString();
        }

        string GetColumnHeaderDataDisplay(C1FlexGrid grid, int r, int c)
        {
            return grid.ColumnHeaders[r, c].ToString();
        }
    }
}

