using ControlExplorer.Common;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlsPage : Page
    {
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public ControlsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            object[] parameters = e.Parameter as object[];
            MainViewModel mvm = parameters[0] as MainViewModel;
            this.defaultViewModel["Controls"] = mvm.Controls;
            this.defaultViewModel["Groups"] = mvm.Groups;
            this.defaultViewModel["NewControls"] = mvm.NewControls;
            this.defaultViewModel["TopControls"] = mvm.TopControls;
            this.defaultViewModel["Navigation"] = parameters[1];
        }


        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var control = e.ClickedItem as ControlDescription;
            if (control != null)
            {
                var navigation = DefaultViewModel["Navigation"] as NavigationHelper;
                this.Frame.Navigate(typeof(SamplesPage),
                    new NavigationParameter(control, navigation));
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var toggleButton = sender as ToggleButton;
            if (toggleButton != null)
            {
                var group = toggleButton.DataContext as GroupDescription;
                group.IsExpanded = toggleButton.IsChecked.Value;
            }
        }

        private void ExpandedButtonClick(object sender, RoutedEventArgs e)
        {
            ExpandCollapseAll(true);
        }

        private void CollapsedButtonClick(object sender, RoutedEventArgs e)
        {
            ExpandCollapseAll(false);
        }

        void ExpandCollapseAll(bool isExpand)
        {
            var groups = this.defaultViewModel["Groups"] as List<GroupDescription>;
            if (groups != null)
            {
                groups.ForEach(g => g.IsExpanded = isExpand);
            }
        }
    }

    public class C1GridView : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var gridViewItem = element as GridViewItem;
            if (gridViewItem != null)
            {
                var binding = new Binding();
                binding.Mode = BindingMode.TwoWay;
                binding.Path = new PropertyPath("Visible");
                binding.Converter = new BooleanToVisibilityConverter();
                gridViewItem.SetBinding(GridViewItem.VisibilityProperty, binding);
            }
        }
    }

    public class C1ToggleButton : ToggleButton
    {
        public C1ToggleButton()
        {
            this.RegisterPropertyChangedCallback(IsCheckedProperty, new DependencyPropertyChangedCallback(OnIsCheckedPropertyChanged));
        }

        static void OnIsCheckedPropertyChanged(DependencyObject obj, DependencyProperty e)
        {
            if (e == C1ToggleButton.IsCheckedProperty)
            {
                var toggleButton = obj as C1ToggleButton;
                if (toggleButton != null)
                {
                    VisualStateManager.GoToState(toggleButton, toggleButton.IsChecked.Value ? "Checked" : "CheckedPointOver", true);
                }
            }
        }
    }
}
