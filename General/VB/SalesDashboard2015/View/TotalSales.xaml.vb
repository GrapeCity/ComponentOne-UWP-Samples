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

' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class TotalSales
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dataSource As DataModel.SampleDataSource = TryCast(Me.DataContext, DataModel.SampleDataSource)
        If dataSource IsNot Nothing Then
            Dim totalSales As Double = dataSource.TotalSales / 1000
            gauge.Value = totalSales
            runTotal.Text = totalSales.ToString()
        End If
    End Sub
End Class