Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("GridTreeViewSamplesLib/Resources")

    Public Shared ReadOnly Property GridTreeViewSamplesDescription() As String
        Get
            Return _loader.GetString("GridTreeViewSamplesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property GridTreeViewSamplesName() As String
        Get
            Return _loader.GetString("GridTreeViewSamplesName")
        End Get
    End Property

    Public Shared ReadOnly Property GridTreeViewSamplesTitle() As String
        Get
            Return _loader.GetString("GridTreeViewSamplesTitle")
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

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property


    Public Shared ReadOnly Property BoundC1TreeView() As String
        Get
            Return _loader.GetString("BoundC1TreeView")
        End Get
    End Property


    Public Shared ReadOnly Property UnBoundC1TreeView() As String
        Get
            Return _loader.GetString("UnBoundC1TreeView")
        End Get
    End Property

    Public Shared ReadOnly Property BoundC1FlexGrid() As String
        Get
            Return _loader.GetString("BoundC1FlexGrid")
        End Get
    End Property

    Public Shared ReadOnly Property UnBoundC1FlexGrid() As String
        Get
            Return _loader.GetString("UnBoundC1FlexGrid")
        End Get
    End Property

    Public Shared ReadOnly Property BuildingPersonTree() As String
        Get
            Return _loader.GetString("BuildingPersonTree")
        End Get
    End Property

    Public Shared ReadOnly Property PersonFormat() As String
        Get
            Return _loader.GetString("PersonFormat")
        End Get
    End Property

    Public Shared ReadOnly Property AddChild_Content() As String
        Get
            Return _loader.GetString("AddChild_Content")
        End Get
    End Property

    Public Shared ReadOnly Property AddRoot_Content() As String
        Get
            Return _loader.GetString("AddRoot_Content")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Bound_Header() As String
        Get
            Return _loader.GetString("Bound_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Change_Content() As String
        Get
            Return _loader.GetString("Change_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Delete_Content() As String
        Get
            Return _loader.GetString("Delete_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Ready_Text() As String
        Get
            Return _loader.GetString("Ready_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Unbound_Header() As String
        Get
            Return _loader.GetString("Unbound_Header")
        End Get
    End Property
End Class