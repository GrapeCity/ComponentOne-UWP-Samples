Imports Windows.UI.Xaml.Data
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System

Public Class Product
    Implements INotifyPropertyChanged
    Implements IEditableObject
    Shared _lines As String() = Strings.Lines.Split("|"c)
    Shared _colors As String() = Strings.Colors.Split("|"c)
    Shared _names As String() = Strings.ProductName.Split("|"c)

    ' object model
    <Display(Name:="Line")>
    Public Property Line() As String
        Get
            Return CType(GetValue("Line"), String)
        End Get
        Set
            SetValue("Line", Value)
        End Set
    End Property

    <Display(Name:="Color")>
    Public Property Color() As String
        Get
            Return CType(GetValue("Color"), String)
        End Get
        Set
            SetValue("Color", Value)
        End Set
    End Property

    <Display(Name:="Name")>
    Public Property Name() As String
        Get
            Return CType(GetValue("Name"), String)
        End Get
        Set
            SetValue("Name", Value)
        End Set
    End Property

    <Display(Name:="Price")>
    Public Property Price() As Double
        Get
            Return CType(GetValue("Price"), Double)
        End Get
        Set
            SetValue("Price", Value)
        End Set
    End Property

    <Display(Name:="Weight")>
    Public Property Weight() As Double
        Get
            Return CType(GetValue("Weight"), Double)
        End Get
        Set
            SetValue("Weight", Value)
        End Set
    End Property

    <Display(Name:="Cost")>
    Public Property Cost() As Double
        Get
            Return CType(GetValue("Cost"), Double)
        End Get
        Set
            SetValue("Cost", Value)
        End Set
    End Property

    <Display(Name:="Volume")>
    Public Property Volume() As Double
        Get
            Return CType(GetValue("Volume"), Double)
        End Get
        Set
            SetValue("Volume", Value)
        End Set
    End Property

    <Display(Name:="Discontinued")>
    Public Property Discontinued() As Boolean
        Get
            Return CType(GetValue("Discontinued"), Boolean)
        End Get
        Set
            SetValue("Discontinued", Value)
        End Set
    End Property

    <Display(Name:="Rating")>
    Public Property Rating() As Integer
        Get
            Return CType(GetValue("Rating"), Integer)
        End Get
        Set
            SetValue("Rating", Value)
        End Set
    End Property

    ' get/set values
    Private _values As New Dictionary(Of String, Object)()
    Function GetValue(p As String) As Object
        Dim value As Object
        _values.TryGetValue(p, value)
        Return value
    End Function
    Sub SetValue(p As String, value As Object)
        If Not Object.Equals(value, GetValue(p)) Then
            _values(p) = value
            OnPropertyChanged(p)
        End If
    End Sub
    Protected Overridable Sub OnPropertyChanged(p As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(p))
    End Sub

    ' factory
    Public Shared Function GetProducts(count As Integer) As ICollectionView
        Dim list As New ObservableCollection(Of Product)()
        Dim rnd As New Random()
        Dim i As Integer = 0
        While i < count
            Dim p As New Product()
            p.Line = _lines(rnd.[Next]() Mod _lines.Length)
            p.Color = _colors(rnd.[Next]() Mod _colors.Length)
            p.Name = _names(rnd.[Next]() Mod _names.Length)
            p.Price = rnd.[Next](1, 1000)
            p.Weight = rnd.[Next](1, 100)
            p.Cost = rnd.[Next](1, 600)
            p.Volume = rnd.[Next](500, 5000)
            p.Discontinued = rnd.NextDouble() < 0.1
            p.Rating = rnd.[Next](0, 5)
            list.Add(p)
            i += 1
        End While
        Return New CollectionViewSource() With {
            .Source = list
        }.View
    End Function
    Public Shared Function GetLines() As String()
        Return _lines
    End Function
    Public Shared Function GetColors() As String()
        Return _colors
    End Function

#Region "INotifyPropertyChanged Members"

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

#End Region

#Region "IEditableObject Members"

    Shared _clone As Dictionary(Of String, Object)
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If _clone Is Nothing Then
            _clone = New Dictionary(Of String, Object)()
        End If
        _clone.Clear()
        For Each key As String In _values.Keys
            _clone(key) = _values(key)
        Next
    End Sub
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        _values.Clear()
        For Each key As String In _clone.Keys
            _values(key) = _clone(key)
        Next
    End Sub
    Public Sub EndEdit() Implements IEditableObject.EndEdit
    End Sub

#End Region
End Class