using C1.Xaml;
using C1.Xaml.RichTextBox;
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

namespace RichTextBoxSamples.Tools
{
    public sealed partial class FontColorTool : UserControl
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

        public FontColorMode ColorMode
        {
            get;
            set;
        }

        public FontColorTool()
        {
            this.InitializeComponent();

            // init flyout
            Popup = new Flyout();
            Popup.Content = this;
            Popup.Placement = FlyoutPlacementMode.Bottom;

            ColorMode = FontColorMode.Foreground;
        }

        public void Show(FrameworkElement placementTarget)
        {
            Popup.ShowAt(placementTarget);
        }

        public void Close()
        {
            Popup.Hide();
        }

        private void colorListBox_ItemTapped(object sender, C1TappedEventArgs e)
        {
            C1ListBoxItem item = sender as C1ListBoxItem;
            Border b = item.Content as Border;
            if (ColorMode == FontColorMode.Background)
            {
                if (Equals(b.Background, RichTextBox.Selection.InlineBackground))
                    RichTextBox.Selection.InlineBackground = RichTextBox.Background;
                else
                    RichTextBox.Selection.InlineBackground = b.Background;
            }
            else
            {
                if (Equals(b.Background, RichTextBox.Selection.InlineBackground))
                    RichTextBox.Selection.Foreground = RichTextBox.Foreground;
                else
                    RichTextBox.Selection.Foreground = b.Background;
            }

            Close();
        }

        bool Equals(Brush source, Brush dest)
        {
            var left = source as SolidColorBrush;
            var right = dest as SolidColorBrush;
            if (left != null && right != null)
            {
                return left.Color.Equals(right.Color);
            }
            return false;
        }
    }

    public enum FontColorMode
    {
        Background,
        Foreground
    }
}
