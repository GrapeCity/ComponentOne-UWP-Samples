Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System

''' <summary>
''' Business object used to represent a Department.
''' </summary>
Public Class Department
    Public Sub New()
        Employees = New ObservableCollection(Of Employee)()
    End Sub

    Public Property DepartmentID() As Integer
    Public Property Name() As String
    Public Property GroupName() As String
    Public Property Employees() As ObservableCollection(Of Employee)
End Class