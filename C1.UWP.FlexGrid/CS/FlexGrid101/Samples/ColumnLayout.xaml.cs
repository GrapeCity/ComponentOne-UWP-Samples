using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexGrid101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ColumnLayout : Page
    {
        private string FILENAME = "ColumnLayout.json";
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public ColumnLayout()
        {
            InitializeComponent();

            InitializeColumnLayout();
        }

        private async void OnEditColumnLayout(object sender, RoutedEventArgs e)
        {
            await new ColumnLayoutForm(this.grid).ShowAsync();
        }

        private async void OnSerializeColumnLayout(object sender, RoutedEventArgs e)
        {
            var serializedColumns = SerializeLayout(grid);

            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(FILENAME, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, serializedColumns);
        }

        private async void InitializeColumnLayout()
        {
            string data = null;
            try
            {
                Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync(FILENAME);
                if (sampleFile.IsAvailable)
                {
                    data = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                }
            }
            catch
            { }

            var items = Customer.GetCustomerList(100);
            grid.ItemsSource = items;
            grid.MinColumnWidth = 85;

            if (!string.IsNullOrWhiteSpace(data))
                DeserializeLayout(grid, data);
        }

        private string SerializeLayout(C1FlexGrid grid)
        {
            var columns = new List<ColumnInfo>();
            foreach (var col in grid.Columns)
            {
                var colInfo = new ColumnInfo { Name = col.ColumnName, IsVisible = col.IsVisible };
                columns.Add(colInfo);
            }
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, columns.ToArray());
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var serializedColumns = new StreamReader(stream).ReadToEnd();
            return serializedColumns;
        }

        private void DeserializeLayout(C1FlexGrid grid, string layout)
        {
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(layout));
            var columns = serializer.ReadObject(stream) as ColumnInfo[];
            for (int i = 0; i < columns.Length; i++)
            {
                var colInfo = columns[i];
                var column = grid.Columns[colInfo.Name];
                var colIndex = grid.Columns.IndexOf(column);
                column.Visible = colInfo.IsVisible;
                if (colIndex != i)
                {
                    grid.Columns.Move(colIndex, i);
                }
            }
        }
    }

    [DataContract]
    public class ColumnInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "isVisible")]
        public bool IsVisible { get; set; }
    }
}
