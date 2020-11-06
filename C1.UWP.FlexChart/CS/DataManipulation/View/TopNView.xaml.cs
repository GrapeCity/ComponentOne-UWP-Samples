using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace DataManipulation
{
    /// <summary>
    /// Interaction logic for TopNView.xaml
    /// </summary>
    public partial class TopNView : Page
    {
        public TopNView()
        {
            InitializeComponent();

            this.Loaded += (o, e) =>
             {
                 this.cbTopNCount.SelectedIndex = 0;
             };
        }

        private void flexChart1_SeriesVisibilityChanged(object sender, C1.Xaml.Chart.SeriesEventArgs e)
        {
            Queue<string> bindings = new Queue<string>();
            foreach (var s in flexChart1.Series)
            {
                if (s.Visibility == C1.Chart.SeriesVisibility.Visible)
                {
                    bindings.Enqueue(s.Binding);
                }
            }
            topNViewModel.Bindings = bindings.ToArray();
        }
    }
}
