Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class SeriesBinding
    Inherits Page
    Private _function1Source As List(Of DataPoint)
    Private _function2Source As List(Of DataPoint)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub SeriesBinding_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetupChart()
    End Sub

    Sub SetupChart()
        flexChart.BeginUpdate()
        Me.Function1.ItemsSource = Function1Source
        Me.Function2.ItemsSource = Function2Source
        flexChart.EndUpdate()
    End Sub

    Public ReadOnly Property Function1Source() As List(Of DataPoint)
        Get
            If _function1Source Is Nothing Then
                _function1Source = DataCreator.Create(Function(x) 2 * Math.Sin(0.16 * x), Function(y) 2 * Math.Cos(0.12 * y), 160)
            End If

            Return _function1Source
        End Get
    End Property

    Public ReadOnly Property Function2Source() As List(Of DataPoint)
        Get
            If _function2Source Is Nothing Then
                _function2Source = DataCreator.Create(Function(x) Math.Sin(0.1 * x), Function(y) Math.Cos(0.15 * y), 160)
            End If

            Return _function2Source
        End Get
    End Property
End Class