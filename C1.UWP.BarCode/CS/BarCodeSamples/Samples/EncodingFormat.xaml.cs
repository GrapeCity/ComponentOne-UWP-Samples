using C1.BarCode;
using C1.Xaml;
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
using Windows.UI.Xaml.Navigation;


namespace BarCodeSamples
{
    /// <summary>
    /// Class defined to store the properties of a category
    /// </summary>
    class Category
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Format Format { get; set; }
        public Category(string key, string value, Format format)
        {
            Key = key;
            Value = value;
            Format = format;
        }
    }

    public sealed partial class EncodingFormat : Page
    {
        List<Category> Categories = new List<Category>();
        Dictionary<string, CodeType> CodeTypes = new Dictionary<string, CodeType>();
        public EncodingFormat()
        {
            this.InitializeComponent();
            
            this.Loaded += OnLoaded;            
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            CreateCodeTypes();
            CreateCategories();
            this.barCodeTypes.DataContext = CodeTypes;
            this.categories.DataContext = Categories;
            this.barCodeTypes.SelectedItem = CodeTypes.ElementAt(0);
            this.categories.SelectedItem = Categories.ElementAt(3);
        }

        private void CreateCodeTypes()
        {
            if (CodeTypes.Count == 0)
            {
                CodeTypes.Add("../Assets/QRCode.png", CodeType.QRCode);
                CodeTypes.Add("../Assets/DataMatrix.png", CodeType.DataMatrix);
                CodeTypes.Add("../Assets/PDF417.png", CodeType.Pdf417);
                CodeTypes.Add("../Assets/Code39X.png", CodeType.Code39x);
            }
        }

        private void CreateCategories()
        {
            if (Categories.Count == 0)
            {
                Categories.Add(new Category("../Assets/Email.png", Strings.EmailMark, Format.Email));
                Categories.Add(new Category("../Assets/Text.png", Strings.TextMark, Format.Text));
                Categories.Add(new Category("../Assets/Url.png", Strings.UrlMark, Format.Url));
                Categories.Add(new Category("../Assets/VCard.png", Strings.VCardMark, Format.VCard));
            }
        }

        private void barCodeTypes_SelectionChanged(object sender, EventArgs e)
        {
            var listBox = sender as C1ListBox;
            var selectedItem = listBox.SelectedItem;
            if (selectedItem != null)
            {
                var item = (KeyValuePair<string, CodeType>)selectedItem;
                CurrentCodeType = (CodeType)item.Value;
            }
        }

        private void encodingTypes_SelectionChanged(object sender, EventArgs e)
        {
            var listBox = sender as C1ListBox;
            var selectedItem = listBox.SelectedItem;
            if (selectedItem != null)
            {
                var item = (Category)selectedItem;
                CurrentCategory = item.Format;
                
            }
        }

        #region
        public Visibility ShowStatus
        {
            get { return (Visibility)GetValue(ShowStatusProperty); }
            set { SetValue(ShowStatusProperty, value); }
        }

        public static readonly DependencyProperty ShowStatusProperty =
            DependencyProperty.Register("ShowStatus", typeof(Visibility), typeof(EncodingFormat), new PropertyMetadata(Visibility.Collapsed));

        public CodeType CurrentCodeType
        {
            get { return (CodeType)GetValue(CurrentCodeTypeProperty); }
            set
            {
                SetValue(CurrentCodeTypeProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentCodeTypeProperty =
            DependencyProperty.Register(
                "CurrentCodeType",
                typeof(CodeType),
                typeof(EncodingFormat),
                new PropertyMetadata(CodeType.QRCode, OnCurrentCodeTypePropertyChanged));

        private static void OnCurrentCodeTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EncodingFormat encodingFormat = d as EncodingFormat;
            if (encodingFormat.CurrentCodeType == CodeType.QRCode && encodingFormat.CurrentCategory == Format.Url)
            {
                encodingFormat.ShowStatus = Visibility.Visible;
            }
            else
            {
                encodingFormat.ShowStatus = Visibility.Collapsed;
            }
        }

        public Format CurrentCategory
        {
            get { return (Format)GetValue(CurrentCategoryProperty); }
            set
            {
                SetValue(CurrentCategoryProperty, value);
            }
        }


        public static readonly DependencyProperty CurrentCategoryProperty =
            DependencyProperty.Register(
                "CurrentCategory",
                typeof(Format),
                typeof(EncodingFormat),
                new PropertyMetadata(Format.Url, OnCurrentCategoryPropertyChanged));

        private static void OnCurrentCategoryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EncodingFormat category = d as EncodingFormat;

            if (category.CurrentCodeType == CodeType.QRCode && category.CurrentCategory == Format.Url)
            {
                category.ShowStatus = Visibility.Visible;
            }
            else
            {
                category.ShowStatus = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
