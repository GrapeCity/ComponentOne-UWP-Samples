using C1.Xaml.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace PdfSamples
{
    /// <summary>
    /// Utility class on top of C1.Xaml.Pdf.
    /// </summary>
    public static class PdfUtils
    {
        /// <summary>
        /// Create C1Pdf document.
        /// </summary>
        /// <returns>The C1Pdf document.</returns>
        internal static C1PdfDocument CreatePdfDocument()
        {
            var pdf = new C1PdfDocument(PaperKind.Letter);
            pdf.ConformanceLevel = PdfAConformanceLevel.PdfA2b;
            return pdf;
        }

        // ***********************************************************************
        // C1PdfDocuments for Rect
        // ***********************************************************************


        // measure a paragraph, skip a page if it won't fit, render it into a rectangle,
        // and update the rectangle for the next paragraph.
        // 
        // optionally mark the paragraph as an outline entry and as a link target.
        //
        // this routine will not break a paragraph across pages. for that, see the Text Flow sample.
        //
        public static Rect RenderParagraph(this C1PdfDocument pdf, string text, Font font, Rect rcPage, Rect rc, bool outline, bool linkTarget)
        {
            // if it won't fit this page, do a page break
            rc.Height = pdf.MeasureString(text, font, rc.Width).Height;
            if (rc.Bottom > rcPage.Bottom)
            {
                pdf.NewPage();
                rc.Y = rcPage.Top;
            }

            // draw the string
            pdf.DrawString(text, font, Colors.Black, rc);

            // show bounds (to check word wrapping)
            //var p = Pen.GetPen(Colors.Orange);
            //pdf.DrawRectangle(p, rc);

            // add headings to outline
            if (outline)
            {
                pdf.DrawLine(Colors.Black, rc.X, rc.Y, rc.Right, rc.Y);
                pdf.AddBookmark(text, 0, rc.Y);
            }

            // add link target
            if (linkTarget)
            {
                pdf.AddTarget(text, rc);
            }

            // update rectangle for next time
            rc = Offset(rc, 0, rc.Height);
            return rc;
        }

        public static Rect RenderParagraph(this C1PdfDocument doc, string text, Font font, Rect rcPage, Rect rc, bool outline)
        {
            return RenderParagraph(doc, text, font, rcPage, rc, outline, false);
        }

        public static Rect RenderParagraph(this C1PdfDocument doc, string text, Font font, Rect rcPage, Rect rc)
        {
            return RenderParagraph(doc, text, font, rcPage, rc, false, false);
        }

        public static Rect PageRectangle(this C1PdfDocument pdf)
        {
            return PageRectangle(pdf, new Thickness(72));
        }

        public static Rect PageRectangle(this C1PdfDocument pdf, Thickness pageMargins)
        {
            Rect rc = pdf.PageRectangle;
            double left = Math.Min(rc.Width, rc.Left + pageMargins.Left);
            double top = Math.Min(rc.Height, rc.Top + pageMargins.Top);
            double width = Math.Max(0, rc.Width - (pageMargins.Left + pageMargins.Right));
            double height = Math.Max(0, rc.Height - (pageMargins.Top + pageMargins.Bottom));
            return new Rect(left, top, width, height);
        }

        public static void SetDocumentInfo(this C1PdfDocument pdf, string title)
        {
            // set document info
            var di = pdf.DocumentInfo;
            di.Author = Strings.DocumentAuthor;
            di.Subject =Strings.DocumentSubject;
            di.Title = title;

            // render footers
            // this reopens each page and adds content to them (now we know the page count).
            var font = new Font("Arial", 8, PdfFontStyle.Bold);
            var fmt = new StringFormat();
            fmt.Alignment = HorizontalAlignment.Right;
            fmt.LineAlignment = VerticalAlignment.Bottom;
            for (int page = 0; page < pdf.Pages.Count; page++)
            {
                pdf.CurrentPage = page;
                var text = string.Format(Strings.Documentfooter,
                    di.Title,
                    page + 1,
                    pdf.Pages.Count);
                pdf.DrawString(
                    text,
                    font,
                    Colors.DarkGray,
                    PdfUtils.Inflate(pdf.PageRectangle, -72, -36),
                    fmt);
            }
        }

        public static async void Save(this C1PdfDocument pdf)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add(Strings.FileTypeChoicesTip, new List<string>() { ".pdf" });
            picker.DefaultFileExtension = ".pdf";
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                await pdf.SaveAsync(file);

                MessageDialog dlg = new MessageDialog(Strings.SaveLocationTip + " " + file.Path, "PdfSamples");
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

        public static MemoryStream SaveToStream(this C1PdfDocument pdf)
        {
            MemoryStream ms = new MemoryStream();
            pdf.Save(ms);
            ms.Seek(0, SeekOrigin.Begin);
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
