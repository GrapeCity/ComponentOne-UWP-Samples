Imports RichTextBoxSamples.Common

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
            "ACwBLAIsB4VSAGkAYwBoAFQAZQB4AHQAQgBvAHgAUwBhAG0AcABsAGUAcwChYaYD" +
            "Qrx/GP66kJpt7CkUR2s2lKR1enQ5msXoS/+RMXkTl3wbq/zL3TLYEzxbrFUWrG7j" +
            "F2KpeptQkqtUUenkvLaP95RmLPf+cbuLSQbJOFn8XFBEMRZCBGSD6NZS9wkKaqVB" +
            "LWAx0XuYZd7NOt98cyH+TojbrMsMNuMFfnlJC/SgPK+72jkro0UcFgPoIWSqqv71" +
            "SXx8wZexbO+EKClAmAgTETpiiw5au38hF185ozReC85jak9hD83hUY0RzodkmTki" +
            "4U8eZS0dg2dg3Rf+fYj747uumrmLeeq2M3yseKWU624JNurbnbpNlyCI/Js4YiUR" +
            "kUYrgdCzKE4Hh1cEJjW+jMmwHFSRvx6gsLbyPKNNLJfXomjlFb11dXfzNgZVZ32D" +
            "BC/7D45nGBxV+qShA0+QjIV4JG9fwFDY32SOBNJdCqgraEy8pmJpqOJVfRItQZPv" +
            "fSlW5bvGVdMJKWuWh9jg6UtFNZm+sBXU15JUr3wyiCciCyqLodcdE9XLyq5FTVYj" +
            "mjtsWwUkMsvNG3Zpt5WaVzjl7Y4hi6tJ/JrC654r+UjWrHZ7FoHbymQD96GaGvII" +
            "s9C6U27mUnyLvnByyHEtLQvS7nGsQ6zlDmTVNNNbBYAdIq4iTx6/29J4jKTuEi7r" +
            "Eu+9p5TfTPFAvAeskQPIfy+wbiZPrUvdK2+13DCCBVUwggQ9oAMCAQICEEEDeNIm" +
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
            "cGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwMJ0gOKhgx74hETZ" +
            "/bITSqVo2Bw/atMt0vTbrYy2KDGEhmLNqL/YQYTbHcgRLBn8O5pJCa+IfSCq9y/3" +
            "yuX8136F8tnjnVwhF8JBK/IoaX8U2OCE7H92G8E0wK6FCvnZWWN84S+gBVOac+7R" +
            "+J9Fp/EqUpbhabkpC8Urvu2ckutCu/na5CFu6lVpE4/lXqy6uae5wIRDwzyEaha/" +
            "OMR7atSp66+pgfodeLkeJrfoLke2tAQsjJKNJ1MtpwrXTRz5+vXyKPGa3czogobe" +
            "zDnHsUT94ZzYJLOjAK+NakneJJ3LEfxzdqbvx/jnTFZsXv5aSlcu/N9mrikWSL73" +
            "ovg81wIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQBJpjeoqErTEfzemKZJAnjjU2Xu" +
            "kJv9HjS1usfpw6F+NSpGu6cvqfSnY42ZEsc35Lz0Qo7nmDEfrqE3C1EgJnhf9BoZ" +
            "akgRYI8cxeYtp66Ts/z39kc/pX8mghE7S1dfqEh7LyiRYEZ3Bp0szaOizg4Ckgei" +
            "QhD1qu58ZqTrhSlfZm48nlzsaoJdRuEiFQcrlwBtNuFWD4bimaEJwOsuoISc0MJc" +
            "GTwoJtxLCMx8aBSHEbsbRc05KkGo+2NQTlsIJ0Qldqlkp2aq8tEVdKnrJGFWPLUg" +
            "/c73WzicvpUrgYDxB1KTYWeFV6tU5erFj4NcDwHcJIE+lHFI8mifJJXDrh3J"
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
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
