using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using C1.Xaml.OrgChart;

namespace OrgChartSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HierarchicalSample : Page
    {
        public HierarchicalSample()
        {
            this.InitializeComponent();
            // create data object
            var league = League.GetLeague();

            // show it in C1OrgChart
            _chart.Header = league;
            // this has the same effect:
            //_chart.ItemsSource = new object[] { league };

            // show it in TreeView
            //_tree.ItemsSource = new object[] { league };
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
    public class League
    {
        public string Name { get; set; }
        public List<Division> Divisions { get; set; }

        public static League GetLeague()
        {
            var league = new League();
            league.Name = Strings.MainLeague;
            league.Divisions = new List<Division>();
            foreach (var div in Strings.StringNorthSouthEastWest.Split(','))
            {
                var d = new Division();
                league.Divisions.Add(d);
                d.Name = div;
                d.Teams = new List<Team>();
                switch(div)
                {
                    case "East":
                        AddNewTeams(d, Strings.TeamFormEast);
                        break;
                    case "West":
                        AddNewTeams(d, Strings.TeamFormWest);
                        break;
                    case "North":
                        AddNewTeams(d, Strings.TeamFormNorth);
                        break;
                    case "South":
                        AddNewTeams(d, Strings.TeamFormSouth);
                        break;
                }
            }
            return league;
        }

        static void AddNewTeams(Division d, string teamNames)
        {
            foreach (var team in teamNames.Split(','))
            {
                var t = new Team();
                d.Teams.Add(t);
                t.Name = team;
            }
        }
    }
    public class Division
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
    public class Team
    {
        public string Name { get; set; }
    }
}
