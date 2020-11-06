using C1.Xaml.Chart.Annotation;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StockAnalysis.EditableAnnotitions
{
    public sealed partial class AnnotationEditor : TextEditor
    {
        public AnnotationEditor()
        {
            this.InitializeComponent();
        }
        public Data.AnnotationStyle EditingAnnotationStyle
        {
            get { return ViewModel.ViewModel.Instance.EditingAnnotationStyle; }           
        }
        
        public override void UpdateEditorContent()
        {
            txtAnnotationContent.Text = GetAnnotationContent();
            if (this.Annotation is Text)
            {
                annotationShapeSettings.Visibility = Visibility.Collapsed;
            }
            else
            {
                annotationShapeSettings.Visibility = Visibility.Visible;
            }
            if (this.Annotation is Line)
            {
                annotationShapeSettings.FillGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                annotationShapeSettings.FillGrid.Visibility = Visibility.Visible;
            }
        }
        private void btnOkCancel_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "Ok":
                    AcceptChanges(txtAnnotationContent.Text);
                   
                    (this.Parent as Popup).IsOpen = false;
                    break;
                case "Cancel":
                    RejectChanges();
                    (this.Parent as Popup).IsOpen = false;
                    break;
            }
        }
    }
}
