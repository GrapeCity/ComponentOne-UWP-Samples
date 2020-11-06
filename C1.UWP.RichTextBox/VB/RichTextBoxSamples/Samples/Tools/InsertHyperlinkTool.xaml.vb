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
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox

Partial Public NotInheritable Class InsertHyperlinkTool
    Inherits UserControl
    Public Property Popup() As Flyout

    Public Property RichTextBox() As C1RichTextBox

    Public Sub New()
        Me.InitializeComponent()

        ' init flyout
        Popup = New Flyout()
        Popup.Content = Me
        Popup.Placement = FlyoutPlacementMode.Bottom
    End Sub

    Public Sub Show(placementTarget As FrameworkElement)
        ' set url text
        txtText.Text = RichTextBox.Selection.Text

        ' set url if opening existing hyperlink
        If RichTextBox.Selection.Html.Contains("<a") AndAlso RichTextBox.Selection.Html.Contains("href") Then
            ' parse out the href part
            Dim i As Integer = RichTextBox.Selection.Html.IndexOf("href")
            Dim j As String = RichTextBox.Selection.Html.Substring(i)
            Dim k As Integer = j.IndexOf(""""c)
            Dim l As String = j.Substring(k + 1)

            txtUrl.Text = l.Substring(0, l.IndexOf(""""c))
            ' this isn't necessary
            'txtUrl.Text = "http://";
        Else
        End If

        Popup.ShowAt(placementTarget)
    End Sub

    Public Sub Close()
        Popup.Hide()
    End Sub

    Private Sub btnInsertHyperlink_Click(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrEmpty(txtUrl.Text) OrElse String.IsNullOrEmpty(txtText.Text) Then
            Return
        End If

        Dim uri As Uri = Nothing
        Try
            uri = New Uri(txtUrl.Text, UriKind.Absolute)
        Catch exp As FormatException
            Try
                uri = New Uri("http://" + txtUrl.Text, UriKind.Absolute)
            Catch exp1 As FormatException
                Dim dialog As New MessageDialog(Strings.UnValidUrlMessage, Strings.[Error])
                dialog.ShowAsync()
                Return
            End Try
        End Try

        Using New DocumentHistoryGroup(RichTextBox.DocumentHistory)
            Dim text As String = txtText.Text.Replace(vbCr & vbLf, vbLf)
            If RichTextBox.Selection.Text <> text Then
                RichTextBox.Selection.Delete()
                Dim run As New C1Run() With {
                    .Text = txtText.Text
                }
                RichTextBox.Selection.Start.InsertInline(run)
                run.ContentRange.MakeHyperlink(uri)
                RichTextBox.Selection = run.ContentRange
            Else
                RichTextBox.Selection.MakeHyperlink(uri)
            End If
        End Using

        Close()
    End Sub
End Class