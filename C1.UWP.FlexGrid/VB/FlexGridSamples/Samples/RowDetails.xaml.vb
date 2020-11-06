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
Imports C1.Xaml

Partial Public Class RowDetails
    Inherits Page
    Public Sub New()
        InitializeComponent()
        Dim data As Object = Customer.GetCustomerList(100)
        Dim view As New C1CollectionView(data)
        _flex.ItemsSource = view
    End Sub
End Class

