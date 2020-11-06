Imports Windows.UI.Xaml.Data
Imports System.Collections.Specialized
Imports System

' converter used to group countries by their first initial
Class CountryInitialConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.Convert
        Return (CType(value, String))(0).ToString().ToUpper()
    End Function
    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class