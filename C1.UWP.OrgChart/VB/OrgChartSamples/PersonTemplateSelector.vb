Imports Windows.UI.Xaml
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Class used to select the templates for items being created.
''' </summary>
Public Class PersonTemplateSelector
    Inherits Windows.UI.Xaml.Controls.DataTemplateSelector
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Dim p As Person = TryCast(item, Person)
        'var e = Application.Current.RootVisual as FrameworkElement;
        'return p.Position.IndexOf("Director") > -1
        '    ? e.Resources["_tplDirector"] as DataTemplate
        '    : e.Resources["_tplOther"] as DataTemplate;


        If p.Position.IndexOf(Strings.Director) > -1 Then
            Return DirectorTemplate
        ElseIf p.Position.IndexOf(Strings.Manager) > -1 Then
            Return ManagerTemplate
        ElseIf p.Position.IndexOf(Strings.Designer) > -1 Then
            Return DesignerTemplate
        Else
            Return OtherTemplate
        End If
    End Function

    Public Property DirectorTemplate() As DataTemplate
    Public Property ManagerTemplate() As DataTemplate
    Public Property DesignerTemplate() As DataTemplate
    Public Property OtherTemplate() As DataTemplate
End Class