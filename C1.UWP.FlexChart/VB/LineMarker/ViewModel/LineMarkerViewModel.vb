Imports C1.Xaml.Chart.Interaction
Imports System.Collections.Generic
Imports System.Linq
Imports System

Public Class LineMarkerViewModel
    Const Count As Integer = 300
    Private rnd As New Random()

    Public ReadOnly Property Items() As List(Of DataItem)
        Get
            Dim data As New List(Of DataItem)()
            Dim [date] As New DateTime(2016, 1, 1)
            Dim i As Integer = 0
            While i < Count
                Dim item As New DataItem() With {
                    .[Date] = [date].AddDays(i),
                    .Input = rnd.[Next](10, 20),
                    .Output = rnd.[Next](0, 10)
                }
                data.Add(item)
                i += 1
            End While

            Return data
        End Get
    End Property

    Public ReadOnly Property LineType() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(LineMarkerLines)).ToList()
        End Get
    End Property

    Public ReadOnly Property LineMarkerInteraction() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(LineMarkerInteraction)).ToList()
        End Get
    End Property

    Public ReadOnly Property LineMarkerAlignments() As Dictionary(Of String, LineMarkerAlignment)
        Get
            Dim alignments As New Dictionary(Of String, LineMarkerAlignment)()
            alignments.Add(Strings.Auto, LineMarkerAlignment.Auto)
            alignments.Add(Strings.Right, LineMarkerAlignment.Right)
            alignments.Add(Strings.Left, LineMarkerAlignment.Left)
            alignments.Add(Strings.Bottom, LineMarkerAlignment.Bottom)
            alignments.Add(Strings.Top, LineMarkerAlignment.Top)
            alignments.Add(Strings.LeftBottom, LineMarkerAlignment.Left Or LineMarkerAlignment.Bottom)
            alignments.Add(Strings.LeftTop, LineMarkerAlignment.Left Or LineMarkerAlignment.Top)
            Return alignments
        End Get
    End Property

    Public ReadOnly Property CanDrag() As List(Of String)
        Get
            Return New List(Of String)() From {
                Strings.[True],
                Strings.[False]
            }
        End Get
    End Property
End Class