using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BarCodeSamples
{
    public sealed partial class Editor : Page
    {
        public Editor()
        {
            this.InitializeComponent();
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
                typeof(Editor),
                new PropertyMetadata(Format.Url, OnCurrentCategoryPropertyChanged));

        private static void OnCurrentCategoryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var editor = d as Editor;
            if (e.NewValue != null)
            {
                Format newValue = (Format)e.NewValue;
                editor.CurrentEditorControl.Children.Clear();
                UserControl control = null;
                switch (newValue)
                {
                    case Format.Url:
                        control = new Url();
                        editor.DataContext = new UrlEntity() { Url = Strings.UrlInitialValue };
                        break;
                    case Format.Text:
                        control = new Text();
                        editor.DataContext = new TextEntity() { Text = Strings.TextInitialValue };
                        break;
                    case Format.Email:
                        control = new Email();
                        editor.DataContext = new EmailEntity() { Address = Strings.EmailAddressInitialValue };
                        break;
                    case Format.VCard:
                        control = new VCard();
                        editor.DataContext = new VCardEntity()
                        {
                            Prefix = Strings.VCardPrefixInitialValue,
                            FirstName = Strings.VCardFirstNameInitialValue,
                            LastName = Strings.VCardLastNameInitialValue,
                            HomeCountry = Strings.VCardHomeCountryInitialValue,
                            Suffix = Strings.VCardSuffixInitialValue,
                            FullName = Strings.VCardFullNameSuffixInitialValue,
                            Title = Strings.VCardTitleInitialValue,
                            Role = Strings.VCardRoleInitialValue
                        };
                        break;
                }
                if (control != null)
                {
                    editor.CurrentEditorControl.Children.Add(control);
                }
            }
        }

        //this is for Phone
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var format = (Format)e.Parameter;
            string formatvalue = format.ToString();
            switch (format)
            {
                case Format.Email:
                    frame.Navigate(typeof(Email), new EmailEntity()
                    {
                        Address = Strings.EmailAddressInitialValue
                    });
                    break;
                case Format.Text:
                    frame.Navigate(typeof(Text), new TextEntity()
                    {
                        Text = Strings.TextInitialValue
                    });
                    break;
                case Format.Url:
                    frame.Navigate(typeof(Url), new UrlEntity()
                    {
                        Url = Strings.UrlInitialValue
                    });
                    break;
                case Format.VCard:
                    frame.Navigate(typeof(VCard), new VCardEntity()
                    {
                        Prefix = Strings.VCardPrefixInitialValue,
                        FirstName = Strings.VCardFirstNameInitialValue,
                        LastName = Strings.VCardLastNameInitialValue,
                        HomeCountry = Strings.VCardHomeCountryInitialValue,
                        Suffix = Strings.VCardSuffixInitialValue,
                        FullName = Strings.VCardFullNameSuffixInitialValue,
                        Title = Strings.VCardTitleInitialValue,
                        Role = Strings.VCardRoleInitialValue,
                        Nickname = Strings.VCardNicknameInitialValue
                    });
                    break;
            }
        }

        private void GenerateBarCode(object sender, RoutedEventArgs e)
        {
            string text = string.Empty;
            var editor = this.frame.Content as UserControl;
            if (editor != null)
            {
                var entity = editor.DataContext as Entity;
                if (entity != null)
                {
                    text = entity.EncodingText;
                }
            }
            Frame.Navigate(typeof(PhoneBarCodePage), text);
        }
    }
}
