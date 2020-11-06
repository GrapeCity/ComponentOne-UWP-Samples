Imports System

Public Class DataItem
    Private _items As List(Of DataItem)

    Public Property Year() As String
        Get
            Return m_Year
        End Get
        Set
            m_Year = Value
        End Set
    End Property
    Private m_Year As String
    Public Property Quarter() As String
        Get
            Return m_Quarter
        End Get
        Set
            m_Quarter = Value
        End Set
    End Property
    Private m_Quarter As String
    Public Property Month() As String
        Get
            Return m_Month
        End Get
        Set
            m_Month = Value
        End Set
    End Property
    Private m_Month As String
    Public Property Value() As Double
        Get
            Return m_Value
        End Get
        Set
            m_Value = Value
        End Set
    End Property
    Private m_Value As Double
    Public ReadOnly Property Items() As List(Of DataItem)
        Get
            If _items Is Nothing Then
                _items = New List(Of DataItem)()
            End If

            Return _items
        End Get
    End Property
End Class

Public Class Item
    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set
            m_ID = Value
        End Set
    End Property
    Private m_ID As Integer
    Public Property Country() As String
        Get
            Return m_Country
        End Get
        Set
            m_Country = Value
        End Set
    End Property
    Private m_Country As String
    Public Property City() As String
        Get
            Return m_City
        End Get
        Set
            m_City = Value
        End Set
    End Property
    Private m_City As String
    Public Property Amount() As Double
        Get
            Return m_Amount
        End Get
        Set
            m_Amount = Value
        End Set
    End Property
    Private m_Amount As Double
    Public Property Year() As String
        Get
            Return m_Year
        End Get
        Set
            m_Year = Value
        End Set
    End Property
    Private m_Year As String
    Public Property Month() As String
        Get
            Return m_Month
        End Get
        Set
            m_Month = Value
        End Set
    End Property
    Private m_Month As String
    Public Property Day() As String
        Get
            Return m_Day
        End Get
        Set
            m_Day = Value
        End Set
    End Property
    Private m_Day As String
End Class

Public Class Leaf
    Public Property Type() As String
        Get
            Return m_Type
        End Get
        Set
            m_Type = Value
        End Set
    End Property
    Private m_Type As String
    Public Property Items() As Leaf()
        Get
            Return m_Items
        End Get
        Set
            m_Items = Value
        End Set
    End Property
    Private m_Items As Leaf()
    Public Property Sales() As Integer
        Get
            Return m_Sales
        End Get
        Set
            m_Sales = Value
        End Set
    End Property
    Private m_Sales As Integer
End Class