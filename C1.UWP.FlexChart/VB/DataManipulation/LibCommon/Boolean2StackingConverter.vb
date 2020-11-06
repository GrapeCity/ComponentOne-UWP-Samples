Imports C1.Chart

Public Class Boolean2StackingConverter
    Implements IValueConverter

    Private Function IValueConverter_Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim b As Boolean = CType(value, Boolean)
        If b Then
            Return Stacking.Stacked
        End If
        Return Stacking.None
    End Function

    Private Function IValueConverter_ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim s As Stacking = CType(value, Stacking)
        If s = Stacking.Stacked Then
            Return True
        End If
        Return False
    End Function
End Class
