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
            "ACwBLAIsB4VDAHUAcgByAGUAbgBjAHkAQwBvAG0AcABhAHIAaQBzAG8AbgBWjL7P" +
            "H6mD6oVTfl3F6j2SUTfn4Go+CGxgit+X8GdeBPpo5DbbgO2qpQuVgAllxGJapt4W" +
            "MG6tVFqoLpyezJ8PQ85Thvf/HFwCeEo04GOUNG3TOid35bDaKEZtR7WaMQma58C1" +
            "u5lPi2WUWBdf46edbibr+750z6uQUm1EvKgobaak21SZVKEUXdClStlQQLt45ZE1" +
            "A85I4a2E+fBYabiA5Xl9Nxgqd0RaDm2fu7F9oS8FK+uZe36+y1PLeKus3YUzyGvQ" +
            "66zwrPajbz8xgLepsMprpDvcl8ybIaYZ4twE/rfeVv/gtivDVzab6Ll9sJwu9YpB" +
            "s9DucsRwVG0F6klaEY5DjDSbCn24c3FES2ZFyfLAInrzAlJBMeLEscv5NfKMBrIm" +
            "SoiPOyF1OFGcmBPUWPEHCaSxfHbapRoDjT5qrmA7ATEgpBaQWGGwpGhaRLwhpNPf" +
            "LRavenvkFAgTCrfQ02CsfYiqfpPTLu3i/8Y1Bl6Zg/ccq3t0gZGZ++m5yVWgeaqr" +
            "ngXbmBCTkZO/XyghD2kegiza7MU3aT4l68hbMbztCKzsuT+TjFxRIBmxbl8xGPMj" +
            "/EQ74x4eABTJXZsW2MWJw4hcom0g178W3cCIV1s9l4hqcU/zS360XdrN6Ubb6T0I" +
            "piae/5aFzkazcDpAg8wFcoKqpCTQxdKRT/ZbizCCBVUwggQ9oAMCAQICEEEDeNIm" +
            "Nll6Ftsmxr0QlIswDQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYD" +
            "VQQKEw5WZXJpU2lnbiwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0" +
            "d29yazE7MDkGA1UECxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlz" +
            "aWduLmNvbS9ycGEgKGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29k" +
            "ZSBTaWduaW5nIDIwMTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5" +
            "WjCBhjELMAkGA1UEBhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2Vu" +
            "ZGFpIEl6dW1pLWt1MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQR" +
            "VG9vbHMgRGV2ZWxvcG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjAN" +
            "BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rr" +
            "THvwdlY2a8COz96uanuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zo" +
            "KV2pt5GxDjO9Fvqel+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq" +
            "9Fu7cgs4TeS67HTuBCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0i" +
            "gM0rKOvev/AifeNB6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5" +
            "xr9xsWjvi9rBga2bDbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQAB" +
            "o4IBjTCCAYkwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAg" +
            "oB6gHIYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtg" +
            "hkgBhvhFAQcXAzBMMCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2Nw" +
            "czAlBggrBgEFBQcCAjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUE" +
            "DDAKBggrBgEFBQcDAzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6" +
            "Ly9zZi5zeW1jZC5jb20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20v" +
            "c2YuY3J0MB8GA1UdIwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQW" +
            "BBQAWvCtpdR4NfWEEqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYB" +
            "BAGCNwIBGwQIMAYBAQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqx" +
            "F8IDqFtV6oyE0ImYvriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8Ynnllfi" +
            "xmWqjF5+VOkeCdfww8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8n" +
            "pNNIVy+PbjCHvd2zKpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6B" +
            "z0qeDIst0Q7tXfgozU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpM" +
            "GlfCwETmwuWe6M/4kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68uc" +
            "xiKomuAwggLEMIIBrKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNV" +
            "BAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcN" +
            "MzcxMjMxMDkyMDU2WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxv" +
            "cGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAzYeytsrQm7CVx5KT" +
            "nYSmJL2xGDb7Y20/HHdQCsOvgB8i0S2g6Sd0nbJi2V2ONR/roge3JECQ6YAgZXeg" +
            "JYOWsBpvrQ+Dg0ZSYqpQpovSU8Bo4gISstf/E/l9nvVn9z2KE/dguT2lfBaP37De" +
            "jKK/rgj1xBqHIVH/8gXNtffbb1MW/bdMzbySC1KSNXrmZMSuP9yc9GyNiZLzoB+b" +
            "iycY604H9s7KnqIB9Gx7H7o21OfFy2FbMt3EXj1gopQ0zRv8LJpTOA1Rkrh7MQbL" +
            "WIW+OPk780jxEI7NNry8RiPKAa74E04WW2zt2SAzXWesSvhxoDUHE+1S9RKs68Ep" +
            "0HEiPwIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCSUKWv5Yw6BH/0V1kBtGN28oSO" +
            "N7yfPaeeAJAGNUApyRi8fanSp7cT+iX8kf83D9NxZQTZ1ndhgSr5AYTLq2Tw+Ldb" +
            "+h/3HhhOFH/7wX+c6ZpYYV9kfVVmgHgofE1BFdaSY/VTGJQlgTXOaes9iLdyIxkH" +
            "+zVNb6kHEiPnoCKnOl9Jvdp7nrX/+KpfPgRG+yLJbjFuGOV6tETuRu+zOFmQZ/pj" +
            "5Xy70nH9Sg6EKKkI4yW9xypr7kg9spZ/MITJMOeTzhQg+5StEiZgNqQznhG6msky" +
            "KBtmAfspdVqGILa1JdUEalRqp7D8KcLVaErYa3o4x+HZn0KyCAdYk2ItCtx1"
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
                rootFrame.Navigate(GetType(CurrencyComparisonDemo), e.Arguments)
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