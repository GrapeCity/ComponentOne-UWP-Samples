Imports SparklineSamples.Common

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
            "ACgBKAIoB4FTAHAAYQByAGsAbABpAG4AZQBTAGEAbQBwAGwAZQBzAJmdxoB9hV9v" +
            "+XFKqZBDkham8nY0v2bxW3NK+4UwkEzOV2L1B/hPztVSX/bwUcPN1dl5yOBCn2ES" +
            "utvGj+5sH/ZL7PXdgBpq3/lWHZm+BpESMgyTc7SBgMYBUAYkmvnfw3hNUhunHo65" +
            "GR28guYsnHZI1HU0QYSof2+I/o5St6L30mqY574p5kErNWq9hsyvAmd1ZfmMNKKJ" +
            "zwQSPxeyLaTsnLIUAzJTqvG7POhL/b01/DudCr6JKQ8DzsdOnW8bVG8x32xqJyaE" +
            "i8b6R8JjpCnaKVbujnjoQtuCJYPZTrWGMwg0rsugDmtmACrfD+7pzDIONDIdEm3E" +
            "K5UvvQaemeQC/pmDtjriOfUpGBEScLeuxSJVhwbbAL/uQCuN+swGGdDNKGhNhucH" +
            "hW6NHT7OIGehd+EhGlRbqQzGbxa9NEbEUHDHcg2Yt9lLxgOdOGsEBd0QNU5zywaT" +
            "oh+hbhocNfwGLLBWRX8809k2LQQZA6LM5WEJ3oyCtf4SogvdzQSc/EdkJPuN2Cg/" +
            "aZK7/839mjaYJ4i6WY4IxiDd0sz1JpEg0hsEPXswQkk+GOKF0Sthk33UwHBf1yM2" +
            "7RDcVY+fZRKeFC3FVU/yy/EdBiAbYeWAbQyGcPrtUZgn6E9PMRzO96HONF+AZGXA" +
            "auCnAOHF/4FLyz67+sB65lwqxK/C1LIgMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW" +
            "2ybGvRCUizANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoT" +
            "DlZlcmlTaWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3Jr" +
            "MTswOQYDVQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24u" +
            "Y29tL3JwYSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNp" +
            "Z25pbmcgMjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGG" +
            "MQswCQYDVQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkg" +
            "SXp1bWkta3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29s" +
            "cyBEZXZlbG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqG" +
            "SIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2" +
            "VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3" +
            "kbEOM70W+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7ty" +
            "CzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso" +
            "696/8CJ940Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3Gx" +
            "aO+L2sGBrZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGN" +
            "MIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAc" +
            "hhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG" +
            "+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUG" +
            "CCsGAQUFBwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoG" +
            "CCsGAQUFBwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3Nm" +
            "LnN5bWNkLmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5j" +
            "cnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa" +
            "8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3" +
            "AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOo" +
            "W1XqjITQiZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqM" +
            "Xn5U6R4J1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hX" +
            "L49uMIe93bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4M" +
            "iy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LA" +
            "RObC5Z7oz/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia" +
            "4DCCAsQwggGsoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZ" +
            "R0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEy" +
            "MzEwOTIwNTZaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIw" +
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCxQQxykjwXtMvO2FkyeKGz" +
            "KxsIcBfxsNRP1jvnVVaGHfMfop3Lf5+8xV9MDQL2bYc4QX3QB6cNlXiI2Ohq2GOn" +
            "vygH8lYDIC/GBj3G2FheZKzdBy70VlOeyZ5iUo1263YiAglDV5y2SUIjFyrcKLik" +
            "sD1Y6Q6fh3doPZLwTaBy1HxqlZjk+FAx2cgioMRlsU3/WCY0w/6vTgHXldzgDtjh" +
            "EVly3bNR9bwRqkBGokk2CSDfUgd7oYgGfjwHU7h7Vf3rAaWcvHqAF2A7Vfwzlb1o" +
            "HCUszrtUduKxDvU7KkcsroMRTOG12b+yz/ksGxDaAxPf43zHr9ru66DgsWgsVrnV" +
            "AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAF8iVCXpcikHoXzPtuKlH2d3XaZ2/IyH" +
            "AGXEcCi8tqygO7+6163yNzUylrhxgwcnEH8y9x+r3DZ73dr380+kzesG1JlLGxsm" +
            "tbg8nXDCPdwUNbeD5fbniDRPrLyGT/L5/UAuPTK64ZmeAM7d1gOZFpg0GxGgAwmY" +
            "NfQwwHzQhCrU3G19mH8bRKj41mjTQXWkqiGkNvCauU/bFyAdLSYu6djtQxWKey3C" +
            "hubHi/KLysxQ8vwWkqrR6/iK9R0WxF9k+IRMAj3WVYW0G6leIIIGiqd27xCKqkyI" +
            "hOtYmP0pfEzB/xOdm7mv+4CDoidCoLFceFtEJnhh7BW2TckCFqVLqaY="
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
            If Not rootFrame.Navigate(GetType(ItemPage), "AllItems") Then
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
