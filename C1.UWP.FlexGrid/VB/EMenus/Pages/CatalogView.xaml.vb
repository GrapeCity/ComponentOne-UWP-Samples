Imports C1.Xaml
Imports C1.Xaml.FlexGrid
Imports Windows.UI.Core
Imports Windows.UI.Xaml.Shapes

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
#Region "ClassMainPage"
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits Page
#Region "PrivateVariables"
    Private _categories As List(Of Category)
    Private colCnt As Integer = 0
    Private cellFactory As ItemCellFactory = Nothing
    Private cellOrderFactory As ItemOrderCellFactory = Nothing
    Private SelectedSubCategory As SubCategory = Nothing
    Private SelectedCategory As Category = Nothing
    Private PrevSelecteditem As C1TreeViewItem = Nothing
    Private cartItems As List(Of CartItem) = Nothing
#End Region

#Region "contructor"
    Public Sub New()
        Me.InitializeComponent()
        _categories = Category.Categories
        cartItems = New List(Of CartItem)()
        treeView.ItemsSource = _categories
    End Sub
#End Region

#Region "Events"
    Sub TreeView_ItemClick(sender As Object, e As C1.Xaml.SourcedEventArgs)
        SetPropertiesForSelectedItem()
    End Sub

    Private Sub Item_ItemPrepared(sender As Object, e As ItemPreparedEventArgs)
        Dim stackPanel As StackPanel = (TryCast(FindVisualChild(Of StackPanel)(TryCast(sender, C1TreeViewItem)), StackPanel))
        Dim path As Path = TryCast(stackPanel.FindName("CollapsedIcon"), Path)
        If path.Visibility = Visibility.Collapsed Then
            path.Visibility = Visibility.Visible
            TryCast(stackPanel.FindName("ExpandedIcon"), Path).Visibility = Visibility.Collapsed
        Else
            path.Visibility = Visibility.Collapsed
            TryCast(stackPanel.FindName("ExpandedIcon"), Path).Visibility = Visibility.Visible
        End If
    End Sub
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        _flexOrder.Visibility = Visibility.Collapsed
        _categories.ForEach(Function(c)
                                c.SubCategories.ForEach(Function(sc)
                                                            sc.Items.ForEach(Function(t)
                                                                                 t.IsEnabled = True
                                                                                 Return True
                                                                             End Function)
                                                            Return True
                                                        End Function)
                                Return True
                            End Function)
        If Not treeView.HasItems Then
            SelectedSubCategory = SelectedCategory.SubCategories(0)
        End If
        cellFactory = New ItemCellFactory()
        cellOrderFactory = New ItemOrderCellFactory()
        _flexItem.CellFactory = cellFactory
        AddHandler cellFactory.ItemClicked, AddressOf CellFactory_ItemClicked
        AddHandler cellOrderFactory.BtnClickAddToCart, AddressOf CellOrderFactory_BtnClickAddToCart
        _flexOrder.CellFactory = cellOrderFactory
        txtSubCategory.Text = SelectedCategory.Text
        AddItemsInGridBasedOnSelectedCategory()
    End Sub
    Private Sub ToggleButton_Unchecked(sender As Object, e As RoutedEventArgs)
        EnableDisableItemsInGrid()
        For Each col As Column In _flexItem.Columns
            col.FontSize = 5
            col.FontSize = col.FontSize + 1
        Next
    End Sub
    Private Sub Image_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        TryCast(Window.Current.Content, Frame).Navigate(GetType(HomePage), Nothing)
        Window.Current.Activate()
    End Sub
    Private Sub Image_PointerEntered(sender As Object, e As PointerRoutedEventArgs)
        Window.Current.CoreWindow.PointerCursor = New CoreCursor(CoreCursorType.Hand, 1)
    End Sub
    Private Sub Image_PointerExited(sender As Object, e As PointerRoutedEventArgs)
        Window.Current.CoreWindow.PointerCursor = New CoreCursor(CoreCursorType.Arrow, 1)
    End Sub
    Private Sub CellFactory_ItemClicked(sender As Object, e As RoutedEventArgs)
        Me.gridChoice.Visibility = Visibility.Collapsed
        _flexItem.Visibility = Visibility.Collapsed
        _flexOrder.Visibility = Visibility.Visible
        If SelectedSubCategory.Name <> "All" Then
            AddItemsInOrderGridBasedOnSelectedSubCategory(SelectedSubCategory, True)
        Else
            AddItemInOrderGridBasedOnSelectedCategory()
        End If
    End Sub
    Private Sub CellOrderFactory_BtnClickAddToCart(sender As Object, e As RoutedEventArgs)
        If TypeOf sender Is CartItem Then
            cartItems.Add(TryCast(sender, CartItem))
            TxtItemCnt.Text = cartItems.Count().ToString()
            TxtTotalPrize.Text = "0.00"
            For Each item As CartItem In cartItems
                TxtTotalPrize.Text = (Convert.ToDouble(TxtTotalPrize.Text) + item.TotalPrize).ToString()
            Next
        End If
    End Sub
    Private Sub ToggleButton_Checked(sender As Object, e As RoutedEventArgs)
        EnableDisableItemsInGrid()
        For Each col As Column In _flexItem.Columns
            col.FontSize = 5
            col.FontSize = col.FontSize + 1
        Next
    End Sub
    Private Sub TreeView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If e.RemovedItems.Count() > 0 AndAlso TypeOf (TryCast(e.RemovedItems(0), C1TreeViewItem)).DataContext Is SubCategory Then
            PrevSelecteditem = TryCast(e.RemovedItems(0), C1TreeViewItem)
        End If
    End Sub
    Private Sub TreeView_ItemPrepared(sender As Object, e As ItemPreparedEventArgs)
        Dim treeViewItem As C1TreeViewItem = (TryCast(e.Element, C1TreeViewItem))
        AddHandler treeViewItem.Loaded, AddressOf TreeViewItem_Loaded
    End Sub
    Private Sub TreeViewItem_Loaded(sender As Object, e As RoutedEventArgs)
        Dim treeViewItem As C1TreeViewItem = CType(sender, C1TreeViewItem)
        If TypeOf treeViewItem.DataContext Is Category AndAlso (TryCast(treeViewItem.DataContext, Category)).Name = SelectedCategory.Name Then
            treeViewItem.EnsureVisible()
            treeViewItem.IsSelected = True
            treeViewItem.IsExpanded = True
            SetPropertiesForSelectedItem()
        End If
        If PrevSelecteditem Is Nothing AndAlso TypeOf treeViewItem.DataContext Is SubCategory AndAlso (TryCast(treeViewItem.DataContext, SubCategory)).Name = SelectedCategory.SubCategories(0).Name Then
            treeViewItem.EnsureVisible()
            treeViewItem.IsSelected = True
            SetPropertiesForSelectedItem()
        End If
    End Sub
#End Region

#Region "PrivateMethods"
    Private Sub ClearSelectedSubCategoryTreeViewItem(item As C1TreeViewItem)

        Dim stackPanel As StackPanel = (TryCast(FindVisualChild(Of StackPanel)(item), StackPanel))
        stackPanel.Background = New SolidColorBrush(Windows.UI.Colors.Transparent)
        Dim textBlock As TextBlock = (TryCast(FindVisualChild(Of TextBlock)(item), TextBlock))
        textBlock.Foreground = New SolidColorBrush(Windows.UI.Colors.Gray)

    End Sub
    Private Sub SetPropertiesForSelectedItem()
        Me.gridChoice.Visibility = Visibility.Visible
        _flexItem.Visibility = Visibility.Visible
        _flexOrder.Visibility = Visibility.Collapsed
        Try
            Dim stackPanel As StackPanel
            Dim textBlock As TextBlock
            Dim item As C1TreeViewItem
            If TypeOf treeView.SelectedItem.DataContext Is Category Then
                SelectedCategory = TryCast(treeView.SelectedItem.DataContext, Category)
                item = CType(treeView.SelectedItem, C1TreeViewItem)
                stackPanel = (TryCast(FindVisualChild(Of StackPanel)(item), StackPanel))
                Dim path As Path = TryCast(stackPanel.FindName("CollapsedIcon"), Path)
                If path.Visibility = Visibility.Collapsed Then
                    path.Visibility = Visibility.Visible
                    TryCast(stackPanel.FindName("ExpandedIcon"), Path).Visibility = Visibility.Collapsed
                Else
                    path.Visibility = Visibility.Collapsed
                    TryCast(stackPanel.FindName("ExpandedIcon"), Path).Visibility = Visibility.Visible
                End If
            Else
                If PrevSelecteditem IsNot Nothing Then
                    ClearSelectedSubCategoryTreeViewItem(PrevSelecteditem)
                End If
                SelectedSubCategory = TryCast(treeView.SelectedItem.DataContext, SubCategory)
                item = treeView.SelectedItem
                stackPanel = (TryCast(FindVisualChild(Of StackPanel)(item), StackPanel))
                stackPanel.Background = New SolidColorBrush(Windows.UI.Colors.Green)
                textBlock = (TryCast(FindVisualChild(Of TextBlock)(item), TextBlock))
                textBlock.Foreground = New SolidColorBrush(Windows.UI.Colors.White)
                txtSubCategory.Text = SelectedSubCategory.Text
                If SelectedSubCategory.Name = "All" Then
                    SelectedCategory = _categories.Where(Function(c) c.Name = SelectedSubCategory.CategoryName).FirstOrDefault()
                    txtSubCategory.Text = SelectedCategory.Text
                    AddItemsInGridBasedOnSelectedCategory()
                Else
                    AddItemsInGridBasedOnSelectedSubCategory(SelectedSubCategory, True)
                End If
            End If

        Catch generatedExceptionName As Exception
        End Try
    End Sub
    Private Shared Function FindVisualChild(Of T As DependencyObject)(parent As DependencyObject) As T
        Dim i As Integer = 0
        While i < VisualTreeHelper.GetChildrenCount(parent)
            Dim child As DependencyObject = VisualTreeHelper.GetChild(parent, i)
            If child IsNot Nothing AndAlso TypeOf child Is T Then
                Return CType(child, T)
            Else
                Dim childOfChild As T = FindVisualChild(Of T)(child)
                If childOfChild IsNot Nothing Then
                    Return childOfChild
                End If
            End If
            i += 1
        End While
        Return Nothing
    End Function
    Private Sub AddItemInOrderGridBasedOnSelectedCategory()
        ClearOrderGridColRow()
        For Each subCategory As SubCategory In SelectedCategory.SubCategories
            AddItemsInOrderGridBasedOnSelectedSubCategory(subCategory, False)
        Next
    End Sub
    Private Sub AddItemsInOrderGridBasedOnSelectedSubCategory(subCategory As SubCategory, isColRowClear As Boolean)
        If isColRowClear Then
            ClearOrderGridColRow()
        End If
        For Each item As Item In subCategory.Items
            Try
                If item.IsEnabled Then
                    _flexOrder.Rows.Add(New Row())
                    _flexOrder(_flexOrder.Rows.Count - 1, 0) = item
                    _flexOrder.Rows(_flexOrder.Rows.Count - 1).Height = 250

                End If

            Catch generatedExceptionName As Exception
            End Try
        Next
    End Sub
    Sub AddItemsInGridBasedOnSelectedCategory()
        ClearColRow()
        For Each subCategory As SubCategory In SelectedCategory.SubCategories
            AddItemsInGridBasedOnSelectedSubCategory(subCategory, False)
        Next
    End Sub
    Private Sub ClearOrderGridColRow()
        _flexOrder.Columns.Clear()
        _flexOrder.Columns.Add(New Column())
        _flexOrder.Rows.Clear()
        _flexOrder.MinColumnWidth = 800
    End Sub
    Private Sub ClearColRow()
        _flexItem.Columns.Clear()
        _flexItem.Columns.Add(New Column())
        _flexItem.Rows.Clear()
        _flexItem.Rows.Add(New Row())
        colCnt = 0
        _flexItem.MinColumnWidth = 250
    End Sub
    Private Sub AddItemsInGridBasedOnSelectedSubCategory(subCategory As SubCategory, isColRowClear As Boolean)
        If isColRowClear Then
            ClearColRow()
        End If
        For Each item As Item In subCategory.Items
            Try
                If colCnt < 3 Then
                    _flexItem(_flexItem.Rows.Count - 1, colCnt) = item
                    _flexItem.Rows(_flexItem.Rows.Count - 1).Height = 250
                    If _flexItem.Rows.Count < 2 Then
                        _flexItem.Columns.Add(New Column())
                    End If
                    colCnt = colCnt + 1
                Else
                    If _flexItem.Rows.Count < 2 Then
                        _flexItem.Columns.RemoveAt(_flexItem.Columns.Count - 1)
                    End If
                    _flexItem.Rows.Add(New Row())
                    colCnt = 0
                    _flexItem(_flexItem.Rows.Count - 1, colCnt) = item

                    _flexItem.Rows(_flexItem.Rows.Count - 1).Height = 250
                    colCnt = colCnt + 1
                End If
            Catch generatedExceptionName As Exception
            End Try
        Next
    End Sub
    Private Sub EnableDisableItemsInGrid()
        _categories.ForEach(Function(c)
                                c.SubCategories.ForEach(Function(sc)
                                                            sc.Items.ForEach(Function(t)
                                                                                 If tglBtnVeg.IsChecked = True AndAlso tglBtnNonVeg.IsChecked = True AndAlso tglBtnSpecial.IsChecked = True Then
                                                                                     t.IsEnabled = True
                                                                                 ElseIf tglBtnNonVeg.IsChecked = False AndAlso (tglBtnVeg.IsChecked = True AndAlso tglBtnSpecial.IsChecked = True) Then
                                                                                     t.IsEnabled = (t.IsVeg OrElse t.IsSpecial)
                                                                                 ElseIf (tglBtnNonVeg.IsChecked = True AndAlso tglBtnSpecial.IsChecked = True) AndAlso tglBtnVeg.IsChecked = False Then
                                                                                     t.IsEnabled = (Not t.IsVeg OrElse t.IsSpecial)
                                                                                 ElseIf tglBtnNonVeg.IsChecked = True AndAlso (tglBtnVeg.IsChecked = False AndAlso tglBtnSpecial.IsChecked = False) Then
                                                                                     t.IsEnabled = Not t.IsVeg
                                                                                 ElseIf tglBtnVeg.IsChecked = True AndAlso (tglBtnNonVeg.IsChecked = False AndAlso tglBtnSpecial.IsChecked = False) Then
                                                                                     t.IsEnabled = t.IsVeg
                                                                                 ElseIf tglBtnSpecial.IsChecked = True AndAlso (tglBtnVeg.IsChecked = False AndAlso tglBtnNonVeg.IsChecked = False) Then
                                                                                     t.IsEnabled = t.IsSpecial
                                                                                 Else
                                                                                     t.IsEnabled = True
                                                                                 End If
                                                                                 Return True
                                                                             End Function)
                                                            Return True
                                                        End Function)
                                Return True
                            End Function)
    End Sub
#End Region
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        Dim category As Category = TryCast(e.Parameter, Category)
        SelectedCategory = category
        MyBase.OnNavigatedTo(e)
    End Sub
End Class
#End Region