Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Text
Imports System.Reflection
Imports System
Imports C1.Xaml.FlexGrid

Public MustInherit Class TemplateCell
    Inherits StackPanel
    Private Shared _customTemplatesDictionary As ResourceDictionary
    Public Shared ReadOnly Property CustomTemplatesDictionary() As ResourceDictionary
        Get
            If _customTemplatesDictionary Is Nothing Then
                _customTemplatesDictionary = New ResourceDictionary()
                If GetType(TemplateCell).GetTypeInfo().[Module].Name.EndsWith("exe") Then
                    _customTemplatesDictionary.Source = New Uri("ms-appx:///Resources/CustomTemplatesDictionary.xaml")
                Else
                    _customTemplatesDictionary.Source = New Uri("ms-appx:///FlexGridSamplesLib/Resources/CustomTemplatesDictionary.xaml")
                End If
            End If
            Return _customTemplatesDictionary
        End Get
    End Property

    Protected Property Icon() As ContentControl
    Protected Property TextBlock() As TextBlock

    Private Property Row() As Row

    Public Sub New(r As Row)
        Row = r
        Orientation = Orientation.Horizontal

        Icon = New ContentControl()
        Icon.Width = 25
        Icon.Height = 25
        Icon.VerticalAlignment = VerticalAlignment.Center
        Icon.Margin = New Thickness(4)
        Icon.ContentTemplate = GetIcon()
        Children.Add(Icon)

        TextBlock = New TextBlock()
        TextBlock.VerticalAlignment = VerticalAlignment.Center
        Children.Add(TextBlock)
        BindCell(r.DataItem)
    End Sub

    Sub BindCell(dataItem As Object)
        Dim binding As New Binding() With {
            .Path = New PropertyPath("Name")
        }
        binding.Source = dataItem
        TextBlock.SetBinding(TextBlock.TextProperty, binding)
        TextBlock.Foreground = Row.Grid.Foreground
    End Sub
    Public MustOverride Function GetIcon() As DataTemplate

End Class

''' <summary>
''' Represents a grid cell that is bound to a song name.
''' </summary>
Public Class SongCell
    Inherits TemplateCell
    Public Sub New(row As Row)
        MyBase.New(row)
    End Sub
    Public Overrides Function GetIcon() As DataTemplate
        Return TryCast(TemplateCell.CustomTemplatesDictionary("SongIcon"), DataTemplate)
    End Function
End Class

''' <summary>
''' Represents a grid cell that has a collapse/expand icon, an image, and some text.
''' </summary>
Public MustInherit Class NodeCell
    Inherits TemplateCell
    Private _gr As GroupRow
    Private _nodeExpandButton As ToggleButton

    Public Sub New(row As Row)
        MyBase.New(row)
        ' store reference to row
        _gr = TryCast(row, GroupRow)
        ' initialize collapsed/expanded image
        _nodeExpandButton = New ToggleButton()
        If Util.IsWindowsPhoneDevice() Then
            _nodeExpandButton.Template = TryCast(TemplateCell.CustomTemplatesDictionary("ExpandCollapsePhoneTemplate"), ControlTemplate)
        Else
            _nodeExpandButton.Template = TryCast(TemplateCell.CustomTemplatesDictionary("ExpandCollapseTemplate"), ControlTemplate)
        End If

        _nodeExpandButton.IsChecked = Not _gr.IsCollapsed
        AddHandler _nodeExpandButton.Checked, AddressOf OnExpandButtonToggled
        AddHandler _nodeExpandButton.Unchecked, AddressOf OnExpandButtonToggled
        Children.Insert(0, _nodeExpandButton)

        ' make text bold
        TextBlock.FontWeight = FontWeights.Bold
    End Sub

    Sub OnExpandButtonToggled(sender As Object, e As RoutedEventArgs)
        Dim toggleButton As ToggleButton = TryCast(sender, ToggleButton)
        _gr.IsCollapsed = Not toggleButton.IsChecked.Value
    End Sub
End Class

''' <summary>
''' Represents a grid cell that is bound to an artist.
''' </summary>
Public Class ArtistCell
    Inherits NodeCell
    Public Sub New(row As Row)
        MyBase.New(row)
    End Sub
    Public Overrides Function GetIcon() As DataTemplate
        Return TryCast(TemplateCell.CustomTemplatesDictionary("ArtistIcon"), DataTemplate)
    End Function
End Class

''' <summary>
''' Represents a grid cell that is bound to an album.
''' </summary>
Public Class AlbumCell
    Inherits NodeCell
    Public Sub New(row As Row)
        MyBase.New(row)
    End Sub
    Public Overrides Function GetIcon() As DataTemplate
        Return TryCast(TemplateCell.CustomTemplatesDictionary("ArtistIcon"), DataTemplate)
    End Function
End Class