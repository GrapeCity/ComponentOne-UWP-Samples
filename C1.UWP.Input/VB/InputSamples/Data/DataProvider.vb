Imports System.Xml.Serialization
Imports System.Threading.Tasks
Imports System.Text
Imports System.Reflection
Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Input
Imports C1.Xaml

Public Class DataProvider
    Private incomeCollection As C1CollectionView
    Private expenseCollection As C1CollectionView

    Private _distributionData As DistributionData
    Private finnanceData As FinnanceData
    Private addressBook As AddressBook

    Shared provider As DataProvider

    Public Property FilterFamilyMembers() As List(Of String)
    Public Property FilterAccountTypes() As List(Of AccountType)
    Public Property FilterIncomeTypes() As List(Of IncomeType)
    Public Property FilterExpenseTypes() As List(Of ExpenseType)

    Public ReadOnly Property DistributionData() As DistributionData
        Get
            Return _distributionData
        End Get
    End Property

    Public ReadOnly Property Incomes() As C1CollectionView
        Get
            Return incomeCollection
        End Get
    End Property
    Public ReadOnly Property Expenses() As C1CollectionView
        Get
            Return expenseCollection
        End Get
    End Property

    Public ReadOnly Property AccountTypes() As Dictionary(Of String, AccountType)
        Get
            Dim dictionary As New Dictionary(Of String, AccountType)()
            dictionary(Strings.Account_Cash) = AccountType.Cash
            dictionary(Strings.Account_CreditCard) = AccountType.CreditCard
            dictionary(Strings.Account_BankAccount) = AccountType.BankAccount
            dictionary(Strings.Account_OnlinePayment) = AccountType.OnlinePayment
            Return dictionary
        End Get
    End Property
    Public ReadOnly Property IncomeTypes() As Dictionary(Of String, IncomeType)
        Get
            Dim dictionary As New Dictionary(Of String, IncomeType)()
            dictionary(Strings.IncomeType_Salary) = IncomeType.Salary
            dictionary(Strings.IncomeType_Stock) = IncomeType.Stock
            dictionary(Strings.IncomeType_InvestmentReturn) = IncomeType.Investment
            dictionary(Strings.IncomeType_Lottery) = IncomeType.Lottery
            dictionary(Strings.IncomeType_Others) = IncomeType.Others
            Return dictionary
        End Get
    End Property
    Public ReadOnly Property ExpenseTypes() As Dictionary(Of String, ExpenseType)
        Get
            Dim dictionary As New Dictionary(Of String, ExpenseType)()
            dictionary(Strings.ExpenseType_Tax) = ExpenseType.Tax
            dictionary(Strings.ExpenseType_Traffic) = ExpenseType.Traffic
            dictionary(Strings.ExpenseType_Shopping) = ExpenseType.Shopping
            dictionary(Strings.ExpenseType_Entertainment) = ExpenseType.Entertainment
            dictionary(Strings.ExpenseType_Education) = ExpenseType.Education
            dictionary(Strings.ExpenseType_Health) = ExpenseType.Health
            dictionary(Strings.ExpenseType_Others) = ExpenseType.Others
            Return dictionary
        End Get
    End Property

    Public ReadOnly Property FamilyMembers() As List(Of String)
        Get
            Dim list As New List(Of String)()
            list.Add("Richard")
            list.Add("Violet")
            list.Add("Olivia")
            list.Add("Lucas")
            Return list
        End Get
    End Property

    Public ReadOnly Property MailList() As List(Of Mail)
        Get
            Return addressBook.Mails
        End Get
    End Property
    Shared Sub New()
    End Sub

    Public Shared Function GetProvider() As DataProvider
        If provider Is Nothing Then
            provider = New DataProvider()
        End If
        Return provider
    End Function

    Public Sub InstallData()
        Dim assembly As Assembly = Assembly.Load(New AssemblyName("InputSamplesLib"))
        Dim mapDataStream As Stream = assembly.GetManifestResourceStream("InputSamples.MapData.xml")
        _distributionData = CType(New XmlSerializer(GetType(DistributionData)).Deserialize(mapDataStream), DistributionData)
        Dim finnanceDataStream As Stream = assembly.GetManifestResourceStream("InputSamples.FinanceData.xml")
        finnanceData = CType(New XmlSerializer(GetType(FinnanceData)).Deserialize(finnanceDataStream), FinnanceData)
        Dim incomesCollcetion As New ObservableCollection(Of Income)(finnanceData.Incomes)
        Dim mailDataStream As Stream = assembly.GetManifestResourceStream("InputSamples.MailData.xml")
        addressBook = CType(New XmlSerializer(GetType(AddressBook)).Deserialize(mailDataStream), AddressBook)
        incomeCollection = New C1CollectionView(finnanceData.Incomes)
        incomeCollection.GroupDescriptions.Add(New PropertyGroupDescription("Name"))
        incomeCollection.GroupDescriptions.Add(New PropertyGroupDescription("AccountType"))
        incomeCollection.GroupDescriptions.Add(New PropertyGroupDescription("Type"))
        expenseCollection = New C1CollectionView(finnanceData.Expenses)
        expenseCollection.GroupDescriptions.Add(New PropertyGroupDescription("Name"))
        expenseCollection.GroupDescriptions.Add(New PropertyGroupDescription("AccountType"))
        expenseCollection.GroupDescriptions.Add(New PropertyGroupDescription("Type"))
        FilterFamilyMembers = New List(Of String)()
        FilterAccountTypes = New List(Of AccountType)()
        FilterIncomeTypes = New List(Of IncomeType)()
        FilterExpenseTypes = New List(Of ExpenseType)()
        incomeCollection.Filter = New Predicate(Of Object)(AddressOf FilterCompatibleIncomeItems)
        expenseCollection.Filter = New Predicate(Of Object)(AddressOf FilterCompatibleExpenseItems)
    End Sub

    Private Function FilterCompatibleIncomeItems(incomeItem As Object) As Boolean
        Dim current As Income = TryCast(incomeItem, Income)
        If current Is Nothing Then
            Return False
        End If
        Dim result As Boolean = FilterFamilyMembers.Contains(current.Name) AndAlso FilterAccountTypes.Contains(current.AccountType) AndAlso FilterIncomeTypes.Contains(current.Type)
        Return result
    End Function
    Private Function FilterCompatibleExpenseItems(expenseItem As Object) As Boolean
        Dim current As Expense = TryCast(expenseItem, Expense)
        If current Is Nothing Then
            Return False
        End If
        Dim result As Boolean = FilterFamilyMembers.Contains(current.Name) AndAlso FilterAccountTypes.Contains(current.AccountType) AndAlso FilterExpenseTypes.Contains(current.Type)
        Return result
    End Function

    Public Sub UpdateData(Of T)(addItems As List(Of T), removeItems As List(Of T), source As List(Of T), filterType As DataFilterType)
        For Each item As T In addItems
            If Not source.Contains(item) Then
                source.Add(item)
            End If
        Next
        For Each item As T In removeItems
            If source.Contains(item) Then
                source.Remove(item)
            End If
        Next
        If filterType <> DataFilterType.Income Then
            expenseCollection.Filter = Nothing
            expenseCollection.Filter = New Predicate(Of Object)(AddressOf FilterCompatibleExpenseItems)
        End If
        If filterType <> DataFilterType.Expense Then
            incomeCollection.Filter = Nothing
            incomeCollection.Filter = New Predicate(Of Object)(AddressOf FilterCompatibleIncomeItems)
        End If
    End Sub
End Class

Public Enum DataFilterType
    Name
    Account
    Income
    Expense
End Enum