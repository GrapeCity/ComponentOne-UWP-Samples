Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.UI
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.FlexGrid
Imports C1.Xaml

Partial Public Class GridTreeViewSample
    Inherits Page
    Private _person As Person
    Private _rnd As New Random()
    Private Persons As New ObservableCollection(Of Person)()

    Public Sub New()
        Me.InitializeComponent()
        ' number of children for each person (4 levels)
        ' item count is 1 + count + count^2 + count^3 + count^4
        ' (e.g. count = 10 => ~10,000 people)

        AddHandler Loaded, AddressOf GridTreeViewSample_Loaded
    End Sub

    Private Sub GridTreeViewSample_Loaded(sender As Object, e As RoutedEventArgs)
        _person = GetData()

#Region "Populating"
        ' put person in a list so we can bind to it
        Dim list As New ObservableCollection(Of Person)()
        list.Add(_person)

        ' show items in bound controls
        Using New Benchmark(Strings.BoundC1TreeView, _txtTree)
            _tree.ItemsSource = list
        End Using

        Using New Benchmark(Strings.BoundC1FlexGrid, _txtFlex)
            _flex.ItemsSource = list
        End Using

        ' show items in unbound controls
        Using New Benchmark(Strings.UnBoundC1TreeView, _txtTreeUnbound)
            ShowPersonOnTree(_person, _treeUnbound)
        End Using

        Using New Benchmark(Strings.UnBoundC1FlexGrid, _txtFlexUnbound)
            ShowPersonOnGrid(_person, _flexUnbound)
        End Using
#End Region

        ' try doing this with a TreeView ;-)
        _flex.CollapseGroupsToLevel(5)
        _flexUnbound.CollapseGroupsToLevel(5)

        ' hide row headers
        _flex.HeadersVisibility = HeadersVisibility.Column
        _flexUnbound.HeadersVisibility = HeadersVisibility.Column
    End Sub

    Private Function GetData() As Person
        Dim count As Integer = 4
        ' build person tree
        Dim _person As New Person()

#Region "CreatingPersons"
        Using New Benchmark(Strings.BuildingPersonTree, _txtPerson)
            Dim i As Integer = 0
            While i < count
                Dim pi As New Person()
                _person.Children.Add(pi)

                Dim j As Integer = 0
                While j < count
                    Dim pj As New Person()
                    pi.Children.Add(pj)

                    Dim k As Integer = 0
                    While k < count
                        Dim pk As New Person()
                        pj.Children.Add(pk)

                        Dim l As Integer = 0
                        While l < count
                            Dim pl As New Person()
                            pk.Children.Add(pl)
                            l += 1
                        End While
                        k += 1
                    End While
                    j += 1
                End While
                i += 1
            End While
        End Using
        Return _person
#End Region
    End Function

#Region "** populate unbound TreeView"
    Sub ShowPersonOnTree(p As Person, t As C1TreeView)
        t.Items.Clear()
        AddPersonToTree(p, t.Items)
    End Sub
    Sub AddPersonToTree(p As Person, items As ItemCollection)
        ' create an item for this person
        Dim item As New C1TreeViewItem()
        item.Tag = p
        item.Header = p.Name

        ' add this person to the tree
        items.Add(item)

        ' and add any children
        For Each child As Object In p.Children
            AddPersonToTree(child, item.Items)
        Next
    End Sub
#End Region

#Region "** populate unbound FlexGrid"

    ' populate unbound FlexGrid
    Sub ShowPersonOnGrid(p As Person, flex As C1FlexGrid)
        ' initialize grid
        flex.Rows.Clear()
        flex.Columns.Clear()

        Dim c As New Column()
        c.Header = "Name"
        Dim binding As New Binding() With {
            .Path = New PropertyPath("Name")
        }
        c.Binding = binding

        c.Width = New GridLength(1, GridUnitType.Star)
        flex.Columns.Add(c)

        c = New Column()
        c.Header = "Children"
        Dim binding2 As New Binding() With {
            .Path = New PropertyPath("Children.Count")
        }
        c.Binding = binding2

        flex.Columns.Add(c)

        Using flex.Rows.DeferNotifications()
            AddPersonToGrid(p, flex, 0)
        End Using
    End Sub
    Sub AddPersonToGrid(p As Person, flex As C1FlexGrid, level As Integer)
        ' create a row for this person
        Dim row As Row
        If p.Children.Count > 0 OrElse True Then
            Dim gr As New GroupRow()
            gr.Level = level
            row = gr
        Else
            row = New Row()
        End If
        row.DataItem = p

        ' add this person to the grid
        flex.Rows.Add(row)

        ' and add any children
        For Each child As Object In p.Children
            AddPersonToGrid(child, flex, level + 1)
        Next
    End Sub
#End Region

#Region "EventHandlers"

    Private Sub _btnAddRoot_Click(sender As Object, e As RoutedEventArgs)
        Dim list As ObservableCollection(Of Person) = TryCast((TryCast(_flex.CollectionView, C1CollectionView)).SourceCollection, ObservableCollection(Of Person))
        Dim root As New Person()
        list.Insert(0, root)
    End Sub

    Private Sub _btnAddChild_Click(sender As Object, e As RoutedEventArgs)
        Dim p As Person = GetSelectedPerson()
        p.Children.Insert(0, New Person())
        TryCast(_flex.CollectionView, C1CollectionView).Refresh()

    End Sub

    Private Sub _btnDelete_Click(sender As Object, e As RoutedEventArgs)
        Dim p As Person = GetSelectedPerson()
        Dim parent As Person = p.Parent
        If parent IsNot Nothing Then
            parent.Children.Remove(p)
        End If
        TryCast(_flex.CollectionView, C1CollectionView).Refresh()
    End Sub

    Private Sub _btnChange_Click(sender As Object, e As RoutedEventArgs)
        Dim p As Person = GetSelectedPerson()
        p.Name = _rnd.[Next](0, 1000).ToString()
    End Sub
#End Region

    Function GetSelectedPerson() As Person
        Dim p As Person = TryCast(_flex.SelectedItem, Person)
        Return If(p IsNot Nothing, p, _person)
    End Function
End Class