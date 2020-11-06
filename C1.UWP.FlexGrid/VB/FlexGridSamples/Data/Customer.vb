Imports System.Reflection
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Collections
Imports System

''' <summary>
''' Simple data class that implements two important binding interfaces:
''' 
''' INotifyPropertyChanged:
'''   Notifies bound controls of changes to the object properties so they can synchronize
'''   the UI with the current object state.
'''   
''' IEditableObject:
'''   Provides transacted edits by saving the object state when editing starts and 
'''   committing or rolling back when editing ends.
'''   
''' </summary>
Public Class Customer
    Implements INotifyPropertyChanged
    Implements IEditableObject
    ' ** fields
    Private _id As Integer, _countryID As Integer
    Private _first As String, _last As String
    Private _father As String, _brother As String, _cousin As String
    Private _active As Boolean
    Private _hired As DateTime
    Private _weight As Double

    ' ** data generators
    Shared _rnd As New Random()
    Shared _firstNames As String() = Strings.FirstNames.Split("|"c)
    Shared _lastNames As String() = Strings.LastNames.Split("|"c)
    Shared _countries As String() = Strings.CountryList.Split("|"c)

    ' ** ctors
    Public Sub New()
        Me.New(_rnd.[Next](10000))
    End Sub
    Public Sub New(id As Integer)
        _id = id

        First = GetString(_firstNames)
        Last = GetString(_lastNames)
        CountryID = _rnd.[Next]() Mod _countries.Length
        Active = _rnd.NextDouble() >= 0.5
        Hired = DateTime.Today.AddDays(-_rnd.[Next](1, 365))
        Weight = 50 + _rnd.NextDouble() * 50
        _father = String.Format("{0} {1}", GetString(_firstNames), Last)
        _brother = String.Format("{0} {1}", GetString(_firstNames), Last)
        _cousin = GetName()
    End Sub

    ' ** object model
    <Display(Name:="ID")>
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set
            If Value <> _id Then
                _id = Value
                RaisePropertyChanged("ID")
            End If
        End Set
    End Property

    <Display(Name:="Name")>
    Public ReadOnly Property Name() As String
        Get
            Return String.Format("{0} {1}", First, Last)
        End Get
    End Property

    <Display(Name:="Country")>
    Public ReadOnly Property Country() As String
        Get
            Return _countries(_countryID)
        End Get
    End Property

    <Display(Name:="CountryID")>
    Public Property CountryID() As Integer
        Get
            Return _countryID
        End Get
        Set
            If Value <> _countryID AndAlso Value > -1 AndAlso Value < _countries.Length Then
                _countryID = Value

                ' call OnPropertyChanged with null parameter since setting this property
                ' modifies the value of "CountryID" and also the value of "Country".
                RaisePropertyChanged("")
            End If
        End Set
    End Property

    <Display(Name:="Active")>
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set
            If Value <> _active Then
                _active = Value
                RaisePropertyChanged("Active")
            End If
        End Set
    End Property

    <Display(Name:="First")>
    Public Property First() As String
        Get
            Return _first
        End Get
        Set
            If Value <> _first Then
                _first = Value

                ' call OnPropertyChanged with null parameter since setting this property
                ' modifies the value of "First" and also the value of "Name".
                RaisePropertyChanged("")
            End If
        End Set
    End Property

    <Display(Name:="Last")>
    Public Property Last() As String
        Get
            Return _last
        End Get
        Set
            If Value <> _last Then
                _last = Value

                ' call OnPropertyChanged with null parameter since setting this property
                ' modifies the value of "First" and also the value of "Name".
                RaisePropertyChanged("")
            End If
        End Set
    End Property

    <Display(Name:="Hired")>
    Public Property Hired() As DateTime
        Get
            Return _hired
        End Get
        Set
            If Value <> _hired Then
                _hired = Value
                RaisePropertyChanged("Hired")
            End If
        End Set
    End Property

    <Display(Name:="Weight")>
    Public Property Weight() As Double
        Get
            Return _weight
        End Get
        Set
            If Value <> _weight Then
                _weight = Value
                RaisePropertyChanged("Weight")
            End If
        End Set
    End Property

    ' some read-only stuff
    <Display(Name:="Father")>
    Public ReadOnly Property Father() As String
        Get
            Return _father
        End Get
    End Property

    <Display(Name:="Brother")>
    Public ReadOnly Property Brother() As String
        Get
            Return _brother
        End Get
    End Property

    <Display(Name:="Cousin")>
    Public ReadOnly Property Cousin() As String
        Get
            Return _cousin
        End Get
    End Property

    ' ** utilities
    Shared Function GetString(arr As String()) As String
        Return arr(_rnd.[Next](arr.Length))
    End Function
    Shared Function GetName() As String
        Return String.Format("{0} {1}", GetString(_firstNames), GetString(_lastNames))
    End Function

    ' ** static list provider
    Public Shared Function GetCustomerList(count As Integer) As ObservableCollection(Of Customer)
        Dim list As New ObservableCollection(Of Customer)()
        Dim i As Integer = 0
        While i < count
            list.Add(New Customer(i))
            i += 1
        End While
        Return list
    End Function

    ' ** static value providers
    Public Shared Function GetCountries() As String()
        Return _countries
    End Function
    Public Shared Function GetFirstNames() As String()
        Return _firstNames
    End Function
    Public Shared Function GetLastNames() As String()
        Return _lastNames
    End Function

    '-----------------------------------------------------------------------------------
#Region "** INotifyPropertyChanged Members"

    ' this interface allows bounds controls to react to changes in the data objects.

    Sub RaisePropertyChanged(propertyName As String)
        OnPropertyChanged(New PropertyChangedEventArgs(propertyName))
    End Sub
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

#End Region

    '-----------------------------------------------------------------------------------
#Region "IEditableObject Members"

    ' this interface allows transacted edits (user can press escape to restore previous values).

    Private _clone As Customer
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        _clone = CType(Me.MemberwiseClone(), Customer)
    End Sub
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        _clone = Nothing
    End Sub
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If _clone IsNot Nothing Then
            For Each p As PropertyInfo In Me.[GetType]().GetRuntimeProperties()
                If p.CanRead AndAlso p.CanWrite Then
                    p.SetValue(Me, p.GetValue(_clone, Nothing), Nothing)
                End If
            Next
        End If
    End Sub

#End Region
End Class