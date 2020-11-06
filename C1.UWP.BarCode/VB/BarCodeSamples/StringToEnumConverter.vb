Imports C1.BarCode

Public Class StringToEnumConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return CType([Enum].Parse(GetType(CodeType), value.ToString()), CodeType)
    End Function
End Class
