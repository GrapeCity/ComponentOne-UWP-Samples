Imports ExcelSamples.Common

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
            "ACABIAIgB3lFAHgAYwBlAGwAUwBhAG0AcABsAGUAcwB7OHFa4KUFJnk2sYeT4xsW" +
            "qqqwDJkgOvUCDVrUYDZIiGi2Ha7SktpsmKY16dvx1VWXHRvP9GF9DE7ENWQDfXMs" +
            "g/MvWEx0/anyF60o7nup1kll1zrdCEhd3QDE2uov+J7lxCR3APVico7np0STLQFX" +
            "4oQRHBY9nKik2Wm01CLSjX8pHBtiIDDehkgDf95MDAvBYDZXWdrRTwkb3ZmZNVgu" +
            "k3zY3tqbg7Mfb9FnnJd99ry5pKUOabir5+uFOzV2jNEUcmok27/8w5F7QtkTofCU" +
            "yFG9A1xbE6POIqitLKg1MbGwkgB/Y4YIFcuv8zXp99B74QT2/6sExW2dLoqmhK/3" +
            "PKdp+I6JKhFuwt8WErZ+QrLY1oc7gASj5oVp6q9bW/sNMW6WioTOCvutxZpFS1qQ" +
            "bM2dPTVM82q0O5zyCXmlwqIg8A5IgHStrbLeZL4L+07EUS2IkBMqMO51/65w2sy/" +
            "Y1cItc+YytVqiEPm92lS69MdBcg3jZ17urEWwp3UGsSNcU4YDU7XB5X6/KqibkrE" +
            "GM0B6OBBrJi7e9Mt1CVPkTdA/0FZI/9h5Rj014SZy5mPVo4TI6rnWTSP+/t17oC0" +
            "xvrRQdsnONVcxL4Pblb+PD3mb3Ny1lBcyHP4ywMVexqoAnv3NZGRI3jWUcVCgG9I" +
            "6gfQxIe6YuRqb5xglj9rTTCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
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
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAusl+7mDMtXCLdDfHUwFqrfYd2CV21A4C" +
            "czQWTagwybz4yqHWcPT1ODOC0Pcxvhj9hwhNA8fQ2x8hj80yaq0RQIc66OFYBLY4" +
            "/WvVihL3m3zMQUOdxYM2mxqKnxiKyqHv6yHCxEtpV57hkoiGfsqGct3pGXREBcI3" +
            "N3mxlyzJcaObtFF0SGzmGWYxu6zcWB2t4J/LB1eBY6Ff5E3YeSs81JrcVRCkoFJ3" +
            "DQKtFgOtWF0cELxwMFrnZsuQ2/s6MnW+4BN4FRiBdz1hetS0leTt/xkZLnPOjHHW" +
            "IdNZTpfasQIwP8YT1D/GFhS246nxFunkl9WKn+yUDW17VCMZB2cbbQIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQCqAugWT97sDiVrt5J7OoyTetdYkdxd/qJn9ZRXLONp" +
            "w/Xmq4A+Tacm3jKt135liddQLOk15Sgt/kqoMxVn/O8Zvy/4O+ktfWGk00+CT/Az" +
            "oSSyfpf5DLjJI9P2EfmODYOd2HIXtyMKwdxfigWnWHoh4FzjnsRhoxaqKRP4t+56" +
            "oJheboc/tEW7AQtGCPv7ZpxATCfDGqkG1HXW/w5+LdQ320nP6XVxGFcQwy/oArnU" +
            "T+pWg4EIsAZaS/8OkpJgz3f1q3NnTlox1Tt/73ka8H4RLXGZUjginwsYQ/ZFqrn/" +
            "/J7LRMJ/C5BKkJPes9XSZ/geqN0zCjDgkLi+ecVTHMzX"
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
