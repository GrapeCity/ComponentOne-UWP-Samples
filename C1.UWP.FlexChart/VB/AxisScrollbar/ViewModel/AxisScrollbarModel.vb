Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class AxisScrollbarModel
    Private rnd As New Random()

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            Dim pointsCount As Object = rnd.[Next](1, 30)
            Dim pointsList As New List(Of DataItem)()
            Dim [date] As New DateTime(DateTime.Now.Year - 3, 1, 1)
            While [date].Year < DateTime.Now.Year
                pointsList.Add(New DataItem() With {
                    .[date] = [date],
                    .Series1 = rnd.[Next](100)
                })
                [date] = [date].AddDays(1)
            End While

            Return pointsList
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return Strings.Description
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return Strings.Title
        End Get
    End Property
End Class