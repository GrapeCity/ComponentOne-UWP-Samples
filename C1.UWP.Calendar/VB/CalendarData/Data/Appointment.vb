Imports System.Threading.Tasks
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Linq
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

<DataContract(Name:="Appointment", [Namespace]:="http://www.componentone.com")>
Public Class Appointment
    Implements INotifyPropertyChanged
    Public Sub New()
        Id = Guid.NewGuid()
    End Sub
    <DataMember>
    Public Property Id() As Guid

    Private _subject As String = ""
    <DataMember>
    Public Property Subject() As String
        Get
            Return _subject
        End Get
        Set
            If _subject <> Value Then
                _subject = Value
                OnPropertyChanged("Subject")
            End If
        End Set
    End Property

    Private _location As String = ""
    <DataMember>
    Public Property Location() As String
        Get
            Return _location
        End Get
        Set
            If _location <> Value Then
                _location = Value
                OnPropertyChanged("Location")
            End If
        End Set
    End Property

    Private _start As DateTime
    <DataMember>
    Public Property Start() As DateTime
        Get
            Return _start
        End Get
        Set
            If _start <> Value Then
                _start = Value
                OnPropertyChanged("Start")
            End If
        End Set
    End Property

    <DataMember>
    Public Property [End]() As DateTime
        Get
            Return _start.Add(_duration)
        End Get
        Set
            If Value >= _start Then
                Duration = (Value.Subtract(_start))
                OnPropertyChanged("End")
            End If
        End Set
    End Property

    Private _duration As TimeSpan
    Public Property Duration() As TimeSpan
        Get
            Return _duration
        End Get
        Set
            If _duration <> Value Then
                _duration = Value
                OnPropertyChanged("Duration")
            End If
        End Set
    End Property

    Private _description As String = ""
    <DataMember>
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set
            If _description <> Value Then
                _description = Value
                OnPropertyChanged("Description")
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
