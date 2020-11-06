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

namespace OrgChartSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainSample : Page
    {
        public MainSample()
        {
            this.InitializeComponent();

            // create hieararchy
            var father = new Platform() { Name = Strings.NameClancy };
            var olderChild = new Platform() { Name = Strings.NameMarge };
            var middleChild = new Platform() { Name = Strings.NamePatty };
            var youngerChild = new Platform() { Name = Strings.NameSelma };

            father.Subplatforms = new List<Platform>();
            father.Subplatforms.Add(olderChild);
            father.Subplatforms.Add(middleChild);
            father.Subplatforms.Add(youngerChild);

            olderChild.Subplatforms = new List<Platform>();
            olderChild.Subplatforms.Add(new Platform() { Name = Strings.NameBart });
            olderChild.Subplatforms.Add(new Platform() { Name = Strings.NameLisa });
            olderChild.Subplatforms.Add(new Platform() { Name = Strings.NameMaggie });

            youngerChild.Subplatforms = new List<Platform>();
            youngerChild.Subplatforms.Add(new Platform() { Name = Strings.NameLing });

            // set to orgchart
            c1OrgChart1.Header = father;
        }

    }

    public class Platform
    {
        public string Name { get; set; }
        public IList<Platform> Subplatforms { get; set; }
    }
}
