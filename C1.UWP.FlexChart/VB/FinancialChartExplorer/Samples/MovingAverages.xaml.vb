Imports C1.Chart
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports System.Linq
Imports System

''' <summary>
''' Interaction logic for MovingAverages.xaml
''' </summary>
Partial Public Class MovingAverages
    Inherits Page
    Private dataSerivice As DataService = DataService.GetService()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataSerivice.GetSymbolData("box")
        End Get
    End Property

    Public ReadOnly Property MovingAverageType() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(MovingAverageType)).ToList()
        End Get
    End Property
End Class