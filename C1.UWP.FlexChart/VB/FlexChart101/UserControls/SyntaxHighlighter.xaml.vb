Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports System.Text.RegularExpressions
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.UI

' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Partial Public Class SyntaxHighlighter
    Inherits UserControl
    Private previousCursor As CoreCursor
    Private _rangeStyles As New C1RangeStyleCollection()

    ' initialize regular expression used to parse xaml
    Private tagPattern As String = "</?(?<tagName>[a-zA-Z0-9_:\-]+)" + "(\s+(?<attName>[a-zA-Z0-9_:\-]+)(?<attValue>(=""[^""]+"")?))*\s*/?>"
    ' initialize regular expression used to parse csharp
    Private stringPattern As String = """(?:\\""|.)*?"""
    Private commentPattern As String = "//[^\n]*\n|/\*(.|[\r\n])*?\*/"

    ' reserved words kept to a minimum (not complete)
    Private reservedWords As String() = New String() {"if", "else", "public", "int", "double", "string",
        "bool", "using", "class", "object", "public", "private",
        "partial", "void", "namespace", "for", "foreach"}

    ' initialize styles used to color the document
    Private brBlue As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Color.FromArgb(255, 0, 0, 255))}
    }
    Private brDarkBlue As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Color.FromArgb(255, 0, 0, 180))}
    }
    Private brDarkRed As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Color.FromArgb(255, 180, 0, 0))}
    }
    Private brLightRed As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Colors.Red)}
    }
    Private brGreen As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Color.FromArgb(255, 0, 160, 0))}
    }

    Public Sub New()
        Me.InitializeComponent()
        If Window.Current.CoreWindow IsNot Nothing Then
            previousCursor = Window.Current.CoreWindow.PointerCursor
        End If
    End Sub

    ' perform syntax coloring
    Sub UpdateSyntaxColoring()
        Dim range As C1TextRange = c1RichTextBox1.Document.ContentRange

        ' reset coloring
        _rangeStyles = New C1RangeStyleCollection()
        c1RichTextBox1.StyleOverrides.Clear()
        c1RichTextBox1.StyleOverrides.Add(_rangeStyles)

        Dim input As String = range.Text

        If Mode = SyntaxMode.Xaml Then
            ' highlight the matches            
            For Each m As Match In Regex.Matches(input, tagPattern)
                ' select whole tag, make it dark blue
                _rangeStyles.Add(New C1RangeStyle(GetRangeAtTextOffset(range.Start, m), brDarkBlue))

                ' select tag name, make it dark red
                Dim tagName As Group = m.Groups("tagName")
                _rangeStyles.Add(New C1RangeStyle(GetRangeAtTextOffset(range.Start, tagName), brDarkRed))

                ' select attribute names, make them light red
                Dim attGroup As Group = m.Groups("attName")
                If attGroup IsNot Nothing Then
                    Dim atts As CaptureCollection = attGroup.Captures
                    Dim i As Integer = 0
                    While i < atts.Count
                        Dim att As Capture = atts(i)
                        _rangeStyles.Add(New C1RangeStyle(GetRangeAtTextOffset(range.Start, att), brLightRed))
                        i += 1
                    End While
                End If
            Next
        ElseIf Mode = SyntaxMode.CSharp Then
            ' highlight reserved words first
            For Each keyword As String In reservedWords
                For Each m As Match In Regex.Matches(input, keyword + " ")
                    ' select reserved word, make it blue
                    _rangeStyles.Add(New C1RangeStyle(GetRangeAtTextOffset(range.Start, m), brBlue))
                Next
            Next

            ' highlight strings            
            For Each m As Match In Regex.Matches(input, stringPattern)
                ' select string, make it red
                _rangeStyles.Add(New C1RangeStyle(GetRangeAtTextOffset(range.Start, m), brDarkRed))
            Next

            ' highlight comments           
            For Each m As Match In Regex.Matches(input, commentPattern)
                ' select comment, make it green
                _rangeStyles.Add(New C1RangeStyle(GetRangeAtTextOffset(range.Start, m), brGreen))
            Next
        End If
    End Sub

    Function GetRangeAtTextOffset(pos As C1TextPointer, capture As Capture) As C1TextRange
        Dim predicate As Predicate(Of Tag) = AddressOf C1TextRange.TextTagFilter
        Dim start As C1TextPointer = pos.GetPositionAtOffset(capture.Index, predicate)
        Dim [end] As C1TextPointer = start.GetPositionAtOffset(capture.Length, predicate)
        Return New C1TextRange(start, [end])
    End Function

#Region "Mode"
    Public Property Mode() As SyntaxMode
    Public Enum SyntaxMode
        Xaml
        CSharp
    End Enum
#End Region

#Region "Text"
    Private Shared DefaultText As String = "No text found"

    ''' <summary>
    ''' IsAvailable Dependency Property
    ''' </summary>
    Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(SyntaxHighlighter), New PropertyMetadata(DefaultText, AddressOf OnTextChanged))

    ''' <summary>
    ''' Gets or sets the Text property. This dependency property
    ''' indicates ....
    ''' </summary>
    Public Property Text() As String
        Get
            Return CType(GetValue(TextProperty), String)
        End Get
        Set
            SetValue(TextProperty, Value)
        End Set
    End Property

    ''' <summary>
    ''' Handles changes to the IsAvailable property.
    ''' </summary>
    ''' <param name="d">
    ''' The <see cref="DependencyObject"/> on which
    ''' the property has changed value.
    ''' </param>
    ''' <param name="e">
    ''' Event data that is issued by any event that
    ''' tracks changes to the effective value of this property.
    ''' </param>
    Private Shared Sub OnTextChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim target As SyntaxHighlighter = CType(d, SyntaxHighlighter)
        Dim oldText As String = CType(e.OldValue, String)
        Dim newText As String = target.Text
        target.OnTextChanged(oldText, newText)
    End Sub

    ''' <summary>
    ''' Provides derived classes an opportunity to handle changes
    ''' to the IsAvailable property.
    ''' </summary>
    ''' <param name="oldIsAvailable">The old IsAvailable value</param>
    ''' <param name="newIsAvailable">The new IsAvailable value</param>
    Protected Overridable Sub OnTextChanged(oldText As String, newText As String)
        c1RichTextBox1.Text = newText
        UpdateSyntaxColoring()
    End Sub
#End Region

    Private Sub c1RichTextBox1_PointerExited(sender As Object, e As PointerRoutedEventArgs)
        Window.Current.CoreWindow.PointerCursor = previousCursor
    End Sub
End Class