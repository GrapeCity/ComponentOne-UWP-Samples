Public Class SelectToVisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim b As Boolean = System.Convert.ToBoolean(value)
        If b Then
            Return Visibility.Visible
        End If
        Return Visibility.Collapsed
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim v As Visibility = DirectCast(value, Visibility)
        If v = Visibility.Visible Then
            Return True
        End If
        Return False
    End Function
End Class