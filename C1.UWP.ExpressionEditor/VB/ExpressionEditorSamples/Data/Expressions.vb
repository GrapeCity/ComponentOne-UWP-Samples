Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Expressions
    Shared _expressions As New List(Of String)()
    Shared _rnd As New Random()

    Public Shared Function GetExpression() As String
        If _expressions.Count = 0 Then
            _expressions.Add("GetYear([Introduced])")
            _expressions.Add("Len([Name])")
            _expressions.Add("Iif([Price]>500, ""Price > 500"", ""Price <= 500"")")
            _expressions.Add("[Color]")
            _expressions.Add("Concat(Concat(GetYear([Introduced]), "" / ""), GetMonth([Introduced]))")
        End If

        Dim index As Object = _rnd.[Next](0, _expressions.Count)
        Return _expressions(index)
    End Function
End Class