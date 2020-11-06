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
using C1.Xaml.RichTextBox.Documents;
using Windows.UI.Text;

namespace RichTextBoxSamples
{
    public sealed partial class RichTextBoxFormatting : Page
    {
        public RichTextBoxFormatting()
        {
            this.InitializeComponent();
            this.Loaded += RichTextBoxFormatting_Loaded;
        }

        void RichTextBoxFormatting_Loaded(object sender, RoutedEventArgs e)
        {
            rtb.Document.Children[0].Children[1].Children[1].Children[0].Children[0].FontWeight = FontWeights.Bold;
            ((C1Table)(rtb.Document.Children[0].Children[3].Children[1].Children[4].Children[1])).Columns[0].Width = new C1Length(50, C1LengthUnitType.Percent);
            ((C1Table)(rtb.Document.Children[0].Children[3].Children[1].Children[4].Children[1])).Columns[1].Width = new C1Length(50);
        }
    }
}
