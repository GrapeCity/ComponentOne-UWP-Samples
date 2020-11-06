Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("InputSamplesLib/Resources")

    Public Shared ReadOnly Property Account_BankAccount() As String
        Get
            Return _loader.GetString("Account_BankAccount")
        End Get
    End Property

    Public Shared ReadOnly Property Account_Cash() As String
        Get
            Return _loader.GetString("Account_Cash")
        End Get
    End Property

    Public Shared ReadOnly Property Account_CreditCard() As String
        Get
            Return _loader.GetString("Account_CreditCard")
        End Get
    End Property

    Public Shared ReadOnly Property Account_OnlinePayment() As String
        Get
            Return _loader.GetString("Account_OnlinePayment")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ButtonDontSend() As String
        Get
            Return _loader.GetString("ButtonDontSend")
        End Get
    End Property

    Public Shared ReadOnly Property ButtonOK() As String
        Get
            Return _loader.GetString("ButtonOK")
        End Get
    End Property

    Public Shared ReadOnly Property ButtonSandAnyway() As String
        Get
            Return _loader.GetString("ButtonSandAnyway")
        End Get
    End Property

    Public Shared ReadOnly Property CheckListDescription() As String
        Get
            Return _loader.GetString("CheckListDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CheckListName() As String
        Get
            Return _loader.GetString("CheckListName")
        End Get
    End Property

    Public Shared ReadOnly Property CheckListTitle() As String
        Get
            Return _loader.GetString("CheckListTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EmptyToError() As String
        Get
            Return _loader.GetString("EmptyToError")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorTitle() As String
        Get
            Return _loader.GetString("ErrorTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Education() As String
        Get
            Return _loader.GetString("ExpenseType_Education")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Entertainment() As String
        Get
            Return _loader.GetString("ExpenseType_Entertainment")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Health() As String
        Get
            Return _loader.GetString("ExpenseType_Health")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Others() As String
        Get
            Return _loader.GetString("ExpenseType_Others")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Shopping() As String
        Get
            Return _loader.GetString("ExpenseType_Shopping")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Tax() As String
        Get
            Return _loader.GetString("ExpenseType_Tax")
        End Get
    End Property

    Public Shared ReadOnly Property ExpenseType_Traffic() As String
        Get
            Return _loader.GetString("ExpenseType_Traffic")
        End Get
    End Property

    Public Shared ReadOnly Property IncomeType_InvestmentReturn() As String
        Get
            Return _loader.GetString("IncomeType_InvestmentReturn")
        End Get
    End Property

    Public Shared ReadOnly Property IncomeType_Lottery() As String
        Get
            Return _loader.GetString("IncomeType_Lottery")
        End Get
    End Property

    Public Shared ReadOnly Property IncomeType_Others() As String
        Get
            Return _loader.GetString("IncomeType_Others")
        End Get
    End Property

    Public Shared ReadOnly Property IncomeType_Salary() As String
        Get
            Return _loader.GetString("IncomeType_Salary")
        End Get
    End Property

    Public Shared ReadOnly Property IncomeType_Stock() As String
        Get
            Return _loader.GetString("IncomeType_Stock")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property MultiSelectDescription() As String
        Get
            Return _loader.GetString("MultiSelectDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MultiSelectName() As String
        Get
            Return _loader.GetString("MultiSelectName")
        End Get
    End Property

    Public Shared ReadOnly Property MultiSelectTitle() As String
        Get
            Return _loader.GetString("MultiSelectTitle")
        End Get
    End Property

    Public Shared ReadOnly Property NoSubjectError() As String
        Get
            Return _loader.GetString("NoSubjectError")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property TagEditorDescription() As String
        Get
            Return _loader.GetString("TagEditorDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TagEditorName() As String
        Get
            Return _loader.GetString("TagEditorName")
        End Get
    End Property

    Public Shared ReadOnly Property TagEditorTitle() As String
        Get
            Return _loader.GetString("TagEditorTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ToastAnd() As String
        Get
            Return _loader.GetString("ToastAnd")
        End Get
    End Property

    Public Shared ReadOnly Property ToastJoinSeprator() As String
        Get
            Return _loader.GetString("ToastJoinSeprator")
        End Get
    End Property

    Public Shared ReadOnly Property ToastNamesFormat() As String
        Get
            Return _loader.GetString("ToastNamesFormat")
        End Get
    End Property

    Public Shared ReadOnly Property ToastPeopleEnd() As String
        Get
            Return _loader.GetString("ToastPeopleEnd")
        End Get
    End Property

    Public Shared ReadOnly Property ToastPeriod() As String
        Get
            Return _loader.GetString("ToastPeriod")
        End Get
    End Property

    Public Shared ReadOnly Property ToastSubjectFormat() As String
        Get
            Return _loader.GetString("ToastSubjectFormat")
        End Get
    End Property

    Public Shared ReadOnly Property ToastTitle() As String
        Get
            Return _loader.GetString("ToastTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ToolTipManager() As String
        Get
            Return _loader.GetString("ToolTipManager")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property
End Class