#define WITHOUT_GRAPHICS

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

using C1.Xaml.Word;
using C1.Xaml.Word.Objects;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TOCPage : Page
    {
        C1WordDocument _doc;

        public TOCPage()
        {
            this.InitializeComponent();
            this.Loaded += TOCPage_Loaded;

            _doc = new C1WordDocument(PaperKind.Letter);
            _doc.Clear();
        }

        async void TOCPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentTOC(_doc);
            WordUtils.SetDocumentInfo(_doc, Strings.TableOfContentsDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(_doc.ToRtfText());
            progressRing.IsActive = false;
        }

        static void CreateDocumentTOC(C1WordDocument doc)
        {
            // calculate page rect (discounting margins)
            Rect rcPage = WordUtils.PageRectangle(doc);
            var height = rcPage.Top;

            // initialize fonts
            Font titleFont = new Font("Tahoma", 20, RtfFontStyle.Bold);
            Font headerFont = new Font("Arial", 14, RtfFontStyle.Bold);
            Font bodyFont = new Font("Times New Roman", 11);

            // add title
            doc.AddParagraph(Strings.TableOfContentsDocumentTitle, titleFont, Colors.DeepPink, RtfHorizontalAlignment.Center);
            doc.AddParagraph(string.Empty);

            // create context of the document
            var pageIndex = 2;
            var data = new List<List<string>>();
            for (int i = 0; i < 30; i++)
            {
                // iniialization data
                var list = new List<string>();
                data.Add(list);

                // create it header (as a link target and outline entry)
                string header = string.Format("{0}. {1}", i + 1, BuildRandomTitle());
                var h = 2 * doc.MeasureString(header, headerFont, rcPage.Width).Height;

                // create some text
                for (int j = 0; j < 3 + _rnd.Next(20); j++)
                {
                    // some paragraph
                    string text = BuildRandomParagraph();
                    var sf = new StringFormat();
                    sf.Alignment = HorizontalAlignment.Stretch;
                    h += doc.MeasureString(text, bodyFont, rcPage.Width, sf).Height;
                    h += 6;

                    // test next page
                    if (height + h > rcPage.Bottom)
                    {
                        pageIndex++;
                        height = rcPage.Top;
                    }
                    height += h;
                    h = 0;

                    // page index for header
                    if (j == 0)
                    {
                        list.Add(pageIndex.ToString());
                        list.Add(header.ToString());
                    }

                    // page index for paragraph
                    list.Add(pageIndex.ToString());
                    list.Add(text.ToString());
                }

                // last line
                height += 20;
            }

            // render Table of Contents
            RtfTable table = new RtfTable(data.Count, 2);
            doc.Add(table);
            for (int row = 0; row < data.Count; row++)
            {
                // get bookmark info
                var list = data[row];
                var page = list[0];
                var header = list[1];

                // add cells
                table.Rows[row].Cells[0].Content.Add(new RtfString(header));
                //var hlink = new RtfHyperlink(string.Format("hdr{0}", 1 + row));
                //hlink.Content.Add(new RtfString(page));
                //table.Rows[row].Cells[1].Content.Add(hlink);
                table.Rows[row].Cells[1].Content.Add(new RtfString(page));

                // set attributes
                table.Rows[row].Cells[0].Alignment = ContentAlignment.BottomLeft;
                table.Rows[row].Cells[1].Alignment = ContentAlignment.BottomRight;
                table.Rows[row].BottomBorderWidth = 1;
                table.Rows[row].BottomBorderStyle = RtfBorderStyle.Dotted;
            }

            // next page
            doc.PageBreak();
            pageIndex = 1;

            // render contents
            foreach (var list in data)
            {
                for (int i = 0; i < list.Count; i += 2)
                {
                    int page = int.Parse(list[i]);
                    if (page != pageIndex)
                    {
                        doc.PageBreak();
                        pageIndex = page;
                    }
                    var text = list[i + 1];
                    if (i == 0)
                    {
                        // header
                        //doc.AddBookmark(string.Format("hdr{0}", 1 + data.IndexOf(list)));
                        doc.AddParagraph(text, headerFont, Colors.DarkGray, RtfHorizontalAlignment.Center);
                        var paragraph = (RtfParagraph)doc.Current;
                        paragraph.TopBorderColor = Colors.DarkGray;
                        paragraph.TopBorderStyle = RtfBorderStyle.Single;
                        paragraph.TopBorderWidth = 1f;
                        doc.AddParagraph(string.Empty, bodyFont, Colors.Black);
                    }
                    else
                    {
                        // context
                        doc.AddParagraph(text, bodyFont, Colors.Black, RtfHorizontalAlignment.Justify);
                    }
                }
                doc.AddParagraph(string.Empty, bodyFont, Colors.Black);
            }
        }

        static string BuildRandomTitle()
        {
            string[] a1 = Strings.BuildRandomTitleString1.Split('|');
            string[] a2 = Strings.BuildRandomTitleString2.Split('|');
            string[] a3 = Strings.BuildRandomTitleString3.Split('|');
            return string.Format("{0} {1} {2}", a1[_rnd.Next(a1.Length - 1)], a2[_rnd.Next(a2.Length - 1)], a3[_rnd.Next(a3.Length - 1)]);
        }

        static string BuildRandomParagraph()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5 + _rnd.Next(10); i++)
            {
                sb.AppendFormat(BuildRandomSentence());
            }
            return sb.ToString();
        }
        static string BuildRandomSentence()
        {
            string[] a1 = Strings.BuildRandomSentenceString1.Split('|');
            string[] a2 = Strings.BuildRandomSentenceString2.Split('|');
            string[] a3 = Strings.BuildRandomSentenceString3.Split('|');
            string[] a4 = Strings.BuildRandomSentenceString4.Split('|');
            return string.Format("{0} {1} {2} {3}. ", a1[_rnd.Next(a1.Length - 1)], a2[_rnd.Next(a2.Length - 1)], a3[_rnd.Next(a3.Length - 1)], a4[_rnd.Next(a4.Length - 1)]);
        }
        static Random _rnd = new Random();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(_doc);
        }
    }
}
