using System;
using System.Windows.Input;

namespace DrillDown
{
    public class RelayCommand : ICommand
    {
        private Action<string> _execute;

        public RelayCommand(Action<string> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter as string);
        }
    }
}
