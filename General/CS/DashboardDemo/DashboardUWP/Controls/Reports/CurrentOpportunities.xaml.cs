using C1.Xaml.FlexReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DashboardUWP
{
    public sealed partial class CurrentOpportunities : UserControl
    {
        C1FlexReport _flexReport;
        Stream _reportStream;

        public CurrentOpportunities()
        {
            this.InitializeComponent();

            _flexReport = new C1FlexReport();
            Loaded += OnLoaded;
        }

        void OnLoaded(object sender, RoutedEventArgs rea)
        {
            Loaded -= OnLoaded;

            using (_reportStream = File.OpenRead("Assets/Reports/CurrentOpportunitiesData.flxr"))
            {
                string[] reports = C1FlexReport.GetReportList(_reportStream);
                fv.DocumentSource = null;
                _reportStream.Seek(0, SeekOrigin.Begin);
                _flexReport.Load(_reportStream, reports[0]);
                fv.DocumentSource = _flexReport;
            }
        }
    }
}
