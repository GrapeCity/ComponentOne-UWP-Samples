Imports Windows.Graphics.Printing.OptionDetails
Imports Windows.UI.Xaml.Printing
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.ViewManagement
Imports Windows.UI.Popups
Imports Windows.UI.Core
Imports Windows.Graphics.Printing
Imports Windows.Foundation
Imports System.Collections.Generic
Imports System.Linq
Imports System
Imports C1.Xaml.FlexGrid

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Printing
    Inherits Page
    Private _data As ICollectionView = Product.GetProducts(100)



    Public Sub New()
        Me.InitializeComponent()

        ' populate grid
        _flex.ItemsSource = _data
        _flex.Columns("Line").AllowMerging = True
        _flex.Columns("Color").AllowMerging = True

        ' for testing
        _flex.AllowResizing = AllowResizing.Both

    End Sub


#Region "** printing"

    Sub _btnPrint_Click(sender As Object, e As RoutedEventArgs)
        Dim pp As PrintParameters = New PrintParameters()
        pp.DocumentName = Strings.SamplePrint
        pp.ScaleMode = ScaleMode.PageWidth
        _flex.Print(pp)
    End Sub

#End Region
End Class