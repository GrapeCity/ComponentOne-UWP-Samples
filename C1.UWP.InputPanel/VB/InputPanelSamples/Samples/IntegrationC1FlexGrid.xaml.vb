Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Windows.Input
Imports System
Imports Windows.UI.Xaml.Input
Imports InputPanelSamples.Common

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class IntegrationC1FlexGrid
    Inherits Page
    Private _viewDetailCommand As ICommand
    Public ReadOnly Property ViewDetailCommand() As ICommand
        Get
            Dim action As Action = AddressOf NavigateToDetails
            If _viewDetailCommand IsNot Nothing Then
                Return _viewDetailCommand
            End If
            _viewDetailCommand = New DelegateCommand(action, FlexGrid.SelectedItem IsNot Nothing)
            Return _viewDetailCommand
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            IntegrationToC1FlexGrid()
            Me.DataContext = Me
        Else
            InitalizeFlexGrid()
        End If
    End Sub

    Sub IntegrationToC1FlexGrid()
        Dim list As Object = Data.LoadEmployee()
        FlexGrid.ItemsSource = New Data().EmployeeObservable
        FlexGrid.SelectionMode = C1.Xaml.FlexGrid.SelectionMode.Row
        FlexGrid.SelectedIndex = 0
    End Sub

    Sub InitalizeFlexGrid()
        Dim list As Object = Data.Load()
        FlexGrid.ItemsSource = New Data().CustomerObservable
    End Sub

    Private Sub NavigateToDetails()
        Dim employee As Employee = TryCast(FlexGrid.SelectedItem, Employee)
        If employee IsNot Nothing Then
            Me.frame.Navigate(GetType(InputPanelCurrentItem), employee)
        End If
    End Sub
End Class