Imports CalendarSamples.Common

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
            "ACYBJgImB39DAGEAbABlAG4AZABhAHIAUwBhAG0AcABsAGUAcwBg5K3djD5Di26Y" +
            "F3wm8VPB/Dc11x9Tm2pR0ron1rhZwBJ8oyzv4F9HYobOprsz0Tw6WuS4hG570nXZ" +
            "WB9YO1sLBIGd9oFyRXy5NvnBvPsoxquQgVRfBnqnu3N8KdzQDbCZWTP352zpXKUv" +
            "+hHSueXviFMGuQGTVPf4TU1LCdJ+nCQjFak3S4i2TUS3CyE32S0t42mV7phX2uek" +
            "2lKDcSVm3B7QR/jtkUrTkYvgUgLJY21jtHvy6txI7/wLUYfk5D9IdI/3r2asVNhh" +
            "PRmKnrH8NX3IJRa32CG6vQja3OcqSRD3qXfGnjULUdeWMzm+vY8HSMXwvn3iH/ic" +
            "6MeQfFIfGlVOCptWVbDriW18XIXdvO9Qp19VV5cXB73bstxT+kRJ3VkPf3xJ4H5I" +
            "NFJOA77FRkq5psIyIDfQApowVOemBLPE2GXTfOIE0XkE0SF3Olt9G5SwXhnePE/F" +
            "Ne5PRA9mWMSI0PG2hTBDk7HVihJEd0Ju2L91Vnv6mIsBS9r/8qYPAdHActr9prHo" +
            "T1NHgQbAPXWN/Dd42K40qRnY1wC61Cz41nSsehFUVF/vgB9CHkHZj91GplEOk1nw" +
            "LrytxlrL0OnfDQCImDycL8AWsWXsoAKCwTxJmESDK6Ws/ZtRR5JTXCoJqgcNfq2s" +
            "p6QJBr5SL7tLtB3+7JxH/lOsWRsuGzCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
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
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtqYvB/ehmJn9ZN67DLbO2r42" +
            "x7RDxjY2BBge74LdN2jI+5ZyBSe2mUV3GbG4E4sqxNp0KK4pHHHxSTTIPq87vDjm" +
            "L6Cp59NyTC+IgpmhQOeaREbOoV5eyUZAy3cJNhdekhLMn3lxbRyNCIMWc7oRHwgM" +
            "HOx3r4zF4cAJkqvQ7zxDagpkHBYgHhXiKn/btEMNw7jLk3OoPF2ljxT6cPMGzDyh" +
            "uKLIosPOegWHqEMXPfTtMLX0CixqKLzfeKLlKyHu1jZHeId1WgVaRA0eJsfxBRE6" +
            "URiBQ5MARGHzjIe0qG7vwNFdcqVNx0laQ4WZ5tFh+Tuu3n/CmNVcqz1c0H1YuQID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQArbZgqxuR/gmkX5H0yxO1WrCRZIPLmRVt9" +
            "qZYRvB3eRh/9lasHkmyrhLcKk0kaonDTPBbMeohE4zaUz3mGnIHYDSbOucBmrCP4" +
            "H3tOhS8qJ0muR90vHP1JGWmTy/n3FEYdJ6018bCBqDJmzukU8YUBQzybWYOhmOiF" +
            "72vOWYcrUuB8bwBSkbAPg28SoVY7le7PQFTMU0QxPx7jv0KcLno/9kuo4wGmcnc3" +
            "1JWL+99g+jlVmEeMqLUCzjllvZAmmweADcWqDuYSJmpAp/K6wRD8A72DxY0QN/Mf" +
            "Oq9JZQ9oEph4gLNWDRZHq4qCRlyJPxfSr01xr66i3zSuJxa7xP/Q"
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
