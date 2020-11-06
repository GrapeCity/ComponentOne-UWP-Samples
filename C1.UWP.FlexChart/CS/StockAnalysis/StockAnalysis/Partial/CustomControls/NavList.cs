using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace StockAnalysis.Partial.CustomControls
{
    public class NavList : ListBox
    {
        public NavList()
        {           
            this.DefaultStyleKey = typeof(NavList);            
        }
        
        public bool IsAutoCloseParentPopup
        {
            get { return (bool)this.GetValue(IsAutoCloseParentPopupProperty); }
            set { this.SetValue(IsAutoCloseParentPopupProperty, value); }
        }
        
        public static DependencyProperty IsAutoCloseParentPopupProperty = DependencyProperty.Register(
            "IsAutoCloseParentPopup",
            typeof(bool),
            typeof(NavList),
            new PropertyMetadata(false, new PropertyChangedCallback((o,e)=>
            {
                NavList nav = o as NavList;
                if (Convert.ToBoolean(e.NewValue))
                {
                    nav.SelectionChanged -= Nav_SelectionChanged;
                    nav.SelectionChanged += Nav_SelectionChanged;
                }
                else
                {
                    nav.SelectionChanged -= Nav_SelectionChanged;
                }
            }))
        );
        private static void Nav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavList nav = sender as NavList;
            Command.CloseDropdownCommand cmd = new Command.CloseDropdownCommand();
            if (e.AddedItems.Count > 0 && e.RemovedItems.Count > 0 && !e.RemovedItems[0].Equals(e.AddedItems[0]))
            {
                cmd.Execute(sender);
            }
        }
    }
}
