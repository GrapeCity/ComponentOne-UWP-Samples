''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
NotInheritable Class App
    Inherits Application
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        C1.UWP.LicenseManager.Key =
            "ABwBHAIcB3VTAHQAbwBjAGsAQwBoAGEAcgB0AFAf80QJJAq+CHbLY+MyH06fGkn6" +
            "7dl0wykolll2i89zY120t6c/potuGQJ32asPOKWfGfHeRtMJ8RMDW8qwzBuMXD1F" +
            "0EkylmdIqE1aDEsPe4Ff4PACyMNeRlLMsgkLPCwkMZWpZRFuZCaH7JJvx8eRZvIZ" +
            "Dk3Uxka6H/rOzVR4QSOpoShJUjRlQBYoqAE/x3R6FsnNvv+u9CNLWRGLTWojX3D4" +
            "/UC1FvPSeS5YThmxkz6jpXaXGQ+cWJwt0b6FwDxREUx+cr5bgApoR7kUsR6l7okL" +
            "ichbwV7APi1NjdSReEHvPqg1iFR6fLThcbHuOTTm5CgBFPstK4vG8KhJbd6IRs5/" +
            "w3CnX95xPlCdrR+Up9RS4mnEfAtg/FdcxSZafbvEK/vVoyYxsuDoW0Jzy3gJWKev" +
            "IA+w+YyJzxx7eKkrnGDCfMU5BiE9d4Ns372qN7nYFhEmipYEhNHca+Kmwql/imHv" +
            "wAEGywjYXsSl5MLcxJn/9h6+XZcNCebpOHPjhahKEbRdSKITSklcMfe5EWuKZbkY" +
            "RglV227SuCZsbxUXNEXHP7TucQMK7QtTKABUs7rKqldoEOW+3RvR0VZaC2AEzvEQ" +
            "Cup/jpUE2n/bcXm5ytI44X07Uy0b0OB+GZacVFe3PQKfjK3DyzIbn+t2UzoumMgE" +
            "lSv+iqcDOcP2u2oDMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
            "hkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJ" +
            "bmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJU" +
            "ZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykx" +
            "MDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBD" +
            "QTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJK" +
            "UDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAV" +
            "BgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVu" +
            "dDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IB" +
            "DwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4" +
            "fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XD" +
            "gcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/v" +
            "q60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2" +
            "pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P" +
            "4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRME" +
            "AjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yu" +
            "c3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYI" +
            "KwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkM" +
            "F2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcG" +
            "CCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAm" +
            "BggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgw" +
            "FoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwF" +
            "DvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB" +
            "/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqs" +
            "XWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiq" +
            "QwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9" +
            "vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/r" +
            "DfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfG" +
            "ipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQwggGsoAMC" +
            "AQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQIEludGVy" +
            "bmFsIERldmVsb3BlcjAeFw0xNzA2MjYxMTAyMzhaFw0zNzA2MjYxMTAyMzhaMCQx" +
            "IjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3" +
            "DQEBAQUAA4IBDwAwggEKAoIBAQCHK0s41qpcI80Fasb2laejb9scZXn8URyV8KG9" +
            "i598QAmwPkScC4IvtmoDU31hdtb9ci872Jm18ocstPOR2V+I3FdsmdsRKg49Zs6j" +
            "zUbTFa3xAfd/h9aWs4Gqg0ZM0tJttsmCExCBCOlgCc0n79Obg/TAQBrZtxvXYLIN" +
            "j/fcOsTCjjD+9MjP9FZ6K3rgRjKWh7wSkD+lgj21/ceuMsfTN5KpsON6Bk3zNgfJ" +
            "4XvE1sFy2IZkwpmZQaarK0rTQp4+zR9CxXg+R9mPEXRPgR03cWIMh8gcnm0aIy4x" +
            "AwiwNrdOYth/zNenWQW6+DrP6exhcUFQQca7wvycCAYGVDVnAgMBAAEwDQYJKoZI" +
            "hvcNAQEFBQADggEBAAubCdTGQWgX+fBXy9q7WHSkIX1Q/85JmTBUdVXVrQqutOku" +
            "Su3iyw68IN53WWcl6d1ZikXkZP8vjjLL1Ab8JwPPxDy0s3W3LZwK+n5w8KMVEPnH" +
            "tRUE3ebND0Ya29oCtZdlFf1RhvVU7rMGwIXSw1JHCx/hUuKzHbecEsIdxAZN+8Zo" +
            "KYjEi567U9AHB7U5K5WqJGvj+QAuEIburCwK3r2zApeWY4CfaC5AobmilK0HodT3" +
            "apNE8FYdfGCjlBULbgCu0p8PdShTHKS1TkHqVQkLrwwFvLCRcJROXIz1n+6LdqE5" +
            "r4DR2ueC+BbXmaLByuWqMF27rN4DGn6JLN4ghPg="

    End Sub
    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used when the application is launched to open a specific file, to display
    ''' search results, and so forth.
    ''' </summary>
    ''' <param name="e">Details about the launch request and process.</param>
    Protected Overrides Sub OnLaunched(e As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
#If DEBUG Then
        ' Show graphics profiling information while debugging.
        If System.Diagnostics.Debugger.IsAttached Then
            ' Display the current frame rate counters
            Me.DebugSettings.EnableFrameRateCounter = True
        End If
#End If

        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        ' Do not repeat app initialization when the Window already has content,
        ' just ensure that the window is active

        If rootFrame Is Nothing Then
            ' Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = New Frame()

            AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                ' TODO: Load state from previously suspended application
            End If
            ' Place the frame in the current Window
            Window.Current.Content = rootFrame
        End If

        If e.PrelaunchActivated = False Then
            If rootFrame.Content Is Nothing Then
                ' When the navigation stack isn't restored navigate to the first page,
                ' configuring the new page by passing required information as a navigation
                ' parameter
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
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
    Private Sub OnNavigationFailed(sender As Object, e As NavigationFailedEventArgs)
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
        ' TODO: Save application state and stop any background activity
        deferral.Complete()
    End Sub

End Class
