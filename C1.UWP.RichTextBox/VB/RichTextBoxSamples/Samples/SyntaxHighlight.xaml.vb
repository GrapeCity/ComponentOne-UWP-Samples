Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Documents
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports Microsoft.VisualBasic
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox

Partial Public NotInheritable Class SyntaxHighlight
    Inherits Page
    Private _rtb As C1RichTextBox
    Private _rangeStyles As New C1RangeStyleCollection()

    ' initialize regular expression used to parse HTML
    Private tagPattern As String = "</?(?<tagName>[a-zA-Z0-9_:\-]+)" + "(\s+(?<attName>[a-zA-Z0-9_:\-]+)(?<attValue>(=""[^""]+"")?))*\s*/?>"

    ' initialize styles used to color the document
    Private brDarkBlue As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Color.FromArgb(255, 0, 0, 180))}
    }
    Private brDarkRed As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Color.FromArgb(255, 180, 0, 0))}
    }
    Private brLightRed As New C1TextElementStyle() From {
        {C1TextElement.ForegroundProperty, New SolidColorBrush(Colors.Red)}
    }

    Public Sub New()
        InitializeComponent()
        AddHandler Loaded, AddressOf SyntaxHighlight_Loaded
    End Sub

    Sub SyntaxHighlight_Loaded(sender As Object, e As RoutedEventArgs)
        If _rtb Is Nothing Then
            _rtb = New C1RichTextBox() With {
                .ReturnMode = ReturnMode.SoftLineBreak,
                .TextWrapping = TextWrapping.NoWrap,
                .IsReadOnly = False,
                .Document = New C1Document() With {
                    .Background = New SolidColorBrush(Colors.White),
                    .FontFamily = New FontFamily("Courier New"),
                    .FontSize = 16
                }
            }

            Dim para As C1Paragraph = New C1Paragraph
            para.Children.Add(New C1Run() With {
                            .Text = GetStringResource("w3c.htm")
                        })
            _rtb.Document.Blocks.Add(para)
            _rtb.StyleOverrides.Clear()
            _rtb.StyleOverrides.Add(_rangeStyles)

            LayoutRoot.Children.Add(_rtb)
            AddHandler _rtb.TextChanged, AddressOf tb_TextChanged
            UpdateSyntaxColoring(_rtb.Document.ContentRange)
        End If
    End Sub

    Sub tb_TextChanged(sender As Object, e As C1TextChangedEventArgs)
        Dim start As C1TextPointer = e.Range.Start.Enumerate(LogicalDirection.Backward).FirstOrDefault(Function(p As C1TextPointer) p.Symbol.Equals(vbLf))
        If start IsNot Nothing Then
            start = start.GetPositionAtOffset(1)
        End If
        Dim [end] As C1TextPointer = e.Range.End.Enumerate().FirstOrDefault(Function(p As C1TextPointer) p.Symbol.Equals(vbCrLf))
        Dim doc As C1TextElement = e.Range.Start.Element.Root
        UpdateSyntaxColoring(New C1TextRange(If(start, doc.ContentStart), If([end], doc.ContentEnd)))
    End Sub

    ' perform syntax coloring
    Sub UpdateSyntaxColoring(range As C1TextRange)
        ' remove old coloring
        _rangeStyles.RemoveRange(range)

        Dim input As String = range.Text

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
    End Sub

    Function GetRangeAtTextOffset(pos As C1TextPointer, capture As Capture) As C1TextRange

        Dim predicate As Predicate(Of Tag) = AddressOf C1TextRange.TextTagFilter
        Dim start As C1TextPointer = pos.GetPositionAtOffset(capture.Index, predicate)
        Dim [end] As C1TextPointer = start.GetPositionAtOffset(capture.Length, predicate)
        Return New C1TextRange(start, [end])
    End Function

    ' utility
    Shared Function GetStringResource(resourceName As String) As String
        Dim asm As Assembly = GetType(SyntaxHighlight).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream([String].Format("RichTextBoxSamples.{0}", resourceName))
        Using sr As New StreamReader(stream)
            Return sr.ReadToEnd()
        End Using
    End Function
End Class