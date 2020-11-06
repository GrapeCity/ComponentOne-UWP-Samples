Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Chart

''' <summary>
''' Interaction logic for BoxWhisker.xaml
''' </summary>
Partial Public Class BoxWhisker
    Inherits Page
    Private _calculations As List(Of String) = Nothing
    Private _data As List(Of ClassScore) = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property Calculations() As List(Of String)
        Get
            If _calculations Is Nothing Then
                _calculations = DataCreator.CreateQuartileCalculations()
            End If

            Return _calculations
        End Get
    End Property

    Public ReadOnly Property Data() As List(Of ClassScore)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateSchoolScoreData()
            End If

            Return _data
        End Get
    End Property

    Private Sub CheckedChanged(sender As Object, e As RoutedEventArgs)
        If boxWhiskerA Is Nothing OrElse boxWhiskerB Is Nothing OrElse boxWhiskerC Is Nothing Then
            Return
        End If

        If sender Is cbShowMeanLine Then
            boxWhiskerA.ShowMeanLine = cbShowMeanLine.IsChecked.Value
            boxWhiskerB.ShowMeanLine = cbShowMeanLine.IsChecked.Value
            boxWhiskerC.ShowMeanLine = cbShowMeanLine.IsChecked.Value
        ElseIf sender Is cbShowInnerPoints Then
            boxWhiskerA.ShowInnerPoints = cbShowInnerPoints.IsChecked.Value
            boxWhiskerB.ShowInnerPoints = cbShowMeanLine.IsChecked.Value
            boxWhiskerC.ShowInnerPoints = cbShowMeanLine.IsChecked.Value
        ElseIf sender Is cbShowOutliers Then
            boxWhiskerA.ShowOutliers = cbShowOutliers.IsChecked.Value
            boxWhiskerB.ShowOutliers = cbShowOutliers.IsChecked.Value
            boxWhiskerC.ShowOutliers = cbShowOutliers.IsChecked.Value
        Else
            boxWhiskerA.ShowMeanMarks = cbShowMeanMarks.IsChecked.Value
            boxWhiskerB.ShowMeanMarks = cbShowMeanMarks.IsChecked.Value
            boxWhiskerC.ShowMeanMarks = cbShowMeanMarks.IsChecked.Value
        End If
    End Sub

    Private Sub cboQuartileCalculation_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If boxWhiskerA Is Nothing OrElse boxWhiskerB Is Nothing OrElse boxWhiskerC Is Nothing Then
            Return
        End If

        Dim comboBox As ComboBox = TryCast(sender, ComboBox)
        If comboBox.SelectedValue IsNot Nothing Then
            Dim calculation As QuartileCalculation = CType([Enum].Parse(GetType(QuartileCalculation), comboBox.SelectedValue.ToString()), QuartileCalculation)
            boxWhiskerA.QuartileCalculation = calculation
            boxWhiskerB.QuartileCalculation = calculation
            boxWhiskerC.QuartileCalculation = calculation
        End If
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        cboQuartileCalculation.SelectedIndex = 0
    End Sub
End Class