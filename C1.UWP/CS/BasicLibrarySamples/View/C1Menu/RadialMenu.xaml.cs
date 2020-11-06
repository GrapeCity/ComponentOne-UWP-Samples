using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BasicLibrarySamples;
using C1.Xaml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BasicLibrarySamples
{
    public sealed partial class RadialMenu : Page
    {
        public RadialMenu()
        {
            UndoCommand = new DelegateCommand<object>(ExecuteUndoCommand, GetCanExecuteUndoCommand);
            RedoCommand = new DelegateCommand<object>(ExecuteRedoCommand, GetCanExecuteRedoCommand);
            ClearFormatCommand = new DelegateCommand<object>(ExecuteClearFormatCommand, GetCanExecuteClearFormatCommand);
            this.InitializeComponent();
        }

        private void contextMenu_ItemClick(object sender, SourcedEventArgs e)
        {
            C1RadialMenuItem item = e.Source as C1RadialMenuItem;
            if (item is C1RadialColorItem)
            {
                this.text.Foreground = ((C1RadialColorItem)item).Brush;
                txt.Text = Strings.ContextMenuItemClickTB + " " + ((C1RadialColorItem)item).Color.ToString();
            }
            else if (item is C1RadialNumericItem)
            {
                txt.FontSize = ((C1RadialNumericItem)item).Value;
                txt.Text = Strings.ContextMenuItemClickTB + " " + ((C1RadialNumericItem)item).Value.ToString();
            }
            else
            {
                txt.Text = Strings.ContextMenuItemClickTB + " " + (item.Header ?? item.Name).ToString();
            }
        }

        private void contextMenu_ItemOpened(object sender, SourcedEventArgs e)
        {
            C1RadialMenuItem item = e.Source as C1RadialMenuItem;
            txt.Text = Strings.RadialMenuItemOpenedTB + " " + (item.Header ?? item.Name).ToString();
        }

        #region ** Commands
        // define some commands and attach them to menu items in xaml
        public DelegateCommand<object> UndoCommand { get; set; }

        private void ExecuteUndoCommand(object parameter)
        {
            txt.Text = Strings.RadialMenuUnDo;
            _canExecuteUndo = false;
            _canExecuteRedo = true;
            UndoCommand.RaiseCanExecuteChanged();
            RedoCommand.RaiseCanExecuteChanged();
        }

        private bool _canExecuteUndo = false;
        private bool GetCanExecuteUndoCommand(object parameter)
        {
            return _canExecuteUndo;
        }

        public DelegateCommand<object> RedoCommand { get; set; }

        private void ExecuteRedoCommand(object parameter)
        {
            txt.Text = Strings.RadialMenuReDo;
            _canExecuteUndo = true;
            _canExecuteRedo = false;
            UndoCommand.RaiseCanExecuteChanged();
            RedoCommand.RaiseCanExecuteChanged();
        }

        private bool _canExecuteRedo = false;
        private bool GetCanExecuteRedoCommand(object parameter)
        {
            return _canExecuteRedo;
        }

        public DelegateCommand<object> ClearFormatCommand { get; set; }

        private void ExecuteClearFormatCommand(object parameter)
        {
            txt.Text = Strings.RadialMenuClear;
            _canExecuteUndo = true;
            _canExecuteRedo = false;
            UndoCommand.RaiseCanExecuteChanged();
            RedoCommand.RaiseCanExecuteChanged();
        }

        private bool GetCanExecuteClearFormatCommand(object parameter)
        {
            return true;
        }
        #endregion

        private void contextMenu_Opened(object sender, EventArgs e)
        {
            // expand menu immediately, as in this sample we don't have underlying editable controls
            contextMenu.Expand();
        }

    }
}
