Imports Windows.UI.Xaml.Data
Imports System.Globalization
Imports System

Public Class IntToStringConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim val As Object = Double.Parse(value.ToString())
        Return CType(Math.Floor(val), Integer)
    End Function
End Class