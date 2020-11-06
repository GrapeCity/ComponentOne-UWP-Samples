Imports C1.Xaml.FlexGrid

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

#Region "ClassHomePage"
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class HomePage
        Inherits Page
#Region "PrivateVariables"
        Private cell As CategoryCellFactory = Nothing
#End Region

#Region "Contructor"
        Public Sub New()
            Me.InitializeComponent()
        End Sub
#End Region

#Region "Events"
        Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
            cell = New CategoryCellFactory()
            _flexCategory.CellFactory = cell
            AddCategoryImagesInGrid()
        End Sub
#End Region

#Region "PrivateMethods"
        Private Sub AddCategoryImagesInGrid()
            _flexCategory.Columns.Clear()
            _flexCategory.Columns.Add(New Column())
            _flexCategory.Rows.Clear()
            _flexCategory.Rows.Add(New Row())
            Dim colCnt As Integer = 0
            _flexCategory.MinColumnWidth = 300
            For Each category As Category In category.Categories
                Try
                If colCnt < 3 Then
                    _flexCategory(_flexCategory.Rows.Count - 1, colCnt) = category
                    _flexCategory.Rows(_flexCategory.Rows.Count - 1).Height = 270
                    If _flexCategory.Rows.Count < 2 Then
                        _flexCategory.Columns.Add(New Column())
                    End If
                    colCnt = colCnt + 1
                Else
                    If _flexCategory.Rows.Count < 2 Then
                        _flexCategory.Columns.RemoveAt(_flexCategory.Columns.Count - 1)
                    End If
                    _flexCategory.Rows.Add(New Row())
                    colCnt = 0
                    _flexCategory(_flexCategory.Rows.Count - 1, colCnt) = category

                    _flexCategory.Rows(_flexCategory.Rows.Count - 1).Height = 270
                    colCnt = colCnt + 1
                End If
            Catch generatedExceptionName As Exception
                End Try
            Next
        End Sub
#End Region
    End Class
#End Region