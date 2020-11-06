using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace StockAnalysis.Partial.UserControls
{
    public sealed partial class AnnotationSettings : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AnnotationSettings()
        {
            this.InitializeComponent();
            this.Loaded += (o, e) =>
            {
                this.annotationTextSettings.DataContext = Model.AnnotationStyle;
            };
            ViewModel.ViewModel.Instance.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "NewAnnotationType")
                {
                    if (ViewModel.ViewModel.Instance.NewAnnotationType == Data.NewAnnotationType.None)
                    {
                        this.fillComboBox.Visibility = Visibility.Collapsed;
                        this.strokeComboBox.Visibility = Visibility.Collapsed;
                        this.fontDropdownControl.Visibility = Visibility.Collapsed;
                    }
                    else if (ViewModel.ViewModel.Instance.NewAnnotationType == Data.NewAnnotationType.Line)
                    {
                        this.fillComboBox.Visibility = Visibility.Collapsed;
                        this.strokeComboBox.Visibility = Visibility.Visible;
                        this.strokeComboBorder.Visibility = Visibility.Visible;
                        this.fontDropdownControl.Visibility = Visibility.Visible;
                    }
                    else if (ViewModel.ViewModel.Instance.NewAnnotationType == Data.NewAnnotationType.Text)
                    {
                        this.fillComboBox.Visibility = Visibility.Collapsed;
                        this.strokeComboBox.Visibility = Visibility.Collapsed;
                        this.fontDropdownControl.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.fillComboBox.Visibility = Visibility.Visible;
                        this.fillComboBorder.Visibility = Visibility.Visible;
                        this.strokeComboBox.Visibility = Visibility.Visible;
                        this.strokeComboBorder.Visibility = Visibility.Visible;
                        this.fontDropdownControl.Visibility = Visibility.Visible;
                    }
                }
            };
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ViewModel.ViewModel Model
        {
            get { return ViewModel.ViewModel.Instance; }
        }

        private void Stroke_SelectedColorChanged(object sender, C1.Xaml.PropertyChangedEventArgs<Windows.UI.Color> e)
        {
            this.Model.AnnotationStyle.Stroke = e.NewValue;
        }

        private void Fill_SelectedColorChanged(object sender, C1.Xaml.PropertyChangedEventArgs<Windows.UI.Color> e)
        {
            this.Model.AnnotationStyle.Fill = e.NewValue;
        }
    }
}
