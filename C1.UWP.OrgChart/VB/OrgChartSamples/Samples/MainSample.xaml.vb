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
Partial Public NotInheritable Class MainSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()

        ' create hieararchy
        Dim father As New Platform() With {
            .Name = Strings.NameClancy
        }
        Dim olderChild As New Platform() With {
            .Name = Strings.NameMarge
        }
        Dim middleChild As New Platform() With {
            .Name = Strings.NamePatty
        }
        Dim youngerChild As New Platform() With {
            .Name = Strings.NameSelma
        }

        father.Subplatforms = New List(Of Platform)()
        father.Subplatforms.Add(olderChild)
        father.Subplatforms.Add(middleChild)
        father.Subplatforms.Add(youngerChild)

        olderChild.Subplatforms = New List(Of Platform)()
        olderChild.Subplatforms.Add(New Platform() With {
            .Name = Strings.NameBart
        })
        olderChild.Subplatforms.Add(New Platform() With {
            .Name = Strings.NameLisa
        })
        olderChild.Subplatforms.Add(New Platform() With {
            .Name = Strings.NameMaggie
        })

        youngerChild.Subplatforms = New List(Of Platform)()
        youngerChild.Subplatforms.Add(New Platform() With {
            .Name = Strings.NameLing
        })

        ' set to orgchart
        c1OrgChart1.Header = father
    End Sub

End Class

Public Class Platform
    Public Property Name() As String
    Public Property Subplatforms() As IList(Of Platform)
End Class