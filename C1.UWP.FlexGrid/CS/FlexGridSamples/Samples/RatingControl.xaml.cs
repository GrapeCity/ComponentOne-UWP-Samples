using System;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace FlexGridSamples
{
    public partial class RatingControl : Page
    {
        public RatingControl()
        {
            InitializeComponent();
            UpdateStars();
        }

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set
            {
                SetValue(RatingProperty, value);
            }
        }

        void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == RatingProperty)
            {
                UpdateStars();
            }
        }
        
        void UpdateStars()
        {
            for (int i = 0; i < _sp.Children.Count; i++)
            {
                _sp.Children[i].Opacity = Rating > i ? 1 : 0.1;
            }
        }

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                "Rating",
                typeof(int),
                typeof(RatingControl),
                new PropertyMetadata(0, RatingControl.OnPropertyChanged));
        static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RatingControl ctl = (RatingControl)d;
            ctl.OnPropertyChanged(e);
        }
    }
}
