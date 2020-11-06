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
    public partial class SortingView : Page
    {
        public SortingView()
        {
            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                this.cbSortBy.SelectedIndex = 0;
            };
        }
    }
}
