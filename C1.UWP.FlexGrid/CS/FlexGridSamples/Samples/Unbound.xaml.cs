using C1.Xaml.FlexGrid;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlexGridSamples
{
    public partial class Unbound : Page
    {
        public Unbound()
        {
            InitializeComponent();

            // populate unbound grid
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(PopulateUnboundGrid));

            // store sample description in Tag property
            Tag = Strings.UnboundTag;
        }

        // fill unbound grid with data
        private async void PopulateUnboundGrid()
        {
            // allow merging
            var fg = _flexUnbound;
            fg.AllowMerging = AllowMerging.All;
            var data = await NorthwindStorage.Load();

            //add rows/ columns to the unbound grid
            for (int i = 0; i < 10; i++) // three years, four quarters per year
            {
                fg.Columns.Add(new Column());
            }
            for (int i = 0; i < 91; i++)
            {
                fg.Rows.Add(new Row());
            }

            // populate the unbound grid with some stuff
            for (int r = 0; r < fg.Rows.Count; r++)
            {
                for (int c = 0; c < fg.Columns.Count; c += 10)
                {
                    fg[r, c] = data[r].CustomerID;
                    fg[r, c + 1] = data[r].CompanyName;
                    fg[r, c + 2] = data[r].ContactName;
                    fg[r, c + 3] = data[r].ContactTitle;
                    fg[r, c + 4] = data[r].Address;
                    fg[r, c + 5] = data[r].City;
                    fg[r, c + 6] = data[r].PostalCode;
                    fg[r, c + 7] = data[r].Country;
                    fg[r, c + 8] = data[r].Phone;
                    fg[r, c + 9] = data[r].Fax;
                }
            }

            // add some group rows above the data
            for (int offset = 0; offset < fg.Rows.Count; offset += 10)
            {
                for (int i = 0; i < 3; i++)
                {
                    fg.Rows.Insert(offset + i, new GroupRow() { Level = i });
                    fg[offset + i, 0] = string.Format(Strings.LevelInfo, i);
                }
            }

            // set unbound column headers
            var ch = fg.ColumnHeaders;
            ch.Rows.Add(new Row()); 
            for (int c = 0; c < ch.Columns.Count; c += 10)
            {
                ch[0, c] = Strings.NorthwindData;
                ch[1, c] = Strings.ColumnHeaderCustomerID;
                ch[1, c + 1] = Strings.ColumnHeaderCompanyName;
                ch[1, c + 2] = Strings.ColumnHeaderContactName;
                ch[1, c + 3] = Strings.ColumnHeaderContactTitle;
                ch[1, c + 4] = Strings.ColumnHeaderAddress;
                ch[1, c + 5] = Strings.ColumnHeaderCity;
                ch[1, c + 6] = Strings.ColumnHeaderPostalCode;
                ch[1, c + 7] = Strings.ColumnHeaderCountry;
                ch[1, c + 8] = Strings.ColumnHeaderPhone;
                ch[1, c + 9] = Strings.ColumnHeaderFax;
            }

            // allow merging the first fixed row
            ch.Rows[0].AllowMerging = true;

            // set unbound row headers
            var rh = fg.RowHeaders;
            rh.Columns.Add(new Column());
            int id = 1;
            for (int c = 0; c < rh.Columns.Count; c++)
            {
                rh.Columns[c].Width = new GridLength(60);
                for (int r = 0; r < rh.Rows.Count; r++)
                {
                    if(c.Equals(0))
                    {
                        if (r % 10 < 3)
                            rh[r, c] = Strings.Level + (r % 10).ToString();
                        else
                            rh[r, c] = Strings.ID;
                    }
                    else
                    {
                        if (r % 10 >= 3)
                        {
                            rh[r, c] = id.ToString();
                            id++;
                        }
                    }
                }
            }

            // allow merging the first fixed column
            rh.Columns[0].AllowMerging = true;

            // listen to column resized event
            _flexUnbound.ResizedColumn += _flexUnbound_ResizedColumn;
        }


        // make all unbound grid columns the same width after they are resized
        private void _flexUnbound_ResizedColumn(object sender, CellRangeEventArgs e)
        {
            var col = _flexUnbound.Columns[e.Column];
            if (col.ActualWidth > 0)
            {
                _flexUnbound.Columns.DefaultSize = col.ActualWidth;
            }
            col.Width = new GridLength(0, GridUnitType.Auto);
        }
    }
}
