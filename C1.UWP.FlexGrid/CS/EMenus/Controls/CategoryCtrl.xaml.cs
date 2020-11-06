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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grapecity.C1_EMenus.Controls
{
    #region ClassCategoryCtrl
    public sealed partial class CategoryCtrl : UserControl
    {
        #region Constructor
        public CategoryCtrl( string imageUri, string name)
        {
            this.InitializeComponent();
            this.imgCategory.Source = new BitmapImage(new Uri(imageUri));
            this.Name = name;
        }
        #endregion

        #region Properties
        public Button ImgButton
        {
            get
            {
                return imgBtn;
            }
        }
        #endregion
    }
    #endregion
}
