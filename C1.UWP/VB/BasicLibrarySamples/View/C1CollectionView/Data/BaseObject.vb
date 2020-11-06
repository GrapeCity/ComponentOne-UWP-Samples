Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Reflection
Imports System

''' <summary>
''' Object that implements INotifyPropertyChanged.
''' </summary>
Public Class BaseObject
    Implements INotifyPropertyChanged
    ' ** INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(propName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub
    Protected Function SetValue(Of T)(ByRef field As T, value As T, propertyName As String) As Boolean
        If Not EqualityComparer(Of T).[Default].Equals(field, value) Then
            field = value
            OnPropertyChanged(propertyName)
            Return True
        End If
        Return False
    End Function
End Class

''' <summary>
''' Object that implements INotifyPropertyChanged and IEditableObject.
''' </summary>
Public Class BaseEditableObject
    Inherits BaseObject
    Implements IEditableObject
    Private _clone As Object

    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        _clone = Me.MemberwiseClone()
    End Sub

    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If _clone IsNot Nothing Then
            For Each pi As PropertyInfo In Me.[GetType]().GetRuntimeProperties()
                If pi.CanRead AndAlso pi.CanWrite Then
                    Dim value As Object = pi.GetValue(_clone)
                    pi.SetValue(Me, value)
                End If
            Next
        End If
        _clone = Nothing
    End Sub

    Public Sub EndEdit() Implements IEditableObject.EndEdit
        _clone = Nothing
    End Sub
End Class