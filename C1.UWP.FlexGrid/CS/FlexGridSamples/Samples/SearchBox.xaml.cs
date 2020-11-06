using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace FlexGridSamples
{
    public partial class SearchBox : Page
    {
        List<PropertyInfo> _propertyInfo = new List<PropertyInfo>();
        C1.Util.Timer _timer = new C1.Util.Timer();

        public SearchBox()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(800);
            _timer.Tick += _timer_Tick;
        }
        public ICollectionView View { get; set; }
        public List<PropertyInfo> FilterProperties
        {
            get { return _propertyInfo; }
        }
        void _txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_imgClear != null)
            {
                // update clear button visibility
                _imgClear.Visibility = string.IsNullOrEmpty(_txtSearch.Text)
                    ? Visibility.Collapsed
                    : Visibility.Visible;

                // start ticking
                _timer.Stop();
                _timer.Start();
            }
        }
        private void _imgClear_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            _txtSearch.Text = string.Empty;
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (View != null && _propertyInfo.Count > 0)
            {
                // ICollectionView does not support filtering in WinRT,
                // but IC1CollectionView does.
                var view = View as C1.Xaml.IC1CollectionView;
                if (view != null)
                {
                    view.Filter = Filter;
                    view.Refresh();
                }
            }
        }
        bool Filter(object item)
        {
            // get search text
            var srch = _txtSearch.Text;

            // no text? show all items
            if (string.IsNullOrEmpty(srch))
            {
                return true;
            }

            // show items that contain the text in any of the specified properties
            foreach (PropertyInfo pi in _propertyInfo)
            {
                var value = pi.GetValue(item, null) as string;
                if (value != null && value.IndexOf(srch, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    return true;
                }
            }

            // exclude this item...
            return false;
        }
    }
}
