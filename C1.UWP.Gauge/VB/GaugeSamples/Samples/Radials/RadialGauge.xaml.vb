Imports Windows.UI.Xaml.Navigation
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

Partial Public NotInheritable Class RadialGauge
    Inherits Page

    Dim _isPressed As Boolean

    Public Sub New()
        Me.InitializeComponent()
    End Sub


    Private Sub OnPointerPressed(sender As Object, e As PointerRoutedEventArgs)
        myGauge.CapturePointer(e.Pointer)
        _isPressed = True
    End Sub

    Private Sub OnPointerMoved(sender As Object, e As PointerRoutedEventArgs)
        If _isPressed Then
            myGauge.Value = PointToValue(e.GetCurrentPoint(myGauge).Position)
        End If
    End Sub

    Private Sub OnPointerReleased(sender As Object, e As PointerRoutedEventArgs)
        myGauge.ReleasePointerCapture(e.Pointer)
        _isPressed = False
    End Sub


    Private Function PointToValue(point As Point) As Double
        Dim center As New Point(myGauge.PointerOrigin.X * myGauge.RenderSize.Width, myGauge.PointerOrigin.Y * myGauge.RenderSize.Height)
        Dim angle As Double = Mod360(Math.Atan2(point.X - center.X, center.Y - point.Y) * 180 / Math.PI)
        Return AngleToValue(angle)
    End Function

    Private Function Mod360(value As Double) As Double
        Dim result As Double = value Mod 360
        If value < 0 Then
            result += 360
        End If
        Return result
    End Function

    Private Function AngleToValue(angle As Double) As Double
        Dim alpha As Double = AngleToLogical(angle)
        Return LogicalToValue(alpha)
    End Function

    Private Function AngleToLogical(angle As Double) As Double
        Dim relativeAngle As Double = Mod360(angle - myGauge.StartAngle)
        Dim absSweepAngle As Double = myGauge.SweepAngle
        If absSweepAngle = 0 OrElse relativeAngle = 0 Then
            Return 0
        End If
        If absSweepAngle < 0 Then
            relativeAngle = 360 - relativeAngle
            absSweepAngle = -absSweepAngle
        End If
        Dim overflow As Double = relativeAngle - absSweepAngle
        If overflow > 0 Then
            Dim underflow As Double = 360 - relativeAngle
            Return If(overflow < underflow, 1, 0)
        End If
        Return relativeAngle / absSweepAngle
    End Function

    Private Function LogicalToValue(alpha As Double) As Double
        If alpha <= 0 Then
            Return myGauge.Minimum
        End If
        If 1 <= alpha Then
            Return myGauge.Maximum
        End If

        Dim linearValue As Double
        If Not myGauge.IsLogarithmic Then
            linearValue = alpha
        Else
            If myGauge.LogarithmicBase <= 1 Then
                Return myGauge.Minimum
            End If

            linearValue = (Math.Pow(myGauge.LogarithmicBase, alpha) - 1) / (myGauge.LogarithmicBase - 1)
        End If
        Return (myGauge.Minimum + (myGauge.Maximum - myGauge.Minimum) * linearValue)
    End Function

End Class

Class ValueTextConverter
    Implements IValueConverter
    Private Function IValueConverter_Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return CDbl(value).ToString("F0")
    End Function

    Private Function IValueConverter_ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

