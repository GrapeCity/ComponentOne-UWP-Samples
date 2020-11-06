Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class PieSelection
    Inherits Page
    Private _data As List(Of FruitDataItem)
    Private _position As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Positions() As List(Of String)
        Get
            If _position Is Nothing Then
                _position = [Enum].GetNames(GetType(Position)).ToList()
            End If

            Return _position
        End Get
    End Property

    Public ReadOnly Property Offsets() As List(Of Double)
        Get
            Return New List(Of Double)() From {0, 0.1, 0.2}
        End Get
    End Property

    Public ReadOnly Property Data() As List(Of FruitDataItem)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateFruit()
            End If

            Return _data
        End Get
    End Property
End Class