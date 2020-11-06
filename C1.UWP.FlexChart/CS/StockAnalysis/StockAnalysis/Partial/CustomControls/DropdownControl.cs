using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class DropdownControl : ComboBox
    {
        public static EventHandler OnDropdownOpened;

        public DropdownControl()
        {
            this.DefaultStyleKey = typeof(DropdownControl);

            this.Tapped += (o, e) =>
            {
                if (IsPopupCenter)
                {

                    var ttv = this.TransformToVisual(Window.Current.Content);
                    Windows.Foundation.Point screenCoords = ttv.TransformPoint(new Windows.Foundation.Point(0, 0));

                    double hOffset = (Window.Current.Bounds.Width)/2;
                    double vOffset = (Window.Current.Bounds.Height)/2;

                    CustomHorizontalOffset = -screenCoords.X + hOffset - 160; // Size of popup
                    CustomVertialOffset = -screenCoords.Y + vOffset - 150; // Size of popup
                }
            };

            this.DropDownOpened += (o, e) =>
            {
                if (OnDropdownOpened != null)
                {                    
                    OnDropdownOpened(this, new EventArgs());
                }
            };
        }

        public object Display
        {
            get { return this.GetValue(DisplayProperty); }
            set { this.SetValue(DisplayProperty, value); }
        }
        public static DependencyProperty DisplayProperty = DependencyProperty.Register(
            "Display",
            typeof(object),
            typeof(DropdownControl),
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
            typeof(DropdownControl),
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
            typeof(DropdownControl),
            new PropertyMetadata(null)
        );

        public FrameworkElement Content
        {
            get { return (FrameworkElement)this.GetValue(ContentProperty); }
            set { this.SetValue(ContentProperty, value); }
        }
        public static DependencyProperty ContentProperty = DependencyProperty.Register(
            "Content",
            typeof(FrameworkElement),
            typeof(DropdownControl),
            new PropertyMetadata(null)
        );
        public double CustomHorizontalOffset
        {
            get { return (double)this.GetValue(CustomHorizontalOffsetProperty); }
            set { this.SetValue(CustomHorizontalOffsetProperty, value); }
        }
        public static DependencyProperty CustomHorizontalOffsetProperty = DependencyProperty.Register(
            "CustomHorizontalOffset",
            typeof(double),
            typeof(DropdownControl),
            new PropertyMetadata(null)
        );

        public double CustomVertialOffset
        {
            get { return (double)this.GetValue(CustomVertialOffsetProperty); }
            set { this.SetValue(CustomVertialOffsetProperty, value); }
        }
        public static DependencyProperty CustomVertialOffsetProperty = DependencyProperty.Register(
            "CustomVertialOffset",
            typeof(double),
            typeof(DropdownControl),
            new PropertyMetadata(null)
        );

        public bool IsPopupCenter
        {
            get { return (bool)this.GetValue(IsPopupCenterProperty); }
            set { this.SetValue(IsPopupCenterProperty, value); }
        }
        public static DependencyProperty IsPopupCenterProperty = DependencyProperty.Register(
            "IsPopupCenter",
            typeof(bool),
            typeof(DropdownControl),
            new PropertyMetadata(false)
        );
    }
}
