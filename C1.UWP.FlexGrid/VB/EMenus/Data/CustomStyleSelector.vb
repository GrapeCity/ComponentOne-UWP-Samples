Imports C1.Xaml
Public Class CustomStyleSelector
    Inherits C1StyleSelector

    Protected Overrides Function SelectStyleCore(item As Object, container As DependencyObject) As Style
        Dim tvi As C1TreeViewItem = CType(container, C1TreeViewItem)
        If TypeOf tvi.Header Is Category Then
            Dim style As Style = (CType(Resources("ExpandedStyle"), Style))

            Return style
        End If

        If TypeOf tvi.Header Is SubCategory Then

            Return CType(Resources("ExpandedStyle"), Style)
        End If
        Return Nothing
    End Function
End Class