using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace InputSamples
{
    public class PaneToggleSwitchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SplitView view = (SplitView)parameter;
            if (view != null)
                view.IsPaneOpen = !view.IsPaneOpen;
        }
    }
}
