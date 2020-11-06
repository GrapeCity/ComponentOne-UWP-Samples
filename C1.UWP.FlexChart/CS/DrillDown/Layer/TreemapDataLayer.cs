using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DrillDown
{
    public class TreemapDataLayer : Bindable
    {
        private Leaf[] _itemsSource;
        private int _depth = 0;
        
        private ObservableCollection<KeyValuePair<string, Leaf[]>> _histories = new ObservableCollection<KeyValuePair<string, Leaf[]>>();

        public TreemapDataLayer(Leaf[] dataSource)
        {
            ItemsSource = dataSource;
            _histories.CollectionChanged += _histories_CollectionChanged;
            _histories.Add(new KeyValuePair<string, Leaf[]> ( "All Types", dataSource ));
            BackCommand = new RelayCommand(p => Back(p));
        }

        private void _histories_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Notify("CurrentType");
        }

        public Leaf[] ItemsSource
        {
            get { return _itemsSource; }
            set
            {
                SetProperty(ref _itemsSource, value, "ItemsSource");
            }
        }

        public int Depth
        {
            get { return _depth; }
            set
            {
                SetProperty(ref _depth, value, "Depth");
            }
        }

        public ObservableCollection<KeyValuePair<string, Leaf[]>> Histories
        {
            get { return _histories; }
            set
            {
                SetProperty(ref _histories, value, "Histories");
            }
        }

        public string CurrentType
        {
            get { return Histories.Last().Key; }
        }

        public RelayCommand BackCommand
        {
            get; set;
        }

        public virtual void Back(object obj)
        {
            var idx = int.Parse(obj.ToString());
            for (int i = _histories.Count() - 1; i>idx; i--)
            {
                Histories.RemoveAt(i);
            }
            Depth = idx;
            ItemsSource = _histories.Last().Value;
        }

        public void DrillDown(object item)
        {
            var dataItem = item as Leaf;
            if(dataItem != null && dataItem.Items != null && dataItem.Items.Count() > 0)
            {
                Histories.Add(new KeyValuePair<string, Leaf[]>(dataItem.Type, dataItem.Items));
                ItemsSource = dataItem.Items;
                Depth++;
            }
        }
    }
}
