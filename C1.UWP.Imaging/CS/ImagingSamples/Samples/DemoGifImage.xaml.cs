using C1.Xaml.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ImagingSamples
{
    public sealed partial class DemoGifImage : Page
    {
        C1GifImage _gifImage;
        bool _play = false;

        public DemoGifImage()
        {
            InitializeComponent();

            _gifImage = new C1GifImage(new Uri("ms-appx:///ImagingSamplesLib/Assets/C1FlexChartZoom.gif"));

            image.Source = _gifImage;
        }

        public bool Play
        {
            get { return _play; }
            set
            {
                if (_play != value)
                {
                    _play = value;
                    if (_play)
                    {
                        _gifImage.Play();
                    }
                    else
                    {
                        _gifImage.Stop();
                    }
                }
            }
        }
    }
}
