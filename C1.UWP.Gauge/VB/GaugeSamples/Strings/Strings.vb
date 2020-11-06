Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("GaugeSamplesLib/Resources")

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

    Public Shared ReadOnly Property LinearGaugeName() As String
        Get
            Return _loader.GetString("LinearGaugeName")
        End Get
    End Property

    Public Shared ReadOnly Property LinearGaugeTitle() As String
        Get
            Return _loader.GetString("LinearGaugeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LinearGaugeDescription() As String
        Get
            Return _loader.GetString("LinearGaugeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RulerGaugeName() As String
        Get
            Return _loader.GetString("RulerGaugeName")
        End Get
    End Property

    Public Shared ReadOnly Property RulerGaugeTitle() As String
        Get
            Return _loader.GetString("RulerGaugeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RulerGaugeDescription() As String
        Get
            Return _loader.GetString("RulerGaugeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property KnobName() As String
        Get
            Return _loader.GetString("KnobName")
        End Get
    End Property

    Public Shared ReadOnly Property KnobTitle() As String
        Get
            Return _loader.GetString("KnobTitle")
        End Get
    End Property

    Public Shared ReadOnly Property KnobDescription() As String
        Get
            Return _loader.GetString("KnobDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RegionKnobName() As String
        Get
            Return _loader.GetString("RegionKnobName")
        End Get
    End Property

    Public Shared ReadOnly Property RegionKnobTitle() As String
        Get
            Return _loader.GetString("RegionKnobTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RegionKnobDescription() As String
        Get
            Return _loader.GetString("RegionKnobDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RadialGaugeName() As String
        Get
            Return _loader.GetString("RadialGaugeName")
        End Get
    End Property

    Public Shared ReadOnly Property RadialGaugeTitle() As String
        Get
            Return _loader.GetString("RadialGaugeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RadialGaugeDescription() As String
        Get
            Return _loader.GetString("RadialGaugeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SpeedometerName() As String
        Get
            Return _loader.GetString("SpeedometerName")
        End Get
    End Property

    Public Shared ReadOnly Property SpeedometerTitle() As String
        Get
            Return _loader.GetString("SpeedometerTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SpeedometerDescription() As String
        Get
            Return _loader.GetString("SpeedometerDescription")
        End Get
    End Property

    Public Shared ReadOnly Property VolumeGaugeName() As String
        Get
            Return _loader.GetString("VolumeGaugeName")
        End Get
    End Property

    Public Shared ReadOnly Property VolumeGaugeTitle() As String
        Get
            Return _loader.GetString("VolumeGaugeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property VolumeGaugeDescription() As String
        Get
            Return _loader.GetString("VolumeGaugeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ClockName() As String
        Get
            Return _loader.GetString("ClockName")
        End Get
    End Property

    Public Shared ReadOnly Property ClockTitle() As String
        Get
            Return _loader.GetString("ClockTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ClockDescription() As String
        Get
            Return _loader.GetString("ClockDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AutomobileName() As String
        Get
            Return _loader.GetString("AutomobileName")
        End Get
    End Property

    Public Shared ReadOnly Property AutomobileTitle() As String
        Get
            Return _loader.GetString("AutomobileTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AutomobileDescription() As String
        Get
            Return _loader.GetString("AutomobileDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ThermometerName() As String
        Get
            Return _loader.GetString("ThermometerName")
        End Get
    End Property

    Public Shared ReadOnly Property ThermometerTitle() As String
        Get
            Return _loader.GetString("ThermometerTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ThermometerDescription() As String
        Get
            Return _loader.GetString("ThermometerDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RuleName() As String
        Get
            Return _loader.GetString("RuleName")
        End Get
    End Property

    Public Shared ReadOnly Property RuleTitle() As String
        Get
            Return _loader.GetString("RuleTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RuleDescription() As String
        Get
            Return _loader.GetString("RuleDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LabelE_Text() As String
        Get
            Return _loader.GetString("LabelE_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LabelF_Text() As String
        Get
            Return _loader.GetString("LabelF_Text")
        End Get
    End Property
End Class
