Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System.Linq
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class StylingSeries
    Inherits Page
    Private _data As List(Of FruitDataItem)
    Private _palettes As List(Of String)

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

    Public ReadOnly Property Palettes() As List(Of String)
        Get
            If _palettes Is Nothing Then
                _palettes = [Enum].GetNames(GetType(Palette)).ToList()
            End If

            Return _palettes
        End Get
    End Property
End Class