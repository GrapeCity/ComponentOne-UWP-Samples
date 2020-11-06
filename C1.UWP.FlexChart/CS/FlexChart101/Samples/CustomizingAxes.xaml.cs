using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace FlexChart101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomizingAxes : Page
    {
        List<FruitDataItem> _data;

        public CustomizingAxes()
        {
            this.InitializeComponent();
        }

        public List<FruitDataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataCreator.CreateFruit();
                }

                return _data;
            }
        }
    }
}
