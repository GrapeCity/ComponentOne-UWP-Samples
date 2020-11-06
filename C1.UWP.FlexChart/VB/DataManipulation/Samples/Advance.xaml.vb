Imports Annotation = C1.Xaml.Chart.Annotation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Text
Imports Windows.UI
Imports Windows.Foundation
Imports System.Linq
Imports System
Imports C1.Xaml.Chart.Interaction
Imports C1.Xaml.Chart
Imports C1.Chart.Annotation
Imports C1.Chart

''' <summary>
''' Interaction logic for Advance.xaml
''' </summary>
Partial Public Class Advance
    Inherits Page
    Private _model As New AnnotationViewModel()
    Private infoAnnotation As Annotation.Rectangle

    Public Sub New()
        InitializeComponent()
        Me.DataContext = _model
    End Sub

    Public ReadOnly Property TextBrush() As SolidColorBrush
        Get
            If Util.IsWindowsDevice Then
                Return New SolidColorBrush(Colors.White)
            Else
                Return New SolidColorBrush(Colors.Black)
            End If
        End Get
    End Property

    Private Sub OnAdvanceLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetupAttotations()
    End Sub

    Sub SetupAttotations()
        Dim financialData As List(Of FinancialItem) = _model.FinancialData
        annotationLayer.Annotations.Clear()
        annotationLayer.Annotations.Add(New Annotation.Rectangle("", 10580, 1285) With {
            .Style = New ChartStyle() With {
                .Fill = New SolidColorBrush(Colors.Green) With {
                    .Opacity = 25.0 / 255
                },
                .Stroke = New SolidColorBrush(Colors.Transparent)
            },
            .Location = New Point(CType(financialData(20).[Date].ToOADate(), Single), 100),
            .Attachment = AnnotationAttachment.DataCoordinate,
            .Position = AnnotationPosition.Right
        })

        For Each data As FinancialItem In financialData
            If data.Volume >= 9 Then
                annotationLayer.Annotations.Add(New Annotation.Square(Strings.DContent, 20) With {
                    .Style = New ChartStyle() With {
                        .Fill = New SolidColorBrush(Colors.Blue) With {
                            .Opacity = 150.0 / 255
                        },
                        .Stroke = New SolidColorBrush(Colors.Transparent),
                        .StrokeThickness = 1
                    },
                    .ContentStyle = New ChartStyle() With {
                        .Stroke = TextBrush,
                        .FontSize = 10,
                        .FontWeight = FontWeights.Bold,
                        .FontFamily = New FontFamily("GenericSansSerif")
                    },
                    .SeriesIndex = 1,
                    .PointIndex = financialData.IndexOf(data),
                    .Attachment = AnnotationAttachment.DataIndex,
                    .TooltipText = Strings.DividendTooltip
                })
            End If
            If data.[Date].Day Mod 10 = 0 Then
                annotationLayer.Annotations.Add(New Annotation.Square(Strings.EContent, 20) With {
                    .Style = New ChartStyle() With {
                        .Fill = New SolidColorBrush(Colors.Aqua) With {
                            .Opacity = 150.0 / 255
                        },
                        .Stroke = New SolidColorBrush(Colors.Black)
                    },
                    .ContentStyle = New ChartStyle() With {
                        .FontSize = 10,
                        .FontWeight = FontWeights.Bold,
                        .FontFamily = New FontFamily("GenericSansSerif")
                    },
                    .SeriesIndex = 0,
                    .PointIndex = financialData.IndexOf(data),
                    .Attachment = AnnotationAttachment.DataIndex,
                    .TooltipText = Strings.CloseTooltip
                })
            End If
        Next
        annotationLayer.Annotations.Add(New Annotation.Line(Strings.RWContent) With {
            .Style = New ChartStyle() With {
                .Stroke = New SolidColorBrush(Colors.Aqua)
            },
            .ContentStyle = New ChartStyle() With {
                .Stroke = TextBrush,
                .FontSize = 12,
                .FontFamily = New FontFamily("GenericSansSerif")
            },
            .Start = New Point(CType(financialData(10).[Date].ToOADate(), Integer), 20),
            .[End] = New Point(CType(financialData(40).[Date].ToOADate(), Integer), 100),
            .Attachment = AnnotationAttachment.DataCoordinate
        })
        annotationLayer.Annotations.Add(New Annotation.Line("") With {
            .Style = New ChartStyle() With {
                .Stroke = New SolidColorBrush(Colors.Aqua)
            },
            .Start = New Point(CType(financialData(20).[Date].ToOADate(), Integer), 0),
            .[End] = New Point(CType(financialData(50).[Date].ToOADate(), Integer), 80),
            .Attachment = AnnotationAttachment.DataCoordinate
        })
        annotationLayer.Annotations.Add(New Annotation.Image("ms-appx:///DataManipulationLib/Assets/flag.png") With {
            .SeriesIndex = 0,
            .PointIndex = 20,
            .Attachment = AnnotationAttachment.DataIndex,
            .Position = AnnotationPosition.Top
        })
        annotationLayer.Annotations.Add(New Annotation.Text(Strings.FacebookContent) With {
            .Style = New ChartStyle() With {
                .Stroke = TextBrush,
                .FontFamily = New FontFamily("GenericSansSerif"),
                .FontSize = 12
            },
            .SeriesIndex = 0,
            .PointIndex = 20,
            .Attachment = AnnotationAttachment.DataIndex,
            .Position = AnnotationPosition.Left
        })
        annotationLayer.Annotations.Add(New Annotation.Image("ms-appx:///DataManipulationLib/Assets/flag.png") With {
            .SeriesIndex = 0,
            .PointIndex = 70,
            .Attachment = AnnotationAttachment.DataIndex,
            .Position = AnnotationPosition.Top
        })
        annotationLayer.Annotations.Add(New Annotation.Text(Strings.AlibabaContent) With {
            .Style = New ChartStyle() With {
                .Stroke = TextBrush,
                .FontFamily = New FontFamily("GenericSansSerif"),
                .FontSize = 12
            },
            .SeriesIndex = 0,
            .PointIndex = 70,
            .Attachment = AnnotationAttachment.DataIndex,
            .Position = AnnotationPosition.Left
        })
        annotationLayer.Annotations.Add(New Annotation.Image("ms-appx:///DataManipulationLib/Assets/arrowDOWN.png") With {
            .SeriesIndex = 0,
            .PointIndex = 30,
            .Attachment = AnnotationAttachment.DataIndex,
            .TooltipText = Strings.ArrowTooltip
        })
        annotationLayer.Annotations.Add(New Annotation.Image("ms-appx:///DataManipulationLib/Assets/arrowUP.png") With {
            .SeriesIndex = 0,
            .PointIndex = 50,
            .Attachment = AnnotationAttachment.DataIndex,
            .TooltipText = Strings.ArrowTooltip
        })
        If Util.IsWindowsDevice Then
            infoAnnotation = New Annotation.Rectangle("", 120, 100) With {
                .Style = New ChartStyle() With {
                    .Fill = New SolidColorBrush(Colors.SandyBrown) With {
                        .Opacity = 200.0 / 255
                    },
                    .Stroke = New SolidColorBrush(Colors.Chocolate)
                },
                .ContentStyle = New ChartStyle() With {
                    .Stroke = New SolidColorBrush(Colors.Chocolate),
                    .FontFamily = New FontFamily("GenericSansSerif"),
                    .FontSize = 10,
                    .FontWeight = FontWeights.Bold
                },
                .Location = New Point(100, 60),
                .Attachment = AnnotationAttachment.Absolute
            }
        Else
            infoAnnotation = New Annotation.Rectangle("", 120, 100) With {
                .Style = New ChartStyle() With {
                    .Fill = New SolidColorBrush(Colors.SandyBrown) With {
                        .Opacity = 200.0 / 255
                    },
                    .Stroke = New SolidColorBrush(Colors.Chocolate)
                },
                .ContentStyle = New ChartStyle() With {
                    .Stroke = New SolidColorBrush(Colors.Chocolate),
                    .FontFamily = New FontFamily("GenericSansSerif"),
                    .FontSize = 12,
                    .FontWeight = FontWeights.Bold
                },
                .Location = New Point(130, 60),
                .Attachment = AnnotationAttachment.Absolute
            }
        End If
    End Sub

    Private Sub flexChart_Rendered(sender As Object, e As RenderEventArgs)
        If flexChart.AxisX.Scrollbar Is Nothing Then
            flexChart.AxisX.Scrollbar = New C1AxisScrollbar() With {
                    .Height = 20,
                    .FontSize = 6
                }
        End If
    End Sub

    Private Sub flexChart_PointerMoved(sender As Object, e As PointerRoutedEventArgs)
        Dim pos As Point = e.GetCurrentPoint(flexChart).Position
        Dim dataList As List(Of FinancialItem) = _model.FinancialData
        If flexChart.PlotRect.Contains(pos) Then
            Dim ht As HitTestInfo = flexChart.HitTest(pos)
            Dim low As Double = dataList(ht.PointIndex).Low
            Dim hight As Double = dataList(ht.PointIndex).Hight
            Dim open As Double = dataList(ht.PointIndex).Open
            Dim close As Double = dataList(ht.PointIndex).Close
            Dim volume As Double = dataList(ht.PointIndex).Volume
            infoAnnotation.Content = String.Format(Strings.InfoTooltip, low, hight, open, close, volume)
            If Not annotationLayer.Annotations.Contains(infoAnnotation) Then
                annotationLayer.Annotations.Add(infoAnnotation)
            End If
            flexChart.Invalidate()
        End If
    End Sub
End Class