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

Partial Public NotInheritable Class Text
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        Me.DataContext = e.Parameter
        MyBase.OnNavigatedTo(e)
    End Sub
End Class