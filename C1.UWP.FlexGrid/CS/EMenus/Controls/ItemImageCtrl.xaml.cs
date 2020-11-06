using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grapecity.C1_EMenus.Controls
{
    #region ClassItemImageCtrl
    public sealed partial class ItemImageCtrl : UserControl
    {
        #region Constructor
        public ItemImageCtrl(string imgUri,string itemText, int Rating, bool isEnabled, bool iconVeg, bool iconSpecial )
        {
            this.InitializeComponent();
            if (System.IO.File.Exists(imgUri))
            {
                this.imgItem.Source = new BitmapImage(new Uri("ms-appx:///"+imgUri));
            }
            else
            {
                this.imgItem.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/ImageNotFound.png"));
            }
            this.txtName.Text = itemText;
            this.imgBtn.IsEnabled = isEnabled;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(stackPanelStar); i++)
            {
                var child = VisualTreeHelper.GetChild(stackPanelStar, i);
                Path path = (child as Path);
                path.Fill = new SolidColorBrush(Color.FromArgb(255,236, 157, 9));
                if (i == Rating - 1) break;
            }
            if (!iconSpecial)
            {
                gridIconSpecial.Visibility = Visibility.Collapsed;
            }
            if (!iconVeg)
            {
                gridIconVeg.Visibility = Visibility.Collapsed;
            }
            else
            {
                gridIconNonVeg.Visibility = Visibility.Collapsed;
            }
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
