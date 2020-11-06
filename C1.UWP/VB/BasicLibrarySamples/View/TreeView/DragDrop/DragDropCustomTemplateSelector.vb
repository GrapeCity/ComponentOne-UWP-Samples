Imports Windows.UI.Xaml
Imports C1.Xaml
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Selects a data template depending on the business object.
''' If the business object represents a Department it gets the DepartmentTemplate.
''' If the business object represents an Employee, then it selects the MaleEmployeeTemplate
''' or the FemaleEmployeeTemplate depending on the Gender property of each employee.
''' </summary>
Public Class DragDropCustomTemplateSelector
    Inherits C1DataTemplateSelector
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        If TypeOf item Is Department Then
            Return TryCast(Resources("DepartmentTemplate"), DataTemplate)
        Else
            Dim employee As Employee = CType(item, Employee)
            Dim templateKey As String = If((employee.Gender = "M"c), "MaleEmployeeTemplate", "FemaleEmployeeTemplate")
            Return TryCast(Resources(templateKey), DataTemplate)
        End If
    End Function

    Public Overrides Property Resources() As ResourceDictionary
End Class