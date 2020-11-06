Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView()

    Public Shared ReadOnly Property InitializedPageError() As String
        Get
            Return _loader.GetString("InitializedPageError")
        End Get
    End Property

    Public Shared ReadOnly Property SignDollar() As String
        Get
            Return _loader.GetString("SignDollar")
        End Get
    End Property

    Public Shared ReadOnly Property Percent() As String
        Get
            Return _loader.GetString("Percent")
        End Get
    End Property

    Public Shared ReadOnly Property Desktop() As String
        Get
            Return _loader.GetString("Desktop")
        End Get
    End Property

    Public Shared ReadOnly Property Mobile() As String
        Get
            Return _loader.GetString("Mobile")
        End Get
    End Property

    Public Shared ReadOnly Property Other() As String
        Get
            Return _loader.GetString("Other")
        End Get
    End Property

    Public Shared ReadOnly Property Q1() As String
        Get
            Return _loader.GetString("Q1")
        End Get
    End Property

    Public Shared ReadOnly Property Q2() As String
        Get
            Return _loader.GetString("Q2")
        End Get
    End Property

    Public Shared ReadOnly Property Q3() As String
        Get
            Return _loader.GetString("Q3")
        End Get
    End Property

    Public Shared ReadOnly Property Q4() As String
        Get
            Return _loader.GetString("Q4")
        End Get
    End Property

    Public Shared ReadOnly Property Partner1() As String
        Get
            Return _loader.GetString("Partner1")
        End Get
    End Property

    Public Shared ReadOnly Property Partner2() As String
        Get
            Return _loader.GetString("Partner2")
        End Get
    End Property

    Public Shared ReadOnly Property Partner3() As String
        Get
            Return _loader.GetString("Partner3")
        End Get
    End Property

    Public Shared ReadOnly Property Partner4() As String
        Get
            Return _loader.GetString("Partner4")
        End Get
    End Property

    Public Shared ReadOnly Property Partner5() As String
        Get
            Return _loader.GetString("Partner5")
        End Get
    End Property

    Public Shared ReadOnly Property Partner6() As String
        Get
            Return _loader.GetString("Partner6")
        End Get
    End Property

    Public Shared ReadOnly Property USA() As String
        Get
            Return _loader.GetString("USA")
        End Get
    End Property

    Public Shared ReadOnly Property Russia() As String
        Get
            Return _loader.GetString("Russia")
        End Get
    End Property

    Public Shared ReadOnly Property China() As String
        Get
            Return _loader.GetString("China")
        End Get
    End Property

    Public Shared ReadOnly Property Spain() As String
        Get
            Return _loader.GetString("Spain")
        End Get
    End Property

    Public Shared ReadOnly Property Japan() As String
        Get
            Return _loader.GetString("Japan")
        End Get
    End Property

    Public Shared ReadOnly Property Brazil() As String
        Get
            Return _loader.GetString("Brazil")
        End Get
    End Property

    Public Shared ReadOnly Property Uruguay() As String
        Get
            Return _loader.GetString("Uruguay")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Category_Text() As String
        Get
            Return _loader.GetString("Category_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Partner_Text() As String
        Get
            Return _loader.GetString("Partner_Text")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneCategory_Header() As String
        Get
            Return _loader.GetString("PhoneCategory_Header")
        End Get
    End Property

    Public Shared ReadOnly Property PhonePartner_Header() As String
        Get
            Return _loader.GetString("PhonePartner_Header")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneQuarterly_Header() As String
        Get
            Return _loader.GetString("PhoneQuarterly_Header")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneRegion_Header() As String
        Get
            Return _loader.GetString("PhoneRegion_Header")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneTotal_Header() As String
        Get
            Return _loader.GetString("PhoneTotal_Header")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneType_Header() As String
        Get
            Return _loader.GetString("PhoneType_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Quarterly_Text() As String
        Get
            Return _loader.GetString("Quarterly_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Region_Text() As String
        Get
            Return _loader.GetString("Region_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RunTotalOne_Text() As String
        Get
            Return _loader.GetString("RunTotalOne_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RunTotalThree_Text() As String
        Get
            Return _loader.GetString("RunTotalThree_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RunTotalTwo_Text() As String
        Get
            Return _loader.GetString("RunTotalTwo_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TitleFive_Text() As String
        Get
            Return _loader.GetString("TitleFive_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TitleFour_Text() As String
        Get
            Return _loader.GetString("TitleFour_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TitleOne_Text() As String
        Get
            Return _loader.GetString("TitleOne_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TitleThree_Text() As String
        Get
            Return _loader.GetString("TitleThree_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TitleTwo_Text() As String
        Get
            Return _loader.GetString("TitleTwo_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Total_Text() As String
        Get
            Return _loader.GetString("Total_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Type_Text() As String
        Get
            Return _loader.GetString("Type_Text")
        End Get
    End Property
End Class