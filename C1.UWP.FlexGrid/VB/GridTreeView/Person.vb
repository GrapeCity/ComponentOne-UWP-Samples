Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Data class: Each Person object has a Children property that is a list of
''' Person objects.
''' </summary>
Public Class Person
    Implements INotifyPropertyChanged
    Shared _ctr As Integer
    Private _children As ObservableCollection(Of Person)
    Private _id As Integer
    Private _name As String
    Private _parent As Person

    Public Sub New()
        ID = System.Threading.Interlocked.Increment(_ctr)
        Name = String.Format(Strings.PersonFormat, ID)
        _children = New ObservableCollection(Of Person)()
        AddHandler _children.CollectionChanged, AddressOf OnCollectionChanged
    End Sub

    Private Sub OnCollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            For Each child As Person In e.NewItems
                child.Parent = Me
            Next
        End If
    End Sub

    <Display(Name:="ID")>
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set
            _id = Value
            OnPropertyChanged("ID")
        End Set
    End Property

    <Display(Name:="Name")>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set
            _name = Value
            OnPropertyChanged("Name")
        End Set
    End Property

    <Display(Name:="Parent")>
    Public Property Parent() As Person
        Get
            Return _parent
        End Get
        Protected Set
            _parent = Value
        End Set
    End Property
    Public ReadOnly Property Children() As ObservableCollection(Of Person)
        Get
            Return _children
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class