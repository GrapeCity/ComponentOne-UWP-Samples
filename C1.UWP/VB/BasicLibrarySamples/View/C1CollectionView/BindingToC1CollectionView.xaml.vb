Imports C1.Xaml
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
Imports BasicLibrarySamples

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class BindingToC1CollectionView
    Inherits Page
    Private ReadOnly _c1CollectionView As C1CollectionView

    Public Sub New()
        Me.InitializeComponent()

        Dim customers As ObservableCollection(Of Customer) = Customer.GetCollection(50)
        _c1CollectionView = New C1CollectionView()
        _c1CollectionView.GroupDescriptions.Add(New PropertyGroupDescription("Country"))
        _c1CollectionView.SortDescriptions.Add(New SortDescription("Name", ListSortDirection.Ascending))
        _c1CollectionView.SourceCollection = customers.Distinct(New SourceComparer())

        listBox1.ItemsSource = _c1CollectionView

        'filterCheckBox.IsChecked = null;
        gridView1.ItemsSource = _c1CollectionView
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
    End Sub

    Private Sub Page_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        scrollViewer.HorizontalScrollBarVisibility = If(e.NewSize.Width > 540, ScrollBarVisibility.Disabled, ScrollBarVisibility.Visible)
    End Sub

#If False Then
    Private Sub filterCheckBox_Click_1(sender As Object, e As RoutedEventArgs)
        Dim isActive As System.Nullable(Of Boolean) = filterCheckBox.IsChecked
        If Not isActive.HasValue Then
            _c1CollectionView.Filter = Nothing
        ElseIf isActive.Value Then
            _c1CollectionView.Filter = IsActiveFilter()
        Else
            _c1CollectionView.Filter = IsInactiveFilter()
        End If
    End Sub

    Function IsActiveFilter(customer As Object) As Boolean
        Return (CType(customer, Customer)).Active
    End Function

    Function IsInactiveFilter(customer As Object) As Boolean
        Return Not (CType(customer, Customer)).Active
    End Function
#End If

End Class

''' <summary>
''' A distinct compare for data source.
''' </summary>
Public Class SourceComparer
    Implements IEqualityComparer(Of Customer)
    Public Function SourceComparerEquals(x As Customer, y As Customer) As Boolean Implements IEqualityComparer(Of Customer).Equals
        If x.Name.Equals(y.Name) AndAlso x.Country.Equals(y.Country) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SourceComparerGetHashCode(obj As Customer) As Integer Implements IEqualityComparer(Of Customer).GetHashCode
        Return 0
    End Function

End Class