using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class DropdownMenu : ComboBox
    {
        public DropdownMenu()
        {
            DefaultStyleKey = typeof(DropdownMenu);
        }

        public object Display
        {
            get { return this.GetValue(DisplayProperty); }
            set { this.SetValue(DisplayProperty, value); }
        }
        public static DependencyProperty DisplayProperty = DependencyProperty.Register(
            "Display",
            typeof(object),
            typeof(DropdownMenu),
            new PropertyMetadata(null)
        );
        
        public DataTemplate DisplayTemplate
        {
            get { return (DataTemplate)this.GetValue(DisplayTemplateProperty); }
            set { this.SetValue(DisplayTemplateProperty, value); }
        }
        public static DependencyProperty DisplayTemplateProperty = DependencyProperty.Register(
            "DisplayTemplate",
            typeof(DataTemplate),
            typeof(DropdownMenu),
            new PropertyMetadata(null)
        );

        public FrameworkElement DropdownHeader
        {
            get { return (FrameworkElement)this.GetValue(DropdownHeaderProperty); }
            set { this.SetValue(DropdownHeaderProperty, value); }
        }
        public static DependencyProperty DropdownHeaderProperty = DependencyProperty.Register(
            "DropdownHeader",
            typeof(FrameworkElement),
            typeof(DropdownMenu),
            new PropertyMetadata(null)
        );
        
    }
}
