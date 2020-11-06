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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ExpressionEditorSamples
{
    /// <summary>
    /// A UserControl which contains ExpressionEditor, ExpressionEditorPanel, implementation of preview, OK&Cancel buttons.
    /// When OK button is pressed, the expression will be passed to the ExpressionEditor of the appointed Column to do the Calculation, Filter, Grouping.
    /// </summary>
    public sealed partial class ExpressionEditorEE : UserControl
    {
        //---------------------
        #region ** events

        public event EventHandler<RoutedEventArgs> OkClick;
        public event EventHandler<RoutedEventArgs> CancelClick;

        /// <summary>
        /// Occurs when expression string changed.
        /// </summary>
        public event EventHandler ExpressionChanged;
        /// <summary>
        /// Rises the <see cref="ExpressionChanged"/> event.
        /// </summary>
        protected void OnExpressionChanged(EventArgs e)
        {
            if (ExpressionChanged != null)
                ExpressionChanged(this, e);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelClick?.Invoke(sender, e);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            OkClick?.Invoke(sender, e);
        }
        #endregion

        //---------------------
        #region ** dependency properties

        public string OKContent
        {
            get { return (string)GetValue(OKContentProperty); }
            set
            {
                SetValue(OKContentProperty, value);
            }
        }
        public static readonly DependencyProperty OKContentProperty =
            DependencyProperty.Register(
                "OKContent",
                typeof(string),
                typeof(ExpressionEditorEE),
                new PropertyMetadata((string)"OK")
                );

        public string CancelContent
        {
            get { return (string)GetValue(CancelContentProperty); }
            set
            {
                SetValue(CancelContentProperty, value);
            }
        }
        public static readonly DependencyProperty CancelContentProperty =
            DependencyProperty.Register(
                "CancelContent",
                typeof(string),
                typeof(ExpressionEditorEE),
                new PropertyMetadata((string)"Cancel")
                );

        public Visibility OperateVisibility
        {
            get { return (Visibility)GetValue(OperateVisibilityProperty); }
            set
            {
                SetValue(OperateVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty OperateVisibilityProperty =
            DependencyProperty.Register(
                "OperateVisibility",
                typeof(Visibility),
                typeof(ExpressionEditorEE),
                new PropertyMetadata(Visibility.Visible)
                );

        #endregion

        //---------------------
        #region ** ctor

        public ExpressionEditorEE()
        {
            InitializeComponent();
        }
        #endregion

        //---------------------
        #region ** public interface
        /// <summary>
        /// Gets or sets the object used as the data source.
        /// </summary>
        public object DataSource
        {
            get
            {
                return this.expressionEditor.DataSource;
            }
            set
            {
                this.expressionEditor.DataSource = value;
            }
        }

        /// <summary>
        /// Gets or sets expression string.
        /// </summary>
        public string Expression
        {
            get
            {
                return this.expressionEditor.Expression;
            }
            set
            {
                this.expressionEditor.Expression = value;
            }
        }

        /// <summary>
        /// Gets value that indicates whether the expression is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.expressionEditor.IsValid;
            }
        }
        #endregion

        //---------------------
        #region ** implementation
        private void ExpressionEditor_ExpressionChanged(object sender, EventArgs e)
        {
            errors.Text = "";
            if (!IsValid)
            {
                result.Text = "";
                this.btn_Ok.IsEnabled = false;
                var editError = this.expressionEditor.GetErrors().FirstOrDefault();
                if (editError != null)
                    errors.Text = editError.FullMessage;
            }
            else
            {
                var value = this.expressionEditor.Evaluate();
                if (value != null)
                    result.Text = value.ToString();
                this.btn_Ok.IsEnabled = true;
                OnExpressionChanged(e);
            }
        }
        #endregion
    }
}
