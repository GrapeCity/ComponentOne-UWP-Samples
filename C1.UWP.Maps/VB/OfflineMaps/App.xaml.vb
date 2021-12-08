Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.ApplicationModel
Imports Windows.ApplicationModel.Activation
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation

Partial NotInheritable Class App
    Inherits Application

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
    End Sub

    Protected Overrides Sub OnLaunched(ByVal e As LaunchActivatedEventArgs)
        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        If rootFrame Is Nothing Then
            rootFrame = New Frame()
            AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
            End If

            Window.Current.Content = rootFrame
        End If

        If e.PrelaunchActivated = False Then

            If rootFrame.Content Is Nothing Then
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
            End If

            Window.Current.Activate()
        End If
    End Sub

    Private Sub OnNavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs)
        Throw New Exception("Failed to load Page " & e.SourcePageType.FullName)
    End Sub

    Private Sub OnSuspending(ByVal sender As Object, ByVal e As SuspendingEventArgs)
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        deferral.Complete()
    End Sub
End Class
