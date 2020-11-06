''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
NotInheritable Class App
    Inherits Application

    ''' <summary>
    ''' Initializes the singleton application object.  This is the first line of authored code
    ''' executed, and as such is the logical equivalent of main() or WinMain().
    ''' </summary>
    Public Sub New()
        C1.UWP.LicenseManager.Key =
            "ABYBFgIWB29CAGkAbgBkAGkAbgBnAB2V0igGyjDd3UfKOM3DPbINR+rPwUVDTphw" +
            "Vxn2Xy4tOPLpHkhhRCIBQ1L9RUJGBURdhGorXaj2qnwL8HRNWnw3LskzASyatVKX" +
            "hRCDhGlWVpqtq8HABn93Kmu13nNidA69zXCZ+X0SlHTvFqTiGuVHiClbJNtzQY/A" +
            "cXSa6NfClH1AJOopZDkVF+hRhs94lxheTGtclfjtQ6xpCxUypMoxTM2PFyi6xstE" +
            "030ccnZiwENwvlpiSxW9XSITm19MSZEHWmvLc+tISj9XbOjxyhVVHtcZoFE3YzAL" +
            "IcR76BKnPT9NXh693jBxyl83kmZrin00aiPUmkFGx8ChFg8fSTlveqTibayEHPA0" +
            "N95c3dJFwQGDmG+vkCiLIK6VbaaE9+AFlJmcor/+6EdvZxhtj1281hRuyV5zmpKv" +
            "zJbXxB9d/oBp8XRh7g38ZW6SF2d5oX/ojNSEqcANk+SChN9OMu37RTEsNjPFu6oz" +
            "0P6Z/1PYswRrBWXj1g8WsgQ7nSwxZwvf1OEw0+5IwyxqDhGUJw+X/BM8Mm39SMdx" +
            "hK2klyiQE9QQudLjkvqnQNg/iKjQSRns95D1h59sTDNkpQOJ5uF53B4PA2mMqQ+Y" +
            "gKkXzMGcEramUpNxYCYtF1hEFXuRJf2fwya17VgCyweOUOAAigvgxUT/RI8C41l3" +
            "D+4uqGX3MIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkqhkiG9w0B" +
            "AQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJbmMuMR8w" +
            "HQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBv" +
            "ZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykxMDEuMCwG" +
            "A1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0x" +
            "NDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0G" +
            "A1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoU" +
            "DkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVudDEXMBUG" +
            "A1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEK" +
            "AoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4fDPR2LhF" +
            "U0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XDgcH2DsdM" +
            "KHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiS" +
            "l1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2pohzbFPz" +
            "tuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSE" +
            "GggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRMEAjAAMA4G" +
            "A1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yuc3ltY2Iu" +
            "Y29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUH" +
            "AgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkMF2h0dHBz" +
            "Oi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUF" +
            "BwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAmBggrBgEF" +
            "BQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp" +
            "6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwFDvhWG46O" +
            "MBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqsXWL8N4LB" +
            "eKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiqQwbJO1pI" +
            "YhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9vdH6cA7R" +
            "2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1l" +
            "zaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfGipQSQykS" +
            "NyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsQwggGsoAMCAQICBA7u" +
            "7u4wDQYJKoZIhvcNAQEFBQAwJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERl" +
            "dmVsb3BlcjAeFw0xNzAxMDEwOTIwNTZaFw0zNzEyMzEwOTIwNTZaMCQxIjAgBgNV" +
            "BAMMGUdDLVVXUCBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0GCSqGSIb3DQEBAQUA" +
            "A4IBDwAwggEKAoIBAQCxPM7L7BqkB3eOlnMjElg3/LdYH0b6UcI/ENilN8jzuLj9" +
            "lmBE3kgV5EMJY+UZo0jatQpYY+PHLFr+qR2dsiBh12BD3Bg7Bu5JbPxtCtUPS9pG" +
            "IS5fWfD3gHZd48C8rWxOofoz4NL4Kk1770mG3XGBQ3hBRinAxItBYkmAHPNpUUcY" +
            "CYT3DmPjK1w7+KnvzEVs9bWafJ7nRJRyFO41Pe2k4vgA2J0xfU3TUbWBYes+8CPd" +
            "qSqVkBt42TBbgPmO8Rx4rQ1eImf/49KssAxSNbLJAGPkm9lHbhL8ZjdMQTI5gjPo" +
            "dEdozMhVgO6EfFuZ9cmvjzaC1ewuThtrzX+9biSPAgMBAAEwDQYJKoZIhvcNAQEF" +
            "BQADggEBAEgKXE8SnpTN3v9nZN4CLizJ3bPZ+eRXtmw3hE3noCIpe72Tcfd9Ce9T" +
            "9Uo2UMLXOarNNzDAz5ycKQeJw8JRqFZqivQvZ76grfiAl+rM/M/TUb5jYh2+WTLV" +
            "PLydgzR9DxooyWjvaekfKdyTeWIkzmd1nyOgHuxyxQckc6fiZo1+DPoysZtGYJxO" +
            "WGWxq6ELJhMUpXvgybgtSvLCpaPbUPYHJii5oUrBtjJ+lLmPTOQV3794q5HpmOHF" +
            "H9HzyF1KHaYB6FWE72YGC2vTd5WyDjHExX6YbR8nDmp2vHPPg3aR2QbKxIQsQGA6" +
            "nCBHf6YlLqOjoN9VVsyeQc4ZJiESaig="
        Me.InitializeComponent()
        AddHandler Me.Suspending, AddressOf OnSuspending
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
