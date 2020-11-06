Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("ExpressionEditorSamplesLib/Resources")


    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
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

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property Typexlsx() As String
        Get
            Return _loader.GetString("Typexlsx")
        End Get
    End Property

    Public Shared ReadOnly Property Typecsv() As String
        Get
            Return _loader.GetString("Typecsv")
        End Get
    End Property

    Public Shared ReadOnly Property DefaultFileName() As String
        Get
            Return _loader.GetString("DefaultFileName")
        End Get
    End Property

    Public Shared ReadOnly Property SaveLocationTip() As String
        Get
            Return _loader.GetString("SaveLocationTip")
        End Get
    End Property

    Public Shared ReadOnly Property SaveAndOpenException() As String
        Get
            Return _loader.GetString("SaveAndOpenException")
        End Get
    End Property

    Public Shared ReadOnly Property SheetName() As String
        Get
            Return _loader.GetString("SheetName")
        End Get
    End Property

    Public Shared ReadOnly Property DataCreatedTip() As String
        Get
            Return _loader.GetString("DataCreatedTip")
        End Get
    End Property

    Public Shared ReadOnly Property OpenTip() As String
        Get
            Return _loader.GetString("OpenTip")
        End Get
    End Property

    Public Shared ReadOnly Property ExpressionEditorSamplesTitle() As String
        Get
            Return _loader.GetString("ExpressionEditorSamplesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ExpressionEditorSamplesDescription() As String
        Get
            Return _loader.GetString("ExpressionEditorSamplesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ExpressionEditorSamplesName() As String
        Get
            Return _loader.GetString("ExpressionEditorSamplesName")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property C1Excel_Text() As String
        Get
            Return _loader.GetString("C1Excel_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ContentTB_Text() As String
        Get
            Return _loader.GetString("ContentTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property CreateButton_Content() As String
        Get
            Return _loader.GetString("CreateButton_Content")
        End Get
    End Property

    Public Shared ReadOnly Property OpenButton_Content() As String
        Get
            Return _loader.GetString("OpenButton_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SaveButton_Content() As String
        Get
            Return _loader.GetString("SaveButton_Content")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridColumnCalculationTitle() As String
        Get
            Return _loader.GetString("IntegrationGridColumnCalculationTitle")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridColumnCalculationDescription() As String
        Get
            Return _loader.GetString("IntegrationGridColumnCalculationDescription")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridColumnCalculationName() As String
        Get
            Return _loader.GetString("IntegrationGridColumnCalculationName")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridSupportGroupingTitle() As String
        Get
            Return _loader.GetString("IntegrationGridSupportGroupingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridSupportGroupingDescription() As String
        Get
            Return _loader.GetString("IntegrationGridSupportGroupingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridSupportGroupingName() As String
        Get
            Return _loader.GetString("IntegrationGridSupportGroupingName")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridSupportFilterTitle() As String
        Get
            Return _loader.GetString("IntegrationGridSupportFilterTitle")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridSupportFilterDescription() As String
        Get
            Return _loader.GetString("IntegrationGridSupportFilterDescription")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrationGridSupportFilterName() As String
        Get
            Return _loader.GetString("IntegrationGridSupportFilterName")
        End Get
    End Property

    Public Shared ReadOnly Property FlexChartSamplesTitle() As String
        Get
            Return _loader.GetString("FlexChartSamplesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FlexChartSamplesDescription() As String
        Get
            Return _loader.GetString("FlexChartSamplesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FlexChartSamplesName() As String
        Get
            Return _loader.GetString("FlexChartSamplesName")
        End Get
    End Property
End Class