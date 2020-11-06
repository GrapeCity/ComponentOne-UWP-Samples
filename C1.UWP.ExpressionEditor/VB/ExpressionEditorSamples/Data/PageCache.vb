Public Class PageCache
    ' Expression Cache
    Shared _expressionCache As String = ""
    Shared _fieldCache As String = ""

    Public Shared Function GetCacheExpression() As String
        Return _expressionCache
    End Function

    Public Shared Sub SetCacheExpression(expression As String)
        _expressionCache = expression
    End Sub

    Public Shared Function GetCacheField() As String
        Return _fieldCache
    End Function

    Public Shared Sub SetCacheField(field As String)
        _fieldCache = field
    End Sub
End Class
