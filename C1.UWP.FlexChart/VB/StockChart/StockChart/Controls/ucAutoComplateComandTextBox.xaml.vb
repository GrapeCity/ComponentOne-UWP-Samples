' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class ucAutoComplateComandTextBox
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
    End Sub



    Public Property Placeholder() As Object
        Get
            Return Me.GetValue(PlaceholderProperty)
        End Get
        Set
            Me.SetValue(PlaceholderProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly PlaceholderProperty As DependencyProperty = DependencyProperty.Register("Placeholder", GetType(Object), GetType(ucAutoComplateComandTextBox), New PropertyMetadata(Nothing))

    Public Property Text() As String
        Get
            Return Me.GetValue(TextProperty).ToString()
        End Get
        Set
            Me.SetValue(TextProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(ucAutoComplateComandTextBox), New PropertyMetadata(Nothing))

    Public Property ItemsSource() As Dictionary(Of String, String)
        Get
            Return DirectCast(Me.GetValue(ItemsSourceProperty), Dictionary(Of String, String))
        End Get
        Set
            Me.SetValue(ItemsSourceProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly ItemsSourceProperty As DependencyProperty = DependencyProperty.Register("ItemsSource", GetType(Dictionary(Of String, String)), GetType(ucAutoComplateComandTextBox), New PropertyMetadata(Nothing))

    Public Property ButtonContent() As Object
        Get
            Return Me.GetValue(ButtonContentProperty)
        End Get
        Set
            Me.SetValue(ButtonContentProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly ButtonContentProperty As DependencyProperty = DependencyProperty.Register("ButtonContent", GetType(Object), GetType(ucAutoComplateComandTextBox), New PropertyMetadata(Nothing))

    Public Property SymbolCode() As String
        Get
            Return Me.GetValue(SymbolCodeProperty).ToString()
        End Get
        Set
            Me.SetValue(SymbolCodeProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly SymbolCodeProperty As DependencyProperty = DependencyProperty.Register("SymbolCode", GetType(String), GetType(ucAutoComplateComandTextBox), New PropertyMetadata(Nothing))



    Public Property Command() As ICommand
        Get
            Return DirectCast(Me.GetValue(CommandProperty), ICommand)
        End Get
        Set
            Me.SetValue(CommandProperty, Value)
        End Set
    End Property


    Public Shared ReadOnly CommandProperty As DependencyProperty = DependencyProperty.Register("Command", GetType(ICommand), GetType(ucAutoComplateComandTextBox), New PropertyMetadata(Nothing))

    Private Sub txtSymbol_TextChanged(sender As AutoSuggestBox, args As AutoSuggestBoxTextChangedEventArgs)

        If args.Reason = AutoSuggestionBoxTextChangeReason.UserInput Then
            Dim src = Me.ItemsSource.Where(Function(s1, i)
                                               Return s1.Key.ToUpper().Contains(sender.Text.ToUpper()) OrElse s1.Value.ToUpper().Contains(sender.Text.ToUpper())

                                           End Function).[Select](Function(s1, i)
                                                                      Return String.Format("{0} {1}", s1.Key, s1.Value)

                                                                  End Function)

            sender.ItemsSource = src
        End If
    End Sub
End Class
