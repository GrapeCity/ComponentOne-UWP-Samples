Imports Windows.UI.Xaml.Shapes
Imports C1.Xaml
Imports System.Reflection
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
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps

Partial Public NotInheritable Class MapChart
    Inherits Page
    Private countries As New Countries()
    Private vl As C1VectorLayer
    Private btnLegend As New AppBarButton()
    Private btnZoomOrigin As New AppBarButton()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub MapChart_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        Me.maps.Zoom = 1
        Me.maps.Source = Nothing
        Me.maps.Center = New Point()
        countries.Clear()
        RemoveHandler maps.TargetZoomChanged, AddressOf maps_TargetZoomChanged
        Me.maps.Layers.Clear()
    End Sub

    Sub MapChart_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        maps.Source = Nothing
        vl = New C1VectorLayer() With {
            .LabelVisibility = LabelVisibility.Hidden,
            .Foreground = New SolidColorBrush(Color.FromArgb(255, &H97, &H35, &H35))
        }

        ' read text data from resources
        Using stream As Stream = GetType(MapChart).GetTypeInfo().Assembly.GetManifestResourceStream("MapsSamples.gdp-ppp.txt")
            Using sr As New StreamReader(stream)
                While Not sr.EndOfStream
                    Dim s As String = sr.ReadLine()

                    Dim ss As String() = s.Split(vbTab.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

                    countries.Add(New Country() With {
                        .Name = ss(1).Trim(),
                        .Value = Double.Parse(ss(2))
                    })
                End While
            End Using
        End Using

        ' create palette
        Dim cvals As New ColorValues()
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 241, 244, 255),
            .Value = 0
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 241, 244, 255),
            .Value = 5000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 224, 224, 246),
            .Value = 10000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 203, 205, 255),
            .Value = 20000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 179, 182, 230),
            .Value = 50000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 156, 160, 240),
            .Value = 100000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 127, 132, 243),
            .Value = 200000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 89, 97, 230),
            .Value = 500000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 56, 64, 217),
            .Value = 1000000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 19, 26, 148),
            .Value = 2000000
        })
        cvals.Add(New ColorValue() With {
            .Color = Color.FromArgb(255, 0, 3, 74),
            .Value = 1.001 * countries.GetMax()
        })

        countries.Converter = cvals

        ' read world map from resources
        Utils.LoadKMZFromResources(vl, "MapsSamples.WorldMap.kmz", True, AddressOf ProcessWorldMap)

        maps.Layers.Add(vl)

        AddHandler maps.TargetZoomChanged, AddressOf maps_TargetZoomChanged
        InitLegend()
    End Sub

    Sub maps_TargetZoomChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If e.NewValue >= 2 Then
            vl.LabelVisibility = LabelVisibility.AutoHide
        Else
            vl.LabelVisibility = LabelVisibility.Hidden
        End If
    End Sub

    Function ProcessWorldMap(v As C1VectorItemBase) As Boolean
        Dim name As String = TryCast(ToolTipService.GetToolTip(v), String)

        Dim country As Country = countries(name)
        If country IsNot Nothing Then
            v.Fill = country.Fill
        Else
            v.Fill = Nothing
        End If

        Return True
    End Function

    Sub InitLegend()
        ' create legend

        legend.Items.Clear()

        Dim cvals As ColorValues = CType(countries.Converter, ColorValues)

        Dim cnt As Integer = cvals.Count
        Dim sz As Double = 20

        Dim i As Integer = 0
        While i < cnt - 1
            Dim cv As ColorValue = cvals(i)
            Dim lbi As New ListBoxItem() With {
                .Height = sz,
                .Margin = New Thickness(0),
                .Padding = New Thickness(0)
            }
            Dim sp As New StackPanel() With {
                .Orientation = Orientation.Horizontal
            }
            Dim lgb As New LinearGradientBrush() With {
                .StartPoint = New Point(0, 0),
                .EndPoint = New Point(0, 1)
            }
            lgb.GradientStops.Add(New GradientStop() With {
                .Color = cv.Color,
                .Offset = 0
            })
            lgb.GradientStops.Add(New GradientStop() With {
                .Color = cvals(i + 1).Color,
                .Offset = 1
            })

            sp.Children.Add(New Rectangle() With {
                .Width = sz,
                .Height = sz,
                .Fill = lgb,
                .Stroke = New SolidColorBrush(Colors.LightGray),
                .StrokeThickness = 0.5,
                .RenderTransform = New TranslateTransform() With {
                    .Y = 0.5 * sz
                }
            })
            sp.Children.Add(New TextBlock() With {
                .Height = sz,
                .Text = cv.Value.ToString(),
                .VerticalAlignment = VerticalAlignment.Center
            })
            lbi.Content = sp
            legend.Items.Add(lbi)
            i += 1
        End While
        legend.Items.Add(New ListBoxItem() With {
            .Height = sz
        })
    End Sub

    Sub btnLegend_Click(sender As Object, e As RoutedEventArgs)
        legendPanel.Visibility = If(legendPanel.Visibility = Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed)
    End Sub
    Sub btnZoomOrigin_Click(sender As Object, e As RoutedEventArgs)
        maps.TargetZoom = 0
        maps.TargetCenter = New Point()
    End Sub

    Private Sub legend_DoubleTapped(sender As Object, e As Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs)
        e.Handled = True
    End Sub
End Class