Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("BasicLibrarySamplesLib/Resources")

    Public Shared ReadOnly Property MaskedTextBoxTitle() As String
        Get
            Return _loader.GetString("MaskedTextBoxTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxDescription() As String
        Get
            Return _loader.GetString("MaskedTextBoxDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxName() As String
        Get
            Return _loader.GetString("MaskedTextBoxName")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxTitle() As String
        Get
            Return _loader.GetString("NumericBoxTitle")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxDescription() As String
        Get
            Return _loader.GetString("NumericBoxDescription")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxName() As String
        Get
            Return _loader.GetString("NumericBoxName")
        End Get
    End Property

    Public Shared ReadOnly Property DropDownTitle() As String
        Get
            Return _loader.GetString("DropDownTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DropDownDescription() As String
        Get
            Return _loader.GetString("DropDownDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DropDownName() As String
        Get
            Return _loader.GetString("DropDownName")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDownTitle() As String
        Get
            Return _loader.GetString("HierarchicalDropDownTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDownDescription() As String
        Get
            Return _loader.GetString("HierarchicalDropDownDescription")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDownName() As String
        Get
            Return _loader.GetString("HierarchicalDropDownName")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_TB_Header() As String
        Get
            Return _loader.GetString("HierarchicalDropDown_TB_Header")
        End Get
    End Property

    Public Shared ReadOnly Property AutoCompleteDropDownTitle() As String
        Get
            Return _loader.GetString("AutoCompleteDropDownTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AutoCompleteDropDownDescription() As String
        Get
            Return _loader.GetString("AutoCompleteDropDownDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AutoCompleteDropDownName() As String
        Get
            Return _loader.GetString("AutoCompleteDropDownName")
        End Get
    End Property

    Public Shared ReadOnly Property DockPanelSampleTitle() As String
        Get
            Return _loader.GetString("DockPanelSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DockPanelSampleDescription() As String
        Get
            Return _loader.GetString("DockPanelSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DockPanelSampleName() As String
        Get
            Return _loader.GetString("DockPanelSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property UniformGridSampleTitle() As String
        Get
            Return _loader.GetString("UniformGridSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property UniformGridSampleDescription() As String
        Get
            Return _loader.GetString("UniformGridSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property UniformGridSampleName() As String
        Get
            Return _loader.GetString("UniformGridSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSampleTitle() As String
        Get
            Return _loader.GetString("WrapPanelSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSampleDescription() As String
        Get
            Return _loader.GetString("WrapPanelSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSampleName() As String
        Get
            Return _loader.GetString("WrapPanelSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property RadialPanelSampleTitle() As String
        Get
            Return _loader.GetString("RadialPanelSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RadialPanelSampleDescription() As String
        Get
            Return _loader.GetString("RadialPanelSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RadialPanelSampleName() As String
        Get
            Return _loader.GetString("RadialPanelSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTabTitle() As String
        Get
            Return _loader.GetString("EntranceTabTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTabDescription() As String
        Get
            Return _loader.GetString("EntranceTabDescription")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTabName() As String
        Get
            Return _loader.GetString("EntranceTabName")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControlTitle() As String
        Get
            Return _loader.GetString("ClearStyleTabControlTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControlDescription() As String
        Get
            Return _loader.GetString("ClearStyleTabControlDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControlName() As String
        Get
            Return _loader.GetString("ClearStyleTabControlName")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSampleTitle() As String
        Get
            Return _loader.GetString("TabControlSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSampleDescription() As String
        Get
            Return _loader.GetString("TabControlSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSampleName() As String
        Get
            Return _loader.GetString("TabControlSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditionsTitle() As String
        Get
            Return _loader.GetString("CollectionViewConditionsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditionseDescription() As String
        Get
            Return _loader.GetString("CollectionViewConditionsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditionsName() As String
        Get
            Return _loader.GetString("CollectionViewConditionsName")
        End Get
    End Property

    Public Shared ReadOnly Property BindingToC1CollectionViewTitle() As String
        Get
            Return _loader.GetString("BindingToC1CollectionViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BindingToC1CollectionViewDescription() As String
        Get
            Return _loader.GetString("BindingToC1CollectionViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BindingToC1CollectionViewName() As String
        Get
            Return _loader.GetString("BindingToC1CollectionViewName")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxSampleTitle() As String
        Get
            Return _loader.GetString("ListBoxSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxSampleDescription() As String
        Get
            Return _loader.GetString("ListBoxSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxSampleName() As String
        Get
            Return _loader.GetString("ListBoxSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSampleTitle() As String
        Get
            Return _loader.GetString("TreeViewSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSampleDescription() As String
        Get
            Return _loader.GetString("TreeViewSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSampleName() As String
        Get
            Return _loader.GetString("TreeViewSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxTreeViewTitle() As String
        Get
            Return _loader.GetString("CheckBoxTreeViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxTreeViewDescription() As String
        Get
            Return _loader.GetString("CheckBoxTreeViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxTreeViewName() As String
        Get
            Return _loader.GetString("CheckBoxTreeViewName")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTreeViewTitle() As String
        Get
            Return _loader.GetString("DragDropTreeViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTreeViewDescription() As String
        Get
            Return _loader.GetString("DragDropTreeViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTreeViewName() As String
        Get
            Return _loader.GetString("DragDropTreeViewName")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalTreeViewTitle() As String
        Get
            Return _loader.GetString("HierarchicalTreeViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalTreeViewDescription() As String
        Get
            Return _loader.GetString("HierarchicalTreeViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalTreeViewName() As String
        Get
            Return _loader.GetString("HierarchicalTreeViewName")
        End Get
    End Property

    Public Shared ReadOnly Property EditTreeViewTitle() As String
        Get
            Return _loader.GetString("EditTreeViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EditTreeViewDescription() As String
        Get
            Return _loader.GetString("EditTreeViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property EditTreeViewName() As String
        Get
            Return _loader.GetString("EditTreeViewName")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSampleTitle() As String
        Get
            Return _loader.GetString("MenuSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSampleDescription() As String
        Get
            Return _loader.GetString("MenuSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSampleName() As String
        Get
            Return _loader.GetString("MenuSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenuTitle() As String
        Get
            Return _loader.GetString("ContextMenuTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenuDescription() As String
        Get
            Return _loader.GetString("ContextMenuDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenuName() As String
        Get
            Return _loader.GetString("ContextMenuName")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuTitle() As String
        Get
            Return _loader.GetString("RadialMenuTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuDescription() As String
        Get
            Return _loader.GetString("RadialMenuDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuName() As String
        Get
            Return _loader.GetString("RadialMenuName")
        End Get
    End Property

    Public Shared ReadOnly Property ProgressIndicatorDemoTitle() As String
        Get
            Return _loader.GetString("ProgressIndicatorDemoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ProgressIndicatorDemoDescription() As String
        Get
            Return _loader.GetString("ProgressIndicatorDemoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ProgressIndicatorDemoName() As String
        Get
            Return _loader.GetString("ProgressIndicatorDemoName")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSliderTitle() As String
        Get
            Return _loader.GetString("RangeSliderTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSliderDescription() As String
        Get
            Return _loader.GetString("RangeSliderDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSliderName() As String
        Get
            Return _loader.GetString("RangeSliderName")
        End Get
    End Property

    Public Shared ReadOnly Property GridSplitterSampleTitle() As String
        Get
            Return _loader.GetString("GridSplitterSampleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property GridSplitterSampleDescription() As String
        Get
            Return _loader.GetString("GridSplitterSampleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property GridSplitterSampleName() As String
        Get
            Return _loader.GetString("GridSplitterSampleName")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandlingTitle() As String
        Get
            Return _loader.GetString("InputHandlingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandlingeDescription() As String
        Get
            Return _loader.GetString("InputHandlingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandlingName() As String
        Get
            Return _loader.GetString("InputHandlingName")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupA() As String
        Get
            Return _loader.GetString("WorldCupGroupA")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupB() As String
        Get
            Return _loader.GetString("WorldCupGroupB")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupC() As String
        Get
            Return _loader.GetString("WorldCupGroupC")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupD() As String
        Get
            Return _loader.GetString("WorldCupGroupD")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupE() As String
        Get
            Return _loader.GetString("WorldCupGroupE")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupF() As String
        Get
            Return _loader.GetString("WorldCupGroupF")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupG() As String
        Get
            Return _loader.GetString("WorldCupGroupG")
        End Get
    End Property

    Public Shared ReadOnly Property WorldCupGroupH() As String
        Get
            Return _loader.GetString("WorldCupGroupH")
        End Get
    End Property

    Public Shared ReadOnly Property SouthAfrica() As String
        Get
            Return _loader.GetString("SouthAfrica")
        End Get
    End Property

    Public Shared ReadOnly Property Mexico() As String
        Get
            Return _loader.GetString("Mexico")
        End Get
    End Property

    Public Shared ReadOnly Property Uruguay() As String
        Get
            Return _loader.GetString("Uruguay")
        End Get
    End Property

    Public Shared ReadOnly Property France() As String
        Get
            Return _loader.GetString("France")
        End Get
    End Property

    Public Shared ReadOnly Property Argentina() As String
        Get
            Return _loader.GetString("Argentina")
        End Get
    End Property

    Public Shared ReadOnly Property Nigeria() As String
        Get
            Return _loader.GetString("Nigeria")
        End Get
    End Property

    Public Shared ReadOnly Property KoreaRepublic() As String
        Get
            Return _loader.GetString("KoreaRepublic")
        End Get
    End Property

    Public Shared ReadOnly Property Greece() As String
        Get
            Return _loader.GetString("Greece")
        End Get
    End Property

    Public Shared ReadOnly Property England() As String
        Get
            Return _loader.GetString("England")
        End Get
    End Property

    Public Shared ReadOnly Property USA() As String
        Get
            Return _loader.GetString("USA")
        End Get
    End Property

    Public Shared ReadOnly Property Algeria() As String
        Get
            Return _loader.GetString("Algeria")
        End Get
    End Property

    Public Shared ReadOnly Property Slovenia() As String
        Get
            Return _loader.GetString("Slovenia")
        End Get
    End Property

    Public Shared ReadOnly Property Germany() As String
        Get
            Return _loader.GetString("Germany")
        End Get
    End Property

    Public Shared ReadOnly Property Australia() As String
        Get
            Return _loader.GetString("Australia")
        End Get
    End Property

    Public Shared ReadOnly Property Serbia() As String
        Get
            Return _loader.GetString("Serbia")
        End Get
    End Property

    Public Shared ReadOnly Property Ghana() As String
        Get
            Return _loader.GetString("Ghana")
        End Get
    End Property

    Public Shared ReadOnly Property Netherlands() As String
        Get
            Return _loader.GetString("Netherlands")
        End Get
    End Property

    Public Shared ReadOnly Property Denmark() As String
        Get
            Return _loader.GetString("Denmark")
        End Get
    End Property

    Public Shared ReadOnly Property Japan() As String
        Get
            Return _loader.GetString("Japan")
        End Get
    End Property

    Public Shared ReadOnly Property Cameroon() As String
        Get
            Return _loader.GetString("Cameroon")
        End Get
    End Property

    Public Shared ReadOnly Property Italy() As String
        Get
            Return _loader.GetString("Italy")
        End Get
    End Property

    Public Shared ReadOnly Property Paraguay() As String
        Get
            Return _loader.GetString("Paraguay")
        End Get
    End Property

    Public Shared ReadOnly Property NewZealand() As String
        Get
            Return _loader.GetString("NewZealand")
        End Get
    End Property

    Public Shared ReadOnly Property Slovakia() As String
        Get
            Return _loader.GetString("Slovakia")
        End Get
    End Property

    Public Shared ReadOnly Property Brazil() As String
        Get
            Return _loader.GetString("Brazil")
        End Get
    End Property

    Public Shared ReadOnly Property KoreaDPR() As String
        Get
            Return _loader.GetString("KoreaDPR")
        End Get
    End Property

    Public Shared ReadOnly Property CoteDlvoire() As String
        Get
            Return _loader.GetString("CoteDlvoire")
        End Get
    End Property

    Public Shared ReadOnly Property Portugal() As String
        Get
            Return _loader.GetString("Portugal")
        End Get
    End Property

    Public Shared ReadOnly Property Spain() As String
        Get
            Return _loader.GetString("Spain")
        End Get
    End Property

    Public Shared ReadOnly Property Switzerland() As String
        Get
            Return _loader.GetString("Switzerland")
        End Get
    End Property

    Public Shared ReadOnly Property Honduras() As String
        Get
            Return _loader.GetString("Honduras")
        End Get
    End Property

    Public Shared ReadOnly Property Chile() As String
        Get
            Return _loader.GetString("Chile")
        End Get
    End Property

    Public Shared ReadOnly Property CouncilOfDirectors() As String
        Get
            Return _loader.GetString("CouncilOfDirectors")
        End Get
    End Property

    Public Shared ReadOnly Property Principal() As String
        Get
            Return _loader.GetString("Principal")
        End Get
    End Property

    Public Shared ReadOnly Property FinanceAdmin() As String
        Get
            Return _loader.GetString("FinanceAdmin")
        End Get
    End Property

    Public Shared ReadOnly Property FinanceOffice() As String
        Get
            Return _loader.GetString("FinanceOffice")
        End Get
    End Property

    Public Shared ReadOnly Property Manager() As String
        Get
            Return _loader.GetString("Manager")
        End Get
    End Property

    Public Shared ReadOnly Property AssistantManager() As String
        Get
            Return _loader.GetString("AssistantManager")
        End Get
    End Property

    Public Shared ReadOnly Property LegalAndProperty() As String
        Get
            Return _loader.GetString("LegalAndProperty")
        End Get
    End Property

    Public Shared ReadOnly Property TravelOffice() As String
        Get
            Return _loader.GetString("TravelOffice")
        End Get
    End Property

    Public Shared ReadOnly Property DeanOfStudents() As String
        Get
            Return _loader.GetString("DeanOfStudents")
        End Get
    End Property

    Public Shared ReadOnly Property AssistantDean() As String
        Get
            Return _loader.GetString("AssistantDean")
        End Get
    End Property

    Public Shared ReadOnly Property Counselling() As String
        Get
            Return _loader.GetString("Counselling")
        End Get
    End Property

    Public Shared ReadOnly Property Counselor() As String
        Get
            Return _loader.GetString("Counselor")
        End Get
    End Property

    Public Shared ReadOnly Property AssistantCounselor() As String
        Get
            Return _loader.GetString("AssistantCounselor")
        End Get
    End Property

    Public Shared ReadOnly Property StudentServices() As String
        Get
            Return _loader.GetString("StudentServices")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenuPhoneTB() As String
        Get
            Return _loader.GetString("ContextMenu_Phone_TB")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenuItemClickTB() As String
        Get
            Return _loader.GetString("ContextMenu_Item_Click_TB")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuItemOpenedTB() As String
        Get
            Return _loader.GetString("ContextMenu_Item_Opened_TB")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuReDo() As String
        Get
            Return _loader.GetString("RadialMenuReDo")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuUnDo() As String
        Get
            Return _loader.GetString("RadialMenuUnDo")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenuClear() As String
        Get
            Return _loader.GetString("RadialMenuClear")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxSampleErrorMessage() As String
        Get
            Return _loader.GetString("ListBoxSampleErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerCountries() As String
        Get
            Return _loader.GetString("CollectionViewCustomerCountries")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerNames() As String
        Get
            Return _loader.GetString("CollectionViewCustomerNames")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyID() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyID")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyName() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyName")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyCountry() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyCountry")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyActive() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyActive")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyCreated() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyCreated")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertySales() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertySales")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyGrowth() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyGrowth")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyAssets() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyAssets")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewCustomerPropertyValue() As String
        Get
            Return _loader.GetString("CollectionViewCustomerPropertyValue")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewNoneItem() As String
        Get
            Return _loader.GetString("CollectionViewNoneItem")
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

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property OperationtException() As String
        Get
            Return _loader.GetString("OperationtException")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property SouthAfricaTopScorerName() As String
        Get
            Return _loader.GetString("SouthAfricaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property MexicoTopScorerName() As String
        Get
            Return _loader.GetString("MexicoTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property UruguayTopScorerName() As String
        Get
            Return _loader.GetString("UruguayTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property FranceTopScorerName() As String
        Get
            Return _loader.GetString("FranceTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property ArgentinaTopScorerName() As String
        Get
            Return _loader.GetString("ArgentinaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property NigeriaTopScorerName() As String
        Get
            Return _loader.GetString("NigeriaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property KoreaSouthTopScorerName() As String
        Get
            Return _loader.GetString("KoreaSouthTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property GreeceTopScorerName() As String
        Get
            Return _loader.GetString("GreeceTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property EnglandTopScorerName() As String
        Get
            Return _loader.GetString("EnglandTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property UnitedStatesTopScorerName() As String
        Get
            Return _loader.GetString("UnitedStatesTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property AlgeriaTopScorerName() As String
        Get
            Return _loader.GetString("AlgeriaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property SloveniaTopScorerName() As String
        Get
            Return _loader.GetString("SloveniaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property GermanyTopScorerName() As String
        Get
            Return _loader.GetString("GermanyTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property AustraliaTopScorerName() As String
        Get
            Return _loader.GetString("AustraliaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property SerbiaTopScorerName() As String
        Get
            Return _loader.GetString("SerbiaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property GhanaTopScorerName() As String
        Get
            Return _loader.GetString("GhanaTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property NetherlandsTopScorerName() As String
        Get
            Return _loader.GetString("NetherlandsTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property DenmarkTopScorerName() As String
        Get
            Return _loader.GetString("DenmarkTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property JapanTopScorerName() As String
        Get
            Return _loader.GetString("JapanTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property CameroonTopScorerName() As String
        Get
            Return _loader.GetString("CameroonTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property ItalyTopScorerName() As String
        Get
            Return _loader.GetString("ItalyTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property ParaguayTopScorerName() As String
        Get
            Return _loader.GetString("ParaguayTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property NewZealandTopScorerName() As String
        Get
            Return _loader.GetString("NewZealandTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property SlovakRepublicTopScorerName() As String
        Get
            Return _loader.GetString("SlovakRepublicTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property BrazilTopScorerName() As String
        Get
            Return _loader.GetString("BrazilTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property KoreaNorthTopScorerName() As String
        Get
            Return _loader.GetString("KoreaNorthTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property CoteDlvoireTopScorerName() As String
        Get
            Return _loader.GetString("CoteDlvoireTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property PortugalTopScorerName() As String
        Get
            Return _loader.GetString("PortugalTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property SpainTopScorerName() As String
        Get
            Return _loader.GetString("SpainTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property SwitzerlandTopScorerName() As String
        Get
            Return _loader.GetString("SwitzerlandTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property HondurasTopScorerName() As String
        Get
            Return _loader.GetString("HondurasTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property ChileTopScorerName() As String
        Get
            Return _loader.GetString("ChileTopScorerName")
        End Get
    End Property

    Public Shared ReadOnly Property AlexVera() As String
        Get
            Return _loader.GetString("AlexVera")
        End Get
    End Property

    Public Shared ReadOnly Property BrunoMaxtor() As String
        Get
            Return _loader.GetString("BrunoMaxtor")
        End Get
    End Property

    Public Shared ReadOnly Property BrunoGates() As String
        Get
            Return _loader.GetString("BrunoGates")
        End Get
    End Property

    Public Shared ReadOnly Property MichaelVera() As String
        Get
            Return _loader.GetString("MichaelVera")
        End Get
    End Property

    Public Shared ReadOnly Property NoelaJohnson() As String
        Get
            Return _loader.GetString("NoelaJohnson")
        End Get
    End Property

    Public Shared ReadOnly Property MartinDay() As String
        Get
            Return _loader.GetString("MartinDay")
        End Get
    End Property

    Public Shared ReadOnly Property LeonardJhonson() As String
        Get
            Return _loader.GetString("LeonardJhonson")
        End Get
    End Property

    Public Shared ReadOnly Property RodrigoBeckham() As String
        Get
            Return _loader.GetString("RodrigoBeckham")
        End Get
    End Property

    Public Shared ReadOnly Property BenSmith() As String
        Get
            Return _loader.GetString("BenSmith")
        End Get
    End Property

    Public Shared ReadOnly Property MaxDays() As String
        Get
            Return _loader.GetString("MaxDays")
        End Get
    End Property

    Public Shared ReadOnly Property SheelaAlvarez() As String
        Get
            Return _loader.GetString("SheelaAlvarez")
        End Get
    End Property

    Public Shared ReadOnly Property JohnMaxto() As String
        Get
            Return _loader.GetString("JohnMaxto")
        End Get
    End Property

    Public Shared ReadOnly Property PeterMeredith() As String
        Get
            Return _loader.GetString("PeterMeredith")
        End Get
    End Property

    Public Shared ReadOnly Property JeanJobs() As String
        Get
            Return _loader.GetString("JeanJobs")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString(" AppName_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property AutoCompleteDropDown_TB_Text() As String
        Get
            Return _loader.GetString(" AutoCompleteDropDown_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property BindingToC1CollectionView_From_Text() As String
        Get
            Return _loader.GetString(" BindingToC1CollectionView_From_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property BindingToC1CollectionView_TB_1_Text() As String
        Get
            Return _loader.GetString(" BindingToC1CollectionView_TB_1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property BindingToC1CollectionView_TB_2_Text() As String
        Get
            Return _loader.GetString(" BindingToC1CollectionView_TB_2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem2_1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem2_1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem2_2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem2_2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem2_3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem2_3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem2_4_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem2_4_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem2_5_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem2_5_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem3_1_1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem3_1_1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem3_1_2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem3_1_2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem3_1_3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem3_1_3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem3_1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem3_1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem3_2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem3_2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem4_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem4_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem5_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem5_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CheckBoxSample_TreeViewItem6_TB_Header_Text() As String
        Get
            Return _loader.GetString(" CheckBoxSample_TreeViewItem6_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_ComboBox_Item1_Content() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_ComboBox_Item1_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_ComboBox_Item2_Content() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_ComboBox_Item2_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_ComboBox_Item3_Content() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_ComboBox_Item3_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_ComboBox_Item4_Content() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_ComboBox_Item4_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Email1_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Email1_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Email2_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Email2_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Email3_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Email3_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Email4_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Email4_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Email5_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Email5_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Everet_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Everet_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Name1_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Name1_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Name2_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Name2_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Name3_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Name3_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Name4_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Name4_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Name5_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Name5_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_NewportHills_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_NewportHills_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Number1_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Number1_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Number2_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Number2_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Number3_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Number3_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Number4_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Number4_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Number5_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Number5_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Seatle_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Seatle_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_Snohomish_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_Snohomish_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_SalesAgents_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_SalesAgents_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_TabItem1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_TabItem1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_TabItem2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_TabItem2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_TabItem3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_TabItem3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_TabItem4_TB_Header_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_TabItem4_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ClearStyleTabControl_TB_Text() As String
        Get
            Return _loader.GetString(" ClearStyleTabControl_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_All_Properties_TB_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_All_Properties_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_Column3_Name_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_Column3_Name_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_Column4_Name_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_Column4_Name_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_Column5_Name_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_Column5_Name_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_Selected_Properties_TB_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_Selected_Properties_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_TB_1_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_TB_1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_TB_2_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_TB_2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_TB_3_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_TB_3_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewConditions_TB_4_Text() As String
        Get
            Return _loader.GetString(" CollectionViewConditions_TB_4_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_Desktop_TB_Text() As String
        Get
            Return _loader.GetString(" ContextMenu_Desktop_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_Item_Click_TB() As String
        Get
            Return _loader.GetString(" ContextMenu_Item_Click_TB ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_Item_Opened_TB_Text() As String
        Get
            Return _loader.GetString(" ContextMenu_Item_Opened_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem1_1_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem1_2_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem1_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem1_3_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem1_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem1_4_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem1_4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem1_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem2_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem3_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem4_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem5_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem5_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem6_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem6_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem7_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem7_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_MenuItem8_Header_Header() As String
        Get
            Return _loader.GetString(" ContextMenu_MenuItem8_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property ContextMenu_Phone_TB() As String
        Get
            Return _loader.GetString(" ContextMenu_Phone_TB ")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTreeView_RadioButton_1_Content() As String
        Get
            Return _loader.GetString(" DragDropTreeView_RadioButton_1_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTreeView_RadioButton_2_Content() As String
        Get
            Return _loader.GetString(" DragDropTreeView_RadioButton_2_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTreeView_TB_Text() As String
        Get
            Return _loader.GetString(" DragDropTreeView_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property DropDownDemo_CheckBox_Content_Content() As String
        Get
            Return _loader.GetString(" DropDownDemo_CheckBox_Content_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_Content1_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_Content1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_Content2_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_Content2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_Content3_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_Content3_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_Content1_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_Content1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_Content2_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_Content2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_Content3_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_Content3_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_Content1_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_Content1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_Content2_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_Content2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_Content3_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_Content3_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_Header_1_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_Header_1_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_Header_2_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_Header_2_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_Header_3_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_Header_3_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_Header_1_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_Header_1_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_Header_2_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_Header_2_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_Header_3_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_Header_3_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_Header_1_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_Header_1_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_Header_2_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_Header_2_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_Header_3_Header() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_Header_3_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property EntranceTab_TabItem3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" EntranceTab_TabItem3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_1_1_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_1_1_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_1_2_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_1_2_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_1_3_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_1_3_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_1_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_1_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_2_1_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_2_1_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_2_2_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_2_2_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_2_3_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_2_3_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_2_4_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_2_4_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_2_5_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_2_5_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_Item_Header_2_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_Item_Header_2_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_TB_Header_Text() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalDropDown_TreeView_Header_Header() As String
        Get
            Return _loader.GetString(" HierarchicalDropDown_TreeView_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalTreeView_TB_1_Text() As String
        Get
            Return _loader.GetString(" HierarchicalTreeView_TB_1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property HierarchicalTreeView_TB_2_Text() As String
        Get
            Return _loader.GetString(" HierarchicalTreeView_TB_2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandling_Run1_Text() As String
        Get
            Return _loader.GetString(" InputHandling_Run1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandling_Run2_Text() As String
        Get
            Return _loader.GetString(" InputHandling_Run2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandling_Run3_Text() As String
        Get
            Return _loader.GetString(" InputHandling_Run3_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property InputHandling_Run4_Text() As String
        Get
            Return _loader.GetString(" InputHandling_Run4_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxSample_TB_Text() As String
        Get
            Return _loader.GetString(" ListBoxSample_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ListBoxSample_Button_Content() As String
        Get
            Return _loader.GetString(" ListBoxSample_Button_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_Bottom_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_Bottom_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_Center_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_Center_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_DOB_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_DOB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_ID_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_ID_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_Left_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_Left_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_Phone_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_Phone_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_Right_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_Right_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_State_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_State_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MaskedTextBoxSample_TB_Top_Text() As String
        Get
            Return _loader.GetString(" MaskedTextBoxSample_TB_Top_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_1_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_1_2_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_1_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_1_3_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_1_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_1_4_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_1_4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_2_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_3_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_4_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_5_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_5_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_6_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_6_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_7_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_7_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_8_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_8_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_9_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_9_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_2_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_3_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_4_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_5_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_5_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_6_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_6_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem2_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_2_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_3_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_4_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_5_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_5_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_6_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_6_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_7_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_7_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem3_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem4_1_1_1_1_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem4_1_1_1_1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem4_1_1_1_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem4_1_1_1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem4_1_1_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem4_1_1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem4_1_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem4_1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem4_1_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem4_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property MenuSample_MenuItem4_Header_Header() As String
        Get
            Return _loader.GetString(" MenuSample_MenuItem4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxSample_TB_Currency_Text() As String
        Get
            Return _loader.GetString(" NumericBoxSample_TB_Currency_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxSample_TB_Custom_Text() As String
        Get
            Return _loader.GetString(" NumericBoxSample_TB_Custom_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxSample_TB_Fixed_Text() As String
        Get
            Return _loader.GetString(" NumericBoxSample_TB_Fixed_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxSample_TB_Number_Text() As String
        Get
            Return _loader.GetString(" NumericBoxSample_TB_Number_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property NumericBoxSample_TB_Percent_Text() As String
        Get
            Return _loader.GetString(" NumericBoxSample_TB_Percent_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property ProgressIndicatorDemo_ProgressIndicator_Header_Header() As String
        Get
            Return _loader.GetString(" ProgressIndicatorDemo_ProgressIndicator_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem1_1_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem1_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem1_2_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem1_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem1_3_TB_Text() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem1_3_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem1_3_ToolTip_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem1_3_ToolTip_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem1_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem2_1_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem2_1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem2_2_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem2_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem2_3_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem2_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem2_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_1_Header_And_ToolTip_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_1_Header_And_ToolTip_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_1_Header_And_ToolTip_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_1_Header_And_ToolTip_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_2_Header_And_ToolTip_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_2_Header_And_ToolTip_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_2_Header_And_ToolTip_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_2_Header_And_ToolTip_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_3_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_4_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem3_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem4_1_Header_And_ToolTip_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem4_1_Header_And_ToolTip_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem4_1_Header_And_ToolTip_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem4_1_Header_And_ToolTip_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem4_2_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem4_2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem4_3_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem4_3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem4_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem4_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem5_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem5_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem6_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem6_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem7_1_Header_And_ToolTip_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem7_1_Header_And_ToolTip_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem7_1_Header_And_ToolTip_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem7_1_Header_And_ToolTip_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_MenuItem7_Header_Header() As String
        Get
            Return _loader.GetString(" RadialMenu_MenuItem7_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Aqua_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Aqua_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Blue_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Blue_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Brown_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Brown_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_DarkBlue_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_DarkBlue_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_DarkGreen_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_DarkGreen_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_DarkPurple_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_DarkPurple_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_DarkRed_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_DarkRed_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Gold_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Gold_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Green_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Green_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_LightGreen_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_LightGreen_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_LightYellow_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_LightYellow_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Lime_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Lime_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Orange_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Orange_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Pink_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Pink_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Plum_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Plum_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Purple_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Purple_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Red_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Red_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Rose_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Rose_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_SkyBlue_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_SkyBlue_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_SlateBlue_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_SlateBlue_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Turquoise_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Turquoise_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialMenu_RadialColorItem_ToolTip_Yellow_ToolTip() As String
        Get
            Return _loader.GetString(" RadialMenu_RadialColorItem_ToolTip_Yellow_ToolTip ")
        End Get
    End Property

    Public Shared ReadOnly Property RadialPanelSample_TB_Text() As String
        Get
            Return _loader.GetString(" RadialPanelSample_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property RadiaMenu_Desktop_TB_Text() As String
        Get
            Return _loader.GetString(" RadiaMenu_Desktop_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property RadiaMenu_Phone_TB_Text() As String
        Get
            Return _loader.GetString(" RadiaMenu_Phone_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_ComboBox_Item1_Content() As String
        Get
            Return _loader.GetString(" TabControlSample_ComboBox_Item1_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_ComboBox_Item2_Content() As String
        Get
            Return _loader.GetString(" TabControlSample_ComboBox_Item2_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_ComboBox_Item3_Content() As String
        Get
            Return _loader.GetString(" TabControlSample_ComboBox_Item3_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem4_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem4_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem5_TB_Content_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem5_TB_Content_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem5_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem5_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem6_TB_Content_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem6_TB_Content_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TabItem6_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TabItem6_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TB_1_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TB_1_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TabControlSample_TB_2_Text() As String
        Get
            Return _loader.GetString(" TabControlSample_TB_2_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_CheckBox_1_Content() As String
        Get
            Return _loader.GetString(" TreeViewSample_CheckBox_1_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_CheckBox_2_Content() As String
        Get
            Return _loader.GetString(" TreeViewSample_CheckBox_2_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem2_1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem2_1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem2_2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem2_2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem2_3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem2_3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem2_4_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem2_4_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem2_5_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem2_5_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem3_1_1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem3_1_1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem3_1_2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem3_1_2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem3_1_3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem3_1_3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem3_1_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem3_1_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem3_2_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem3_2_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem3_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem3_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem4_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem4_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem5_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem5_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property TreeViewSample_TreeViewItem6_TB_Header_Text() As String
        Get
            Return _loader.GetString(" TreeViewSample_TreeViewItem6_TB_Header_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property UniformGridSample_Button_Content_Content() As String
        Get
            Return _loader.GetString(" UniformGridSample_Button_Content_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_Content_TB_Text() As String
        Get
            Return _loader.GetString(" VerticalMenu_Content_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_DragDropManager_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_DragDropManager_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Toolbar_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Toolbar_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_DockControl_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_DockControl_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_RadialMenu_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_RadialMenu_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Tiles_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Tiles_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_TreeView_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_TreeView_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_HyperPanel_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_HyperPanel_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_OutlookBar_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_OutlookBar_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Accordion_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Accordion_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_TabControl_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_TabControl_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Windows_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Windows_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_MediaPlayer_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_MediaPlayer_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_ProgressBar_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_ProgressBar_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_TileView_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_TileView_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Carousel_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Carousel_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Book_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Book_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_CoverFlow_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_CoverFlow_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Menu_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Menu_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_LayoutPanels_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_LayoutPanels_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_Imaging_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_Imaging_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem_HtmlHost_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem_HtmlHost_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem1_Header_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem1_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem2_Header_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem2_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_MenuItem3_Header_Header() As String
        Get
            Return _loader.GetString(" VerticalMenu_MenuItem3_Header_Header ")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalMenu_TB_Text() As String
        Get
            Return _loader.GetString(" VerticalMenu_TB_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_Horizontal_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_Horizontal_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_1_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_1_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_10_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_10_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_11_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_11_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_12_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_12_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_13_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_13_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_14_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_14_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_15_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_15_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_16_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_16_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_17_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_17_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_18_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_18_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_19_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_19_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_2_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_2_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_20_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_20_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_3_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_3_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_4_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_4_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_5_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_5_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_6_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_6_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_7_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_7_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_8_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_8_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_HyperlinkButton_Content_9_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_HyperlinkButton_Content_9_Content ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_TB_Text_Text() As String
        Get
            Return _loader.GetString(" WrapPanelSample_TB_Text_Text ")
        End Get
    End Property

    Public Shared ReadOnly Property WrapPanelSample_Vertical_Content() As String
        Get
            Return _loader.GetString(" WrapPanelSample_Vertical_Content ")
        End Get
    End Property
End Class