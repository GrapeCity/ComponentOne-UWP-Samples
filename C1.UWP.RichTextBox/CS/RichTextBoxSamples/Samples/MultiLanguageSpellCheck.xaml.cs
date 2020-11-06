using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using C1.Xaml.SpellChecker;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using C1.C1Zip;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO.Compression;

namespace RichTextBoxSamples
{
    public sealed partial class MultiLanguageSpellCheck : Page
    {
        C1SpellChecker _c1SpellChecker = new C1SpellChecker();

        public MultiLanguageSpellCheck()
        {
            this.InitializeComponent();

            rtb.Text = Strings.SpellCheck;

            Loaded += new RoutedEventHandler(MultiLanguageSpellCheck_Loaded);
            
        }

        void MultiLanguageSpellCheck_Loaded(object sender, RoutedEventArgs e)
        {
            cmbLanguage.SelectionChanged += new SelectionChangedEventHandler(cmbLanguage_SelectionChanged);
            cmbLanguage.ItemTemplate = (DataTemplate)Resources["DictionaryTemplate"];
            cmbLanguage.ItemsSource = SpellDictionaryWrapper.GetLanguages();
            cmbLanguage.SelectedIndex = 0;
        }

        void cmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDictionaryFromServer();
        }

        private async void GetDictionaryFromServer()
        {
            var dctWrapper = (SpellDictionaryWrapper)cmbLanguage.SelectedItem;

            if (dctWrapper == null)
                return;

            // load the dictionary from the server
            HttpClient client = new HttpClient();
            try
            {
                loading.Visibility = Visibility.Visible;
                rtb.IsEnabled = false;

                //Get the dictionary as stream from server.
                var serverRoot = "http://demos.componentone.com/dictionaries/";
                var stream = await client.GetStreamAsync(new Uri(serverRoot + dctWrapper.Address, UriKind.Absolute));

                MemoryStream outputStream = new MemoryStream();
                await stream.CopyToAsync(outputStream);

                rtb.SpellChecker = _c1SpellChecker;
                await _c1SpellChecker.MainDictionary.LoadAsync(outputStream);

                loading.Visibility = Visibility.Collapsed;
                rtb.IsEnabled = true;
            }
            catch (Exception e)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(e.Message);
                dialog.ShowAsync();
                loading.Visibility = Visibility.Collapsed;
                rtb.IsEnabled = true;
            }
        }

        #region SpellDictionaryWrapper

        public class SpellDictionaryWrapper
        {
            public static List<SpellDictionaryWrapper> GetLanguages()
            {
                var list = new List<SpellDictionaryWrapper>();
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_da-DK.dct", Name = Strings.Denmark, FlagUri = "../Assets/Flags/Denmark.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_de-CH.dct", Name = Strings.Switzerland, FlagUri = "../Assets/Flags/Switzerland.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_de-DE.dct", Name = Strings.Germany, FlagUri = "../Assets/Flags/Germany.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_el-GR.dct", Name = Strings.Greece, FlagUri = "../Assets/Flags/Greece.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_en-CA.dct", Name = Strings.Canada, FlagUri = "../Assets/Flags/Canada.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_en-GB.dct", Name = Strings.UK, FlagUri = "../Assets/Flags/United_Kingdom.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_en-US.dct", Name = Strings.US, FlagUri = "../Assets/Flags/United_States.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_es-AR.dct", Name = Strings.Argentina, FlagUri = "../Assets/Flags/Argentina.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_es-ES.dct", Name = Strings.Spain, FlagUri = "../Assets/Flags/Spain.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_es-MX.dct", Name = Strings.Mexico, FlagUri = "../Assets/Flags/Mexico.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_fr-CA.dct", Name = Strings.CanadaFrench, FlagUri = "../Assets/Flags/Canada.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_fr-FR.dct", Name = Strings.France, FlagUri = "../Assets/Flags/France.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_it-IT.dct", Name = Strings.Italy, FlagUri = "../Assets/Flags/Italy.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_nb-NO.dct", Name = Strings.Bokmal, FlagUri = "../Assets/Flags/Norway.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_nl-NL.dct", Name = Strings.Netherlands, FlagUri = "../Assets/Flags/Netherlands.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_pt-BR.dct", Name = Strings.Brazil, FlagUri = "../Assets/Flags/Brazil.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_pt-PT.dct", Name = Strings.Portugal, FlagUri = "../Assets/Flags/Portugal.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_ru-RU.dct", Name = Strings.Russia, FlagUri = "../Assets/Flags/Russia.png" });
                list.Add(new SpellDictionaryWrapper() { Address = "C1Spell_sv-SE.dct", Name = Strings.Sweden, FlagUri = "../Assets/Flags/Sweden.png" });
                return list;
            }

            public string Address { get; set; }
            public string Name { get; set; }
            public string FlagUri { get; set; }
        }

        #endregion
    }
}
