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
Partial Public NotInheritable Class TemplateSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        CreateData()
    End Sub

    Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' create new data
        CreateData()
    End Sub

    Sub CreateData()
        Dim p As Person
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            p = Person.CreatePerson(3)
        Else
            p = Person.CreatePerson(5)
        End If
        c1OrgChart1.Header = p
    End Sub

    Private Sub comboOrientation_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If c1OrgChart1 Is Nothing Then
            Return
        End If
        If comboOrientation IsNot Nothing Then
            If comboOrientation.SelectedIndex = 0 Then
                c1OrgChart1.Orientation = Orientation.Horizontal
            Else
                c1OrgChart1.Orientation = Orientation.Vertical
            End If
        End If
    End Sub
End Class