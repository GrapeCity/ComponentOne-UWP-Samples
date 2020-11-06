Imports C1.Xaml
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System

Public NotInheritable Partial Class DragDrop
		Inherits Page
		Public Sub New()
			Me.InitializeComponent()
			SampleTreeView.ItemsSource = BuildDepartmentTree()

			SampleTreeView.AllowDragDrop = True
		End Sub

		Private Function BuildDepartmentTree() As ObservableCollection(Of Object)
			Dim itemsSource As New ObservableCollection(Of Object)()
			Dim departmentDirectory As IDictionary(Of Integer, Department) = New Dictionary(Of Integer, Department)()

			' insert all departments as root nodes
			Dim departments As List(Of Department) = DataLoader.LoadDepartments()
			For Each d As Department In departments
				itemsSource.Add(d)
				departmentDirectory.Add(d.DepartmentID, d)
			Next

			' insert all employees in their corresponding department
			Dim employees As List(Of Employee) = DataLoader.LoadEmployees()
			For Each e As Employee In employees
				Dim d As Department = departmentDirectory(e.DepartmentID)
				d.Employees.Add(e)
			Next

			Return itemsSource
		End Function

		Private Sub OnButtonChecked(sender As Object, e As RoutedEventArgs)
			Dim rb As RadioButton = TryCast(sender, RadioButton)
			If SampleTreeView IsNot Nothing Then
				SampleTreeView.DropAction = If((rb.Name.CompareTo("Move") = 0), DropAction.Move, DropAction.Copy)
			End If
		End Sub
End Class