Imports System.Collections
Imports C1.Xaml
Imports C1.Xaml.FlexGrid
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
Imports System.Reflection
Imports System

Partial Public NotInheritable Class CollectionView
    Inherits Page
    Private _c1CollectionView As C1CollectionView

    Public Sub New()
        Me.InitializeComponent()
        c1FlexGrid1.GroupHeaderConverter = New MyGroupConverter()
        Dim filterFields As New List(Of FilterFiled)()
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledLine,
            .Filed = "Line"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledColor,
            .Filed = "Color"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledPrice,
            .Filed = "Price"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledWeight,
            .Filed = "Weight"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledCost,
            .Filed = "Cost"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledVolume,
            .Filed = "Volume"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledDiscontinued,
            .Filed = "Discontinued"
        })
        filterFields.Add(New FilterFiled() With {
            .Name = Strings.FiledRating,
            .Filed = "Rating"
        })
        filterComboBox.ItemsSource = filterFields
        filterComboBox.DisplayMemberPath = "Name"
        filterComboBox.SelectedIndex = 0

        'you can use a customer C1CollectionViewConverter to define sort/group in xaml page
        'or define C1CollectionViewer as following.
        '_c1CollectionView = new C1CollectionView();
        '_c1CollectionView.SourceCollection = Product.GetProducts(100);
        '_c1CollectionView.GroupDescriptions.Add(new C1.Xaml.PropertyGroupDescription("Color"));

        c1FlexGrid1.DataContext = New ViewModel()

        AddHandler c1FlexGrid1.Loaded, AddressOf C1FlexGrid1_Loaded
    End Sub

    Private Sub C1FlexGrid1_Loaded(sender As Object, e As RoutedEventArgs)
        _c1CollectionView = TryCast(c1FlexGrid1.CollectionView, C1CollectionView)
    End Sub

    Sub UpdateFiltering()
        If filterTextBox.Text.Length = 0 Then
            _c1CollectionView.Filter = Nothing
        Else
            If _c1CollectionView.Filter Is Nothing Then
                _c1CollectionView.Filter = AddressOf FilterFunction
            Else
                _c1CollectionView.Refresh()
            End If
        End If
    End Sub

    Function FilterFunction(product As Object) As Boolean
        ' get customer to test
        Dim c As Product = TryCast(product, Product)
        If c Is Nothing Then
            Return False
        End If

        ' get value of the property we're filtering on
        Dim ff As FilterFiled = TryCast(filterComboBox.SelectedItem, FilterFiled)
        Dim pi As PropertyInfo = GetType(Product).GetRuntimeProperty(ff.Filed)
        Dim propValue As Object = pi.GetValue(c, Nothing)
        If propValue Is Nothing Then
            Return False
        End If

        ' check if the property contains the filter string
        Dim text As String = propValue.ToString()
        Return text.IndexOf(filterTextBox.Text, StringComparison.CurrentCultureIgnoreCase) > -1
    End Function
    Sub filterTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        UpdateFiltering()
    End Sub
    Sub filterComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        filterTextBox.Text = String.Empty
    End Sub

    Private Sub groupCheckbox_Checked(sender As Object, e As RoutedEventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If _c1CollectionView IsNot Nothing AndAlso cb IsNot Nothing Then
            Dim name As String = cb.Name
            Dim propertyName As String = name
            If name.Contains("Color") Then
                propertyName = "Color"
            ElseIf name.Contains("Line") Then
                propertyName = "Line"
            ElseIf name.Contains("Rating") Then
                propertyName = "Rating"
            End If
            Using _c1CollectionView.DeferRefresh()
                Dim group As GroupDescription = _c1CollectionView.GroupDescriptions.FirstOrDefault(Function(p) (TryCast(p, PropertyGroupDescription)).PropertyName = propertyName)
                If group Is Nothing Then
                    _c1CollectionView.GroupDescriptions.Add(New PropertyGroupDescription(propertyName))
                End If
            End Using
        End If
    End Sub

    Private Sub groupCheckbox_Unchecked(sender As Object, e As RoutedEventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If _c1CollectionView IsNot Nothing AndAlso cb IsNot Nothing Then
            Dim name As String = cb.Name
            Dim propertyName As String = name
            If name.Contains("Color") Then
                propertyName = "Color"
            ElseIf name.Contains("Line") Then
                propertyName = "Line"
            ElseIf name.Contains("Rating") Then
                propertyName = "Rating"
            End If
            Using _c1CollectionView.DeferRefresh()
                _c1CollectionView.GroupDescriptions.Remove(_c1CollectionView.GroupDescriptions.FirstOrDefault(Function(p) (TryCast(p, PropertyGroupDescription)).PropertyName = propertyName))
            End Using
        End If
    End Sub
End Class

Class MyGroupConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim gr As GroupRow = TryCast(parameter, GroupRow)
        Dim group As ICollectionViewGroup = gr.Group
        Dim cv As IC1CollectionView = TryCast(gr.Grid.CollectionView, IC1CollectionView)
        Dim desc As PropertyGroupDescription = If(cv IsNot Nothing AndAlso gr.Level < cv.GroupDescriptions.Count, TryCast(cv.GroupDescriptions(gr.Level), PropertyGroupDescription), Nothing)
        Dim name As String = desc.PropertyName
        If name = "Line" OrElse name = "Color" OrElse name = "Rating" Then
            name = gr.Grid.Columns(name).Header
        End If

        'string headerName = gr.Grid.Columns[name].Header;
        Dim itemCount As Integer = group.GroupItems.Count
        If itemCount > 1 Then
            Return String.Format(Strings.ItemsCount, name, itemCount)
        End If
        Return String.Format(Strings.ItemCount, name, itemCount)
    End Function

    ' shouldn't need to convert back to anything
    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return Nothing
        'throw new NotImplementedException();
    End Function
End Class

Public Class C1CollectionViewConverter
    Implements IValueConverter

    Private _sortDescriptions As New ObservableCollection(Of SortDescription)()

    Public Property SortDescriptions() As ObservableCollection(Of SortDescription)
        Get
            Return _sortDescriptions
        End Get
        Set
            _sortDescriptions = Value
        End Set
    End Property


    Private _groupDescriptions As New ObservableCollection(Of PropertyGroupDescription)()

    Public Property GroupDescriptions() As ObservableCollection(Of PropertyGroupDescription)
        Get
            Return _groupDescriptions
        End Get
        Set
            _groupDescriptions = Value
        End Set
    End Property
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If value IsNot Nothing AndAlso TypeOf value Is IEnumerable Then
            Dim collectionView As New C1CollectionView()
            collectionView.SourceCollection = CType(value, System.Collections.IEnumerable)
            For Each group As PropertyGroupDescription In Me.GroupDescriptions
                collectionView.GroupDescriptions.Add(group)
            Next
            For Each sort As SortDescription In Me.SortDescriptions
                collectionView.SortDescriptions.Add(sort)
            Next

            Return collectionView
        End If
        Return Nothing
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Public Class ViewModel
    Public Property Products() As ICollectionView

    Public Sub New()
        Products = Product.GetProducts(100)
    End Sub
End Class

Public Class FilterFiled
    Public Property Name() As String
    Public Property Filed() As String
End Class