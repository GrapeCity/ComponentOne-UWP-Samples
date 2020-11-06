Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Linq
Imports System
Imports C1.Xaml.Chart.Interaction

Class GestureChartDemoModel
    Implements INotifyPropertyChanged
    Private _data As List(Of DataPoint)
    Private _currentPointsCount As Integer = 1000

    Public Property Data() As List(Of DataPoint)
        Get
            If _data Is Nothing Then
                _data = DataCreator.Create(_currentPointsCount)
            End If
            Return _data
        End Get
        Set
            _data = Value
            OnPropertyChanged("Data")
        End Set
    End Property

    Public ReadOnly Property GestureMode() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(GestureMode)).ToList()
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class