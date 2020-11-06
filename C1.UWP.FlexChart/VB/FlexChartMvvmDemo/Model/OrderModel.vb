Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Namespace Model
    Public Class OrderModel
        Public Property ID() As Integer

        Public Property [Date]() As DateTime

        Public Property Category() As String

        Public Property Country() As String

        Public Property Year() As String

        Public Property Amount() As Double
    End Class
End Namespace