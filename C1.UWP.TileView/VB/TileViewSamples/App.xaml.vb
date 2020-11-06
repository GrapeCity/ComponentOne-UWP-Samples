Imports TileViewSamples.Common

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
            "ACYBJgImB39UAGkAbABlAFYAaQBlAHcAUwBhAG0AcABsAGUAcwBm019luwz4l/8q" +
            "0dAhe+wPdDFcYkstlGtONodjZmNjvvrJ2c1GzMuuEGqRDB3QlREyo0I6HNZ/EY3k" +
            "oGzIR9MBBaaLaxgWxSs3k9Sl2iTuLfq5dtbUZoUfbdbtWhg7wk933RgTvWSPLEug" +
            "Rj3kD972Z4JMN1GN2WXyf5kngJO48zFv3feWcA8hrFsbLtNybH80uFdXSYnGLsKh" +
            "+uV6w8bK1/zU2aPBCc1EXR0S+9p7HPAhacettmUdRL6VA7xq87uUOJa6HbOKBfm6" +
            "MA/hb7PCCQDQt9YC3f0tTP5Q+QpKVGeu++qqkhOYhAZ/P8oZVre44Xnk6XH+bKcN" +
            "vvkRUAqFbbyCOkajpwB61kEDAywQDtNhG4CPDauwL02xatwf7mYuJCgOxeb6jBKQ" +
            "uVqF7Q6HpVxGBsK7aiac8qoBdjIv3YUbyHff7YbwhalvaNsA4doSOSn4PR/7ufrE" +
            "0ZewaBO3rEN5m/KcrQ8aZyJLD0mYNrJyq7AbmH+w7Bg/MZSxZ+9ZQSH7C0eJVJUq" +
            "CNI76laCdmLddF0vzHl691MX1RG55zi1SnYrcLR9iJczlxvIwJ8CUWuiw5cCnHTz" +
            "pDYyfqYHnHxhzDEO6ZMcwYDtGugT2yvx9IFC2KpR+AOxe4E8cwvBxVkweeQSEyD2" +
            "ixmF4syJnxLHJdUi35rSf5vdycghXTCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
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
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwAUHXu33JcJs/2hOZQ+P+3VL" +
            "481YGRdRzasuXneDSB3Dsancu2DntbPlv2HPDaNAUC39Uu3pJXnwmIp6vCybGstr" +
            "oldNp3vL3GABPxCdlvHIbiylLR/1X+rAHEvOQq/sNjq3W/0S1k4tHpCS8diFGQY6" +
            "fb6eQ6ZctGrI8M/ezCAvMrENKohQuU+sliJQwcfDixGI+ksOCKwrNf9g04qSmFtj" +
            "bTpgNZ2DmaRrtlxY+qRq7j9gANs9fj+6mz4n4ACYiToh8781QdzgVqHSpYNI2DFB" +
            "GQJPFZSPmwwG9QihbEgayLP27mUD+1DWfMX26Ljm0BR4FeY7KQP9hxmW5WYnaQID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQAVQKWfX+L+XlPRgcNeLY0Jcx6F5aezXUOi" +
            "SYpnD1rcHOCGaVcrhKIftv5O/D2yi1S/VK8e5l7xrYWTAd3wmYEijLk8NSqsLpyR" +
            "WHgex5sKDykHsHd0I14KymozAzHVN43czPm0d04x05phkTgauvlbbmiYqBQpGAbU" +
            "P6vObmFS1KaW1zXCGaA2A+OsI2eHohD4HCgbEKbh/PD0Fj7m4NseHtc6rqgunoTU" +
            "4wR4LteBcLkyMPgLrmrJk4XEA+hKX7/l/enJ7DAeicwkojbTyBRL8OCqTPRZRyxH" +
            "N2SVIYPMo47g5DJTZhYZ3RfTnh4RSr81WTw45ZLW2L7lyctcxKfl"
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
