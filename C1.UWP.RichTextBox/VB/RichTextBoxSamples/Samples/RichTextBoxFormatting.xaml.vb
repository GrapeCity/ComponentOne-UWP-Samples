Imports Windows.UI.Text
Imports C1.Xaml.RichTextBox.Documents
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

Partial Public NotInheritable Class RichTextBoxFormatting
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Loaded, AddressOf RichTextBoxFormatting_Loaded
    End Sub

    Sub RichTextBoxFormatting_Loaded(sender As Object, e As RoutedEventArgs)
        rtb.Document.Children(0).Children(1).Children(1).Children(0).Children(0).FontWeight = FontWeights.Bold
        TryCast(rtb.Document.Children(0).Children(3).Children(1).Children(4).Children(1), C1Table).Columns(0).Width = New C1Length(50, C1LengthUnitType.Percent)
        TryCast(rtb.Document.Children(0).Children(3).Children(1).Children(4).Children(1), C1Table).Columns(1).Width = New C1Length(50)
    End Sub
End Class