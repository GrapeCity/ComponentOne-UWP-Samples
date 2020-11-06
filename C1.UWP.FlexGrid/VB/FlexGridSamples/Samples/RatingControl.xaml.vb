Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Reflection
Imports System

Partial Public Class RatingControl
    Inherits Page
    Public Sub New()
        InitializeComponent()
        UpdateStars()
    End Sub

    Public Property Rating() As Integer
        Get
            Return CType(GetValue(RatingProperty), Integer)
        End Get
        Set
            SetValue(RatingProperty, Value)
        End Set
    End Property

    Sub OnPropertyChanged(e As DependencyPropertyChangedEventArgs)
        If e.[Property].Equals(RatingProperty) Then
            UpdateStars()
        End If
    End Sub

    Sub UpdateStars()
        Dim i As Integer = 0
        While i < _sp.Children.Count
            _sp.Children(i).Opacity = If(Rating > i, 1, 0.1)
            i += 1
        End While
    End Sub

    Public Shared ReadOnly RatingProperty As DependencyProperty = DependencyProperty.Register("Rating", GetType(Integer), GetType(RatingControl), New PropertyMetadata(0, AddressOf RatingControl.OnPropertyChanged))
    Shared Sub OnPropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim ctl As RatingControl = CType(d, RatingControl)
        ctl.OnPropertyChanged(e)
    End Sub
End Class