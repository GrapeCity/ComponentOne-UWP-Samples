Imports Windows.UI.Xaml.Documents
Imports Windows.UI.Text

Public Class TextBoxExt
    Inherits DependencyObject
    Public Shared Function GetFormattedText(obj As DependencyObject) As String
        Return CType(obj.GetValue(FormattedTextProperty), String)
    End Function

    Public Shared Sub SetFormattedText(obj As DependencyObject, value As String)
        obj.SetValue(FormattedTextProperty, value)
    End Sub

    Public Shared ReadOnly FormattedTextProperty As DependencyProperty = DependencyProperty.RegisterAttached("FormattedText",
                                                                                                             GetType(String),
                                                                                                             GetType(TextBoxExt),
                                                                                                             New PropertyMetadata(String.Empty,
                                                                                                             AddressOf OnFormattedTextPropertyChanged))

    Private Shared Sub OnFormattedTextPropertyChanged(obj As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim tb As TextBlock = TryCast(obj, TextBlock)
        tb.Inlines.Clear()
        Dim formattedText As String = TryCast(tb.GetValue(FormattedTextProperty), String)
        If String.IsNullOrEmpty(formattedText) Then
            Return
        End If

        Dim len As Integer = formattedText.Length
        Dim fIndex As Integer = formattedText.IndexOf("[b]")
        Dim lIndex As Integer = formattedText.IndexOf("[/b]")
        If fIndex <> -1 AndAlso lIndex <> -1 Then
            Dim title As String = formattedText.Substring(fIndex + 3, lIndex - fIndex - 3)
            tb.Inlines.Add(New Run() With {
                .Text = title,
                .FontWeight = FontWeights.Bold
            })
            If len > lIndex + 4 Then
                Dim description As String = formattedText.Substring(lIndex + 4, len - lIndex - 4)
                tb.Inlines.Add(New Run() With {
                    .Text = description
                })
            End If
        Else
            tb.Text = formattedText
        End If
    End Sub
End Class