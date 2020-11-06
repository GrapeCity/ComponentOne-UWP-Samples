using System;
using Windows.UI;
using Windows.UI.Xaml;
using C1.Xaml.FlexGrid;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FlexGrid101
{
    /// <summary>
    /// Custom cell factory that allow highlight content and change background cell contains the data matching
    /// </summary>
    internal class FullTextFilterCellFactory : CellFactory
    {
        #region ** fields
        Brush HighlightedForeground = new SolidColorBrush(Colors.Red);
        Brush HighlightedBackground = new SolidColorBrush(Color.FromArgb(60, 255, 255, 0));

        C1FlexGrid _flex;
        FullTextFilter _filterInfo;
        #endregion

        #region ** ctors
        public FullTextFilterCellFactory(FullTextFilter filter)
        {
            // initialize factory
            _filterInfo = filter;
        }

        #endregion

        #region ** ICellFactory
        /// <summary>
        /// Sets the content of a <see cref="Border"/> element used to display the value of a data cell.
        /// </summary>
        /// <param name="grid"><see cref="C1FlexGrid"/> that owns the cell.</param>
        /// <param name="bdr"><see cref="Border"/> element that contains the header.</param>
        /// <param name="rng"><see cref="CellRange"/> that specifies the row and column represented by the cell.</param>
        public override void CreateCellContent(C1FlexGrid grid, Border bdr, CellRange rng)
        {
            base.CreateCellContent(grid, bdr, rng);

            if (bdr != null && bdr.Child is TextBlock)
            {
                var label = bdr.Child as TextBlock;
                if (label != null)
                {
                    var query = _filterInfo.TextFilter;
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        var queryParts = _filterInfo.FilterCondition.TreatSpacesAsAndOperator ? query.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) : new string[] { query };
                        if (label.Highlight(queryParts, HighlightedForeground, isMatchCase: _filterInfo.FilterCondition.MatchCase, isMatchWholeWord: _filterInfo.FilterCondition.MatchWholeWord))
                            bdr.Background = HighlightedBackground;
                    }
                }
            }

        }
        #endregion
    }
}
