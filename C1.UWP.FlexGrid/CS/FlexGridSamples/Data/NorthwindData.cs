using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Serialization;
using Windows.Storage;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlexGridSamples
{
    public class NorthwindData
    {
        [Display(Name = "CustomerID")]
        public string CustomerID { get; set; }

        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Display(Name = "ContactName")]
        public string ContactName { get; set; }

        [Display(Name = "ContactTitle")]
        public string ContactTitle { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }
    }

    public class NorthwindStorage
    {
        public static async Task<List<NorthwindData>> Load()
        {
            try
            {
                Uri resourceUri;
                if (typeof(NorthwindStorage).GetTypeInfo().Module.Name.EndsWith("exe") ||
                    Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    resourceUri = new Uri("ms-appx:///Resources/Northwind.xml");
                }
                else
                {
                    resourceUri = new Uri("ms-appx:///FlexGridSamplesLib/Resources/Northwind.xml");
                }
                var file = await StorageFile.GetFileFromApplicationUriAsync(resourceUri);
                var fileStream = await file.OpenAsync(FileAccessMode.Read);
                var xmls = new XmlSerializer(typeof(List<NorthwindData>));
                return (List<NorthwindData>)xmls.Deserialize(fileStream.AsStream());
            }
            catch(Exception e)
            {
                throw new Exception(Strings.FileNotFoundException);
            }
        }
    }
}
