Imports C1.Xaml.Maps
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation

Partial Public NotInheritable Class MapTool
    Inherits UserControl

    Public Sub New()
        Me.InitializeComponent()
        Me.DataContext = Me
    End Sub

    Public Shared ReadOnly MapsProperty As DependencyProperty = DependencyProperty.Register("Maps", GetType(C1Maps), GetType(MapTool), Nothing)

    Public Property Maps As C1Maps
        Get
            Return CType(Me.GetValue(MapsProperty), C1Maps)
        End Get
        Set(ByVal value As C1Maps)
            Me.SetValue(MapsProperty, value)
        End Set
    End Property
End Class
