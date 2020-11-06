Imports C1.Xaml
Imports System.Reflection
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

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class CollectionViewConditions
    Inherits Page
    Private ReadOnly _c1CollectionView As C1CollectionView
    Private NoneItem As String = Strings.CollectionViewNoneItem

    Public Sub New()
        Me.InitializeComponent()

        Dim fieldNames As IList(Of String) = New String() {Strings.CollectionViewCustomerPropertyID, Strings.CollectionViewCustomerPropertyName, Strings.CollectionViewCustomerPropertyCountry, Strings.CollectionViewCustomerPropertyActive, Strings.CollectionViewCustomerPropertyCreated, Strings.CollectionViewCustomerPropertySales,
            Strings.CollectionViewCustomerPropertyGrowth}


        chooseSortFields.FieldNames = fieldNames

        Dim groupFields As New List(Of String)(fieldNames)
        groupFields.Sort()
        groupFields.Remove(Strings.CollectionViewCustomerPropertyActive)
        Dim filterFields As New List(Of String)(groupFields)
        groupFields.Insert(0, NoneItem)
        groupComboBox.ItemsSource = groupFields
        groupComboBox.SelectedItem = NoneItem
        filterComboBox.ItemsSource = filterFields
        filterComboBox.SelectedIndex = 0


        Dim customers As ObservableCollection(Of Customer) = Customer.GetCollection(50)
        _c1CollectionView = New C1CollectionView()
        _c1CollectionView.SourceCollection = customers

        'gridView1.ItemsSource = _c1CollectionView;

        'filterCheckBox.IsChecked = null;
        listBox1.ItemsSource = _c1CollectionView
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
    End Sub

    Sub UpdateSorting()
        Using _c1CollectionView.DeferRefresh()
            _c1CollectionView.SortDescriptions.Clear()
            For Each fieldName As String In chooseSortFields.SelectedFieldNames
                _c1CollectionView.SortDescriptions.Add(New SortDescription(fieldName, ListSortDirection.Ascending))
            Next
        End Using
    End Sub

    Sub UpdateGrouping()
        If _c1CollectionView Is Nothing Then
            Return
        End If
        Using _c1CollectionView.DeferRefresh()
            _c1CollectionView.GroupDescriptions.Clear()
            Dim selectedString As String = CType(groupComboBox.SelectedItem, String)
            If selectedString <> NoneItem Then
                _c1CollectionView.GroupDescriptions.Add(New PropertyGroupDescription(GetGroupPropertyName(groupComboBox.SelectedIndex)))
            End If
        End Using
    End Sub

    Function GetGroupPropertyName(selectedIndex As Integer) As String
        Dim selectedProperty As String = Nothing
        Select Case selectedIndex
            Case 1
                selectedProperty = "Country"
                Exit Select
            Case 2
                selectedProperty = "Created"
                Exit Select
            Case 3
                selectedProperty = "Growth"
                Exit Select
            Case 4
                selectedProperty = "ID"
                Exit Select
            Case 5
                selectedProperty = "Name"
                Exit Select
            Case 6
                selectedProperty = "Sales"
                Exit Select
            Case Else
                selectedProperty = "NoneItem"
                Exit Select
        End Select
        Return selectedProperty
    End Function

    Sub UpdateFiltering()
        If filterTextBox.Text.Length = 0 Then
            _c1CollectionView.Filter = Nothing
        Else
            If _c1CollectionView.Filter Is Nothing Then
                Dim filter As Predicate(Of Object) = AddressOf FilterFunction
                _c1CollectionView.Filter = filter
            Else
                _c1CollectionView.Refresh()
            End If
        End If
    End Sub

    Function FilterFunction(customer As Object) As Boolean
        Dim cust As Customer = TryCast(customer, Customer)
        If cust Is Nothing Then
            Return False
        End If
        Dim propValue As Object = Nothing

        Dim selectedItem As [String] = CType(filterComboBox.SelectedItem, String)
        Select Case selectedItem
            Case Strings.CollectionViewCustomerPropertyID
                propValue = cust.ID
            Case Strings.CollectionViewCustomerPropertyName
                propValue = cust.Name
            Case Strings.CollectionViewCustomerPropertyCountry
                propValue = cust.Country
            Case Strings.CollectionViewCustomerPropertyCreated
                propValue = cust.Created
            Case Strings.CollectionViewCustomerPropertySales
                propValue = cust.Sales
            Case Strings.CollectionViewCustomerPropertyGrowth
                propValue = cust.Growth
            Case Else
                Return True
        End Select
        If propValue Is Nothing Then
            Return False
        End If
        Return propValue.ToString().StartsWith(filterTextBox.Text, StringComparison.CurrentCultureIgnoreCase)
    End Function

    Private Sub chooseSortFields_SelectedFieldNamesChanged_1(sender As Object, e As EventArgs)
        UpdateSorting()
    End Sub

    Private Sub groupComboBox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs)
        UpdateGrouping()
    End Sub

    Private Sub filterTextBox_TextChanged_1(sender As Object, e As TextChangedEventArgs)
        UpdateFiltering()
    End Sub

    Private Sub filterComboBox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs)
        filterTextBox.Text = ""
    End Sub

End Class