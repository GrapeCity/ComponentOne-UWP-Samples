Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class RulerGauge
    Inherits Page
    Implements IAnimationPage
    Private storyboard As New Storyboard()
    Private animation As New DoubleAnimation()
    Private r As New Random()
    Public Sub New()
        Me.InitializeComponent()

        animation.Duration = TimeSpan.FromSeconds(1)
        animation.EnableDependentAnimation = True
        animation.EasingFunction = New QuadraticEase() With {
            .EasingMode = EasingMode.EaseInOut
        }
        Storyboard.SetTarget(animation, myGauge)
        Storyboard.SetTargetProperty(animation, "(c1Gaugeauge.Value)")
        storyboard.Children.Add(animation)
        AddHandler storyboard.Completed, AddressOf Storyboard_Completed
        storyboard.Begin()
    End Sub

    Private Sub Storyboard_Completed(sender As Object, e As Object)
        animation.From = animation.[To]
        animation.[To] = r.NextDouble() * 100
        storyboard.Begin()
    End Sub

    Public Sub StopAnimation() Implements IAnimationPage.StopAnimation
        storyboard.Stop()
    End Sub
End Class
