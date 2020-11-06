using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1.Xaml.FlexGrid;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace ColumnPinning
{
    /// <summary>
    /// A customized Cell Factory that will add a pinning icon to each Column Header.
    /// </summary>
    class ColumnPinningCellFactory : CellFactory
    {
        public ObservableCollection<int> ColumnRecord;
        bool _needUpdateLayout;

        /// <summary>
        /// Define customized content for the column header.
        /// </summary>
        /// <param name="grid">The grid object which the Pin icon will be drawn on.</param>
        /// <param name="bdr">The border that wraps around the element.</param>
        /// <param name="rng"></param>
        public override void CreateColumnHeaderContent(C1FlexGrid grid, Border bdr, CellRange rng)
        {
            base.CreateColumnHeaderContent(grid, bdr, rng);
            if (ColumnRecord == null)
            {
                // Populate ColumnRecord collection to stored the original index of each column before pinning them.
                ColumnRecord = new ObservableCollection<int>();
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    ColumnRecord.Add(i);
                }
            }
            // Define a Content Control as pinning icon.
            ContentControl freeze = new ContentControl();
            freeze.Style = (Style)Application.Current.Resources["ColumnFreezeIconStyle"];
            freeze.Width = 20;
            freeze.Visibility = Visibility.Visible;
            freeze.PointerPressed += (sender, e) => SetPinColumn(sender, e, grid, rng);

            // note, this method is called every time when column headers are re-drawn 
            // so it is a good place to set appearance depending on whether column is frozen or not
            int col = rng.Column;
            if (col >= grid.FrozenColumns)
            {
                // set icon appearance for not frozen column
                freeze.Content = "\ue718"; // Pin icon
            }
            else
            {
                // set icon appearance for pinned column
                freeze.Content = "\ue840"; // Pinned icon
            }

            Grid container = bdr.Child as Grid;
            ConcatenateElements(bdr, bdr.Child, freeze, 1);
        }

        internal void OnGridColumnCollectionChanged(C1FlexGrid grid)
        {
            if (_needUpdateLayout)
            {
                grid.UpdateLayout();
                _needUpdateLayout = false;
            }
        }
        /// <summary>
        /// Pin/Unpin column.
        /// </summary>
        /// <param name="sender">Event caller.</param>
        /// <param name="e">Event argument.</param>
        /// <param name="grid">The grid object.</param>
        /// <param name="rng">The cellrange to be operated on.</param>
        private void SetPinColumn(object sender, PointerRoutedEventArgs e, C1FlexGrid grid, CellRange rng)
        {
            ContentControl pinIcon = (ContentControl)sender;
            pinIcon.Foreground = new SolidColorBrush(Colors.Red);
            int col = rng.Column;
            // When pinning column, we move that column to the left side and increment the FrozenCol number.
            if (col >= grid.FrozenColumns)
            {
                if (col != grid.FrozenColumns)
                {
                    grid.Columns.Move(col, grid.FrozenColumns);
                    ColumnRecord.Move(col, grid.FrozenColumns);
                }
                grid.FrozenColumns++;
            }
            // When unpinning column, we move that column back to its corresponding position based on the ColumnRecord.
            else
            {
                _needUpdateLayout = true;
                grid.FrozenColumns--;
                MoveColumn(col, grid);
            }
        }

        /// <summary>
        /// Move column to the right position upon unpinning.
        /// </summary>
        /// <param name="index">The position of the column prior to unpin event.</param>
        /// <param name="grid">The grid which contains the column.</param>
        private void MoveColumn(int index, C1FlexGrid grid)
        {
            int value = ColumnRecord[index];
            //Move the col outside of Frozen area first-hand
            if (index != grid.FrozenColumns)
            {
                grid.Columns.Move(index, grid.FrozenColumns);
                ColumnRecord.Move(index, grid.FrozenColumns);
            }

            if (grid.FrozenColumns == 0 && value == 0)
            {
                return;
            }

            int curIndex = grid.FrozenColumns;           
            for (int i = grid.FrozenColumns; i < ColumnRecord.Count; i++)
            {
                if (ColumnRecord[curIndex] < ColumnRecord[i] )
                {
                    grid.Columns.Move(curIndex, i-1);
                    ColumnRecord.Move(curIndex, i-1);
                    break;
                }
                if (i == ColumnRecord.Count -1)
                {
                    grid.Columns.Move(curIndex, i );
                    ColumnRecord.Move(curIndex, i );
                    break;
                }                
            }
        }

        /// <summary>
        /// Concatenate 2 UIelement in order from left to right.
        /// </summary>
        /// <param name="bdr"></param>
        /// <param name="e1">The left element.</param>
        /// <param name="e2">The right element.</param>
        /// <param name="autoCol"></param>
        void ConcatenateElements(Border bdr, UIElement e1, UIElement e2, int autoCol)
        {
            if (e1 == null || e2 == null)
            {
                return;
            }
            var g = new Grid();
            g.Background = new SolidColorBrush(Colors.Transparent); // make sure it's transparent
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions[autoCol].Width = new GridLength(1, GridUnitType.Auto);

            bdr.Child = null;
            g.Children.Add(e1);
            g.Children.Add(e2);
            e2.SetValue(Grid.ColumnProperty, 1);
            bdr.Child = g;
        }
    }
}
