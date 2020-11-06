Imports System.Globalization
Imports C1.Xaml.ExpressionEditor
Imports C1.Xaml

Public Class ExpressionGroupDescription
    Inherits GroupDescription
    Public Shared editer As New C1ExpressionEditor()

    Public Property Expression() As String

    Public Overrides Function GroupNameFromItem(item As Object, level As Integer, culture As CultureInfo) As Object
        editer.DataSource = item
        editer.Expression = Expression

        If editer.IsValid Then
            Return editer.Evaluate()
        End If
        Return ""
    End Function
End Class