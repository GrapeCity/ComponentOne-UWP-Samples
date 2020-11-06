using C1.Xaml;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlexGridSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FullTextFilter : Page
    {
        C1CollectionView _c1CollectionView;

        public string TextFilter;
        public FullTextFilterCondition FilterCondition;
        public FullTextFilter()
        {
            this.InitializeComponent();
            c1FlexGrid1.GroupHeaderConverter = new MyGroupConverter();

            FilterCondition = new FullTextFilterCondition();
            FilterCondition.BindingPaths = new List<string>() { "Name", "Line", "Color", "Price", "Weight", "Cost", "Volume", "Rating" };

            c1FlexGrid1.DataContext = new ViewModel();
            c1FlexGrid1.Loaded += C1FlexGrid1_Loaded;
        }

        private void C1FlexGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            _c1CollectionView = c1FlexGrid1.CollectionView as C1CollectionView;
            c1FlexGrid1.CellFactory = new FullTextFilterCellFactory(this);
        }

        void UpdateFiltering()
        {
            // Update FullTextFilterCondition
            FilterCondition.MatchCase = _cbMatchCase.IsChecked ?? false;
            FilterCondition.MatchWholeWord = _cbMatchWholeWord.IsChecked ?? false;
            FilterCondition.TreatSpacesAsAndOperator = _cbTreatSpaceAsAnd.IsChecked ?? false;

            TextFilter = filterTextBox.Text;

            // Apply FullTextFilter
            _c1CollectionView.ApplyFullTextFilter(TextFilter, FilterCondition);
        }

        void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFiltering();
        }

        private void FullTextFilterUpdated(object sender, RoutedEventArgs e)
        {
            if (_c1CollectionView != null)
                UpdateFiltering();
        }
    }
}
