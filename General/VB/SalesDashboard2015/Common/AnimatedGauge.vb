Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class AnimatedGauge
    Inherits C1.Xaml.Gauge.C1RadialGauge
    ''' <summary>
    ''' Gets or sets the target for the control's Value property.
    ''' </summary>
    Public Property AnimatedValue() As Double
        Get
            Return CType(GetValue(AnimatedValueProperty), Double)
        End Get
        Set
            SetValue(AnimatedValueProperty, Value)
        End Set
    End Property
    ''' <summary>
    ''' Identifies the <see cref="AnimatedValue"/> dependency property.
    ''' </summary>
    Public Shared ReadOnly AnimatedValueProperty As DependencyProperty = DependencyProperty.Register("AnimatedValue", GetType(Double), GetType(AnimatedGauge), New PropertyMetadata(Nothing, AddressOf OnTargetValuePropertyChanged))
    Shared Sub OnTargetValuePropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        ' get animated gauge
        Dim ag As AnimatedGauge = CType(d, AnimatedGauge)

        ' create animation
        Dim da As New DoubleAnimation()
        da.EnableDependentAnimation = True
        da.[To] = CType(e.NewValue, Double)
        da.Duration = New Duration(TimeSpan.FromMilliseconds(ag.Duration))
        Storyboard.SetTargetProperty(da, "Value")

        Storyboard.SetTarget(da, d)

        ' apply easing function
        Dim ef As EasingFunctionBase = ag.EasingFunction
        If ef Is Nothing Then
            Dim ee As New ElasticEase()
            ee.Oscillations = 1
            ee.Springiness = 3
            ef = ee
        End If
        da.EasingFunction = ef

        ' play animation
        Dim sb As New Storyboard()
        sb.Children.Add(da)
        sb.Begin()
    End Sub

    ''' <summary>
    ''' Gets or sets the easing function that animates the gauge pointer.
    ''' </summary>
    Public Property EasingFunction() As EasingFunctionBase
        Get
            Return CType(GetValue(EasingFunctionProperty), EasingFunctionBase)
        End Get
        Set
            SetValue(EasingFunctionProperty, Value)
        End Set
    End Property
    ''' <summary>
    ''' Identifies the <see cref="EasingFunction"/> dependency property.
    ''' </summary>
    Public Shared ReadOnly EasingFunctionProperty As DependencyProperty = DependencyProperty.Register("EasingFunction", GetType(EasingFunctionBase), GetType(AnimatedGauge), New PropertyMetadata(Nothing))
    ''' <summary>
    ''' Gets or sets the duration of the animation, in milliseconds.
    ''' </summary>
    Public Property Duration() As Double
        Get
            Return CType(GetValue(DurationProperty), Double)
        End Get
        Set
            SetValue(DurationProperty, Value)
        End Set
    End Property
    ''' <summary>
    ''' Identifies the <see cref="Duration"/> dependency property.
    ''' </summary>
    Public Shared ReadOnly DurationProperty As DependencyProperty = DependencyProperty.Register("Duration", GetType(Double), GetType(AnimatedGauge), New PropertyMetadata(250.0))
End Class