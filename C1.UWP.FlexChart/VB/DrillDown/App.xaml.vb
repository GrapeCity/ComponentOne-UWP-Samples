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
            "ABoBGgIaB3NEAHIAaQBsAGwARABvAHcAbgAmlwOZxnOcmc6HgIl9nFd6c76vwT8y" +
            "XUN2S192qNpKb7H28GAkaI84lwkxlbs42N+1rxkbAktHYq/a+9f+PIU2IWrTQpbJ" +
            "v3tCGJEUxNPbEgJXLjMBgHBhmlGRyit0OW9BlSrBs1Vw9rznfQg8cpejwJIgWjKB" +
            "Yq6s3KcRTYLqLGvOUT3Apcc49p3Pz0QO35+IYLFOkmRmj5fkgV65vUllTGdYo0el" +
            "gr/tVFzwuW4lC06dHfmg5gnV66Y6SuJdWJPMy9aqVx2JQbcHQsloIDc3pAXpN7vx" +
            "UqcQWHFKz70gztb+miV5m6HotX0gf8CqY614nMZT2iA4yM/tPycCYxN4G/REcjvt" +
            "xS6XRToDWax3LF6nc/wjMkXWCoWs7dlUJkwycpzMwjAINJAw+FSru+PzhNmpd244" +
            "AW6RZbPMnD/Trvru7zo81lix6vZ5hx3j7n5OHkFoyoEh69aAHeyVJSYZj2v15+cm" +
            "alQW3qygZSuS1fydnZBUyMtWhsKhIgKwqYQCgX7Gq407Ae4gDlksmaAnKqIRtexo" +
            "IcUBOlM0t25cQ97jnEYUzhO+NIN1SycQlQ4cZwSKELL0/nygIqHkxrSzS7iD2H9l" +
            "NrcKGzOZwChZseJfF7mxexjYoBpqIezXSTEMLRoLIDmcP2AsE8F6w8Jr4MewMaZX" +
            "3VFWu+/ZZSrTijCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIswDQYJKoZI" +
            "hvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2lnbiwgSW5j" +
            "LjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UECxMyVGVy" +
            "bXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEgKGMpMTAx" +
            "LjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIwMTAgQ0Ew" +
            "HhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UEBhMCSlAx" +
            "DzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1MRcwFQYD" +
            "VQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxvcG1lbnQx" +
            "FzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8A" +
            "MIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2a8COz96uanuluHwz" +
            "0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqel+u1w4HB" +
            "9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTuBCRv76ut" +
            "IFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB6Omp9qaI" +
            "c2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjvi9rBga2bDbDPD+Fz" +
            "CUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCCAYkwCQYDVR0TBAIw" +
            "ADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYaaHR0cDovL3NmLnN5" +
            "bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhFAQcXAzBMMCMGCCsG" +
            "AQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggrBgEFBQcCAjAZDBdo" +
            "dHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggrBgEFBQcDAzBXBggr" +
            "BgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5jb20wJgYI" +
            "KwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0MB8GA1UdIwQYMBaA" +
            "FM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWEEqgsBQ74" +
            "VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYBAQABAf8w" +
            "DQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImYvriarF1i" +
            "/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+VOkeCdfww8m4qkMG" +
            "yTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2zKpyaPb3R" +
            "+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgozU1v6w30" +
            "mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4kCpXxoqU" +
            "EkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAwggLEMIIBrKADAgEC" +
            "AgQO7u7uMA0GCSqGSIb3DQEBBQUAMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5h" +
            "bCBEZXZlbG9wZXIwHhcNMTcwNjEyMTQwNjQ1WhcNMzcwNjEyMTQwNjQ1WjAkMSIw" +
            "IAYDVQQDDBlHQy1VV1AgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkqhkiG9w0B" +
            "AQEFAAOCAQ8AMIIBCgKCAQEAkgVF/aCa84tH1lI4gEa7Qgp77xnad0YkP4mmdYAM" +
            "CfTl61lSPJNhGtEpvA60s4giwn0qUVkY6QSEsMJ138hKr+vvdqKEyLsXmybNF6nZ" +
            "2BT3i/2Bk1CrzW/4BhHy0+tDE/u598Vy8U1u71+u8Q/8N9K42WdOFPqXjh9Gno7C" +
            "lhLSDNEWVfOrXZOUGM6Kj0LDfgDPJQAO5dPS6Af1nzjxijuxkXg63YJ2+s9t2ME9" +
            "aT+j9L4N3SdcCiqMbaMo1adXJmsOejkdOwG5H8Iyg+S3YwP1BAj1xUk777276W0z" +
            "oi0uwcs+VwobBLQJVi1NQAQefrHmt98fGS4ZFQk7p84J4wIDAQABMA0GCSqGSIb3" +
            "DQEBBQUAA4IBAQBthq3vPlkQ0HuaO2Z2oBiRQn+3g0mILPVM6yHw4gl48M0JkdcW" +
            "9iEprKA79O6Oq5jIT3DG7jq4uz5WZ2cdkIOY1MfKBF7K3moKTzMPHTfW+py/9aRo" +
            "T/zgWsCLqNJ3OeGs++3M3rFXbUI+JscSCnmj7IJUsOKqiseQyti/FlWZSLAn/VEq" +
            "Wo92RKoo3BozqIWiB5zPSZMrGiTsf88+LsRwdddCMFyhyS9e2a76frKsV4I4R6hI" +
            "fucjXqBCkofcHdvqDPznISdmE/Eyk5GEOTy/Hq57EqRCc7/pbOtSto8jzaTxbA+k" +
            "GHCgyRXmEP+wyYg+w0KmbOpoODaRE7R990Xn"
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