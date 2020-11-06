Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.ViewManagement
Imports Windows.Graphics.Display
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.CompilerServices
Imports System.Linq
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

Namespace Common
    ''' <summary>
    ''' Value converter that translates true to <see cref="Visibility.Visible"/> and false to
    ''' <see cref="Visibility.Collapsed"/>.
    ''' </summary>
    Public NotInheritable Class BooleanToVisibilityConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
            Return If((TypeOf value Is Boolean AndAlso CType(value, Boolean)), Visibility.Visible, Visibility.Collapsed)
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
            Return TypeOf value Is Visibility AndAlso CType(value, Visibility) = Visibility.Visible
        End Function
    End Class
End Namespace