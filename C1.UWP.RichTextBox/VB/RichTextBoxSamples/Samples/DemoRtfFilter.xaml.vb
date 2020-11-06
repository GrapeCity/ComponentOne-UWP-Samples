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
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml

Partial Public NotInheritable Class DemoRtfFilter
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()

        richTextBox.Html = Strings.RtfSample
    End Sub

    Private Sub C1TabControl_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            Dim oldItem As C1TabItem = e.RemovedItems.OfType(Of C1TabItem)().FirstOrDefault()
            If oldItem Is Nothing Then
                Return
            End If
            ' items are null the first time around because InitializeComponent is running
            If htmlTab Is Nothing Then
                htmlTab = TryCast(Me.FindName("htmlTab"), C1TabItem)
            End If
            If rtfTab Is Nothing Then
                rtfTab = TryCast(Me.FindName("rtfTab"), C1TabItem)
            End If
            If htmlBox Is Nothing Then
                htmlBox = TryCast(Me.FindName("htmlBox"), C1RichTextBox)
            End If
            If rtfBox Is Nothing Then
                rtfBox = TryCast(Me.FindName("rtfBox"), C1RichTextBox)
            End If

            If oldItem.Equals(richTextBoxTab) Then
                htmlBox.Text = richTextBox.Html
                rtfBox.Text = New RtfFilter().ConvertFromDocument(richTextBox.Document)
            ElseIf oldItem.Equals(htmlTab) Then
                richTextBox.Html = htmlBox.Text
                rtfBox.Text = New RtfFilter().ConvertFromDocument(richTextBox.Document)
            ElseIf oldItem.Equals(rtfTab) Then
                richTextBox.Document = New RtfFilter().ConvertToDocument(rtfBox.Text)
                htmlBox.Text = RichTextBox.Html
            End If
        Catch
        End Try
    End Sub
End Class