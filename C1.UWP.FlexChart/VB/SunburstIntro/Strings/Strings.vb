Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("SunburstIntroLib/Resources")

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
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

    Public Shared ReadOnly Property TxtAppName() As String
        Get
            Return _loader.GetString("TxtAppName")
        End Get
    End Property

    Public Shared ReadOnly Property InnerRadius() As String
        Get
            Return _loader.GetString("InnerRadius")
        End Get
    End Property

    Public Shared ReadOnly Property Offset() As String
        Get
            Return _loader.GetString("Offset")
        End Get
    End Property

    Public Shared ReadOnly Property StartAngle() As String
        Get
            Return _loader.GetString("StartAngle")
        End Get
    End Property

    Public Shared ReadOnly Property Reversed() As String
        Get
            Return _loader.GetString("Reversed")
        End Get
    End Property

    Public Shared ReadOnly Property Palette() As String
        Get
            Return _loader.GetString("Palette")
        End Get
    End Property

    Public Shared ReadOnly Property LegendPosition() As String
        Get
            Return _loader.GetString("LegendPosition")
        End Get
    End Property

    Public Shared ReadOnly Property Header() As String
        Get
            Return _loader.GetString("Header")
        End Get
    End Property

    Public Shared ReadOnly Property Footer() As String
        Get
            Return _loader.GetString("Footer")
        End Get
    End Property

    Public Shared ReadOnly Property FooterContent() As String
        Get
            Return _loader.GetString("FooterContent")
        End Get
    End Property

    Public Shared ReadOnly Property HeaderContent() As String
        Get
            Return _loader.GetString("HeaderContent")
        End Get
    End Property

    Public Shared ReadOnly Property SelectedItemPosition() As String
        Get
            Return _loader.GetString("SelectedItemPosition")
        End Get
    End Property

    Public Shared ReadOnly Property SelectedItemOffset() As String
        Get
            Return _loader.GetString("SelectedItemOffset")
        End Get
    End Property

#Region "Samples"
    Public Shared ReadOnly Property BasicFeaturesTitle() As String
        Get
            Return _loader.GetString("BasicFeaturesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BasicFeaturesDescription() As String
        Get
            Return _loader.GetString("BasicFeaturesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BasicFeaturesName() As String
        Get
            Return _loader.GetString("BasicFeaturesName")
        End Get
    End Property

    Public Shared ReadOnly Property GettingStartedTitle() As String
        Get
            Return _loader.GetString("GettingStartedTitle")
        End Get
    End Property

    Public Shared ReadOnly Property GettingStartedDescription() As String
        Get
            Return _loader.GetString("GettingStartedDescription")
        End Get
    End Property

    Public Shared ReadOnly Property GettingStartedName() As String
        Get
            Return _loader.GetString("GettingStartedName")
        End Get
    End Property

    Public Shared ReadOnly Property LegendTitleTitle() As String
        Get
            Return _loader.GetString("LegendTitleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LegendTitleDescription() As String
        Get
            Return _loader.GetString("LegendTitleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LegendTitlesName() As String
        Get
            Return _loader.GetString("LegendTitlesName")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionTitle() As String
        Get
            Return _loader.GetString("SelectionTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionDescription() As String
        Get
            Return _loader.GetString("SelectionDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SelectionName() As String
        Get
            Return _loader.GetString("SelectionName")
        End Get
    End Property

    Public Shared ReadOnly Property GroupTitle() As String
        Get
            Return _loader.GetString("GroupTitle")
        End Get
    End Property

    Public Shared ReadOnly Property GroupDescription() As String
        Get
            Return _loader.GetString("GroupDescription")
        End Get
    End Property

    Public Shared ReadOnly Property GroupName() As String
        Get
            Return _loader.GetString("GroupName")
        End Get
    End Property

#End Region
End Class