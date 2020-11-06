using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;

using Windows.Storage;
using Windows.UI.Popups;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using C1.Xaml.FlexReport;
using C1.Xaml.FlexViewer;

namespace C1FlexReportExplorer
{
    public sealed partial class MainPage : Page
    {
        C1FlexReport _report;
        List<Category> _categories;
        string _defCategoryName;
        string _defReportName;

        public MainPage()
        {
            this.InitializeComponent();

            _report = new C1FlexReport();
            flexViewer.PrepareToolMenu += FlexViewer_PrepareToolMenu;
            flexViewer.NavigateToCustomTool += FlexViewer_NavigateToCustomTool;
            this.Loaded += MainPage_Loaded;
        }

        public List<Category> Categories
        {
            get { return _categories; }
        }

        internal string DefaultCategoryName
        {
            get { return _defCategoryName; }
        }

        internal string DefaultReportName
        {
            get { return _defReportName; }
        }

        internal void App_Suspending()
        {
            flexViewer.Pane.HandleSuspending();
        }

        internal bool HandleBackRequest()
        {
            if (flexViewer.ActiveTool != FlexViewerTool.CustomTool1)
            {
                flexViewer.ShowToolPanel(FlexViewerTool.CustomTool1);
                return true;
            }
            return false;
        }

        public async Task LoadReport(string categoryName, string reportFileName, string reportName)
        {
            // load report
            try
            {
                using (Stream fs = File.OpenRead("Assets/Reports/" + categoryName.Trim() + "/" + reportFileName.Trim()))
                {
                    _report.Load(fs, reportName);
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.ErrorFormat, reportName, ex.Message), Strings.ErrorTitle);
                await md.ShowAsync();
                return;
            }

            // 
            flexViewer.DocumentSource = null;

            // render report
            progressRing.IsActive = true;
            try
            {
                await _report.RenderAsync();
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.ErrorFormat, reportName, ex.Message), Strings.ErrorTitle);
                await md.ShowAsync();
                return;
            }
            finally
            {
                progressRing.IsActive = false;
            }

            // assign rendered report to the viewer
            flexViewer.DocumentSource = _report;
        }

        internal void ClearDefaults()
        {
            _defCategoryName = null;
            _defReportName = null;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // load the report catalog
            XDocument xdoc = new XDocument();
            using (Stream fs = File.OpenRead("Assets/ReportsCatalog.xml"))
            {
                xdoc = XDocument.Load(fs);
            }

            // prepare the list of reports for the TreeView
            IEnumerable<XElement> xelems = xdoc.Descendants("Category");
            _categories = new List<Category>();
            foreach (XElement xelem in xelems)
            {
                Category category = new Category();
                category.Name = xelem.Attribute("Name").Value;
                category.Text = xelem.Attribute("Text").Value;
                category.ImageUri = "Assets/Reports/MenuIcons/" + xelem.Attribute("Image").Value + ".png";
                List<Report> reports = new List<Report>();
                foreach (XElement childReports in xelem.Descendants("Report"))
                {
                    Report rpt = new Report();
                    rpt.CategoryName = category.Name;
                    rpt.ReportName = childReports.Descendants("ReportName").First().Value;
                    rpt.FileName = childReports.Descendants("FileName").First().Value;
                    rpt.ReportTitle = childReports.Descendants("ReportTitle").First().Value;
                    rpt.ImageUri = "Assets/Reports/" + category.Name.Trim() + "/Images/" + childReports.Descendants("ImageName").First().Value.Trim();
                    reports.Add(rpt);
                }
                category.Reports = reports;
                _categories.Add(category);
            }

            // copy SQLite database from resources to the local folder
            Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("C1FlexReportExplorer.Resources.C1NWind.db"))
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.CreateFileAsync("C1NWind.db", CreationCollisionOption.ReplaceExisting);
                using (Stream dst = await sf.OpenStreamForWriteAsync())
                {
                    await stream.CopyToAsync(dst);
                    await dst.FlushAsync();
                }
            }

            // open the default report
            XElement xelemDef = xdoc.Descendants("SelectedReport").First();
            if (xelemDef != null)
            {
                _defCategoryName = xelemDef.Descendants("CategoryName").FirstOrDefault().Value;
                _defReportName = xelemDef.Descendants("ReportName").FirstOrDefault().Value;
                string defFileName = xelemDef.Descendants("FileName").FirstOrDefault().Value;
                await LoadReport(_defCategoryName, defFileName, _defReportName);
            }

            flexViewer.ShowToolPanel(FlexViewerTool.CustomTool1);
        }

        void FlexViewer_PrepareToolMenu(object sender, EventArgs e)
        {
            var tmi = new ToolMenuItem("\xE773", FlexViewerTool.CustomTool1, Strings.CatalogToolLabel);
            flexViewer.ToolMenuItems.Insert(0, tmi);
        }

        void FlexViewer_NavigateToCustomTool(object sender, CustomToolEventArgs e)
        {
            if (e.Tool == FlexViewerTool.CustomTool1)
            {
                e.ToolFrame.Navigate(typeof(CatalogView), null);
                e.NavigatedTo = true;
            }
        }
    }
}
