using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Windows.Storage;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TileViewSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage : Page
    {
        public BlankPage()
        {
            this.InitializeComponent();
            Loaded += BlankPage_Loaded;
        }

        private async void BlankPage_Loaded(object sender, RoutedEventArgs e)
        {
            var data = await CelebrityStorage.Load();
            c1tileView1.ItemsSource = data;
        }
    }

    public class Celebrity
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class CelebrityStorage
    {
        public static async Task<List<Celebrity>> Load()
        {
            try
            {
                Uri resourceUri;
                if (typeof(CelebrityStorage).GetTypeInfo().Module.Name.EndsWith("exe") ||
                    Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    resourceUri = new Uri("ms-appx:///Resources/Celebrity.xml");
                }
                else
                {
                    resourceUri = new Uri("ms-appx:///TileViewSamplesLib/Resources/Celebrity.xml");
                }
                var file = await StorageFile.GetFileFromApplicationUriAsync(resourceUri);
                var fileStream = await file.OpenAsync(FileAccessMode.Read);
                var xmls = new XmlSerializer(typeof(List<Celebrity>));
                return (List<Celebrity>)xmls.Deserialize(fileStream.AsStream());
            }
            catch
            {
                throw new NotSupportedException();
            }
        }
    }
}
