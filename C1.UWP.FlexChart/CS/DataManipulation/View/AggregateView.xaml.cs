using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace DataManipulation
{
    /// <summary>
    /// Interaction logic for AggregateView.xaml
    /// </summary>
    public partial class AggregateView : Page
    {
        public AggregateView()
        {
            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                this.cbProperty.SelectedIndex = 0;
                this.cbTopNCount.SelectedIndex = 0;
            };
        }
    }
}
