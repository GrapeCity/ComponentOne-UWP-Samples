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
    #region ClassItemOrderCtrl
    public sealed partial class ItemOrderCtrl : UserControl
    {
        #region Contructor
        public ItemOrderCtrl(string imageuri, string itemText, string description, int Rating, bool iconVeg, bool iconSpecial, double prizeRegular, double prizeMedium, double prizeLarge)
        {
            this.InitializeComponent();
            if (System.IO.File.Exists(imageuri))
            {
                this.imgItem.Source = new BitmapImage(new Uri("ms-appx:///" + imageuri));
            }
            else
            {
                this.imgItem.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/ImageNotFound.png"));
            }
            this.txtName.Text = itemText;
            this.txtDescription.Text = description;
            this.txtRPrize.Text +=": "+ prizeRegular.ToString();
            this.txtMPrize.Text += ": " + prizeMedium.ToString();
            this.txtLPrize.Text += ": " + prizeLarge.ToString();
            this.txtQty.Text = "1";
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(stackPanelStar); i++)
            {
                var child = VisualTreeHelper.GetChild(stackPanelStar, i);
                Path path = (child as Path);
                path.Fill = new SolidColorBrush(Color.FromArgb(255, 236, 157, 9));
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

        #region properties
        public Button BtnAddToCart { get { return btnAddToCart; } }
        public Button BtnMinus { get { return btnMinus; } }
        public Button BtnPlus { get { return btnPlus; } }
        public TextBox TextQty { get { return txtQty; } }
        public ToggleButton TglBtnRegular { get { return tglBtnRegular; } }
        public ToggleButton TglBtnMedium { get { return tglBtnMedium; } }
        public ToggleButton TglBtnLarge { get { return tglBtnLarge; } }
        #endregion
    }
    #endregion
}
