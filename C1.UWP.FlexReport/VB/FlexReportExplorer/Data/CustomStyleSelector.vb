Imports C1.Xaml

Public Class CustomStyleSelector
    Inherits C1StyleSelector

    Protected Overrides Function SelectStyleCore(item As Object, container As DependencyObject) As Style
        Dim tvi = DirectCast(container, C1TreeViewItem)
        If TypeOf tvi.Header Is Category Then
            tvi.SetBinding(C1TreeViewItem.IsExpandedProperty, New Binding() With {
                .Source = tvi.Header,
                .Path = New PropertyPath("IsExpanded"),
                .Mode = BindingMode.TwoWay
            })
            Return DirectCast(Resources("ExpandedStyle"), Style)
        End If
        If TypeOf tvi.Header Is Report Then
            tvi.SetBinding(C1TreeViewItem.IsSelectedProperty, New Binding() With {
                .Source = tvi.Header,
                .Path = New PropertyPath("IsSelected"),
                .Mode = BindingMode.TwoWay
            })
        End If
        Return Nothing
    End Function

End Class
