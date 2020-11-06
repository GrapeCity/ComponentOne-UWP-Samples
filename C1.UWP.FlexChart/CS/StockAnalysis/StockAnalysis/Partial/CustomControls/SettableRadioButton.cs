using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Partial.CustomControls
{
    public class SettableRadioButton : RadioButton
    {
        public SettableRadioButton()
        {
            this.DefaultStyleKey = typeof(SettableRadioButton);
        }

        public bool IsShowSetting
        {
            get { return (bool)this.GetValue(IsShowSettingProperty); }
            set { this.SetValue(IsShowSettingProperty, value); }
        }
        public static DependencyProperty IsShowSettingProperty = DependencyProperty.Register(
            "IsShowSetting",
            typeof(bool),
            typeof(SettableRadioButton),
            new PropertyMetadata(false)
        );
        
        public Command.SettingCommand SettingCommand
        {
            get { return (Command.SettingCommand)this.GetValue(SettingCommandProperty); }
            set { this.SetValue(SettingCommandProperty, value); }
        }

        public static DependencyProperty SettingCommandProperty = DependencyProperty.Register
            (
                "SettingCommand",
                typeof(Command.SettingCommand),
                typeof(SettableRadioButton),
                new PropertyMetadata(null)
            );

    }
}
