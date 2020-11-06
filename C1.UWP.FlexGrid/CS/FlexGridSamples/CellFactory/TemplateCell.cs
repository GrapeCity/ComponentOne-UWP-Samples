using C1.Xaml.FlexGrid;
using System;
using System.Reflection;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace FlexGridSamples
{
    public abstract class TemplateCell : StackPanel
    {
        private static ResourceDictionary _customTemplatesDictionary;
        public static ResourceDictionary CustomTemplatesDictionary
        {
            get
            {
                if (_customTemplatesDictionary == null)
                {
                    _customTemplatesDictionary = new ResourceDictionary();
                    if (typeof(TemplateCell).GetTypeInfo().Module.Name.EndsWith("exe"))
                    {
                        _customTemplatesDictionary.Source = new Uri("ms-appx:///Resources/CustomTemplatesDictionary.xaml");
                    }
                    else
                    {
                        _customTemplatesDictionary.Source = new Uri("ms-appx:///FlexGridSamplesLib/Resources/CustomTemplatesDictionary.xaml");
                    }
                }
                return _customTemplatesDictionary;
            }
        }

        protected ContentControl Icon { get; set; }
        protected TextBlock TextBlock { get; set; }

        private Row Row { get; set; }

        public TemplateCell(Row row)
        {
            Row = row;
            Orientation = Orientation.Horizontal;

            Icon = new ContentControl();
            Icon.Width = 25;
            Icon.Height = 25;
            Icon.VerticalAlignment = VerticalAlignment.Center;
            Icon.Margin = new Thickness(4);
            Icon.ContentTemplate = GetIcon();
            Children.Add(Icon);

            TextBlock = new TextBlock();
            TextBlock.VerticalAlignment = VerticalAlignment.Center;
            Children.Add(TextBlock);
            BindCell(row.DataItem);
        }

        void BindCell(object dataItem)
        {
            var binding = new Binding { Path = new PropertyPath("Name") };
            binding.Source = dataItem;
            TextBlock.SetBinding(TextBlock.TextProperty, binding);
            TextBlock.Foreground = Row.Grid.Foreground;
        }
        public abstract DataTemplate GetIcon();

    }

    /// <summary>
    /// Represents a grid cell that is bound to a song name.
    /// </summary>
    public class SongCell : TemplateCell
    {
        public SongCell(Row row) : base(row) { }
        public override DataTemplate GetIcon()
        {
            return TemplateCell.CustomTemplatesDictionary["SongIcon"] as DataTemplate;
        }
    }

    /// <summary>
    /// Represents a grid cell that has a collapse/expand icon, an image, and some text.
    /// </summary>
    public abstract class NodeCell : TemplateCell
    {
        GroupRow _gr;
        private ToggleButton _nodeExpandButton;

        public NodeCell(Row row)
            : base(row)
        {
            // store reference to row
            _gr = row as GroupRow;
            // initialize collapsed/expanded image
            _nodeExpandButton = new ToggleButton();
            if (Util.IsWindowsPhoneDevice())
            {
                _nodeExpandButton.Template = TemplateCell.CustomTemplatesDictionary["ExpandCollapsePhoneTemplate"] as ControlTemplate;
            }
            else
            {
                _nodeExpandButton.Template = TemplateCell.CustomTemplatesDictionary["ExpandCollapseTemplate"] as ControlTemplate;
            }

            _nodeExpandButton.IsChecked = !_gr.IsCollapsed;
            _nodeExpandButton.Checked += OnExpandButtonToggled;
            _nodeExpandButton.Unchecked += OnExpandButtonToggled;
            Children.Insert(0, _nodeExpandButton);

            // make text bold
            TextBlock.FontWeight = FontWeights.Bold;
        }

        void OnExpandButtonToggled(object sender, RoutedEventArgs e)
        {
            var toggleButton = sender as ToggleButton;
            _gr.IsCollapsed = !toggleButton.IsChecked.Value;
        }
    }

    /// <summary>
    /// Represents a grid cell that is bound to an artist.
    /// </summary>
    public class ArtistCell : NodeCell
    {
        public ArtistCell(Row row)
            : base(row)
        {
        }
        public override DataTemplate GetIcon()
        {
            return TemplateCell.CustomTemplatesDictionary["ArtistIcon"] as DataTemplate;
        }
    }

    /// <summary>
    /// Represents a grid cell that is bound to an album.
    /// </summary>
    public class AlbumCell : NodeCell
    {
        public AlbumCell(Row row)
            : base(row)
        {
        }
        public override DataTemplate GetIcon()
        {
            return TemplateCell.CustomTemplatesDictionary["ArtistIcon"] as DataTemplate;
        }
    }

}
