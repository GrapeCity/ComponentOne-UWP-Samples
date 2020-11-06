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
            "ACgBKAIoB4FEAGEAdABhAE0AYQBuAGkAcAB1AGwAYQB0AGkAbwBuAHIFhKZ6c3mS" +
            "GdEK9IDAudS5fcJRroCAZ3e8O2sJYb/QSF++Gcr+1hWM5BiVloOThvCq1nqcCjcv" +
            "PFbpVuYXglLRyQTyS+GlxO13vnC/HYVRMm/8rIl2U0EI20zZhI1pN5RrFrrfmZAx" +
            "2aVhcd2MK1/UNtWFNwEweTUKYtqB1YHRhd1DQ36Z/ir0d9r4qYAOUHQlDr8FAGjs" +
            "tDJeXoMdjfu5htMlWh3FPpDewUUcHyB7mzFN+chdrUG+Swu8wbRbTJHaI7fJerNH" +
            "A0oBpqnEanBjbFfuM5eqpU4enK1xAtautSWNG8SLIUxV+jrFMto0CYdOz6t0PD6z" +
            "9CE1H7sH9Vt5J02fhnZxLmtHMczMOGmuB1Zh9texsKlB+hAAmiQxb+Pecfw89fWe" +
            "yfteNCTu/QdFtY/B4PT13YD5AueYzSBjpVH+PnukB606BxbIPasLThrJZM5t2cqP" +
            "PxWZ5VAlKEvWy8tvlmmKQw5o+ou7nFdL2uY0OiARD3tgQZw/pA4NX5VS4J4B05EI" +
            "lBwNgivCLo3kQ/ozojULIQcKKSanUJj0a47uoBbbZJmoMCsNPL2l8RCkwCLX86nB" +
            "9FClwuz0nfFnuyay17V5zBA9CZ+XoO4DMOyDohIwM049F3bm4AUi7leLryviE0L8" +
            "psVfOdKKIvOPzygSyvAqp2TQtBsF2m7oMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW" +
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
            "R0MtVVdQIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDExNjQ0MjdaFw0zNzEy" +
            "MzExNjQ0MjdaMCQxIjAgBgNVBAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIw" +
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCNNV3Qq3GjLJfCZoYU+YWY" +
            "OD62AqV6jxPCGTLc8vqLVXBwlx9XVBM4gDmBoAnnaafdihp12XsxUY910ziPksBk" +
            "2o5CzuQqkOKqmucHjRZ/hTcV8RDHXmOfKAeu/r+rNh50PgReHKwy9jxMc6resQVk" +
            "7QxsJplVuPiC7R+/jU4M2rfH7uYwUV079bBCWritYaYbjnpTwBBd77836XEWArsC" +
            "dSg5PuQRsApn2ST4wrpbk8CosZcvR1NpkpiJrnEQUYktyuW6od+mLGY0SVuCzKjU" +
            "DAGQMRiY79DYp+SXItqmuFxGZCOcO28fSYmGdjccci70SPHc4E5pXLGKTVGWEteL" +
            "AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAFiA1ogXRWyVKLEnytK3t4pxE/9mp3ak" +
            "Jv+tS86j8BmOna57FB0RIC+fOhl0VlLY4xLLDjjyKIdDBdc4PLupYD3DpkJj1Wrz" +
            "2IFeC5vMDTFPkRNE6iPZo2kvh4q7q4qfS7cRKgn2FJ6wXBcD1ml8bJ2PpURSuovN" +
            "tqbrKuh8LBerPwiyZMPTWM+1W5IvlVqaE00Vr3iJoNt4a1ii5jEZZ8j3E30vzmS6" +
            "IYOATqFXVtKXW1AQlud4AZfgIw9e01eYYXbTIRZ9Efgq0cA2tcySHGoLu0kKr0w4" +
            "vMvf7/+Rz6DyJPbGNuWsLJeOrhgUtN8qPuGHYB4a7M8eR/+NydNmQN8="
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