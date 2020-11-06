Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class CustomizingAxes
    Inherits Page
    Private _data As List(Of FruitDataItem)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of FruitDataItem)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateFruit()
            End If

            Return _data
        End Get
    End Property
End Class