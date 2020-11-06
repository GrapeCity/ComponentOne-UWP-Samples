Imports FlexGridSamples.Common

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
            "ACYBJgImB39GAGwAZQB4AEcAcgBpAGQAUwBhAG0AcABsAGUAcwCdTsOpj3gorVWi" +
            "14fxQi75I1EAKD9xG2/4MY4JCymOxWeiqQHBxSfLfhTkn8AS1uJ26ohOyJnSKMSg" +
            "C23uypJ9gAbWtlS7JyrjZQHP/MNOe81ln8GZil9/x/aLrdp6mrC7xMKd995qCar8" +
            "0T6SQWyOzaS1OIFJeTV9oPFOYqCTwYhora0OPKLcDn4RwLwLbFkBqLT1OmJZ62JW" +
            "yyHoEgKhIwcfM7YCQ0WIeTqGR1IXWwciUrs5zwJa9NXCxGF2SEmuKMWdEsnzwFND" +
            "8BMHMgHjeaC/s2fs7NF0nXQznN76/ClWsXyqDy2ScGyMfFL7DwUCVcyMe3/S6Xbg" +
            "8zNwTCbycMAajJ3ooml3P6l7urEg8XHzJrKnfs5unk2axrI0Tsx7ISyDhJEZ3Pvi" +
            "pWFO6a2H4K3hkEoxtHr48KVFSoeyVp0bgweKRfAOL8ZKM2MnVB5istataXSPMzoP" +
            "xZPPCiyDhqaUORlWnseheloe5RI/cPP5wCyzT6GMFEMALEZwFgeDp5cY36RY1cgW" +
            "kgRfbOSB55Ki7VB28GobEXWRCYczK1lT7DufjK9JPSdQ1abR/ubdvGALNQv1xLWg" +
            "blRTQBAJ3zjWBEmElTYj9Ixvf5j12ch3FIOmF++Annn50qETFqI05dmbuCG2r/XJ" +
            "Fx0fvmQ8VkG8ckI7bceXdY6AWY+z6TCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsm" +
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
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAyiHu4KzzvbUks9SragXwnfgQ" +
            "KH3UiCBB+LIuM8XGsHlEQqD9dYto58Tx0umGJWhCFif03zVuTmggwq9ArGqEfn6j" +
            "4Qo61FieVRtJGJwBIylcqlEB8mVNwuf1Qy+rn8t5BID4cUx1fl5cb2hr+kDIDcpV" +
            "yVh8ezzn0zZZJIHt6EX1QIRHqYQ6BoKgotGgwKwkMDLJwloS4Odv8oyjhnC7xWlj" +
            "osJZPt1MA6EfMw/tJpF1oBNUbHvoTxLbllJxwnKgvav2zDCvjMWBvS4QJBK9MT7S" +
            "HggzBC7oG2EPSYKEIRqqfmjIqwVEwIALgOnlgP6eYh1Xj2VXa0SsS6whRTReHQID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQBxvySCfW+m89Uv6Hwo4q4xj6/Zsw84q0Eh" +
            "l7Bk/LONU3ersJvaoomOR4/n9px+V+OtpE2bEYMcb8bX3FrQ7G/Ngh5rhkqH4imC" +
            "Vpo2VF781qEqoLy/iLHJMm6EqrlSxeFhvNdzc5Bwy+YNt9HE0aK6GiE45ZDOs4Fd" +
            "T0JBvBozB6GhzUdGu5WI00QNqjZblZUpvuNnzg9+CpcP6Z3r4dJcVBHWsL7SXqPV" +
            "zyyeLc9pk3DfMs4I5MkC5n8Liv0mThD7r6aV465YmdPdolfm6wmEkdK83elVyULS" +
            "iojfDAEO8EgltcP7yQPCigZR36mbXH6UTS5UW7f7fPMvo/HxuEsx"
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
