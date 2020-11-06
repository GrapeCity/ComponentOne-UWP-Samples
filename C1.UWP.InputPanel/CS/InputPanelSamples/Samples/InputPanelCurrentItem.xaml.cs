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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InputPanelSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InputPanelCurrentItem : Page
    {
        private ICommand backFlexGridCommand;
        public ICommand BackFlexGridCommand
        {
            get
            {
                return backFlexGridCommand ?? (backFlexGridCommand = new DelegateCommand(() => NavigateToFlexGrid(), true));
            }
        }

        public InputPanelCurrentItem()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameter = e.Parameter;
            if (parameter != null)
            {
                var employee = parameter as Employee;
                if (employee != null)
                {
                    InputPanel.CurrentItem = employee;
                }
            }
        }

        private void NavigateToFlexGrid()
        {
            if (this.Frame!= null)
            {
                this.Frame.Navigate(typeof(IntegrationC1FlexGrid));
            }
        }
    }
}
