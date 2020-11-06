using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using C1.Xaml.FlexGrid;

namespace FlexGrid101
{
    // cell factory used to create media cells
    public class MusicCellFactory : CellFactory
    {
        static Thickness _emptyThickness = new Thickness(0);
        public List<RatingCell> _ratings = new List<RatingCell>();

        // bind a cell to a range
        public override void CreateCellContent(C1FlexGrid grid, Border bdr, CellRange range)
        {
            // get row/col
            var row = grid.Rows[range.Row];
            var col = grid.Columns[range.Column];
            var gr = row as GroupRow;

            // no border for group rows
            if (gr != null)
            {
                bdr.BorderThickness = _emptyThickness;
            }

            // bind first cell in each group row to collapse/expand
            if (gr != null && range.Column == 0)
            {
                BindGroupRowCell(grid, bdr, range);
                return;
            }

            // bind regular data cells
            switch (col.ColumnName)
            {
                // show names with images
                case "Name":
                    bdr.Child = new SongCell(row);
                    return;

                // show ratings with stars
                case "Rating":
                    var song = row.DataItem as Song;
                    if (song != null && gr == null)
                    {
                        var cell = new RatingCell();
                        cell.SetBinding(RatingCell.RatingProperty, col.Binding);
                        bdr.Child = cell;
                    }
                    return;
            }

            // default binding
            base.CreateCellContent(grid, bdr, range);
        }

        // bind a cell to a group row
        void BindGroupRowCell(C1FlexGrid grid, Border bdr, CellRange range)
        {
            // get row, group row
            var row = grid.Rows[range.Row];
            var gr = row as GroupRow;

            // show group caption/image on first column
            if (range.Column == 0)
            {
                // build a custom data item if necessary
                if (gr.DataItem == null)
                {
                    gr.DataItem = BuildGroupDataItem(gr);
                }

                // get type of cell we need
                Type cellType = gr.Level == 0 ? typeof(ArtistCell) : typeof(AlbumCell);

                // create the cell
                bdr.Child = gr.Level == 0 
                    ? (UIElement)new ArtistCell(row)
                    : (UIElement)new AlbumCell(row);
            }
        }

        // build a song to represent a group
        // the GetChildDataItems method returns all songs that belong
        // to this node, and the LINQ statement below calculates the total 
        // size, length, and average rating for the album/artist.
        Song BuildGroupDataItem(GroupRow gr)
        {
            var gs = gr.GetDataItems().OfType<Song>();
            return new Song()
                {
                    Name = gr.Group.Group.ToString(),
                    Size = (long)gs.Sum(s => s.Size),
                    Duration = (long)gs.Sum(s => s.Duration),
                    Rating = (int)(gs.Average(s => s.Rating) + 0.5)
                };
        }
    }
}
