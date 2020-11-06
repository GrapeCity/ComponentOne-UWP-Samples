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
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using C1.Chart;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InputSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MultiSelect : Page
    {
        private PaneToggleSwitchCommand toggleSwitchCommand;

        bool installing;

        public MultiSelect()
        {
            this.InitializeComponent();

            if (AppHelper.IsWindowsPhoneDevice())
            {
                RootView.OpenPaneLength = Window.Current.Bounds.Width;
                FontSize = 12;
            }
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

        public Dictionary<string,AccountType> AccountTypes { get { return DataProvider.GetProvider().AccountTypes; } }
        public Dictionary<string, IncomeType> IncomeTypes { get { return DataProvider.GetProvider().IncomeTypes; } }
        public Dictionary<string, ExpenseType> ExpenseTypes { get { return DataProvider.GetProvider().ExpenseTypes; } }

        public List<string> FamilyMembers { get { return DataProvider.GetProvider().FamilyMembers; } }

        public C1CollectionView Incomes { get { return DataProvider.GetProvider().Incomes; } }
        public C1CollectionView Expenses { get { return DataProvider.GetProvider().Expenses; } }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            installing = true;
            DisplayInformation.GetForCurrentView().OrientationChanged += MultiSelect_OrientationChanged;
            FamilyMemberSelect.SelectAll();
            AccountSelect.SelectedItems.Add(AccountSelect.Items[0]);
            AccountSelect.SelectedItems.Add(AccountSelect.Items[2]);
            IncomeDetailsSelect.SelectedItems.Add(IncomeDetailsSelect.Items[0]);
            IncomeDetailsSelect.SelectedItems.Add(IncomeDetailsSelect.Items[1]);
            ExpenseDetailsSelect.SelectedItems.Add(ExpenseDetailsSelect.Items[0]);
            ExpenseDetailsSelect.SelectedItems.Add(ExpenseDetailsSelect.Items[1]);
            ExpenseDetailsSelect.SelectedItems.Add(ExpenseDetailsSelect.Items[5]);
            FamilyMemberSelect.AddHandler(PointerPressedEvent, new PointerEventHandler(OnPointerPressed), true);
            AccountSelect.AddHandler(PointerPressedEvent, new PointerEventHandler(OnPointerPressed), true);
            IncomeDetailsSelect.AddHandler(PointerPressedEvent, new PointerEventHandler(OnPointerPressed), true);
            ExpenseDetailsSelect.AddHandler(PointerPressedEvent, new PointerEventHandler(OnPointerPressed), true);
            installing = false;
        }

        private void MultiSelect_OrientationChanged(DisplayInformation sender, object args)
        {
            if (AppHelper.IsWindowsPhoneDevice())
            {
                switch (sender.CurrentOrientation)
                {
                    case DisplayOrientations.Landscape:
                    case DisplayOrientations.LandscapeFlipped:
                        IncomeChart.LegendPosition = Position.Left;
                        ExpenseChart.LegendPosition = Position.Left;
                        break;
                    case DisplayOrientations.Portrait:
                    case DisplayOrientations.PortraitFlipped:
                        IncomeChart.LegendPosition = Position.Bottom;
                        ExpenseChart.LegendPosition = Position.Bottom;
                        break;
                }
            }
        }

        private void OnFamilyMemberSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppHelper.IsWindowsPhoneDevice() && !installing)
            {
                RootView.IsPaneOpen = false;
            }
            List<string> addItems;
            List<string> removeItems;
            CreateAddAndRemoveItems(true, e, out addItems, out removeItems);
            DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterFamilyMembers, DataFilterType.Name);
        }

        private void OnAccountSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppHelper.IsWindowsPhoneDevice() && !installing)
            {
                RootView.IsPaneOpen = false;
            }
            List<AccountType> addItems;
            List<AccountType> removeItems;
            CreateAddAndRemoveItems(false, e, out addItems, out removeItems);
            DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterAccountTypes, DataFilterType.Account);
        }

        private void OnIncomeDetailsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppHelper.IsWindowsPhoneDevice() && !installing)
            {
                RootView.IsPaneOpen = false;
            }
            List<IncomeType> addItems;
            List<IncomeType> removeItems;
            CreateAddAndRemoveItems(false, e, out addItems, out removeItems);
            DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterIncomeTypes, DataFilterType.Income);
        }

        private void OnExpenseDetailsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppHelper.IsWindowsPhoneDevice() && !installing)
            {
                RootView.IsPaneOpen = false;
            }
            List<ExpenseType> addItems;
            List<ExpenseType> removeItems;
            CreateAddAndRemoveItems(false,e,out addItems,out removeItems);
            DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterExpenseTypes, DataFilterType.Expense);
        }

        private void CreateAddAndRemoveItems<T>(bool isString, SelectionChangedEventArgs e, out List<T> addItems, out List<T> removeItems)
        {
            addItems = new List<T>();
            removeItems = new List<T>();
            foreach (object item in e.AddedItems)
            {
                T member = isString ? (T)item : ((KeyValuePair<string, T>)item).Value;
                addItems.Add(member);
            }
            foreach (object item in e.RemovedItems)
            {
                T member = isString ? (T)item : ((KeyValuePair<string, T>)item).Value;
                removeItems.Add(member);
            }
        }

        bool IsClickToggleButton(DependencyObject element)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            if (parent == null)
                return false;
            else if (parent is ToggleButton)
                return true;
            else
                return IsClickToggleButton(parent);
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement element = e.OriginalSource as FrameworkElement;
            bool result = IsClickToggleButton(element);
            if (result)
                (sender as C1MultiSelect).Focus(FocusState.Keyboard);
        }
    }
}
