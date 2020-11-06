using DashboardModel;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DashboardUWP
{
    public sealed partial class RangeSelector : UserControl
    {
        List<SaleItem> items;

        public RangeSelector()
        {
            this.InitializeComponent();
        }

        public event DateRangeChangedEvent DateRangeChanged;

        void RasisedDateRangeChangedEvent(DateRange dateRange)
        {
            if (DateRangeChanged != null)
                DateRangeChanged(this, new DateRangeChangedEventArgs(dateRange));
        }

        public List<SaleItem> DateSaleItemSource { get { return items; } }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            items = DataService.GetService().DateSaleList;
            Chart.ItemsSource = items;
        }

        private void OnSelectorValueChanged(object sender, EventArgs e)
        {
            DateRange dateRange = new DateRange();
            dateRange.Start = items[(int)Selector.LowerValue].Date;
            dateRange.End = items[(int)Selector.UpperValue].Date;
            RasisedDateRangeChangedEvent(dateRange);
        }
    }
}
