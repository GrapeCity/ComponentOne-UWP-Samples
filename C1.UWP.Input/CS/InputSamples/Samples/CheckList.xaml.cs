using C1.Xaml;
using C1.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InputSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CheckList : Page
    {
        private PaneToggleSwitchCommand toggleSwitchCommand;

        private ObservableCollection<Factory> factoryItems;
        private ObservableCollection<Office> officeItems;

        public CheckList()
        {
            this.InitializeComponent();
            if(AppHelper.IsWindowsPhoneDevice())
            {
                RootView.OpenPaneLength = Window.Current.Bounds.Width;
                FontSize = 12;
            }
            officeItems = new ObservableCollection<Office>();
            factoryItems = new ObservableCollection<Factory>();
        }

        public PaneToggleSwitchCommand ToggleSwitchCommand
        {
            get
            {
                if (toggleSwitchCommand == null)
                    toggleSwitchCommand = new PaneToggleSwitchCommand();
                return toggleSwitchCommand;
            }
        }

        public List<Office> Offices { get { return DataProvider.GetProvider().DistributionData.Offices; } }
        public List<Factory> Factories { get { return DataProvider.GetProvider().DistributionData.Factories; } }

        public ObservableCollection<Office> OfficeItems { get { return officeItems; } }
        public ObservableCollection<Factory> FactoryItems { get { return factoryItems; } }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            FactorySelector.SelectAll();
            OfficeSelector.SelectAll();
        }

        private void OnFactorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppHelper.IsWindowsPhoneDevice())
                RootView.IsPaneOpen = false;
            Update((sender as C1CheckList), FactoryItems, e);
        }

        private void OnOfficeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppHelper.IsWindowsPhoneDevice())
                RootView.IsPaneOpen = false;
            Update((sender as C1CheckList), OfficeItems, e);
        }

        private void Update<T>(C1CheckList checkList,ObservableCollection<T> source,SelectionChangedEventArgs e)
        {
            foreach(T addItem in e.AddedItems)
            {
                if (!source.Contains(addItem))
                    source.Add(addItem);
            }
            foreach(T removeItem in e.RemovedItems)
            {
                if (source.Contains(removeItem))
                    source.Remove(removeItem);
            }
        }
    }
}
