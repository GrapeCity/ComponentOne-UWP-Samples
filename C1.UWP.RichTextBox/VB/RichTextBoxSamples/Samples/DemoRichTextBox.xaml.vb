Imports C1.Xaml
Imports RichTextBoxSamples.Tools
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports Windows.UI
Imports Windows.UI.Text
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class DemoRichTextBox
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()

        Dim asm As Assembly = GetType(DemoRichTextBox).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("RichTextBoxSamples.simple.htm")
        Dim sr As StreamReader = New StreamReader(stream)
        Dim html As String = sr.ReadToEnd()
        rtb.Html = html
        AddHandler rtb.PointerPressed, AddressOf rtb_PointerPressed
    End Sub

    Private Sub rtb_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        rtbMenu.Show(rtb, e.GetCurrentPoint(rtb).Position)
    End Sub

    Private Sub rtb_RequestNavigate(sender As Object, e As RequestNavigateEventArgs)
        Dim md As New MessageDialog(String.Concat(Strings.NavigateMessage, e.Hyperlink.NavigateUri, Strings.Navigate))

        md.Commands.Add(New UICommand(Strings.Ok, Function(UICommandInvokedHandler)
                                                      Windows.System.Launcher.LaunchUriAsync(e.Hyperlink.NavigateUri)
                                                  End Function))

        md.Commands.Add(New UICommand(Strings.Cancel, Function(UICommandInvokedHandler)
                                                          rtb.Select(e.Hyperlink.ContentStart.TextOffset, e.Hyperlink.ContentRange.Text.Length)
                                                      End Function))

        md.ShowAsync()
    End Sub
End Class