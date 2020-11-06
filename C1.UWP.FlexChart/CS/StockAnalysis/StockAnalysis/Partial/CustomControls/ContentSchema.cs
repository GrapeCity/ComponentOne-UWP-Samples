using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class ContentSchema : Control
    {
        public ContentSchema()
        {
            DefaultStyleKey = typeof(ContentSchema);
        }

        public Control Nav
        {
            get { return (Control)this.GetValue(NavProperty); }
            set { this.SetValue(NavProperty, value); }
        }
        public static DependencyProperty NavProperty = DependencyProperty.Register(
            "Nav",
            typeof(Control),
            typeof(ContentSchema),
            new PropertyMetadata(null)
        );

        public Control Settings
        {
            get { return (Control)this.GetValue(SettingsProperty); }
            set { this.SetValue(SettingsProperty, value); }
        }
        public static DependencyProperty SettingsProperty = DependencyProperty.Register(
            "Settings",
            typeof(Control),
            typeof(ContentSchema),
            new PropertyMetadata(null)
        );
        


        public FrameworkElement AnnotitionsSettings
        {
            get { return (FrameworkElement)this.GetValue(AnnotitionsSettingsProperty); }
            set { this.SetValue(AnnotitionsSettingsProperty, value); }
        }
        public static DependencyProperty AnnotitionsSettingsProperty = DependencyProperty.Register(
            "AnnotitionsSettings",
            typeof(FrameworkElement),
            typeof(ContentSchema),
            new PropertyMetadata(null)
        );

        public Control Chart
        {
            get { return (Control)this.GetValue(ChartProperty); }
            set { this.SetValue(ChartProperty, value); }
        }
        public static DependencyProperty ChartProperty = DependencyProperty.Register(
            "Chart",
            typeof(Control),
            typeof(ContentSchema),
            new PropertyMetadata(null)
        );

    }
}
