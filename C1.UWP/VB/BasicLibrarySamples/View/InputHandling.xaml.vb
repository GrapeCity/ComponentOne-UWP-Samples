Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI
Imports Windows.Foundation
Imports System
Imports C1.Xaml

Partial Public Class InputHandling
    Inherits Page
    Private _dragHelper As C1DragHelper
    Private _zoomHelper As C1ZoomHelper
    Private _rand As New Random()

    Public Sub New()
        InitializeComponent()

        _dragHelper = New C1DragHelper(FramePanel, C1DragHelperMode.TranslateXY Or C1DragHelperMode.Inertia, captureElementOnPointerPressed:=False)
        AddHandler _dragHelper.DragStarting, AddressOf OnDragStarting
        AddHandler _dragHelper.DragStarted, AddressOf OnDragStarted
        AddHandler _dragHelper.DragDelta, AddressOf OnDragDelta
        AddHandler _dragHelper.DragCompleted, AddressOf OnDragCompleted
        AddHandler _dragHelper.DragInertiaStarted, AddressOf OnDragInertiaStarted
        _zoomHelper = New C1ZoomHelper(FramePanel, ctrlRequired:=False)
        AddHandler _zoomHelper.ZoomStarted, AddressOf OnZoomStarted
        AddHandler _zoomHelper.ZoomDelta, AddressOf OnZoomDelta
        AddHandler _zoomHelper.ZoomCompleted, AddressOf OnZoomCompleted
        AddHandler Rectangle.Tapped, AddressOf OnRectangleTapped
    End Sub

#Region "** tapped"

    Sub OnRectangleTapped(sender As Object, e As TappedRoutedEventArgs)
        Rectangle.Background = GetRandomBrush()
    End Sub

#End Region

#Region "** drag"
    Sub OnDragStarting(sender As Object, e As C1DragStartingEventArgs)
    End Sub

    Private _initialX As Double, _initialY As Double

    Sub OnDragStarted(sender As Object, e As EventArgs)
        Dim position As Point = GetPosition()
        _initialX = position.X
        _initialY = position.Y
    End Sub

    Sub OnDragDelta(sender As Object, e As C1DragDeltaEventArgs)
        Dim zoom As Double = GetZoom()
        Dim maxX As Double = FramePanel.ActualWidth - Rectangle.ActualWidth * zoom
        Dim maxY As Double = FramePanel.ActualHeight - Rectangle.ActualHeight * zoom
        Dim newX As Double = _initialX + e.CumulativeTranslation.X
        Dim newY As Double = _initialY + e.CumulativeTranslation.Y
        If e.IsInertial Then
            Bounce(maxX, maxY, newX, newY)
        Else
            RectangleClip(maxX, maxY, newX, newY)
        End If
        SetPosition(New Point(newX, newY))
    End Sub

    Sub OnDragInertiaStarted(sender As Object, e As EventArgs)
    End Sub

    Sub OnDragCompleted(sender As Object, e As EventArgs)
        Rectangle.Background = GetRandomBrush()
    End Sub

#End Region

#Region "** zoom"

    Private _initialZoom As Double
    Private _initialPosition As Point
    Private _relativePosition As Point

    Sub OnZoomStarted(sender As Object, e As C1ZoomStartedEventArgs)
        _dragHelper.Complete()
        _initialZoom = GetZoom()
        _initialPosition = GetPosition()
        _relativePosition = e.GetPosition(Rectangle)
    End Sub

    Sub OnZoomDelta(sender As Object, e As C1ZoomDeltaEventArgs)
        Dim maxZoom As Double = Math.Min(ActualWidth / Rectangle.ActualWidth, ActualHeight / Rectangle.ActualHeight) / 2
        Dim newZoom As Double = Math.Min(maxZoom, _initialZoom * e.UniformCumulativeScale)
        Dim maxX As Double = FramePanel.ActualWidth - Rectangle.ActualWidth * newZoom
        Dim maxY As Double = FramePanel.ActualHeight - Rectangle.ActualHeight * newZoom
        Dim newX As Double, newY As Double
        Zoom(maxZoom, _initialZoom, _initialPosition, _relativePosition, newZoom, newX,
            newY)
        RectangleClip(maxX, maxY, newX, newY)
        SetZoom(newZoom, newX, newY)
    End Sub

    Sub OnZoomInertiaStarted(sender As Object, e As EventArgs)
    End Sub

    Sub OnZoomCompleted(sender As Object, e As C1ZoomCompletedEventArgs)
        Dim maxZoom As Double = Math.Min(ActualWidth / Rectangle.ActualWidth, ActualHeight / Rectangle.ActualHeight) / 2
        Dim newZoom As Double = Math.Min(maxZoom, _initialZoom * e.UniformCumulativeScale)
        Dim maxX As Double = FramePanel.ActualWidth - Rectangle.ActualWidth * newZoom
        Dim maxY As Double = FramePanel.ActualHeight - Rectangle.ActualHeight * newZoom
        Dim newX As Double, newY As Double
        Zoom(maxZoom, _initialZoom, _initialPosition, _relativePosition, newZoom, newX,
            newY)
        RectangleClip(maxX, maxY, newX, newY)
        SetZoom(newZoom, newX, newY)
    End Sub

#End Region

#Region "** implementation"

    Private Function GetRandomBrush() As SolidColorBrush
        Dim buffer As Byte() = New Byte(3) {}
        _rand.NextBytes(buffer)
        Return New SolidColorBrush(Color.FromArgb(&HFF, buffer(0), buffer(1), buffer(2)))
    End Function

    Private Shared Sub RectangleClip(maxX As Double, maxY As Double, ByRef newX As Double, ByRef newY As Double)
        newX = Math.Max(0, Math.Min(maxX, newX))
        newY = Math.Max(0, Math.Min(maxY, newY))
    End Sub

    Private Shared Sub Bounce(maxX As Double, maxY As Double, ByRef newX As Double, ByRef newY As Double)
        If newX < 0 Then
            newX = If(CType((newX / maxX), Integer) Mod 2 = 0, -(newX Mod maxX), maxX + (newX Mod maxX))
        Else
            newX = If(CType((newX / maxX), Integer) Mod 2 = 0, newX Mod maxX, maxX - (newX Mod maxX))
        End If
        If newY < 0 Then
            newY = If(CType((newY / maxY), Integer) Mod 2 = 0, -(newY Mod maxY), maxY + (newY Mod maxY))
        Else
            newY = If(CType((newY / maxY), Integer) Mod 2 = 0, newY Mod maxY, maxY - (newY Mod maxY))
        End If
    End Sub

    Private Shared Sub Zoom(maxZoom As Double, initialZoom As Double, initialPosition As Point, relativePosition As Point, zoom As Double, ByRef newX As Double,
        ByRef newY As Double)
        newX = initialPosition.X + ((relativePosition.X * initialZoom) - (relativePosition.X * zoom))
        newY = initialPosition.Y + ((relativePosition.Y * initialZoom) - (relativePosition.Y * zoom))
    End Sub

    Private Function GetPosition() As Point
        Dim transform As CompositeTransform = TryCast(Rectangle.RenderTransform, CompositeTransform)
        Return New Point(transform.TranslateX, transform.TranslateY)
    End Function

    Private Sub SetPosition(position As Point)
        Dim transform As CompositeTransform = TryCast(Rectangle.RenderTransform, CompositeTransform)
        transform.TranslateX = position.X
        transform.TranslateY = position.Y
    End Sub

    Private Function GetZoom() As Double
        Dim transform As CompositeTransform = TryCast(Rectangle.RenderTransform, CompositeTransform)
        Return transform.ScaleX
    End Function

    Private Sub SetZoom(zoom As Double, x As Double, y As Double)
        Dim transform As CompositeTransform = TryCast(Rectangle.RenderTransform, CompositeTransform)
        transform.ScaleX = zoom
        transform.ScaleY = zoom
        transform.TranslateX = x
        transform.TranslateY = y
    End Sub

#End Region
End Class