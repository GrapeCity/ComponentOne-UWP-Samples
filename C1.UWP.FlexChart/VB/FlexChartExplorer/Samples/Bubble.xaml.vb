Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Bubble
    Inherits Page
    Private _data As List(Of DataItem)
    Private npts As Integer = 30
    Private rnd As New Random()

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of DataItem)()
                Dim i As Integer = 0
                While i < npts
                    _data.Add(New DataItem() With {
                        .X = rnd.NextDouble(),
                        .Y = rnd.NextDouble(),
                        .Size = rnd.[Next](100)
                    })
                    i += 1
                End While
            End If

            Return _data
        End Get
    End Property

    Public Class DataItem
        Public Property X() As Double
        Public Property Y() As Double
        Public Property Size() As Double
    End Class
End Class