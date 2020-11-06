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

Public Class DayOfWeekTemplateSelector
    Inherits C1.Xaml.C1DataTemplateSelector
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Dim slot As DayOfWeekSlot = TryCast(item, DayOfWeekSlot)
        If slot IsNot Nothing AndAlso slot.DayOfWeek = DayOfWeek.Saturday Then
            ' set color for Saturday
            DirectCast(container, Control).Foreground = New SolidColorBrush(Color.FromArgb(255, 0, 191, 255))
        End If
        ' don't change DataTemplate at all
        Return Nothing
    End Function
End Class
