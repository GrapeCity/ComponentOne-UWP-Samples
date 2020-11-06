Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports InputPanelSamples.Common

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class InputPanelCurrentItem
    Inherits Page
    Private _backFlexGridCommand As ICommand
    Public ReadOnly Property BackFlexGridCommand() As ICommand
        Get
            Dim action As Action = AddressOf NavigateToFlexGrid
            If _backFlexGridCommand IsNot Nothing Then
                Return _backFlexGridCommand
            End If
            _backFlexGridCommand = New DelegateCommand(action, True)
            Return _backFlexGridCommand
        End Get
    End Property
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        Dim parameter As Object = e.Parameter
        If parameter IsNot Nothing Then
            Dim employee As Employee = TryCast(parameter, Employee)
            If employee IsNot Nothing Then
                InputPanel.CurrentItem = employee
            End If
        End If

    End Sub
    Private Sub NavigateToFlexGrid()
        If Me.Frame IsNot Nothing Then
            Me.Frame.Navigate(GetType(IntegrationC1FlexGrid))
        End If
    End Sub
End Class