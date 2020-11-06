using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Serialization;
using Windows.Storage;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlexGrid101
{
    public class Song
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Album")]
        public string Album { get; set; }

        [Display(Name = "Artist")]
        public string Artist { get; set; }

        [Display(Name = "Duration")]
        public long Duration { get; set; }  // in milliseconds

        [Display(Name = "Size")]
        public long Size { get; set; }      // in bytes

        [Display(Name = "Rating")]
        public int Rating { get; set; }     // from 0 to 5
    }

    public class MediaLibraryStorage
    {
        public static async Task<List<Song>> Load()
        {
            try
            {
                Uri resourceUri;
                if (typeof(MediaLibraryStorage).GetTypeInfo().Module.Name.EndsWith("exe") || 
                    Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    resourceUri = new Uri("ms-appx:///Resources/songs.xml");
                }
                else
                {
                    resourceUri = new Uri("ms-appx:///FlexGrid101Lib/Resources/songs.xml");
                }
                var file = await StorageFile.GetFileFromApplicationUriAsync(resourceUri);
                var fileStream = await file.OpenAsync(FileAccessMode.Read);
                var xmls = new XmlSerializer(typeof(List<Song>));
                return (List<Song>)xmls.Deserialize(fileStream.AsStream());
            }
            catch
            {
                throw new Exception(Strings.FileNotFoundException);
            }
        }
    }
}
