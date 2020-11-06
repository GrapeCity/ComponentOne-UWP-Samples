Imports BarCodeSamples.Common

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
            "ACQBJAIkB31CAGEAcgBDAG8AZABlAFMAYQBtAHAAbABlAHMAEwjuRdfy0t+ueflR" +
            "1lgthZNukmb3bC+OvtvfpFNmejwnvhJ80ClylEruGmIVL6PGrgcdzRQSWWp9JVEa" +
            "/E1WGusWScsVmr6Mw31ePgSVaYptEp5s2jUyTE2hfd53TkO6P6kLVgF5YRwgWL8K" +
            "/u9Y6voJwumaRBrrlONLxOUdRC9sI15vKSJ4iCys5zmIZwEqqQqKUvmx7HssPnFR" +
            "K7J8Z2b4tRzYk070Rm28Bnz7cSM3eYKPkuQwCBS9/dhGEkOv2A8xXAdBqmYxQG/4" +
            "zVwA7geD1A3eFDvGryb2Os82EAnJF4f2UwoQ3xD2lqqbe3LzvFBXIJ7GjGopuRhW" +
            "3GeFpDiiRodW8fs4NHoCeDkDusLYq2jqedMMqqVOE56kgcCcibEdUnbALLGtXLKQ" +
            "65QUpBRlo41psH0/5DTJnN7NSjXUdW1N/G+qHT4Jx2Ok2NB8rctgBz7AKfgQM9j4" +
            "cI/gQ+3GQrmRC/5cn0/oQofC5fihuYOiAsW2F8NGk2gS3HuJin3WOioU3IRNnzfG" +
            "iNZGY25Y37F2cFFEfTyeX2a96Rib56nlEM0a+osz01gmmpQIWizVyr4rcISes7Fb" +
            "qCMhi+3Zdr9ARFqW23GcHuKeNfkpf2J1aOpO+VZ5xZqTmiCb2UUaEF8Ti0tZIGNm" +
            "oSBFpabLQJuvVbcjS2T6nPgQ5k4wggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9" +
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
            "DQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALtmeGc5XOwZPwjOn0q2pNuAYr68" +
            "XjXlzQAoaa4TW2wDr2foI72YL5gWuThkDp6yDLEKCsBIuPZFTUdnmBX07pOt7YfQ" +
            "sp7tS8bRv+LOfWFvGVT9BbNLSylp7JFnYCuJOT3wpw9tyFFxo9Jnfe/c4wgY7eyl" +
            "2jZY0nTewzC2J+ecB7EdyIva2vjR4SnW3uwY55S9cb43XAdBqi/hEdv1FlLD6GKs" +
            "JDEK5O2e4Y1FH6PGrTN6VZYsrvOgYXvaTnZZAKhIECOZNuNXjwVKYv1oRTdjK8iA" +
            "iZiEfEp3rXM/0OFRIr8k5BThnsAJj9IYdd/N+K+HB7zCbS1MVoUfG71aLhECAwEA" +
            "ATANBgkqhkiG9w0BAQUFAAOCAQEAL11cmKPmD1YUgCEiMMx7ReqUSGCZqttIBGzg" +
            "rjkzOucEqMBqRBpE88bfjw6qRH8spLPJl2EuW7+cA/XWsjCQ31yae4vtUdexwG8a" +
            "ytjKtIZ3e2tEivIwNMAPlTD9S2vzrJK6+UQMQz5MDjy+Mu+uwZnJAAkoyzFXntz2" +
            "fB5PFVhvDqpJok0mQkVzIpB2QmaiFjSqHy/kYMqkEkJMNRN4GFDlwRMZ/2ONkgJa" +
            "WowS7GvQdJ59Gh6/Jespitw6Af+1+ux2Xu1ACimZdDBmtu72w7TqAXLhUz4JoWmG" +
            "amHN3M0t4j0lXWp7D8Y0uRTVo7XCXQdWN59tsTBdnXfjIhLIKQ=="
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
