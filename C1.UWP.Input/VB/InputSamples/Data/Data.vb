Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Entity
    Public Property Name() As String
    Public Property Latitude() As Double
    Public Property Longitude() As Double
    Public ReadOnly Property Position() As Point
        Get
            Return New Point(Longitude, Latitude)
        End Get
    End Property
End Class

Public Class Office
    Inherits Entity
    Public Property Manager() As String
    Public Property Stores() As Integer

    Public ReadOnly Property ToolTip() As String
        Get
            Dim _tooltip As String = Name + vbCrLf + Strings.ToolTipManager + Manager
            Return _tooltip
        End Get
    End Property
End Class

Public Class Factory
    Inherits Entity
    Public Property Capacity() As Double
End Class

Public Class DistributionData
    Public Property Factories() As List(Of Factory)
    Public Property Offices() As List(Of Office)
End Class

Public Enum AccountType
    Cash
    CreditCard
    BankAccount
    OnlinePayment
End Enum

Public Enum IncomeType
    Salary
    Stock
    Investment
    Lottery
    Others
End Enum

Public Enum ExpenseType
    Tax
    Traffic
    Shopping
    Entertainment
    Education
    Health
    Others
End Enum

Public Class FinnanceItem
    Public Property Name() As String
    Public Property Comment() As String
    Public Property Cost() As Double
    Public Property AccountId() As Integer
    Public Property TypeId() As Integer
    Public ReadOnly Property AccountType() As AccountType
        Get
            Return CType(AccountId, AccountType)
        End Get
    End Property
End Class

Public Class Income
    Inherits FinnanceItem
    Public ReadOnly Property Type() As IncomeType
        Get
            Return CType(TypeId, IncomeType)
        End Get
    End Property
End Class

Public Class Expense
    Inherits FinnanceItem
    Public ReadOnly Property Type() As ExpenseType
        Get
            Return CType(TypeId, ExpenseType)
        End Get
    End Property
End Class

Public Class FinnanceData
    Public Property Incomes() As List(Of Income)
    Public Property Expenses() As List(Of Expense)
End Class

Public Class Mail
    Public Property Name() As String
    Public Property Address() As String
End Class

Public Class AddressBook
    Public Property Mails() As List(Of Mail)
End Class