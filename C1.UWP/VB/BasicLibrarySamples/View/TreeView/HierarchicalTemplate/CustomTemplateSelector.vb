Imports Windows.UI.Xaml
Imports C1.Xaml

''' <summary>
''' Selects a data template depending on the assembly of the type stored in the data object.
''' If the type belongs to the C1.Silverlight assembly then the DataTemplate
''' with key=C1DataTemplate is selected, otherwise the DataTemplate with key=SilverlightDataTemplate
''' is selected
''' </summary>
Public Class CustomTemplateSelector
    Inherits C1DataTemplateSelector
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Dim group As WorldCupGroup = TryCast(item, WorldCupGroup)
        Dim team As WorldCupTeam = TryCast(item, WorldCupTeam)

        If group IsNot Nothing Then
            Return TryCast(Resources("GroupTemplate"), DataTemplate)
        End If

        If team IsNot Nothing Then
            Return TryCast(Resources("TeamTemplate"), DataTemplate)
        End If

        Return Nothing
    End Function

    Public Overrides Property Resources() As ResourceDictionary
        Get
            Return MyBase.Resources
        End Get
        Set
            MyBase.Resources = Value
        End Set
    End Property
End Class