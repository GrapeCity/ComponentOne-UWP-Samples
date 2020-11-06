Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Calendar

Public Class DaySlotTemplateSelector
    Inherits C1.Xaml.Calendar.DaySlotTemplateSelector
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Dim slot As DaySlot = TryCast(item, DaySlot)
        If slot IsNot Nothing AndAlso Not slot.IsAdjacent AndAlso slot.DayOfWeek = DayOfWeek.Saturday Then
            ' set color for Saturday
            DirectCast(container, Control).Foreground = New SolidColorBrush(Color.FromArgb(255, 0, 191, 255))
        End If
        ' the base class will select custom DataTemplate, defined in the DaySlotTemplateSelector.Resources collection (see MainPage.xaml file)
        Return MyBase.SelectTemplateCore(item, container)
    End Function
End Class
