using System;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InputPanelSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IntegrationC1FlexGrid : Page
    {
        private ICommand viewDetailCommand;
        public ICommand ViewDetailCommand
        {
            get
            {
                return viewDetailCommand ?? (viewDetailCommand = new DelegateCommand(() => NavigateToDetails(), FlexGrid.SelectedItem!=null));
            }
        }

        public IntegrationC1FlexGrid()
        {
            InitializeComponent();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {               
                IntegrationToC1FlexGrid();
                this.DataContext = this;
            }
            else
            {
                InitalizeFlexGrid();
            }
        }       

        void IntegrationToC1FlexGrid()
        {
            var list = Data.LoadEmployee();
            FlexGrid.ItemsSource = new Data().EmployeeObservable;
            FlexGrid.SelectionMode = C1.Xaml.FlexGrid.SelectionMode.Row;
            FlexGrid.SelectedIndex = 0;    
        }     

        void InitalizeFlexGrid()
        {
            var list = Data.Load();         
            FlexGrid.ItemsSource = new Data().CustomerObservable;          
        }

        private void NavigateToDetails()
        {
            Employee employee = FlexGrid.SelectedItem as Employee;
            if (employee != null)
            {
                this.frame.Navigate(typeof(InputPanelCurrentItem), employee);
            }
        }
    }   
}
