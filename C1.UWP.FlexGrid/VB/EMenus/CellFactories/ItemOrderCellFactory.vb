Imports C1.Xaml.FlexGrid

#Region "ClassItemOrderCellFactory"
Class ItemOrderCellFactory
    Inherits CellFactory
#Region "EventHandler"
    Public Event BtnClickAddToCart As RoutedEventHandler
#End Region

#Region "PrivateVariables"
    Private item As Item
#End Region

#Region "OverrideMethods"
    'override CreateCell
    Public Overrides Function CreateCell(grid As C1FlexGrid, cellType As CellType, rng As CellRange) As FrameworkElement

        If grid(rng.Row, rng.Column) Is Nothing Then
            Return MyBase.CreateCell(grid, cellType, rng)
        End If
        item = (TryCast(grid(rng.Row, rng.Column), Item))
        Dim itemOrderCtrl As New ItemOrderCtrl(item.ImageUri, item.Text, item.Description, item.Rating, item.IsVeg, item.IsSpecial,
                item.PrizeRegular, item.PrizeMedium, item.PrizeLarge)
        Dim tglRegular As ToggleButton = itemOrderCtrl.TglBtnRegular
        Dim tglMedium As ToggleButton = itemOrderCtrl.TglBtnMedium
        Dim tglLarge As ToggleButton = itemOrderCtrl.TglBtnLarge
        Dim txtboxQty As TextBox = itemOrderCtrl.TextQty
        ' Implement related evenets
        AddHandler itemOrderCtrl.BtnMinus.Click, Function(s, e)
                                                     If Not String.IsNullOrEmpty(itemOrderCtrl.TextQty.Text) AndAlso Convert.ToInt32(itemOrderCtrl.TextQty.Text) >= 2 Then
                                                         itemOrderCtrl.TextQty.Text = (Convert.ToInt32(itemOrderCtrl.TextQty.Text) - 1).ToString()

                                                     End If
                                                     Return True
                                                 End Function
        AddHandler itemOrderCtrl.BtnPlus.Click, Function(s, e)
                                                    If Not String.IsNullOrEmpty(itemOrderCtrl.TextQty.Text) Then
                                                        itemOrderCtrl.TextQty.Text = (Convert.ToInt32(itemOrderCtrl.TextQty.Text) + 1).ToString()
                                                    End If
                                                    Return True
                                                End Function
        AddHandler txtboxQty.Paste, Function(s, e)
                                        e.Handled = True
                                        Return True
                                    End Function
        AddHandler txtboxQty.KeyDown, Function(s, e)
                                          If e.KeyStatus.ScanCode = 11 AndAlso String.IsNullOrEmpty(txtboxQty.Text.Trim()) Then
                                              e.Handled = True
                                          ElseIf e.KeyStatus.ScanCode >= 0 AndAlso e.KeyStatus.ScanCode <= 11 Then
                                              e.Handled = False
                                          Else
                                              e.Handled = True
                                          End If
                                          Return True
                                      End Function
        AddHandler txtboxQty.LostFocus, Function(s, e)
                                            If String.IsNullOrEmpty(txtboxQty.Text.Trim()) OrElse Convert.ToInt32(txtboxQty.Text.Trim()) = 0 Then
                                                txtboxQty.Text = "1"
                                            End If
                                            Return True
                                        End Function
        AddHandler itemOrderCtrl.BtnAddToCart.Click, Function(s, e)
                                                         Dim cartItem As New CartItem() With {
                                                         .Id = item.Id,
                                                         .Text = item.Text,
                                                         .Description = item.Description,
                                                         .Quantity = (Convert.ToInt32(itemOrderCtrl.TextQty.Text)),
                                                         .Size = SizeEnum.Medium,
                                                         .ImgUri = item.ImageUri,
                                                         .PrizePerUnit = item.PrizeMedium,
                                                         .TotalPrize = item.PrizeMedium * Convert.ToInt32(itemOrderCtrl.TextQty.Text)}
                                                         If tglRegular.IsChecked = True Then
                                                             cartItem.Size = SizeEnum.Regular
                                                             cartItem.TotalPrize = item.PrizeRegular * Convert.ToInt32(itemOrderCtrl.TextQty.Text)
                                                         ElseIf tglLarge.IsChecked = True Then
                                                             cartItem.Size = SizeEnum.Large
                                                             cartItem.TotalPrize = item.PrizeLarge * Convert.ToInt32(itemOrderCtrl.TextQty.Text)
                                                         Else
                                                         End If
                                                         RaiseEvent BtnClickAddToCart(cartItem, e)
                                                         Return True
                                                     End Function
        AddHandler tglRegular.Click, Function(s, e)
                                         tglLarge.IsChecked = tglMedium.IsChecked = False
                                         tglRegular.IsChecked = True
                                         Return True
                                     End Function
        AddHandler tglMedium.Click, Function(s, e)
                                        tglLarge.IsChecked = tglRegular.IsChecked = False
                                        tglMedium.IsChecked = True
                                        Return True
                                    End Function
        AddHandler tglLarge.Click, Function(s, e)
                                       tglRegular.IsChecked = tglMedium.IsChecked = False
                                       tglLarge.IsChecked = True
                                       Return True
                                   End Function
        Return itemOrderCtrl
    End Function
#End Region
End Class
#End Region