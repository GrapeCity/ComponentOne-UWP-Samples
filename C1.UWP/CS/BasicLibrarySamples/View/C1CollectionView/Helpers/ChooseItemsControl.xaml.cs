using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace BasicLibrarySamples
{
    public sealed partial class ChooseItemsControl : UserControl
    {
        private IList<string> _fieldNames = null;
        private readonly ObservableCollection<string> _fieldNamesInternal = new ObservableCollection<string>();
        private readonly ObservableCollection<string> _selectedFieldNamesInternal = new ObservableCollection<string>();
        private bool _suppressNotifications = false;
        
        public ChooseItemsControl()
        {
            this.InitializeComponent();

            allListBox.ItemsSource = FieldNamesInternal;
            selectedListBox.ItemsSource = SelectedFieldNamesInternal;
            _selectedFieldNamesInternal.CollectionChanged += SelectedFieldNamesInternal_CollectionChanged;
        }

        public IList<string> FieldNames
        {
            get { return _fieldNames; }
            set
            {
                int selCount = _selectedFieldNamesInternal.Count;
                _suppressNotifications = true;
                try
                {
                    _fieldNamesInternal.Clear();
                    _selectedFieldNamesInternal.Clear();
                    _fieldNames = value;
                    if (_fieldNames != null)
                    {
                        List<string> items = new List<string>(_fieldNames);
                        items.Sort();
                        foreach (string s in items)
                            _fieldNamesInternal.Add(s);
                    }
                }
                finally
                {
                    _suppressNotifications = false;
                    if (selCount > 0)
                        OnSelectedFieldNamesChanged();
                }
            }
        }

        public IList<string> SelectedFieldNames
        {
            get { return _selectedFieldNamesInternal; }
        }

        public event EventHandler<EventArgs> SelectedFieldNamesChanged;

        private ObservableCollection<string> FieldNamesInternal
        {
            get { return _fieldNamesInternal; }
        }

        private ObservableCollection<string> SelectedFieldNamesInternal
        {
            get { return _selectedFieldNamesInternal; }
        }

        private void OnSelectedFieldNamesChanged()
        {
            if (SelectedFieldNamesChanged != null)
                SelectedFieldNamesChanged(this, EventArgs.Empty);
        }

        void SelectedFieldNamesInternal_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotifications)
                OnSelectedFieldNamesChanged();
        }

        private void UpdateAllFieldsButtonsState()
        {
            selectButton.IsEnabled = allListBox.SelectedItem != null;
        }

        private void UpdateSelectedFieldsButtonsState()
        {
            unselectButton.IsEnabled = selectedListBox.SelectedItem != null;
            bool isEnabled = selectedListBox.Items.Count > 1 && selectedListBox.SelectedItem != null;
            upButton.IsEnabled = IsEnabled && selectedListBox.SelectedIndex > 0;
            downButton.IsEnabled = IsEnabled && selectedListBox.SelectedIndex < selectedListBox.Items.Count - 1;
        }

        private void Select()
        {
            if (allListBox.SelectedItem != null)
            {
                _selectedFieldNamesInternal.Add((string)allListBox.SelectedItem);
                selectedListBox.SelectedItem = allListBox.SelectedItem;
                int idx = allListBox.SelectedIndex;
                _fieldNamesInternal.Remove((string)allListBox.SelectedItem);
                if (allListBox.Items.Count > 0)
                    allListBox.SelectedIndex = Math.Min(idx, allListBox.Items.Count - 1);
            }
        }

        private void Unselect()
        {
            string selItem = (string)selectedListBox.SelectedItem;
            if (selItem != null)
            {
                List<string> list = new List<string>(_fieldNamesInternal);
                list.Add(selItem);
                list.Sort();
                _fieldNamesInternal.Clear();
                foreach (string s in list)
                    _fieldNamesInternal.Add(s);
                allListBox.SelectedItem = selItem;
                int idx = selectedListBox.SelectedIndex;
                _selectedFieldNamesInternal.Remove((string)selectedListBox.SelectedItem);
                if (selectedListBox.Items.Count > 0)
                    selectedListBox.SelectedIndex = Math.Min(idx, selectedListBox.Items.Count - 1);
            }
        }

        private void MoveUp()
        {
            int idx = selectedListBox.SelectedIndex;
            if (idx > 0)
            {
                _selectedFieldNamesInternal.Move(idx, idx - 1);
                selectedListBox.SelectedIndex = idx - 1;
            }
        }

        private void MoveDown()
        {
            int idx = selectedListBox.SelectedIndex;
            if (idx >= 0 && idx < _selectedFieldNamesInternal.Count - 1)
            {
                _selectedFieldNamesInternal.Move(idx, idx + 1);
                selectedListBox.SelectedIndex = idx + 1;
            }
        }

        private void allListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateAllFieldsButtonsState();
        }

        private void selectedListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedFieldsButtonsState();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void unselectButton_Click(object sender, RoutedEventArgs e)
        {
            Unselect();
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            MoveUp();
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            MoveDown();
        }

        private void allListBox_DoubleTapped_1(object sender, DoubleTappedRoutedEventArgs e)
        {
            Select();
        }

        private void selectedListBox_DoubleTapped_1(object sender, DoubleTappedRoutedEventArgs e)
        {
            Unselect();
        }

    }

}
