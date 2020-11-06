Imports C1.Xaml.Chart
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Axes
    Inherits Page
    Private _data As List(Of DataItem)
    Private rnd As New Random()
    Private npts As Integer = 12

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of DataItem)()
                Dim dt As Date = DateTime.Today
                Dim i As Integer = 0
                While i < npts
                    _data.Add(New DataItem() With {
                        .Time = dt.AddMonths(i),
                        .Precipitation = rnd.[Next](30, 100),
                        .Temperature = rnd.[Next](7, 20)
                    })
                    i += 1
                End While
            End If
            Return _data
        End Get
    End Property

    Public ReadOnly Property LabelAngles() As List(Of Double)
        Get
            Return New List(Of Double)() From {-90, -45, 0, 45, 90}
        End Get
    End Property

    Public Class DataItem
        Public Property Time() As DateTime
        Public Property Precipitation() As Integer
        Public Property Temperature() As Integer
    End Class

End Class