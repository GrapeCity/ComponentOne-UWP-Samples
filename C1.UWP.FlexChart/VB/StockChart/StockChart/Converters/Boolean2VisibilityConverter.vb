Public Class Boolean2VisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim b As Boolean = System.Convert.ToBoolean(value)
        Return If(b, Windows.UI.Xaml.Visibility.Visible, Windows.UI.Xaml.Visibility.Collapsed)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim v As Windows.UI.Xaml.Visibility = DirectCast(value, Windows.UI.Xaml.Visibility)
        Return v = Windows.UI.Xaml.Visibility.Visible
    End Function
End Class

Public Class Boolean2VisibilityConverter2
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim b As Boolean = System.Convert.ToBoolean(value)
        Return If(b, Visibility.Collapsed, Visibility.Visible)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim v As Visibility = DirectCast(value, Visibility)
        Return v = Visibility.Collapsed
    End Function
End Class