using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;

using C1.Xaml.Word;
using C1.Xaml.Word.Objects;

namespace WordSamples
{
    /// <summary>
    /// Utility class on top of C1.Xaml.Word.
    /// </summary>
    public static class WordUtils
    {
        // ***********************************************************************
        // C1WordDocuments for measure a paragraph
        // ***********************************************************************

        //public static double MeasureText(this C1WordDocument doc, string text, Font font, Rect rcPage, double height, RtfHorizontalAlignment align = RtfHorizontalAlignment.Undefined)
        //{
        //    // if it won't fit this page, do a page break
        //    var sf = new StringFormat();
        //    switch (align)
        //    {
        //        case RtfHorizontalAlignment.Center:
        //            sf.Alignment = HorizontalAlignment.Center;
        //            break;
        //        case RtfHorizontalAlignment.Justify:
        //            sf.Alignment = HorizontalAlignment.Stretch;
        //            break;
        //        case RtfHorizontalAlignment.Right:
        //            sf.Alignment = HorizontalAlignment.Right;
        //            break;
        //    }
        //    //sf.FormatFlags |= StringFormatFlags.
        //    rc.Height = doc.MeasureString(text, font, rcPage.Width, sf).Height;
        //    if (rc.Bottom > rcPage.Bottom)
        //    {
        //        doc.PageBreak();
        //        rc.Y = rcPage.Top;
        //    }

        //    // add the paragraph
        //    doc.AddParagraph(text, font, clr, align);
        //    //doc.DrawString(text, font, Colors.Black, rc);

        //    // add headings to outline
        //    if (outline)
        //    {
        //        // top line
        //        var paragraph = (RtfParagraph)doc.Current;
        //        paragraph.TopBorderColor = clr;
        //        paragraph.TopBorderStyle = RtfBorderStyle.Single;
        //        paragraph.TopBorderWidth = 1f;

        //        //doc.DrawLine(Colors.Black, rc.X, rc.Y, rc.Right, rc.Y);
        //        doc.AddBookmark(text);
        //    }

        //    // add link target
        //    if (linkTarget)
        //    {
        //        //doc.AddLink(text);
        //    }

        //    // update rectangle for next time
        //    rc = Offset(rc, 0, rc.Height);
        //    return rc;
        //}

        // ***********************************************************************
        // C1WordDocuments for Rect
        // ***********************************************************************

        // measure a paragraph, skip a page if it won't fit, render it into a rectangle,
        // and update the rectangle for the next paragraph.
        // 
        // optionally mark the paragraph as an outline entry and as a link target.
        //
        // this routine will not break a paragraph across pages. for that, see the Text Flow sample.
        //
        public static Rect RenderParagraph(this C1WordDocument doc, string text, Font font, Rect rcPage, Rect rc, bool outline, bool linkTarget)
        {
            // if it won't fit this page, do a page break
            rc.Height = doc.MeasureString(text, font, rc.Width).Height;
            if (rc.Bottom > rcPage.Bottom)
            {
                doc.PageBreak();
                rc.Y = rcPage.Top;
            }

            // draw the string
            doc.DrawString(text, font, Colors.Black, rc);

            // show bounds (to check word wrapping)
            //var p = Pen.GetPen(Colors.Orange);
            //doc.DrawRectangle(p, rc);

            // add headings to outline
            if (outline)
            {
                doc.DrawLine(Colors.Black, rc.X, rc.Y, rc.Right, rc.Y);
                //doc.AddBookmark(text, 0, rc.Y);
            }

            // add link target
            if (linkTarget)
            {
                //doc.AddTarget(text, rc);
            }

            // update rectangle for next time
            rc = Offset(rc, 0, rc.Height);
            return rc;
        }

        public static Rect RenderParagraph(this C1WordDocument doc, string text, Font font, Rect rcPage, Rect rc, bool outline)
        {
            return RenderParagraph(doc, text, font, rcPage, rc, outline, false);
        }

        public static Rect RenderParagraph(this C1WordDocument doc, string text, Font font, Rect rcPage, Rect rc)
        {
            return RenderParagraph(doc, text, font, rcPage, rc, false, false);
        }

        static int _pageCurrent = 1;
        public static int CurrentPage(this C1WordDocument doc)
        {
            return _pageCurrent;
        }
        public static int CurrentPage(this C1WordDocument doc, int page)
        {
            _pageCount = Math.Max(_pageCount, page);
            _pageCurrent = page;
            return _pageCurrent;
        }
        static int _pageCount = 1;
        public static int PageCount(this C1WordDocument doc)
        {
            return _pageCount;
        }

        public static Rect PageRectangle(this C1WordDocument doc)
        {
            return PageRectangle(doc, new Thickness(doc.LeftMargin, doc.TopMargin, doc.RightMargin, doc.BottomMargin));
        }
        public static Rect PageRectangle(this C1WordDocument doc, Thickness pageMargins)
        {
            var sz = doc.PageSize;
            double left = Math.Min(sz.Width, pageMargins.Left);
            double top = Math.Min(sz.Height, pageMargins.Top);
            double width = Math.Max(0, sz.Width - (pageMargins.Left + pageMargins.Right));
            double height = Math.Max(0, sz.Height - (pageMargins.Top + pageMargins.Bottom));
            return new Rect(left, top, width, height);
        }

        public static void SetDocumentInfo(this C1WordDocument doc, string title, bool graphicFooter = false)
        {
            // set document info
            var di = doc.Info;
            di.Author = Strings.DocumentAuthor;
            di.Subject = Strings.DocumentSubject;
            di.Title = title;

            // footer font
            var font = new Font("Arial", 8, RtfFontStyle.Bold);
            var fmt = new StringFormat();
            fmt.Alignment = HorizontalAlignment.Right;
            fmt.LineAlignment = VerticalAlignment.Bottom;

            // render footers
            if (graphicFooter)
            {
                // this reopens each page and adds content to them (now we know the page count).
                for (int page = 0; page < doc.PageCount(); page++)
                {
                    doc.CurrentPage(page);
                    var text = string.Format(Strings.Documentfooter,
                        di.Title,
                        page + 1,
                        doc.PageCount());
                    doc.DrawString(
                        text,
                        font,
                        Colors.DarkGray,
                        WordUtils.Inflate(doc.PageRectangle(), -72, -36),
                        fmt);
                }
            }
            else
            {
                // standard footer
                var text = string.Format(Strings.Documentfooter, di.Title, "|", "|");
                var paragraph = new RtfParagraph(doc.CurrentSection.Footer);
                paragraph.Alignment = RtfHorizontalAlignment.Right;
                int count = 0;
                foreach (var part in text.Split('|'))
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        paragraph.Add(new RtfString(part));
                    }
                    switch (count)
                    {
                        case 0:
                            paragraph.Add(new RtfPageField());
                            break;
                        case 1:
                            paragraph.Add(new RtfNumPagesField());
                            break;
                    }
                    count++;
                }
                doc.CurrentSection.Footer.Add(paragraph);
            }
        }

        public static async void Save(this C1WordDocument doc)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add(Strings.FileTypeChoicesTip, new List<string>() { ".docx" });
            picker.FileTypeChoices.Add(Strings.AlternateFileTypeChoicesTip, new List<string>() { ".rtf" });
            picker.DefaultFileExtension = ".docx";
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                await doc.SaveAsync(file, file.Name.ToLower().EndsWith(".rtf") ? FileFormat.Rtf : FileFormat.OpenXml);

                MessageDialog dlg = new MessageDialog(Strings.SaveLocationTip + " " + file.Path, "WordSamples");
                dlg.Commands.Add(new UICommand("Open", new UICommandInvokedHandler((args) =>
                {
                    // to open the created file (using file extension)
                    var success = Launcher.LaunchFileAsync(file);
                })));
                dlg.Commands.Add(new UICommand("Cancel"));
                dlg.CancelCommandIndex = 2;
                await dlg.ShowAsync();
            }
        }

        public static async Task<MemoryStream> SaveToStream(this C1WordDocument doc)
        {
            var ms = new MemoryStream();
            using (var imas = new InMemoryRandomAccessStream())
            {
                await doc.SaveAsync(imas.AsStream(), FileFormat.OpenXml);
            }
            return ms;
        }

        // ***********************************************************************
        // Extension methods for Rect
        // ***********************************************************************

        public static Rect Inflate(this Rect rc, double dx, double dy)
        {
            rc.X -= dx;
            rc.Y -= dy;
            rc.Width += 2 * dx;
            rc.Height += 2 * dy;
            return rc;
        }

        public static Rect Offset(this Rect rc, double dx, double dy)
        {
            rc.X += dx;
            rc.Y += dy;
            return rc;
        }

    }
}
