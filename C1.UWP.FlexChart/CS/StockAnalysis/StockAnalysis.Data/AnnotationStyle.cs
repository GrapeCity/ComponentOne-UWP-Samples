using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Media;

namespace StockAnalysis.Data
{
    public class AnnotationStyle : INotifyPropertyChanged
    {

        private Color stroke = Color.FromArgb(255, 138, 195, 75);
        public Color Stroke
        {
            get
            {
                return stroke;
            }
            set
            {
                if (stroke != value)
                {
                    stroke = value;
                    OnPropertyChanged("Stroke");
                }
            }
        }

        private Color fill = Color.FromArgb(160, 138, 195, 75);
        public Color Fill
        {
            get
            {
                return fill;
            }
            set
            {
                if (fill != value)
                {
                    fill = value;
                    OnPropertyChanged("Fill");
                }
            }
        }

        private Color foreground = Color.FromArgb(255, 0, 112, 192);
        public Color Foreground
        {
            get
            {
                return foreground;
            }
            set
            {
                if (foreground != value)
                {
                    foreground = value;
                    OnPropertyChanged("Foreground");
                }
            }
        }


        private string fontFamily = "Arial";
        public string FontFamily
        {
            get
            {
                return fontFamily;
            }
            set
            {              
                if (fontFamily != value)
                {
                    fontFamily = value;
                    OnPropertyChanged("FontFamily");
                }
            }
        }

        private FontWeight fontWeight = new FontWeight();
        public FontWeight FontWeight
        {
            get
            {
                return fontWeight;
            }
            set
            {
                if (!fontWeight.Equals(value))
                {
                    fontWeight = value;
                    OnPropertyChanged("FontWeight");
                }
            }
        }
       
        private double fontSize = 10;
        public double FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                if (fontSize != value)
                {
                    fontSize = value;
                    OnPropertyChanged("FontSize");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
