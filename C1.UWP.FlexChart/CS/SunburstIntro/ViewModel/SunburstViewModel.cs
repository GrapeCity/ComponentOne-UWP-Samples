using C1.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace SunburstIntro
{
    public class SunburstViewModel : INotifyPropertyChanged
    {
        private string _legendPosition = "Auto";
        private string _selectedItemPosition = "Top";

        public List<DataItem> HierarchicalData
        {
            get
            {
                return DataService.CreateHierarchicalData();
            }
        }

        public List<FlatDataItem> FlatData
        {
            get
            {
                return DataService.CreateFlatData();
            }
        }

        public ICollectionView View
        {
            get
            {
                return DataService.CreateGroupCVData();
            }
        }

        public List<string> Positions
        {
            get
            {
                return Enum.GetNames(typeof(Position)).ToList();
            }
        }

        public List<string> Palettes
        {
            get
            {
                return Enum.GetNames(typeof(Palette)).ToList();
            }
        }

        public List<string> LabelPositions
        {
            get
            {
                return Enum.GetNames(typeof(PieLabelPosition)).ToList();
            }
        }

        public List<string> LabelOverlappings
        {
            get
            {
                return Enum.GetNames(typeof(PieLabelOverlapping)).ToList();
            }
        }

        public string LegendPosition
        {
            get { return _legendPosition; }
            set
            {
                if (_legendPosition != value)
                {
                    _legendPosition = value;
                    OnPropertyChanged("LegendPosition");
                }
            }
        }

        public string SelectedItemPosition
        {
            get { return _selectedItemPosition; }
            set
            {
                if (_selectedItemPosition != value)
                {
                    _selectedItemPosition = value;
                    OnPropertyChanged("SelectedItemPosition");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
