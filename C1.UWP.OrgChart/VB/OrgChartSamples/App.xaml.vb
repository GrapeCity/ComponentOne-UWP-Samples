Imports OrgChartSamples.Common

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
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
        C1.UWP.LicenseManager.Key =
            "ACYBJgImB39PAHIAZwBDAGgAYQByAHQAUwBhAG0AcABsAGUAcwAos+v8AAWq36KB" +
            "56TVYCKk7H86agVdxHnfz2L49eLdsPflcKeQQ/raviPSMcNwpb7rqM1IcwR80/Af" +
            "8RyO0BJdMkxbkoVxJ28IeBCXoKxhzEzRhz01q0OPDKawDon7kW5r6kBvwKMDKZS+" +
            "l5yIe66m9Tj/+EIC0uJoGJytwefj1sbFgyRkeqSUiSKYZfxhpyqSU7P+RwiRr86N" +
            "oLfa8sq8LL8aAQsvrc01RuXMcHNZdB6+31KcWzQBXY3ktIGfpbBZ4//cdpQUs8Y0" +
            "LTqruet/2iL2J1en5W7g7WS+JdMx133lJztuNf45IELASn5RWAKp1DnjaOh4xEvw" +
            "wgweEtWBayzWXZjQJIwNSf074aFx6WNZZ90RUbJ3HJBlMRMf2DoFu/vtjzMoJtAl" +
            "ovJtzsS0aVWOf6DBKOacgufGRFkGZfhpNoJ8R2MLaIY/5PCHI3ICWdfK7msNTKFl" +
            "LD2avc9tDx/PmAUpyqSweQVQBlwb9bW36ipp/u5DWdd+6AH5H3bRY1jjplkTvyH3" +
            "Vpl9RXieaxNgKBF2megKbDv+zbH0g6xFh8NFU+KyUKMMIxCeqnLyzXooz9wloemL" +
            "RBCPh5phR2/Epzx1rqeP9inPdgqUHy3l2hUI911jDG+2pYAg4uZXEPKoFjLg5cxM" +
            "crtQssdoM2R2nCcCLbeM9AnfUUC+PTCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
            "xr0QlIswDQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5W" +
            "ZXJpU2lnbiwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7" +
            "MDkGA1UECxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNv" +
            "bS9ycGEgKGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWdu" +
            "aW5nIDIwMTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjEL" +
            "MAkGA1UEBhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6" +
            "dW1pLWt1MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMg" +
            "RGV2ZWxvcG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG" +
            "9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2" +
            "a8COz96uanuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5Gx" +
            "DjO9Fvqel+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4" +
            "TeS67HTuBCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOve" +
            "v/AifeNB6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjv" +
            "i9rBga2bDbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCC" +
            "AYkwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYa" +
            "aHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhF" +
            "AQcXAzBMMCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggr" +
            "BgEFBQcCAjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggr" +
            "BgEFBQcDAzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5z" +
            "eW1jZC5jb20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0" +
            "MB8GA1UdIwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCt" +
            "pdR4NfWEEqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIB" +
            "GwQIMAYBAQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV" +
            "6oyE0ImYvriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+" +
            "VOkeCdfww8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+P" +
            "bjCHvd2zKpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst" +
            "0Q7tXfgozU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETm" +
            "wuWe6M/4kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAw" +
            "ggLEMIIBrKADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdD" +
            "LVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMDkyMDU2WhcNMzcxMjMx" +
            "MDkyMDU2WjAkMSIwIAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIB" +
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnDApOeNnPzdhWk+q4KqsXwrw" +
            "wS1Tx4ZDsLkxnGeq3HxcFK7DzzCpgeNkuUTMPQJJFDqZ53I+HQv1701AMUUFjuEI" +
            "wv90HJPAUAlgitHmUvAb8Wy9tZyrTYZ68hBzRrxcogajHS6U57QUchQ95BcrNMEL" +
            "X+PE8BOOMfi3hiqphlZJCV9U1RjhDYXI7tuaV52+2nNzp++jQ8cdO5MvhjxGh5NT" +
            "txSyZvtUjkYhh///mQXNS7cBOXxlnU9V2m8lr6b4+lj3VtBJZCTtFaTmmFogCL8P" +
            "WzymMwmA0AumC8z2EPlqLKQPbDKbdbwj2QCK6SLulHfmsi8q+VVvSZfEVqR5HwID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQAsGpc2ep/n5cVw8BA5V57r4qMLAcWSwEoM" +
            "dEL7XG5tC/k3dO9jEQbxUittuBlWMzkQiLubR4Z4alAINDOiTy4RBGod6xMUjv/q" +
            "eaWSqTlk+21Efca6BB3D6C6sTr0ktNCNxJpWXONbgeBYXVnY5iR9l5zGQYZBaTDK" +
            "FOlxSToZmN0FSDL1PDgn+sMinjGDm8khoMFb9g6vgkRmpKHWCz1Z7X2Ku+cQTrtM" +
            "QAaMs0rxu8V+Z8RVxM1iUPfKOkr8YQSPtusX/hJsvg01v5jK44UbHelTf6ZHOKCS" +
            "RL8F7s6C4x+DQRIjrSEHYoruf0DiUpGkmEH3qLV4w55Hlu4dTa+v"
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
    End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Private Async Sub OnSuspending(sender As Object, e As SuspendingEventArgs)
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        Await SuspensionManager.SaveAsync()
        deferral.Complete()
    End Sub
End Class
