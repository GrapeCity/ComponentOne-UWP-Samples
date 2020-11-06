Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("OrgChartSamplesLib/Resources")

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property CollapseOrExpand_Text() As String
        Get
            Return _loader.GetString("CollapseOrExpand_Text")
        End Get
    End Property

    Public Shared ReadOnly Property CollapseToLevelOneBT_Content() As String
        Get
            Return _loader.GetString("CollapseToLevelOneBT_Content")
        End Get
    End Property

    Public Shared ReadOnly Property CollapseToLevelTwoBT_Content() As String
        Get
            Return _loader.GetString("CollapseToLevelTwoBT_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Designer() As String
        Get
            Return _loader.GetString("Designer")
        End Get
    End Property

    Public Shared ReadOnly Property Director() As String
        Get
            Return _loader.GetString("Director")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDataTemplateOrgChartTB_Text() As String
        Get
            Return _loader.GetString("HierarchicalDataTemplateOrgChartTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property HorizontalCB_Content() As String
        Get
            Return _loader.GetString("HorizontalCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property HorizontalComboBoxItem_Content() As String
        Get
            Return _loader.GetString("HorizontalComboBoxItem_Content")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property MainLeague() As String
        Get
            Return _loader.GetString("MainLeague")
        End Get
    End Property

    Public Shared ReadOnly Property Manager() As String
        Get
            Return _loader.GetString("Manager")
        End Get
    End Property

    Public Shared ReadOnly Property NewDataBT_Content() As String
        Get
            Return _loader.GetString("NewDataBT_Content")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesCollapseExpandDescription() As String
        Get
            Return _loader.GetString("OrgChartSamplesCollapseExpandDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesCollapseExpandName() As String
        Get
            Return _loader.GetString("OrgChartSamplesCollapseExpandName")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesCollapseExpandTitle() As String
        Get
            Return _loader.GetString("OrgChartSamplesCollapseExpandTitle")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesHierarchicalSampleDescription() As String
        Get
            Return _loader.GetString("OrgChartSamplesHierarchicalSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesHierarchicalSampleName() As String
        Get
            Return _loader.GetString("OrgChartSamplesHierarchicalSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesHierarchicalSampleTitle() As String
        Get
            Return _loader.GetString("OrgChartSamplesHierarchicalSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesOverviewDescription() As String
        Get
            Return _loader.GetString("OrgChartSamplesOverviewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesOverviewName() As String
        Get
            Return _loader.GetString("OrgChartSamplesOverviewName")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesOverviewTitle() As String
        Get
            Return _loader.GetString("OrgChartSamplesOverviewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesTemplateSelectorDescription() As String
        Get
            Return _loader.GetString("OrgChartSamplesTemplateSelectorDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesTemplateSelectorName() As String
        Get
            Return _loader.GetString("OrgChartSamplesTemplateSelectorName")
        End Get
    End Property

    Public Shared ReadOnly Property OrgChartSamplesTemplateSelectorTitle() As String
        Get
            Return _loader.GetString("OrgChartSamplesTemplateSelectorTitle")
        End Get
    End Property

    Public Shared ReadOnly Property OrientationTB_Text() As String
        Get
            Return _loader.GetString("OrientationTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RefreshDataBT_Content() As String
        Get
            Return _loader.GetString("RefreshDataBT_Content")
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

    Public Shared ReadOnly Property StringAdjective() As String
        Get
            Return _loader.GetString("StringAdjective")
        End Get
    End Property

    Public Shared ReadOnly Property StringAreas() As String
        Get
            Return _loader.GetString("StringAreas")
        End Get
    End Property

    Public Shared ReadOnly Property StringFirstName() As String
        Get
            Return _loader.GetString("StringFirstName")
        End Get
    End Property

    Public Shared ReadOnly Property StringFormatThreeArg() As String
        Get
            Return _loader.GetString("StringFormatThreeArg")
        End Get
    End Property

    Public Shared ReadOnly Property StringFormatTwoArg() As String
        Get
            Return _loader.GetString("StringFormatTwoArg")
        End Get
    End Property

    Public Shared ReadOnly Property StringLastName() As String
        Get
            Return _loader.GetString("StringLastName")
        End Get
    End Property

    Public Shared ReadOnly Property StringNorthSouthEastWest() As String
        Get
            Return _loader.GetString("StringNorthSouthEastWest")
        End Get
    End Property

    Public Shared ReadOnly Property StringNoun() As String
        Get
            Return _loader.GetString("StringNoun")
        End Get
    End Property

    Public Shared ReadOnly Property StringPositions() As String
        Get
            Return _loader.GetString("StringPositions")
        End Get
    End Property

    Public Shared ReadOnly Property StringVerb() As String
        Get
            Return _loader.GetString("StringVerb")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property TotalItem() As String
        Get
            Return _loader.GetString("TotalItem")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalComboBoxItem_Content() As String
        Get
            Return _loader.GetString("VerticalComboBoxItem_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ZoomTB_Text() As String
        Get
            Return _loader.GetString("ZoomTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TeamFormEast() As String
        Get
            Return _loader.GetString("TeamFormEast")
        End Get
    End Property

    Public Shared ReadOnly Property TeamFormWest() As String
        Get
            Return _loader.GetString("TeamFormWest")
        End Get
    End Property

    Public Shared ReadOnly Property TeamFormSouth() As String
        Get
            Return _loader.GetString("TeamFormSouth")
        End Get
    End Property

    Public Shared ReadOnly Property TeamFormNorth() As String
        Get
            Return _loader.GetString("TeamFormNorth")
        End Get
    End Property

    Public Shared ReadOnly Property NameClancy() As String
        Get
            Return _loader.GetString("NameClancy")
        End Get
    End Property

    Public Shared ReadOnly Property NameMarge() As String
        Get
            Return _loader.GetString("NameMarge")
        End Get
    End Property

    Public Shared ReadOnly Property NamePatty() As String
        Get
            Return _loader.GetString("NamePatty")
        End Get
    End Property

    Public Shared ReadOnly Property NameSelma() As String
        Get
            Return _loader.GetString("NameSelma")
        End Get
    End Property

    Public Shared ReadOnly Property NameLing() As String
        Get
            Return _loader.GetString("NameLing")
        End Get
    End Property

    Public Shared ReadOnly Property NameBart() As String
        Get
            Return _loader.GetString("NameBart")
        End Get
    End Property

    Public Shared ReadOnly Property NameLisa() As String
        Get
            Return _loader.GetString("NameLisa")
        End Get
    End Property

    Public Shared ReadOnly Property NameMaggie() As String
        Get
            Return _loader.GetString("NameMaggie")
        End Get
    End Property

    Public Shared ReadOnly Property FamilyTreeTitle() As String
        Get
            Return _loader.GetString("FamilyTreeTitle")
        End Get
    End Property
End Class