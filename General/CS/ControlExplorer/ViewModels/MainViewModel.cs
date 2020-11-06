using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;

namespace ControlExplorer
{
    public class MainViewModel
    {
        #region ** fields

        private static MainViewModel _instance = null;

        #endregion

        #region ** object model

        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();
                return _instance;
            }
        }

        public IEnumerable<GroupDescription> Groups { get; private set; }

        public IEnumerable<ControlDescription> Controls { get; private set; }

        public IEnumerable<ControlDescription> NewControls { get; set; }

        public IEnumerable<ControlDescription> TopControls { get; set; }

        #endregion

        #region private stuff

        private async Task LoadGroups()
        {
            var doc = await LoadXmlResource("Resources/ControlList.xml");
            Groups = (from g in doc.Root.Elements("Group")
                      select new GroupDescription(g)).ToList();
            Controls = from g in Groups
                       from c in g.Controls
                       orderby c.Name ascending
                       select c;
            NewControls = from g in Groups
                          from c in g.Controls
                          orderby c.Name ascending
                          where c.IsNew
                          select c;
            TopControls = from g in Groups
                          from c in g.Controls
                          orderby c.Name ascending
                          where c.IsTop
                          select c;
        }

        private static async Task<XDocument> LoadXmlResource(string resourceName)
        {
            var uri = new Uri("ms-appx:///" + resourceName);
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
            return XDocument.Load(await file.OpenStreamForReadAsync());
        }

        #endregion

        public async Task Load()
        {
            await LoadGroups();
        }
    }
}
