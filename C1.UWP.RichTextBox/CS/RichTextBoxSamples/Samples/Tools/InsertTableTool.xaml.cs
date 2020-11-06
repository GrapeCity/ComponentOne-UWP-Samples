using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RichTextBoxSamples.Tools
{
    public sealed partial class InsertTableTool : UserControl
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

        public InsertTableTool()
        {
            this.InitializeComponent();

            // init flyout
            Popup = new Flyout();
            Popup.Content = this;
            Popup.Placement = FlyoutPlacementMode.Top;
        }

        public void Show(FrameworkElement placementTarget)
        {
            Popup.ShowAt(placementTarget);
        }

        public void Close()
        {
            Popup.Hide();
        }

        private void btnInsertTable_Click(object sender, RoutedEventArgs e)
        {
            int rows = (int)numRowsBox.Value;
            int cols = (int)numColsBox.Value;
            if (RichTextBox != null && rows > 0 && cols > 0)
                RichTextBox.Selection.Start.InsertTable(rows, cols);
            Close();
        }
    }
}
