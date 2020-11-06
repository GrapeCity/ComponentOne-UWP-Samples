Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Collections.ObjectModel
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Dynamic
    Inherits Page
    Const NUMBER_OF_POINTS As Integer = 20
    Private _timer As New DispatcherTimer()
    Private dataSource As New ObservableCollection(Of DynamicItem)()
    Private rnd As New Random()
    Private _counter As Integer = 1

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Dynamic_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler _timer.Tick, AddressOf _timer_Tick
        _timer.Interval = New TimeSpan(0, 0, 0, 1)
        _timer.Start()
    End Sub

    Private Sub _timer_Tick(sender As Object, e As Object)
        If dataSource.Count > NUMBER_OF_POINTS Then
            dataSource.RemoveAt(0)
        End If
        dataSource.Add(New DynamicItem() With {
            .Day = _counter,
            .Trucks = rnd.[Next](100),
            .Ships = rnd.[Next](100) / 2,
            .Planes = rnd.[Next](100) / 4
        })
        _counter += 1
    End Sub

    Public ReadOnly Property Data() As ObservableCollection(Of DynamicItem)
        Get
            Return dataSource
        End Get
    End Property

    Private Sub btnSlow_Click(sender As Object, e As RoutedEventArgs)
        If _timer IsNot Nothing Then
            _timer.Interval = New TimeSpan(0, 0, 0, 1)
        End If
    End Sub

    Private Sub btnMedium_Click(sender As Object, e As RoutedEventArgs)
        If _timer IsNot Nothing Then
            _timer.Interval = New TimeSpan(0, 0, 0, 0, 500)
        End If
    End Sub

    Private Sub btnFast_Click(sender As Object, e As RoutedEventArgs)
        If _timer IsNot Nothing Then
            _timer.Interval = New TimeSpan(0, 0, 0, 0, 100)
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As RoutedEventArgs)
        Dim button As Object = TryCast(sender, Button)
        If _timer.IsEnabled Then
            _timer.[Stop]()
            button.Content = Strings.BtnStart
        Else
            _timer.Start()
            button.Content = Strings.BtnStop
        End If
    End Sub
End Class