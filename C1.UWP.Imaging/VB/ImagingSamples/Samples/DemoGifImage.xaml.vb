Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Imaging

Partial Public NotInheritable Class DemoGifImage
    Inherits Page
    Private _gifImage As C1GifImage
    Private _play As Boolean = False

    Public Sub New()
        InitializeComponent()

        _gifImage = New C1GifImage(New Uri("ms-appx:///ImagingSamplesLib/Assets/C1FlexChartZoom.gif"))

        Image.Source = _gifImage
    End Sub

    Public Property Play() As Boolean
        Get
            Return _play
        End Get
        Set
            If _play <> Value Then
                _play = Value
                If _play Then
                    _gifImage.Play()
                Else
                    _gifImage.[Stop]()
                End If
            End If
        End Set
    End Property
End Class