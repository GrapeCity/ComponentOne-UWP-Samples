Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation
Imports System.Text
Imports System.Collections.Generic
Imports System
Imports C1.Chart

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class PlotAreas
    Inherits Page
    Private _data As PlotAreasSampleDataItem()

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As PlotAreasSampleDataItem()
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateForPlotAreas()
            End If

            Return _data
        End Get
    End Property

End Class