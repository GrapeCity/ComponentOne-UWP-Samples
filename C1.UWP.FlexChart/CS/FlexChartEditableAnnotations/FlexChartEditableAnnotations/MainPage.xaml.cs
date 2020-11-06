using C1.Chart.Annotation;
using C1.Xaml;
using C1.Xaml.Chart;
using C1.Xaml.Chart.Annotation;
using C1.Xaml.Chart.Interaction;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Reflection;
using Windows.UI.Xaml.Documents;
using System.Globalization;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlexChartEditableAnnotations
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private EditableAnnotationLayer al;
        private List<CustomButton> _lsAttachmentGroup, _lsAnnotationGroup;
        private C1AxisScrollbar _scrollbar;
        private C1ContextMenu _flexChartContextMenu;
        public MainPage()
        {
            this.InitializeComponent();
            Init();
        }

        private void Init()
        {
            _lsAttachmentGroup = new List<CustomButton>{
                cbAbsolute,cbDataCoordinate,cbRelative
            };

            _lsAnnotationGroup = new List<CustomButton>{
                cbText,cbCircle,cbEllipse,cbRectangle,cbSquare,cbLine,cbPolygon
            };

            tbTitle.Text = Localizer.GetItem("introduction", "title");

            ToolTipService.SetToolTip(cbAbsolute, Localizer.GetItem("Absolute", "description"));
            ToolTipService.SetPlacement(cbAbsolute, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbRelative, Localizer.GetItem("Relative", "description"));
            ToolTipService.SetPlacement(cbRelative, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbDataCoordinate, Localizer.GetItem("DataCoordinate", "description"));
            ToolTipService.SetPlacement(cbDataCoordinate, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbAllowMove, Localizer.GetItem("allowMove", "description"));
            ToolTipService.SetPlacement(cbAllowMove, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbText, Localizer.GetItem("textAnno", "description"));
            ToolTipService.SetPlacement(cbText, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbLine, Localizer.GetItem("lineAnno", "description"));
            ToolTipService.SetPlacement(cbLine, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbCircle, Localizer.GetItem("circleAnno", "description"));
            ToolTipService.SetPlacement(cbCircle, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbEllipse, Localizer.GetItem("ellipseAnno", "description"));
            ToolTipService.SetPlacement(cbEllipse, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbRectangle, Localizer.GetItem("rectAnno", "description"));
            ToolTipService.SetPlacement(cbRectangle, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbSquare, Localizer.GetItem("squareAnno", "description"));
            ToolTipService.SetPlacement(cbSquare, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);
            ToolTipService.SetToolTip(cbPolygon, Localizer.GetItem("polygonAnno", "description"));
            ToolTipService.SetPlacement(cbPolygon, Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom);

            cbAbsolute.Tag = AnnotationAttachment.Absolute;
            cbRelative.Tag = AnnotationAttachment.Relative;
            cbDataCoordinate.Tag = AnnotationAttachment.DataCoordinate;
            cbAllowMove.Tag = "AllowMove";
            cbText.Tag = "Text";
            cbLine.Tag = "Line";
            cbCircle.Tag = "Circle";
            cbEllipse.Tag = "Ellipse";
            cbRectangle.Tag = "Rectangle";
            cbSquare.Tag = "Square";
            cbPolygon.Tag = "Polygon";

            txtDescription.Text = Localizer.GetItem("introduction", "description");

            InitChart();

            _flexChartContextMenu = new C1ContextMenu() { Background = new SolidColorBrush(Colors.DarkGray) };
            C1MenuItem item = new C1MenuItem();
            Windows.UI.Xaml.Controls.Image img = new Windows.UI.Xaml.Controls.Image();
            string url = "ms-appx:///Resources/cross.png";
            img.Source = new BitmapImage() { UriSource = new Uri(url) };  //RandomAccessStreamReference.CreateFromUri(new Uri(url));

            item.Icon = new BitmapIcon() { UriSource = new Uri(url) };
            item.HeaderBackground = new SolidColorBrush(Colors.DarkGray);
            item.Header = "Delete";
            _flexChartContextMenu.Items.Add(item);

            _flexChartContextMenu.ItemClick += _flexChartContextMenu_ItemClick;

            cbAbsolute.Checked = true;
            cbAllowMove.Checked = true;
        }

        private void _flexChartContextMenu_ItemClick(object sender, SourcedEventArgs e)
        {
            al.Annotations.Remove(al.SelectedAnnotation);
        }

        private void InitChart()
        {
            var ls = new List<Point>();
            Random r = new Random();

            for (int i = 0; i < 100; i++)
            {
                ls.Add(new Point(i, r.Next(0, 1000)));
            }

            flexChart1.ItemsSource = ls;
            flexChart1.ChartType = C1.Chart.ChartType.Scatter;
            flexChart1.ToolTip.Visibility = Visibility.Collapsed;
            flexChart1.Series.Clear();
            flexChart1.Series.Add(new C1.Xaml.Chart.Series
            {
                Binding = "Y",
                BindingX = "X"
            });

            #region Annotations Setup

            al = new EditableAnnotationLayer(flexChart1);

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Text
            {
                Attachment = AnnotationAttachment.Relative,
                Content = "Text Annotation",
                Location = new Point(0.55, 0.15),
                Style = new ChartStyle() { FontSize = 12, Stroke = new SolidColorBrush(Colors.Black) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Rectangle
            {
                Attachment = AnnotationAttachment.Absolute,
                Content = "Absolute",
                Location = new Point(100, 150),
                Width = 100,
                Height = 50,
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Ellipse
            {
                Attachment = AnnotationAttachment.Relative,
                Location = new Point(0.5f, 0.35f),
                Content = "Relative",
                Width = 100,
                Height = 50,
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Square
            {
                Attachment = AnnotationAttachment.DataCoordinate,
                Content = "DataCoordinate",
                Length = 120,
                Location = new Point(20, 200),
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Polygon("Polygon")
            {
                Attachment = AnnotationAttachment.Absolute,
                Points =
                {
                    new Point(300, 25),
                    new Point(250, 70),
                    new Point(275, 115),
                    new Point(325, 115),
                    new Point(350, 70)
                },
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Line
            {
                Attachment = AnnotationAttachment.Relative,
                Content = "Horizontal Line",
                Start = new Point(0, 0.5f),
                End = new Point(1.2f, 0.5f),
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Line
            {
                Attachment = AnnotationAttachment.Relative,
                Content = "Vertical Line",
                Start = new Point(0.7f, 0),
                End = new Point(0.7f, 1.2f),
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.Annotations.Add(new C1.Xaml.Chart.Annotation.Line
            {
                Attachment = AnnotationAttachment.Absolute,
                Content = "Slanted Line",
                Start = new Point(100, 70),
                End = new Point(200, 170),
                Style = new ChartStyle() { Fill = new SolidColorBrush(Colors.Red) }
            });

            al.PolygonAddFunc = (pt) =>
            {
                return new C1.Xaml.Chart.Annotation.Polygon(string.Empty)
                {
                    Points =
                    {
                        pt,pt,pt
                    }
                };
            };

            flexChart1.Layers.Add(al);

            al.PolygonReSizeFunc = (poly, rectangle) =>
            {
                var top = new Point((float)(rectangle.Left + rectangle.Width / 2), rectangle.Y);
                var left = new Point(rectangle.Left, rectangle.Bottom);
                var right = new Point(rectangle.Right, rectangle.Bottom);
                poly.Points[0] = Helpers.CoordsToAnnoPoint(flexChart1, poly, top);
                poly.Points[1] = Helpers.CoordsToAnnoPoint(flexChart1, poly, left);
                poly.Points[2] = Helpers.CoordsToAnnoPoint(flexChart1, poly, right);
            };

            al.ContentEditor = new AnnotationEditor();
            #endregion

            flexChart1.Rendered += FlexChart1_Rendered;
            flexChart1.PointerPressed += FlexChart1_PointerPressed;

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;            
        }       

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Delete && al.SelectedAnnotation != null)
            {
                al.Annotations.Remove(al.SelectedAnnotation);
            }
        }

        private void FlexChart1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                flexChart1.Focus(FocusState.Pointer);
                _flexChartContextMenu.Hide();
                var p = e.GetCurrentPoint((UIElement)sender);
                if (p.Properties.IsRightButtonPressed)
                {
                    if (al.HitTest(e.GetCurrentPoint(flexChart1).Position) != null)
                    {
                        al.SelectedAnnotation = al.HitTest(e.GetCurrentPoint(flexChart1).Position);
                        _flexChartContextMenu.Show(flexChart1, p.Position);
                    }
                }
            }
        }
        private void FlexChart1_Rendered(object sender, RenderEventArgs e)
        {
            SetupAxisScrollbar();
        }

        private void SetupAxisScrollbar()
        {
            if (flexChart1.AxisX.Scrollbar != null)
                return;
            flexChart1.AxisX.Scrollbar = new C1AxisScrollbar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedItem = sender as CustomButton;

            //Handle Annotation Attachments
            if (_lsAttachmentGroup.Contains(clickedItem))
            {
                foreach (var item in _lsAttachmentGroup)
                    item.Checked = item == clickedItem ? !item.Checked : false;
                al.Attachment = (AnnotationAttachment)clickedItem.Tag;

            }

            //Handle adding new Annotations 
            else if (_lsAnnotationGroup.Contains(clickedItem))
            {
                foreach (var item in _lsAnnotationGroup)
                    item.Checked = item == clickedItem ? !item.Checked : false;
                var annoToAdd = (string)clickedItem.Tag;
                var asm = typeof(AnnotationBase).GetTypeInfo().Assembly;
                al.NewAnnotationType = asm.GetType(string.Format("C1.Xaml.Chart.Annotation.{0}", annoToAdd));
                al.AllowAdd = clickedItem.Checked;
            }
            //Allow Moving Annotations at runtime
            else if ((string)clickedItem.Tag == "AllowMove")
            {
                clickedItem.Checked = !clickedItem.Checked;
                al.AllowMove = clickedItem.Checked;
            }
        }
    }
}
