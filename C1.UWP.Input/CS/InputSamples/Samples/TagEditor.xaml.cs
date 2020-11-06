using C1.Xaml;
using C1.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InputSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TagEditor : Page
    {
        bool _changedSelectedItemsInternal;

        private PaneToggleSwitchCommand toggleSwitchCommand;

        public List<Mail> Mails { get { return DataProvider.GetProvider().MailList; } }

        private List<Mail> _filterItems = new List<Mail>();

        public TagEditor()
        {
            this.InitializeComponent();
            if (AppHelper.IsWindowsPhoneDevice())
            {
                RootView.OpenPaneLength = Window.Current.Bounds.Width;
                FontSize = 12;
            }
            _changedSelectedItemsInternal = false;
        }

        public PaneToggleSwitchCommand ToggleSwitchCommand
        {
            get
            {
                if (toggleSwitchCommand == null)
                    toggleSwitchCommand = new PaneToggleSwitchCommand();
                return toggleSwitchCommand;
            }
        }

        private void OnAddressEditorKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
                SuggestListPopup.IsOpen = false;
        }

        private void OnAddressEditorLostFocus(object sender, RoutedEventArgs e)
        {
            SuggestListPopup.IsOpen = false;
        }

        private void OnAddressEditorEditing(object sender, TagEidtorEditingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Text))
                SuggestListPopup.IsOpen = false;
            else
                DoFilter(e.Text);
        }

        private void OnListBoxSelectionChanged(object sender, SelectionChangedEventArgs<int> e)
        {
            if (_changedSelectedItemsInternal)
                return;
            foreach (int index in e.AddedItems)
            {
                Mail item = (Mail)ContactList.Items[index];
                _changedSelectedItemsInternal = true;
                AddressEditor.InsertTag(item.Name);
                AddressEditor.SetEditorText(string.Empty);
                _changedSelectedItemsInternal = false;
                AddressEditor.Focus(FocusState.Programmatic);
            }
            foreach (int index in e.RemovedItems)
            {
                Mail item = (Mail)ContactList.Items[index];
                _changedSelectedItemsInternal = true;
                RemoveTagByName(item.Name);
                _changedSelectedItemsInternal = false;
            }
        }

        private void OnAddressEditorTagInserted(object sender, RoutedEventArgs e)
        {
            if (_changedSelectedItemsInternal)
                return;
            SuggestListPopup.IsOpen = false;
            C1Tag addedTag = sender as C1Tag;
            if (addedTag != null)
            {
                int addIndex = MyIndexOf((string)addedTag.Content);
                if ( addIndex >= 0)
                {
                    Mail addMail = Mails[addIndex];
                    object[] selectedItems = ContactList.SelectedItems as object[];
                    var list = selectedItems == null ? new List<object>() : selectedItems.ToList();
                    list.Add(addMail);
                    _changedSelectedItemsInternal = true;
                    ContactList.SelectedItems = list.ToArray();
                    _changedSelectedItemsInternal = false;
                }
            }
        }

        private void OnAddressEditorTagRemoved(object sender, RoutedEventArgs e)
        {
            if (_changedSelectedItemsInternal)
                return;
            C1Tag removeTag = sender as C1Tag;
            if (removeTag != null)
            {
                int removeIndex = MyIndexOf((string)removeTag.Content);
                if (removeIndex >= 0)
                {
                    Mail removeMail = Mails[removeIndex];
                    object[] selectedItems = ContactList.SelectedItems as object[];
                    var list = selectedItems.ToList();
                    list.Remove(removeMail);
                    _changedSelectedItemsInternal = true;
                    ContactList.SelectedItems = list.ToArray();
                    _changedSelectedItemsInternal = false;
                }
            }
        }

        private void RemoveTagByName(string value)
        {
            int removeIndex = -1;
            for (int index = 0; index < AddressEditor.Tags.Count; index++)
            {
                string tagContent = (string)AddressEditor.Tags[index].Content;
                if (tagContent == value)
                {
                    removeIndex = index;
                    break;
                }
            }
            if (removeIndex > -1)
                AddressEditor.RemoveTagAt(removeIndex);
        }

        private void OnItemTapped(object sender, C1TappedEventArgs e)
        {
            e.Handled = true;
            SuggestListPopup.IsOpen = false;
            C1ListBoxItem item = sender as C1ListBoxItem;
            string tag = (item.Content as Mail)?.Name?.Trim();
            if (!string.IsNullOrEmpty(tag) && !AddressEditor.Text.Contains(tag))
            {
                // add new tag
                AddressEditor.InsertTag(tag);
                AddressEditor.SetEditorText(string.Empty);
                AddressEditor.Focus(FocusState.Programmatic);
                Mail selectedMail = Mails[MyIndexOf(tag)];
                _changedSelectedItemsInternal = true;
                if (ContactList.SelectedItems == null)
                {
                    object[] selectedItems = new object[] { selectedMail };
                    ContactList.SelectedItems = selectedItems;
                }
                else
                {
                    object[] selectedItems = ContactList.SelectedItems as object[];
                    var list = selectedItems.ToList();
                    if (!list.Contains(selectedMail))
                    {
                        list.Add(selectedMail);
                        ContactList.SelectedItems = list.ToArray();
                    }
                }
                _changedSelectedItemsInternal = false;
            }
        }

        private void OnSuggestListPopupClosed(object sender, object e)
        {
            SuggestList.ItemsSource = null;
        }

        private void DoFilter(string text)
        {
            _filterItems.Clear();
            foreach (Mail item in Mails)
            {
                if (CanAddInFilterList(item, text))
                    _filterItems.Add(item);
            }
            if (_filterItems.Count > 0)
            {
                SuggestList.ItemsSource = null;
                SuggestList.ItemsSource = _filterItems;
            }
            SuggestListPopup.IsOpen = _filterItems.Count > 0;
        }

        private bool CanAddInFilterList(Mail mail,string text)
        {
            bool isStartWith = mail.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase) || mail.Address.StartsWith(text, StringComparison.OrdinalIgnoreCase);
            if (ContactList.SelectedItems == null)
                return isStartWith;
            else
            {
                object[] selectedItems = ContactList.SelectedItems as object[];
                return isStartWith && !selectedItems.Contains(mail);
            }
        }

        private int MyIndexOf(string value)
        {
            for (int i = 0; i < Mails.Count; i++)
            {
                if (Mails[i].Name.Equals(value, StringComparison.OrdinalIgnoreCase) || Mails[i].Address.Equals(value, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        private async void OnSendClick(object sender, RoutedEventArgs e)
        {
            if(await VerifyMailAsync())
            {
                List<string> names = new List<string>();
                foreach (C1Tag tag in AddressEditor.Tags)
                    names.Add((string)tag.Content);
                ToastNotificationsHelper.ShowToastNotification(SubjectText.Text, names.ToArray());
            }
        }

        private async Task<bool> VerifyMailAsync()
        {
            if (AddressEditor.Tags.Count == 0)
            {
                ContentDialog emptyToErrorDialog = new ContentDialog();
                emptyToErrorDialog.Title = Strings.ErrorTitle;
                emptyToErrorDialog.Content = Strings.EmptyToError;
                emptyToErrorDialog.PrimaryButtonText = Strings.ButtonOK;
                await emptyToErrorDialog.ShowAsync();
                return false;
            }
            if (string.IsNullOrEmpty(SubjectText.Text))
            {
                ContentDialog emptyToErrorDialog = new ContentDialog();
                emptyToErrorDialog.Title = Strings.ErrorTitle;
                emptyToErrorDialog.Content = Strings.NoSubjectError;
                emptyToErrorDialog.PrimaryButtonText = Strings.ButtonDontSend;
                emptyToErrorDialog.SecondaryButtonText = Strings.ButtonSandAnyway;
                ContentDialogResult result = await emptyToErrorDialog.ShowAsync();
                return result.Equals(ContentDialogResult.Secondary);
            }
            return true;
        }
    }
}
