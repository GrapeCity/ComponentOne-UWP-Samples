Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Reflection
Imports System.Collections.Generic
Imports System
Imports C1.Xaml

Partial Public Class SearchBox
    Inherits Page
    Private _propertyInfo As New List(Of PropertyInfo)()
    Private _timer As New C1.Util.Timer()

    Public Sub New()
        InitializeComponent()
        _timer.Interval = TimeSpan.FromMilliseconds(800)
        AddHandler _timer.Tick, AddressOf _timer_Tick
    End Sub
    Public Property View() As ICollectionView
    Public ReadOnly Property FilterProperties() As List(Of PropertyInfo)
        Get
            Return _propertyInfo
        End Get
    End Property
    Sub _txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs)
        If _imgClear IsNot Nothing Then
            ' update clear button visibility
            _imgClear.Visibility = If(String.IsNullOrEmpty(_txtSearch.Text), Visibility.Collapsed, Visibility.Visible)

            ' start ticking
            _timer.[Stop]()
            _timer.Start()
        End If
    End Sub
    Private Sub _imgClear_PointerPressed(sender As Object, e As Windows.UI.Xaml.Input.PointerRoutedEventArgs)
        _txtSearch.Text = String.Empty
    End Sub
    Sub _timer_Tick(sender As Object, e As EventArgs)
        _timer.[Stop]()
        If View IsNot Nothing AndAlso _propertyInfo.Count > 0 Then
            ' ICollectionView does not support filtering in WinRT,
            ' but IC1CollectionView does.
            Dim cv As IC1CollectionView = TryCast(View, IC1CollectionView)
            If cv IsNot Nothing Then
                cv.Filter = AddressOf Filter
                cv.Refresh()
            End If
        End If
    End Sub
    Function Filter(item As Object) As Boolean
        ' get search text
        Dim srch As String = _txtSearch.Text

        ' no text? show all items
        If String.IsNullOrEmpty(srch) Then
            Return True
        End If

        ' show items that contain the text in any of the specified properties
        For Each pi As PropertyInfo In _propertyInfo
            Dim value As String = TryCast(pi.GetValue(item, Nothing), String)
            If value IsNot Nothing AndAlso value.IndexOf(srch, StringComparison.OrdinalIgnoreCase) > -1 Then
                Return True
            End If
        Next

        ' exclude this item...
        Return False
    End Function
End Class