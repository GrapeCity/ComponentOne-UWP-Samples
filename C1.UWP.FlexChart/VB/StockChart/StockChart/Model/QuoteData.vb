Public Class QuoteData
    Inherits List(Of Quote)
    Private _referenceValue As New Reference()
    Friend ReadOnly Property ReferenceValue() As Reference
        Get
            Return _referenceValue
        End Get
    End Property
End Class