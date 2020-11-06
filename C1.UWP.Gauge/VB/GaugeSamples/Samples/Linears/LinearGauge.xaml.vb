Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class LinearGauge
    Inherits Page

    Private _isPressed As Boolean

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub OnPointerMoved(sender As Object, e As PointerRoutedEventArgs)
        If _isPressed Then
            myGauge.Value = PointToValue(e.GetCurrentPoint(myGauge).Position)
        End If
    End Sub

    Private Sub OnPointerPressed(sender As Object, e As PointerRoutedEventArgs)
        myGauge.CapturePointer(e.Pointer)
        _isPressed = True
    End Sub

    Private Sub OnPointerReleased(sender As Object, e As PointerRoutedEventArgs)
        myGauge.ReleasePointerCapture(e.Pointer)
        _isPressed = False
    End Sub

    Private Function PointToValue(point As Point) As Double
        Dim min As Double = myGauge.ActualWidth * myGauge.XAxisLocation
        Dim max As Double = myGauge.ActualWidth * (1 - myGauge.XAxisLocation)
        If point.X <= min Then
            Return 0
        End If
        If point.X >= max Then
            Return 100
        End If
        Dim maxvalue As Double = myGauge.ActualWidth * myGauge.XAxisLength
        Dim locatX As Double = point.X - min
        Return locatX / maxvalue * 100
    End Function

End Class
