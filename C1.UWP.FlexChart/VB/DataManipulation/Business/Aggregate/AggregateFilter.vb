Public Class AggregateFilter
    Inherits FilterBase
    Public Overrides Sub Analyse()
        Dim src As IEnumerable(Of Object) = TryCast(Me.Source, IEnumerable(Of Object))

        If src Is Nothing Then
            Return
        End If
        If Not src.Any() Then
            Return
        End If

        Dim data As IEnumerable(Of KeyValuePair(Of String, Double))

        If Bindings Is Nothing OrElse Bindings.Length = 0 Then
            data = From p In src Select New KeyValuePair(Of String, Double)(GetValueKey(p, New String() {"Year", "M"}), GetValue(p, "Value"))
        Else
            Dim groupedData As IEnumerable(Of IGrouping(Of String, Object)) = src.GroupBy(Function(k) GetValueKey(k, Bindings))
            data = From p In groupedData Select New KeyValuePair(Of String, Double)(GetValueKey(p.First(), Bindings).ToString(), (From k In p Select GetValue(k, "Value")).Aggregate(AggregateType))
        End If

        Me.DataSource = data.ToArray()

        Me.OnPropertyChanged("DataSource")
    End Sub
    Private Shared Function GetValueKey(obj As Object, keys As String()) As String
        Dim r As String = String.Empty
        For Each key As String In keys
            Select Case key
                Case "Q"
                    r += " Q" + GetValue(obj, key).ToString()
                    Exit Select
                Case "M"
                    Dim dt As New DateTime(1900, Convert.ToInt32(GetValue(obj, key)), 1)
                    r += " " + dt.ToString("MMM")
                    Exit Select
                Case Else
                    r += GetValue(obj, key).ToString()
                    Exit Select
            End Select
        Next
        Return r
    End Function
End Class