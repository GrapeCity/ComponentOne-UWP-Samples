using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Simple.OData.Client;

using C1.Xaml.FlexReport;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Binding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static readonly Uri ODataUri = new Uri(@"http://services.odata.org/V3/OData/OData.svc/");
        private C1FlexReport _report;

        public MainPage()
        {
            this.InitializeComponent();

            _report = new C1FlexReport();
            _report.BusyStateChanged += _report_BusyStateChanged;
        }

        private async void _report_BusyStateChanged(object sender, EventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    cbReport.IsEnabled = !((C1FlexReport)sender).IsBusy;
                });
        }

        private async Task ShowReport(string reportName)
        {
            try
            {
                // build report
                prMain.IsActive = true;
                switch (reportName)
                {
                    case "Categories":
                        await BuildCategoriesReport();
                        break;
                    case "Products":
                        await BuildProductsReport();
                        break;
                }
                prMain.IsActive = false;

                // assign report to the preview pane
                flexViewerPane.DocumentSource = null;
                flexViewerPane.DocumentSource = _report;
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format("Failed to show \"{0}\" report, error:\r\n{1}", reportName, ex.Message));
                await md.ShowAsync();
            }
        }

        private async Task BuildCategoriesReport()
        {
            // request data from OData service
            var client = new ODataClient(ODataUri);
            // select all categrues
            var categories = (await client.For<Category>().FindEntriesAsync()).ToList<Category>();

            // load report definition from resources
            Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("Binding.Resources.Reports.flxr"))
                _report.Load(stream, "Categories");

            // assign dataset to the report
            _report.DataSource.Recordset = categories;
        }

        private async Task BuildProductsReport()
        {
            // request data from OData service
            var client = new ODataClient(ODataUri);
            // select all categries and products of each category
            var categories = (await client.For<Category>().Expand(x => new { x.Products }).FindEntriesAsync()).ToList();
            var products = (
                from c in categories
                from p in c.Products
                select new
                {
                    CategoryID = c.ID,
                    CategoryName = c.Name,
                    ID = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate,
                    DiscontinuedDate = p.DiscontinuedDate,
                    Rating = p.Rating,
                    Price = p.Price,
                }).ToList();

            // load report definition from resources
            Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("Binding.Resources.Reports.flxr"))
                _report.Load(stream, "Products");

            // assign dataset to the report
            _report.DataSource.Recordset = products;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await ShowReport(((ComboBoxItem)cbReport.SelectedItem).Content as string);

            cbReport.SelectionChanged += cbReport_SelectionChanged;
        }

        private async void cbReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await ShowReport(((ComboBoxItem)cbReport.SelectedItem).Content as string);
        }

        public class Category
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<Product> Products { get; set; }
        }

        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime ReleaseDate { get; set; }
            public DateTime DiscontinuedDate { get; set; }
            public int Rating { get; set; }
            public double Price { get; set; }
        }
    }
}
