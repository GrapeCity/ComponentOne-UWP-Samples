using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace StockAnalysis.Command
{
    public class SettingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool canExecute = true;
        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public async void Execute(object parameter)
        {
            var key = parameter == null ? null : parameter.ToString();
            if (!string.IsNullOrEmpty(key))
            {
                Partial.SettingsDialog settingsDialog = new Partial.SettingsDialog(key);                
                await settingsDialog.ShowAsync();
            }
        }
    }
}
