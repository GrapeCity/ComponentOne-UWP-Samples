FlexReportSamples
------------------------------------------------------------------------
Demonstrates the major features of FlexReport for UWP.

* Viewer:

There is a sample based on the C1FlexViewer control. It allows to pick
a report from the predefined list, then view the report, update its parameters,
show and navigate to the report outlines, modify its zoom and layout options,
export the report to various formats, regenerate it for the specified paper
format and margins, print the report.

* Viewer Pane:

The samples demonstrates how we can use C1FlexViewerPane as an independent
control (usually, it is a part of the C1FlexViewer control). It is possible to
integrate the pane with your own tools to change the document zoom and layout
options and to print the document displayed in the C1FlexViewerPane control.

* Export:

This sample allows to select a report from a .flxr FlexReport report definition file,
or pick a report from the list of predefined reports, and generates the report.
The report then can be exported to any of the supported external formats.

PLEASE NOTE: this sample references the FlexReport.SQLite sample, which requires
the following open source projects to be installed on the system:

1) SQLite for Universal App Platform
   Can be downloaded from: https://www.sqlite.org/download.html
   should be installed automatically via NuGet manager, packet named "sqlite"

2) sqlite-net-pcl NuGet project
   Should be installed automatically via NuGet manager, packet named "sqlite-net-pcl",
   for more details see https://github.com/praeclarum/sqlite-net

The sample uses the SQLite data provider implemented by the FlexReport.SQLite sample,
e.g. to show all records from the Categories table, the C1.Xaml.FlexReport.DataSource
object can be set up as follows:

  dataSource.DataProvider = DataProvider.SQLite;
  dataSource.ConnectionString = @"Data Source=?(SpecialFolder.SystemDefault)\C1NWind.db";
  dataSource.RecordSource = "select * from categories";

* Printing:

This sample allows to select a report from a .flxr FlexReport report definition file,
or pick a report from the list of predefined reports, and generates the report.
The report then can be printed via standard UWP print dialog.
