using C1.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BasicLibrarySamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AutoCompleteDropDown : Page
    {
        private bool _updating = false;
        private string _text = string.Empty;
        private string _symbol = string.Empty;
        private int _maxItems = 9;
        private Dictionary<string, string> _items;

        public AutoCompleteDropDown()
        {
            InitializeComponent();

            this.Loaded += async delegate
            {
                await LoadSymbols();
            };

            this.DropDownOpensUp = false;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                this.txt.Loaded += delegate
                {
                    var newBinding = new Binding();
                    newBinding.Path = new PropertyPath("Text");
                    newBinding.Source = this.txtSymbol;
                    newBinding.Mode = BindingMode.TwoWay;
                    newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    this.txt.SetBinding(TextBox.TextProperty, newBinding);

                    this.txt.Focus(FocusState.Programmatic);
                    this.txt.SelectionStart = this.txt.Text.Length;
                };
            }
        }

        private async Task LoadSymbols()
        {
            _items = new Dictionary<string, string>();
            string resName = "BasicLibrarySamplesLib\\Resources\\Symbols.txt";
            StorageFile txtFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(resName);
            var inputStream = await txtFile.OpenAsync(FileAccessMode.Read);
            using (StreamReader s = new StreamReader(inputStream.AsStreamForRead()))
            {
                while (!s.EndOfStream)
                {
                    string[] sn = s.ReadLine().Split('\t');
                    if (sn.Length == 2)
                        _items[sn[0]] = sn[1];
                }
            }
        }

        #region ** object model

        public bool DropDownOpensUp
        {
            get
            {
                return (searchSymbols.DropDownDirection == DropDownDirection.ForceAbove);
            }
            set
            {
                if (value)
                {
                    searchSymbols.DropDownDirection = DropDownDirection.ForceAbove;
                }
                else
                {
                    searchSymbols.DropDownDirection = DropDownDirection.ForceBelow;
                }
            }
        }

        public Dictionary<string, string> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public string Text
        {
            get { return _text; }
        }

        public string Symbol
        {
            get { return _symbol; }
        }

        public event EventHandler SelectionChange;

        #endregion

        private void txtSymbol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!_updating) && (_selectedText != txtSymbol.Text))
            {
                string text = txtSymbol.Text;
                List<string> items = BuildList(text);
                if (items.Count == 0)
                {
                    if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                        searchSymbols.IsDropDownOpen = false;
                    else
                        listBox.Items.Clear();
                }
                else
                {
                    listBox.Items.Clear();
                    foreach (string key in items)
                    {
                        listBox.Items.Add(BuildItem(text, key, _items[key]));
                    }
                    searchSymbols.IsDropDownOpen = true;
                }
            }
        }

        private void txtSymbol_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            int delta = 0;
            switch (e.Key)
            {
                case VirtualKey.Down:
                    delta = 1;
                    break;

                case VirtualKey.Up:
                    delta = -1;
                    break;

                case VirtualKey.Enter:
                    CommitListSelection();
                    break;

                case VirtualKey.Escape:
                    searchSymbols.IsDropDownOpen = false;
                    break;
            }

            int oldIndex;
            if ((_selectedItem != null) && listBox.Items.Contains(_selectedItem))
            {
                oldIndex = listBox.Items.IndexOf(_selectedItem);
            }
            else
            {
                oldIndex = (DropDownOpensUp ? listBox.Items.Count : -1);
            }
            int index = Math.Min(Math.Max(0, oldIndex + delta), listBox.Items.Count - 1);
            if ((index >= 0) && (index < listBox.Items.Count))
            {
                SelectedItem = listBox.Items[index] as ContentControl;
            }
        }

        private void txtSymbol_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                searchSymbols.IsDropDownOpen = false;
            }
        }

        private string _selectedText;
        void li_MouseLeftButtonDown(object sender, PointerRoutedEventArgs e)
        {
            SelectedItem = sender as ContentControl;
            if (SelectedItem != null)
            {
                CommitListSelection();
            }
        }

        #region ** private stuff

        // commit listbox selection

        private ContentControl _selectedItem = null;
        private ContentControl SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != null)
                {
                    (_selectedItem.Content as StackPanel).Background = new SolidColorBrush(Colors.Transparent);
                }
                _selectedItem = value;
                if (value != null)
                {
                    (value.Content as StackPanel).Background = new SolidColorBrush(Color.FromArgb(0xff, 0xb8, 0xd1, 0xe4));
                }
            }
        }

        private void CommitListSelection()
        {
            if (_selectedItem==null)
            {
                return;
            }
            StackPanel sp = (StackPanel)(_selectedItem).Content;
            if (sp != null)
            {
                // apply text to textbox, hide popup
                _updating = true;
                _symbol = (sp.Children[0] as TextBlock).Text;
                _text = (sp.Children[1] as TextBlock).Text;
                txtSymbol.Text = _symbol;
                _updating = false;

                // fire event to indicate a choice was made
                CommitSelection();

                searchSymbols.IsDropDownOpen = false;

                _selectedText = txtSymbol.Text;
                txtSymbol.Select(0, txtSymbol.Text.Length);
            }
        }

        // commit C1TextBox change
        private void CommitSelection()
        {
            if (SelectionChange != null)
            {
                SelectionChange(this, new EventArgs());
            }
        }

        // methods used for building the pick list
        private List<string> BuildList(string text)
        {
            List<string> list = new List<string>();
            if (text.Length > 0)
            {
                // add matches on symbol first
                foreach (string key in _items.Keys)
                {
                    if (key.StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        list.Add(key);
                        if (list.Count >= _maxItems)
                            break;
                    }
                }

                // add matches on name second
                foreach (string key in _items.Keys)
                {
                    if (_items[key].IndexOf(text, StringComparison.CurrentCultureIgnoreCase) > -1 &&
                        !list.Contains(key))
                    {
                        list.Add(key);
                        if (list.Count >= _maxItems)
                            break;
                    }
                }
            }
            return list;
        }

        private FrameworkElement BuildItem(string search, string key, string text)
        {
            StackPanel p = new StackPanel();
            p.Orientation = Orientation.Horizontal;
            p.Background = new SolidColorBrush(Colors.Transparent);
            p.Children.Add(BuildSubItem(search, key, 60));
            p.Children.Add(BuildSubItem(search, text, 200));

            ContentControl c = new ContentControl();
            c.PointerPressed += new PointerEventHandler(li_MouseLeftButtonDown);
            c.Content = p;

            return c;
        }

        private TextBlock BuildSubItem(string search, string text, double width)
        {
            TextBlock tb = new TextBlock();
            tb.Text = string.Empty;
            tb.Margin = new Thickness(5);

            for (int start = 0; ; )
            {
                // look for a match
                int index = text.IndexOf(search, start, StringComparison.CurrentCultureIgnoreCase);

                // match not found, add remainder and be done
                if (index < 0)
                {
                    CreateRun(tb, false, text.Substring(start));
                    break;
                }

                // match found: add regular and bold parts
                if (index > start)
                {
                    CreateRun(tb, false, text.Substring(start, index - start));
                }
                CreateRun(tb, true, text.Substring(index, search.Length));
                start = index + search.Length;
            }

            tb.Width = width;
            return tb;
        }

        private void CreateRun(TextBlock tb, bool highlight, string text)
        {
            Run run = new Run();
            run.Text = text;
            run.FontFamily = FontFamily;
            run.FontSize = FontSize;
            run.FontWeight = highlight ? FontWeights.Bold : FontWeights.Normal;
            
            tb.Inlines.Add(run);
        }

        #endregion

        
    }
}
