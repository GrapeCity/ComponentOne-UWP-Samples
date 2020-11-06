using C1.Xaml;
using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace GridTreeViewSamples
{
    public partial class GridTreeViewSample : Page
    {
        Person _person;
        Random _rnd = new Random();
        private ObservableCollection<Person> Persons = new ObservableCollection<Person>();

        public GridTreeViewSample()
        {
            this.InitializeComponent();
            // number of children for each person (4 levels)
            // item count is 1 + count + count^2 + count^3 + count^4
            // (e.g. count = 10 => ~10,000 people)
            this.Loaded += GridTreeViewSample_Loaded;
            
        }

        private void GridTreeViewSample_Loaded(object sender, RoutedEventArgs e)
        {
            _person = GetData();

            #region Populating
            // put person in a list so we can bind to it
            var list = new ObservableCollection<Person>();
            list.Add(_person);

            // show items in bound controls
            using (new Benchmark(Strings.BoundC1TreeView, _txtTree))
            {
                _tree.ItemsSource = list;
            }

            using (new Benchmark(Strings.BoundC1FlexGrid, _txtFlex))
            {
                _flex.ItemsSource = list;
            }

            // show items in unbound controls
            using (new Benchmark(Strings.UnBoundC1TreeView, _txtTreeUnbound))
            {
                ShowPersonOnTree(_person, _treeUnbound);
            }

            using (new Benchmark(Strings.UnBoundC1FlexGrid, _txtFlexUnbound))
            {
                ShowPersonOnGrid(_person, _flexUnbound);
            }
            #endregion

            // try doing this with a TreeView ;-)
            _flex.CollapseGroupsToLevel(5);
            _flexUnbound.CollapseGroupsToLevel(5);

            // hide row headers
            _flex.HeadersVisibility = HeadersVisibility.Column;
            _flexUnbound.HeadersVisibility = HeadersVisibility.Column;
        }

        private Person GetData()
        {
            int count = 4;
            // build person tree
            Person _person = new Person();

            #region CreatingPersons
            using (new Benchmark(Strings.BuildingPersonTree, _txtPerson))
            {
                for (int i = 0; i < count; i++)
                {
                    var pi = new Person();
                    _person.Children.Add(pi);

                    for (int j = 0; j < count; j++)
                    {
                        var pj = new Person();
                        pi.Children.Add(pj);

                        for (int k = 0; k < count; k++)
                        {
                            var pk = new Person();
                            pj.Children.Add(pk);

                            for (int l = 0; l < count; l++)
                            {
                                var pl = new Person();
                                pk.Children.Add(pl);
                            }
                        }
                    }
                }
            }
            return _person;
            #endregion
        }

        #region ** populate unbound TreeView
        void ShowPersonOnTree(Person p, C1TreeView t)
        {
            t.Items.Clear();
            AddPersonToTree(p, t.Items);
        }
        void AddPersonToTree(Person p, ItemCollection items)
        {
            // create an item for this person
            var item = new C1TreeViewItem();
            item.Tag = p;
            item.Header = p.Name;

            // add this person to the tree
            items.Add(item);

            // and add any children
            foreach (var child in p.Children)
            {
                AddPersonToTree(child, item.Items);
            }
        }
        #endregion

        #region ** populate unbound FlexGrid

        // populate unbound FlexGrid
        void ShowPersonOnGrid(Person p, C1FlexGrid flex)
        {
            // initialize grid
            flex.Rows.Clear();
            flex.Columns.Clear();

            var c = new Column();
            c.Header = "Name";
            var binding = new Binding { Path = new PropertyPath("Name") };
            c.Binding = binding;

            c.Width = new GridLength(1, GridUnitType.Star);
            flex.Columns.Add(c);

            c = new Column();
            c.Header = "Children";
            var binding2 = new Binding { Path = new PropertyPath("Children.Count") };
            c.Binding = binding2;

            flex.Columns.Add(c);

            using (flex.Rows.DeferNotifications())
            {
                AddPersonToGrid(p, flex, 0);
            }
        }
        void AddPersonToGrid(Person p, C1FlexGrid flex, int level)
        {
            // create a row for this person
            Row row;
            if (p.Children.Count > 0 || true)
            {
                var gr = new GroupRow();
                gr.Level = level;
                row = gr;
            }
            else
            {
                row = new Row();
            }
            row.DataItem = p;

            // add this person to the grid
            flex.Rows.Add(row);

            // and add any children
            foreach (var child in p.Children)
            {
                AddPersonToGrid(child, flex, level + 1);
            }
        }
        #endregion

        #region EventHandlers

        private void _btnAddRoot_Click(object sender, RoutedEventArgs e)
        {
            var list = (_flex.CollectionView as C1CollectionView).SourceCollection as ObservableCollection<Person>;
            var root = new Person();
            list.Insert(0, root);
        }

        private void _btnAddChild_Click(object sender, RoutedEventArgs e)
        {
            var p = GetSelectedPerson();
            p.Children.Insert(0, new Person());
            (_flex.CollectionView as C1CollectionView).Refresh();

        }

        private void _btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var p = GetSelectedPerson();
            var parent = p.Parent;
            if (parent != null)
            {
                parent.Children.Remove(p);
            }
            (_flex.CollectionView as C1CollectionView).Refresh();
        }

        private void _btnChange_Click(object sender, RoutedEventArgs e)
        {
            var p = GetSelectedPerson();
            p.Name = _rnd.Next(0, 1000).ToString();
        }
        #endregion

        Person GetSelectedPerson()
        {
            var p = _flex.SelectedItem as Person;
            return p != null ? p : _person;
        }
    }
}