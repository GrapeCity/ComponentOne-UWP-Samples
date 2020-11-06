Public Class IntToVisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim index = Integer.Parse(value.ToString())
        Dim preIndexes As IEnumerable(Of String) = parameter.ToString().Split(" ")

        If preIndexes.Any(Function(p) p = index) Then
            Return Visibility.Visible
        Else
            Return Visibility.Collapsed
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

