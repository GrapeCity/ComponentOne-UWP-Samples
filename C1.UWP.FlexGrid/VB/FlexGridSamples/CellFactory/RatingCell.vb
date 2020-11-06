Imports Windows.UI.Xaml.Shapes
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports System

''' <summary>
''' Cell that shows a rating value as an image with stars.
''' </summary>
Public Class RatingCell
    Inherits StackPanel
    Const MAXRATING As Integer = 5
    Const OFF As Double = 0.2
    Const [ON] As Double = 1.0

    ''' <summary>
    ''' Identifies the <see cref="ItemsSource"/> dependency property.
    ''' </summary>
    Public Shared ReadOnly RatingProperty As DependencyProperty = DependencyProperty.Register("Rating", GetType(Integer), GetType(RatingCell), New PropertyMetadata(0, AddressOf OnRatingChanged))

    Public Sub New()
        Orientation = Orientation.Horizontal
        Dim i As Integer = 0
        While i < 5
            Dim star As New ContentControl()
            star.Width = 20
            star.Height = 20
            star.ContentTemplate = GetStarPath()
            star.Opacity = OFF
            AddHandler star.PointerPressed, AddressOf img_PointerPressed
            Children.Add(star)
            i += 1
        End While
    End Sub

    Public Property Rating() As Integer
        Get
            Return CType(GetValue(RatingProperty), Integer)
        End Get
        Set
            SetValue(RatingProperty, Value)
        End Set
    End Property
    Sub img_PointerPressed(sender As Object, e As Windows.UI.Xaml.Input.PointerRoutedEventArgs)
        ' calculate rating based on the index of the star
        Dim star As ContentControl = TryCast(sender, ContentControl)
        Dim cell As RatingCell = TryCast(star.Parent, RatingCell)
        Dim index As Integer = cell.Children.IndexOf(star)
        If index > 0 OrElse e.GetCurrentPoint(star).Position.X > star.Width / 3 Then
            index += 1
        End If

        ' apply the new rating
        cell.Rating = index
        Animate(star)
    End Sub

    Shared Function GetStarPath() As DataTemplate
        Return TryCast(TemplateCell.CustomTemplatesDictionary("StarIcon"), DataTemplate)
    End Function

    Shared Sub OnRatingChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim cell As RatingCell = CType(d, RatingCell)
        Dim i As Integer = 0
        While i < cell.Children.Count
            cell.Children(i).Opacity = If(i < cell.Rating, [ON], OFF)
            i += 1
        End While
    End Sub

    Shared _animate As FrameworkElement
    Shared _sb As Storyboard
    Sub Animate(star As FrameworkElement)
        ' create storyboard
        If _sb Is Nothing Then
            _sb = New Storyboard()
            _sb.Duration = New Duration(TimeSpan.FromMilliseconds(20))
            AddHandler _sb.Completed, AddressOf sb_Completed
        End If

        ' suspend current animation if any
        If _animate IsNot Nothing Then
            _sb.[Stop]()
            _animate.RenderTransform = Nothing
        End If

        ' start new animation
        star.RenderTransform = New ScaleTransform() With {
                .ScaleX = 2,
                .ScaleY = 2,
                .CenterX = star.Width / 2,
                .CenterY = star.Height / 2
            }
        _animate = star
        _sb.Begin()
    End Sub

    Sub sb_Completed(sender As Object, e As Object)
        Dim st As ScaleTransform = TryCast(_animate.RenderTransform, ScaleTransform)
        If st IsNot Nothing Then
            If st.ScaleX > 1 Then
                st.ScaleX -= 0.1
                st.ScaleY -= 0.1
                _sb.Begin()
            End If
            Return
        End If
    End Sub
End Class