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
            "ACABIAIgB3lXAGUAYQBsAHQAaABIAGUAYQBsAHQAaACimiCmndJrqPnwD6nblbPu" +
            "8LgmjDRPi7pFU+LrSTEVn3CVLVSdLmGa3ailq9lB0kTbsSLDE08xUvDYcpTZbfe3" +
            "y4naWC3PHTKahqc+tw9XBDfIX4xORsafAUoPTzWWzyl/Qd7eA6YOKB9mowc+9Lw4" +
            "5031t/vJB2vjSZ5uhf0t39Eap9rzKhJtvhIKuvg5U0uB9LqKyEVVyXRYB1+Hzgkf" +
            "Cu14QAgYTpix3loj0NpMG1Bkd2+cluq+Edhnc4llPH6+zQu0WPzqufR4u3zenVNl" +
            "+aRY4sAfmLGjINqZ8H10YyaoEyhZHJirOuKsD3bexfYkfbL0yOg29gB/yh6IAe35" +
            "B1o1MRkYKkf/0nxi5Rx3aNk5MsC+Vy76FSRTggASPgItiIgLPc8/bVjpxsxmBKss" +
            "yqkjuDg1eIA2q84VE5JiIv7YPApV/UUkXiZ0qCvZc6qorWJ0ExUkR2zzvPkEAuMy" +
            "qLTSVdIPJCaCMDOZCUf9jtNW1FrJRvIm0EHouoq2VtSJzq+Hl0xY8uVyLB4w8okO" +
            "S50Vp5xmZY3zJMaNPzpZIQ1Ih4YoFDLXTq6oazSC1CgfP9WLi2lzbEJSg/JboYzZ" +
            "gfCjMKlWNVw1BmLmzTJ9GnKBgjCicH5h8LCpB9+TnuXjNyJz6f8BP+TISJ3qudB9" +
            "4i7Mm4wD+kMLuqwIjTy68jCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
            "DQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2ln" +
            "biwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UE" +
            "CxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEg" +
            "KGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIw" +
            "MTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UE" +
            "BhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1" +
            "MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxv" +
            "cG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEF" +
            "AAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2a8COz96u" +
            "anuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqe" +
            "l+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTu" +
            "BCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB" +
            "6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjvi9rBga2b" +
            "DbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCCAYkwCQYD" +
            "VR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYaaHR0cDov" +
            "L3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhFAQcXAzBM" +
            "MCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggrBgEFBQcC" +
            "AjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggrBgEFBQcD" +
            "AzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5j" +
            "b20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0MB8GA1Ud" +
            "IwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWE" +
            "EqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYB" +
            "AQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImY" +
            "vriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+VOkeCdfw" +
            "w8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2z" +
            "KpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgo" +
            "zU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4" +
            "kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAwggLEMIIB" +
            "rKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdDLVVXUCBJ" +
            "bnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcNMzcxMjMxMDkyMDU2" +
            "WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkq" +
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAplwDaN88T7t8Sz8WPhwT5sB/WOpC+FMi" +
            "/DVB6D58LiSyCJab0hVntjM2bf5yLb49Kyx1mHjVagRaMDJnjAlxG0eCilXtiGNB" +
            "S1PhcMo2MoBl+eHxRABt2FkY6fj0Ri2Q9DMVceLdOSZ8NE1qUtFcmjiGPHY7gYFN" +
            "QJnwvyd9FKKVBdz9GdH1gmQP2zA2nBLdOzdS1naD6SD3yZ8LOTMuXwPnS4+ZH8wU" +
            "nBB6fh+nMM3A0b3lm+LpbyURtxjZ9YqqQsSpLNilR7u3lStj4hkiUAA/qo07lI8X" +
            "Aq/IGc34XeIJendch+0KTg6obQsurQZ5kqyHV9Guhf/k+0SGb2tgqwIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQCkgJZrdUG7GcYYn5RsZYIOsFNN/nXjVIvB71ij7VMe" +
            "5u/Fove9RIekhjs+ix7LeVzL9fs17Ld9ZF2erZFIDWiOOYezFIPSe1c8W3wNqfu/" +
            "qIyVt1ZCxfh9FyeUsn99UcOSsjtXyl+pS9J1NBywlEYVPKHjdZyZLQ9qM4bIiMgL" +
            "F2tw3+Arx7qBI/AeqTwZCv+jc9eFUrrFaVzAs9fis0BMg+mYey8juIDxl8zDwF/F" +
            "xQUBTGEmGu3eJOh+RFrxSUjkwRz8ONKzeG85EjDfdaQSOhUfBiWabI9Qg9GmyxHO" +
            "fCYv1/5gntGLh/R5sR+/KFKa3xUfx1rVGC2pH6p9hRFC"
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