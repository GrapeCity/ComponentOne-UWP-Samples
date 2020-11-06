Imports System.Threading.Tasks
Imports System.Text
Imports System.Reflection
Imports System.Linq
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

''' <summary>
''' Class that represents some generic data object to use as a sample.
''' </summary>
Public Class Product
    Inherits BaseObject
    Private _name As String, _color As String, _line As String
    Private _price As Double, _cost As Double
    Private _date As DateTime
    Private _discontinued As Boolean

    Shared _products As List(Of Product)

    Shared _rnd As New Random()
    Shared _names As String() = "Macko|Surfair|Pocohey|Studeby".Split("|"c)
    Shared _lines As String() = "Computers|Washers|Stoves|Cars".Split("|"c)
    Shared _colors As String() = "Red|Green|Blue|White".Split("|"c)

    Public Sub New()
        Name = PickOne(_names)
        Line = PickOne(_lines)
        Color = PickOne(_colors)
        Price = 30 + _rnd.NextDouble() * 1000
        Cost = 3 + _rnd.NextDouble() * 300
        Discontinued = _rnd.NextDouble() < 0.2
        Introduced = DateTime.Today.AddDays(_rnd.[Next](-600, 0))
    End Sub

    Public Shared Function GetData() As List(Of Product)
        If _products Is Nothing Then
            _products = GetData(200)
        End If
        Return _products
    End Function

    Public Shared Function GetData(Count As Integer) As List(Of Product)
        Dim list As New List(Of Product)()
        Dim i As Integer = 0
        While i < Count
            list.Add(New Product())
            i += 1
        End While
        Return list
    End Function

    Function PickOne(options As String()) As String
        Return options(_rnd.[Next]() Mod options.Length)
    End Function


    <Display(Name:="Special Price (New Customers)")>
    <Editable(False)>
    Public Property CustomField1() As Double

    <Display(Name:="Special Price (Card Holders)")>
    <Editable(False)>
    Public Property CustomField2() As Double

    <Display(Name:="Name")>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set
            SetProperty("Name", _name, Value)
        End Set
    End Property

    <Display(Name:="Color")>
    Public Property Color() As String
        Get
            Return _color
        End Get
        Set
            SetProperty("Color", _color, Value)
        End Set
    End Property

    <Display(Name:="Line")>
    Public Property Line() As String
        Get
            Return _line
        End Get
        Set
            SetProperty("Line", _line, Value)
        End Set
    End Property

    <Display(Name:="Price")>
    Public Property Price() As Double
        Get
            Return _price
        End Get
        Set
            SetProperty("Price", _price, Value)
        End Set
    End Property

    <Display(Name:="Cost")>
    Public Property Cost() As Double
        Get
            Return _cost
        End Get
        Set
            SetProperty("Cost", _cost, Value)
        End Set
    End Property

    <Display(Name:="Introduced")>
    Public Property Introduced() As DateTime
        Get
            Return _date
        End Get
        Set
            SetProperty("Introduced", _date, Value)
        End Set
    End Property

    <Display(Name:="Discontinued")>
    Public Property Discontinued() As Boolean
        Get
            Return _discontinued
        End Get
        Set
            SetProperty("Discontinued", _discontinued, Value)
        End Set
    End Property
End Class

''' <summary>
''' BaseObject provides INotifyPropertyChanged and IEditableObject.
''' </summary>
Public Class BaseObject
    Implements INotifyPropertyChanged
    Implements IEditableObject
    Protected Function SetProperty(Of T)(propName As String, ByRef field As T, value As T) As Boolean
        If EqualityComparer(Of T).[Default].Equals(field, value) Then
            Return False
        End If
        field = value
        OnPropertyChanged(propName)
        Return True
    End Function

#Region "** INotifyPropertyChanged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Sub OnPropertyChanged(propName As String)
        OnPropertyChanged(New PropertyChangedEventArgs(propName))
    End Sub
    Protected Overridable Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

#End Region

#Region "** IEditableObject"

    Private _clone As Object = Nothing
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        _clone = Me.MemberwiseClone()
    End Sub
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        For Each p As Object In Me.[GetType]().GetTypeInfo().DeclaredProperties
            Dim value As Object = p.GetValue(_clone, Nothing)
            p.SetValue(Me, value, Nothing)
        Next
    End Sub
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        _clone = Nothing
    End Sub

#End Region
End Class