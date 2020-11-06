using System;
using System.Collections.Generic;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StockAnalysis.Partial.UserControls
{
    public sealed partial class Overlays : UserControl
    {
        public Overlays()
        {
            this.InitializeComponent();
        }

        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }

        private ClearListCommand clearCommand = null;
        public ClearListCommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new ClearListCommand();
                }
                return clearCommand;
            }
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Data.OverlayItem item in e.AddedItems)
            {
                if (!Model.OverlayTypes.Contains(item.Type))
                {
                    Model.OverlayTypes.Add(item.Type);
                }
            }
            foreach (Data.OverlayItem item in e.RemovedItems)
            {
                if (Model.OverlayTypes.Contains(item.Type))
                {
                    Model.OverlayTypes.Remove(item.Type);
                }
            }
        }
    }

    public class ClearListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ListBox list = parameter as ListBox;
            if (list != null)
            {
                list.SelectedIndex = -1;
            }
        }
    }
}
