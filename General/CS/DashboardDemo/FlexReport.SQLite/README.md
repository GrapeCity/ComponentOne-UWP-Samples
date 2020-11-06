## FlexReport.SQLite
#### [Download as zip](https://downgit.github.io/#/home?url=https://github.com/GrapeCity/ComponentOne-UWP-Samples/tree/master/General/CS/DashboardDemo/FlexReport.SQLite)
____
#### Implements SQLite data provider for use with FlexReport for UWP (C# version).
____
This project implements the data provider which allows FlexReport for UWP to 
access SQLite databases. If you are using FlexReport for UWP, and your reports 
use SQLite data sources, add the C# or VB.NET version of this project to your 
solution, and add a reference to it to your project that uses FlexReport. This 
allows the FlexReport engine to access SQLite databases without having a hard
reference to SQLite.

You can install SQLite on your WinForms system and use the FlexReport designer 
app to create reports with SQLite data sources. Alternatively, you can load a 
report using for example an OLEDB data source, and change it programmatically. 
For example, if you want to show all records from the Categories table in the 
C1Nwind sample database, setup the C1.Xaml.FlexReport.DataSource object as 
follows:

  dataSource.DataProvider = DataProvider.SQLite;
  dataSource.ConnectionString = @"Data Source=?(SpecialFolder.SystemDefault)\C1NWind.db";
  dataSource.RecordSource = "select * from categories";

This project uses 2 open source projects:

1) SQLite for Universal App Platform
   Can be downloaded from: https://www.sqlite.org/download.html
   should be installed automatically via NuGet manager, packet named "sqlite"

2) sqlite-net-pcl NuGet project
   Should be installed automatically via NuGet manager, packet named "sqlite-net-pcl",
   for more details see https://github.com/praeclarum/sqlite-net

