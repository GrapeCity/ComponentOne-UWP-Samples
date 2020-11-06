using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace FlexChart101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Toggle : Page
    {
        List<FruitDataItem> _fruits;

        public Toggle()
        {
            this.InitializeComponent();
        }

        public List<FruitDataItem> Data
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = DataCreator.CreateFruit();
                }

                return _fruits;
            }
        }
    }
}
