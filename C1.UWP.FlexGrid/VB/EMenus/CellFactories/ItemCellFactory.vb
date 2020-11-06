Imports C1.Xaml.FlexGrid

#Region "ClassItemCellFactory"
Class ItemCellFactory
    Inherits CellFactory
#Region "EventHandler"
    Public Event ItemClicked As RoutedEventHandler
#End Region

#Region "PrivateVariables"
    Private imgBtn As Button
    Private itemImageCtrl As ItemImageCtrl
    Private item As Item
#End Region

#Region "OverrideMethods"
    'Override CreateCell
    Public Overrides Function CreateCell(grid As C1FlexGrid, cellType As CellType, rng As CellRange) As FrameworkElement
        item = TryCast(grid(rng.Row, rng.Column), Item)
        If item Is Nothing Then
            Return MyBase.CreateCell(grid, cellType, rng)
        End If
        itemImageCtrl = New ItemImageCtrl(item.ImageUri, item.Text, item.Rating, item.IsEnabled, item.IsVeg, item.IsSpecial)
        imgBtn = itemImageCtrl.ImgButton
        If Not item.IsEnabled Then
            itemImageCtrl.Opacity = 0.2
        End If
        'Implement related events
        AddHandler imgBtn.Click, Function(s, e)
                                     RaiseEvent ItemClicked(item, e)
                                     Return True
                                 End Function
        Return itemImageCtrl
    End Function
#End Region
End Class
#End Region