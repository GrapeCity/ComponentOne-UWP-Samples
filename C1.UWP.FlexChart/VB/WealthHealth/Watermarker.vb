Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Markup
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation
Imports System
Imports C1.Xaml.Chart
Imports C1.Xaml

Public Class Watermarker
    Inherits ContentControl
    Private _marker As TextBlock

    Public Property ParentChart() As C1FlexChart
        Get
            Return CType(GetValue(ParentChartProperty), C1FlexChart)
        End Get
        Set
            SetValue(ParentChartProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly ParentChartProperty As DependencyProperty = DependencyProperty.Register("ParentChart", GetType(C1FlexChart), GetType(Watermarker), New PropertyMetadata(Nothing))

    Public Property Year() As Integer
        Get
            Return CType(GetValue(YearProperty), Integer)
        End Get
        Set
            SetValue(YearProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly YearProperty As DependencyProperty = DependencyProperty.Register("Year", GetType(Integer), GetType(Watermarker), New PropertyMetadata(0, AddressOf OnYearPropertyChanged))

    Shared Sub OnYearPropertyChanged(obj As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim w As Object = TryCast(obj, Watermarker)
        If w IsNot Nothing Then
            w.OnYearChanged()
        End If
    End Sub

    Sub OnYearChanged()
        If _marker Is Nothing Then
            _marker = New TextBlock() With {
                .Opacity = 0.1,
                .Foreground = New SolidColorBrush(CType(XamlBindingHelper.ConvertValue(GetType(Color), "#00916f"), Color))
            }
        End If
        InvalidateMeasure()
        InvalidateArrange()
    End Sub

    Protected Overrides Function MeasureOverride(constraint As Size) As Size
        If _marker IsNot Nothing Then
            If constraint.Height <> 0 AndAlso constraint.Width <> 0 Then
                If Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
                    _marker.FontSize = 120
                Else
                    _marker.FontSize = Math.Min(constraint.Height, constraint.Width) / 2
                End If
                _marker.Text = Year.ToString()
                _marker.Measure(New Size(constraint.Width, constraint.Height))
            End If
        End If
        Return MyBase.MeasureOverride(constraint)
    End Function

    Protected Overrides Function ArrangeOverride(arrangeBounds As Size) As Size
        If _marker IsNot Nothing AndAlso ParentChart IsNot Nothing Then
            Dim rect As Rect = ParentChart.PlotRect
            Dim desiredSize As Size = _marker.DesiredSize
            _marker.Arrange(New Rect(rect.Right - desiredSize.Width, rect.Bottom - desiredSize.Height, desiredSize.Width, desiredSize.Height))
            If Me.Content Is Nothing Then
                Content = _marker
            End If
        End If
        Return arrangeBounds
    End Function
End Class