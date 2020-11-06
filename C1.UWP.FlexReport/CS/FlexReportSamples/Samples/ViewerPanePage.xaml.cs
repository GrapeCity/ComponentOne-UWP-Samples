using System;
using System.IO;
using System.Reflection;

using Windows.Storage;
using Windows.UI.Popups;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using C1.Xaml;
using C1.Xaml.FlexReport;
using C1.Xaml.FlexViewer;

namespace FlexReportSamples
{
    public sealed partial class ViewerPanePage : Page
    {
        C1FlexReport _report;

        public ViewerPanePage()
        {
            this.InitializeComponent();
            this.Unloaded += ViewerPage_Unloaded;
            this.Loaded += ViewerPage_Loaded;

            _report = new C1FlexReport();
        }

        void ViewerPage_Unloaded(object sender, RoutedEventArgs e)
        {
            cbReport.SelectionChanged -= CbReport_SelectionChanged;

            flexViewerPane.DocumentSource = null;
            _report.Dispose();
            _report = null;
        }

        async void ViewerPage_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly asm = typeof(ExportPage).GetTypeInfo().Assembly;
            await ExportPage.CopyC1NWind();

            string[] reports = null;

            // get list of reports from resource using stream
            using (Stream stream = asm.GetManifestResourceStream("FlexReportSamples.Resources.FlexCommonTasks_UWP.flxr"))
                reports = C1FlexReport.GetReportList(stream);

            cbReport.Items.Clear();
            cbReport.SelectionChanged += CbReport_SelectionChanged;

            if (reports != null && reports.Length > 0)
            {
                foreach (string s in reports)
                    cbReport.Items.Add(s);
                cbReport.SelectedIndex = 0;
            }
        }

        async void CbReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedReport = cbReport.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedReport))
                return;

            // load report
            try
            {
                // load from resource stream
                Assembly asm = typeof(ExportPage).GetTypeInfo().Assembly;
                using (Stream stream = asm.GetManifestResourceStream("FlexReportSamples.Resources.FlexCommonTasks_UWP.flxr"))
                    _report.Load(stream, selectedReport);
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.FailedToLoadFmt, selectedReport, ex.Message), "Error");
                await md.ShowAsync();
                return;
            }

            flexViewerPane.DocumentSource = null;
            flexViewerPane.DocumentSource = _report;
        }

        private void MenuFlyout_Opening(object sender, object e)
        {
            foreach (MenuFlyoutItemBase mfib in ((MenuFlyout)sender).Items)
            {
                switch (mfib.Name)
                {
                    case "mfiActualSize":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.ActualSizeCommand;
                        break;
                    case "mfiPageWidth":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.PageWidthCommand;
                        break;
                    case "mfiWholePage":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.WholePageCommand;
                        break;
                    case "mfiOnePage":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.OnePageViewCommand;
                        break;
                    case "mfiFacingPages":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.FacingPagesCommand;
                        break;
                    case "mfiTwoPages":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.TwoPagesViewCommand;
                        break;
                    case "mfiFourPages":
                        ((MenuFlyoutItem)mfib).Command = flexViewerPane.FourPagesViewCommand;
                        break;
                }
            }
        }
    }
}
