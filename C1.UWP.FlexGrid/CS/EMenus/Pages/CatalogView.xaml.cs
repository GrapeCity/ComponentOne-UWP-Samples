using C1.Xaml;
using C1.Xaml.FlexGrid;
using Grapecity.C1_EMenus.CellFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Grapecity.C1_EMenus.Pages
{
    #region ClassMainPage
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region PrivateVariables
        private List<Category> _categories;
        private int colCnt = 0;
        private ItemCellFactory cellFactory = null;
        private ItemOrderCellFactory cellOrderFactory = null;
        private SubCategory SelectedSubCategory = null;
        private Category SelectedCategory = null;
        private C1TreeViewItem PrevSelecteditem = null;
        private List<CartItem> cartItems = null;
        #endregion

        #region contructor
        public MainPage()
        {
            this.InitializeComponent();
            _categories = Category.Categories;
            cartItems = new List<CartItem>();
            treeView.ItemsSource = _categories;
        }
        #endregion

        #region Events
        void TreeView_ItemClick(object sender, C1.Xaml.SourcedEventArgs e)
        {
            SetPropertiesForSelectedItem(e.Source as C1TreeViewItem);
        }      

        private void Item_ItemPrepared(object sender, ItemPreparedEventArgs e)
        {
            StackPanel stackPanel = (FindVisualChild<StackPanel>(sender as C1TreeViewItem) as StackPanel);
            Path path = stackPanel.FindName("CollapsedIcon") as Path;
            if (path.Visibility == Visibility.Collapsed)
            {
                path.Visibility = Visibility.Visible;
                (stackPanel.FindName("ExpandedIcon") as Path).Visibility = Visibility.Collapsed;
            }
            else
            {
                path.Visibility = Visibility.Collapsed;
                (stackPanel.FindName("ExpandedIcon") as Path).Visibility = Visibility.Visible;
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           _flexOrder.Visibility = Visibility.Collapsed;
            _categories.ForEach(c => c.SubCategories.ForEach(sc => sc.Items.ForEach(t =>
            {
                t.IsEnabled = true;
            })));
            if (!treeView.HasItems)
            {
                SelectedSubCategory = SelectedCategory.SubCategories[0];
            }
            cellFactory = new ItemCellFactory();
            cellOrderFactory = new ItemOrderCellFactory();
            _flexItem.CellFactory = cellFactory;
            cellFactory.ItemClicked += CellFactory_ItemClicked;
            cellOrderFactory.BtnClickAddToCart += CellOrderFactory_BtnClickAddToCart;
            _flexOrder.CellFactory = cellOrderFactory;
            txtSubCategory.Text = SelectedCategory.Text;
            AddItemsInGridBasedOnSelectedCategory();
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            EnableDisableItemsInGrid();
            foreach (Column col in _flexItem.Columns)
            {
                col.FontSize = 5;
                col.FontSize = col.FontSize + 1;
            }
        }
        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(HomePage), null);
            Window.Current.Activate();
        }
        private void Image_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 1);
        }
        private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }
        private void CellFactory_ItemClicked(object sender, RoutedEventArgs e)
        {
            this.gridChoice.Visibility = Visibility.Collapsed;
            _flexItem.Visibility = Visibility.Collapsed;
            _flexOrder.Visibility = Visibility.Visible;
            if (SelectedSubCategory.Name != "All")
            {
                AddItemsInOrderGridBasedOnSelectedSubCategory(SelectedSubCategory, true);
            }
            else
            {
                AddItemInOrderGridBasedOnSelectedCategory();
            }
        }
        private void CellOrderFactory_BtnClickAddToCart(object sender, RoutedEventArgs e)
        {
            if (sender is CartItem)
            {
                cartItems.Add(sender as CartItem);
                TxtItemCnt.Text = cartItems.Count().ToString();
                TxtTotalPrize.Text = "0.00";
                foreach (CartItem item in cartItems)
                {
                    TxtTotalPrize.Text = (Convert.ToDouble(TxtTotalPrize.Text) + item.TotalPrize).ToString();
                }
            }
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            EnableDisableItemsInGrid();
            foreach (Column col in _flexItem.Columns)
            {
                col.FontSize = 5;
                col.FontSize = col.FontSize + 1;
            }
        }
        private void TreeView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count() > 0 && (e.RemovedItems[0] as C1TreeViewItem).DataContext is SubCategory)
            {
                PrevSelecteditem = e.RemovedItems[0] as C1TreeViewItem;
            }
        }
        private void TreeView_ItemPrepared(object sender, ItemPreparedEventArgs e)
        {
            C1TreeViewItem treeViewItem = (e.Element as C1TreeViewItem);
            treeViewItem.Loaded += TreeViewItem_Loaded;
        }
        private void TreeViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            C1TreeViewItem treeViewItem = (C1TreeViewItem)sender;
            if (treeViewItem.DataContext is Category && (treeViewItem.DataContext as Category).Name == SelectedCategory.Name)
            {
                treeViewItem.EnsureVisible();
                treeViewItem.IsSelected = true;
                treeViewItem.IsExpanded = true;
                SetPropertiesForSelectedItem(treeViewItem);
            }
            if (PrevSelecteditem == null && treeViewItem.DataContext is SubCategory && (treeViewItem.DataContext as SubCategory).Name == SelectedCategory.SubCategories[0].Name)
            {
                treeViewItem.EnsureVisible();
                treeViewItem.IsSelected = true;
                SetPropertiesForSelectedItem(treeViewItem);
            }
        }
        #endregion

        #region PrivateMethods
        private void ClearSelectedSubCategoryTreeViewItem(C1TreeViewItem item)
        {
            
                StackPanel stackPanel = (FindVisualChild<StackPanel>(item) as StackPanel);
                stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.Transparent);
                TextBlock textBlock = (FindVisualChild<TextBlock>(item) as TextBlock);
                textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Gray);
           
        }
        private void SetPropertiesForSelectedItem(C1TreeViewItem clickedItem)
        {
            this.gridChoice.Visibility = Visibility.Visible;
            _flexItem.Visibility = Visibility.Visible;
            _flexOrder.Visibility = Visibility.Collapsed;
            try
            {
                StackPanel stackPanel;
                TextBlock textBlock;
                C1TreeViewItem item;
                if (clickedItem.DataContext is Category)
                {
                    SelectedCategory = clickedItem.DataContext as Category;
                    item = (C1TreeViewItem)clickedItem;
                    stackPanel = (FindVisualChild<StackPanel>(item) as StackPanel);
                    Path path = stackPanel.FindName("CollapsedIcon") as Path;
                    if (path.Visibility == Visibility.Collapsed)
                    {
                        path.Visibility = Visibility.Visible;
                        (stackPanel.FindName("ExpandedIcon") as Path).Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        path.Visibility = Visibility.Collapsed;
                        (stackPanel.FindName("ExpandedIcon") as Path).Visibility = Visibility.Visible;
                    }

                }
                else
                {
                    if (PrevSelecteditem != null)
                        ClearSelectedSubCategoryTreeViewItem(PrevSelecteditem);
                    SubCategory subCategory = SelectedSubCategory = (clickedItem.DataContext as SubCategory);
                    item = clickedItem;
                    stackPanel = (FindVisualChild<StackPanel>(item) as StackPanel);
                    stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    textBlock = (FindVisualChild<TextBlock>(item) as TextBlock);
                    textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                    txtSubCategory.Text = SelectedSubCategory.Text;
                    if (SelectedSubCategory.Name == "All")
                    {
                        SelectedCategory = _categories.Where(c => c.Name == SelectedSubCategory.CategoryName).FirstOrDefault();
                        txtSubCategory.Text = SelectedCategory.Text;
                        AddItemsInGridBasedOnSelectedCategory();
                    }
                    else
                    {
                        AddItemsInGridBasedOnSelectedSubCategory(SelectedSubCategory, true);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {                
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        private void AddItemInOrderGridBasedOnSelectedCategory()
        {
            ClearOrderGridColRow();
            foreach (SubCategory subCategory in SelectedCategory.SubCategories)
            {
                AddItemsInOrderGridBasedOnSelectedSubCategory(subCategory, false);
            }
        }
        private void AddItemsInOrderGridBasedOnSelectedSubCategory(SubCategory subCategory, bool isColRowClear)
        {
            if (isColRowClear)
            {
                ClearOrderGridColRow();
            }
            foreach (Item item in subCategory.Items)
            {
                try
                {
                    if (item.IsEnabled)
                    {
                        _flexOrder.Rows.Add(new Row());
                        _flexOrder[_flexOrder.Rows.Count - 1, 0] = item;
                        _flexOrder.Rows[_flexOrder.Rows.Count - 1].Height = 250;
                    }
                                           
                }
                catch (Exception )
                {

                }
            }
        }
        void AddItemsInGridBasedOnSelectedCategory()
        {
            ClearColRow();
            foreach (SubCategory subCategory in SelectedCategory.SubCategories)
            {
                AddItemsInGridBasedOnSelectedSubCategory(subCategory, false);
            }
        }
        private void ClearOrderGridColRow()
        {
            _flexOrder.Columns.Clear();
            _flexOrder.Columns.Add(new Column());
            _flexOrder.Rows.Clear();
            _flexOrder.MinColumnWidth = 800;
        }
        private void ClearColRow()
        {
            _flexItem.Columns.Clear();
            _flexItem.Columns.Add(new Column());
            _flexItem.Rows.Clear();
            _flexItem.Rows.Add(new Row());
             colCnt = 0;
            _flexItem.MinColumnWidth = 250;
        }
        private void AddItemsInGridBasedOnSelectedSubCategory(SubCategory subCategory, bool isColRowClear)
        {
            if (isColRowClear)
            {
                ClearColRow();
            }
            foreach (Item item in subCategory.Items)
            {
                try
                {
                    if (colCnt < 3)
                    {
                        _flexItem[_flexItem.Rows.Count - 1, colCnt] = item;
                        _flexItem.Rows[_flexItem.Rows.Count - 1].Height = 250;
                        if (_flexItem.Rows.Count < 2)
                        {
                            _flexItem.Columns.Add(new Column());
                        }
                        colCnt = colCnt + 1;
                    }
                    else
                    {
                        if (_flexItem.Rows.Count < 2)
                        {
                            _flexItem.Columns.RemoveAt(_flexItem.Columns.Count - 1);
                        }
                        _flexItem.Rows.Add(new Row());
                        colCnt = 0;
                        _flexItem[_flexItem.Rows.Count - 1, colCnt] = item;

                        _flexItem.Rows[_flexItem.Rows.Count - 1].Height = 250;
                        colCnt = colCnt + 1;
                    }
                }
                catch (Exception )
                {

                }
            }
        }        
        private void EnableDisableItemsInGrid()
        {
            _categories.ForEach(c => c.SubCategories.ForEach(sc => sc.Items.ForEach(t =>
                 {
                 if (tglBtnVeg.IsChecked == true && tglBtnNonVeg.IsChecked == true && tglBtnSpecial.IsChecked == true)
                     {
                         t.IsEnabled = true;
                     }
                     else if (tglBtnNonVeg.IsChecked == false && (tglBtnVeg.IsChecked == true && tglBtnSpecial.IsChecked == true))
                     {
                         t.IsEnabled = (t.IsVeg || t.IsSpecial);
                     }
                     else if ((tglBtnNonVeg.IsChecked == true && tglBtnSpecial.IsChecked == true ) && tglBtnVeg.IsChecked == false)
                     {
                         t.IsEnabled = (!t.IsVeg || t.IsSpecial);
                     }
                     else if (tglBtnNonVeg.IsChecked == true &&( tglBtnVeg.IsChecked == false && tglBtnSpecial.IsChecked == false))
                     {
                         t.IsEnabled = !t.IsVeg ;
                     }
                     else if (tglBtnVeg.IsChecked == true && (tglBtnNonVeg.IsChecked == false && tglBtnSpecial.IsChecked == false))
                     {
                         t.IsEnabled = t.IsVeg;
                     }
                     else if (tglBtnSpecial.IsChecked == true && (tglBtnVeg.IsChecked == false && tglBtnNonVeg.IsChecked == false))
                     {
                         t.IsEnabled = t.IsSpecial;
                     }
                     else
                     {
                         t.IsEnabled = true;
                     }
                 })));
        }        
        #endregion
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var category = e.Parameter as Category;            
            SelectedCategory = category;
            base.OnNavigatedTo(e);
        }  
    }
    #endregion
}
