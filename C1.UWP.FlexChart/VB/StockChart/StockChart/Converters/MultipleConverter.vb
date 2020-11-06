Class MultipleConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim v As Double = System.Convert.ToDouble(value)
        Dim times As Integer = System.Convert.ToInt32(parameter)
        If times < 1 Then
            times = 1
        End If
        Return v * times
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim v As Double = System.Convert.ToDouble(value)
        Dim times As Integer = System.Convert.ToInt32(parameter)
        If times < 1 Then
            times = 1
        End If
        Return v / times
    End Function
End Class