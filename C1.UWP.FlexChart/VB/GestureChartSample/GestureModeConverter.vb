Imports Windows.UI.Xaml.Data
Imports System
Imports C1.Xaml.Chart.Interaction

Class GestureModeToStringConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return CType([Enum].Parse(GetType(GestureMode), value.ToString()), GestureMode)
    End Function
End Class