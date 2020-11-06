Imports Windows.UI.Xaml
Imports C1.Xaml

''' <summary>
''' Selects a style for the nodes that are ancestors of a C1.Silverlight assembly class
''' so they start with the IsExpanded property set to True
''' </summary>
Public Class CustomStyleSelector
    Inherits C1StyleSelector
    Protected Overrides Function SelectStyleCore(item As Object, container As DependencyObject) As Style
        Dim group As WorldCupGroup = TryCast((CType(container, C1TreeViewItem)).Header, WorldCupGroup)
        If group IsNot Nothing Then
            Return CType(Resources("ExpandedStyle"), Style)
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