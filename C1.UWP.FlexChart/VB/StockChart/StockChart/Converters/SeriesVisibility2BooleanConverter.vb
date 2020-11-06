Public Class SeriesVisibility2BooleanConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim v As C1.Chart.SeriesVisibility = DirectCast(value, C1.Chart.SeriesVisibility)
        Return v = C1.Chart.SeriesVisibility.Visible
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim b As Boolean = System.Convert.ToBoolean(value)
        Return If(b, C1.Chart.SeriesVisibility.Visible, C1.Chart.SeriesVisibility.Hidden)
    End Function
End Class