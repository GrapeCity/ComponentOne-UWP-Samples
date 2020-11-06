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
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class FlexGridDemo
    Inherits Page
    Private _view As C1.Xaml.C1CollectionView

    Public Sub New()
        Me.InitializeComponent()
        ' create an observable list of customers
        Dim list As New System.Collections.ObjectModel.ObservableCollection(Of Customer)()
        Dim i As Integer = 0
        While i < 1000
            list.Add(New Customer())
            i += 1
        End While

        ' create a C1CollectionView from the list 
        ' (it supports sorting, filtering, and grouping)
        _view = New C1.Xaml.C1CollectionView(list)

        ' sort and group customers by country
        _view.SortDescriptions.Add(New C1.Xaml.SortDescription("Country", C1.Xaml.ListSortDirection.Ascending))
        _view.GroupDescriptions.Add(New C1.Xaml.PropertyGroupDescription("Country"))

        ' for MVVM scenarios, simply make the C1CollectionView an exposed property on the view model and bind to it
        c1FlexGrid1.ItemsSource = _view

        'c1FlexGrid1.FrozenColumns = 2;
        c1FlexGrid1.Columns("Weight").GroupAggregate = C1.Xaml.FlexGrid.Aggregate.Sum
    End Sub

    Private Sub mergeCountry_Click(sender As Object, e As RoutedEventArgs)
        c1FlexGrid1.Columns("Country").AllowMerging = CType(mergeCountry.IsChecked, Boolean)
    End Sub
End Class