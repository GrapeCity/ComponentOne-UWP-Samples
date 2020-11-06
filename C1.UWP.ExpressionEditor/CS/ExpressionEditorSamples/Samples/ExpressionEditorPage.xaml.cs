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
    public sealed partial class ExpressionEditorPage : Page
    {
        private Type _backPageType = null;

        public ExpressionEditorPage()
        {
            this.InitializeComponent();

            expressionEditor.OkClick += Editor_OkClick;
            expressionEditor.CancelClick += Editor_CancelClick;
        }

        private void Editor_CancelClick(object sender, RoutedEventArgs e)
        {
            if (this._backPageType != null)
            {
                this.Frame.Navigate(_backPageType);
            }
        }

        private void Editor_OkClick(object sender, RoutedEventArgs e)
        {
            if (this._backPageType != null)
            {
                PageCache.SetCacheExpression(expressionEditor.Expression);
                this.Frame.Navigate(this._backPageType);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameter = e.Parameter;
            if (parameter != null)
            {
                var editor = parameter as C1ExpressionEditor;
                if (editor != null)
                {
                    _backPageType = editor.Tag as Type;
                    expressionEditor.DataSource = editor.DataSource;
                    expressionEditor.Expression = editor.Expression;
                }
            }
        }
    }
}
