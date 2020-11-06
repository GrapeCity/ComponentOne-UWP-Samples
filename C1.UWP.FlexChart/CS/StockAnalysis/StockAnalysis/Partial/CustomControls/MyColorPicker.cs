using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class MyColorPicker : Control
    {
        public MyColorPicker()
        {
            this.DefaultStyleKey = typeof(MyColorPicker);
        }

        public Color SelectedColor
        {
            get { return (Color)this.GetValue(SelectedColorProperty); }
            set { this.SetValue(SelectedColorProperty, value); }
        }
        public static DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            "SelectedColor",
            typeof(Color),
            typeof(MyColorPicker),
            new PropertyMetadata(Colors.Black)
        );
        
        public string Description
        {
            get { return (string)this.GetValue(DescriptionProperty); }
            set { this.SetValue(DescriptionProperty, value); }
        }
        public static DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description",
            typeof(string),
            typeof(MyColorPicker),
            new PropertyMetadata(null)
        );
    }
}
