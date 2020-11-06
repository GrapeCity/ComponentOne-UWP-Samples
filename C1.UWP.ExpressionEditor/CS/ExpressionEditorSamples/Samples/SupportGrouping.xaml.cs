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
    public sealed partial class SupportGrouping : Page
    {
        C1ExpressionEditor _editor = new C1ExpressionEditor();
        public C1CollectionView View;

        public SupportGrouping()
        {
            this.InitializeComponent();

            View = new C1CollectionView(Product.GetData());

            flexGrid.ItemsSource = View;

            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                InitalizeDesktop();
            }

            flexGrid.Loaded += FlexGrid_Loaded;
        }

        void InitalizeDesktop()
        {
            editor.OkClick += Editor_OkClick;
            editor.CancelClick += Editor_CancelClick;
            editor.DataSource = flexGrid.CollectionView.FirstOrDefault();
            editor.Expression = Expressions.GetExpression();
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
            if (expression != "")
            {
                PageCache.SetCacheExpression("");
                _editor.Expression = expression;
                _editor.DataSource = flexGrid.CollectionView.FirstOrDefault();
                if (_editor.IsValid)
                {
                    ExpressionGroupDescription group = new ExpressionGroupDescription();
                    group.Expression = _editor.Expression;
                    View.GroupDescriptions.Add(group);
                }
            }
        }

        private void Editor_CancelClick(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void Editor_OkClick(object sender, RoutedEventArgs e)
        {
            if (editor.IsValid)
            {
                ExpressionGroupDescription expression = new ExpressionGroupDescription();
                expression.Expression = editor.Expression;
                View.GroupDescriptions.Add(expression);
            }
        }

        private void group_Click(object sender, RoutedEventArgs e)
        {
            var obj = flexGrid.CollectionView.FirstOrDefault();
            if (obj != null)
                _editor.DataSource = obj;
            _editor.Expression = Expressions.GetExpression();
            NavigateToExpressionEditor();
        }

        private void NavigateToExpressionEditor()
        {
            if (_editor != null)
            {
                _editor.Tag = typeof(SupportGrouping);
                this.frame.Navigate(typeof(ExpressionEditorPage), _editor);
            }
        }
    }
}
