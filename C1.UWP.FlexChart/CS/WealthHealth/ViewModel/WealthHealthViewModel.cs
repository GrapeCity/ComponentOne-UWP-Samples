using System;
using System.ComponentModel;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.ApplicationModel;

namespace WealthHealth
{
    public class WealthHealthViewModel : DependencyObject, INotifyPropertyChanged
    {
        DataService dataService = new DataService();
        List<Country> _countries;
        string _content;
        string _trackContent;
        const double YearMin = 1800d;
        const double YearMax = 2009d;
        const double AnimLength = 15000;
        const string PauseTip = "\uE102";
        const string ResumeTip = "\uE103";
        Storyboard _sb;

        public WealthHealthViewModel()
        {
            if (!DesignMode.DesignModeEnabled)
            {
                _countries = dataService.CreateData();
                ToggleAnimation();
            }
        }

        public List<Country> Countries
        {
            get
            {
                return _countries;
            }
            set
            {
                if (_countries != null)
                {
                    _countries = value;
                    NotifyPropertyChanged("Countries");
                }
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (value != _content)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }

        public PlayCommand PlayAnimation
        {
            get
            {
                return new PlayCommand(()=> { PerformAnimation(); });
            }
        }

        public string TrackContent
        {
            get
            {
                return _trackContent;
            }
            set
            {
                if (_trackContent != value)
                {
                    _trackContent = value;
                    NotifyPropertyChanged("TrackContent");
                }
            }
        }

        void UpdateData(int year)
        {
            Countries = dataService.UpdateData(year);
        }

        public double Year
        {
            get { return (double)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(double), typeof(WealthHealthViewModel), new PropertyMetadata(1800.0d, OnYearPropertyChanged));

        public event PropertyChangedEventHandler PropertyChanged;

        static void OnYearPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var w = obj as WealthHealthViewModel;
            if (w != null)
            {
                var newValue = (int)Math.Floor((double)e.NewValue);

                w.UpdateData(newValue);
            }
        }

        void ToggleAnimation()
        {
            var animation = new DoubleAnimation()
            {
                From = YearMin,
                To = YearMax,
                Duration = new Duration(TimeSpan.FromMilliseconds(AnimLength)),
                EnableDependentAnimation = true
            };
            if (_sb == null)
            {
                _sb = new Storyboard();
                _sb.Completed += _sb_Completed;
                _sb.Children.Add(animation);
            }
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, "Year");
            _sb.Begin();
            _content = ResumeTip;
        }

        private void _sb_Completed(object sender, object e)
        {
            Content = PauseTip;
        }

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        void PerformAnimation()
        {
            if (_sb != null)
            {
                if (Year == YearMax)
                {
                    Content = ResumeTip;
                    _sb.Begin();
                }
                else
                {
                    if (_sb.GetCurrentTime().Milliseconds == AnimLength || Content.Equals(PauseTip))
                    {
                        Content = ResumeTip;
                        _sb.Seek(TimeSpan.FromMilliseconds((double)(Year - YearMin) / (double)(YearMax - YearMin) * AnimLength));
                        _sb.Resume();
                    }
                    else
                    {
                        Content = PauseTip;
                        _sb.Pause();
                    }
                }
            }
        }

        public void StopAnimation()
        {
            if (_sb != null && Content.Equals(ResumeTip))
            {
                _sb.Pause();
                Content = PauseTip;
            }
        }
    }
}
