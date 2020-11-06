Imports ImagingSamples.Common

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
            "ACQBJAIkB31JAG0AYQBnAGkAbgBnAFMAYQBtAHAAbABlAHMAT+gCUoCB5wrnMfWe" +
            "jlmN0HqcS4f4sfd8yjc/t2G4B5cxaUEYmsK96ee8DaG+dsH+zCr71LgGk5dlSjIX" +
            "AG2Drcqt2qfmyyD93zqPUQqesyB+iW/TEaPzkn5yuDMPcioH2zv5OFF9N7h/1BEG" +
            "zXUArHHeNIvVX9I844Lvn5OE5k5RxVkHSKK009pqq+SAvKsgGEQZ2jZ3I1Ih2fxT" +
            "BVpq0Xs/ssEOhCOzvVAkrTfbvP0BeVJD68URt275CPOe9W62P2GER38XLdN3Vkjj" +
            "VYmVSbe8oYlOMfvGQHPfypluy3UgB9MdwguuMbeki6aMN+LXeb6hhnyl1hmS1vZw" +
            "NhD6Zp7yWyGl1VnnVw0wFl/gmyuvpZkmrRyz2gVz4llzFVWx4V00EzoHkrNgv5OB" +
            "YXm/TWH3L9GhnVIbhBPDufLQLF1IrFyExUssHGYLVVHsO2CT7l0bU/LeUmaHt1Uy" +
            "gc2nyaMo5mXcQX5dHhzD8+kCNPUODl8Z+ZNO4GBV2DA5W2H2OSrPdZxAukJ2bbUp" +
            "EAP2r+KQ/bK1ypP2MhdZGPFrAaYtGTF5Gpfapap+cIUiNpoKFVPfcvqX6/o7lm6i" +
            "408sfgs1IL67XdCVk2cu+Tk4h/SZ9rtQNaHMlVMwWAYJHtGPeGwqGpVxA87RNh/+" +
            "fyRO+DSi4WgaFdc57b5MikCMguQwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9" +
            "EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVy" +
            "aVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5" +
            "BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20v" +
            "cnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmlu" +
            "ZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJ" +
            "BgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVt" +
            "aS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERl" +
            "dmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcN" +
            "AQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvA" +
            "js/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4z" +
            "vRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3k" +
            "uux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/w" +
            "In3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74va" +
            "wYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJ" +
            "MAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0" +
            "dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEH" +
            "FwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYB" +
            "BQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYB" +
            "BQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3lt" +
            "Y2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAf" +
            "BgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXU" +
            "eDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsE" +
            "CDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqM" +
            "hNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTp" +
            "HgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24w" +
            "h73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO" +
            "7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLl" +
            "nujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIIC" +
            "xDCCAaygAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAkMSIwIAYDVQQDDBlHQy1V" +
            "V1AgSW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTA5MjA1NloXDTM3MTIzMTA5" +
            "MjA1NlowJDEiMCAGA1UEAwwZR0MtVVdQIEludGVybmFsIERldmVsb3BlcjCCASIw" +
            "DQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAJDKb6ubJ0UymTcaaBySmQXihkwM" +
            "e6onB/z7OJlI4XhcypbQdpMYP37eHsumUYjrZ3MOEnfvfRnESJb4hGx9yzRego5G" +
            "4wUW4VuHh7nba0cpUES/54G39DVDG2Ac7L50wE5dzx3TKpQ2mZAa8A5MaM5walra" +
            "vuLOoNDP9HrME6niElE3YkqtvDFf3b28EX7wIw5Ggjt6kQB1YBKgPnREyKAYVqy2" +
            "vLSjURcK5Ae3KktkD22NlkpwK2ZOiXmeEKcHR6yrif8/KbEWg7SZ/T4opFu8Z0z9" +
            "ZiB6MVM5IfApPn96XNFgkoofseN1srZnOFfdIHsMY5K2lRorngWMh4H0QgsCAwEA" +
            "ATANBgkqhkiG9w0BAQUFAAOCAQEAE+ZlsC2LcEVQ/kU1ovRYsguPwDoM/cmmCT65" +
            "QpBvAzvZKZJkLpf+zETvWjaqbDdqmAMUKGPg92LhHM5Lh/XoCnYvS1wxhN2HwdnN" +
            "cztK6F5n+P61CfDV5Knk3N/1bbjkGm9SNqkRQe2MPh58x1oaaCw6Ym0uq2rfvocV" +
            "OXg4k9UhVYw9OvYUfjH+cHA5fjPVa72S+pMfi0+lxE6EqSo+ace1wnccOIz8ecBK" +
            "5Rqo0IrxjRRHs4WQNAw0AKovYu1xyqKRRMLbFizD1YdFd3poh23bcwvZ7dqsRMd0" +
            "WbHAbbkhtVIcMtRx9kdjFirzHRYc1b63KqXj8JJhfXBqj6TRmw=="
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
