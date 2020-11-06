' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

Imports C1.Chart
Imports C1.Xaml.Chart
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class FunnelChart
    Inherits Page

    Private _data As List(Of DataItem)

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateFunnelData()
            End If
            Return _data
        End Get
    End Property

    Public ReadOnly Property FunnelTypes() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(FunnelChartType)).ToList()
        End Get
    End Property

    Public ReadOnly Property Funnel() As C1FlexChart
        Get
            Return funnelChart
        End Get
    End Property
End Class
