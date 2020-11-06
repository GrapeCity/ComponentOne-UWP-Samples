Imports System.Threading.Tasks
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
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Input
Imports C1.Xaml

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class TagEditor
    Inherits Page
    Private _changedSelectedItemsInternal As Boolean

    Private m_toggleSwitchCommand As PaneToggleSwitchCommand

    Public ReadOnly Property Mails() As List(Of Mail)
        Get
            Return DataProvider.GetProvider().MailList
        End Get
    End Property

    Private _filterItems As New List(Of Mail)()

    Public Sub New()
        Me.InitializeComponent()
        If AppHelper.IsWindowsPhoneDevice() Then
            RootView.OpenPaneLength = Window.Current.Bounds.Width
            FontSize = 12
        End If
        _changedSelectedItemsInternal = False
    End Sub

    Public ReadOnly Property ToggleSwitchCommand() As PaneToggleSwitchCommand
        Get
            If m_toggleSwitchCommand Is Nothing Then
                m_toggleSwitchCommand = New PaneToggleSwitchCommand()
            End If
            Return m_toggleSwitchCommand
        End Get
    End Property

    Private Sub OnAddressEditorKeyDown(sender As Object, e As KeyRoutedEventArgs)
        If e.Key = Windows.System.VirtualKey.Escape Then
            SuggestListPopup.IsOpen = False
        End If
    End Sub

    Private Sub OnAddressEditorLostFocus(sender As Object, e As RoutedEventArgs)
        SuggestListPopup.IsOpen = False
    End Sub

    Private Sub OnAddressEditorEditing(sender As Object, e As TagEidtorEditingEventArgs)
        If String.IsNullOrEmpty(e.Text) Then
            SuggestListPopup.IsOpen = False
        Else
            DoFilter(e.Text)
        End If
    End Sub

    Private Sub OnListBoxSelectionChanged(sender As Object, e As SelectionChangedEventArgs(Of Integer))
        If _changedSelectedItemsInternal Then
            Return
        End If
        For Each index As Integer In e.AddedItems
            Dim item As Mail = CType(ContactList.Items(index), Mail)
            _changedSelectedItemsInternal = True
            AddressEditor.InsertTag(item.Name)
            AddressEditor.SetEditorText(String.Empty)
            _changedSelectedItemsInternal = False
            AddressEditor.Focus(FocusState.Programmatic)
        Next
        For Each index As Integer In e.RemovedItems
            Dim item As Mail = CType(ContactList.Items(index), Mail)
            _changedSelectedItemsInternal = True
            RemoveTagByName(item.Name)
            _changedSelectedItemsInternal = False
        Next
    End Sub

    Private Sub OnAddressEditorTagInserted(sender As Object, e As RoutedEventArgs)
        If _changedSelectedItemsInternal Then
            Return
        End If
        SuggestListPopup.IsOpen = False
        Dim addedTag As C1Tag = TryCast(sender, C1Tag)
        If addedTag IsNot Nothing Then
            Dim addIndex As Integer = MyIndexOf(CType(addedTag.Content, String))
            If addIndex >= 0 Then
                Dim addMail As Mail = Mails(addIndex)
                Dim selectedItems As Object() = TryCast(ContactList.SelectedItems, Object())
                Dim list As List(Of Object) = If(selectedItems Is Nothing, New List(Of Object)(), selectedItems.ToList())
                list.Add(addMail)
                _changedSelectedItemsInternal = True
                ContactList.SelectedItems = list.ToArray()
                _changedSelectedItemsInternal = False
            End If
        End If
    End Sub

    Private Sub OnAddressEditorTagRemoved(sender As Object, e As RoutedEventArgs)
        If _changedSelectedItemsInternal Then
            Return
        End If
        Dim removeTag As C1Tag = TryCast(sender, C1Tag)
        If removeTag IsNot Nothing Then
            Dim removeIndex As Integer = MyIndexOf(CType(removeTag.Content, String))
            If removeIndex >= 0 Then
                Dim removeMail As Mail = Mails(removeIndex)
                Dim selectedItems As Object() = TryCast(ContactList.SelectedItems, Object())
                Dim list As List(Of Object) = selectedItems.ToList()
                list.Remove(removeMail)
                _changedSelectedItemsInternal = True
                ContactList.SelectedItems = list.ToArray()
                _changedSelectedItemsInternal = False
            End If
        End If
    End Sub

    Private Sub RemoveTagByName(value As String)
        Dim removeIndex As Integer = -1
        Dim index As Integer = 0
        While index < AddressEditor.Tags.Count
            Dim tagContent As String = CType(AddressEditor.Tags(index).Content, String)
            If tagContent = value Then
                removeIndex = index
                Exit While
            End If
            index += 1
        End While
        If removeIndex > -1 Then
            AddressEditor.RemoveTagAt(removeIndex)
        End If
    End Sub

    Private Sub OnItemTapped(sender As Object, e As C1TappedEventArgs)
        e.Handled = True
        SuggestListPopup.IsOpen = False
        Dim item As C1ListBoxItem = TryCast(sender, C1ListBoxItem)
        Dim mail As Mail = TryCast(item.Content, Mail)
        If mail IsNot Nothing AndAlso mail.Name IsNot Nothing Then
            Dim tag As String = mail.Name.Trim()
            If Not String.IsNullOrEmpty(tag) AndAlso Not AddressEditor.Text.Contains(tag) Then
                ' add new tag
                AddressEditor.InsertTag(tag)
                AddressEditor.SetEditorText(String.Empty)
                AddressEditor.Focus(FocusState.Programmatic)
                Dim selectedMail As Mail = Mails(MyIndexOf(tag))
                _changedSelectedItemsInternal = True
                If ContactList.SelectedItems Is Nothing Then
                    Dim selectedItems As Object() = New Object() {selectedMail}
                    ContactList.SelectedItems = selectedItems
                Else
                    Dim selectedItems As Object() = TryCast(ContactList.SelectedItems, Object())
                    Dim list As List(Of Object) = selectedItems.ToList()
                    list.Add(selectedMail)
                    ContactList.SelectedItems = list.ToArray()
                End If
                _changedSelectedItemsInternal = False
            End If
        End If
    End Sub

    Private Sub OnSuggestListPopupClosed(sender As Object, e As Object)
        SuggestList.ItemsSource = Nothing
    End Sub

    Private Sub DoFilter(text As String)
        _filterItems.Clear()
        For Each item As Mail In Mails
            If CanAddInFilterList(item, text) Then
                _filterItems.Add(item)
            End If
        Next
        If _filterItems.Count > 0 Then
            SuggestList.ItemsSource = Nothing
            SuggestList.ItemsSource = _filterItems
        End If
        SuggestListPopup.IsOpen = _filterItems.Count > 0
    End Sub

    Private Function CanAddInFilterList(mail As Mail, text As String) As Boolean
        Dim isStartWith As Boolean = mail.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase) OrElse mail.Address.StartsWith(text, StringComparison.OrdinalIgnoreCase)
        If ContactList.SelectedItems Is Nothing Then
            Return isStartWith
        Else
            Dim selectedItems As Object() = TryCast(ContactList.SelectedItems, Object())
            Return isStartWith AndAlso Not selectedItems.Contains(mail)
        End If
    End Function

    Private Function MyIndexOf(value As String) As Integer
        Dim i As Integer = 0
        While i < Mails.Count
            If Mails(i).Name.Equals(value, StringComparison.OrdinalIgnoreCase) OrElse Mails(i).Address.Equals(value, StringComparison.OrdinalIgnoreCase) Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Private Async Sub OnSendClick(sender As Object, e As RoutedEventArgs)
        If Await VerifyMailAsync() Then
            Dim names As New List(Of String)()
            For Each tag As C1Tag In AddressEditor.Tags
                names.Add(CType(tag.Content, String))
            Next
            ToastNotificationsHelper.ShowToastNotification(SubjectText.Text, names.ToArray())
        End If
    End Sub

    Private Async Function VerifyMailAsync() As Task(Of Boolean)
        If AddressEditor.Tags.Count = 0 Then
            Dim emptyToErrorDialog As New ContentDialog()
            emptyToErrorDialog.Title = Strings.ErrorTitle
            emptyToErrorDialog.Content = Strings.EmptyToError
            emptyToErrorDialog.PrimaryButtonText = Strings.ButtonOK
            Await emptyToErrorDialog.ShowAsync()
            Return False
        End If
        If String.IsNullOrEmpty(SubjectText.Text) Then
            Dim emptyToErrorDialog As New ContentDialog()
            emptyToErrorDialog.Title = Strings.ErrorTitle
            emptyToErrorDialog.Content = Strings.NoSubjectError
            emptyToErrorDialog.PrimaryButtonText = Strings.ButtonDontSend
            emptyToErrorDialog.SecondaryButtonText = Strings.ButtonSandAnyway
            Dim result As ContentDialogResult = Await emptyToErrorDialog.ShowAsync()
            Return result.Equals(ContentDialogResult.Secondary)
        End If
        Return True
    End Function
End Class