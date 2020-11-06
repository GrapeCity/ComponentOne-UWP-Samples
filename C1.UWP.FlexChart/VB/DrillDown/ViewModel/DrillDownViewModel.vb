


Imports Windows.UI

Public Class DrillDownViewModel
    Private _layer As DataLayer
    Private _sunburstLayer As SunburstDataLayer
    Private _treemapLayer As TreemapDataLayer
    Private _groupBy As String = "Country,City"

    Public ReadOnly Property ChartTypes() As List(Of String)
        Get
            Return New List(Of String)() From {
                "Column",
                "Pie"
            }
        End Get
    End Property

    Public ReadOnly Property Groups() As Dictionary(Of String, String)
        Get
            Dim groups__1 = New Dictionary(Of String, String)()
            groups__1.Add("Country and City", "Country,City")
            groups__1.Add("Country and Year", "Country,Year")
            groups__1.Add("Year and Country", "Year,Country")
            groups__1.Add("Country, City and Year", "Country,City,Year")
            groups__1.Add("Year, Country and City", "Year,Country,City")

            Return groups__1
        End Get
    End Property

    Public ReadOnly Property Aggregates() As Dictionary(Of String, AggregateType)
        Get
            Dim aggTypes = New Dictionary(Of String, AggregateType)()
            aggTypes.Add("Sum", AggregateType.Sum)
            aggTypes.Add("Count of Non-Null", AggregateType.Cnt)
            aggTypes.Add("Average", AggregateType.Avg)
            aggTypes.Add("Maximum", AggregateType.Max)
            aggTypes.Add("Minimum", AggregateType.Min)
            aggTypes.Add("Deviation", AggregateType.Rng)
            aggTypes.Add("Standard Deviation", AggregateType.Std)
            aggTypes.Add("Variance", AggregateType.Var)
            aggTypes.Add("Population Standard Deviation", AggregateType.StdPop)
            aggTypes.Add("Population variance", AggregateType.VarPop)

            Return aggTypes
        End Get
    End Property

    Public ReadOnly Property DataLayer() As DataLayer
        Get
            If _layer Is Nothing Then
                _layer = New DataLayer(DataService.Instance.GetData(500)) With {
                    .Binding = "Value",
                    .GroupBy = GroupBy
                }
            End If
            Return _layer
        End Get
    End Property

    Public Property GroupBy() As String
        Get
            Return _groupBy
        End Get
        Set
            _groupBy = Value
            DataLayer.GroupBy = _groupBy
        End Set
    End Property

    Public ReadOnly Property SunburstDataLayer() As SunburstDataLayer
        Get
            If _sunburstLayer Is Nothing Then
                _sunburstLayer = New SunburstDataLayer(DataService.Instance.GetSunburstData()) With {
                    .Binding = "Value",
                    .BindingX = "Year,Quarter,Month",
                    .CustomPalette = New List(Of Brush)() From {
                        GetBrush("#ff88bde6"),
                        GetBrush("#fffbb258"),
                        GetBrush("#ff90cd97"),
                        GetBrush("#fff6aac9"),
                        GetBrush("#ffbfa554"),
                        GetBrush("#ffbc99c7"),
                        GetBrush("#ffeddd46")
                    }
                }
            End If
            Return _sunburstLayer
        End Get
    End Property

    Public ReadOnly Property TreemapDataLayer() As TreemapDataLayer
        Get
            If _treemapLayer Is Nothing Then
                _treemapLayer = New TreemapDataLayer(DataService.Instance.GetTreemapData())
            End If
            Return _treemapLayer
        End Get
    End Property

    Private Function GetBrush(hex As String) As Brush
        hex = hex.Replace("#", String.Empty)
        Dim a As Byte = CByte(Convert.ToUInt32(hex.Substring(0, 2), 16))
        Dim r As Byte = CByte(Convert.ToUInt32(hex.Substring(2, 2), 16))
        Dim g As Byte = CByte(Convert.ToUInt32(hex.Substring(4, 2), 16))
        Dim b As Byte = CByte(Convert.ToUInt32(hex.Substring(6, 2), 16))

        Dim color__1 = Color.FromArgb(a, r, g, b)
        Return New SolidColorBrush() With {
            .Color = color__1,
            .Opacity = 0.7
        }
    End Function
End Class

