using C1.Xaml;
using C1.Xaml.Chart;
using C1.Xaml.ExpressionEditor;
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
    public sealed partial class FlexChartFilter : Page
    {
        C1ExpressionEditor _editor = new C1ExpressionEditor();
        public C1CollectionView View;

        public FlexChartFilter()
        {
            this.InitializeComponent();

            View = new C1CollectionView(DataCreator.CreateData());

            flexChart.ItemsSource = View;
            flexChart.BindingX = "Country";
            flexChart.Series.Add(new Series() { SeriesName = "Sales", Binding = "Sales" });
            flexChart.Series.Add(new Series() { SeriesName = "Expenses", Binding = "Expenses" });

            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                InitalizeDesktop();
            }
            else
            {
                InitalizeMobile();
            }

            flexChart.Loaded += FlexChart_Loaded;
        }

        private void FlexChart_Loaded(object sender, RoutedEventArgs e)
        {
            var expression = PageCache.GetCacheExpression();
            if (expression != _editor.Expression)
            {
                PageCache.SetCacheExpression("");
                if (expression == "")
                    expression = "[Sales] < 10";
                _editor.Expression = expression;
                _editor.DataSource = View.FirstOrDefault();
                if (_editor.IsValid)
                {
                    View.Filter = new Predicate<object>(Contains);
                    View.Refresh();
                }
            }
        }

        void InitalizeDesktop()
        {
            editor.DataSource = View.FirstOrDefault();
            editor.Expression = "[Sales] < 10";
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
                c1editor.Expression = "[Sales] < 10";
            }
            c1editor.DataSource = View.FirstOrDefault();
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
            _editor.DataSource = obj as DataItem;
            var value = _editor.Evaluate();
            var ret = true;
            if (value != null)
                Boolean.TryParse(value.ToString(), out ret);
            return ret;
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                if (editor.IsValid)
                {
                    View.Filter = new Predicate<object>(Contains);
                    View.Refresh();
                }
            }
            else
            {
                _editor.DataSource = View.FirstOrDefault();
                _editor.Expression = c1editor.Expression;
                NavigateToExpressionEditor();
            }
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
            View.Refresh();
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            editor.ExpressionChanged += Editor_ExpressionChanged;
            if (editor.IsValid)
            {
                View.Filter = new Predicate<object>(Contains);
                View.Refresh();
            }
        }

        private void Check_Unchecked(object sender, RoutedEventArgs e)
        {
            editor.ExpressionChanged -= Editor_ExpressionChanged;
        }

        private void Editor_ExpressionChanged(object sender, EventArgs e)
        {
            if (editor.IsValid)
            {
                View.Filter = new Predicate<object>(Contains);
                View.Refresh();
            }
        }

        private void NavigateToExpressionEditor()
        {
            if (_editor != null)
            {
                _editor.Tag = typeof(FlexChartFilter);
                this.frame.Navigate(typeof(ExpressionEditorPage), _editor);
            }
        }
    }
}
