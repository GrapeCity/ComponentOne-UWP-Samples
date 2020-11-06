using C1.Xaml;
using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexGrid101
{
    public sealed partial class ColumnLayoutForm : ContentDialog
    {
        C1FlexGrid _grid;
        ObservableCollection<ColumnLayoutItemViewModel> _columns = new ObservableCollection<ColumnLayoutItemViewModel>();

        public ColumnLayoutForm(C1FlexGrid grid)
        {
            this.InitializeComponent();

            _grid = grid;
            PrimaryButtonText = Strings.OK;
            SecondaryButtonText = Strings.Cancel;

            foreach (var column in _grid.Columns)
            {
                _columns.Add(new ColumnLayoutItemViewModel(_columns, column));
            }
            DataContext = _columns;
            UpdateColumns();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            grid.FinishEditing();
            UpdateColumns();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        public void UpdateColumns()
        {
            try
            {
                for (int i = 0; i < _columns.Count; i++)
                {
                    var cvm = _columns[i];
                    var currentIndex = _grid.Columns.IndexOf(cvm.Column);
                    if (currentIndex != i)
                    {
                        _grid.Columns.Move(currentIndex, i);
                    }
                    if (cvm.IsVisible != cvm.Column.IsVisible)
                    {
                        cvm.Column.Visible = cvm.IsVisible;
                    }
                }
            }
            catch { }
        }
    }

    public class ColumnLayoutItemViewModel
    {
        public ColumnLayoutItemViewModel(ObservableCollection<ColumnLayoutItemViewModel> columns, Column column)
        {
            Columns = columns;
            Column = column;
            Title = column.ColumnName;
            IsVisible = column.IsVisible;
            UpCommand = new MoveCommand(param => this.MoveUp(), param => this.CanMoveUp());
            DownCommand = new MoveCommand(param => this.MoveDown(), param => this.CanMoveDown());
        }

        public ObservableCollection<ColumnLayoutItemViewModel> Columns { get; set; }
        public Column Column { get; set; }
        public string Title { get; set; }
        public ICommand UpCommand { get; set; }
        public ICommand DownCommand { get; set; }
        public bool IsVisible { get; set; }

        private bool CanMoveUp()
        {
            return Columns.IndexOf(this) > 0;
        }

        private void MoveUp()
        {
            var currentIndex = Columns.IndexOf(this);
            Columns.Move(currentIndex, currentIndex - 1);
            //Columns.RemoveAt(currentIndex);
            //Columns.Insert(currentIndex - 1, this);
            //UpdateCommands();
        }

        private bool CanMoveDown()
        {
            return Columns.IndexOf(this) < Columns.Count - 1;
        }

        private void MoveDown()
        {
            var currentIndex = Columns.IndexOf(this);
            Columns.Move(currentIndex, currentIndex + 1);
            //Columns.RemoveAt(currentIndex);
            //Columns.Insert(currentIndex + 1, this);
            //UpdateCommands();
        }

        //private void UpdateCommands()
        //{
        //    foreach (var column in Columns)
        //    {
        //        column.UpCommand.CanExecute()
        //        column.DownCommand.ChangeCanExecute();
        //    }
        //}
    }

    public class MoveCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public MoveCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public MoveCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }

        #endregion // ICommand Members
    }
}
