using C1.Xaml.FlexGrid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlexGridSamples
{
    public partial class ExcelStyleMerge : Page
    {
        ExcelStyleMergeManager _xlMergeManager;

        public ExcelStyleMerge()
        {
            InitializeComponent();
            _xlMergeManager = new ExcelStyleMergeManager(_flex);
            _flex.MergeManager = _xlMergeManager;
            _flex.AllowMerging = AllowMerging.Cells;
            Loaded += ExcelStyleMerge_Loaded;
        }

        private async void ExcelStyleMerge_Loaded(object sender, RoutedEventArgs e)
        {
            var data = await NorthwindStorage.Load();
            _flex.ItemsSource = data;
        }

        void _btnMerge_Click(object sender, RoutedEventArgs e)
        {
            _xlMergeManager.AddMergedRange(_flex.Selection);
        }
        void _btnSplit_Click(object sender, RoutedEventArgs e)
        {
            _xlMergeManager.RemoveMergedRange(_flex.Selection);
        }
    }
}
