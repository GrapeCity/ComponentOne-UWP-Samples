using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Command
{
    class CloseDropdownCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var parameterType = parameter.GetType();
            DependencyObject obj = parameter as DependencyObject;
            if (obj != null)
            {
                var popUps = VisualTreeHelper.GetOpenPopups(Window.Current);
                foreach (var popup in popUps)
                {
                    if (Utilities.Helper.FindControl<FrameworkElement>(popup.Child, parameterType, ((FrameworkElement)parameter).Name) != null && popup.IsOpen)
                    {
                        popup.IsOpen = false;
                    }
                }               
            }
        }
    }
}
