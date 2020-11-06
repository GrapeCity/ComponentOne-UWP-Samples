Imports System.Text

Class DataService
    Shared _names As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Shared _prices As New Dictionary(Of String, QuoteData)(StringComparer.OrdinalIgnoreCase)

    Shared Sub New()
    End Sub


    Private Sub New()
    End Sub

    Private Shared _instance As DataService
    Public Shared ReadOnly Property Instance() As DataService
        Get
            If _instance Is Nothing Then
                _instance = New DataService()
            End If
            Return _instance
        End Get
    End Property

    Public ReadOnly Property SymbolNames() As Dictionary(Of String, String)
        Get
            ' load company names (once)
            If _names.Count = 0 Then
                For Each line As String In DataPort.SymbolNames
                    If line IsNot Nothing Then
                        Dim parts = line.Split(vbTab)
                        If parts.Length >= 2 Then
                            Dim key = parts(0).Trim()
                            Dim value = parts(1).Trim()
                            If key.Length > 0 AndAlso value.Length > 0 Then
                                _names(key) = value
                            End If
                        End If
                    End If
                Next
            End If
            Return _names
        End Get
    End Property

    Public Function GetSymbolName(symbol As String) As String
        Dim value As String = Nothing
        If _names IsNot Nothing Then
            If _names.TryGetValue(symbol, value) Then
                Return (value & Convert.ToString("(")) + symbol.ToUpper() + ")"
            End If
        End If
        Return value
    End Function

    Public Function GetSymbolData(symbol As String, Optional onWebError As Action(Of String) = Nothing) As QuoteData
        ' try getting from cache
        Dim quoteCache As QuoteData
        If _prices.TryGetValue(symbol, quoteCache) Then
            Return quoteCache
        End If
        Dim quoteData As New QuoteData()

        ' not in cache, get now
        Dim t = DateTime.Today
        Dim startDate = New DateTime(t.Year - 10, 1, 1)
        Dim fmt = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={0}&apikey=IF6RVQ6S90CZZ7VJ&datatype=csv&outputsize=full"
        Dim url = String.Format(fmt, symbol)

        ' get content
        Dim sb = New StringBuilder()
        Dim request = System.Net.WebRequest.Create(url)

        Dim task = request.GetResponseAsync()
        'where it's exiting
        Try
            Using sr = New StreamReader(task.Result.GetResponseStream())
                ' skip headers
                sr.ReadLine()

                ' read each line
                Dim line = sr.ReadLine()
                While line IsNot Nothing
                    ' append date (field 0) and adjusted close price (field 6)
                    Dim items = line.Split(","c)

                    Dim q As New Quote(quoteData.ReferenceValue) With {
                       .[date] = DateTime.Parse(items(0)),
                       .open = Convert.ToDouble(items(1)),
                       .high = Convert.ToDouble(items(2)),
                       .low = Convert.ToDouble(items(3)),
                       .close = Convert.ToDouble(items(4)),
                       .volume = Convert.ToDouble(items(5))
                    }
                    If q.date < startDate Then Exit While
                        quoteData.Add(q)

                    line = sr.ReadLine()
                End While
            End Using
        Catch ex As AggregateException
            If onWebError IsNot Nothing Then
                onWebError(ex.Message)
            Else
                System.Diagnostics.Debug.WriteLine(ex.Message)
            End If
        Catch ex As System.Net.WebException
            If onWebError IsNot Nothing Then
                onWebError(ex.Message)
            Else
                System.Diagnostics.Debug.WriteLine(ex.Message)
            End If
        End Try

        FillEvents(symbol, quoteData)

        quoteData.Reverse()
        _prices(symbol) = quoteData

        Return quoteData
    End Function

    Public Async Sub GetSymbolDataAsync(symbol As String, onCallback As Action(Of QuoteData), Optional onWebError As Action(Of String) = Nothing)
        Await Windows.System.Threading.ThreadPool.RunAsync(Sub(workItem As Object)
                                                               Dim data = GetSymbolData(symbol, onWebError)
                                                               onCallback(data)
                                                           End Sub
                                                           )
    End Sub



    Private Sub FillEvents(symbol As String, qs As IEnumerable(Of Quote))
        ' not in cache, get now
        Dim fmt = "http://articlefeeds.nasdaq.com/nasdaq/symbols?symbol={0}"
        Dim url = String.Format(fmt, symbol)

        ' get content
        Dim sb = New StringBuilder()

        Try
            Dim request = System.Net.WebRequest.Create(url)

            Dim task = request.GetResponseAsync()
            'where it's exiting
            Using stream = task.Result.GetResponseStream()
                Dim doc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
                doc.Load(stream)
                Dim items = doc.GetElementsByTagName("item")
                For Each item As System.Xml.XmlNode In items
                    Dim dt = DateTime.Parse(item("pubDate").InnerText)
                    Dim text = item("title").InnerText
                    Dim quote = qs.FirstOrDefault(Function(q) (q.date - dt).Days = 0)
                    If quote IsNot Nothing Then
                        If quote.events IsNot Nothing Then
                            If quote.events.Length > 0 Then
                                quote.events += Environment.NewLine
                            End If

                            quote.events += text
                        Else
                            quote.events = text
                        End If
                    End If
                Next
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try

    End Sub

    Public Function GetSymbolYRange(quoteData As IEnumerable(Of Quote), s As Double, e As Double, Optional porperty As String = Nothing) As QuoteRange
        Dim qr As QuoteRange = Nothing
        Dim ds As DateTime = Utilities.FromOADate(s)
        Dim de As DateTime = Utilities.FromOADate(e)
        Dim quoteCache As IEnumerable(Of Quote) = From p In quoteData Where p.[date] >= ds AndAlso p.[date] <= de Select p

        If quoteCache.Any() Then
            qr = New QuoteRange()
            qr.PriceMin = quoteCache.Min(Function(k)
                                             If String.IsNullOrEmpty(porperty) OrElse porperty.ToUpper() = "high,low,open,close".ToUpper() Then
                                                 Return k.low
                                             Else
                                                 Return k.GetValue(porperty)
                                             End If

                                         End Function)
            qr.PriceMax = quoteCache.Max(Function(k)
                                             If String.IsNullOrEmpty(porperty) OrElse porperty.ToUpper() = "high,low,open,close".ToUpper() Then
                                                 Return k.high
                                             Else
                                                 Return k.GetValue(porperty)
                                             End If

                                         End Function)
            qr.VolumeMin = quoteCache.Min(Function(k) k.volume)
            qr.VolumeMax = quoteCache.Max(Function(k) k.volume)
        End If
        Return qr
    End Function
End Class