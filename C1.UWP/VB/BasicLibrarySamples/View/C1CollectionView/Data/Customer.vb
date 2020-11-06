Imports System.ComponentModel.DataAnnotations
Imports System.Collections.ObjectModel
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports System

Public Class Customer
    Inherits BaseEditableObject
    Private _id As Integer
    Private _name As String, _country As String
    Private _created As DateTime
    Private _value As Double, _sales As Double, _assets As Double, _growth As Double
    Private _active As Boolean

    Shared _ctr As Integer
    Shared _rnd As New Random()
    Shared _countries As String() = Strings.CollectionViewCustomerCountries.Split("|"c)
    Shared _names As String() = Strings.CollectionViewCustomerNames.Split("|"c)

    Public Shared Function GetCollection(count As Integer) As ObservableCollection(Of Customer)
        Dim ret As New ObservableCollection(Of Customer)()
        Dim i As Integer = 0
        While i < count
            ret.Add(New Customer())
            i += 1
        End While
        Return ret
    End Function

    Public Sub New()
        _ctr += 1
        ID = _ctr
        Name = _names(_rnd.[Next]() Mod _names.Length)
        Country = _countries(_rnd.[Next]() Mod _countries.Length)
        Created = DateTime.Today.AddDays(_rnd.[Next](-40, -30))
        Dim i As Integer = 0
        While i < 100
            Assets += _rnd.NextDouble() * 100
            Value += _rnd.NextDouble() * 1000
            Sales += _rnd.NextDouble() * 100
            i += 1
        End While
        If _rnd.NextDouble() < 0.05 Then
            Value = -Value
            Assets = -Assets
        End If
        If _rnd.NextDouble() < 0.05 Then
            Growth = -Growth
        End If
        Growth = _rnd.NextDouble()
        Active = _rnd.NextDouble() > 0.5
    End Sub

    <Display(Name:="ID")>
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set
            SetValue(_id, Value, "ID")
        End Set
    End Property

    <Display(Name:="Name")>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set
            SetValue(_name, Value, "Name")
        End Set
    End Property

    <Display(Name:="Country")>
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set
            SetValue(_country, Value, "Country")
        End Set
    End Property

    <Display(Name:="Created")>
    Public Property Created() As DateTime
        Get
            Return _created
        End Get
        Set
            SetValue(_created, Value, "Created")
        End Set
    End Property

    <Display(Name:="Sales")>
    Public Property Sales() As Double
        Get
            Return _sales
        End Get
        Set
            SetValue(_sales, Value, "Sales")
        End Set
    End Property

    <Display(Name:="Growth")>
    Public Property Growth() As Double
        Get
            Return _growth
        End Get
        Set
            SetValue(_growth, Value, "Growth")
        End Set
    End Property

    <Display(Name:="Assets")>
    Public Property Assets() As Double
        Get
            Return _assets
        End Get
        Set
            SetValue(_assets, Value, "Assets")
        End Set
    End Property

    <Display(Name:="Value")>
    Public Property Value() As Double
        Get
            Return _value
        End Get
        Set
            SetValue(_value, Value, "Value")
        End Set
    End Property

    <Display(Name:="Active")>
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set
            SetValue(_active, Value, "Active")
        End Set
    End Property
End Class