Imports C1.Xaml.OrgChart
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class HierarchicalSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        ' create data object
        Dim league As League = League.GetLeague()

        ' show it in C1OrgChart
        ' this has the same effect:
        '_chart.ItemsSource = new object[] { league };

        ' show it in TreeView
        '_tree.ItemsSource = new object[] { league };
        _chart.Header = league
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
    End Sub
End Class
Public Class League
    Public Property Name() As String
    Public Property Divisions() As List(Of Division)

    Public Shared Function GetLeague() As League
        Dim league As League = New League()
        league.Name = Strings.MainLeague
        league.Divisions = New List(Of Division)()
        For Each div As String In Strings.StringNorthSouthEastWest.Split(","c)
            Dim d As New Division()
            league.Divisions.Add(d)
            d.Name = div
            d.Teams = New List(Of Team)()
            Select Case div
                Case "East"
                    AddNewTeams(d, Strings.TeamFormEast)
                    Exit Select
                Case "West"
                    AddNewTeams(d, Strings.TeamFormWest)
                    Exit Select
                Case "North"
                    AddNewTeams(d, Strings.TeamFormNorth)
                    Exit Select
                Case "South"
                    AddNewTeams(d, Strings.TeamFormSouth)
                    Exit Select
            End Select
        Next
        Return league
    End Function

    Shared Sub AddNewTeams(d As Division, teamNames As String)
        For Each team As String In teamNames.Split(","c)
            Dim t As New Team()
            d.Teams.Add(t)
            t.Name = team
        Next
    End Sub
End Class
Public Class Division
    Public Property Name() As String
    Public Property Teams() As List(Of Team)
End Class
Public Class Team
    Public Property Name() As String
End Class