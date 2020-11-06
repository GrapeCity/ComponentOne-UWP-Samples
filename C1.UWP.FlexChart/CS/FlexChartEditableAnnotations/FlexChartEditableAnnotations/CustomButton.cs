using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FlexChartEditableAnnotations
{
    public class CustomButton : Button
    {       
        public CustomButton()
        {                      
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.Padding = new Thickness(0);
        }

        public static readonly DependencyProperty CheckedProperty = DependencyProperty.RegisterAttached(
        "Checked",
        typeof(bool),
        typeof(CustomButton),
        new PropertyMetadata(null)
        );

        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set
            {
                SetValue(CheckedProperty, value);

                if (value == true)
                {
                    this.Background = new SolidColorBrush(Colors.LightSkyBlue);
                }
                else
                {
                    this.Background = new SolidColorBrush(Colors.Transparent);
                }
            }
        }
    }
}
