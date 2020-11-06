Imports Rectangle = C1.Xaml.Chart.Annotation.Rectangle
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Markup
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports System.Windows
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Chart
Imports C1.Chart.Annotation
Imports C1.Chart

''' <summary>
''' Interaction logic for EventAnnotations.xaml
''' </summary>
Partial Public Class EventAnnotations
    Inherits Page
    Private dataService As DataService = DataService.GetService()
    Private _data As List(Of Quote)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub EventAnnotations_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim annotations As List(Of Annotation) = dataService.GetData(Of Annotation)("box-annotations")
        annotationLayer.Annotations.Clear()
        For Each anno As Annotation In annotations
            Dim rectangle As New Rectangle() With {
                .Content = "E",
                .Width = 20,
                .Height = 20,
                .Attachment = AnnotationAttachment.DataIndex,
                .PointIndex = anno.DataIndex,
                .TooltipText = If(anno.Description = Nothing, "[b]" + anno.Title + "[/b]", ("[b]" + anno.Title + "[/b]" + vbLf + anno.Description))
            }
            Dim fillColor As Color = CType(XamlBindingHelper.ConvertValue(GetType(Color), "#88bde6"), Color)
            rectangle.Style = New ChartStyle() With {
                .Fill = New SolidColorBrush(fillColor)
            }
            annotationLayer.Annotations.Add(rectangle)
        Next
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            If _data Is Nothing Then
                _data = dataService.GetSymbolData("box", 87)
            End If

            Return _data
        End Get
    End Property

    Private Sub rangeChanged(sender As Object, e As EventArgs)
        Dim yRange As Range = dataService.FindRenderedYRange(Data, selector.LowerValue, selector.UpperValue)
        financialChart.BeginUpdate()
        financialChart.AxisX.Min = selector.LowerValue
        financialChart.AxisX.Max = selector.UpperValue
        financialChart.AxisY.Min = yRange.Min
        financialChart.AxisY.Max = yRange.Max
        financialChart.EndUpdate()
    End Sub

    Private Sub selectorChart_Rendered(sender As Object, e As RenderEventArgs)
        If selector IsNot Nothing Then
            Dim axis As IAxis = TryCast(selectorChart.AxisX, IAxis)
            Dim min As Double = axis.GetMin()
            Dim max As Double = axis.GetMax()
            Dim range As Range = dataService.FindApproxRange(min, max, If(dataService.IsWindowsPhoneDevice(), 0.25, 0.45))
            selector.LowerValue = range.Min
            selector.UpperValue = range.Max
        End If
    End Sub
End Class