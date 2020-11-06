Imports System.Collections.ObjectModel
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

Partial Public NotInheritable Class ChooseItemsControl
    Inherits UserControl
    Private _fieldNames As IList(Of String) = Nothing
    Private ReadOnly _fieldNamesInternal As New ObservableCollection(Of String)()
    Private ReadOnly _selectedFieldNamesInternal As New ObservableCollection(Of String)()
    Private _suppressNotifications As Boolean = False

    Public Sub New()
        Me.InitializeComponent()

        allListBox.ItemsSource = FieldNamesInternal
        selectedListBox.ItemsSource = SelectedFieldNamesInternal
        AddHandler _selectedFieldNamesInternal.CollectionChanged, AddressOf SelectedFieldNamesInternal_CollectionChanged
    End Sub

    Public Property FieldNames() As IList(Of String)
        Get
            Return _fieldNames
        End Get
        Set
            Dim selCount As Integer = _selectedFieldNamesInternal.Count
            _suppressNotifications = True
            Try
                _fieldNamesInternal.Clear()
                _selectedFieldNamesInternal.Clear()
                _fieldNames = Value
                If _fieldNames IsNot Nothing Then
                    Dim items As New List(Of String)(_fieldNames)
                    items.Sort()
                    For Each s As String In items
                        _fieldNamesInternal.Add(s)
                    Next
                End If
            Finally
                _suppressNotifications = False
                If selCount > 0 Then
                    OnSelectedFieldNamesChanged()
                End If
            End Try
        End Set
    End Property

    Public ReadOnly Property SelectedFieldNames() As IList(Of String)
        Get
            Return _selectedFieldNamesInternal
        End Get
    End Property

    Public Event SelectedFieldNamesChanged As EventHandler(Of EventArgs)

    Private ReadOnly Property FieldNamesInternal() As ObservableCollection(Of String)
        Get
            Return _fieldNamesInternal
        End Get
    End Property

    Private ReadOnly Property SelectedFieldNamesInternal() As ObservableCollection(Of String)
        Get
            Return _selectedFieldNamesInternal
        End Get
    End Property

    Private Sub OnSelectedFieldNamesChanged()
        RaiseEvent SelectedFieldNamesChanged(Me, EventArgs.Empty)
    End Sub

    Sub SelectedFieldNamesInternal_CollectionChanged(sender As Object, e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
        If Not _suppressNotifications Then
            OnSelectedFieldNamesChanged()
        End If
    End Sub

    Private Sub UpdateAllFieldsButtonsState()
        selectButton.IsEnabled = allListBox.SelectedItem IsNot Nothing
    End Sub

    Private Sub UpdateSelectedFieldsButtonsState()
        unselectButton.IsEnabled = selectedListBox.SelectedItem IsNot Nothing
        Dim isEnabled As Boolean = selectedListBox.Items.Count > 1 AndAlso selectedListBox.SelectedItem IsNot Nothing
        upButton.IsEnabled = isEnabled AndAlso selectedListBox.SelectedIndex > 0
        downButton.IsEnabled = isEnabled AndAlso selectedListBox.SelectedIndex < selectedListBox.Items.Count - 1
    End Sub

    Private Sub [Select]()
        If allListBox.SelectedItem IsNot Nothing Then
            _selectedFieldNamesInternal.Add(CType(allListBox.SelectedItem, String))
            selectedListBox.SelectedItem = allListBox.SelectedItem
            Dim idx As Integer = allListBox.SelectedIndex
            _fieldNamesInternal.Remove(CType(allListBox.SelectedItem, String))
            If allListBox.Items.Count > 0 Then
                allListBox.SelectedIndex = Math.Min(idx, allListBox.Items.Count - 1)
            End If
        End If
    End Sub

    Private Sub Unselect()
        Dim selItem As String = CType(selectedListBox.SelectedItem, String)
        If selItem IsNot Nothing Then
            Dim list As New List(Of String)(_fieldNamesInternal)
            list.Add(selItem)
            list.Sort()
            _fieldNamesInternal.Clear()
            For Each s As String In list
                _fieldNamesInternal.Add(s)
            Next
            allListBox.SelectedItem = selItem
            Dim idx As Integer = selectedListBox.SelectedIndex
            _selectedFieldNamesInternal.Remove(CType(selectedListBox.SelectedItem, String))
            If selectedListBox.Items.Count > 0 Then
                selectedListBox.SelectedIndex = Math.Min(idx, selectedListBox.Items.Count - 1)
            End If
        End If
    End Sub

    Private Sub MoveUp()
        Dim idx As Integer = selectedListBox.SelectedIndex
        If idx > 0 Then
            _selectedFieldNamesInternal.Move(idx, idx - 1)
            selectedListBox.SelectedIndex = idx - 1
        End If
    End Sub

    Private Sub MoveDown()
        Dim idx As Integer = selectedListBox.SelectedIndex
        If idx >= 0 AndAlso idx < _selectedFieldNamesInternal.Count - 1 Then
            _selectedFieldNamesInternal.Move(idx, idx + 1)
            selectedListBox.SelectedIndex = idx + 1
        End If
    End Sub

    Private Sub allListBox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs)
        UpdateAllFieldsButtonsState()
    End Sub

    Private Sub selectedListBox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs)
        UpdateSelectedFieldsButtonsState()
    End Sub

    Private Sub selectButton_Click(sender As Object, e As RoutedEventArgs)
        [Select]()
    End Sub

    Private Sub unselectButton_Click(sender As Object, e As RoutedEventArgs)
        Unselect()
    End Sub

    Private Sub upButton_Click(sender As Object, e As RoutedEventArgs)
        MoveUp()
    End Sub

    Private Sub downButton_Click(sender As Object, e As RoutedEventArgs)
        MoveDown()
    End Sub

    Private Sub allListBox_DoubleTapped_1(sender As Object, e As DoubleTappedRoutedEventArgs)
        [Select]()
    End Sub

    Private Sub selectedListBox_DoubleTapped_1(sender As Object, e As DoubleTappedRoutedEventArgs)
        Unselect()
    End Sub

End Class
