Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports System.Reflection
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class FindAndReplace
    Inherits Page
    Private _listStart As List(Of Integer) = Nothing
    Private _findIndex As Integer = 0
    Private _rangeStyles As C1RangeStyleCollection = Nothing
    Private _highlightStyle As C1TextElementStyle = Nothing

    Public Sub New()
        Me.InitializeComponent()
        rtb.Text = Strings.Find
        AddHandler rtb.ContextMenuOpening, AddressOf rtb_ContextMenuOpening
        AddHandler rtb.Tapped, AddressOf rtb_Tapped
        _listStart = New List(Of Integer)()
        _rangeStyles = New C1RangeStyleCollection()

        _highlightStyle = New C1TextElementStyle()
        _highlightStyle(C1TextElement.BackgroundProperty) = New SolidColorBrush(Colors.Yellow)
    End Sub

#Region "event handler"
    Sub rtb_ContextMenuOpening(sender As Object, e As C1.Xaml.RichTextBox.ContextMenuOpeningEventArgs)
        e.Handled = True
    End Sub

    Sub rtb_Tapped(sender As Object, e As TappedRoutedEventArgs)
        If rtb.ContextMenu IsNot Nothing AndAlso TypeOf rtb.ContextMenu Is IC1ContextMenu Then
            TryCast(rtb.ContextMenu, IC1ContextMenu).Show(rtb, e.GetPosition(rtb))
        End If
    End Sub
    Private Sub txtFindText_TextChanged(sender As Object, e As TextChangedEventArgs)
        ClearAll()
        rtb.Selection = New C1TextRange(rtb.Document.ContentStart)
        If Not [String].IsNullOrEmpty(txtFindText.Text) Then
            FindText()
        End If
    End Sub
    Private Sub btnPrevious_Click(sender As Object, e As RoutedEventArgs)
        _findIndex = If(_findIndex <= 0, _listStart.Count - 1, _findIndex - 1)
        rtb.[Select](_listStart(_findIndex), txtFindText.Text.Length)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As RoutedEventArgs)
        _findIndex = If(_findIndex >= _listStart.Count - 1, 0, _findIndex + 1)
        rtb.[Select](_listStart(_findIndex), txtFindText.Text.Length)
    End Sub

    Private Sub btnReplaceAll_Click(sender As Object, e As RoutedEventArgs)
        Using New DocumentHistoryGroup(rtb.DocumentHistory)
            Dim i As Integer = _rangeStyles.Count - 1
            While i > -1
                _rangeStyles(i).Range.Text = tbxReplaceText.Text
                i -= 1
            End While
        End Using
        ClearAll()
        rtb.Selection = New C1TextRange(rtb.Document.ContentStart)
    End Sub

    Private Sub btnReplace_Click(sender As Object, e As RoutedEventArgs)
        Using New DocumentHistoryGroup(rtb.DocumentHistory)
            _rangeStyles.RemoveAt(_findIndex)
            rtb.SelectedText = tbxReplaceText.Text
        End Using
        ClearAll()
        FindText()
    End Sub
#End Region

#Region "implemention"
    Sub ClearAll()
        _rangeStyles.Clear()
        _listStart.Clear()
        _findIndex = 0
        btnPrevious.IsEnabled = False
        btnNext.IsEnabled = False
        tbxReplaceText.IsEnabled = False
        btnReplace.IsEnabled = False
        btnReplaceAll.IsEnabled = False
    End Sub

    Sub FindText()
        Dim textFound As Boolean = True
        Do
            Dim index As Integer = rtb.FindText(txtFindText.Text)
            If index < 0 OrElse _listStart.Contains(index) Then
                textFound = False
            Else
                _listStart.Add(index)
                _rangeStyles.Add(New C1RangeStyle(rtb.Selection, _highlightStyle))
            End If
        Loop While textFound

        If _listStart.Count > 0 Then
            rtb.StyleOverrides.Add(_rangeStyles)
            tbxReplaceText.IsEnabled = True
            btnReplace.IsEnabled = True
            btnReplaceAll.IsEnabled = True
            If _listStart.Count > 1 Then
                btnPrevious.IsEnabled = True
                btnNext.IsEnabled = True
            End If
        End If
    End Sub
#End Region
End Class