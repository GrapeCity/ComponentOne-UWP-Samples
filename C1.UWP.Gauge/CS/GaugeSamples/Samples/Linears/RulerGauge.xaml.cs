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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace GaugeSamples
{
    public sealed partial class RulerGauge : Page, IAnimationPage
    {
        Storyboard storyboard = new Storyboard();
        public RulerGauge()
        {
            this.InitializeComponent();

            var r = new Random();
            
            var animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.EnableDependentAnimation = true;
            animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut };
            Storyboard.SetTarget(animation, myGauge);
            Storyboard.SetTargetProperty(animation,"(c1Gaugeauge.Value)");
            storyboard.Children.Add(animation);
            storyboard.Completed += (s, e) =>
            {
                animation.From = animation.To;
                animation.To = r.NextDouble() * 100;
                storyboard.Begin();
            };
            storyboard.Begin();
        }

        public void StopAnimation()
        {
            storyboard.Stop();
        }
    }
}
