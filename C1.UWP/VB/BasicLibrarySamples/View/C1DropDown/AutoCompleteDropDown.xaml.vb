Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Documents
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Text
Imports Windows.UI
Imports Windows.System
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml
Imports Windows.Storage.Streams

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class AutoCompleteDropDown
    Inherits Page
    Private _updating As Boolean = False
    Private _text As String = String.Empty
    Private _symbol As String = String.Empty
    Private _maxItems As Integer = 9
    Private _items As Dictionary(Of String, String)

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Loaded, AddressOf OnLoaded
        Me.DropDownOpensUp = False
        If Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            AddHandler Me.txt.Loaded, AddressOf OnTextBoxLoaded
        End If
    End Sub

    Private Async Sub OnLoaded()
        Await LoadSymbols()
    End Sub

    Private Sub OnTextBoxLoaded()
        Dim binding As Binding = New Binding()
        binding.Path = New PropertyPath("Text")
        binding.Source = Me.txtSymbol
        binding.Mode = BindingMode.TwoWay
        binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        Me.txt.SetBinding(TextBox.TextProperty, binding)
        Me.txt.Focus(FocusState.Programmatic)
        Me.txt.SelectionStart = Me.txt.Text.Length
    End Sub

    Private Async Function LoadSymbols() As Task
        _items = New Dictionary(Of String, String)()
        Dim resName As String = "BasicLibrarySamplesLib\Resources\Symbols.txt"
        Dim txtFile As StorageFile = Await Package.Current.InstalledLocation.GetFileAsync(resName)
        Dim inputStream As IRandomAccessStream = Await txtFile.OpenAsync(FileAccessMode.Read)
        Using s As New StreamReader(inputStream.AsStreamForRead())
            While Not s.EndOfStream
                Dim sn As String() = s.ReadLine().Split()
                If sn.Length = 2 Then
                    _items(sn(0)) = sn(1)
                End If
            End While
        End Using
    End Function

#Region "** object model"

    Public Property DropDownOpensUp() As Boolean
        Get
            Return (searchSymbols.DropDownDirection = DropDownDirection.ForceAbove)
        End Get
        Set
            If Value Then
                searchSymbols.DropDownDirection = DropDownDirection.ForceAbove
            Else
                searchSymbols.DropDownDirection = DropDownDirection.ForceBelow
            End If
        End Set
    End Property

    Public Property Items() As Dictionary(Of String, String)
        Get
            Return _items
        End Get
        Set
            _items = Value
        End Set
    End Property
    Public ReadOnly Property Text() As String
        Get
            Return _text
        End Get
    End Property

    Public ReadOnly Property Symbol() As String
        Get
            Return _symbol
        End Get
    End Property

    Public Event SelectionChange As EventHandler

#End Region

    Private Sub txtSymbol_TextChanged(sender As Object, e As TextChangedEventArgs)
        If (Not _updating) AndAlso (_selectedText <> txtSymbol.Text) Then
            Dim text As String = txtSymbol.Text
            Dim items As List(Of String) = BuildList(text)
            If items.Count = 0 Then
                If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
                    searchSymbols.IsDropDownOpen = False
                Else
                    listBox.Items.Clear()
                End If
            Else
                listBox.Items.Clear()
                For Each key As String In items
                    listBox.Items.Add(BuildItem(text, key, _items(key)))
                Next
                searchSymbols.IsDropDownOpen = True
            End If
        End If
    End Sub

    Private Sub txtSymbol_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        Dim delta As Integer = 0
        Select Case e.Key
            Case VirtualKey.Down
                delta = 1
                Exit Select

            Case VirtualKey.Up
                delta = -1
                Exit Select

            Case VirtualKey.Enter
                CommitListSelection()
                Exit Select

            Case VirtualKey.Escape
                searchSymbols.IsDropDownOpen = False
                Exit Select
        End Select

        Dim oldIndex As Integer
        If (_selectedItem IsNot Nothing) AndAlso listBox.Items.Contains(_selectedItem) Then
            oldIndex = listBox.Items.IndexOf(_selectedItem)
        Else
            oldIndex = (If(DropDownOpensUp, listBox.Items.Count, -1))
        End If
        Dim index As Integer = Math.Min(Math.Max(0, oldIndex + delta), listBox.Items.Count - 1)
        If (index >= 0) AndAlso (index < listBox.Items.Count) Then
            SelectedItem = TryCast(listBox.Items(index), ContentControl)
        End If
    End Sub

    Private Sub txtSymbol_LostFocus(sender As Object, e As RoutedEventArgs)
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            searchSymbols.IsDropDownOpen = False
        End If
    End Sub

    Private _selectedText As String
    Sub li_MouseLeftButtonDown(sender As Object, e As PointerRoutedEventArgs)
        SelectedItem = TryCast(sender, ContentControl)
        If SelectedItem IsNot Nothing Then
            CommitListSelection()
        End If
    End Sub

#Region "** private stuff"

    ' commit listbox selection

    Private _selectedItem As ContentControl = Nothing
    Private Property SelectedItem() As ContentControl
        Get
            Return _selectedItem
        End Get
        Set
            If _selectedItem IsNot Nothing Then
                TryCast(_selectedItem.Content, StackPanel).Background = New SolidColorBrush(Colors.Transparent)
            End If
            _selectedItem = Value
            If Value IsNot Nothing Then
                TryCast(Value.Content, StackPanel).Background = New SolidColorBrush(Color.FromArgb(&HFF, &HB8, &HD1, &HE4))
            End If
        End Set
    End Property

    Private Sub CommitListSelection()
        If _selectedItem Is Nothing Then
            Return
        End If
        Dim sp As StackPanel = CType((_selectedItem).Content, StackPanel)
        If sp IsNot Nothing Then
            ' apply text to textbox, hide popup
            _updating = True
            _symbol = (TryCast(sp.Children(0), TextBlock)).Text
            _text = (TryCast(sp.Children(1), TextBlock)).Text
            txtSymbol.Text = _symbol
            _updating = False

            ' fire event to indicate a choice was made
            CommitSelection()

            searchSymbols.IsDropDownOpen = False

            _selectedText = txtSymbol.Text
            txtSymbol.[Select](0, txtSymbol.Text.Length)
        End If
    End Sub

    ' commit C1TextBox change
    Private Sub CommitSelection()
        RaiseEvent SelectionChange(Me, New EventArgs())
    End Sub

    ' methods used for building the pick list
    Private Function BuildList(text As String) As List(Of String)
        Dim list As New List(Of String)()
        If text.Length > 0 Then
            ' add matches on symbol first
            For Each key As String In _items.Keys
                If key.StartsWith(text, StringComparison.CurrentCultureIgnoreCase) Then
                    list.Add(key)
                    If list.Count >= _maxItems Then
                        Exit For
                    End If
                End If
            Next

            ' add matches on name second
            For Each key As String In _items.Keys
                If _items(key).IndexOf(text, StringComparison.CurrentCultureIgnoreCase) > -1 AndAlso Not list.Contains(key) Then
                    list.Add(key)
                    If list.Count >= _maxItems Then
                        Exit For
                    End If
                End If
            Next
        End If
        Return list
    End Function

    Private Function BuildItem(search As String, key As String, text As String) As FrameworkElement
        Dim p As New StackPanel()
        p.Orientation = Orientation.Horizontal
        p.Background = New SolidColorBrush(Colors.Transparent)
        p.Children.Add(BuildSubItem(search, key, 60))
        p.Children.Add(BuildSubItem(search, text, 200))

        Dim c As New ContentControl()
        AddHandler c.PointerPressed, New PointerEventHandler(AddressOf li_MouseLeftButtonDown)
        c.Content = p

        Return c
    End Function

    Private Function BuildSubItem(search As String, text As String, width As Double) As TextBlock
        Dim tb As New TextBlock()
        tb.Text = String.Empty
        tb.Margin = New Thickness(5)

        Dim start As Integer = 0
        While True
            ' look for a match
            Dim index As Integer = text.IndexOf(search, start, StringComparison.CurrentCultureIgnoreCase)

            ' match not found, add remainder and be done
            If index < 0 Then
                CreateRun(tb, False, text.Substring(start))
                Exit While
            End If

            ' match found: add regular and bold parts
            If index > start Then
                CreateRun(tb, False, text.Substring(start, index - start))
            End If
            CreateRun(tb, True, text.Substring(index, search.Length))
            start = index + search.Length
        End While

        tb.Width = width
        Return tb
    End Function

    Private Sub CreateRun(tb As TextBlock, highlight As Boolean, text As String)
        Dim run As New Run()
        run.Text = text
        run.FontFamily = FontFamily
        run.FontSize = FontSize
        run.FontWeight = If(highlight, FontWeights.Bold, FontWeights.Normal)

        tb.Inlines.Add(run)
    End Sub

#End Region


End Class