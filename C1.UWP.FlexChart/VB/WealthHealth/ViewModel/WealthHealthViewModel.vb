Imports Windows.ApplicationModel
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System

Public Class WealthHealthViewModel
    Inherits DependencyObject
    Implements INotifyPropertyChanged
    Private dataService As New DataService()
    Private _countries As List(Of Country)
    Private _content As String
    Private _trackContent As String
    Const YearMin As Double = 1800.0
    Const YearMax As Double = 2009.0
    Const AnimLength As Double = 15000
    Const PauseTip As String = ""
    Const ResumeTip As String = ""
    Private _sb As Storyboard

    Public Sub New()
        If Not DesignMode.DesignModeEnabled Then
            _countries = dataService.CreateData()
            ToggleAnimation()
        End If
    End Sub

    Public Property Countries() As List(Of Country)
        Get
            Return _countries
        End Get
        Set
            If _countries IsNot Nothing Then
                _countries = Value
                NotifyPropertyChanged("Countries")
            End If
        End Set
    End Property

    Public Property Content() As String
        Get
            Return _content
        End Get
        Set
            If Value <> _content Then
                _content = Value
                NotifyPropertyChanged("Content")
            End If
        End Set
    End Property

    Public ReadOnly Property PlayAnimation() As PlayCommand
        Get
            Return New PlayCommand(Sub()
                                       PerformAnimation()
                                   End Sub)
        End Get
    End Property

    Public Property TrackContent() As String
        Get
            Return _trackContent
        End Get
        Set
            If _trackContent <> Value Then
                _trackContent = Value
                NotifyPropertyChanged("TrackContent")
            End If
        End Set
    End Property

    Sub UpdateData(year As Integer)
        Countries = dataService.UpdateData(year)
    End Sub

    Public Property Year() As Double
        Get
            Return CType(GetValue(YearProperty), Double)
        End Get
        Set
            SetValue(YearProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly YearProperty As DependencyProperty = DependencyProperty.Register("Year", GetType(Double), GetType(WealthHealthViewModel), New PropertyMetadata(1800.0, AddressOf OnYearPropertyChanged))

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Shared Sub OnYearPropertyChanged(obj As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim w As Object = TryCast(obj, WealthHealthViewModel)
        If w IsNot Nothing Then
            Dim newValue As Integer = CType(Math.Floor(CType(e.NewValue, Double)), Integer)
            w.UpdateData(newValue)
        End If
    End Sub

    Sub ToggleAnimation()
        Dim animation As New DoubleAnimation() With {
            .From = YearMin,
            .[To] = YearMax,
            .Duration = New Duration(TimeSpan.FromMilliseconds(AnimLength)),
            .EnableDependentAnimation = True
        }
        If _sb Is Nothing Then
            _sb = New Storyboard()
            AddHandler _sb.Completed, AddressOf _sb_Completed
            _sb.Children.Add(animation)
        End If
        Storyboard.SetTarget(animation, Me)
        Storyboard.SetTargetProperty(animation, "Year")
        _sb.Begin()
        _content = ResumeTip
    End Sub

    Private Sub _sb_Completed(sender As Object, e As Object)
        Content = PauseTip
    End Sub

    Sub NotifyPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Sub PerformAnimation()
        If _sb IsNot Nothing Then
            If Year = YearMax Then
                Content = ResumeTip
                _sb.Begin()
            Else
                If _sb.GetCurrentTime().Milliseconds = AnimLength OrElse Content.Equals(PauseTip) Then
                    Content = ResumeTip
                    _sb.Seek(TimeSpan.FromMilliseconds(CType((Year - YearMin), Double) / CType((YearMax - YearMin), Double) * AnimLength))
                    _sb.[Resume]()
                Else
                    Content = PauseTip
                    _sb.Pause()
                End If
            End If
        End If
    End Sub

    Public Sub StopAnimation()
        If _sb IsNot Nothing AndAlso Content.Equals(ResumeTip) Then
            _sb.Pause()
            Content = PauseTip
        End If
    End Sub
End Class