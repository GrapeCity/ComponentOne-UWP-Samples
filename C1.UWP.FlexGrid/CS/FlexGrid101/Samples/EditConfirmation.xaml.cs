using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexGrid101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class EditConfirmation : Page
    {
        public EditConfirmation()
        {
            InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.MinColumnWidth = 85;
        }

        private object _originalValue;

        private void OnBeginningEdit(object sender, CellEditEventArgs e)
        {
            _originalValue = grid[e.CellRange.Row, e.CellRange.Column];
        }

        private async void OnCellEditEnded(object sender, CellEditEventArgs e)
        {
            var originalValue = _originalValue;
            var currentValue = grid[e.CellRange.Row, e.CellRange.Column];
            if (!e.CancelEdits && (originalValue == null && currentValue != null || !originalValue.Equals(currentValue)))
            {
                MessageDialog msgbox = new MessageDialog(Strings.EditConfirmationQuestion, Strings.EditConfirmationQuestionTitle);

                msgbox.Commands.Clear();
                msgbox.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
                msgbox.Commands.Add(new UICommand { Label = "No", Id = 1 });

                var res = await msgbox.ShowAsync();

                if ((int)res.Id == 1)
                {
                    grid[e.CellRange.Row, e.CellRange.Column] = originalValue;
                }
            }
        }
    }
}
