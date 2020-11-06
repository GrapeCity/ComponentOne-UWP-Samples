using C1.Xaml.FlexGrid;
using Grapecity.C1_EMenus.CellFactories;
using Grapecity.C1_EMenus.Pages;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Grapecity.C1_EMenus
{
    #region ClassHomePage
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        #region PrivateVariables
        private CategoryCellFactory cell = null;
        #endregion

        #region Contructor
        public HomePage()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cell = new CategoryCellFactory();
            _flexCategory.CellFactory = cell;
            AddCategoryImagesInGrid();
        }
        #endregion

        #region PrivateMethods
        private void AddCategoryImagesInGrid()
        {
            _flexCategory.Columns.Clear();
            _flexCategory.Columns.Add(new Column());
            _flexCategory.Rows.Clear();
            _flexCategory.Rows.Add(new Row());
            int colCnt = 0;
            _flexCategory.MinColumnWidth = 300;
            foreach (Category category in Category.Categories)
            {
                try
                {
                    if (colCnt < 3)
                    {
                        _flexCategory[_flexCategory.Rows.Count - 1, colCnt] = category;
                        _flexCategory.Rows[_flexCategory.Rows.Count - 1].Height = 270;
                        if (_flexCategory.Rows.Count < 2)
                        {
                            _flexCategory.Columns.Add(new Column());
                        }
                        colCnt = colCnt + 1;
                    }
                    else
                    {
                        if (_flexCategory.Rows.Count < 2)
                        {
                            _flexCategory.Columns.RemoveAt(_flexCategory.Columns.Count - 1);
                        }
                        _flexCategory.Rows.Add(new Row());
                        colCnt = 0;
                        _flexCategory[_flexCategory.Rows.Count - 1, colCnt] = category;

                        _flexCategory.Rows[_flexCategory.Rows.Count - 1].Height = 270;
                        colCnt = colCnt + 1;
                    }
                }
                catch (Exception )
                {
                  
                }
            }
        }
        #endregion
    }
    #endregion
}