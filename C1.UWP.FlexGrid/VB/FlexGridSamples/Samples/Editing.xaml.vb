Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.UI
Imports System.Collections.Generic
Imports C1.Xaml.FlexGrid

Partial Public Class Editing
    Inherits Page
    Public Sub New()
        InitializeComponent()

        ' store sample description in Tag property
        Tag = Strings.EditingTag

        ' populate edit grid
        Dispatcher.RunAsync(CoreDispatcherPriority.Normal, AddressOf PopulateEditGrid)
    End Sub

    Private Sub PopulateEditGrid()
        ' create the data
        Dim data As ObservableCollection(Of Customer) = Customer.GetCustomerList(100)
        Dim view As New CollectionViewSource()
        view.Source = data
        _flexEdit.ItemsSource = view.View

        ' hide read-only "Country" column 
        Dim col As Column = _flexEdit.Columns("Country")
        _flexEdit.Columns.Remove(col)

        ' map countryID column so it shows country names instead of their IDs
        Dim dct As New Dictionary(Of Integer, String)()
        For Each country As String In Customer.GetCountries()
            dct(dct.Count) = country
        Next
        col = _flexEdit.Columns("CountryID")
        col.ValueConverter = New ColumnValueConverter(dct)
        col.HorizontalAlignment = HorizontalAlignment.Left
        col.Width = New GridLength(120)

        ' provide auto-complete lists for first and last name columns
        col = _flexEdit.Columns("First")
        col.ValueConverter = New ColumnValueConverter(Customer.GetFirstNames(), False)
        col = _flexEdit.Columns("Last")
        col.ValueConverter = New ColumnValueConverter(Customer.GetLastNames(), False)

        ' make read-only columns look disabled
        Dim readOnlyBrush As New SolidColorBrush(Color.FromArgb(&HE0, &HE0, &HE0, &HE0))
        For Each c As Column In _flexEdit.Columns
            If c.PropertyInfo IsNot Nothing AndAlso Not c.PropertyInfo.CanWrite Then
                c.Background = readOnlyBrush
            End If
        Next
    End Sub
End Class