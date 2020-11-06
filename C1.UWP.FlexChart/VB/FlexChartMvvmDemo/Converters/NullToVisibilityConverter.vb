Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.Collections.Generic
Imports System

Namespace Converters
    Public Class NullToVisibilityConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
            Return If(value Is Nothing, Visibility.Visible, Visibility.Collapsed)
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace