using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Windows.UI.Core;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

using C1.Xaml;
using C1.Xaml.FlexViewer;

namespace C1FlexReportExplorer
{
    public sealed partial class CatalogView : Page, IFlexViewerToolPanel
    {
        static double _lastY;

        C1FlexViewer _fv;
        MainPage _mainPage;
        ScrollViewer _sv;

        public CatalogView()
        {
            this.InitializeComponent();
        }

        void IFlexViewerToolPanel.SetViewer(C1FlexViewer fv)
        {
            _fv = fv;
            _mainPage = null;
            DependencyObject el = fv;
            do
            {
                el = VisualTreeHelper.GetParent(el);
                _mainPage = el as MainPage;
            } while (_mainPage == null && el != null);
            if (_mainPage == null)
            {
                return;
            }
            treeView.ItemsSource = _mainPage.Categories;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            DependencyObject obj = treeView;
            while (_sv == null && VisualTreeHelper.GetChildrenCount(obj) > 0)
            {
                obj = VisualTreeHelper.GetChild(obj, 0);
                _sv = obj as ScrollViewer;
            }
            if ((_lastY > 0 && _sv != null) || _mainPage.DefaultReportName != null)
            {
                treeView.LayoutUpdated += TreeView_LayoutUpdated;
            }
        }

        void TreeView_LayoutUpdated(object sender, object e)
        {
            treeView.LayoutUpdated -= TreeView_LayoutUpdated;
            if (_mainPage.DefaultReportName == null)
                _sv.ChangeView(null, _lastY, null, true);
            else
            {
                string catName = _mainPage.DefaultCategoryName;
                string rptName = _mainPage.DefaultReportName;
                foreach (C1FlexReportExplorer.Category cat in treeView.Items)
                {
                    if (cat != null && cat.Name == catName)
                    {
                        var catItem = treeView.ContainerFromItem(cat) as C1TreeViewItem;
                        if (catItem != null)
                        {
                            if (!catItem.IsExpanded)
                            {
                                catItem.EnsureVisible();
                                treeView.LayoutUpdated += TreeView_LayoutUpdated;
                                catItem.Expand();
                            }
                            else
                            {
                                foreach (C1FlexReportExplorer.Report rpt in catItem.Items)
                                {
                                    if (rpt != null && rpt.ReportName == rptName)
                                    {
                                        _mainPage.ClearDefaults();
                                        var tvi = catItem.ContainerFromItem(rpt) as C1TreeViewItem;
                                        if (tvi != null)
                                        {
                                            tvi.EnsureVisible();
                                            tvi.IsSelected = true;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        void IFlexViewerToolPanel.OnHiding()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            if (_sv != null)
            {
                _lastY = _sv.VerticalOffset;
            }
            treeView.ItemsSource = null;
        }

        ViewHeader IFlexViewerToolPanel.GetViewHeader()
        {
            return viewHeader;
        }

        void Close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _fv.HideToolPanel();
        }

        async void TreeView_ItemClick(object sender, C1.Xaml.SourcedEventArgs e)
        {
            string reportName = string.Empty;
            try
            {
                var selectedItem = treeView.SelectedItem;
                var rpt = selectedItem.DataContext as C1FlexReportExplorer.Report;
                if (rpt != null)
                {
                    reportName = rpt.ReportName;
                    if (!string.IsNullOrEmpty(reportName))
                    {
                        // load report
                        await _mainPage.LoadReport(rpt.CategoryName.Trim(), rpt.FileName, reportName);

                        if (!_fv.IsExpandedContent)
                        {
                            _fv.HideToolPanel();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(string.Format(Strings.ReportErrorFormat, reportName, ex.Message));
                await md.ShowAsync();
            }
        }
    }
}
