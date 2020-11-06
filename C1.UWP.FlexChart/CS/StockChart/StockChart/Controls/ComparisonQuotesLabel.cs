using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace StockChart
{
    class ComparisonQuotesLabel : ContentControl
    {
        public ComparisonQuotesLabel()
        {
        }

        public IEnumerable<QuoteInfo> QuotesInfo
        {
            get
            {
                return (IEnumerable<QuoteInfo>)this.GetValue(QuotesInfoProperty);
            }
            set
            {
                this.SetValue(QuotesInfoProperty, value);
            }
        }


        public readonly static DependencyProperty QuotesInfoProperty = DependencyProperty.Register(
            "QuotesInfo", typeof(IEnumerable<QuoteInfo>), typeof(ComparisonQuotesLabel), new PropertyMetadata(null,
                new PropertyChangedCallback((o, e) =>
                {
                    ComparisonQuotesLabel cql = o as ComparisonQuotesLabel;
                    if (cql != null)
                    {
                        cql.UpdateLabels();
                    }
                })
                )
            );

        public DisplayMode DisplayMode
        {
            get
            {
                return (DisplayMode)this.GetValue(DisplayModeProperty);
            }
            set
            {
                this.SetValue(DisplayModeProperty, value);
            }
        }

        public readonly static DependencyProperty DisplayModeProperty = DependencyProperty.Register(
            "DisplayMode", typeof(DisplayMode), typeof(ComparisonQuotesLabel), new PropertyMetadata(DisplayMode.Independent,
                new PropertyChangedCallback((o, e) =>
                {
                    ComparisonQuotesLabel cql = o as ComparisonQuotesLabel;
                    if (cql != null)
                    {
                        cql.UpdateLabels();
                    }
                })
                )
            );


        private void UpdateLabels()
        {
            if (this.QuotesInfo == null || this.QuotesInfo.Count() == 0)
            {
                this.Content = null;
                return;
            }
            TextBlock text = new TextBlock();
            text.VerticalAlignment = VerticalAlignment.Stretch;
            text.HorizontalAlignment = HorizontalAlignment.Right;
            //text.FlowDirection = FlowDirection.RightToLeft;
            text.FontSize = this.FontSize;

            if (this.DisplayMode == DisplayMode.Comparison)
            {
                foreach (var quote in this.QuotesInfo)
                {
                    var format = string.Format((quote.Value >= 0 ? "+{0:P2}" : "{0:P2}"), quote.Value);
                    if (quote.Value == 0)
                    {
                        format = "{0:P2}";
                    }

                    string price = string.Format(format, quote.Value);

                    Run priceRun = new Run();
                    priceRun.Text = price + "  ";
                    priceRun.Foreground = quote.Value >= 0 ? new SolidColorBrush(Color.FromArgb(255, 18, 155, 20))
                        : new SolidColorBrush(Color.FromArgb(255, 255, 30, 0));

                    Run codeRun = new Run();
                    codeRun.Text = quote.Code + "  ";
                    codeRun.Foreground = new SolidColorBrush(quote.Color);

                    text.Inlines.Add(codeRun);
                    text.Inlines.Add(priceRun);

                }
            }
            else
            {
                Brush brush = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));

                var quote = this.QuotesInfo.FirstOrDefault();

                if (quote != null)
                {
                    string volume = string.Format("Volume: {0:D0}", quote.Volume);
                    Run volumeRun = new Run();
                    volumeRun.Text = volume + "  ";
                    volumeRun.Foreground = brush;


                    string price = string.Format("Price: {0:.##}", quote.Value);
                    Run priceRun = new Run();
                    priceRun.Text = price + "  ";
                    priceRun.Foreground = brush;


                    string date = string.Format("{0:MMM dd, yyyy}", quote.Date);
                    Run dateRun = new Run();
                    dateRun.Text = date + "  ";
                    dateRun.Foreground = brush;


                    text.Inlines.Add(dateRun);
                    text.Inlines.Add(priceRun);
                    text.Inlines.Add(volumeRun);


                }
            }

            this.Content = text;
        }


    }
}
