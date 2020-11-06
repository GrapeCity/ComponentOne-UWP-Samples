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

using C1.Util;
using C1.Xaml.Word;
using C1.Xaml.Word.Objects;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BasicTextPage : Page
    {
        C1WordDocument word;

        public BasicTextPage()
        {
            this.InitializeComponent();
            this.Loaded += BasicText_Loaded;

            word = new C1WordDocument(PaperKind.Letter);
            word.Clear();
        }

        async void BasicText_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentText(word);
            WordUtils.SetDocumentInfo(word, Strings.TableOfContentsDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(word.ToRtfText());
            progressRing.IsActive = false;
        }

        /// <summary>
        /// Shows how to position and align text
        /// </summary>
        static void CreateDocumentText(C1WordDocument word)
        {
            // use landscape for more impact
            word.Landscape = true;

            // show some text 
            var text = Strings.DocumentBasicText;
            var font = new Font("Segoe UI Light", 14, RtfFontStyle.Regular);

            // add paragraph
            word.AddParagraph(text, font, Colors.MidnightBlue, RtfHorizontalAlignment.Justify);
            var paragraph = (RtfParagraph)word.Current;
            paragraph.LeftBorderColor = Colors.Blue;
            paragraph.LeftBorderStyle = RtfBorderStyle.Emboss;
            paragraph.LeftBorderWidth = 1f;
            paragraph.TopBorderColor = Colors.Blue;
            paragraph.TopBorderStyle = RtfBorderStyle.Emboss;
            paragraph.TopBorderWidth = 2f;
            paragraph.RightBorderColor = Colors.Purple;
            paragraph.RightBorderStyle = RtfBorderStyle.DotDash;
            paragraph.RightBorderWidth = 5f;

            // next show some text 
            text = Strings.DocumentBasicText2;
            word.AddParagraph(text, font, Colors.Black, RtfHorizontalAlignment.Justify);
            paragraph = (RtfParagraph)word.Current;
            paragraph.LeftBorderColor = Colors.DeepPink;
            paragraph.LeftBorderStyle = RtfBorderStyle.DashDotStroked;
            paragraph.LeftBorderWidth = 4f;
            paragraph.RightBorderColor = Colors.Chocolate;
            paragraph.RightBorderStyle = RtfBorderStyle.Single;
            paragraph.RightBorderWidth = 2f;
            paragraph.BottomBorderColor = Colors.DarkRed;
            paragraph.BottomBorderStyle = RtfBorderStyle.Dashed;
            paragraph.BottomBorderWidth = 3f;

            // RTF/Word formats
            var titleFont = new Font("Segoe UI Light", 48, RtfFontStyle.Bold);
            paragraph = word.GetParagraph(string.Empty, titleFont);
            var rs = new RtfString("R", titleFont);
            rs.ForeColor = Colors.Red;
            paragraph.Add(rs);
            rs = new RtfString("T", titleFont);
            rs.ForeColor = Colors.DarkGreen;
            paragraph.Add(rs);
            rs = new RtfString("F", titleFont);
            rs.ForeColor = Colors.BlueViolet;
            paragraph.Add(rs);
            rs = new RtfString(" / ", titleFont);
            rs.ForeColor = Colors.Coral;
            paragraph.Add(rs);
            titleFont = new Font("Segoe UI Light", 48, RtfFontStyle.Bold | RtfFontStyle.Italic);
            rs = new RtfString("Word", titleFont);
            rs.ForeColor = Colors.DarkSeaGreen;
            paragraph.Add(rs);
            word.Add(paragraph);
            var tableFont = new Font("Segoe UI Light", 16, RtfFontStyle.Regular);
            word.AddParagraph(string.Empty, tableFont, Colors.Black);

            // add table
            int rows = 4;
            int cols = 3;
            RtfTable table = new RtfTable(rows, cols);
            word.Add(table);
            table.Rows[0].Cells[0].SetMerged(1, 2);
            for (int row = 0; row < rows; row++)
            {
                if (row == 0)
                {
                    table.Rows[row].Height = 50;
                }
                for (int col = 0; col < cols; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        // table header
                        text = Strings.DocumentBasicMergedCell;
                        table.Rows[row].Cells[col].Alignment = ContentAlignment.MiddleCenter;
                        table.Rows[row].Cells[col].BackFilling = Colors.LightPink;
                    }
                    else
                    {
                        // table cell
                        text = string.Format("table cell {0}:{1}.", row, col);
                        table.Rows[row].Cells[col].BackFilling = Colors.LightYellow;
                    }
                    table.Rows[row].Cells[col].Content.Add(new RtfString(text));
                    table.Rows[row].Cells[col].BottomBorderWidth = 2;
                    table.Rows[row].Cells[col].TopBorderWidth = 2;
                    table.Rows[row].Cells[col].LeftBorderWidth = 2;
                    table.Rows[row].Cells[col].RightBorderWidth = 2;
                    if (col == cols - 1)
                    {
                        table.Rows[row].Cells[col].Alignment = ContentAlignment.BottomRight;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(word);
        }
    }
}
