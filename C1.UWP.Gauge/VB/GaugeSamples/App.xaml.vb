Imports GaugeSamples.Common

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
            "ACABIAIgB3lHAGEAdQBnAGUAUwBhAG0AcABsAGUAcwCQFRj7E8DKJfOYYN0HCHJ+" +
            "wSU2PCoxg5wYl1JvAKF1a5ZwIi1q8Og+L6L+2L1B2IaXybsVhmtIo4AeneOraNZm" +
            "lOqr6ZnQviv01MUdMlDKhgSqagfMnVQstgIHFQjG9fVDcK00puLfq0oOLmHCVMLo" +
            "wNdww1kywD2magOhKmqCaEfnGFAbS0T/Qx1fYZrJF2a109DNMiHXnrAvd861a7p9" +
            "XAk976nljKZi6lyeO+D+uk0XTxcOcdVqTE69/i94TlepWlZsLtDM9TExQKLBQcYc" +
            "PMHc55D9UkDUqJUAI5Xpv5RVNSSJzRJnJ/Q205hDjVme6IKwhduhs/iXmvdVx+Et" +
            "jk3/OtvBF2Hqy68EjU+unCRfn6CizSyoNKQCvlcbXF8IFN2EB0YUS2XAdkh6Rs/I" +
            "Hk+lyEQS0b72p5sPyWmwmD34gMSYKF9gjqFVTJhtoWaNJBpqNgyWZzvo3IjqV/hM" +
            "pbPLyM79LjinubLgXY5TtUNIFMJn2M1qNK+PRxNrMvWhGLQjReXCezQxCz8zFpx4" +
            "qOaDEzbSeSRlSx1i0R+6l5WMlGvYJRoO8MX3dU0VqzyGMgibeho2whYdp90onhhS" +
            "5rgWfaL0v16uRT9uiLckVNlg5CPlGEYhbZHSUCOtB36Opc8isokr6zTnIdgFO6wY" +
            "m7f8VjPesaPQChSmCqDgGTCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
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
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlVCpP45o01jQyg7nQ1ug6VlnJ2+FpNPQ" +
            "Eyyp6bvb+voT212GAA6OECDev/0CzJwOOppLKF1V6FLbcbBMCB834an6lF9spCEN" +
            "bqo0QJdE0myCJjftWZEz21O0/gb5CKtycGDP4jL4Y0tJ+mJxsIHM9cWVp2qkWI9Y" +
            "DRBT+3slRllAIeTa9lHIwofM9992y2U8Ub48FIhk9KEBQ8Q2Pk+r5lAXVrP8uB1d" +
            "XkX3nEK+USy25mfA4yvrpEukAqYiyw4ErqZlp5bBVEH1nhE1e3T6Ot1f79MQW3N7" +
            "vfrLaszQBUBd4wvFAQfSk2tW5s8n9eG5y88oZe7MQmZW22nuyDAM3wIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQBsI8rVUi89l0SNL6ren+Gw+UsPC7OzmL04rARkTAO2" +
            "lpTnBXQ9IokzUve4DgNwZZyS8Ot8cL6YcvOFvpwawcNlqT+WSWqBwcgzJfi5FHrz" +
            "yeFHds1PAa9lMmIOrPeZ4UFkkWuY3J9ZuXyOi4yRzoUWeV4EKZFRsQe7Gp+WPxbR" +
            "AWZU5asvgOxUqvy9jcZHH5J5J7SwinMaWhXEqAAHMikAkTcpjLiiwke83WrxrAqM" +
            "qtKSjkj4NPDuRxCWcqcuL5ASStxSFEBmKNhg7DADVbCaKNU25mcG3dFDvHWceaDd" +
            "pOEz0Iu/Vng9z+hosNGONbIp/0Rk34L8Lm7S29i9JPYq"
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
