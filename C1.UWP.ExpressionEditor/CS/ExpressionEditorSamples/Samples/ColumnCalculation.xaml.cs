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
    public sealed partial class ColumnCalculation : Page
    {
        private C1ExpressionEditor _editor;

        public ColumnCalculation()
        {
            this.InitializeComponent();

            List<Product> items = Product.GetData();
            flexGrid.ItemsSource = items;

            C1ExpressionEditor c1ExpressionEditor1 = new C1ExpressionEditor();
            C1ExpressionEditor c1ExpressionEditor2 = new C1ExpressionEditor();
            c1ExpressionEditor1.Expression = "[Price]*0.95";
            c1ExpressionEditor2.Expression = "[Price]*0.8";
            flexGrid.ExpressionEditors.Add("CustomField1", c1ExpressionEditor1);
            flexGrid.ExpressionEditors.Add("CustomField2", c1ExpressionEditor2);

            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                InitalizeDesktop();
                comboBox.SelectedIndex = 0;
            }
            else
            {
                comboBox.SelectedIndex = -1;
            }
            flexGrid.Loaded += FlexGrid_Loaded;
        }

        void InitalizeDesktop()
        {
            editor.OkClick += Editor_OkClick;
            editor.CancelClick += Editor_CancelClick;
        }

        private void FlexGrid_Loaded(object sender, RoutedEventArgs e)
        {
            flexGrid.AutoSizeColumns(0, 1, 2); // adjust column sizes to reflect long headers

            var field = PageCache.GetCacheField();
            if (flexGrid != null && flexGrid.ExpressionEditors.Contains(field))
            {
                flexGrid.ExpressionEditors[field].Expression = PageCache.GetCacheExpression();
                PageCache.SetCacheField("");
                PageCache.SetCacheExpression("");
            }
        }

        private void Editor_CancelClick(object sender, RoutedEventArgs e)
        {
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                var field = ((ComboBoxItem)comboBox.SelectedItem).Tag as string;
                if (flexGrid != null && flexGrid.ExpressionEditors.Contains(field))
                {
                    editor.Expression = flexGrid.ExpressionEditors[field].Expression;
                }
            }
        }

        private void Editor_OkClick(object sender, RoutedEventArgs e)
        {
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                var field = ((ComboBoxItem)comboBox.SelectedItem).Tag as string;
                if (flexGrid != null && flexGrid.ExpressionEditors.Contains(field))
                {
                    flexGrid.ExpressionEditors[field].Expression = editor.Expression;
                }
            }
        }

        // Change ExpressionEditor settings to allow edit expression for selected C1FlexGrid column.
        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var field = (e.AddedItems[0] as ComboBoxItem).Tag as string;
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                if (flexGrid != null && flexGrid.ExpressionEditors.Contains(field))
                {
                    if (_editor == null)
                    {
                        _editor = new C1ExpressionEditor();
                    }
                    _editor.DataSource = flexGrid.ExpressionEditors[field].DataSource;
                    _editor.Expression = flexGrid.ExpressionEditors[field].Expression;
                    PageCache.SetCacheField(field);
                    NavigateToExpressionEditor();
                }
            }
            else
            {
                if (flexGrid != null && flexGrid.ExpressionEditors.Contains(field))
                {
                    editor.DataSource = flexGrid.ExpressionEditors[field].DataSource;
                    editor.Expression = flexGrid.ExpressionEditors[field].Expression;
                }
            }
        }

        private void NavigateToExpressionEditor()
        {
            if (_editor != null)
            {
                _editor.Tag = typeof(ColumnCalculation);
                this.frame.Navigate(typeof(ExpressionEditorPage), _editor);
            }
        }
    }
}
