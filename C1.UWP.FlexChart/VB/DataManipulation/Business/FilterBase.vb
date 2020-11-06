

Imports System.Reflection

Public MustInherit Class FilterBase
    Implements INotifyPropertyChanged
    Private _bindings As String()
    Private _bindingX As String
    Private _aggregateType As AggregateType = AggregateType.Sum
    Private _sortType As SortType = SortType.None
    Private _sortOrder As Boolean = False

    Private _source As Object

    Public Property Bindings() As String()
        Get
            Return Me._bindings
        End Get
        Set
            Me._bindings = Value
            Analyse()
        End Set
    End Property

    Public Property BindingX() As String
        Get
            Return Me._bindingX
        End Get
        Set
            Me._bindingX = Value
            Analyse()
        End Set
    End Property

    Public Property AggregateType() As AggregateType
        Get
            Return Me._aggregateType
        End Get
        Set
            Me._aggregateType = Value
            Analyse()
        End Set
    End Property

    Public Property SortType() As SortType
        Get
            Return Me._sortType
        End Get
        Set
            Me._sortType = Value
            Analyse()
        End Set
    End Property

    Public Property SortOrder() As Boolean
        Get
            Return Me._sortOrder
        End Get
        Set
            Me._sortOrder = Value
            Analyse()
        End Set
    End Property

    Public Property Source() As Object
        Get
            Return Me._source
        End Get
        Set
            Me._source = Value
            Analyse()
        End Set
    End Property

    Public Property DataSource() As Object
        Get
            Return m_DataSource
        End Get
        Protected Set
            m_DataSource = Value
        End Set
    End Property
    Private m_DataSource As Object

    Public MustOverride Sub Analyse()

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Protected Shared Function GetValue(obj As Object, binding As String) As Double
        Dim v As Double = Convert.ToDouble(obj.[GetType]().GetProperty(binding).GetValue(obj))

        Return v
    End Function
    Protected Shared Sub SetValue(obj As Object, binding As String, value As Object)
        obj.[GetType]().GetProperty(binding).SetValue(obj, value)
    End Sub

    Protected Shared Function GetValues(obj As Object, bindings As String()) As Double()
        Dim values As IEnumerable(Of Double) = From p In bindings Select Convert.ToDouble(obj.[GetType]().GetProperty(p).GetValue(obj))

        Return values.ToArray()
    End Function

End Class



Public Class DataSourceChangedEventArgs
    Inherits EventArgs
    Public Property DataSource() As Object
        Get
            Return m_DataSource
        End Get
        Set
            m_DataSource = Value
        End Set
    End Property
    Private m_DataSource As Object
End Class