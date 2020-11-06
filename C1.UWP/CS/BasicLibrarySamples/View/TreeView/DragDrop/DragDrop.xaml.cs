using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using C1.Xaml;

namespace BasicLibrarySamples
{
    public sealed partial class DragDrop : Page
    {
        public DragDrop()
        {
            this.InitializeComponent();
            SampleTreeView.ItemsSource = BuildDepartmentTree();

            SampleTreeView.AllowDragDrop = true;
        }

        private ObservableCollection<object> BuildDepartmentTree()
        {
            ObservableCollection<object> itemsSource = new ObservableCollection<object>();
            IDictionary<int, Department> departmentDirectory = new Dictionary<int, Department>();

            // insert all departments as root nodes
            List<Department> departments = DataLoader.LoadDepartments();
            foreach (Department d in departments)
            {
                itemsSource.Add(d);
                departmentDirectory.Add(d.DepartmentID, d);
            }

            // insert all employees in their corresponding department
            List<Employee> employees = DataLoader.LoadEmployees();
            foreach (Employee e in employees)
            {
                Department d = departmentDirectory[e.DepartmentID];
                d.Employees.Add(e);
            }

            return itemsSource;
        }

        private void OnButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (SampleTreeView != null)
            {
                SampleTreeView.DropAction = (rb.Name.CompareTo("Move") == 0) ? DropAction.Move : DropAction.Copy;
            }
        }
    }
}
