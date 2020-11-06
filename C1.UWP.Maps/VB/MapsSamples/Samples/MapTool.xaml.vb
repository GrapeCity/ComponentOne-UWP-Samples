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
Imports C1.Xaml.Maps

Partial Public NotInheritable Class MapTool
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
        Me.DataContext = Me
    End Sub

    Public Shared ReadOnly MapsProperty As DependencyProperty = DependencyProperty.Register("Maps", GetType(C1Maps), GetType(MapTool), Nothing)
    Public Property Maps() As C1Maps
        Get
            Return CType(Me.GetValue(MapsProperty), C1Maps)
        End Get
        Set
            Me.SetValue(MapsProperty, Value)
        End Set
    End Property
End Class