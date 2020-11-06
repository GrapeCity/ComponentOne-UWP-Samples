Imports C1.Xaml.FlexGrid

#Region "ClassCategoryCellFactory"
Class CategoryCellFactory
    Inherits CellFactory
#Region "PrivateVariables"
    Private imgBtn As Button
    Private categoryCtrl As CategoryCtrl
    Private category As Category
#End Region

#Region "OverrideMethods"
    'Override CreateCell
    Public Overrides Function CreateCell(grid As C1FlexGrid, cellType As CellType, rng As CellRange) As FrameworkElement
        category = TryCast(grid(rng.Row, rng.Column), Category)
        If category Is Nothing Then
            Return MyBase.CreateCell(grid, cellType, rng)
        End If
        categoryCtrl = New CategoryCtrl(category.ImageUri, category.Name)
        imgBtn = categoryCtrl.ImgButton
        'Implement related events
        AddHandler imgBtn.Click, Function(s, e)
                                     TryCast(Window.Current.Content, Frame).Navigate(GetType(MainPage), category)
                                     Window.Current.Activate()
                                     Return True
                                 End Function
        Return categoryCtrl
    End Function
#End Region
End Class
#End Region