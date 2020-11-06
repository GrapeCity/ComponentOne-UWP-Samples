using System;
using System.Windows.Input;

namespace BasicLibrarySamples
{
    public class DelegateCommand<T> : ICommand
    {
        private static readonly Action<T> EmptyExecute = (T) => { };
        private static readonly Func<T, bool> EmptyCanExecute = (T) => true;


        private Action<T> _execute;
        private Func<T, bool> _canExecute;

        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(T parameter)
        {
           _execute(parameter);
        }


        public bool CanExecute(T parameter)
        {
            return _canExecute(parameter);
        }


        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute((T)parameter);
        }


        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null)
            {
                h(this, EventArgs.Empty);
            }
        }


        void ICommand.Execute(object parameter)
        {
            this.Execute((T)parameter);
        }
    }

}
