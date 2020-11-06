using C1.Xaml.FlexGrid;
using Grapecity.C1_EMenus.Controls;
using Grapecity.C1_EMenus.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Grapecity.C1_EMenus.CellFactories
{
    #region ClassCategoryCellFactory
    class CategoryCellFactory : CellFactory
    {
        #region PrivateVariables
        private Button imgBtn;
        private CategoryCtrl categoryCtrl;
        private Category category;
        #endregion

        #region OverrideMethods
        //Override CreateCell
        public override FrameworkElement CreateCell(C1FlexGrid grid, CellType cellType, CellRange rng)
        {
            category = grid[rng.Row, rng.Column] as Category;
            if (category == null)
                return base.CreateCell(grid, cellType, rng);
            categoryCtrl = new CategoryCtrl(category.ImageUri,category.Name);
            imgBtn = categoryCtrl.ImgButton;
            //Implement related events
            imgBtn.Click += (s, e) =>
            {
                (Window.Current.Content as Frame).Navigate(typeof(MainPage), category);
                Window.Current.Activate();
            };
            return categoryCtrl;
        }
        #endregion
    }
    #endregion
}
