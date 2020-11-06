Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.UI.Core
Imports Windows.System
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Xml.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps
Imports C1.Xaml

Partial Public NotInheritable Class Flicker
    Inherits Page
    Private _timer As DispatcherTimer
    Public Sub New()
        InitializeComponent()
        AddHandler btnLoad.IsEnabledChanged, Sub(s, e)
                                                 btnLoad.Content = If(btnLoad.IsEnabled, Strings.Load, Strings.Loading)
                                             End Sub
        maps.TargetZoom = 4
    End Sub

    Sub Flicker_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        txt.Visibility = Visibility.Visible
        Me.maps.Zoom = 0
        Me.maps.Center = New Point()
        Me.maps.Opacity = 0.5
        Me.maps.TargetCenter = New Point()
        _timer.[Stop]()


    End Sub

    Sub Flicker_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Me.maps.Zoom = 0
        ' shuffle images in z-order
        vl = TryCast(maps.Layers(0), C1VectorLayer)
        _timer = New DispatcherTimer() With {
            .Interval = TimeSpan.FromSeconds(0.5)
        }
        AddHandler _timer.Tick, Sub(ts, te)
                                    Dim cnt As Integer = vl.Children.Count
                                    If cnt >= 2 Then
                                        vl.BeginUpdate()

                                        Dim item As C1VectorItemBase = vl.Children(0)
                                        vl.Children.RemoveAt(0)
                                        vl.Children.Add(item)

                                        vl.EndUpdate()
                                    End If

                                End Sub
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(tb.Text) Then
            Dim source As String = String.Format("http://api.flickr.com/services/feeds/geo/{0}", tb.Text)
            If vl IsNot Nothing Then
                _timer.[Stop]()
                vl.UriSource = New Uri(source)
                btnLoad.IsEnabled = tb.IsEnabled = False
                txt.Text = Strings.Loading1
                txt.Visibility = Visibility.Visible
                Maps.Opacity = 0.5
            End If
        End If
    End Sub

    Private Sub Border_Tapped(sender As Object, e As TappedRoutedEventArgs)
        Dim bdr As Border = CType(sender, Border)

        ShowImage(bdr, "")
        ShowModalWindow()

        ' Find other images covered by the current images
        Dim pt0 As Point = e.GetPosition(bdr)

        Dim pt As Point = e.GetPosition(Maps)
        Dim pt1 As Point = pt, pt2 As Point = pt
        pt1.X -= pt0.X
        pt1.Y -= pt0.Y
        pt2.X = pt1.X + bdr.ActualWidth
        pt2.Y = pt1.Y + bdr.ActualWidth

        pt1 = Maps.ScreenToGeographic(pt1)
        pt2 = Maps.ScreenToGeographic(pt2)

        Dim min As New Point(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y))
        Dim max As New Point(Math.Max(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y))

        Dim list As New List(Of C1VectorPlacemark)()

        For Each pm As C1VectorPlacemark In vl.Children
            If pm.GeoPoint.X >= min.X AndAlso pm.GeoPoint.X <= max.X AndAlso pm.GeoPoint.Y >= min.Y AndAlso pm.GeoPoint.Y <= max.Y Then
                list.Add(pm)
            End If
        Next

        ' start "slideshow"
        If list.Count > 1 Then
            Dim dp As DispatcherTimer
            Dim tcnt As Integer = 0

            dp = New DispatcherTimer() With {
                .Interval = TimeSpan.FromSeconds(2)
            }
            AddHandler dp.Tick, Sub(se, ea)
                                    tcnt += 1
                                    If tcnt >= list.Count Then
                                        tcnt = 0
                                    End If

                                    ShowImage(TryCast(list(tcnt).LabelUI, FrameworkElement), String.Format("{0}/{1} ", tcnt + 1, list.Count))

                                End Sub

            AddHandler popup.Closed, Sub(s1, e1)
                                         dp.[Stop]()
                                     End Sub

            dp.Start()
        End If
    End Sub

    Private Sub ShowImage(lbl As FrameworkElement, header As String)
        If lbl IsNot Nothing Then
            Dim im As Image = TryCast(lbl.FindName("img"), Image)
            If im IsNot Nothing Then
                contImg.Source = im.Source
            End If
            Dim tb As TextBlock = TryCast(lbl.FindName("txt"), TextBlock)
            If tb IsNot Nothing Then
                tbHeader.Text = header + tb.Text
            End If
        End If
    End Sub

    Private Sub ShowModalWindow()
        'First we need to find out how big our window is, so we can center to it.
        Dim currentWindow As CoreWindow = Window.Current.CoreWindow

        'Set our background rectangle to fill the entire window
        mask.Height = currentWindow.Bounds.Height
        mask.Width = currentWindow.Bounds.Width
        mask.Margin = New Thickness(0, 0, 0, 0)

        'Make sure the background is visible
        mask.Visibility = Windows.UI.Xaml.Visibility.Visible

        'Here is where I get a bit tricky.  You see popMessage.ActualWidth will show
        'the full screen width, and not the actual width of the popup, and popMessage.Width
        'will show 0 at this point.  So we needed to calculate the actual
        'display width.  I do this by using a calculation that determines the
        'scaling percentage from the height, and then calculates that against my
        'original width coding.
        Popup.HorizontalOffset = (currentWindow.Bounds.Width / 2) - (400 / 2)
        Popup.VerticalOffset = (currentWindow.Bounds.Height / 2 - (440 / 2))
        Popup.IsOpen = True
    End Sub

    Private Sub btnClose_Tapped(sender As Object, e As TappedRoutedEventArgs)
        mask.Visibility = Windows.UI.Xaml.Visibility.Collapsed
        Popup.IsOpen = False
    End Sub

    Private _zoom As Double = 0

    Private Sub vl_UriSourceFailed(sender As Object, e As EventArgs)
        txt.Text = Strings.CannotLoadMessage
        btnLoad.IsEnabled = tb.IsEnabled = True
    End Sub

    Private Sub vl_UriSourceLoaded(sender As Object, e As EventArgs)
        txt.Visibility = Visibility.Collapsed
        Maps.Opacity = 1
        btnLoad.IsEnabled = tb.IsEnabled = True
        _timer.Start()

        Dim vl As C1VectorLayer = CType(sender, C1VectorLayer)
        Dim bnds As Rect = vl.Children.GetBounds()
        If Not bnds.IsEmpty Then
            Maps.TargetCenter = New Point(bnds.Left + 0.5 * bnds.Width, bnds.Top + 0.5 * bnds.Height)

            Dim w As Double = If(Maps.ActualWidth > 0, Maps.ActualWidth, 500)
            Dim h As Double = If(Maps.ActualHeight > 0, Maps.ActualHeight, 500)

            Dim scale As Double = Math.Max(bnds.Width / 360 * w, bnds.Height / 180 * h)


            _zoom = Math.Log(512 / Math.Max(scale, 1), 2.0)
            AddHandler maps.CenterChanged, AddressOf maps_CenterChanged
        End If
    End Sub

    Sub maps_CenterChanged(sender As Object, e As PropertyChangedEventArgs(Of Point))
        If Maps.TargetCenter = Maps.Center Then
            RemoveHandler maps.CenterChanged, AddressOf maps_CenterChanged
            maps.TargetZoom = _zoom
        End If
    End Sub

    Private Sub tb_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        If e.Key = VirtualKey.Enter Then
            Button_Click(btnLoad, New RoutedEventArgs())
        End If
    End Sub
End Class

Public Class ImageConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim xe As XElement = TryCast(value, XElement)

        If xe IsNot Nothing Then
            Dim content As XElement = xe.Element(xe.GetDefaultNamespace() + "content")
            If content IsNot Nothing Then
                Dim s As String = content.Value
                If Not String.IsNullOrEmpty(s) Then
                    Dim i1 As Integer = s.IndexOf("http://farm")
                    If i1 >= 0 Then
                        Dim i2 As Integer = s.IndexOf(".jpg", i1)
                        If i2 >= 0 Then
                            Return s.Substring(i1, i2 - i1 + ".jpg".Length)
                        End If
                    End If
                End If
            End If
        End If

        Return Nothing
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return value
    End Function
End Class