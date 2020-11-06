using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Waterfall : Page
    {
        List<WaterfallItem> _data;
        public Waterfall()
        {
            this.InitializeComponent();
            this.Loaded += OnLoaded;
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            wf.Start = 100;
            wf.IntermediateTotalPositions = new List<int>() { 3, 6, 9, 12 };
        }

        public List<WaterfallItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataCreator.CreateWaterfallData();
                }

                return _data;
            }
        }
    }
}
