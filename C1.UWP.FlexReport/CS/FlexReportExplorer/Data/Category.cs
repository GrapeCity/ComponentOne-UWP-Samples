using System;
using System.Collections.Generic;
using System.Reflection;

using Windows.UI.Xaml;

namespace C1FlexReportExplorer
{
    /// <summary>
    /// Represents a Category group
    /// </summary>
    public class Category : DependencyObject
    {
        public string Name { get; set; }
        public string Text { get; set; }        
        public string ImageUri { get; set; }
        public List<Report> Reports { get; set; }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(
                "IsExpanded",
                typeof(bool),
                typeof(Category),
                new PropertyMetadata(false)
                );
    }

    /// <summary>
    /// Represents an Item of group
    /// </summary>
    public class Report : DependencyObject
    {
        public string CategoryName { get; set; }
        public string ReportName { get; set; }
        public string FileName { get; set; }
        public string ReportTitle { get; set; }
        public string ImageUri { get; set; }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(
                "IsSelected",
                typeof(bool),
                typeof(Report),
                new PropertyMetadata(false)
                );
    }
}
