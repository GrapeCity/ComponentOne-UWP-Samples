Imports Windows.Storage
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.IO
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System
Imports Windows.Storage.Streams

''' <summary>
''' Based on this: http://en.wikipedia.org/wiki/Market_data
''' </summary>
Public Class FinancialData
    Implements INotifyPropertyChanged
    Const HISTORY_SIZE As Integer = 5
    Private _askHistory As New List(Of Decimal)()
    Private _bidHistory As New List(Of Decimal)()
    Private _saleHistory As New List(Of Decimal)()

    <Display(Name:="Symbol")>
    Public Property Symbol() As String
        Get
            Return CType(GetProp("Symbol"), String)
        End Get
        Set
            SetProp("Symbol", Value)
        End Set
    End Property

    <Display(Name:="Name")>
    Public Property Name() As String
        Get
            Return CType(GetProp("Name"), String)
        End Get
        Set
            SetProp("Name", Value)
        End Set
    End Property

    <Display(Name:="Bid")>
    Public Property Bid() As Decimal
        Get
            Return CType(GetProp("Bid"), Decimal)
        End Get
        Set
            AddHistory(_bidHistory, Value)
            SetProp("Bid", Value)
        End Set
    End Property

    <Display(Name:="Ask")>
    Public Property Ask() As Decimal
        Get
            Return CType(GetProp("Ask"), Decimal)
        End Get
        Set
            AddHistory(_askHistory, Value)
            SetProp("Ask", Value)
        End Set
    End Property

    <Display(Name:="LastSale")>
    Public Property LastSale() As Decimal
        Get
            Return CType(GetProp("LastSale"), Decimal)
        End Get
        Set
            AddHistory(_saleHistory, Value)
            SetProp("LastSale", Value)
        End Set
    End Property

    <Display(Name:="BidSize")>
    Public Property BidSize() As Integer
        Get
            Return CType(GetProp("BidSize"), Integer)
        End Get
        Set
            SetProp("BidSize", Value)
        End Set
    End Property

    <Display(Name:="AskSize")>
    Public Property AskSize() As Integer
        Get
            Return CType(GetProp("AskSize"), Integer)
        End Get
        Set
            SetProp("AskSize", Value)
        End Set
    End Property

    <Display(Name:="LastSize")>
    Public Property LastSize() As Integer
        Get
            Return CType(GetProp("LastSize"), Integer)
        End Get
        Set
            SetProp("LastSize", Value)
        End Set
    End Property

    <Display(Name:="Volume")>
    Public Property Volume() As Integer
        Get
            Return CType(GetProp("Volume"), Integer)
        End Get
        Set
            SetProp("Volume", Value)
        End Set
    End Property

    <Display(Name:="QuoteTime")>
    Public Property QuoteTime() As DateTime
        Get
            Return CType(GetProp("QuoteTime"), DateTime)
        End Get
        Set
            SetProp("QuoteTime", Value)
        End Set
    End Property

    <Display(Name:="TradeTime")>
    Public Property TradeTime() As DateTime
        Get
            Return CType(GetProp("TradeTime"), DateTime)
        End Get
        Set
            SetProp("TradeTime", Value)
        End Set
    End Property
    Public Function GetHistory(propName As String) As List(Of Decimal)
        Select Case propName
            Case "Ask"
                Return _askHistory
            Case "Bid"
                Return _bidHistory
            Case "LastSale"
                Return _saleHistory
        End Select
        Return Nothing
    End Function
    Sub AddHistory(list As List(Of Decimal), value As Decimal)
        While list.Count >= HISTORY_SIZE
            list.RemoveAt(0)
        End While
        While list.Count < HISTORY_SIZE
            list.Add(value)
        End While
    End Sub

    Private _propBag As New Dictionary(Of String, Object)()
    Function GetProp(propName As String) As Object
        Dim value As Object = Nothing
        _propBag.TryGetValue(propName, value)
        Return value
    End Function
    Sub SetProp(propName As String, value As Object)
        If Not _propBag.ContainsKey(propName) OrElse Not GetProp(propName).Equals(value) Then
            _propBag(propName) = value
            OnPropertyChanged(New PropertyChangedEventArgs(propName))
        End If
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Overridable Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

    ' get a default list of financial items
    Public Shared Async Function GetFinancialData() As Task(Of FinancialDataList)
        Dim list As New FinancialDataList()
        Dim rnd As New Random(0)

        Dim resourceUri As Uri
        If GetType(FinancialData).GetTypeInfo().[Module].Name.EndsWith("exe") Then
            resourceUri = New Uri("ms-appx:///Resources/StockSymbols.txt")
        Else
            resourceUri = New Uri("ms-appx:///FlexGridSamplesLib/Resources/StockSymbols.txt")
        End If
        Dim file As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(resourceUri)
        Dim fileStream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.Read)

        Using sr As New StreamReader(fileStream.AsStream())
            While Not sr.EndOfStream
                Dim sn As String() = sr.ReadLine().Split(vbTab(0))
                If sn.Length > 1 AndAlso sn(0).Trim().Length > 0 Then
                    Dim data As New FinancialData()
                    data.Symbol = sn(0)
                    data.Name = sn(1)
                    data.Bid = rnd.[Next](1, 1000)
                    data.Ask = data.Bid + CType(rnd.NextDouble(), Decimal)
                    data.LastSale = data.Bid
                    data.BidSize = rnd.[Next](10, 500)
                    data.AskSize = rnd.[Next](10, 500)
                    data.LastSize = rnd.[Next](10, 500)
                    data.Volume = rnd.[Next](10000, 20000)
                    data.QuoteTime = DateTime.Now
                    data.TradeTime = DateTime.Now
                    list.Add(data)
                End If
            End While
        End Using
        list.AutoUpdate = True
        Return list
    End Function
End Class

Public Class FinancialDataList
    Inherits List(Of FinancialData)
    ' fields
    Private _timer As C1.Util.Timer
    Private _rnd As New Random(0)
    Private _updateInterval As Integer = 100
    Private _autoUpdate As Boolean = False

    ' object model
    Public Property UpdateInterval() As Integer
        Get
            Return _updateInterval
        End Get
        Set
            _updateInterval = Value
            UpdateTimer()
        End Set
    End Property
    Public Property BatchSize() As Integer
    Public Property AutoUpdate() As Boolean
        Get
            Return _autoUpdate
        End Get
        Set
            If _autoUpdate <> Value Then
                _autoUpdate = Value
                UpdateTimer()
            End If
        End Set
    End Property

    Private _temp As Int32 = 0
    ' ctor
    Public Sub New()
        BatchSize = 100
    End Sub

    Private Sub UpdateTimer()
        If (AutoUpdate) Then
            If (_timer Is Nothing) Then
                _timer = New C1.Util.Timer()
                AddHandler _timer.Tick, AddressOf _timer_Tick
            End If
            _timer.Interval = TimeSpan.FromMilliseconds(UpdateInterval)
            _timer.IsEnabled = True
        ElseIf (_timer IsNot Nothing) Then
            _timer.IsEnabled = False
            RemoveHandler _timer.Tick, AddressOf _timer_Tick
            _timer = Nothing
        End If
    End Sub

    Sub _timer_Tick(sender As Object, e As EventArgs)
        If Me.Count > 0 Then
            Dim i As Integer = 0
            While i < BatchSize
                Dim index As Integer = _rnd.[Next]() Mod Me.Count
                Dim data As FinancialData = Me(index)
                Dim ok As Boolean = False
                While Not ok
                    Try
                        data.Bid = data.Bid * CType((1 + (_rnd.NextDouble() * 0.11 - 0.05)), Decimal)
                        data.Ask = data.Ask * CType((1 + (_rnd.NextDouble() * 0.11 - 0.05)), Decimal)
                        ok = True
                    Catch
                    End Try
                End While
                data.BidSize = _rnd.[Next](10, 1000)
                data.AskSize = _rnd.[Next](10, 1000)
                Dim sale As Decimal = (data.Ask + data.Bid) / 2
                data.LastSale = sale
                data.LastSize = CType((data.AskSize + data.BidSize) / 2, Integer)
                data.QuoteTime = DateTime.Now
                data.TradeTime = DateTime.Now.AddSeconds(-_rnd.[Next](0, 60))
                i += 1
            End While
        End If
    End Sub
End Class