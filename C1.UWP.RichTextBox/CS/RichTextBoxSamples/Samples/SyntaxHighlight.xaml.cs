using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RichTextBoxSamples
{
    public sealed partial class SyntaxHighlight : Page
    {
        C1RichTextBox _rtb;
        C1RangeStyleCollection _rangeStyles = new C1RangeStyleCollection();

        // initialize regular expression used to parse HTML
        string tagPattern =
            @"</?(?<tagName>[a-zA-Z0-9_:\-]+)" +
            @"(\s+(?<attName>[a-zA-Z0-9_:\-]+)(?<attValue>(=""[^""]+"")?))*\s*/?>";

        // initialize styles used to color the document
        C1TextElementStyle brDarkBlue = new C1TextElementStyle 
        { 
            { C1TextElement.ForegroundProperty, new SolidColorBrush(Color.FromArgb(255, 0, 0, 180)) }
        };
        C1TextElementStyle brDarkRed = new C1TextElementStyle 
        { 
            { C1TextElement.ForegroundProperty, new SolidColorBrush(Color.FromArgb(255, 180, 0, 0)) }
        };
        C1TextElementStyle brLightRed = new C1TextElementStyle 
        { 
            { C1TextElement.ForegroundProperty, new SolidColorBrush(Colors.Red) }
        };

        public SyntaxHighlight()
        {
            InitializeComponent();

            Loaded += SyntaxHighlight_Loaded;
        }

        void SyntaxHighlight_Loaded(object sender, RoutedEventArgs e)
        {
            if (_rtb == null)
            {
                _rtb = new C1RichTextBox
                {
                    ReturnMode = ReturnMode.SoftLineBreak,
                    TextWrapping = TextWrapping.NoWrap,
                    IsReadOnly = false,
                    Document = new C1Document
                    {
                        Background = new SolidColorBrush(Colors.White),
                        FontFamily = new FontFamily("Courier New"),
                        FontSize = 16,
                        Blocks = 
                    {
                        new C1Paragraph 
                        {
                            Children =
                            {
                                new C1Run 
                                { 
                                    Text = GetStringResource("w3c.htm")
                                },
                            },
                        }
                    }
                    },
                    StyleOverrides = { _rangeStyles }
                };
                LayoutRoot.Children.Add(_rtb);
                _rtb.TextChanged += tb_TextChanged;
                UpdateSyntaxColoring(_rtb.Document.ContentRange);
            }
        }

        void tb_TextChanged(object sender, C1TextChangedEventArgs e)
        {
            var start = e.Range.Start.Enumerate(LogicalDirection.Backward)
                                     .FirstOrDefault(p => p.Symbol.Equals('\n'));
            if (start != null)
            {
                start = start.GetPositionAtOffset(1);
            }
            var end = e.Range.End.Enumerate().FirstOrDefault(p => p.Symbol.Equals('\n'));
            var doc = e.Range.Start.Element.Root;
            UpdateSyntaxColoring(new C1TextRange(start ?? doc.ContentStart, end ?? doc.ContentEnd));
        }

        // perform syntax coloring
        void UpdateSyntaxColoring(C1TextRange range)
        {
            // remove old coloring
            _rangeStyles.RemoveRange(range);

            var input = range.Text;

            // highlight the matches            
            foreach (Match m in Regex.Matches(input, tagPattern))
            {
                // select whole tag, make it dark blue
                _rangeStyles.Add(new C1RangeStyle(GetRangeAtTextOffset(range.Start, m), brDarkBlue));

                // select tag name, make it dark red
                var tagName = m.Groups["tagName"];
                _rangeStyles.Add(new C1RangeStyle(GetRangeAtTextOffset(range.Start, tagName), brDarkRed));

                // select attribute names, make them light red
                var attGroup = m.Groups["attName"];
                if (attGroup != null)
                {
                    var atts = attGroup.Captures;
                    for (int i = 0; i < atts.Count; i++)
                    {
                        var att = atts[i];
                        _rangeStyles.Add(new C1RangeStyle(GetRangeAtTextOffset(range.Start, att), brLightRed));
                    }
                }
            }
        }

        C1TextRange GetRangeAtTextOffset(C1TextPointer pos, Capture capture)
        {
            var start = pos.GetPositionAtOffset(capture.Index, C1TextRange.TextTagFilter);
            var end = start.GetPositionAtOffset(capture.Length, C1TextRange.TextTagFilter);
            return new C1TextRange(start, end);
        }

        // utility
        static string GetStringResource(string resourceName)
        {
            Assembly asm = typeof(SyntaxHighlight).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream(String.Format("RichTextBoxSamples.Resources.{0}", resourceName));
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
