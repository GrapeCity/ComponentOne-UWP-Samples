

Imports C1.Chart

Public Class AggregateViewModel
    Inherits ViewModelBase(Of AggregateFilter)
    Shared r As New Random()
    Public Sub New()
        Filter.AggregateType = AggregateType.Sum
        Dim sis As New Queue(Of AggregateItem)()

        For i As Integer = 0 To 239
            Dim month As Integer = ((i Mod 12) + 1)
            Dim q As Integer = Convert.ToInt32((month / 3) + (If((month Mod 3) = 0, 0, 1)))
            Dim year As Integer = Convert.ToInt32((1997 + (i - 1) / 12))

            sis.Enqueue(New AggregateItem() With {
                .Year = year,
                .M = month.ToString(),
                .Q = q,
                .Value = r.[Next](500)
            })
        Next
        Me.Source = sis
    End Sub

    Public Overrides Property Filter() As AggregateFilter
        Get
            Return MyBase.Filter
        End Get
        Set
            MyBase.Filter = Value
        End Set
    End Property

#Region "Selection Data"


    Private _aggregateProperty As String = Nothing
    Public Property AggregateProperty() As String
        Get
            Return _aggregateProperty
        End Get
        Set
            Dim key As String = Value
            If String.IsNullOrEmpty(key) Then
                Filter.Bindings = Nothing
            End If

            Select Case key
                Case "Year"
                    Filter.Bindings = New String() {"Year"}
                    Exit Select
                Case "Quarter"
                    Filter.Bindings = New String() {"Year", "Q"}
                    Exit Select
                Case Else
                    Filter.Bindings = Nothing
                    Exit Select
            End Select
        End Set
    End Property

    Private _aggregateTypes As Dictionary(Of String, AggregateType)
    Public ReadOnly Property AggregateTypes() As Dictionary(Of String, AggregateType)
        Get
            If _aggregateTypes Is Nothing Then
                _aggregateTypes = New Dictionary(Of String, AggregateType)()
                For Each item As Object In [Enum].GetValues(GetType(AggregateType))
                    _aggregateTypes.Add("Aggregate Type: " + DirectCast(item, AggregateType).ToString(), DirectCast(item, AggregateType))
                Next
            End If
            Return _aggregateTypes
        End Get
    End Property

    Private _aggregateProperties As Dictionary(Of String, String)
    Public ReadOnly Property AggregateProperties() As Dictionary(Of String, String)
        Get
            If _aggregateProperties Is Nothing Then
                _aggregateProperties = New Dictionary(Of String, String)()
                _aggregateProperties.Add("Aggregate Property: Null", "")
                _aggregateProperties.Add("Aggregate Property: Quarter", "Quarter")

                _aggregateProperties.Add("Aggregate Property: Year", "Year")
            End If
            Return _aggregateProperties
        End Get
    End Property

#End Region

End Class