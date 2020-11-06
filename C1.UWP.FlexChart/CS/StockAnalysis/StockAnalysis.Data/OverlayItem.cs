using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Data
{
    public class ListDataItem : DependencyObject
    {
        public string Name
        {
            get { return (string)this.GetValue(NameProperty); }
            set { this.SetValue(NameProperty, value); }
        }

        public static DependencyProperty NameProperty = DependencyProperty.Register
            (
                "Name",
                typeof(string),
                typeof(ListDataItem),
                new PropertyMetadata(null)
            );


        public object Tag
        {
            get { return this.GetValue(TagProperty); }
            set { this.SetValue(TagProperty, value); }
        }

        public static DependencyProperty TagProperty = DependencyProperty.Register
            (
                "Tag",
                typeof(object),
                typeof(ListDataItem),
                new PropertyMetadata(null)
            );

    }

    public class OverlayItem : ListDataItem
    {
        public Data.OverlayType Type
        {
            get { return (Data.OverlayType)this.GetValue(TypeProperty); }
            set { this.SetValue(TypeProperty, value); }
        }

        public static DependencyProperty TypeProperty = DependencyProperty.Register
            (
                "Type",
                typeof(Data.OverlayType),
                typeof(OverlayItem),
                new PropertyMetadata(Data.OverlayType.None)
            );



        public bool IsShowSettings
        {
            get { return (bool)this.GetValue(IsShowSettingsProperty); }
            set { this.SetValue(IsShowSettingsProperty, value); }
        }

        public static DependencyProperty IsShowSettingsProperty = DependencyProperty.Register
            (
                "IsShowSettings",
                typeof(bool),
                typeof(OverlayItem),
                new PropertyMetadata(true)
            );

    }
    public class ImageListDataItem : ListDataItem
    {
        public ImageSource Source
        {
            get { return (ImageSource)this.GetValue(SourceProperty); }
            set { this.SetValue(SourceProperty, value); }
        }

        public static DependencyProperty SourceProperty = DependencyProperty.Register
            (
                "Source",
                typeof(ImageSource),
                typeof(ListDataItem),
                new PropertyMetadata(null)
            );
    }
}
