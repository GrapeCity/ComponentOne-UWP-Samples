using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace FlexGrid101
{
    /// <summary>
    /// Cell that shows a rating value as an image with stars.
    /// </summary>
    public class RatingCell : StackPanel
    {
        const int MAXRATING = 5;
        const double OFF = 0.2;
        const double ON = 1.0;

        /// <summary>
        /// Identifies the <see cref="ItemsSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                "Rating",
                typeof(int),
                typeof(RatingCell),
                new PropertyMetadata(0, OnRatingChanged));

        public RatingCell()
        {
            Orientation = Orientation.Horizontal;
            for (int i = 0; i < 5; i++)
            {
                var star = new ContentControl();
                star.Width = 20;
                star.Height = 20;
                star.ContentTemplate = GetStarPath();
                star.Opacity = OFF;
                star.PointerPressed += img_PointerPressed;
                Children.Add(star);
            }
        }

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }
        void img_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // calculate rating based on the index of the star
            var star = sender as ContentControl;
            RatingCell cell = star.Parent as RatingCell;
            int index = cell.Children.IndexOf(star);
            if (index > 0 || e.GetCurrentPoint(star).Position.X > star.Width / 3)
            {
                index++;
            }

            // apply the new rating
            cell.Rating = index;
            Animate(star);
        }

        static DataTemplate GetStarPath()
        {
            return TemplateCell.CustomTemplatesDictionary["StarIcon"] as DataTemplate;
        }

        static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RatingCell cell = (RatingCell)d;
            for (int i = 0; i < cell.Children.Count; i++)
            {
                cell.Children[i].Opacity = i < cell.Rating ? ON : OFF;
            }
        }

        static FrameworkElement _animate;
        static Storyboard _sb;
        void Animate(FrameworkElement star)
        {
            // create storyboard
            if (_sb == null)
            {
                _sb = new Storyboard();
                _sb.Duration = new Duration(TimeSpan.FromMilliseconds(20));
                _sb.Completed += sb_Completed;
            }

            // suspend current animation if any
            if (_animate != null)
            {
                _sb.Stop();
                _animate.RenderTransform = null;
            }

            // start new animation
            star.RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 2, CenterX = star.Width / 2, CenterY = star.Height / 2 };
            _animate = star;
            _sb.Begin();
        }

        void sb_Completed(object sender, object e)
        {
            var st = _animate.RenderTransform as ScaleTransform;
            if (st != null)
            {
                if (st.ScaleX > 1)
                {
                    st.ScaleX -= .1;
                    st.ScaleY -= .1;
                    _sb.Begin();
                }
                return;
            }
        }
    }
}
