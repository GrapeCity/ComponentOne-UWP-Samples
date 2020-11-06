using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace StockChart
{
    public sealed partial class ucAutoComplateComandTextBox : UserControl
    {
        public ucAutoComplateComandTextBox()
        {
            this.InitializeComponent();
        }



        public object Placeholder
        {
            get { return this.GetValue(PlaceholderProperty); }
            set { this.SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                "Placeholder", typeof(object), typeof(ucAutoComplateComandTextBox),
                new PropertyMetadata(null)
                );

        public string Text
        {
            get { return this.GetValue(TextProperty).ToString(); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", typeof(string), typeof(ucAutoComplateComandTextBox),
                new PropertyMetadata(null)
                );

        public Dictionary<string, string> ItemsSource
        {
            get { return (Dictionary<string, string>)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource", typeof(Dictionary<string, string>), typeof(ucAutoComplateComandTextBox),
                new PropertyMetadata(null)
                );

        public object ButtonContent
        {
            get { return this.GetValue(ButtonContentProperty); }
            set { this.SetValue(ButtonContentProperty, value); }
        }

        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register(
                "ButtonContent", typeof(object), typeof(ucAutoComplateComandTextBox),
                new PropertyMetadata(null)
                );

        public string SymbolCode
        {
            get { return this.GetValue(SymbolCodeProperty).ToString(); }
            set { this.SetValue(SymbolCodeProperty, value); }
        }

        public static readonly DependencyProperty SymbolCodeProperty =
            DependencyProperty.Register(
                "SymbolCode", typeof(string), typeof(ucAutoComplateComandTextBox),
                new PropertyMetadata(null)
                );



        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command", typeof(ICommand), typeof(ucAutoComplateComandTextBox),
                new PropertyMetadata(null, (o, e) =>
                {

                })
                );
        private void txtSymbol_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var src = this.ItemsSource.Where((s1, i) =>
                {
                    return s1.Key.ToUpper().Contains(sender.Text.ToUpper()) || s1.Value.ToUpper().Contains(sender.Text.ToUpper());
                })
                .Select((s1, i) =>
                {
                    return string.Format("{0} {1}", s1.Key, s1.Value);
                });

                sender.ItemsSource = src;
            }
        }
    }
}
