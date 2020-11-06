using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlexChart101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dynamic : Page
    {
        const int NUMBER_OF_POINTS = 20;
        DispatcherTimer _timer = new DispatcherTimer();
        ObservableCollection<DynamicItem> data = new ObservableCollection<DynamicItem>();
        Random rnd = new Random();
        int _counter = 1;

        public Dynamic()
        {
            this.InitializeComponent();
            this.Loaded += Dynamic_Loaded;
        }

        private void Dynamic_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Start();
        }

        private void _timer_Tick(object sender, object e)
        {
            if (data.Count > NUMBER_OF_POINTS)
                data.RemoveAt(0);
            data.Add(new DynamicItem()
            {
                Day = _counter,
                Trucks = rnd.Next(100),
                Ships = rnd.Next(100) / 2,
                Planes = rnd.Next(100) / 4
            });
            _counter++;
        }

        public ObservableCollection<DynamicItem> Data
        {
            get
            {
                return data;
            }
        }

        private void btnSlow_Click(object sender, RoutedEventArgs e)
        {
            if (_timer != null)
                _timer.Interval = new TimeSpan(0, 0, 0, 1);
        }

        private void btnMedium_Click(object sender, RoutedEventArgs e)
        {
            if (_timer != null)
                _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        }

        private void btnFast_Click(object sender, RoutedEventArgs e)
        {
            if (_timer != null)
                _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (_timer.IsEnabled)
            {
                _timer.Stop();
                button.Content = Strings.BtnStart;
            }
            else
            {
                _timer.Start();
                button.Content = Strings.BtnStop;
            }
        }
    }
}
