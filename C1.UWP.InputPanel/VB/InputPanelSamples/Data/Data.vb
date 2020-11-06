Imports System.Xml
Imports System.Runtime.Serialization
Imports C1.Xaml.InputPanel
Imports C1.Xaml
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Core
Imports System.Threading.Tasks
Imports System.Xml.Serialization
Imports Windows.Storage
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Xml.Linq
Imports System.Linq
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports Windows.Storage.Streams

Public Class Data
    Shared _customer As List(Of Customer)
    Shared _employee As List(Of Employee)

    Public Shared Function Load() As List(Of Customer)
        If _customer Is Nothing Then
            _customer = GetCustomers(Of Customer)()
        End If
        Return _customer
    End Function

    Public Shared Function LoadEmployee() As List(Of Employee)
        If _employee Is Nothing Then
            _employee = GetCustomers(Of Employee)()
        End If
        Return _employee
    End Function

    Public Shared Function GetCustomers(Of T As Class)() As List(Of T)
        Try
            Using stream As Stream = GetType(Data).GetTypeInfo().Assembly.GetManifestResourceStream("InputPanelSamples.customers.xml")
                If stream IsNot Nothing Then
                    Dim xmls = New XmlSerializer(GetType(List(Of T)))
                    Return DirectCast(xmls.Deserialize(stream), List(Of T))
                End If
                Return New List(Of T)()
            End Using
        Catch
            Throw New Exception(Strings.FileNotFoundException)
        End Try
    End Function

    Private _employeeObservable As ObservableCollection(Of Employee)
    Public ReadOnly Property EmployeeObservable() As ObservableCollection(Of Employee)
        Get
            If _employeeObservable Is Nothing Then
                Dim list As New ObservableCollection(Of Employee)()
                For Each employee As Employee In _employee
                    list.Add(TryCast(employee, Employee))
                Next
                _employeeObservable = list
            End If
            Return _employeeObservable
        End Get
    End Property

    Private _customerObservable As ObservableCollection(Of Customer)
    Public ReadOnly Property CustomerObservable() As ObservableCollection(Of Customer)
        Get
            If _customerObservable Is Nothing Then
                Dim list As New ObservableCollection(Of Customer)()
                For Each customer As Customer In _customer
                    list.Add(TryCast(customer, Customer))
                Next
                _customerObservable = list
            End If
            Return _customerObservable
        End Get
    End Property

    Private _customerCollectionView As ICollectionView
    Public ReadOnly Property CustomerCollectionView() As ICollectionView
        Get
            If _customerCollectionView Is Nothing Then
                Dim list As New ObservableCollection(Of Customer)()
                For Each customer As Customer In _customer
                    list.Add(TryCast(customer, Customer))
                Next
                _customerCollectionView = New C1CollectionView(list)
            End If
            Return _customerCollectionView
        End Get
    End Property
End Class

Public Enum Occupation
    Doctor
    Artist
    Educator
    Engineer
    Executive
    Other
End Enum

Public Class Customer
    Implements INotifyPropertyChanged
    ' ** fields
    Private _id As String
    Private _first As String, _last As String
    Private _country As String
    Private _birthDate As DateTime
    Private _weight As Double
    Private _age As Integer
    Private _occupation As Occupation
    Private _phone As String
    Private _active As Boolean

    ' ** ctors
    Public Sub New()
        _birthDate = DateTime.Now
    End Sub

    ' ** object model
    <Display(Name:="ID")>
    <Editable(False)>
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set
            If Value <> _id Then
                _id = Value
                NotifyPropertyChanged("ID")
            End If
        End Set
    End Property

    <Display(Name:="Country")>
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set
            If Value <> _country Then
                _country = Value
                NotifyPropertyChanged("Country")
            End If
        End Set
    End Property

    <Display(Name:="Name")>
    Public ReadOnly Property Name() As String
        Get
            Return First + " " + Last
        End Get
    End Property

    <Display(Name:="First Name")>
    <Required(ErrorMessage:="First name is required.")>
    Public Property First() As String
        Get
            Return _first
        End Get
        Set
            If Value <> _first Then
                _first = Value

                ' call OnPropertyChanged with null parameter since setting this property
                ' modifies the value of "First" and also the value of "Name".
                NotifyPropertyChanged("First")
                NotifyPropertyChanged("Name")
            End If
        End Set
    End Property

    <Display(Name:="Last Name")>
    <Required(ErrorMessage:="Last name is required.")>
    Public Property Last() As String
        Get
            Return _last
        End Get
        Set
            If Value <> _last Then
                _last = Value

                ' call OnPropertyChanged with null parameter since setting this property
                ' modifies the value of "Last" and also the value of "Name".
                NotifyPropertyChanged("Last")
                NotifyPropertyChanged("Name")
            End If
        End Set
    End Property

    <Display(Name:="Birth Date")>
    Public Property BirthDate() As DateTime
        Get
            Return _birthDate
        End Get
        Set
            If Value <> _birthDate Then
                _birthDate = Value
                NotifyPropertyChanged("BirthDate")
            End If
        End Set
    End Property

    <Display(Name:="Age")>
    Public Property Age() As Integer
        Get
            Return _age
        End Get
        Set
            If Value <> _age Then
                _age = Value
                NotifyPropertyChanged("Age")
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
                NotifyPropertyChanged("Weight")
            End If
        End Set
    End Property

    <Display(Name:="Occupation")>
    Public Property Occupation() As Occupation
        Get
            Return _occupation
        End Get
        Set
            If Value <> _occupation Then
                _occupation = Value
                NotifyPropertyChanged("Occupation")
            End If
        End Set
    End Property

    <Display(Name:="Phone Number")>
    <C1InputPanelMask("(000) 000-0000")>
    Public Property Phone() As String
        Get
            Return _phone
        End Get
        Set
            If Value <> _phone Then
                _phone = Value
                NotifyPropertyChanged("Phone")
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
                NotifyPropertyChanged("Active")
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub
End Class

<XmlType("ArrayOfCustomer")>
Public Class Employees
    Public Property employees() As List(Of Employee)
End Class

<XmlType("Customer")>
Public Class Employee
    Implements INotifyPropertyChanged
    ' ** fields       
    Private _id As String
    Private _birthDate As DateTime
    Private _age As Integer
    Private _occupation As Occupation
    Private _phone As String

    ' ** ctors
    Public Sub New()
    End Sub

    <Display(Name:="ID")>
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set
            If Value <> _id Then
                _id = Value
                NotifyPropertyChanged("ID")
            End If
        End Set
    End Property

    <Display(Name:="Birth Date")>
    Public Property BirthDate() As DateTime
        Get
            Return _birthDate
        End Get
        Set
            If Value <> _birthDate Then
                _birthDate = Value
                NotifyPropertyChanged("BirthDate")
            End If
        End Set
    End Property

    <Display(Name:="Age")>
    Public Property Age() As Integer
        Get
            Return _age
        End Get
        Set
            If Value <> _age Then
                _age = Value
                NotifyPropertyChanged("Age")
            End If
        End Set
    End Property

    <Display(Name:="Occupation")>
    Public Property Occupation() As Occupation
        Get
            Return _occupation
        End Get
        Set
            If Value <> _occupation Then
                _occupation = Value
                NotifyPropertyChanged("Occupation")
            End If
        End Set
    End Property

    <Display(Name:="Phone Number")>
    <C1InputPanelMask("(000) 000-0000")>
    Public Property Phone() As String
        Get
            Return _phone
        End Get
        Set
            If Value <> _phone Then
                _phone = Value
                NotifyPropertyChanged("Phone")
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub
End Class