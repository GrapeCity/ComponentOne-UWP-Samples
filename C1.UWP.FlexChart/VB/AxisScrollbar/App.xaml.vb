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

''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
Partial NotInheritable Class App
    Inherits Application
    ''' <summary>
    ''' Initializes the singleton application object.  This is the first line of authored code
    ''' executed, and as such is the logical equivalent of main() or WinMain().
    ''' </summary>
    Public Sub New()
        C1.UWP.LicenseManager.Key =
            "ACIBIgIiB3tBAHgAaQBzAFMAYwByAG8AbABsAGIAYQByAJ1xlQmu3gUvJQZvsz+H" +
            "X0rOM28LPxFQP1rQn2Pi7ck7fIE4Y3mY1AoOTFujwWZGepYLWTmZn+e5ERiE3Svz" +
            "D3FjEswpRhkNxcjkNw0aoxV/E5yerZeH7Vid2yo3icUgilGRlNwue3H2UqcrO1WG" +
            "e6Lbe9ednnE8FCr+IbNUJrbQcqz3Mf1wwyJSKYzxlmgvkIK5mi+9NgK58Kn1IH2L" +
            "Cmdgsm/tzaokdJsTxUwosU0qKejSIiuz4AmYjO9GGKg7kHrfOzMlnimVGVryj3bx" +
            "cnai+dizLICDQ/ztGGV6DxHKIXhtblf5PIVf4szoemtVks0mkHvoJBbUI784CVWo" +
            "+RQ0viTFsCbZsBKzTScY1ygVXZbdDMfgjQfixrXEeDpqn3a9JF8jV1q5d9EPedqF" +
            "c9GSF4fSQTiiYIYze3DqM+F+c8vK4ZPdrkRbhieKvg9bVkaqZsT+NP+Rm4goB+kp" +
            "ORodydz4JvO/wPJipaqj/vt0hK6/Z0oDkAQdmv6knL3N4GfRsQbvKuGSGISvscIn" +
            "SBWe3Cnvu4ZiX+O6IiOpa83q3DeKaT0pcOXs+VATHAiGM4/3lbAM0JDzbxw3vV62" +
            "BU3FEQlZO8W3obHS4leaQUEp7CUDlNcp4Px33Xhv4a8XgzveHgRWK5rTrroMqvlU" +
            "oeDMbJ7C9SWbuZ+baWnUB8bdMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
            "izANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
            "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
            "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
            "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
            "MjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYD" +
            "VQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkt" +
            "a3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZl" +
            "bG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEB" +
            "AQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P" +
            "3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W" +
            "+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5Lrs" +
            "dO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ9" +
            "40Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGB" +
            "rZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJ" +
            "BgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRw" +
            "Oi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcD" +
            "MEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUF" +
            "BwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUF" +
            "BwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNk" +
            "LmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYD" +
            "VR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg1" +
            "9YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgw" +
            "BgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQ" +
            "iZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J" +
            "1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe9" +
            "3bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d" +
            "+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7o" +
            "z/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQw" +
            "ggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQ" +
            "IEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEyMzEwOTIw" +
            "NTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0G" +
            "CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDiTKur3zCnwRjga19+Km8/2ZSk2Vja" +
            "05S9MnjIKzjF6G0WKN4IlOKPlC7c6v0SXUasNUmfDwxEl2CugfSKTl1Q4C2XR+iT" +
            "n9Widty+hYiv0RI8PnPhtkHzYafLz66v7ky/Vt6nSdMD13RAPiDvjE386jlB2UiG" +
            "mijPSZv1yHn2wSX6j5hlLJh8vIkbObOtw4+hQikU/a3KgRV4UpehMyXbGXCJ2Ej9" +
            "NFfsogwagSsUfp1zmeMbJciLZ1h8Bv8EiymZ+qEisZC9Lj4okOgym0POGMXJhkgS" +
            "HARSLfYqhOlH3UFMhaLOHnEQIPKQcPQqSSB8EhAh4tzyqPfTSFRTYmhFAgMBAAEw" +
            "DQYJKoZIhvcNAQEFBQADggEBALaKacNyxLBxf1xa/Y/Q20xzRsFmAaJzvHDfvKg7" +
            "ALcYqjcWU8CVFNYjuxIHM8/Lk3d2TDlE//hj2zIJue7n6Q6PBfyFylPmURVxfGq1" +
            "RkumjYjLUUwh4PqRcCPiRFHq8HIlryK1iy7ZnS+kMOzmqas8Z3Ww3zyEKVolDwVL" +
            "UfFBfp9exVQ/q9Gqy7g7Zh/PF2h4eUmkjmqAlQBay5ITgmVlCug0zAlbxauwzYNf" +
            "KUzWDvjEmgqDkPLGPgHpxbNt9Bb8YqAHRkGThtbTZjCxwSPZZz/82ziTSXjocgvv" +
            "YkZF1NGQwdwF5Wrv+uxgvz3GhgStHhCN/HTa0vsS8EoWhm4="
        Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(Microsoft.ApplicationInsights.WindowsCollectors.Metadata Or Microsoft.ApplicationInsights.WindowsCollectors.Session)
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used such as when the application is launched to open a specific file.
    ''' </summary>
    ''' <param name="e">Details about the launch request and process.</param>
    Protected Overrides Sub OnLaunched(e As LaunchActivatedEventArgs)
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

        If e.PrelaunchActivated = False Then
            If rootFrame.Content Is Nothing Then
                ' When the navigation stack isn't restored navigate to the first page,
                ' configuring the new page by passing required information as a navigation
                ' parameter
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
            End If
            ' Ensure the current window is active
            Window.Current.Activate()
        End If
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
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        'TODO: Save application state and stop any background activity
        deferral.Complete()
    End Sub
End Class