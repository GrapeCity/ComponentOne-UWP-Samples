<EditorBrowsable(EditorBrowsableState.Never)>
Public Class Bindable
    Implements INotifyPropertyChanged
    Protected Sub SetProperty(Of T)(ByRef [property] As T, value As T, propertyName As String)
        If Not Object.ReferenceEquals([property], value) Then
            [property] = value
            Notify(propertyName)
        End If
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Friend Sub Notify(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class

