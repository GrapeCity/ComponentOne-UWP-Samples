''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
NotInheritable Partial Class App
		Inherits Application
    ''' <summary>
    ''' Initializes the singleton application object.  This is the first line of authored code
    ''' executed, and as such is the logical equivalent of main() or WinMain().
    ''' </summary>
    Public Sub New()
        Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(Microsoft.ApplicationInsights.WindowsCollectors.Metadata Or Microsoft.ApplicationInsights.WindowsCollectors.Session)
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
    End Sub

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used such as when the application is launched to open a specific file.
    ''' </summary>
    ''' <param name="e">Details about the launch request and process.</param>
    Protected Overrides Sub OnLaunched(e As LaunchActivatedEventArgs)
#If DEBUG Then
        If System.Diagnostics.Debugger.IsAttached Then
            Me.DebugSettings.EnableFrameRateCounter = True
        End If
#End If
        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)
        ' Do not repeat app initialization when the Window already has content,
        ' just ensure that the window is active
        If rootFrame Is Nothing Then
            ' Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = New Frame()
            AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed
            'TODO: Load state from previously suspended application
            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
            End If
            ' Place the frame in the current Window
            Window.Current.Content = rootFrame
        End If
        If rootFrame.Content Is Nothing Then
            ' When the navigation stack isn't restored navigate to the first page,
            ' configuring the new page by passing required information as a navigation
            ' parameter
            rootFrame.Navigate(GetType(HomePage), e.Arguments)
        End If
        ' Ensure the current window is active
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' Invoked when Navigation to a certain page fails
    ''' </summary>
    ''' <param name="sender">The Frame which failed navigation</param>
    ''' <param name="e">Details about the navigation failure</param>
    Sub OnNavigationFailed(sender As Object, e As NavigationFailedEventArgs)
			Throw New Exception("Failed to load Page " + e.SourcePageType.FullName)
		End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs)
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        'TODO: Save application state and stop any background activity
        deferral.Complete()
    End Sub
End Class