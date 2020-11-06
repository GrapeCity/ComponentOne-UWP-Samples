Imports Windows.UI

Public Class Color2BrushConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim c As Color = DirectCast(value, Color)
        Return New SolidColorBrush(c)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim b As SolidColorBrush = DirectCast(value, SolidColorBrush)
        Return If(b Is Nothing, Colors.White, b.Color)
    End Function
End Class