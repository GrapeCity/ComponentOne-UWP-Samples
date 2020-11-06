using C1.Xaml;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
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

namespace RichTextBoxSamples
{
    public sealed partial class DemoRtfFilter : Page
    {
        public DemoRtfFilter()
        {
            this.InitializeComponent();

            richTextBox.Html = html;
        }

        private void C1TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var oldItem = e.RemovedItems.OfType<C1TabItem>().FirstOrDefault();
                if (oldItem == null) return; // items are null the first time around because InitializeComponent is running

                if (htmlTab == null)
                    htmlTab = this.FindName("htmlTab") as C1TabItem;
                if (rtfTab == null)
                    rtfTab = this.FindName("rtfTab") as C1TabItem;
                if (htmlBox == null)
                    htmlBox = this.FindName("htmlBox") as C1RichTextBox;
                if (rtfBox == null)
                    rtfBox = this.FindName("rtfBox") as C1RichTextBox;

                if (oldItem == richTextBoxTab)
                {
                    htmlBox.Text = richTextBox.Html;
                    rtfBox.Text = new RtfFilter().ConvertFromDocument(richTextBox.Document);
                }
                else if (oldItem == htmlTab)
                {
                    richTextBox.Html = htmlBox.Text;
                    rtfBox.Text = new RtfFilter().ConvertFromDocument(richTextBox.Document);
                }
                else if (oldItem == rtfTab)
                {
                    richTextBox.Document = new RtfFilter().ConvertToDocument(rtfBox.Text);
                    htmlBox.Text = richTextBox.Html;
                }
            }
            catch { }
        }

        string html = Strings.RtfSample;
    }
}
