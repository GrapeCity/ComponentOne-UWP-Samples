Imports GridTreeViewSamples.Common

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
            "AC4BLgIuB4dHAHIAaQBkAFQAcgBlAGUAVgBpAGUAdwBTAGEAbQBwAGwAZQBzAEIu" +
            "Lva8v6tQmpOVtRGLwVDeiFF0JB3e6URTl72B1CMUlSlfaaA5zhJhNEjfJSuZ6S+G" +
            "PtQwKm5Kq7zX4gRK84EP1NxynRulFBcKr6dsfgBKXiObhdqdnuJzH0uXggE//L7c" +
            "F4/a2Mn1fSHXb8Ntqg5MRv6csaRPhBY9jEzE7gJcLvs81cUEYcV4/k7vzSPaux6b" +
            "JGfFp3yKjAAoWxAFS/pVbqvDvBfUD6XE/IUZah/xeEAXuWlI0+6LraRE7FJUb5ZX" +
            "V7NNJ+sjSwMUgbcYf3W1H8YLTONLk6is3zeaS7eyOrPujqBZlbtob87WAoBur4LR" +
            "pyd0SYnoPXk8chk27n1faECdcD2SNoLvXS1nYMK7ISxMMGdFbAUdPXxG/qZMKNJr" +
            "zW35srYypfZH7NC6ja00wN5TNrDsYOR0mpl1SwvYlWoZp7odJTarBl/DYf8uW5Yc" +
            "DcYanersM/s10arXdqdnY+4ULicgHfsfgiWVfZzrs/Po2vU2OxxcpYPQJyZ6Uuq9" +
            "JK/udVQnMxK/v5YM+siBFv/eN45lxTPwt4/1Ial5/3oeC1dVbPT7avcEw+AIkAdC" +
            "tYMCFAXVlLgYKBayWyW8DQxX0uKyalECylk/XJirhDo4h34diJsx/47axwZWQIkT" +
            "OnPkaEX0TtxEElMIgeaISAj9JN4ZNrdDv+WKCpYbMIIFVTCCBD2gAwIBAgIQQQN4" +
            "0iY2WXoW2ybGvRCUizANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAV" +
            "BgNVBAoTDlZlcmlTaWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBO" +
            "ZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVy" +
            "aXNpZ24uY29tL3JwYSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBD" +
            "b2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5" +
            "NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9T" +
            "ZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQL" +
            "FBFUb29scyBEZXZlbG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEi" +
            "MA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvP" +
            "mutMe/B2VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVH" +
            "zOgpXam3kbEOM70W+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0" +
            "iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZny" +
            "HSKAzSso696/8CJ940Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1n" +
            "n/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMB" +
            "AAGjggGNMIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAi" +
            "MCCgHqAchhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsG" +
            "C2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20v" +
            "Y3BzMCUGCCsGAQUFBwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1Ud" +
            "JQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0" +
            "cDovL3NmLnN5bWNkLmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNv" +
            "bS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0O" +
            "BBYEFABa8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgor" +
            "BgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VY" +
            "irEXwgOoW1XqjITQiZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeW" +
            "V+LGZaqMXn5U6R4J1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9" +
            "jyek00hXL49uMIe93bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyK" +
            "ToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9c" +
            "akwaV8LARObC5Z7oz/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3r" +
            "y5zGIqia4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAG" +
            "A1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZa" +
            "Fw0zNzEyMzEwOTIwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZl" +
            "bG9wZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDDMH3CU8d0J/PW" +
            "p/+nr9t5ku8S6T5xJebPTIjaEsh8KbEfu2ZiLh41Bk/HYynk8L2hMCqoi70v3nbQ" +
            "o77XzOKaTe6puZRvz2cgh8rZlpxZF16Tx/jgk7iZ+Nhv9yKK/6EEPJsMhB9A5JcN" +
            "p5suh3ms9aXrR5sxExKwKiurLb83KoNcXTvPoQ8T7EkuTu/o4oQh1Y5akd+ISpyy" +
            "bYbjl9yZc6lyRIovbszGoQgBf77Oe6ERhWlKi+fAeRpp1ovSUHBBvuuyeoU5Tw1R" +
            "9PAr+/X40lL0fAUscA4bxVj7o710mPVc2YOxVqLriIu1p7Wfzc67+rg5pgX51bVK" +
            "wKA8kvbTAgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAD/0a5RGAhV0EpOyzsaTsddE" +
            "VGwkKUxJS/doghcUc1TFDD18FLNLIEtJ840F0cra3HASvtclWHvawYLAZSMkR2eO" +
            "F/wZlEgSLMWIlc3PM49/8RmF3y7fLsxYlgsI2Y5DPiFiAtmydW82ADpYgp+Hj0C3" +
            "kEuUMHTb+WoFBW/P9fyfH87u4XSGO/g/KMtPCkoqGSDbtjFdT9iFjPlmyLIYByB9" +
            "KLGxo/bPuLySnofl1hbjW60vHB26jp7a/8P/RFgMHg6lVhTqnOy401JzxIMLQYZj" +
            "h1OzLQRs1lr5rBPQuj7GGIhsg4aFFBHsueUfDmkoBmYP3wPk/zLwfBViyMtLjTk="
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
