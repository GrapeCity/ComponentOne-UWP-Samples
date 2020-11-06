using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Windows.UI.Text;
using Windows.UI;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using RichTextBoxSamples.Tools;
using C1.Xaml;

namespace RichTextBoxSamples
{
    public sealed partial class DemoRichTextBox : Page
    {
        public DemoRichTextBox()
        {
            this.InitializeComponent();

            Assembly asm = typeof(DemoRichTextBox).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("RichTextBoxSamples.Resources.simple.htm");
            var html = new StreamReader(stream).ReadToEnd();
            rtb.Html = html;
            rtb.PointerPressed += rtb_PointerPressed;
        }

        void rtb_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            rtbMenu.Show(rtb, e.GetCurrentPoint(rtb).Position);
        }


        private void cmbLineNumberMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rtb == null)
            {
                return;
            }
            switch(cmbLineNumberMode.SelectedIndex)
            {
                case 1:
                    rtb.LineNumberMode = TextLineNumberMode.Continuous;
                    break;
                case 2:
                    rtb.LineNumberMode = TextLineNumberMode.RestartEachPage;
                    break;
                default:
                    rtb.LineNumberMode = TextLineNumberMode.None;
                    break;
            }
        }

        private void rtb_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var md = new MessageDialog(Strings.NavigateMessage + e.Hyperlink.NavigateUri, Strings.Navigate);

            md.Commands.Add(new UICommand(Strings.Ok, (UICommandInvokedHandler) =>
            {
                Windows.System.Launcher.LaunchUriAsync(e.Hyperlink.NavigateUri);
            }));

            md.Commands.Add(new UICommand(Strings.Cancel, (UICommandInvokedHandler) =>
            {
                rtb.Select(e.Hyperlink.ContentStart.TextOffset, e.Hyperlink.ContentRange.Text.Length);
            }));

            md.ShowAsync();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
