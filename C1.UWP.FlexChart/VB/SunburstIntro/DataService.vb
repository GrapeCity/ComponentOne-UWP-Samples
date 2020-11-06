Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Xaml
Imports System.Collections

Public Class DataService
    Private rnd As New Random()
    Shared _default As DataService

    Public Shared ReadOnly Property Instance() As DataService
        Get
            If _default Is Nothing Then
                _default = New DataService()
            End If

            Return _default
        End Get
    End Property

    Public Shared Function CreateHierarchicalData() As List(Of DataItem)
        Dim rnd As Random = Instance.rnd

        Dim years As New List(Of String)()
        Dim times As New List(Of List(Of String))() From {
            New List(Of String)() From {"Jan", "Feb", "Mar"},
            New List(Of String)() From {"Apr", "May", "June"},
            New List(Of String)() From {"Jul", "Aug", "Sep"},
            New List(Of String)() From {"Oct", "Nov", "Dec"}
            }

        Dim items As New List(Of DataItem)()
        Dim yearLen As Integer = Math.Max(CType(Math.Round(Math.Abs(5 - Instance.rnd.NextDouble() * 10)), Integer), 3)
        Dim currentYear As Integer = DateTime.Now.Year
        Dim j As Integer = yearLen
        While j > 0
            years.Add((currentYear - j).ToString())
            j -= 1
        End While
        Dim quarterAdded As Boolean = False

        years.ForEach(Sub(y)
                          Dim i As Object = years.IndexOf(y)
                          Dim addQuarter As Boolean = Instance.rnd.NextDouble() > 0.5
                          If Not quarterAdded AndAlso i = years.Count - 1 Then
                              addQuarter = True
                          End If
                          Dim year As New DataItem() With {
                              .Year = y
                          }
                          If addQuarter Then
                              quarterAdded = True
                              times.ForEach(Sub(q)
                                                Dim addMonth As Boolean = Instance.rnd.NextDouble() > 0.5
                                                Dim idx As Integer = times.IndexOf(q)
                                                Dim quar As String = "Q" + (idx + 1).ToString()
                                                Dim quarters As New DataItem() With {
                                                    .Year = y,
                                                    .Quarter = quar
                                                }
                                                If addMonth Then
                                                    q.ForEach(Sub(m)
                                                                  quarters.Items.Add(New DataItem() With {
                                                                      .Year = y,
                                                                      .Quarter = quar,
                                                                      .Month = m,
                                                                      .Value = rnd.[Next](20, 30)
                                                                  })

                                                              End Sub)
                                                Else
                                                    quarters.Value = rnd.[Next](80, 100)
                                                End If
                                                year.Items.Add(quarters)

                                            End Sub)
                          Else
                              year.Value = rnd.[Next](80, 100)
                          End If
                          items.Add(year)

                      End Sub)

        Return items
    End Function

    Public Shared Function CreateFlatData() As List(Of FlatDataItem)
        Dim rnd As Random = Instance.rnd
        Dim years As New List(Of String)()
        Dim times As New List(Of List(Of String))() From {
            New List(Of String)() From {"Jan", "Feb", "Mar"},
            New List(Of String)() From {"Apr", "May", "June"},
            New List(Of String)() From {"Jul", "Aug", "Sep"},
            New List(Of String)() From {"Oct", "Nov", "Dec"}
            }

        Dim items As New List(Of FlatDataItem)()
        Dim yearLen As Integer = Math.Max(CType(Math.Round(Math.Abs(5 - rnd.NextDouble() * 10)), Integer), 3)
        Dim currentYear As Integer = DateTime.Now.Year
        Dim j As Integer = yearLen
        While j > 0
            years.Add((currentYear - j).ToString())
            j -= 1
        End While
        Dim quarterAdded As Boolean = False
        years.ForEach(Sub(y)
                          Dim i As Object = years.IndexOf(y)
                          Dim addQuarter As Boolean = rnd.NextDouble() > 0.5
                          If Not quarterAdded AndAlso i = years.Count - 1 Then
                              addQuarter = True
                          End If
                          If addQuarter Then
                              quarterAdded = True
                              times.ForEach(Sub(q)
                                                Dim addMonth As Boolean = rnd.NextDouble() > 0.5
                                                Dim idx As Integer = times.IndexOf(q)
                                                Dim quar As String = "Q" + (idx + 1).ToString()
                                                If addMonth Then
                                                    q.ForEach(Sub(m)
                                                                  items.Add(New FlatDataItem() With {
                                                                      .Year = y,
                                                                      .Quarter = quar,
                                                                      .Month = m,
                                                                      .Value = rnd.[Next](30, 40)
                                                                  })

                                                              End Sub)
                                                Else
                                                    items.Add(New FlatDataItem() With {
                                                        .Year = y,
                                                        .Quarter = quar,
                                                        .Value = rnd.[Next](80, 100)
                                                    })
                                                End If

                                            End Sub)
                          Else
                              items.Add(New FlatDataItem() With {
                                  .Year = y.ToString(),
                                  .Value = rnd.[Next](80, 100)
                              })
                          End If

                      End Sub)

        Return items
    End Function

    Public Shared Function CreateGroupCVData() As ICollectionView
        Dim data As List(Of Item) = New List(Of Item)()
        Dim quarters As String() = New String() {"Q1", "Q2", "Q3", "Q4"}
        Dim months = {
        New With {
            .Name = "Jan",
            .Value = 1
        },
        New With {
            .Name = "Feb",
            .Value = 2
        },
        New With {
            .Name = "Mar",
            .Value = 3
        },
        New With {
            .Name = "Apr",
            .Value = 4
        },
        New With {
            .Name = "May",
            .Value = 5
        },
        New With {
            .Name = "June",
            .Value = 6
        },
        New With {
        .Name = "Jul",
            .Value = 7
        },
        New With {
        .Name = "Aug",
        .Value = 8
        },
        New With {
        .Name = "Sep",
        .Value = 9
        },
        New With {
        .Name = "Oct",
        .Value = 10
        },
        New With {
        .Name = "Nov",
        .Value = 11
        },
        New With {
        .Name = "Dec",
        .Value = 12
        }}
        Dim year As Integer = DateTime.Now.Year
        Dim yearLen As Integer, i As Integer, len As Integer = 100
        Dim years As List(Of Integer) = New List(Of Integer)()
        yearLen = 3

        i = yearLen
        While i > 0
            years.Add(year - i)
            i -= 1
        End While

        Dim y As Integer, q As Integer, m As Integer
        i = 0
        While i < len
            y = CType(Math.Floor(Instance.rnd.NextDouble() * yearLen), Integer)
            q = CType(Math.Floor(Instance.rnd.NextDouble() * 4), Integer)
            m = CType(Math.Floor(Instance.rnd.NextDouble() * 3), Integer)

            data.Add(New Item() With {
                .Year = years(y),
                .Quarter = quarters(q),
                .MonthName = months(q).Name,
                .MonthValue = months(q).Value,
                .Value = Math.Round(Instance.rnd.NextDouble() * 100)
            })
            i += 1
        End While
        Dim cv As C1CollectionView = New C1CollectionView()
        cv.SourceCollection = data
        cv.SortDescriptions.Add(New SortDescription("Year", ListSortDirection.Ascending))
        cv.SortDescriptions.Add(New SortDescription("Quarter", ListSortDirection.Ascending))
        cv.SortDescriptions.Add(New SortDescription("MonthVal", ListSortDirection.Ascending))
        cv.GroupDescriptions.Add(New PropertyGroupDescription("Year"))
        cv.GroupDescriptions.Add(New PropertyGroupDescription("Quarter"))
        cv.GroupDescriptions.Add(New PropertyGroupDescription("MonthName"))
        Return cv
    End Function

End Class