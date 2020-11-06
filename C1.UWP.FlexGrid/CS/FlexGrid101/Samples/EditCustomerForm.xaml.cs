using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class EditCustomerForm : ContentDialog
    {
        private Customer editingCustomer;
        public EditCustomerForm(Customer cust)
        {
            InitializeComponent();

            if (cust != null)
            {
                // initialize input form with values from the selected customer
                this.editingCustomer = cust;
                entryFirstName.Text = cust.FirstName;
                entryLastName.Text = cust.LastName;
                datePickerLastOrder.Date = cust.LastOrderDate;
                entryOrderTotal.Text = cust.OrderTotal.ToString("n4");
            }

            Title = Strings.EditCustomer;
            PrimaryButtonText = Strings.Apply;
            SecondaryButtonText = Strings.Cancel;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // save new values to the customer object
            this.editingCustomer.FirstName = entryFirstName.Text;
            this.editingCustomer.LastName = entryLastName.Text;
            this.editingCustomer.LastOrderDate = datePickerLastOrder.Date.Date;
            double orderTotal;
            if (double.TryParse(entryOrderTotal.Text, out orderTotal))
                this.editingCustomer.OrderTotal = orderTotal;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
