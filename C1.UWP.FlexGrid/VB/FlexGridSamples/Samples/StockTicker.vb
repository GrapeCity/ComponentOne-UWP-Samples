Imports C1.Xaml.Sparkline
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation
Imports Windows.UI.Xaml.Shapes

''' <summary>
''' Interaction logic for StockTicker.xaml
''' </summary>
<TemplatePartAttribute(Name:="LayoutRoot", Type:=GetType(Grid))>
<TemplatePartAttribute(Name:="Arrow", Type:=GetType(Polygon))>
<TemplatePartAttribute(Name:="TxtChange", Type:=GetType(TextBlock))>
<TemplatePartAttribute(Name:="TxtValue", Type:=GetType(TextBlock))>
<TemplatePartAttribute(Name:="SparkLine", Type:=GetType(C1Sparkline))>
Public Class StockTicker
    Inherits Control
    Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Double), GetType(StockTicker), New PropertyMetadata(0.0, AddressOf ValueChanged))

    Private _format As String = "n2"
    Private _flash As Storyboard
    Private _bindingSource As String
    Private _firstTime As Boolean = True
    Private _root As Grid
    Private _arrow As Polygon
    Private _txtChange As TextBlock
    Private _txtValue As TextBlock
    Private _stArrow As ScaleTransform
    Private _sparkLine As C1Sparkline

    Shared _brNegative As Brush = New SolidColorBrush(Colors.Red)
    Shared _brPositive As Brush = New SolidColorBrush(Colors.Green)
    Shared _clrNegative As Color = Color.FromArgb(100, &HFF, 0, 0)
    Shared _clrPositive As Color = Color.FromArgb(100, 0, &HFF, 0)

    Public Sub New()
        IsHitTestVisible = False
        DefaultStyleKey = GetType(StockTicker)
    End Sub

    Protected Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()
        _root = TryCast(GetTemplateChild("LayoutRoot"), Grid)
        Dim [error] As Boolean = False
        If _root Is Nothing Then
            [error] = True
        Else
            _arrow = TryCast(GetTemplateChild("Arrow"), Polygon)
            If _arrow IsNot Nothing Then
                _stArrow = TryCast(_arrow.RenderTransform, ScaleTransform)
            End If
            _txtChange = TryCast(GetTemplateChild("TxtChange"), TextBlock)
            _txtValue = TryCast(GetTemplateChild("TxtValue"), TextBlock)
            _sparkLine = TryCast(GetTemplateChild("SparkLine"), C1Sparkline)
            [error] = [error] Or _arrow Is Nothing OrElse _txtChange Is Nothing OrElse _txtValue Is Nothing OrElse _stArrow Is Nothing OrElse _sparkLine Is Nothing
        End If
        If [error] Then
            Throw New System.Exception("StockTicker ControlTemplate doesn't contain all required members")
        End If
    End Sub

    Private ReadOnly Property Flash() As Storyboard
        Get
            If _flash Is Nothing Then
                _flash = CType(_root.Resources("Flash"), Storyboard)
            End If
            Return _flash
        End Get
    End Property
    Public Property Value() As Double
        Get
            Return CType(GetValue(ValueProperty), Double)
        End Get
        Set
            SetValue(ValueProperty, Value)
        End Set
    End Property

    Private Shared Sub ValueChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        TryCast(d, StockTicker).OnValueChanged(e)
    End Sub

    Private Sub OnValueChanged(e As DependencyPropertyChangedEventArgs)
        Dim value As Double = CType(e.NewValue, Double)
        Dim oldValue As Double = CType(e.OldValue, Double)

        ' resetting
        If Double.IsNaN(value) Then
            If _flash IsNot Nothing Then
                _flash.[Stop]()
            End If
            _root.Background = New SolidColorBrush(Colors.Transparent)
            _arrow.Fill = Nothing
            _txtChange.Foreground = _txtValue.Foreground
            Return
        End If

        ' get historical data
        Dim data As FinancialData = TryCast(Tag, FinancialData)
        Dim list As List(Of Decimal) = If(BindingSource <> Nothing, data.GetHistory(BindingSource), New System.Collections.Generic.List(Of Decimal)())
        If list IsNot Nothing AndAlso list.Count > 1 Then
            oldValue = CType(list(list.Count - 2), Double)
        End If

        ' calculate percentage change
        Dim change As Double = If(oldValue = 0 OrElse Double.IsNaN(oldValue), 0, (value - oldValue) / oldValue)

        ' update text
        _txtValue.Text = value.ToString(_format)
        _txtChange.Text = String.Format(Strings.Change, change * 100)

        ' update flash color
        Dim ca As ColorAnimation

        ' update symbol
        If change = 0 Then
            _arrow.Fill = Nothing
            _txtChange.Foreground = _txtValue.Foreground
        ElseIf change < 0 Then
            _stArrow.ScaleY = -1
            _txtChange.Foreground = _brNegative
            _arrow.Fill = _brNegative
            ca = TryCast(Flash.Children(0), ColorAnimation)
            ca.From = _clrNegative
        Else
            _stArrow.ScaleY = +1
            _txtChange.Foreground = _brPositive
            _arrow.Fill = _brPositive
            ca = TryCast(Flash.Children(0), ColorAnimation)
            ca.From = _clrPositive
        End If

        ' update sparkline
        If list IsNot Nothing Then
            _sparkLine.Data = Nothing
            _sparkLine.Data = list
        End If

        ' flash new value (but not right after the control was created)
        If Not _firstTime AndAlso change <> 0 Then
            _flash.Begin()
        End If
        _firstTime = False
    End Sub
    Public Property BindingSource() As String
        Get
            Return _bindingSource
        End Get
        Set
            _bindingSource = Value
        End Set
    End Property
    Public Property Format() As String
        Get
            Return _format
        End Get
        Set
            _format = Value
            _txtValue.Text = Value.ToString(_format)
        End Set
    End Property
End Class