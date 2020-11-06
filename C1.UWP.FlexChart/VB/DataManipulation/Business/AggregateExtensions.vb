
Module AggregateExtensions
    <Extension()>
    Public Function Aggregate(values As IEnumerable(Of Double), type As AggregateType, Optional customFun As Func(Of IEnumerable(Of Double), Double) = Nothing) As Double
        If customFun IsNot Nothing Then
            Return customFun(values)
        End If
        Select Case type
            Case AggregateType.Avg
                Return values.Average()
            Case AggregateType.Sum
                Return values.Sum()
            Case AggregateType.Max
                Return values.Max()
            Case AggregateType.Min
                Return values.Min()
            Case Else
                Return values.Sum()
        End Select
    End Function

    <Extension()>
    Public Function Sort(kvs As IEnumerable(Of KeyValuePair(Of Double, Object)), type As SortType) As IEnumerable(Of KeyValuePair(Of Double, Object))
        Select Case type
            Case SortType.Descending
                Return From kv In kvs.OrderByDescending(Function(k) k.Key) Select kv
            Case SortType.Ascending
                Return From kv In kvs.OrderBy(Function(k) k.Key) Select kv
            Case SortType.None
                Return kvs
            Case Else
                Return kvs
        End Select
    End Function

    <Extension()>
    Public Function GetValue(kvs As IEnumerable(Of KeyValuePair(Of Double, Object))) As IEnumerable(Of Object)
        Return From kv In kvs Select kv.Value
    End Function
End Module