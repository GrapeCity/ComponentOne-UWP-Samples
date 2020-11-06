

Public Class SortingFilter
    Inherits FilterBase

    Private _customSortFun As Func(Of IEnumerable(Of Double), Double)
    Public Property CustomSortFun() As Func(Of IEnumerable(Of Double), Double)
        Get
            Return Me._customSortFun
        End Get
        Set
            Me._customSortFun = Value
            Analyse()
        End Set
    End Property


    Public Overrides Sub Analyse()
        Dim src As IEnumerable(Of Object) = TryCast(Me.Source, IEnumerable(Of Object))

        If src Is Nothing OrElse Bindings Is Nothing OrElse Bindings.Length = 0 Then
            Return
        End If
        If Not src.Any() Then
            Return
        End If
        Dim data As IEnumerable(Of KeyValuePair(Of Double, Object))
        If CustomSortFun IsNot Nothing Then
            data = From p In src Select New KeyValuePair(Of Double, Object)(GetValues(p, Bindings).Aggregate(AggregateType, CustomSortFun), p)
        Else
            data = From p In src Select New KeyValuePair(Of Double, Object)(GetValues(p, Bindings).Aggregate(AggregateType), p)
        End If

        Dim tempData As IEnumerable(Of KeyValuePair(Of Double, Object)) = data.Sort(Me.SortType)
        Dim sortedTopNData As IEnumerable(Of Object) = data.Sort(Me.SortType).GetValue()

        Dim source As New Queue(Of Object)(sortedTopNData)

        Me.DataSource = source.ToArray()

        Me.OnPropertyChanged("DataSource")

    End Sub

End Class