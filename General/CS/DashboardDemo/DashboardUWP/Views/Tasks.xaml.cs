using C1.Xaml;
using C1.Xaml.FlexGrid;
using DashboardModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DashboardUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Tasks : Page, IUpdatablePage
    {
        public Tasks()
        {
            this.InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdataPage();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            All.CellFactory = new TaskCellFactory();
            InProgress.CellFactory = new TaskCellFactory();
            Completed.CellFactory = new TaskCellFactory();
            Deferred.CellFactory = new TaskCellFactory();
            Urgent.CellFactory = new TaskCellFactory();
        }

        public void UpdataPage()
        {
            int index = RootPivot.SelectedIndex;
            DataService.GetService().CampainTaskType = (CampainTaskType)index;
            C1CollectionView collectionView = DataService.GetService().CampainTaskCollction;
            if (collectionView != null && collectionView.CanGroup == true)
            {
                collectionView.GroupDescriptions.Clear();
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("AssignedTo"));
            }
            switch (index)
            {
                case 0:
                    All.ItemsSource = collectionView;
                    break;
                case 1:
                    InProgress.ItemsSource = collectionView;
                    break;
                case 2:
                    Completed.ItemsSource = collectionView;
                    break;
                case 3:
                    Deferred.ItemsSource = collectionView;
                    break;
                case 4:
                    Urgent.ItemsSource = collectionView;
                    break;
            }
        }
    }
}
