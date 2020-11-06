using C1.Xaml.FlexGrid;
using Grapecity.C1_EMenus.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grapecity.C1_EMenus.CellFactories
{
    #region ClassItemCellFactory
    class ItemCellFactory : CellFactory
    {
        #region EventHandler
        public event RoutedEventHandler ItemClicked;
        #endregion

        #region PrivateVariables
        private Button imgBtn;
        private ItemImageCtrl itemImageCtrl;
        private Item item;
        #endregion

        #region OverrideMethods
        //Override CreateCell
        public override FrameworkElement CreateCell(C1FlexGrid grid, CellType cellType, CellRange rng)
        {
            item = (grid[rng.Row, rng.Column] as Item);
            if (item == null)
                return base.CreateCell(grid, cellType, rng); 
            itemImageCtrl = new ItemImageCtrl(item.ImageUri, item.Text, item.Rating, item.IsEnabled, item.IsVeg, item.IsSpecial);
            imgBtn = itemImageCtrl.ImgButton;
            if (!item.IsEnabled)
            {
                itemImageCtrl.Opacity = .2;
            }
            //Implement related events
            imgBtn.Click += (s, e) =>
            {
                ItemClicked?.Invoke(item, e);
            };
            return itemImageCtrl;
        }
        #endregion
    }
    #endregion
}
