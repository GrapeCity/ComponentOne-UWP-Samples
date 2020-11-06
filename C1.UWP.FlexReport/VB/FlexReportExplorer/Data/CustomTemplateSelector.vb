Imports C1.Xaml

Public Class CustomTemplateSelector
    Inherits C1DataTemplateSelector

    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Dim group = TryCast(item, Category)
        If group IsNot Nothing Then
            If group.Name = "Separator" Then
                Return TryCast(Resources("CategorySeparatorTemplate"), DataTemplate)
            End If
            Return TryCast(Resources("CategoryTemplate"), DataTemplate)
        End If
        If TypeOf item Is Report Then
            Return TryCast(Resources("ReportTemplate"), DataTemplate)
        End If
        Return Nothing
    End Function

End Class