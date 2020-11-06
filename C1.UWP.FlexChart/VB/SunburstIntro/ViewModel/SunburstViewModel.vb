Imports System.Linq
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System
Imports C1.Chart

Public Class SunburstViewModel
    Implements INotifyPropertyChanged
    Private _legendPosition As String = "Auto"
    Private _selectedItemPosition As String = "Top"

    Public ReadOnly Property HierarchicalData() As List(Of DataItem)
        Get
            Return DataService.CreateHierarchicalData()
        End Get
    End Property

    Public ReadOnly Property FlatData() As List(Of FlatDataItem)
        Get
            Return DataService.CreateFlatData()
        End Get
    End Property

    Public ReadOnly Property View() As ICollectionView
        Get
            Return DataService.CreateGroupCVData()
        End Get
    End Property

    Public ReadOnly Property Positions() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(Position)).ToList()
        End Get
    End Property

    Public ReadOnly Property Palettes() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(Palette)).ToList()
        End Get
    End Property

    Public Property LegendPosition() As String
        Get
            Return _legendPosition
        End Get
        Set
            If _legendPosition <> Value Then
                _legendPosition = Value
                OnPropertyChanged("LegendPosition")
            End If
        End Set
    End Property

    Public Property SelectedItemPosition() As String
        Get
            Return _selectedItemPosition
        End Get
        Set
            If _selectedItemPosition <> Value Then
                _selectedItemPosition = Value
                OnPropertyChanged("SelectedItemPosition")
            End If
        End Set
    End Property

    Private Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class