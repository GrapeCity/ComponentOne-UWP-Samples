using C1.Xaml.FlexGrid;
using Grapecity.C1_EMenus.Controls;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Grapecity.C1_EMenus.CellFactories
{
    #region ClassItemOrderCellFactory
    class ItemOrderCellFactory : CellFactory
    {
        #region EventHandler
        public event RoutedEventHandler BtnClickAddToCart;
        #endregion

        #region PrivateVariables        
        private Item item;
        #endregion

        #region OverrideMethods
        //override CreateCell
        public override FrameworkElement CreateCell(C1FlexGrid grid, CellType cellType, CellRange rng)
        {

            if (grid[rng.Row, rng.Column] == null)
                return base.CreateCell(grid, cellType, rng);
            item = (grid[rng.Row, rng.Column] as Item);
            ItemOrderCtrl itemOrderCtrl = new ItemOrderCtrl(item.ImageUri, item.Text, item.Description, item.Rating, item.IsVeg, item.IsSpecial, item.PrizeRegular, item.PrizeMedium, item.PrizeLarge);
            ToggleButton tglRegular = itemOrderCtrl.TglBtnRegular;
            ToggleButton tglMedium = itemOrderCtrl.TglBtnMedium;
            ToggleButton tglLarge = itemOrderCtrl.TglBtnLarge;
            TextBox txtboxQty = itemOrderCtrl.TextQty;
            // Implement related evenets
            itemOrderCtrl.BtnMinus.Click += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(itemOrderCtrl.TextQty.Text) && Convert.ToInt32(itemOrderCtrl.TextQty.Text) >= 2)
                    {
                        itemOrderCtrl.TextQty.Text = (Convert.ToInt32(itemOrderCtrl.TextQty.Text) - 1).ToString();
                    }

                };
            itemOrderCtrl.BtnPlus.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(itemOrderCtrl.TextQty.Text))
                {
                    itemOrderCtrl.TextQty.Text = (Convert.ToInt32(itemOrderCtrl.TextQty.Text) + 1).ToString();
                }
            };
            txtboxQty.Paste += (s, e) =>
                    {
                        e.Handled = true;
                    };
            txtboxQty.KeyDown += (s, e) =>
            {

                if (e.KeyStatus.ScanCode == 11 && string.IsNullOrEmpty(txtboxQty.Text.Trim()))
                {
                    e.Handled = true;
                }
                else if (e.KeyStatus.ScanCode >= 0 && e.KeyStatus.ScanCode <= 11)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            };
            txtboxQty.LostFocus += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtboxQty.Text.Trim()) || Convert.ToInt32(txtboxQty.Text.Trim()) == 0)
                {
                    txtboxQty.Text = "1";
                }
            };
            itemOrderCtrl.BtnAddToCart.Click += (s, e) =>
            {
                if (BtnClickAddToCart != null)
                {
                    CartItem cartItem = new CartItem()
                    {
                        Id = item.Id,
                        Text = item.Text,
                        Description = item.Description,
                        Quantity = (Convert.ToInt32(itemOrderCtrl.TextQty.Text)),
                        Size = SizeEnum.Medium,
                        ImgUri = item.ImageUri,
                        PrizePerUnit = item.PrizeMedium,
                        TotalPrize = item.PrizeMedium * Convert.ToInt32(itemOrderCtrl.TextQty.Text),
                    };
                    if (tglRegular.IsChecked == true)
                    {
                        cartItem.Size = SizeEnum.Regular;
                        cartItem.TotalPrize = item.PrizeRegular * Convert.ToInt32(itemOrderCtrl.TextQty.Text);
                    }
                    else if (tglLarge.IsChecked == true)
                    {
                        cartItem.Size = SizeEnum.Large;
                        cartItem.TotalPrize = item.PrizeLarge * Convert.ToInt32(itemOrderCtrl.TextQty.Text);
                    }
                    else { }
                    BtnClickAddToCart(cartItem, e);
                }
            };
            tglRegular.Click += (s, e) =>
            {
                tglLarge.IsChecked = tglMedium.IsChecked = false;
                tglRegular.IsChecked = true;
            };
            tglMedium.Click += (s, e) =>
            {
                tglLarge.IsChecked = tglRegular.IsChecked = false;
                tglMedium.IsChecked = true;
            };
            tglLarge.Click += (s, e) =>
            {
                tglRegular.IsChecked = tglMedium.IsChecked = false;
                tglLarge.IsChecked = true;
            };
            return itemOrderCtrl;
        }
        #endregion
    }
    #endregion
}
