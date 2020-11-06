using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using C1.Xaml;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;

namespace RichTextBoxSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FindAndReplace : Page
    {
        List<int> _listStart = null;
        int _findIndex = 0;
        C1RangeStyleCollection _rangeStyles = null;
        C1TextElementStyle _highlightStyle = null;

        public FindAndReplace()
        {
            this.InitializeComponent();
            rtb.Text = Strings.Find;
            rtb.ContextMenuOpening += rtb_ContextMenuOpening;
            rtb.Tapped += rtb_Tapped;
            _listStart = new List<int>();
            _rangeStyles = new C1RangeStyleCollection();

            _highlightStyle = new C1TextElementStyle();
            _highlightStyle[C1TextElement.BackgroundProperty] = new SolidColorBrush(Colors.Yellow);
        }

        #region event handler
        void rtb_ContextMenuOpening(object sender, C1.Xaml.RichTextBox.ContextMenuOpeningEventArgs e)
        {
            e.Handled = true;
        }

        void rtb_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (rtb.ContextMenu != null && rtb.ContextMenu is IC1ContextMenu)
            {
                (rtb.ContextMenu as IC1ContextMenu).Show(rtb, e.GetPosition(rtb));
            }
        }
        private void txtFindText_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearAll();
            rtb.Selection = new C1TextRange(rtb.Document.ContentStart);
            if (!String.IsNullOrEmpty(txtFindText.Text))
            {
                FindText();
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            _findIndex = _findIndex <= 0 ? _listStart.Count - 1 : _findIndex - 1;
            rtb.Select(_listStart[_findIndex], txtFindText.Text.Length);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _findIndex = _findIndex >= _listStart.Count - 1 ? 0 : _findIndex + 1;
            rtb.Select(_listStart[_findIndex], txtFindText.Text.Length);
        }

        private void btnReplaceAll_Click(object sender, RoutedEventArgs e)
        {
            using (new DocumentHistoryGroup(rtb.DocumentHistory))
            {
                for (int i = _rangeStyles.Count - 1; i > -1; i--)
                {
                    _rangeStyles[i].Range.Text = tbxReplaceText.Text;
                }                
            }
            ClearAll();
            rtb.Selection = new C1TextRange(rtb.Document.ContentStart);
        }

        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            using (new DocumentHistoryGroup(rtb.DocumentHistory))
            {
                _rangeStyles.RemoveAt(_findIndex);
                rtb.SelectedText = tbxReplaceText.Text;
            }
            ClearAll();
            FindText();
        }
        #endregion

        #region implemention
        void ClearAll()
        {
            _rangeStyles.Clear();
            _listStart.Clear();
            _findIndex = 0;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            tbxReplaceText.IsEnabled = false;
            btnReplace.IsEnabled = false;
            btnReplaceAll.IsEnabled = false;
        }

        void FindText()
        {
            bool textFound = true;
            do
            {
                int index = rtb.FindText(txtFindText.Text);
                if (index < 0 || _listStart.Contains(index))
                    textFound = false;
                else
                {
                    _listStart.Add(index);
                    _rangeStyles.Add(new C1RangeStyle(rtb.Selection, _highlightStyle));
                }
            } while (textFound);

            if (_listStart.Count > 0)
            {
                rtb.StyleOverrides.Add(_rangeStyles);
                tbxReplaceText.IsEnabled = true;
                btnReplace.IsEnabled = true;
                btnReplaceAll.IsEnabled = true;
                if (_listStart.Count > 1)
                {
                    btnPrevious.IsEnabled = true;
                    btnNext.IsEnabled = true;
                }
            }
        }
        #endregion
    }
}
