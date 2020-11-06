Imports C1.Xaml

Public Class CustomTemplateSelector
    Inherits C1DataTemplateSelector
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        If TypeOf item Is Category Then
            Return TryCast(Resources("CategoryTemplate"), DataTemplate)
        End If
        If TypeOf item Is SubCategory Then
            Return TryCast(Resources("SubCategoryTemplate"), DataTemplate)
        End If
        Return Nothing
    End Function
End Class
