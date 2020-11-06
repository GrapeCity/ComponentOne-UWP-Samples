

Public Class ViewModelBase(Of T As FilterBase)
    Implements INotifyPropertyChanged

    Private m_Filter As T
    Public Overridable Property Filter() As T
        Get
            Return m_Filter
        End Get
        Set
            m_Filter = Value
        End Set
    End Property

    Public Sub New()
        Filter = TryCast(Activator.CreateInstance(GetType(T)), T)

        AddHandler Me.Filter.PropertyChanged, AddressOf Filter_PropertyChanged
    End Sub

    Private Sub Filter_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        Me.OnPropertyChanged(e.PropertyName)
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Property Bindings() As String()
        Get
            Return Filter.Bindings
        End Get
        Set
            Filter.Bindings = Value
        End Set
    End Property

    Public Property BindingX() As String
        Get
            Return Filter.BindingX
        End Get
        Set
            Filter.BindingX = Value
        End Set
    End Property

    Public Property AggregateType() As AggregateType
        Get
            Return Filter.AggregateType
        End Get
        Set
            Filter.AggregateType = Value
        End Set
    End Property

    Public Property SortType() As SortType
        Get
            Return Filter.SortType
        End Get
        Set
            Filter.SortType = Value
        End Set
    End Property

    Public Property SortOrder() As Boolean
        Get
            Return Filter.SortOrder
        End Get
        Set
            Filter.SortOrder = Value
        End Set
    End Property


    Private _chartType As C1.Chart.ChartType = C1.Chart.ChartType.Column
    Public Property ChartType() As C1.Chart.ChartType
        Get
            Return _chartType
        End Get
        Set
            _chartType = Value
        End Set
    End Property

    Public Property Source() As Object
        Get
            Return Filter.Source
        End Get
        Set
            Filter.Source = Value
        End Set
    End Property

    Public ReadOnly Property DataSource() As Object
        Get
            Return Filter.DataSource
        End Get
    End Property



End Class