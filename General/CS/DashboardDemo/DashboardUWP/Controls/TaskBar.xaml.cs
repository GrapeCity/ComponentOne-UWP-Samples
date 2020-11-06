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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DashboardUWP
{
    public sealed partial class TaskBar : UserControl
    {
        public TaskBar()
        {
            this.InitializeComponent();
        }

        public SolidColorBrush BarColor
        {
            set
            {
                Bar.Fill = value;
            }
        }

        public double PrecentComplete
        {
            set
            {
                string precent = value.ToString("P0");
                Label.Text = precent;
                Bar.Height = Height;
                Bar.Width = Width * value;
            }
        }
    }
}
