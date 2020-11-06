using StockAnalysis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class SettingList : ItemsControl
    {
        public SettingList()
        {
            this.DefaultStyleKey = typeof(SettingList);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var container = new SettingListItem();
            ((SettingListItem)container).Style = App.Current.Resources["settingListItem_Normal"] as Style;
            return container;
        }       
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            SettingParam setting = item as SettingParam;
            Type type = setting.Type;
            SettingListItem container = element as SettingListItem;

            if (type.Equals(typeof(UInt32)))
            {
                container.Style = App.Current.Resources["settingListItem_UInt32"] as Style;                
            } 
            else if (type.Equals(typeof(Double)))
            {
                container.Style = App.Current.Resources["settingListItem_Double"] as Style;
            }
            else if (type.Equals(typeof(Boolean)))
            {
                container.Style = App.Current.Resources["settingListItem_Boolean"] as Style;
            }
            else if (type.Equals(typeof(Windows.UI.Xaml.Media.Brush)))
            {
                container.Style = App.Current.Resources["settingListItem_Brush"] as Style;
            }
            else if (type.GetTypeInfo().IsEnum)
            {               
                container.Style = App.Current.Resources["settingListItem_Enum"] as Style;
            }
            else if (type.Equals(typeof(Object.Threshold)))
            {
                container.Style = App.Current.Resources["settingListItem_Threshold"] as Style;
            }           
            base.PrepareContainerForItemOverride(element, item);
        }        
    }
}
