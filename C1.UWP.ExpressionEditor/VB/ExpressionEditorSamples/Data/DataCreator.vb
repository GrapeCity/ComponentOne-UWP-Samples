Imports System.Collections.Generic

Public Class DataCreator
		Shared _datas As List(Of DataItem)

		Public Shared Function CreateData() As List(Of DataItem)
			If _datas Is Nothing Then
				_datas = New List(Of DataItem)()
				_datas.Add(New DataItem("UK", 5, 4))
				_datas.Add(New DataItem("USA", 7, 3))
				_datas.Add(New DataItem("Germany", 8, 5))
				_datas.Add(New DataItem("Japan", 12, 8))
			End If
			Return _datas
		End Function
End Class

Public Class DataItem
    Public Sub New()
    End Sub

    Public Sub New(_country As String, _sales As Integer, _expenses As Integer)
        Country = _country
        Sales = _sales
        Expenses = _expenses
    End Sub

    Public Property Country() As String
    Public Property Sales() As Integer
    Public Property Expenses() As Integer
End Class