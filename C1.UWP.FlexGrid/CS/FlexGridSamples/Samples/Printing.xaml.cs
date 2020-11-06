using C1.Xaml.FlexGrid;
using System;
using System.Linq;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Graphics.Printing;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;
using Windows.Graphics.Printing.OptionDetails;

namespace FlexGridSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Printing : Page
    {
        ICollectionView _data = Product.GetProducts(100);

        public Printing()
        {
            this.InitializeComponent();

            // populate grid
            _flex.ItemsSource = _data;
            _flex.Columns["Line"].AllowMerging = true;
            _flex.Columns["Color"].AllowMerging = true;

            // for testing
            _flex.AllowResizing = AllowResizing.Both;
        }

        #region ** printing
        
        void _btnPrint_Click(object sender, RoutedEventArgs e)
        {
            _flex.Print(new PrintParameters()
            {
                DocumentName = Strings.SamplePrint,
                ScaleMode = ScaleMode.PageWidth
            });
        }

        #endregion
    }
}
