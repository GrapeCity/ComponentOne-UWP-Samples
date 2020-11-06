using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class MyComboBox : ComboBox
    {       
        public MyComboBox()
        {
            this.DefaultStyleKey = typeof(MyComboBox);

            this.DropDownOpened += (o, e) =>
            {
                var dataContext = (o as MyComboBox).DataContext as Data.SettingParam;
                if (dataContext != null && dataContext.IsEnumType)
                {
                    var navList = ((e as RoutedEventArgs).OriginalSource as MyComboBox).Content as NavList;                   
                    navList.SelectedItem = dataContext.Value;
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
            typeof(MyComboBox),
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
            typeof(MyComboBox),
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
            typeof(MyComboBox),
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
            typeof(MyComboBox),
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
            typeof(MyComboBox),
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
            typeof(MyComboBox),
            new PropertyMetadata(null)
        );
    }
}
