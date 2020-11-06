Imports System.Threading.Tasks
Imports System.Text
Imports System.Reflection
Imports C1.Xaml.Chart
Imports System.Collections.Specialized
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Data
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports Windows.ApplicationModel.Resources.Core
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Linq
Imports System



' The data model defined by this file serves as a representative example of a strongly-typed
' model that supports notification when members are added, removed, or modified.  The property
' names chosen coincide with data bindings in the standard item templates.
'
' Applications may use this model as a starting point and build on it, or discard it entirely and
' replace it with something appropriate to their needs.

Namespace DataModel
    ''' <summary>
    ''' Creates a collection of groups and items with hard-coded content.
    ''' 
    ''' SampleDataSource initializes with placeholder data rather than live production
    ''' data so that sample data is provided at both design-time and run-time.
    ''' </summary>
    Public Class SampleDataSource
        Inherits SalesDashboard2015.Common.BindableBase
        Private Shared _sampleDataSource As New SampleDataSource()
        Private startDate As New DateTime(2009, 1, 1)
        Private numPoints As Integer = 730
        Private types As String() = New String() {"Console", "Desktop", "Phone", "Tablet", "TV"}
        Private categories As String() = New String() {Strings.Desktop, Strings.Mobile, Strings.Other}
        Private partners As String() = New String() {Strings.Partner1, Strings.Partner2, Strings.Partner3, Strings.Partner4, Strings.Partner5, Strings.Partner6}
        Private quarters As String() = New String() {Strings.Q1, Strings.Q2, Strings.Q3, Strings.Q4}
        Private regions As New List(Of Region)()

        Private _allSales As New ObservableCollection(Of SampleDataItem)()
        Public ReadOnly Property AllSales() As ObservableCollection(Of SampleDataItem)
            Get
                Return Me._allSales
            End Get
        End Property

#Region "Total Sales"
        Public ReadOnly Property TotalSales() As Double
            Get
                Dim runningTotal As Double = 0
                For Each item As SampleDataItem In _allSales
                    runningTotal += item.SaleAmount
                Next
                Return runningTotal
            End Get
        End Property
#End Region

#Region "Sales by Type"
        Private _totalSalesConsole As Double
        Public ReadOnly Property TotalSalesConsole() As Double
            Get
                Return _totalSalesConsole
            End Get
        End Property

        Private _totalSalesDesktop As Double
        Public ReadOnly Property TotalSalesDesktop() As Double
            Get
                Return _totalSalesDesktop
            End Get
        End Property

        Private _totalSalesPhone As Double
        Public ReadOnly Property TotalSalesPhone() As Double
            Get
                Return _totalSalesPhone
            End Get
        End Property

        Private _totalSalesTablet As Double
        Public ReadOnly Property TotalSalesTablet() As Double
            Get
                Return _totalSalesTablet
            End Get
        End Property

        Private _totalSalesTV As Double
        Public ReadOnly Property TotalSalesTV() As Double
            Get
                Return _totalSalesTV
            End Get
        End Property
#End Region

#Region "Sales by Partner"

        Public ReadOnly Property SalesByPartner() As List(Of PartnersData)
            Get
                ' group all sales by partner
                Dim query As IEnumerable(Of IGrouping(Of String, SampleDataItem)) = _allSales.GroupBy(Function(sale) sale.Partner)
                Dim partnersDatas As New List(Of PartnersData)()
                Dim index As Integer = 0
                For Each group As IGrouping(Of String, SampleDataItem) In query
                    Dim data As New PartnersData()
                    Dim runningTotal As Double = 0
                    For Each item As SampleDataItem In group
                        runningTotal += item.SaleAmount
                    Next
                    data.TotalSale = runningTotal
                    data.PartnersName = partners(index)
                    index += 1
                    partnersDatas.Add(data)
                Next
                Return partnersDatas
            End Get
        End Property

#End Region

#Region "Sales by Category"
        Public ReadOnly Property SalesByCategory() As List(Of CategoryData)
            Get
                ' group all sales by category
                Dim query As IEnumerable(Of IGrouping(Of String, SampleDataItem)) = _allSales.GroupBy(Function(sale) sale.Category)
                Dim dataList As New List(Of CategoryData)()
                Dim index As Integer = 0
                Dim totalCategoryNumber As Double = 0
                Dim totalSaleNumber As Double = 0
                For Each group As IGrouping(Of String, SampleDataItem) In query
                    Dim data As New CategoryData()
                    For Each item As SampleDataItem In group
                        totalCategoryNumber += item.SaleAmount
                    Next
                    data.CategoryName = categories(index)
                    data.TotalSale = totalCategoryNumber
                    dataList.Add(data)
                    totalSaleNumber += totalCategoryNumber
                    totalCategoryNumber = 0
                    index += 1
                Next
                For Each data As CategoryData In dataList
                    Dim curNumber As Double = data.TotalSale
                    data.Percent = curNumber / totalSaleNumber * 100
                    data.Percent = Double.Parse(Convert.ToDouble(data.Percent).ToString("0.00"))
                Next
                Return dataList
            End Get
        End Property
#End Region

        '#Region "Sales by Region"
        Public ReadOnly Property SalesByRegion() As List(Of RegionData)
            Get
                ' group all sales by category
                Dim query As IEnumerable(Of IGrouping(Of Region, SampleDataItem)) = _allSales.GroupBy(Function(sale) sale.Region)
                Dim regionDatas As New List(Of RegionData)()
                For Each region As IGrouping(Of Region, SampleDataItem) In query
                    Dim data As New RegionData()
                    Dim firstItem As SampleDataItem = region.First()
                    data.Longitude = firstItem.Region.Longitude
                    data.Latitude = firstItem.Region.Latitude
                    data.RegionName = firstItem.Region.Name
                    Dim runningTotal As Double = 0
                    ' calculate total for group
                    For Each item As SampleDataItem In region
                        runningTotal += item.SaleAmount
                    Next
                    data.SaleValue = runningTotal
                    regionDatas.Add(data)
                Next
                Return regionDatas
            End Get
        End Property

        '#End Region

#Region "Sales by Quarter"

        Public ReadOnly Property SalesByQuarter() As List(Of QuarterData)
            Get
                ' group all sales by year
                'Dim yearGroup As IEnumerable(Of IGrouping(Of Integer, SampleDataItem)) = From sale In _allSales Group By SaleDate = sale.SaleDate.Year Into Group
                Dim yearGroup As IEnumerable(Of IGrouping(Of Integer, SampleDataItem)) = _allSales.GroupBy(Function(sale) sale.SaleDate.Year)
                Dim quarterDatas As New List(Of QuarterData)()
                For Each year As IGrouping(Of Integer, SampleDataItem) In yearGroup
                    Dim monthGroup As IEnumerable(Of IGrouping(Of Integer, SampleDataItem)) = year.GroupBy(Function(sale) sale.SaleDate.Month)
                    Dim firstItem As SampleDataItem = year.First()
                    Dim saleNumber As Double = 0
                    Dim counter As Integer = 1
                    For Each month As IGrouping(Of Integer, SampleDataItem) In monthGroup
                        For Each item As SampleDataItem In month
                            saleNumber += item.SaleAmount
                        Next
                        If counter.Equals(3) OrElse counter.Equals(6) OrElse counter.Equals(9) OrElse counter.Equals(12) Then
                            If quarterDatas.Count < (counter / 3) Then
                                Dim data As New QuarterData()
                                If firstItem.SaleDate.Year.Equals(2009) Then
                                    data.Year2009 = saleNumber
                                Else
                                    data.Year2010 = saleNumber
                                End If
                                data.Quarter = quarters(CType(counter / 3 - 1, Integer))
                                quarterDatas.Add(data)
                            Else
                                If firstItem.SaleDate.Year.Equals(2009) Then
                                    quarterDatas(CType(counter / 3 - 1, Integer)).Year2009 = saleNumber
                                Else
                                    quarterDatas(CType(counter / 3 - 1, Integer)).Year2010 = saleNumber
                                End If
                            End If
                            saleNumber = 0
                        End If
                        counter += 1
                    Next
                Next
                Return quarterDatas
            End Get
        End Property

#End Region

        Public Sub New()
            InitializeRegions()

            Dim rnd As New Random()
            Dim i As Integer = 0
            While i < numPoints
                _allSales.Add(New SampleDataItem(Guid.NewGuid().ToString(), types(rnd.[Next](types.Length)), categories(rnd.[Next](categories.Length)), partners(rnd.[Next](partners.Length)), regions(rnd.[Next](regions.Count)), startDate.AddDays(i),
                    rnd.[Next](0, i)))
                i += 1
            End While

            CalculateTotalSales()
        End Sub

        Private Sub InitializeRegions()
            regions.Add(New Region() With {
                .Name = Strings.Spain,
                .Latitude = 40.6986,
                .Longitude = -3.2949
            })
            regions.Add(New Region() With {
                .Name = Strings.USA,
                .Latitude = 40.423,
                .Longitude = -98.7372
            })
            regions.Add(New Region() With {
                .Name = Strings.Brazil,
                .Latitude = -15.6778,
                .Longitude = -47.4384
            })
            regions.Add(New Region() With {
                .Name = Strings.Uruguay,
                .Latitude = -33.0,
                .Longitude = -56.0
            })
            regions.Add(New Region() With {
                .Name = Strings.Russia,
                .Latitude = 54.827,
                .Longitude = 55.0423
            })
            regions.Add(New Region() With {
                .Name = Strings.China,
                .Latitude = 32.9043,
                .Longitude = 110.4677
            })
            regions.Add(New Region() With {
                .Name = Strings.Japan,
                .Latitude = 35.4112,
                .Longitude = 135.8337
            })

        End Sub

        Private Sub CalculateTotalSales()

            _totalSalesConsole = 0
            _totalSalesDesktop = 0
            _totalSalesPhone = 0
            _totalSalesTablet = 0
            _totalSalesTV = 0
            For Each item As SampleDataItem In _allSales
                If item.Type.Equals("TV") Then
                    _totalSalesTV += item.SaleAmount
                ElseIf item.Type.Equals("Desktop") Then
                    _totalSalesDesktop += item.SaleAmount
                ElseIf item.Type.Equals("Console") Then
                    _totalSalesConsole += item.SaleAmount
                ElseIf item.Type.Equals("Tablet") Then
                    _totalSalesTablet += item.SaleAmount
                ElseIf item.Type.Equals("Phone") Then
                    _totalSalesPhone += item.SaleAmount
                End If
            Next
        End Sub
    End Class

    ''' <summary>
    ''' Quarter item data model
    ''' </summary>
    Public Class QuarterData
        Public Property Quarter() As String
        Public Property Year2010() As Double
        Public Property Year2009() As Double
    End Class

    ''' <summary>
    ''' Partners item data model
    ''' </summary>
    Public Class PartnersData
        Public Property PartnersName() As String
        Public Property TotalSale() As Double
    End Class

    ''' <summary>
    ''' Region item data model
    ''' </summary>
    Public Class RegionData
        Public Property RegionName() As String
        Public Property Latitude() As Double
        Public Property Longitude() As Double
        Public Property SaleValue() As Double
    End Class

    Public Class CategoryData
        Public Property CategoryName() As String
        Public Property TotalSale() As Double
        Public Property Percent() As Double
    End Class

    ''' <summary>
    ''' Generic item data model.
    ''' </summary>
    Public Class SampleDataItem
        Inherits Common.BindableBase
        Public Sub New()
        End Sub

        Public Sub New(uniqueId As [String], type As [String], category As [String], partner As [String], region As Region, saleDate As DateTime,
            saleAmount As Double)
            Me._uniqueId = uniqueId
            Me._type = type
            Me._category = category
            Me._partner = partner
            Me._region = region
            Me._saleAmount = saleAmount
            Me._saleDate = saleDate
        End Sub

        Private _uniqueId As String = String.Empty
        Public Property UniqueId() As String
            Get
                Return Me._uniqueId
            End Get
            Set
                Me.SetProperty(Me._uniqueId, Value)
            End Set
        End Property

        Private _type As String = String.Empty
        Public Property Type() As String
            Get
                Return Me._type
            End Get
            Set
                Me.SetProperty(Me._type, Value)
            End Set
        End Property

        Private _category As String = String.Empty
        Public Property Category() As String
            Get
                Return Me._category
            End Get
            Set
                Me.SetProperty(Me._category, Value)
            End Set
        End Property

        Private _partner As String = String.Empty
        Public Property Partner() As String
            Get
                Return Me._partner
            End Get
            Set
                Me.SetProperty(Me._partner, Value)
            End Set
        End Property

        Private _region As Region = Nothing
        Public Property Region() As Region
            Get
                Return Me._region
            End Get
            Set
                Me.SetProperty(Me._region, Value)
            End Set
        End Property

        Private _saleDate As DateTime
        Public Property SaleDate() As DateTime
            Get
                Return Me._saleDate
            End Get
            Set
                Me.SetProperty(Me._saleDate, Value)
            End Set
        End Property

        Private _saleAmount As Double
        Public Property SaleAmount() As Double
            Get
                Return Me._saleAmount
            End Get
            Set
                Me.SetProperty(Me._saleAmount, Value)
            End Set
        End Property
    End Class

    Public Class Region
        Public Property Name() As String
        Public Property Latitude() As Double
        Public Property Longitude() As Double
    End Class
End Namespace