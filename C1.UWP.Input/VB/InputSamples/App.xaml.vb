Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports Windows.ApplicationModel.Activation
Imports Windows.ApplicationModel
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports InputSamples.Common


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
			Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
        C1.UWP.LicenseManager.Key = "ACABIAIgB3lJAG4AcAB1AHQAUwBhAG0AcABsAGUAcwCQonLzc+pOxUo15iZFXrWq" + "N4ZF/lgnO8DQkdrjS15y1LJG2/tXRKBmNJK1/D6QEYJbSV8kxoaRm1IViFvR1B/L" + "apRIsQYne0IzGa6mkwKcIPYqsUMfJ3tw8NZUfPfiy3llSHBKdkWbmS5S4vX/Cszc" + "4mfnjUNqYY5b4RIXLiywLwJURMlJCVjTd9TfSjLaKX3gTt4v4Jf/yhHu/Mr1ISmc" + "xjKSu9D08KaKUsSjKwLnjWjiMpgQusPdKyOBN9BDjVAYaMmiF/RPXvkVWqYRZYgE" + "Ubbzu9wvjEv1PKkBJ54jtHCjGZs5tYGBKvYH92seP8vKKWqzzfedUzc7zpc8tad5" + "rSQI+hSnyeGM1dQux4g/Aqzzr8XEtvTGxiHPAvOIMHPvxxfz0BBTvNlSaHbhwSSI" + "nY8f8a9yl1IpZfL0Xwxt5POJoUCx7gB3ZgjhPn9qGZho3JmpEibBgDORcjYKadGe" + "/vp7C/wcwA9eYRXBOdh3AXKLr+dr05X5gxFm1+b9CKXpVv4NwAlc2yM70KDvjgvs" + "f0WoyEVK89I8lmlNQB5r+vNuO661TcemKxzobaUNjp5F/mxR3LurKCi9u0VETa9s" + "YQM1bOiV0TL5n8bdz1zj84qnIG/yw5+Ajk1m3tJn7Z8n49ACy7xBEvHkEYdlpZ8S" + "/2AcPXrdh1lts9eOWVBAfzCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" + "DQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2ln" + "biwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UE" + "CxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEg" + "KGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIw" + "MTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UE" + "BhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1" + "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"
		End Sub

		''' <summary>
		''' Invoked when the application is launched normally by the end user.  Other entry points
		''' will be used when the application is launched to open a specific file, to display
		''' search results, and so forth.
		''' </summary>
		''' <param name="args">Details about the launch request and process.</param>
		Protected Overrides Async Sub OnLaunched(args As LaunchActivatedEventArgs)
			Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

			' Do not repeat app initialization when the Window already has content,
			' just ensure that the window is active
			If rootFrame Is Nothing Then
				' Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = New Frame()
				'Associate the frame with a SuspensionManager key                                
				SuspensionManager.RegisterFrame(rootFrame, "AppFrame")

				If args.PreviousExecutionState = ApplicationExecutionState.Terminated Then
					' Restore the saved session state only when appropriate
					Try
						Await SuspensionManager.RestoreAsync()
							'Something went wrong restoring state.
							'Assume there is no state and continue
					Catch generatedExceptionName As SuspensionManagerException
					End Try
				End If

				' Place the frame in the current Window
				Window.Current.Content = rootFrame
			End If
			If rootFrame.Content Is Nothing Then
				' When the navigation stack isn't restored navigate to the first page,
				' configuring the new page by passing required information as a navigation
				' parameter
				If Not rootFrame.Navigate(GetType(MainPage), "AllItems") Then
					Throw New Exception(Strings.InitializationException)
				End If
			End If
			' Ensure the current window is active
			Window.Current.Activate()

			DataProvider.GetProvider().InstallData()
		End Sub

		''' <summary>
		''' Invoked when application execution is being suspended.  Application state is saved
		''' without knowing whether the application will be terminated or resumed with the contents
		''' of memory still intact.
		''' </summary>
		''' <param name="sender">The source of the suspend request.</param>
		''' <param name="e">Details about the suspend request.</param>
		Private Async Sub OnSuspending(sender As Object, e As SuspendingEventArgs)
			Dim deferral As Object = e.SuspendingOperation.GetDeferral()
			Await SuspensionManager.SaveAsync()
			deferral.Complete()
		End Sub
End Class