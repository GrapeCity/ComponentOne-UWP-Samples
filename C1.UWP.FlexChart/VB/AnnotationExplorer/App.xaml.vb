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
Imports AnnotationExplorer.Common

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
            "ACwBLAIsB4VBAG4AbgBvAHQAYQB0AGkAbwBuAEUAeABwAGwAbwByAGUAcgCMZ5m5" +
            "Hj3iPIhGrO6RV0BMFmSrF0ZS2e5nsXLvzF7m6BSuQcCJpBY3eFzvSgkCm0qZLRcE" +
            "v+6P4Vs1HL2/bYeVfpmBJZtIXn0U5xSVI2oBtVP8AkUWGpuO4DB24WiE+UhpteRh" +
            "EvczWUbmt0YiLkFcULKXLCOkE7f8BO8/lvsZs2QcaPEv0vSq5yaQrkaQPo2rvDz9" +
            "aGJu8uXpIx/JXU56YGoCJyFJ2fv4iMVwHdSbtIaIP2sR4fOH/14Y5PAhTdwMZx5o" +
            "V8DX6Gi18fltBfzgIQP5FRWX3aBauZ8EIQ5eUTqZLdCo+f3WlyuQgZj1joLtWc3N" +
            "oC9TIZVsZst7RJStHVy7DnWK+6XzIvHRHFdMB6TnpXU5Hp/0aG77swUE9nJUFcIi" +
            "UFa9+FCevLSC00nJ6uDj/JBMtl+iF+w+PrYLkUaAdcgXJZ0Ij/r1QIaeTlyLetl9" +
            "ZHikQaKtcTAZEDBcoFqMwUbrq4arwr3XB5Aa0SelEg8nHHUc4Sb1cZB9tX6uouio" +
            "/AapMHiXp9NdXRGIDv3LIspsZLEc9YljRwdeG3TQQPx68ACKgck3cO8DkPN6ZIj9" +
            "lehZ17o1qFhtJePi/AlsVMRDivdygariiwPTmRtVuQ7w4UaVUqrWh9705ilLZMxr" +
            "Mush1TxIB8abhl3Wo82rXBeAk7f5Ebc8DjaqRzCCBVUwggQ9oAMCAQICEEEDeNIm" +
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
            "cGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnryy9bNRLtuNe//i" +
            "0jOinxnuYFG4ivvgJqEEDr1iSbagxXWwJzAuxlrbZo1b0Nww9x98PHzsv/KWsH/3" +
            "Y/1dGAFcIm7mwCrIVad0IUWRqr02MD8sk0qyO9eDI9LOHDHlpmXeJk9rgK/kFwY4" +
            "PaxyxQeSs1PO7fT7VvrKXpJ2BQUlZx/3JgcHSLcMCfcmP4Ak9D5MG068/v3yCcHe" +
            "XKwV/XHz3PbQN5wOxEI11h2nXjq7iW9y90nXcyVUaGV3zx8/Kz4fhYB8rHfnxucC" +
            "85hbEqRIrwtMG7ZBWD4MJQiw0Q8aGmQbfDRgAIhE1zFIMVzlepI/FzZwmRZIpHr6" +
            "bEcywQIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCXz0gscefIZkRF9kwUTGVekVDC" +
            "/QONKjMXkapK4ZoGSL1ncuUIrxAu7yn4oCuUv+UmUDW0DGJkRAILmInRFhjawaOE" +
            "NAZxun85+QJ2scvLxu4/fbUjpZJIjEexsWnJ17500P5afZrfWjthsGg00R/no/xs" +
            "P9b/3n6DKdrtlk1ngyNgNuLhKLW0FLmEWwkIrA0aOfXq3uOqnaMe0f/JOeISzBrA" +
            "8UvKwjwSMDngpLUDd5CuQ2ybgUtdL5OvHtlZTc0FJsGcOGzqQXiNu6Ns5fCmLmZK" +
            "rb8aCi4yl8l5zRvzpLb8gpUMTaJ8YCO3EKtbbS2Q5UsTEqKoEBAYZbrzhhmP"
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used such as when the application is launched to open a specific file.
    ''' </summary>
    ''' <param name="e">Details about the launch request and process.</param>
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
    End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Private Async Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        Await SuspensionManager.SaveAsync()
        deferral.Complete()
    End Sub
End Class