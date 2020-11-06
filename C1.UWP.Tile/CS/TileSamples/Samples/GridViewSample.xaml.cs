using C1.Xaml;
using C1.Xaml.Tile;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TileSamples.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TileSamples
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GridViewSample : Page
    {
        public GridViewSample()
        {
            this.InitializeComponent();
            ObservableCollection<SampleItem> source = new ObservableCollection<SampleItem>();
            for (int i = 1; i < 45; i++)
            {
                source.Add(new SampleItem() { Title = Strings.SampleDataTitle + i, Header = Strings.SampleDataHeader + i });
            }
            gridView.ItemsSource = source;
        }
    }

    /// <summary>
    /// The GridView control is much more advanced ItemsControl than ListBox. It supports items reodering and dragging.
    /// It also can use WrapGrid as an ItemsPanel. That requires some additional code for correct working with C1 tiles in the GridView.ItemTemplate.
    /// Please, carefully read code comments for more information.
    /// </summary>
    public class MyGridView : GridView
    {
        public MyGridView()
        {
        }

        // The default GridView virtualization reuses the ContentTemplate visual tree for different elements.
        // The GridView creates the limited number of C1Tile objects and reuses them at scrolling. 
        // So, the C1Tile content is changed when end-user scrolls the GridView. 
        // Unfortunately, WrapGrid doesn't honor VirtualizingStackPanel.VirtualizationMode="Standard" setting.
        // So we need some code to workaround this issue.
        // To avoid ContentChange animations while scrolling, freeze tiles in the ClearContainerForItemOverride
        // and unfreeze after reusing them for the new item.
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            IList<DependencyObject> list = new List<DependencyObject>();
            VTreeHelper.GetChildrenOfType(element, typeof(C1TileBase), ref list);
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () =>
                {
                    // unfreeze tile after changing tile content.
                    foreach (C1TileBase tile in list)
                    {
                        tile.IsFrozen = false;
                    }
                });
        }
        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            IList<DependencyObject> list = new List<DependencyObject>();
            VTreeHelper.GetChildrenOfType(element, typeof(C1TileBase), ref list);
            foreach (C1TileBase tile in list)
            {
                tile.IsFrozen = true;
            }
            base.ClearContainerForItemOverride(element, item);
        }
     }
}
