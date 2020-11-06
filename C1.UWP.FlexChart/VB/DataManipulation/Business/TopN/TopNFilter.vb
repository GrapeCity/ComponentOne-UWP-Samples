

Public Class TopNFilter
    Inherits FilterBase
    Private _topNEnabled As Boolean
    Private _topNCount As Integer
    Private _showOthers As Boolean

    Public Property TopNEnabled() As Boolean
        Get
            Return Me._topNEnabled
        End Get
        Set
            Me._topNEnabled = Value
            Analyse()
        End Set
    End Property
    Public Property TopNCount() As Integer
        Get
            Return Me._topNCount
        End Get
        Set
            Me._topNCount = Value
            Analyse()
        End Set
    End Property
    Public Property ShowOthers() As Boolean
        Get
            Return Me._showOthers
        End Get
        Set
            Me._showOthers = Value
            Analyse()
        End Set
    End Property

    Public Overrides Sub Analyse()
        Dim src As IEnumerable(Of Object) = TryCast(Me.Source, IEnumerable(Of Object))

        If src Is Nothing OrElse Bindings Is Nothing OrElse Bindings.Length = 0 Then
            Return
        End If
        If Not src.Any() Then
            Return
        End If

        If Me.TopNCount >= 1 Then
            Dim data As IEnumerable(Of KeyValuePair(Of Double, Object)) = From p In src Select New KeyValuePair(Of Double, Object)(GetValues(p, Bindings).Aggregate(AggregateType), p)

            Dim sortedTopNData As IEnumerable(Of Object) = data.Sort(Me.SortType).Take(Me.TopNCount).GetValue()

            Dim source As New Queue(Of Object)()
            Dim sourceOthers As New Queue(Of Object)()
            For Each obj As Object In src
                If sortedTopNData.Contains(obj) Then
                    source.Enqueue(obj)
                Else
                    If ShowOthers Then
                        sourceOthers.Enqueue(obj)
                    End If
                End If
            Next

            If SortOrder Then
                source = New Queue(Of Object)(sortedTopNData)
            End If

            If ShowOthers Then
                Dim srcItem = src.First()
                Dim others = Activator.CreateInstance(srcItem.[GetType]())

                SetValue(others, "Name", "Others")

                For Each binding As String In Bindings
                    Dim ptValues As New Queue(Of Double)()
                    For Each item As Object In sourceOthers
                        ptValues.Enqueue(GetValue(item, binding))
                    Next
                    SetValue(others, binding, ptValues.Aggregate(AggregateType.Sum))
                Next
                source.Enqueue(others)
            End If
            Me.DataSource = source.ToArray()
        Else
            Me.DataSource = Me.Source
        End If

        Me.OnPropertyChanged("DataSource")
    End Sub
End Class