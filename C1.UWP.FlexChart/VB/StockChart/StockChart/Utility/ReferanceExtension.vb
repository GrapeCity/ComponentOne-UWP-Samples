Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Module ReferanceExtension
    <Extension()>
    Public Function GetValue(obj As Object, [property] As String) As Double
        Return Convert.ToDouble(obj.[GetType]().GetProperty([property]).GetValue(obj, Nothing))
    End Function
    <Extension()>
    Public Function GetRefValue(obj As Object, [property] As String) As Object
        Return obj.[GetType]().GetProperty([property]).GetValue(obj, Nothing)
    End Function
End Module