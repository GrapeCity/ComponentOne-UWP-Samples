using C1.Xaml;
using C1.Xaml.ExpressionEditor;
using C1.Xaml.FlexGrid;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExpressionEditorSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SupportFilter : Page
    {
        C1ExpressionEditor _editor = new C1ExpressionEditor();
        public C1CollectionView View;

        public SupportFilter()
        {
            this.InitializeComponent();

            View = new C1CollectionView(Product.GetData());

            flexGrid.ItemsSource = View;

            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                InitalizeDesktop();
            }
            else
            {
                InitalizeMobile();
            }
            flexGrid.Loaded += FlexGrid_Loaded;
        }

        void InitalizeDesktop()
        {
            editor.DataSource = flexGrid.CollectionView.FirstOrDefault();
            editor.Expression = "[Price] > 1000";
            editor.ExpressionChanged += ExpressionEditor_ExpressionChanged;
        }

        void InitalizeMobile()
        {
            var expression = PageCache.GetCacheExpression();
            if (expression != "")
            {
                c1editor.Expression = expression;
            }
            else
            {
                c1editor.Expression = "[Price] > 1000";
            }
            c1editor.DataSource = flexGrid.CollectionView.FirstOrDefault();
        }

        private void FlexGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Column column in flexGrid.Columns)
            {
                // hide calculated columns
                if (column.ColumnName.Equals("CustomField1") || column.ColumnName.Equals("CustomField2"))
                    column.Visible = false;
            }

            var expression = PageCache.GetCacheExpression();
            if (expression != _editor.Expression)
            {
                PageCache.SetCacheExpression("");
                _editor.Expression = expression;
                _editor.DataSource = flexGrid.CollectionView.FirstOrDefault();
                if (_editor.IsValid)
                {
                    View.Filter = new Predicate<object>(Contains);
                    View.Refresh();
                }
            }
        }

        private void ExpressionEditor_ExpressionChanged(object sender, EventArgs e)
        {
            _editor.Expression = editor.Expression;
            _editor.DataSource = editor.DataSource;
            if (_editor.IsValid)
            {
                View.Filter = new Predicate<object>(Contains);
                View.Refresh();
            }
        }

        private bool Contains(object obj)
        {
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                _editor.Expression = editor.Expression;
            }
            else
            {
                _editor.Expression = c1editor.Expression;
            }
            _editor.DataSource = obj as Product;
            var value = _editor.Evaluate();
            var ret = true;
            if (value != null)
                Boolean.TryParse(value.ToString(), out ret);
            return ret;
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            var obj = flexGrid.CollectionView.FirstOrDefault();
            if (obj != null)
                _editor.DataSource = obj;
            _editor.Expression = c1editor.Expression;
            NavigateToExpressionEditor();
        }

        private void NavigateToExpressionEditor()
        {
            if (_editor != null)
            {
                _editor.Tag = typeof(SupportFilter);
                this.frame.Navigate(typeof(ExpressionEditorPage), _editor);
            }
        }
    }
}
