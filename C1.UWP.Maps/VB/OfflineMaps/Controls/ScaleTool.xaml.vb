Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps
Imports C1.Xaml

' The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class ScaleTool
    Inherits UserControl
    Public Sub New()
        'this.DataContext = this;
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Identifies the <see cref="Maps"/> dependency property. 
    ''' </summary>
    Public Shared ReadOnly MapsProperty As DependencyProperty = DependencyProperty.Register("Maps", GetType(C1Maps), GetType(ScaleTool), New PropertyMetadata(Nothing, AddressOf OnMapsPropertyChanged))

    Private Shared Sub OnMapsPropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        TryCast(d, ScaleTool).OnMapsChanged(TryCast(e.OldValue, C1Maps))
    End Sub

    Private Sub OnMapsChanged(oldMaps As C1Maps)
        If oldMaps IsNot Nothing Then
            RemoveHandler oldMaps.ZoomChanged, AddressOf OnZoomChanged
            RemoveHandler oldMaps.CenterChanged, AddressOf OnCenterChanged
            RemoveHandler oldMaps.SizeChanged, AddressOf OnSizeChanged
        End If

        If Me.Maps IsNot Nothing Then
            AddHandler Me.Maps.ZoomChanged, AddressOf OnZoomChanged
            AddHandler Me.Maps.CenterChanged, AddressOf OnCenterChanged
            AddHandler Me.Maps.SizeChanged, AddressOf OnSizeChanged
            UpdateScale()
        End If
    End Sub

    ''' <summary>
    ''' Gets or sets the <see cref="C1Maps" /> associated with this <see cref="C1Maps" />.
    ''' </summary>
    Public Property Maps() As C1Maps
        Get
            Return CType(GetValue(MapsProperty), C1Maps)
        End Get
        Set
            SetValue(MapsProperty, Value)
        End Set
    End Property

    Sub OnSizeChanged(sender As Object, e As SizeChangedEventArgs)
        UpdateScale()
    End Sub

    Sub OnCenterChanged(sender As Object, e As PropertyChangedEventArgs(Of Point))
        UpdateScale()
    End Sub

    Sub OnZoomChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        UpdateScale()
    End Sub

    Sub UpdateScale()
        UpdateScale(MetersScale, MetersLabel, 1, 1000, "km", "m")
        UpdateScale(MilesScale, MilesLabel, 3.2808399, 5280, "mi", "ft")
    End Sub

    Sub UpdateScale(scale As FrameworkElement, label As TextBlock, meterToUnit As Double, largeToSmall As Double, largeUnit As String, unit As String)
        If scale Is Nothing Then
            Return
        End If

        Dim minPixels As Double = If(Double.IsNaN(scale.MinWidth), 0, scale.MinWidth)
        Dim maxPixels As Double = If(Double.IsNaN(scale.MaxWidth), 500, scale.MaxWidth)

        Dim minDistance As Double = GetDistance(minPixels) * meterToUnit
        Dim maxDistance As Double = GetDistance(maxPixels) * meterToUnit

        Dim roundest As Integer = Me.Roundest(CType(minDistance, Integer), CType(maxDistance, Integer))
        If roundest.ToString().Length <= Math.Ceiling(Math.Log10(largeToSmall)) Then
            If label IsNot Nothing Then
                label.Text = CType(roundest, String) + " " + unit
            End If
        Else
            minDistance /= largeToSmall
            maxDistance /= largeToSmall
            roundest = Me.Roundest(CType(minDistance, Integer), CType(maxDistance, Integer))
            If label IsNot Nothing Then
                label.Text = CType(roundest, String) + " " + CType(largeUnit, String)
            End If
        End If

        Dim alpha As Double = (roundest - minDistance) * 1.0 / (maxDistance - minDistance)
        scale.Width = Math.Max(minPixels * (1 - alpha) + maxPixels * alpha, 0)
    End Sub

    ' returns the distance in meters from the center of the map to a point 'pixels' pixels to the right
    Function GetDistance(pixels As Double) As Double
        Return C1Maps.Distance(Maps.Center, Maps.ScreenToGeographic(New Point(Maps.ActualWidth / 2 + pixels, Maps.ActualHeight / 2)))
    End Function

    ' returns the largest number with more trailing zeros between min and max
    Function Roundest(min As Integer, max As Integer) As Integer
        Dim maxs As String = max.ToString()
        Dim mins As String = min.ToString()

        Dim i As Integer = 0
        While i < maxs.Length
            If maxs.Length > mins.Length OrElse maxs(i) <> mins(i) Then
                Return Integer.Parse(maxs.Substring(0, i + 1).PadRight(maxs.Length, "0"c))
            End If
            System.Threading.Interlocked.Increment(i)
        End While
        Return max
    End Function
End Class
