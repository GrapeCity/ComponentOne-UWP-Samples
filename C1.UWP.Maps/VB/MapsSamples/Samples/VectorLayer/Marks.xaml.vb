Imports Windows.UI.Xaml.Shapes
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps
Imports C1.Xaml

Partial Public NotInheritable Class Marks
    Inherits Page
#Region "fields"
    Private vl As C1VectorLayer
    Private rnd As New Random()
    Private current As C1VectorPlacemark = Nothing
    Private shapes As Dictionary(Of C1VectorPlacemark, Path)
    Private idx As Integer = 1
    Private placeHolder As Canvas
    Private offsetX As Double
    Private offsetY As Double
    Private isCapture As Boolean = False
#End Region

    Public Sub New()
        InitializeComponent()

        shapes = New Dictionary(Of C1VectorPlacemark, Path)()
        comboSources.ItemsSource = [Enum].GetValues(GetType(Sources))
        comboSources.SelectedItem = Sources.VirtualEarthRoad
    End Sub

    Sub Marks_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        RemoveHandler c1Maps1.RightTapped, AddressOf maps_RightTapped
        shapes.Clear()
        comboSources.SelectedIndex = 0
        idx = 1
        Me.c1Maps1.Zoom = 0
        Me.c1Maps1.Center = New Point()
        Me.c1Maps1.Layers.Clear()
    End Sub

    Sub Marks_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        vl = New C1VectorLayer()
        c1Maps1.Layers.Add(vl)
        AddHandler c1Maps1.RightTapped, AddressOf maps_RightTapped
        c1Maps1.TargetCenter = New Point(0, 20)
        c1Maps1.Zoom = 2
        Dim i As Integer = 0
        While i < 10
            ' create random coordinates
            Dim pt As New Point(-80 + rnd.[Next](160), -80 + rnd.[Next](160))
            AddMark(pt)
            i += 1
        End While
    End Sub

    Sub maps_RightTapped(sender As Object, e As RightTappedRoutedEventArgs)
        AddMark(c1Maps1.ScreenToGeographic(e.GetPosition(c1Maps1)))
    End Sub

    Sub mark_ManipulationCompleted(sender As Object, e As ManipulationCompletedRoutedEventArgs)
        If Not isCapture Then
            Return
        End If
        isCapture = False
        If current IsNot Nothing Then
            vl.Children.Add(current)
            Dim currentPosition As Point = e.Container.C1TransformToVisual(c1Maps1).TransformPoint(e.Position)
            current.GeoPoint = Me.c1Maps1.ScreenToGeographic(New Point(currentPosition.X - offsetX, currentPosition.Y - offsetY))
            Dim timer As New DispatcherTimer()
            timer.Interval = New TimeSpan(0, 0, 0, 0, 120)
            AddHandler timer.Tick, Sub(s, e1)
                                       timer.[Stop]()
                                       If root.Children.Contains(placeHolder) Then
                                           root.Children.Remove(placeHolder)
                                       End If
                                       If placeHolder IsNot Nothing Then
                                           placeHolder.Children.Clear()
                                           placeHolder = Nothing
                                       End If

                                   End Sub
            timer.Start()
        End If
        current = Nothing
        offsetX = 0
        offsetY = 0
        e.Handled = True
    End Sub

    Sub mark_ManipulationDelta(sender As Object, e As ManipulationDeltaRoutedEventArgs)
        If current Is Nothing OrElse Not isCapture Then
            Return
        End If
        Dim pt As Point = e.Container.C1TransformToVisual(c1Maps1).TransformPoint(e.Position)
        If placeHolder IsNot Nothing Then
            placeHolder.RenderTransform = New TranslateTransform() With {
                .X = pt.X - offsetX,
                .Y = pt.Y - offsetY
            }
        End If
        e.Handled = True
    End Sub

    Sub mark_ManipulationStarted(sender As Object, e As ManipulationStartedRoutedEventArgs)
        current = TryCast(sender, C1VectorPlacemark)

        If current Is Nothing OrElse Not isCapture Then
            Return
        End If

        vl.Children.Remove(current)
        If placeHolder Is Nothing Then
            placeHolder = New Canvas()
            Dim shape As Shape = Nothing
            If shapes.Keys.Contains(current) Then
                shape = shapes(current)
            Else
                shape = InitShape(current)
            End If
            placeHolder.Children.Add(shape)
            Dim textBlock As TextBlock = InitLabel(current)
            placeHolder.Children.Add(textBlock)
            Dim pt As Point = Me.c1Maps1.GeographicToScreen(Me.current.GeoPoint)
            Dim currentPosition As Point = e.Container.C1TransformToVisual(c1Maps1).TransformPoint(e.Position)
            offsetX = currentPosition.X - pt.X
            offsetY = currentPosition.Y - pt.Y
            placeHolder.RenderTransform = New TranslateTransform() With {
                .X = pt.X,
                .Y = pt.Y
            }
        End If
        If Not Me.root.Children.Contains(placeHolder) Then
            Me.root.Children.Add(placeHolder)
        End If
        e.Handled = True
    End Sub

    Sub mark_DoubleTapped(sender As Object, e As DoubleTappedRoutedEventArgs)
        If placeHolder IsNot Nothing Then
            If root.Children.Contains(placeHolder) Then
                root.Children.Remove(placeHolder)
            End If
        End If
        e.Handled = True
        vl.Children.Remove(CType(sender, C1VectorPlacemark))
    End Sub


    Private Function InitShape(place As C1VectorPlacemark) As Path
        Dim path As New Path() With {
            .Fill = place.Fill,
            .Stroke = place.Stroke,
            .StrokeThickness = place.StrokeThickness,
            .StrokeDashArray = place.StrokeDashArray,
            .StrokeStartLineCap = place.StrokeStartLineCap,
            .StrokeEndLineCap = place.StrokeEndLineCap,
            .StrokeDashCap = place.StrokeDashCap,
            .StrokeLineJoin = place.StrokeLineJoin,
            .StrokeDashOffset = place.StrokeDashOffset,
            .StrokeMiterLimit = place.StrokeMiterLimit,
            .Data = place.Geometry
        }
        shapes.Add(place, path)

        Return path
    End Function

    Private Function InitLabel(place As C1VectorPlacemark) As TextBlock
        Dim text As TextBlock = TryCast(place.Label, TextBlock)
        text.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
        Dim desiredSize As Size = text.DesiredSize
        Dim left As Double = 0
        Dim top As Double = 2

        If text IsNot Nothing Then
            Select Case place.LabelPosition
                Case LabelPosition.Center
                    left = left - 0.5 * desiredSize.Width
                    top = top - 0.5 * desiredSize.Height
                    Exit Select
                Case LabelPosition.Bottom
                    left = left - 0.5 * desiredSize.Width
                    Exit Select
                Case LabelPosition.Top
                    left = left - 0.5 * desiredSize.Width
                    top = top - desiredSize.Height
                    Exit Select
                Case LabelPosition.Left
                    left = left - desiredSize.Width
                    top = top - 0.5 * desiredSize.Height
                    Exit Select
                Case LabelPosition.Right
                    top = top - 0.5 * desiredSize.Height
                    Exit Select
            End Select
            Canvas.SetLeft(text, left)
            Canvas.SetTop(text, top)
        End If

        Return text
    End Function

    Sub AddMark(pt As Point)
        Dim clr As Color = Colors.DarkRed
        Dim mark As New C1VectorPlacemark() With {
            .GeoPoint = pt,
            .Label = New TextBlock() With {
                .RenderTransform = New TranslateTransform() With {
                    .Y = -5
                },
                .IsHitTestVisible = False,
                .FontSize = 18,
                .Foreground = New SolidColorBrush(Colors.White),
                .Margin = New Thickness(0, 20, 0, 18),
                .Text = idx.ToString()
            },
            .LabelPosition = LabelPosition.Top,
            .Geometry = Utils.CreateBaloon(),
            .Fill = TryCast(root.Resources("MarkFill"), SolidColorBrush)
        }

        AddHandler mark.PointerPressed, AddressOf mark_PointerPressed
        AddHandler mark.ManipulationStarted, AddressOf mark_ManipulationStarted
        AddHandler mark.ManipulationDelta, AddressOf mark_ManipulationDelta
        AddHandler mark.ManipulationCompleted, AddressOf mark_ManipulationCompleted
        mark.ManipulationMode = ManipulationModes.TranslateX Or ManipulationModes.TranslateY

        vl.Children.Add(mark)
        vl.LabelVisibility = LabelVisibility.Visible

        AddHandler mark.DoubleTapped, AddressOf mark_DoubleTapped
        idx += 1
    End Sub

    Sub mark_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        isCapture = True
        e.Handled = True
    End Sub

    Private Sub comboSources_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Source = CType(comboSources.SelectedItem, Sources)
    End Sub

    Public Enum Sources
        VirtualEarthAerial
        VirtualEarthRoad
        VirtualEarthHybrid
    End Enum

    Private sourcesMap As New Dictionary(Of Sources, MultiScaleTileSource)() From {
        {Sources.VirtualEarthAerial, New VirtualEarthAerialSource()},
        {Sources.VirtualEarthRoad, New VirtualEarthRoadSource()},
        {Sources.VirtualEarthHybrid, New VirtualEarthHybridSource()}
    }

    Private _source As Sources
    Public Property Source() As Sources
        Get
            Return _source
        End Get
        Set
            _source = Value
            c1Maps1.Source = sourcesMap(_source)
        End Set
    End Property
End Class