using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RichTextBoxSamples.Tools
{
    public sealed partial class InsertHyperlinkTool : UserControl
    {
        public Flyout Popup
        {
            get;
            set;
        }

        public C1RichTextBox RichTextBox
        {
            get;
            set;
        }

        public InsertHyperlinkTool()
        {
            this.InitializeComponent();

            // init flyout
            Popup = new Flyout();
            Popup.Content = this;
            Popup.Placement = FlyoutPlacementMode.Bottom;
        }

        public void Show(FrameworkElement placementTarget)
        {
            // set url text
            txtText.Text = RichTextBox.Selection.Text;

            // set url if opening existing hyperlink
            if (RichTextBox.Selection.Html.Contains("<a") && RichTextBox.Selection.Html.Contains("href"))
            {
                // parse out the href part
                int i = RichTextBox.Selection.Html.IndexOf("href");
                string j = RichTextBox.Selection.Html.Substring(i);
                int k = j.IndexOf('"');
                string l = j.Substring(k + 1);

                txtUrl.Text = l.Substring(0, l.IndexOf('"'));
            }
            else
            {
                // this isn't necessary
                //txtUrl.Text = "http://";
            }

            Popup.ShowAt(placementTarget);
        }

        public void Close()
        {
            Popup.Hide();
        }

        private void btnInsertHyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrl.Text) || string.IsNullOrEmpty(txtText.Text))
                return;

            Uri uri = null;
            try
            {
                uri = new Uri(txtUrl.Text, UriKind.Absolute);
            }
            catch (FormatException)
            {
                try
                {
                    uri = new Uri("http://" + txtUrl.Text, UriKind.Absolute);
                }
                catch (FormatException)
                {
                    MessageDialog dialog = new MessageDialog(Strings.UnValidUrlMessage, Strings.Error);
                    dialog.ShowAsync();
                    return;
                }
            }

            using (new DocumentHistoryGroup(RichTextBox.DocumentHistory))
            {
                var text = txtText.Text.Replace("\r\n", "\n");
                if (RichTextBox.Selection.Text != text)
                {
                    RichTextBox.Selection.Delete();
                    var run = new C1Run() { Text = txtText.Text };
                    RichTextBox.Selection.Start.InsertInline(run);
                    run.ContentRange.MakeHyperlink(uri);
                    RichTextBox.Selection = run.ContentRange;
                }
                else
                {
                    RichTextBox.Selection.MakeHyperlink(uri);
                }
            }

            Close();
        }
    }
}
