Public Class IsComparisonModeToDisplayModeConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim b As Boolean = System.Convert.ToBoolean(value)
        Return If(b, DisplayMode.Comparison, DisplayMode.Independent)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim dm As DisplayMode = DirectCast(value, DisplayMode)
        Return dm = DisplayMode.Comparison
    End Function
End Class